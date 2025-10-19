#define ServUO
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using TraitSystem;                // ← for ITrait, IAttachmentTrait, TraitXml
using Server.Engines.XmlSpawner2; // ← for XmlAttachment, XmlAttach
using CustomNPC;                  // ← for ITraitHolder
using Server.Network;
using System.Diagnostics;

namespace Server.Engines.XmlSpawner2
{
    public class XmlRandomTraits : XmlAttachment, ITraitHolder
    {
        private string _fileName;
        private int _minTraits, _maxTraits;

        public List<ITrait> Traits { get; private set; } = new List<ITrait>();

        private readonly Dictionary<Mobile, Dictionary<string, DateTime>> _giveItemCooldowns
            = new Dictionary<Mobile, Dictionary<string, DateTime>>();
        private readonly TimeSpan _itemCooldown = TimeSpan.FromMinutes(30);

        // ===== XML CACHING =====
        private static readonly Dictionary<string, List<ITrait>> _traitCache
            = new Dictionary<string, List<ITrait>>(StringComparer.OrdinalIgnoreCase);

        private List<ITrait> LoadAllTraits()
        {
            var key = _fileName;
            if (!_traitCache.TryGetValue(key, out var list))
            {
                var path = ResolvePath();
                try
                {
                    var sw = Stopwatch.StartNew();
                    list = TraitXml.Load(path).ToList();
                    sw.Stop();
                    Console.WriteLine($"[XmlRandomTraits] Loaded {list.Count} traits from '{_fileName}' in {sw.ElapsedMilliseconds}ms");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[XmlRandomTraits] ERROR loading trait file '{_fileName}': {ex}");
                    list = new List<ITrait>();
                }
                _traitCache[key] = list;
            }
            return list;
        }
        // =======================

        // Serialization ctor
        public XmlRandomTraits(ASerial serial) : base(serial) { }

        // Default ctor
        [Attachable]
        public XmlRandomTraits() : this("SosariaSpeechTraits", 1, 4) { }

        [Attachable]
        public XmlRandomTraits(string fileName, int minTraits, int maxTraits)
        {
            _fileName = (fileName ?? "SosariaSpeechTraits").Trim();
            _minTraits = Math.Max(1, minTraits);
            _maxTraits = Math.Max(_minTraits, maxTraits);
        }

        private string ResolvePath()
            => Path.Combine(Core.BaseDirectory, "Data", _fileName + ".xml");

        public override void OnAttach()
        {
            base.OnAttach();
            InitTraits();
        }

        // Reattach: Only re-init if traits are missing
        public override void OnReattach()
        {
            base.OnReattach();
            if (Traits == null || Traits.Count == 0)
                InitTraits();
        }

        private void InitTraits()
        {
            var all = LoadAllTraits();
            if (all.Count == 0) return;

            // Pick random subset
            all.Shuffle();
            Traits = all.Take(Utility.RandomMinMax(_minTraits, _maxTraits)).ToList();

            // Apply any IAttachmentTrait-defined XmlAttachments
            foreach (var attTrait in Traits.OfType<IAttachmentTrait>())
            {
                if (AttachedTo is Mobile m)
                    attTrait.AttachTo(m);
                else if (AttachedTo is Item it)
                    XmlAttach.AttachTo(it, (XmlAttachment)Activator.CreateInstance(
                        attTrait.GetType(),
                        new object[] { })); // You may need specific ctor args here
            }
        }

        public override bool HandlesOnSpeech => true;

        public override void OnSpeech(SpeechEventArgs e)
        {
            if (Deleted || AttachedTo == null) return;

            Mobile ownerMob = AttachedTo as Mobile;
            Item ownerIt = AttachedTo as Item;
            Point3D loc = ownerMob != null ? ownerMob.Location : ownerIt.GetWorldLocation();
            Map map = ownerMob?.Map ?? ownerIt.Map;

            if (map == null || map == Map.Internal || !e.Mobile.InRange(loc, 3))
                return;

            string spoken = e.Speech;

            foreach (var tr in Traits.OrderByDescending(t => t.Priority))
            {
                // Item-giving response?
                if (tr is IItemTrait itTrait &&
                    itTrait.TryGetResponse(spoken, out string line, out Item itm, out string key))
                {
                    if (IsOnCooldown(e.Mobile, key))
                    {
                        DelaySay(ownerMob, ownerIt, "You must wait before asking for that again.");
                        return;
                    }

                    DelaySay(ownerMob, ownerIt, line);
                    GiveItem(e.Mobile, itm);
                    SetCooldown(e.Mobile, key);
                    return;
                }

                // Simple dialogue response?
                if (tr.TryGetResponse(spoken, out string resp))
                {
                    DelaySay(ownerMob, ownerIt, resp);
                    return;
                }
            }
        }

        private void DelaySay(Mobile m, Item it, string text)
        {
            double delay = Utility.RandomDouble() * 0.3 + 0.2; // 0.5–1.0s
            Timer.DelayCall(TimeSpan.FromSeconds(delay), () =>
            {
                if (m != null && !m.Deleted)
                    m.PublicOverheadMessage(MessageType.Regular, GetRandomHue(), false, text);
                else if (it != null && !it.Deleted)
                    it.PublicOverheadMessage(MessageType.Regular, GetRandomHue(), false, text);
            });
        }

        private static void GiveItem(Mobile to, Item itm)
        {
            if (itm == null) return;
            if (!to.AddToBackpack(itm))
                itm.MoveToWorld(to.Location, to.Map);
            to.SendMessage(1153, $"* {itm.Name ?? itm.GetType().Name} slips into your pack *");
        }

        private bool IsOnCooldown(Mobile mob, string key)
        {
            if (_giveItemCooldowns.TryGetValue(mob, out var dict) &&
                dict.TryGetValue(key, out var last))
            {
                return (DateTime.UtcNow - last) < _itemCooldown;
            }
            return false;
        }

        private void SetCooldown(Mobile mob, string key)
        {
            if (!_giveItemCooldowns.TryGetValue(mob, out var dict))
                _giveItemCooldowns[mob] = dict = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
            dict[key] = DateTime.UtcNow;
        }

        private static int GetRandomHue()
        {
            int[] hues = {
                0x20,0x35,0x44,0x57,0x66,
                0x72,0x81,0x90,0xA3,0xB4,
                0xC1,0xD5,0xE9,0xFF,0x1FA,
                0x213,0x256,0x268,0x2B0,0x301
            };
            return hues[Utility.Random(hues.Length)];
        }

        // ===== SERIALIZATION VERSIONING =====
        private const int CurrentVersion = 1;
        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write(CurrentVersion);   // version
            w.Write(_fileName);
            w.Write(_minTraits);
            w.Write(_maxTraits);
            w.Write(Traits.Count);
            Traits.ForEach(t => w.Write(t.Name));
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            int version = r.ReadInt();
            _fileName = r.ReadString();
            _minTraits = r.ReadInt();
            _maxTraits = version >= 1 ? r.ReadInt() : _minTraits;

            int cnt = r.ReadInt();

            var all = LoadAllTraits()
                .GroupBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

            Traits = new List<ITrait>(cnt);
            for (int i = 0; i < cnt; i++)
                if (all.TryGetValue(r.ReadString(), out var trait))
                    Traits.Add(trait);
        }
        // =====================================
    }
}
