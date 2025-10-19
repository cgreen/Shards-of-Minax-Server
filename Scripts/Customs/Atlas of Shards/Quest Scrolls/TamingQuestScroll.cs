/*
 * TamingQuestScroll.cs
 *
 * A self-contained, parameter-friendly taming quest scroll
 * that rewards 1–4 random items from QuestScrollRewards.
 * © 2025 – free to use / modify.
 */

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
    public class TamingQuestScroll : Item
    {
        // --- ❶ default pools ---------------------------------------------
        // Use your full AnimalLore creature list:
        private static readonly AnimalLoreContractType[] DefaultCreaturePool =
            AnimalLoreContractType.Get;

        // Now point at the generic reward list:
        private static readonly Type[] DefaultRewardPool =
            QuestScrollRewards.m_Rewards; 

        // --- ❷ state -----------------------------------------------------
        private Type       _creatureType;
        private string     _creatureName;
        private int        _amountToTame;
        private int        _amountTamed;
        private int        _goldReward;
        private List<Type> _rewardTypes;

        // Skill-scroll / Maxxia logic omitted in favor of generic rewards

        // --- ❸ GM-tweakable props ----------------------------------------
        [CommandProperty(AccessLevel.GameMaster)]
        public string CreatureName   => _creatureName;
        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountToTame      { get => _amountToTame;  set => _amountToTame  = Math.Max(1, value); }
        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountTamed       { get => _amountTamed;   set => _amountTamed   = Math.Max(0, value); }
        [CommandProperty(AccessLevel.GameMaster)]
        public int GoldReward        { get => _goldReward;    set => _goldReward    = Math.Max(0, value); }

        // --- ❹ constructors -----------------------------------------------
        // Parameterless for [add TamingQuestScroll]
        [Constructable]
        public TamingQuestScroll()
            : this(null, 0, 0, new Type[0])
        {
        }

        // --- ❹a 3-parameter convenience ctor ------------------------------

        [Constructable]
        public TamingQuestScroll(string creatureName, int amountToTame, int goldReward)
            : this(
                LookupCreatureType(creatureName),  // resolve any tamed creature type
                amountToTame,
                goldReward,
                new Type[0]                       // no explicit rewards → random
              )
        {
            // Override the display name so it shows exactly what was passed in:
            _creatureName = creatureName ?? _creatureType?.Name ?? "unknown";
            Name          = $"Taming Quest: tame {_amountToTame} {_creatureName}";
        }

        // --- helper to resolve any BaseCreature by simple name -------------
        private static Type LookupCreatureType(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                // 1) try fully-qualified (e.g. Server.Mobiles.Kirin)
                var t = Type.GetType($"Server.Mobiles.{name}", false, true);

                // 2) if that fails, scan all loaded assemblies for a matching simple name
                if (t == null)
                {
                    t = AppDomain.CurrentDomain
                                 .GetAssemblies()
                                 .SelectMany(a => a.GetTypesSafe())
                                 .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }

                // 3) ensure it’s a tamed creature
                if (t != null && typeof(BaseCreature).IsAssignableFrom(t))
                    return t;
            }

            // 4) fallback to the default pool
            var pick = DefaultCreaturePool[Utility.Random(DefaultCreaturePool.Length)];
            return pick.Type;
        }


        // Full-param ctor for GMs
        [Constructable]
        public TamingQuestScroll(
            Type   customCreature,
            int    customAmount,
            int    customGold,
            params Type[] customRewards
        ) : base(0x14EF) // parchment scroll graphic
        {
            Weight   = 1.0;
            LootType = LootType.Blessed;
            Hue      = 0x4B5;

            // ❶ pick creature
            var pick = (customCreature != null
                        ? DefaultCreaturePool.FirstOrDefault(ct => ct.Type == customCreature)
                        : DefaultCreaturePool[Utility.Random(DefaultCreaturePool.Length)])
                       ?? DefaultCreaturePool[0];

            _creatureType  = pick.Type;
            _creatureName  = pick.Name;
            _amountToTame  = (customAmount > 0) ? customAmount : Utility.RandomMinMax(5, 10);
            _goldReward    = (customGold   > 0) ? customGold   : _amountToTame * 500;

            // ❷ pick rewards: either custom or 1–4 random
            _rewardTypes = (customRewards != null && customRewards.Length > 0)
                           ? customRewards.ToList()
                           : PickRandomRewardTypes();

            Name = $"Taming Quest: tame {_amountToTame} {_creatureName}";
        }

        // Helper to grab N random distinct rewards
        private static List<Type> PickRandomRewardTypes()
        {
            int count = Utility.RandomMinMax(1, 4);
            return DefaultRewardPool
                   .OrderBy(t => Utility.Random(0x10000))
                   .Take(count)
                   .ToList();
        }

        // --- ❺ double-click → recalc & show gump -------------------------
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }

            from.SendGump(new TamingQuestGump(from, this));
        }

        // --- ❻ gump --------------------------------------------------------
        private class TamingQuestGump : Gump
        {
            private readonly TamingQuestScroll _scroll;

            public TamingQuestGump(Mobile from, TamingQuestScroll scroll)
                : base(75, 50)
            {
                _scroll = scroll;

                // dynamic sizing: base 160px + 20px per reward line
                int rewardLines = _scroll._rewardTypes.Count;
                int height      = 160 + (rewardLines * 25);

                AddPage(0);
                AddBackground(0, 0, 300, height, 9270);

                // header
                AddLabel(40, 20, 54, "Taming Quest");

                // quest details
                int y = 50;
                AddLabel(40, y, 54, $"To Tame:    {_scroll._amountToTame} {_scroll._creatureName}"); y += 20;
                AddLabel(40, y, 54, $"Tamed:      {_scroll._amountTamed}");                   y += 20;
                AddLabel(40, y, 54, $"Gold Reward: {_scroll._goldReward}");                   y += 20;

                // list each reward on its own line
                AddLabel(40, y, 54, "Rewards:"); y += 20;
                foreach (var rt in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, rt.Name);
                    y += 20;
                }

                // button
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
            private readonly TamingQuestScroll _scroll;

            public TamingQuestTarget(TamingQuestScroll scroll)
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
                        from.SendGump(new TamingQuestGump(from, _scroll));
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

            // give gold
            from.AddToBackpack(new Gold(_goldReward));

            // give each reward
            foreach (var t in _rewardTypes)
            {
                if (Activator.CreateInstance(t) is Item itm)
                    from.AddToBackpack(itm);
            }

            from.SendMessage("Your rewards have been placed in your backpack!");
            Delete();
        }

        // --- ❾ persistence -----------------------------------------------
        public TamingQuestScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(_creatureType?.AssemblyQualifiedName ?? "");
            writer.Write(_creatureName);
            writer.Write(_amountToTame);
            writer.Write(_amountTamed);
            writer.Write(_goldReward);

            // serialize reward list
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
            _goldReward   = reader.ReadInt();

            int count = reader.ReadInt();
            _rewardTypes = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                var t = Type.GetType(reader.ReadString());
                if (t != null) _rewardTypes.Add(t);
            }
        }
    }
}
