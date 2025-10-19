// DeliveryQuestScroll.cs  – revised for XML trait system
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;
using TraitSystem;          // ← TraitXml, ITrait
using CustomNPC;           // ← ITraitHolder

namespace Server.Items
{
    public class DeliveryQuestScroll : Item
    {
        // ── CONFIG ────────────────────────────────────────────────────
        private static readonly string TraitXmlPath =
            Path.Combine(Core.BaseDirectory, "Data", "SosariaSpeechTraits.xml");

        private static readonly Type[] DefaultRewardPool = QuestScrollRewards.m_Rewards;

        // ── STATE ─────────────────────────────────────────────────────
        private string     _traitName;
        private bool       _delivered;
        private int        _goldReward;
        private List<Type> _rewardTypes;

        // ── GM props ──────────────────────────────────────────────────
        [CommandProperty(AccessLevel.GameMaster)] public string TraitName   => _traitName;
        [CommandProperty(AccessLevel.GameMaster)] public bool   Delivered   { get => _delivered; set => _delivered = value; }
        [CommandProperty(AccessLevel.GameMaster)] public int    GoldReward  { get => _goldReward;  set => _goldReward = Math.Max(0, value); }

        // ── CTORS ─────────────────────────────────────────────────────
        [Constructable]
        public DeliveryQuestScroll() : this(null, 0, Array.Empty<Type>()) { }

        // 1) Allow [add DeliveryQuestScroll <trait>]
        [Constructable]
        public DeliveryQuestScroll(string customTrait)
            : this(customTrait, 0, Array.Empty<Type>())
        {
        }

        // 2) Allow [add DeliveryQuestScroll <trait> <gold>]
        [Constructable]
        public DeliveryQuestScroll(string customTrait, int customGold)
            : this(customTrait, customGold, Array.Empty<Type>())
        {
        }

        [Constructable]
        public DeliveryQuestScroll(string customTrait, int customGold, params Type[] customRewards)
            : base(0x14EF)
        {
            Weight = 1.0;
            LootType = LootType.Blessed;
            Hue = 0x4B5;

            // 1️⃣  LOAD TRAITS FROM XML
            var allTraits = TraitXml.Load(TraitXmlPath).ToList();
            if (allTraits.Count == 0)
                throw new InvalidOperationException($"No traits found at {TraitXmlPath}");

            var pick = allTraits.FirstOrDefault(t =>
                            customTrait != null &&
                            t.Name.Equals(customTrait, StringComparison.OrdinalIgnoreCase))
                       ?? allTraits[Utility.Random(allTraits.Count)];

            _traitName  = pick.Name;
            _delivered  = false;
            _goldReward = (customGold > 0) ? customGold : Utility.RandomMinMax(1000, 5000);

            // rewards
            _rewardTypes = (customRewards != null && customRewards.Length > 0)
                           ? customRewards.ToList()
                           : PickRandomRewardTypes();

            Name = $"Delivery Quest: find a {_traitName}";
        }

        private static List<Type> PickRandomRewardTypes()
        {
            return DefaultRewardPool
                   .OrderBy(_ => Utility.Random(0x10000))
                   .Take(Utility.RandomMinMax(1, 4))
                   .ToList();
        }

        // ── Double-click → open gump ──────────────────────────────────
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }
            from.SendGump(new DeliveryQuestGump(from, this));
        }

        // ──  Gump  ────────────────────────────────────────────────────
        private class DeliveryQuestGump : Gump
        {
            private readonly DeliveryQuestScroll _scroll;

            public DeliveryQuestGump(Mobile from, DeliveryQuestScroll scroll) : base(75, 50)
            {
                _scroll = scroll;
                AddPage(0);

                int height = 160 + (_scroll._rewardTypes.Count * 25);
                AddBackground(0, 0, 300, height, 9270);

                AddLabel(40, 20, 54, "Delivery Quest");
                AddLabel(40, 50, 54, $"Target Trait: {_scroll._traitName}");
                AddLabel(40, 70, 54, $"Delivered:    {_scroll._delivered}");
                AddLabel(40, 90, 54, $"Gold Reward:  {_scroll._goldReward}");

                int y = 110;
                AddLabel(40, y, 54, "Rewards:"); y += 20;
                foreach (var t in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, t.Name); y += 20;
                }

                int buttonId = _scroll._delivered ? 2 : 1;
                string buttonText = _scroll._delivered ? "Claim Reward" : "Deliver";
                AddButton(40, y, 4005, 4007, buttonId, GumpButtonType.Reply, 0);
                AddLabel (75, y, 54, buttonText);
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                var from = state.Mobile;
                switch (info.ButtonID)
                {
                    case 1:  // Deliver
                        from.SendMessage("Select the NPC to deliver to.");
                        from.Target = new DeliveryQuestTarget(_scroll);
                        break;
                    case 2:  // Claim
                        _scroll.TryClaim(from);
                        break;
                }
            }
        }

        // ── Targeting logic ───────────────────────────────────────────
        private class DeliveryQuestTarget : Target
        {
            private readonly DeliveryQuestScroll _scroll;

            public DeliveryQuestTarget(DeliveryQuestScroll scroll) : base(12, false, TargetFlags.None)
            {
                _scroll = scroll;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile mob && targeted is ITraitHolder holder &&
                    holder.Traits.Any(t =>
                        t.Name.Equals(_scroll._traitName, StringComparison.OrdinalIgnoreCase)))
                {
                    from.SendMessage($"You deliver the scroll to {mob.Name}.");
                    _scroll._delivered = true;
                    from.SendGump(new DeliveryQuestGump(from, _scroll));
                }
                else
                {
                    from.SendMessage("This is not the correct NPC.");
                }
            }
        }

        // ── Claim & reward ────────────────────────────────────────────
        private void TryClaim(Mobile from)
        {
            if (!_delivered)
            {
                from.SendMessage("You haven't delivered the quest yet.");
                return;
            }

            from.AddToBackpack(new Gold(_goldReward));
            foreach (var t in _rewardTypes)
                if (Activator.CreateInstance(t) is Item itm)
                    from.AddToBackpack(itm);

            from.SendMessage("Your rewards are in your backpack!");
            Delete();
        }

        // ── Persistence ───────────────────────────────────────────────
        public DeliveryQuestScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);                  // version
            writer.Write(_traitName);
            writer.Write(_delivered);
            writer.Write(_goldReward);

            writer.Write(_rewardTypes.Count);
            foreach (var t in _rewardTypes)
                writer.Write(t.AssemblyQualifiedName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version   = reader.ReadInt();
            _traitName    = reader.ReadString();
            _delivered    = reader.ReadBool();
            _goldReward   = reader.ReadInt();

            int count     = reader.ReadInt();
            _rewardTypes  = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                var t = Type.GetType(reader.ReadString());
                if (t != null) _rewardTypes.Add(t);
            }
        }
    }
}
