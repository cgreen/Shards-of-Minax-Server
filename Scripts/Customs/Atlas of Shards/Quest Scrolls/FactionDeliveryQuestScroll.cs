/*
 * FactionDeliveryQuestScroll.cs
 *
 * A “delivery” quest scroll that grants
 * MobFactions reputation instead of gold.
 * © 2025 – free to use / modify.
 */

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
using Server.Engines.XmlSpawner2;  // for XmlMobFactions
using TraitSystem;                // ← TraitXml, ITrait
using CustomNPC;                  // ← ITraitHolder

namespace Server.Items
{
    public class FactionDeliveryQuestScroll : Item
    {
        // ── CONFIG ────────────────────────────────────────────────────
        private static readonly string TraitXmlPath =
            Path.Combine(Core.BaseDirectory, "Data", "SosariaSpeechTraits.xml");

        private static readonly Type[] DefaultRewardPool = QuestScrollRewards.m_Rewards;

        // ── STATE ─────────────────────────────────────────────────────
        private string                          _traitName;
        private bool                            _delivered;
        private int                             _repReward;
        private XmlMobFactions.GroupTypes      _faction;
        private List<Type>                     _rewardTypes;

        // ── GM props ──────────────────────────────────────────────────
        [CommandProperty(AccessLevel.GameMaster)]
        public string TraitName      => _traitName;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Delivered        { get => _delivered;  set => _delivered   = value; }

        [CommandProperty(AccessLevel.GameMaster)]
        public XmlMobFactions.GroupTypes Faction
            { get => _faction;      set => _faction     = value; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RepReward        { get => _repReward;  set => _repReward   = Math.Max(0, value); }


        // ── NEW: ctor used when the 3rd arg is an *int* ────────────────
        // Called by the dialogue engine with:
        //   1) trait name   (string)
        //   2) faction name (string)
        //   3) rep amount   (int)
        [Constructable]
        public FactionDeliveryQuestScroll(string traitText, string factionText, int repAmount)
            : this(
                traitText,
                (XmlMobFactions.GroupTypes)Enum.Parse(
                    typeof(XmlMobFactions.GroupTypes),
                    factionText,
                    true
                ),
                repAmount,
                Array.Empty<Type>()     // no item rewards supplied via ctorArgs
            )
        {
        }
 

		[Constructable]
		public FactionDeliveryQuestScroll(string customTrait, string factionText, string repText)
			: this(
				customTrait,
				// parse the enum (throws if invalid)
				(XmlMobFactions.GroupTypes)Enum.Parse(
					typeof(XmlMobFactions.GroupTypes),
					factionText,
					ignoreCase: true
				),
				// parse the int (throws if invalid)
				Int32.Parse(repText),
				// no item rewards in the ctorArgs call
				Array.Empty<Type>()
			)
		{
		}

        // ── CTORS ─────────────────────────────────────────────────────
        [Constructable]
        public FactionDeliveryQuestScroll()
            : this(null, XmlMobFactions.GroupTypes.Player, 0, Array.Empty<Type>())
        {
        }

        [Constructable]
        public FactionDeliveryQuestScroll(string customTrait)
            : this(customTrait, XmlMobFactions.GroupTypes.Player, 0, Array.Empty<Type>())
        {
        }

        [Constructable]
        public FactionDeliveryQuestScroll(string customTrait, XmlMobFactions.GroupTypes faction, int customRep)
            : this(customTrait, faction, customRep, Array.Empty<Type>())
        {
        }



        [Constructable]
        public FactionDeliveryQuestScroll(
            string customTrait,
            XmlMobFactions.GroupTypes faction,
            int    customRep,
            params Type[] customRewards
        ) : base(0x14EF)
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

            _traitName   = pick.Name;
            _delivered   = false;
            _faction     = faction;
            _repReward   = (customRep > 0)
                           ? customRep
                           : Utility.RandomMinMax(100, 500);

            _rewardTypes = (customRewards != null && customRewards.Length > 0)
                           ? customRewards.ToList()
                           : PickRandomRewardTypes();

            Name = $"Faction Delivery Quest: {_traitName}";
        }

