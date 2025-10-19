/*
 * FactionTamingQuestScroll.cs
 *
 * A faction-based taming quest scroll.
 * Rewards reputation with a chosen XmlMobFactions faction instead of gold.
 * © 2025 – free to use / modify.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;
using Server.Engines.XmlSpawner2;      // for XmlMobFactions attachment

namespace Server.Items
{
    public class FactionTamingQuestScroll : Item
    {
        // --- ❶ default pools ---------------------------------------------
        private static readonly AnimalLoreContractType[] DefaultCreaturePool =
            AnimalLoreContractType.Get;

        private static readonly Type[] DefaultRewardPool =
            QuestScrollRewards.m_Rewards;

        // --- ❷ state -----------------------------------------------------
        private Type                           _creatureType;
        private string                         _creatureName;
        private int                            _amountToTame;
        private int                            _amountTamed;
        private XmlMobFactions.GroupTypes      _faction;
        private int                            _repReward;
        private List<Type>                     _rewardTypes;

        // --- ❸ GM-tweakable props ----------------------------------------
        [CommandProperty(AccessLevel.GameMaster)]
        public string CreatureName    => _creatureName;

        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountToTame       { get => _amountToTame;   set => _amountToTame   = Math.Max(1, value); }
        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountTamed        { get => _amountTamed;    set => _amountTamed    = Math.Max(0, value); }

        [CommandProperty(AccessLevel.GameMaster)]
        public XmlMobFactions.GroupTypes Faction
            { get => _faction;        set => _faction        = value; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RepReward          { get => _repReward;     set => _repReward     = Math.Max(0, value); }

        // --- ❹ constructors -----------------------------------------------
        // 1) Default for [add FactionTamingQuestScroll]
        [Constructable]
        public FactionTamingQuestScroll()
            : this(null, 0, XmlMobFactions.GroupTypes.Player, 0, new Type[0])
        {
        }

        // 2) Convenience for staff: [add FactionTamingQuestScroll <faction> <rep>]
        [Constructable]
        public FactionTamingQuestScroll(
            XmlMobFactions.GroupTypes faction,
            int repAmount
        ) : this(null, 0, faction, repAmount, new Type[0])
        {
        }

        // 3) Full-param ctor
        [Constructable]
        public FactionTamingQuestScroll(
            Type                          customCreature,
            int                           customAmount,
            XmlMobFactions.GroupTypes     faction,
            int                           customRep,
            params Type[]                 customRewards
        ) : base(0x14EF) // parchment graphic
        {
            Weight   = 1.0;
            LootType = LootType.Blessed;
            Hue      = 0x4B5;

            // pick creature
            var pick = (customCreature != null
                        ? DefaultCreaturePool.FirstOrDefault(ct => ct.Type == customCreature)
                        : DefaultCreaturePool[Utility.Random(DefaultCreaturePool.Length)])
                       ?? DefaultCreaturePool[0];

            _creatureType  = pick.Type;
            _creatureName  = pick.Name;
            _amountToTame  = (customAmount > 0) ? customAmount : Utility.RandomMinMax(5, 10);

            // faction & rep
            _faction       = faction;
            _repReward     = (customRep > 0) ? customRep : _amountToTame * 50;

            // pick rewards
            _rewardTypes   = (customRewards != null && customRewards.Length > 0)
                             ? customRewards.ToList()
                             : PickRandomRewardTypes();

            Name = $"Taming Quest: tame {_amountToTame} {_creatureName}";
        }

        // --- helper: pick 1–4 random rewards ------------------------------
        private static List<Type> PickRandomRewardTypes()
        {
            int count = Utility.RandomMinMax(1, 4);
            return DefaultRewardPool
                   .OrderBy(_ => Utility.Random(0x10000))
                   .Take(count)
                   .ToList();
        }

        // --- ❺ double-click → show gump -----------------------------------
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }

            from.SendGump(new FactionTamingQuestGump(from, this));
        }

        // --- ❻ gump --------------------------------------------------------
        private class FactionTamingQuestGump : Gump
        {
            private readonly FactionTamingQuestScroll _scroll;

            public FactionTamingQuestGump(Mobile from, FactionTamingQuestScroll scroll)
                : base(75, 50)
            {
                _scroll = scroll;

                int lines  = _scroll._rewardTypes.Count;
                int height = 160 + (lines * 25);

                AddPage(0);
                AddBackground(0, 0, 300, height, 9270);

                AddLabel(40, 20, 54, "Taming Quest");

                int y = 50;
                AddLabel(40, y, 54, $"To Tame:    {_scroll._amountToTame} {_scroll._creatureName}"); y += 20;
                AddLabel(40, y, 54, $"Tamed:      {_scroll._amountTamed}");                   y += 20;
                AddLabel(40, y, 54, $"Faction Rep: {_scroll._repReward} ({_scroll._faction})"); y += 20;

                AddLabel(40, y, 54, "Rewards:"); y += 20;
                foreach (var rt in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, rt.Name);
                    y += 20;
                }

                if (_scroll._amountTamed < _scroll._amountToTame)
                {
                    AddButton(40, y, 4005, 4007, 1, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 54, "Turn In Creature");
                }
                else
                {
                    AddButton(40, y, 4005, 4007, 2, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 54, "Claim Reward");
                }
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                var from = state.Mobile;
                if (info.ButtonID == 1)
                {
                    from.SendMessage("Select the tamed creature to turn in.");
                    from.Target = new TamingQuestTarget(_scroll);
                }
                else if (info.ButtonID == 2)
                {
                    _scroll.TryClaim(from);
                }
            }
        }

        // --- ❼ targeting logic ---------------------------------------------
        private class TamingQuestTarget : Target
        {
            private readonly FactionTamingQuestScroll _scroll;

            public TamingQuestTarget(FactionTamingQuestScroll scroll)
                : base(10, false, TargetFlags.None)
            {
                _scroll = scroll;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BaseCreature c &&
                    c.Controlled && c.ControlMaster == from &&
                    c.GetType() == _scroll._creatureType)
                {
                    from.SendMessage("You have turned in the creature.");
                    _scroll._amountTamed++;
                    c.Delete();

                    if (_scroll._amountTamed < _scroll._amountToTame)
                        from.Target = new TamingQuestTarget(_scroll);
                    else
                        from.SendGump(new FactionTamingQuestGump(from, _scroll));
                }
                else
                {
                    from.SendMessage("That creature does not meet the quest requirements.");
                }
            }
        }

        // --- ❽ claim & reward ----------------------------------------------
        private void TryClaim(Mobile from)
        {
            if (_amountTamed < _amountToTame)
            {
                from.SendMessage("You haven't tamed enough creatures yet.");
                return;
            }

            // award faction reputation
            GiveFactionRep(from, _faction, _repReward);

            // give item rewards
            foreach (var t in _rewardTypes)
            {
                if (Activator.CreateInstance(t) is Item itm)
                    from.AddToBackpack(itm);
            }

            from.SendMessage("Your rewards have been placed in your backpack!");
            Delete();
        }

        // --- ❾ persistence -----------------------------------------------
        public FactionTamingQuestScroll(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(_creatureType?.AssemblyQualifiedName ?? "");
            writer.Write(_creatureName);
            writer.Write(_amountToTame);
            writer.Write(_amountTamed);

            writer.Write((int)_faction);
            writer.Write(_repReward);

            writer.Write(_rewardTypes.Count);
            foreach (var t in _rewardTypes)
                writer.Write(t.AssemblyQualifiedName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            _creatureType = Type.GetType(reader.ReadString());
            _creatureName = reader.ReadString();
            _amountToTame = reader.ReadInt();
            _amountTamed  = reader.ReadInt();

            _faction      = (XmlMobFactions.GroupTypes)reader.ReadInt();
            _repReward    = reader.ReadInt();

            int count = reader.ReadInt();
            _rewardTypes = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                var t = Type.GetType(reader.ReadString());
                if (t != null) _rewardTypes.Add(t);
            }
        }

        // --- helper to safely award faction rep ---------------------------
        private static void GiveFactionRep(Mobile player, XmlMobFactions.GroupTypes faction, int amount)
        {
            if (amount <= 0) return;

            var x = XmlAttach.FindAttachment(player, typeof(XmlMobFactions), "Standard") as XmlMobFactions;
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
