// SosariaRandomNPC.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;
using System.IO;

namespace Server.Regions.Sosaria
{
    [CorpseName("the dry remains of a Sosarian wanderer")]
    public class SosariaRandomNPC : BaseVendor
    {


        // Example: specialized vendor packs for Sosaria caravans, oasis traders, etc.
        private static readonly Type[] SosariaVendorPacks =
        {
			typeof(SBBowyer),
			typeof(SBTailor),    typeof(SBProvisioner), typeof(SBFisherman)
        };

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos => m_SBInfos;

        // reuse the same EvaluateGump & EvaluateEntry from the generic system

        public override void InitSBInfo()
        {
            m_SBInfos.Clear();
            var sbType = SosariaVendorPacks[Utility.Random(SosariaVendorPacks.Length)];
            m_SBInfos.Add((SBInfo)Activator.CreateInstance(sbType));
        }

		protected virtual string SpeechTraitXmlFile => 
			Path.Combine(Core.BaseDirectory, "Data", "SosariaSpeechTraits.xml");

		public List<SosariaISpeechTrait> Traits { get; private set; } = new List<SosariaISpeechTrait>();

        [Constructable]
        public SosariaRandomNPC() : base("the Sosarian")
        {
            InitBody();
            InitOutfit();
            // pick 2–5 Sosaria‐only traits
			// 1) start with all the compiled‐in traits
			var allTraits = SosariaTraitRegistry.Compiled.ToList();

			// 2) add *this* NPC’s XML file, if it exists
			allTraits.AddRange(
				SosariaTraitRegistry.LoadFromXml(SpeechTraitXmlFile)
			);

			// 3) pick 2–5 at random from the merged list
			Traits = allTraits
						.OrderBy(_ => Utility.RandomDouble())
						.Take(Utility.RandomMinMax(2, 5))
						.ToList();
		
        }

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			list.Add(new EvaluateSosariaEntry(from, this));
		}


        public override void InitBody()
        {
            Female = Utility.RandomBool();
            Body   = Female ? 0x191 : 0x190;
            Hue    = Utility.RandomSkinHue();
            Name   = NameList.RandomName(Female ? "female" : "male");
            Title  = "of the shifting sands";
            SetStr(Utility.RandomMinMax(40, 70));
            SetDex(Utility.RandomMinMax(40, 70));
            SetInt(Utility.RandomMinMax(60, 100));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        public override void InitOutfit()
        {
            // Desert‐friendly garb: light robes, turbans, sandals…
            AddItem(RandomClothing(
                new Sandals(), new Boots(), new ThighBoots()));
            AddItem(RandomClothing(
                new Robe(), new HoodedShroudOfShadows(), new MaleKimono()));
            AddItem(RandomClothing(
                new Cap(), new Bandana(), new ClothNinjaHood()));
            Utility.AssignRandomHair(this);
			Hue = Utility.RandomMinMax(1, 3000);
            HairHue       = Utility.RandomMinMax(1, 3000);
            FacialHairHue = Utility.RandomMinMax(1, 3000);
        }

        private Item RandomClothing(params Item[] opts)
        {
            var itm = opts[Utility.Random(opts.Length)];
            itm.Hue = Utility.RandomMinMax(2000, 2600); // desert palette
            return itm;
        }

        #region Speech Handling (identical to RandomNPC)
        public override void OnSpeech(SpeechEventArgs e)
        {
            if (!e.Mobile.InRange(this, 3)) return;
            var text = e.Speech;
            foreach (var t in Traits.OrderByDescending(tr => tr.Priority))
            {
                if (t is SosariaIItemSpeechTrait itTrait
                    && itTrait.TryGetResponse(text, out string resp, out Item itm))
                {
                    if (itm == null)
                    {
                        Say(resp);
                        return;
                    }

                    var key = e.Mobile.Serial + "-" + t.Name;
                    if (_lastGiven.TryGetValue(key, out var last)
                        && (DateTime.UtcNow - last) < TimeSpan.FromMinutes(30))
                    {
                        Say("I have nothing more for you right now.");
                        return;
                    }

                    Say(resp);
                    if (!e.Mobile.AddToBackpack(itm))
                        itm.MoveToWorld(e.Mobile.Location, e.Mobile.Map);

                    e.Mobile.SendMessage(1153, $"* {Name} gives you a {itm.Name}! *");
                    _lastGiven[key] = DateTime.UtcNow;
                    return;
                }

                if (t.TryGetResponse(text, out string plain))
                {
                    Say(plain);
                    return;
                }
            }

            base.OnSpeech(e);
        }
        #endregion

        #region Serialize
        private readonly Dictionary<string, DateTime> _lastGiven = new Dictionary<string, DateTime>();

        public SosariaRandomNPC(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter w)
		{
			base.Serialize(w);
			w.Write(0);

			// if Traits is null, write zero and skip the loop
			var count = Traits?.Count ?? 0;
			w.Write(count);

			if (Traits != null)
				foreach (var t in Traits)
					w.Write(t.Name);
		}

		public override void Deserialize(GenericReader r)
		{
			base.Deserialize(r);
			r.ReadInt();               // version
			int count = r.ReadInt();   // how many names were written

			// Build a map that ignores duplicates (case-insensitive)
			var lookup = new Dictionary<string, SosariaISpeechTrait>(
							 StringComparer.OrdinalIgnoreCase);

			void AddRange(IEnumerable<SosariaISpeechTrait> src)
			{
				foreach (var t in src)
					if (!lookup.ContainsKey(t.Name))
						lookup[t.Name] = t;          // keep the first one
			}

			AddRange(SosariaTraitRegistry.Compiled);
			AddRange(SosariaTraitRegistry.LoadFromXml(SpeechTraitXmlFile));

			// Re-hydrate the NPC’s own trait list
			Traits = new List<SosariaISpeechTrait>(count);
			for (int i = 0; i < count; i++)
			{
				var name = r.ReadString();
				if (lookup.TryGetValue(name, out var trait))
					Traits.Add(trait);
			}
		}


        #endregion
    }
}