        // Helper to pick 1–4 random item rewards
        private static List<Type> PickRandomRewardTypes()
        {
            return DefaultRewardPool
                   .OrderBy(_ => Utility.Random(0x10000))
                   .Take(Utility.RandomMinMax(1, 4))
                   .ToList();
        }

        // ── DOUBLE-CLICK → OPEN GUMP ──────────────────────────────────
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }
            from.SendGump(new FactionDeliveryQuestGump(from, this));
        }

        // ── GUMP ──────────────────────────────────────────────────────
        private class FactionDeliveryQuestGump : Gump
        {
            private readonly FactionDeliveryQuestScroll _scroll;

            public FactionDeliveryQuestGump(Mobile from, FactionDeliveryQuestScroll scroll)
                : base(75, 50)
            {
                _scroll = scroll;
                AddPage(0);

                int height = 160 + (_scroll._rewardTypes.Count * 25);
                AddBackground(0, 0, 300, height, 9270);

                AddLabel(40, 20, 54, "Delivery Quest");
                AddLabel(40, 50, 54, $"Target Trait: {_scroll._traitName}");
                AddLabel(40, 70, 54, $"Delivered:    {_scroll._delivered}");
                AddLabel(40, 90, 54,
                    $"Faction Rep:  {_scroll._repReward} ({_scroll._faction})"
                );

                int y = 110;
                AddLabel(40, y, 54, "Rewards:"); y += 20;
                foreach (var t in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, t.Name);
                    y += 20;
                }

                int buttonId = _scroll._delivered ? 2 : 1;
                string buttonText = _scroll._delivered ? "Claim Reward" : "Deliver";
                AddButton(40, y, 4005, 4007, buttonId, GumpButtonType.Reply, 0);
                AddLabel(75, y, 54, buttonText);
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

        // ── TARGETING LOGIC ───────────────────────────────────────────
        private class DeliveryQuestTarget : Target
        {
            private readonly FactionDeliveryQuestScroll _scroll;

            public DeliveryQuestTarget(FactionDeliveryQuestScroll scroll)
                : base(12, false, TargetFlags.None)
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
                    from.SendGump(new FactionDeliveryQuestGump(from, _scroll));
                }
                else
                {
                    from.SendMessage("This is not the correct NPC.");
                }
            }
        }

        // ── CLAIM & REWARD ────────────────────────────────────────────
        private void TryClaim(Mobile from)
        {
            if (!_delivered)
            {
                from.SendMessage("You haven't delivered the quest yet.");
                return;
            }

            // Award faction reputation instead of gold
            GiveFactionRep(from, _faction, _repReward);

            // Item rewards
            foreach (var t in _rewardTypes)
                if (Activator.CreateInstance(t) is Item itm)
                    from.AddToBackpack(itm);

            from.SendMessage("Your rewards are in your backpack!");
            Delete();
        }

        // ── PERSISTENCE ───────────────────────────────────────────────
        public FactionDeliveryQuestScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);                  // version
            writer.Write(_traitName);
            writer.Write(_delivered);
            writer.Write((int)_faction);
            writer.Write(_repReward);

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
            _faction      = (XmlMobFactions.GroupTypes)reader.ReadInt();
            _repReward    = reader.ReadInt();

            int count     = reader.ReadInt();
            _rewardTypes  = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                var t = Type.GetType(reader.ReadString());
                if (t != null) _rewardTypes.Add(t);
            }
        }

        // ── HELPER to safely add faction rep ───────────────────────────
        private static void GiveFactionRep(
            Mobile player,
            XmlMobFactions.GroupTypes faction,
            int amount)
        {
            if (amount <= 0) return;

            var x = XmlAttach.FindAttachment(
                        player, typeof(XmlMobFactions), "Standard"
                    ) as XmlMobFactions;

            if (x == null)
            {
                x = new XmlMobFactions();
                XmlAttach.AttachTo(player, player, x);
            }

            int current = x.GetFactionLevel(faction);
            x.SetFactionLevel(faction, current + amount);
            player.SendMessage($"You gain {amount} reputation with {faction}!");
        }
    }
}
