using System;
using System.Collections.Generic;
using System.Linq;

using Server.ContextMenus;
using Server.Engines.PartySystem; // If you want party looting rules to apply
using Server.Gumps;             // Potentially for future interactions
using Server.Network;
using Server.Mobiles;
using Server.Items;             // For Ore types, Pickaxe etc.
// using Server.SkillHandlers;  // Not strictly needed for basic skill checks here

namespace Server.Items
{
    public class AzuriteChest : LockableContainer
    {
        #region Properties
        private int m_Level;
        private Mobile m_Owner; // Player who discovered or has rights
        private DateTime m_DeleteTime;
        private Timer m_DeleteTimer;
        private bool m_Temporary;

        private bool m_IsBeingMined;
        private Mobile m_CurrentMiner;
        private DateTime m_MiningEndTime;
        private Timer m_MiningTimer;
        private int m_RequiredMiningSkill;
        private int m_MaxGuardiansAlive; // Maximum guardians simultaneously
        private TimeSpan m_MiningDuration; // Total time required to mine

        private List<Mobile> m_Guardians;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Level { get { return m_Level; } set { m_Level = value; InvalidateProperties(); SetChestPropertiesByLevel(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Owner { get { return m_Owner; } set { m_Owner = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime DeleteTime { get { return m_DeleteTime; } private set { m_DeleteTime = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsBeingMined { get { return m_IsBeingMined; } set { m_IsBeingMined = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile CurrentMiner { get { return m_CurrentMiner; } set { m_CurrentMiner = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RequiredMiningSkill { get { return m_RequiredMiningSkill; } set { m_RequiredMiningSkill = value; } }

        public override bool IsDecoContainer { get { return false; } }
        #endregion

        #region Loot & Guardian Definitions
        // --- Define Ore Types and Guardians per Level ---
        // Example: You'll need to replace these with actual item and mobile types from your server.
        // Consider adding chances for different ore types within a level.
        public static Dictionary<int, OreDefinition[]> OreRewardsByLevel { get; } = new Dictionary<int, OreDefinition[]>
        {
            { 1, new OreDefinition[] { new OreDefinition(typeof(IronOre), 150, 250), new OreDefinition(typeof(DullCopperOre), 50, 100) } },
            { 2, new OreDefinition[] { new OreDefinition(typeof(DullCopperOre), 150, 250), new OreDefinition(typeof(ShadowIronOre), 75, 125) } },
            { 3, new OreDefinition[] { new OreDefinition(typeof(ShadowIronOre), 150, 250), new OreDefinition(typeof(CopperOre), 100, 175), new OreDefinition(typeof(BronzeOre), 25, 75) } },
            { 4, new OreDefinition[] { new OreDefinition(typeof(CopperOre), 150, 250), new OreDefinition(typeof(BronzeOre), 100, 175), new OreDefinition(typeof(GoldOre), 50, 100) } },
            { 5, new OreDefinition[] { new OreDefinition(typeof(BronzeOre), 150, 250), new OreDefinition(typeof(GoldOre), 100, 175), new OreDefinition(typeof(AgapiteOre), 75, 125) } },
            { 6, new OreDefinition[] { new OreDefinition(typeof(AgapiteOre), 150, 250), new OreDefinition(typeof(VeriteOre), 100, 175), new OreDefinition(typeof(ValoriteOre), 75, 150) } }
            // Add more levels. Consider custom "AzuriteOre" here.
        };

        public static Dictionary<int, Type[]> GuardianTypesByLevel { get; } = new Dictionary<int, Type[]>
        {
            { 1, new Type[] { typeof(EarthElemental), typeof(OreGolem) } }, // Replace OreGolem with a fitting creature
            { 2, new Type[] { typeof(EarthElemental), typeof(OreGolem), typeof(BronzeElemental) } }, // Replace with actual types
            { 3, new Type[] { typeof(EarthElemental), typeof(BronzeElemental), typeof(AgapiteElemental) } },
            { 4, new Type[] { typeof(AgapiteElemental), typeof(GoldenElemental), typeof(ShadowIronElemental) } },
            { 5, new Type[] { typeof(GoldenElemental), typeof(VeriteElemental), typeof(ValoriteElemental) } },
            { 6, new Type[] { typeof(VeriteElemental), typeof(ValoriteElemental), typeof(AncientOreGuardian) } } // Replace with a boss-like guardian
            // These are examples; use creatures available/suitable for your shard.
        };

        public struct OreDefinition
        {
            public Type OreType;
            public int MinAmount;
            public int MaxAmount;

            public OreDefinition(Type type, int min, int max)
            {
                OreType = type;
                MinAmount = min;
                MaxAmount = max;
            }
        }
        #endregion

        #region Constructor
        [Constructable]
        public AzuriteChest(int level) : this(null, level, false)
        {
        }

        public AzuriteChest(Mobile owner, int level, bool temporary) : base(0x9A8) // Example: Large Crate ItemID
        {
            m_Owner = owner;
            m_Level = Math.Max(1, Math.Min(level, OreRewardsByLevel.Count)); // Ensure level is valid
            m_Temporary = temporary;
            m_Guardians = new List<Mobile>();

            SetChestPropertiesByLevel(); // Sets name, skill req, etc.

            Movable = false;

            // Despawn timer
            m_DeleteTime = DateTime.UtcNow + TimeSpan.FromHours(2.0); // Chest lasts for 2 hours if not touched
            m_DeleteTimer = new InternalDeleteTimer(this, m_DeleteTime);
            m_DeleteTimer.Start();

            FillChestWithOres();

            // This chest is not traditionally lockpicked.
            // It's "locked" by requiring the mining process.
            Locked = true;
            LockLevel = 1000; // Arbitrarily high to prevent normal lockpicking
            MaxLockLevel = 1000;
            RequiredSkill = 0; // Lockpicking skill, not relevant here.
            TrapType = TrapType.None;
            TrapPower = 0;
            TrapLevel = 0;
        }

        private void SetChestPropertiesByLevel()
        {
            Name = String.Format("Level {0} Azurite Deposit", m_Level); // Name changes with level
            // Example: Change appearance based on level
            // ItemID = 0x9A8 + (m_Level > 3 ? 1 : 0); // e.g. different graphic for higher levels
            Hue = 1176; // An Azurite-like blue/purple hue.

            switch (m_Level)
            {
                case 1: m_RequiredMiningSkill = 30; m_MaxGuardiansAlive = 2; m_MiningDuration = TimeSpan.FromSeconds(45); break;
                case 2: m_RequiredMiningSkill = 50; m_MaxGuardiansAlive = 3; m_MiningDuration = TimeSpan.FromSeconds(60); break;
                case 3: m_RequiredMiningSkill = 70; m_MaxGuardiansAlive = 3; m_MiningDuration = TimeSpan.FromSeconds(75); break;
                case 4: m_RequiredMiningSkill = 85; m_MaxGuardiansAlive = 4; m_MiningDuration = TimeSpan.FromSeconds(90); break;
                case 5: m_RequiredMiningSkill = 95; m_MaxGuardiansAlive = 4; m_MiningDuration = TimeSpan.FromSeconds(120); break;
                case 6: m_RequiredMiningSkill = 100; m_MaxGuardiansAlive = 5; m_MiningDuration = TimeSpan.FromSeconds(150); break;
                default: m_RequiredMiningSkill = 30; m_MaxGuardiansAlive = 2; m_MiningDuration = TimeSpan.FromSeconds(45); break;
            }
            InvalidateProperties();
        }
        #endregion

        #region Loot Filling
        public void FillChestWithOres()
        {


            if (!OreRewardsByLevel.ContainsKey(m_Level))
            {
                Console.WriteLine($"AzuriteChest Error: No ore rewards defined for level {m_Level}.");
                return;
            }

            OreDefinition[] oreDefs = OreRewardsByLevel[m_Level];

            foreach (OreDefinition def in oreDefs)
            {
                try
                {
                    Item ore = Activator.CreateInstance(def.OreType) as Item;
                    if (ore != null)
                    {
                        ore.Amount = Utility.RandomMinMax(def.MinAmount, def.MaxAmount);
                        DropItem(ore);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"AzuriteChest Error: Could not create ore {def.OreType}: {e.Message}");
                }
            }

            // Chance for gems or other mining rares
            int gemCount = Utility.RandomMinMax(m_Level, m_Level * 2);
            for (int i = 0; i < gemCount; i++)
            {
                DropItem(Loot.RandomGem());
            }

            // Example: Chance for a special item like a mining power scroll or a unique gem
            if (m_Level >= 4 && Utility.RandomDouble() < (0.02 * (m_Level - 3)))
            {
                // DropItem(new SpecialMiningRelatedItem());
            }
        }
        #endregion

        #region Mining Interaction
        public override void OnDoubleClick(Mobile from)
        {
            if (Locked) // Only allow double-click interaction if it needs mining
            {
                AttemptBeginMining(from);
            }
            else // If not locked, it means it's mined and guardians are dead, so open it.
            {
                if (!CheckLoot(from, false)) return; // Check ownership/party for looting
                base.OnDoubleClick(from); // Standard open container
            }
        }

        public void AttemptBeginMining(Mobile from)
        {
            if (m_IsBeingMined)
            {
                from.SendLocalizedMessage(m_CurrentMiner == from ? 1072210 : 1072211); // "You are already mining this." or "Someone else is..."
                return;
            }

            if (!from.InRange(this.GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away.
                return;
            }

            Pickaxe pickaxe = from.FindItemOnLayer(Layer.OneHanded) as Pickaxe ?? from.FindItemOnLayer(Layer.TwoHanded) as Pickaxe;
            if (pickaxe == null)
                 pickaxe = from.Backpack?.FindItemByType<Pickaxe>(true);

            if (pickaxe == null)
            {
                from.SendMessage("You must have a pickaxe equipped or in your backpack to mine this.");
                return;
            }

            if (from.Skills[SkillName.Mining].Value < m_RequiredMiningSkill)
            {
                from.SendMessage("Your mining skill is not high enough to attempt this.");
                return;
            }
            
            if (m_Guardians.Any(g => g != null && g.Alive))
            {
                from.SendMessage("You must defeat the current guardians before attempting to mine again!");
                return;
            }

            BeginMiningProcess(from);
        }

        public void BeginMiningProcess(Mobile from)
        {
            m_IsBeingMined = true;
            m_CurrentMiner = from;

            from.SendMessage("You begin to strike the Azurite deposit...");
            from.RevealingAction();
            from.PlaySound(0x125); // Mining sound

            from.Frozen = true; // Prevent movement during the main mining phase

            m_MiningEndTime = DateTime.UtcNow + m_MiningDuration;
            if (m_MiningTimer != null) m_MiningTimer.Stop();
            m_MiningTimer = new MiningProcessTimer(this, from, m_MiningEndTime);
            m_MiningTimer.Start();

            // Initial guardian spawn
            SpawnGuardians(from, true);
        }

        private class MiningProcessTimer : Timer
        {
            private AzuriteChest m_Chest;
            private Mobile m_Miner;
            private DateTime m_ProcessEndTime;
            private int m_Ticks;
            private DateTime m_NextGuardianSpawnTime;

            public MiningProcessTimer(AzuriteChest chest, Mobile miner, DateTime endTime) : base(TimeSpan.FromSeconds(0.5), TimeSpan.FromSeconds(0.5))
            {
                m_Chest = chest;
                m_Miner = miner;
                m_ProcessEndTime = endTime;
                m_Ticks = 0;
                Priority = TimerPriority.TenMS;
                ScheduleNextGuardianSpawn();
            }

            private void ScheduleNextGuardianSpawn()
            {
                // Spawn guardians more frequently at start, less towards end, or based on waves.
                // Example: spawn every 15-25 seconds.
                m_NextGuardianSpawnTime = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(15, 25));
            }

            protected override void OnTick()
            {
                if (m_Chest == null || m_Chest.Deleted || m_Miner == null || m_Miner.Deleted || !m_Miner.Alive)
                {
                    m_Chest?.InterruptMining("The mining process was interrupted.");
                    Stop();
                    return;
                }

                if (!m_Miner.InRange(m_Chest.GetWorldLocation(), 3) || m_Miner.Map != m_Chest.Map)
                {
                    m_Chest.InterruptMining("You moved too far away from the deposit.");
                    Stop();
                    return;
                }

                Pickaxe pickaxe = m_Miner.FindItemOnLayer(Layer.OneHanded) as Pickaxe ?? m_Miner.FindItemOnLayer(Layer.TwoHanded) as Pickaxe;
                 if (pickaxe == null) pickaxe = m_Miner.Backpack?.FindItemByType<Pickaxe>(true);

                if (pickaxe == null)
                {
                    m_Chest.InterruptMining("You need a pickaxe to continue mining!");
                    Stop();
                    return;
                }

                if (DateTime.UtcNow >= m_ProcessEndTime)
                {
                    m_Chest.CompleteMiningProcess(m_Miner);
                    Stop();
                    return;
                }

                m_Ticks++;

                if (DateTime.UtcNow >= m_NextGuardianSpawnTime)
                {
                    m_Chest.SpawnGuardians(m_Miner, false);
                    ScheduleNextGuardianSpawn();
                }

                if (m_Ticks % 4 == 0) // Approx every 2 seconds
                {
                    m_Miner.PlaySound(Utility.RandomList(0x125, 0x126)); // Mining sounds
                    Effects.SendTargetEffect(m_Chest, 0x373A, 10, 16); // Visual effect on chest
                    if (m_Miner.Body.IsHuman && !m_Miner.Mounted)
                        m_Miner.Animate(Utility.RandomBool() ? 11 : 12, 5, 1, true, false, 0); // Mining animation
                    

                }
            }
        }

        public void InterruptMining(string message)
        {
            if (m_CurrentMiner != null)
            {
                m_CurrentMiner.Frozen = false;
                m_CurrentMiner.SendMessage(message);
            }

            if (m_MiningTimer != null) m_MiningTimer.Stop();
            m_MiningTimer = null;
            m_IsBeingMined = false;
            m_CurrentMiner = null;

            // Optional: despawn some/all guardians or make them passive if mining stops.
            // For now, they remain aggressive.
        }

        public void CompleteMiningProcess(Mobile from)
        {
            from.Frozen = false;
            m_IsBeingMined = false;
            // m_CurrentMiner = null; // Keep m_CurrentMiner as the one who finished for ownership checks

            from.SendMessage("You've broken through the Azurite deposit!");
            from.PlaySound(0x536); // A satisfying "thunk" or "crack"

            // Skill gain check
            from.CheckSkill(SkillName.Mining, m_RequiredMiningSkill, m_RequiredMiningSkill + 25.0);

            if (m_Guardians.Any(g => g != null && g.Alive))
            {
                from.SendMessage("Defeat the remaining guardians to access the ores!");
                // Chest remains Locked = true until guardians are cleared.
            }
            else
            {
                from.SendMessage("The deposit is clear! You can now access the ores.");
                Locked = false; // Unlock the chest
                // Send a system message or effect if desired
                Effects.PlaySound(this.Location, this.Map, 0x02F); // Unlocking sound
            }
        }
        #endregion

        #region Guardian Spawning
        public void SpawnGuardians(Mobile target, bool initialSpawn)
        {
            if (Map == null || Map == Map.Internal) return;

            int currentLiveGuardians = m_Guardians.Count(g => g != null && g.Alive);
            if (currentLiveGuardians >= m_MaxGuardiansAlive) return; // Don't exceed max

            int guardiansToAttemptSpawn = initialSpawn ? Utility.RandomMinMax(1, (m_MaxGuardiansAlive / 2) +1) : Utility.RandomMinMax(1, 2);
            int actuallySpawned = 0;

            if (!GuardianTypesByLevel.ContainsKey(m_Level))
            {
                Console.WriteLine($"AzuriteChest Error: No guardian types defined for level {m_Level}.");
                return;
            }
            Type[] possibleGuardians = GuardianTypesByLevel[m_Level];

            for (int i = 0; i < guardiansToAttemptSpawn && (currentLiveGuardians + actuallySpawned) < m_MaxGuardiansAlive; ++i)
            {
                BaseCreature guardian = null;
                try
                {
                    guardian = Activator.CreateInstance(possibleGuardians[Utility.Random(possibleGuardians.Length)]) as BaseCreature;
                }
                catch (Exception e) { Console.WriteLine($"AzuriteChest Error: Spawning guardian failed: {e.Message}"); continue; }

                if (guardian != null)
                {
                    Point3D spawnLoc = GetValidSpawnLocation(target.Location, Map, 5);
                    guardian.MoveToWorld(spawnLoc, Map);

                    guardian.FocusMob = target;
                    guardian.Combatant = target;

                    // Customize guardian appearance/name
                    guardian.Name = String.Format("{0} Guardian", GetOreTypeNameForLevel());
                    guardian.Hue = this.Hue; // Match chest hue, or specific guardian hue
                    guardian.NoKillAwards = true; // They don't give fame/karma/loot directly from kill

                    m_Guardians.Add(guardian);
                    actuallySpawned++;
                }
            }

            if (target != null && actuallySpawned > 0)
            {
                target.SendMessage("Guardians emerge from the stone to defend the deposit!");
                Effects.PlaySound(this.Location, this.Map, 0x1FB); // Earthy rumble sound
            }
        }
        
        private string GetOreTypeNameForLevel() // For guardian naming
        {
            switch(m_Level)
            {
                case 1: return "Iron";
                case 2: return "Shadow";
                case 3: return "Copper";
                case 4: return "Bronze";
                case 5: return "Agapite";
                case 6: return "Valorite";
                default: return "Stone";
            }
        }

        private Point3D GetValidSpawnLocation(Point3D center, Map map, int range)
        {
            for (int i = 0; i < 20; i++) // Try up to 20 times
            {
                int x = center.X + Utility.RandomMinMax(-range, range);
                int y = center.Y + Utility.RandomMinMax(-range, range);
                int z = map.GetAverageZ(x, y);

                if (map.CanSpawnMobile(x, y, z))
                    return new Point3D(x, y, z);
            }
            return center; // Fallback if no suitable spot is found quickly
        }

        // Call this when a guardian is killed or despawns
        public void OnGuardianDeath(Mobile guardian)
        {
            m_Guardians.Remove(guardian);

            // If mining was completed and this was the last guardian
            if (!Locked && !m_IsBeingMined && m_CurrentMiner != null && m_CurrentMiner.Alive)
            {
                if (!m_Guardians.Any(g => g != null && g.Alive))
                {
                    m_CurrentMiner.SendMessage("The last guardian has fallen! The ores are yours.");
                    Locked = false; // Re-ensure it's unlocked.
                    Effects.PlaySound(this.Location, this.Map, 0x02F);
                }
            }
        }
        #endregion

        #region Overrides & Context Menu
        public override bool CheckLocked(Mobile from)
        {
            if (!Locked) // If it's already unlocked, allow access (subject to CheckLoot)
                return false;

            // If locked, it means mining isn't complete OR guardians are still up
            if (m_IsBeingMined && from == m_CurrentMiner)
                from.SendMessage("You are still mining the deposit.");
            else if (m_IsBeingMined)
                from.SendMessage("Someone is currently mining this deposit.");
            else if (m_Guardians.Any(g => g != null && g.Alive))
                from.SendMessage("The deposit is protected by guardians!");
            else
                from.SendMessage("This Azurite deposit must be carefully mined open.");

            return true; // It is "locked" in the sense that it can't be opened directly yet.
        }

        public override void LockPick(Mobile from)
        {
            from.SendLocalizedMessage(501695); // This lock cannot be picked.
        }

        // Prevent normal trapping/detrapping

        public override bool ExecuteTrap(Mobile from) { return false; } // No trap to execute

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            // Remove default "Pick Lock" if it exists for LockableContainers
            for (int i = list.Count - 1; i >= 0; i--)
            {
                // Type check might be needed if LockpickEntry class is known
                // For now, checking by number (often 6126 for Pick Lock)
                if (list[i].Number == 6126)
                    list.RemoveAt(i);
            }

            if (from.Alive && Locked && !m_IsBeingMined && from.InRange(this.GetWorldLocation(), 2))
            {
                list.Add(new BeginMiningEntry(from, this));
            }
        }

        private class BeginMiningEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private AzuriteChest m_Chest;

            public BeginMiningEntry(Mobile from, AzuriteChest chest) : base(6200, 2) // 6200 = "Mine" or custom cliloc
            {
                m_From = from;
                m_Chest = chest;

                if (m_Chest.IsBeingMined || m_From.Skills[SkillName.Mining].Value < m_Chest.RequiredMiningSkill || m_Chest.m_Guardians.Any(g => g != null && g.Alive))
                    Flags |= CMEFlags.Disabled;
            }

            public override void OnClick()
            {
                if (m_Chest.IsBeingMined || m_From.Skills[SkillName.Mining].Value < m_Chest.RequiredMiningSkill || m_Chest.m_Guardians.Any(g => g != null && g.Alive))
                {
                     m_From.SendMessage("You cannot mine this right now."); // More specific messages handled by AttemptBeginMining
                     return;
                }
                m_Chest.AttemptBeginMining(m_From);
            }
        }
        
        // Looting permissions (similar to TreasureMapChest)
        private bool CheckLoot(Mobile m, bool criminalAction)
        {
            if (m_Temporary || m.AccessLevel >= AccessLevel.GameMaster) return true;
            if (m_Owner == null || m == m_Owner || m == m_CurrentMiner) return true; // CurrentMiner who completed it also has rights

            Party p = Party.Get(m_Owner ?? m_CurrentMiner); // Check party of original owner or successful miner
            if (p != null && p.Contains(m)) return true;

            Map map = this.Map;
            if (map != null && (map.Rules & MapRules.HarmfulRestrictions) == 0) // Fel rules
            {
                if (criminalAction) m.CriminalAction(true);
                else m.SendLocalizedMessage(1010630); // Taking someone else's treasure is a criminal offense!
                return true;
            }

            m.SendLocalizedMessage(1010631); // You did not discover this!
            return false;
        }
        public override bool CheckItemUse(Mobile from, Item item) { return CheckLoot(from, item != this) && base.CheckItemUse(from, item); }
        public override bool CheckLift(Mobile from, Item item, ref LRReason reject) { return CheckLoot(from, true) && base.CheckLift(from, item, ref reject); }

        #endregion

        #region Serialization
        public AzuriteChest(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)2); // Version

            // Version 2
            writer.Write(m_MaxGuardiansAlive);
            // No more fields for V2, but good practice to increment if structure changes

            // Version 1
            writer.Write(m_IsBeingMined);
            writer.Write(m_CurrentMiner);
            writer.WriteDeltaTime(m_MiningEndTime); // Store end time to resume timer
            writer.Write(m_RequiredMiningSkill);
            // m_MaxGuardians was removed, use m_MaxGuardiansAlive (V2)
            writer.Write(m_MiningDuration);

            // Version 0
            writer.Write(m_Level);
            writer.Write(m_Owner);
            writer.WriteDeltaTime(m_DeleteTime);
            writer.Write(m_Temporary);

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 2:
                {
                    m_MaxGuardiansAlive = reader.ReadInt();
                    goto case 1;
                }
                case 1:
                {
                    m_IsBeingMined = reader.ReadBool();
                    m_CurrentMiner = reader.ReadMobile();
                    m_MiningEndTime = reader.ReadDeltaTime();
                    m_RequiredMiningSkill = reader.ReadInt();
                    m_MiningDuration = reader.ReadTimeSpan();
                    // m_MaxGuardians was implicitly handled by falling through from V0, if it existed there.
                    // If loading an old V0 chest, m_MaxGuardiansAlive would need a default if not set by V2.
                    if (version < 2 && m_MaxGuardiansAlive == 0) // If loaded from V0 or V1 without V2 part
                    {
                         SetChestPropertiesByLevel(); // This will set m_MaxGuardiansAlive
                    }
                    goto case 0;
                }
                case 0:
                {
                    m_Level = reader.ReadInt();
                    m_Owner = reader.ReadMobile();
                    m_DeleteTime = reader.ReadDeltaTime();
                    m_Temporary = reader.ReadBool();
                    m_Guardians = reader.ReadStrongMobileList();
                    break;
                }
            }

            // Post-deserialization timer restarts
            if (!m_Temporary && m_DeleteTime > DateTime.UtcNow)
            {
                m_DeleteTimer = new InternalDeleteTimer(this, m_DeleteTime);
                m_DeleteTimer.Start();
            }
            else if (!m_Temporary && m_DeleteTime <= DateTime.UtcNow) { Timer.DelayCall(TimeSpan.Zero, Delete); }


            if (m_IsBeingMined && m_CurrentMiner != null)
            {
                if (DateTime.UtcNow < m_MiningEndTime)
                {
                    m_MiningTimer = new MiningProcessTimer(this, m_CurrentMiner, m_MiningEndTime);
                    m_MiningTimer.Start();
                    if (m_CurrentMiner.IsOnline()) m_CurrentMiner.Frozen = true;
                }
                else // Mining time would have elapsed
                {
                    CompleteMiningProcess(m_CurrentMiner); // Or InterruptMining if that's more appropriate
                }
            }
            m_Guardians.RemoveAll(g => g == null || g.Deleted);
             if (version < 2 && m_MaxGuardiansAlive == 0) SetChestPropertiesByLevel(); // One last check for older versions
        }
        #endregion

        #region Delete Timer & Cleanup
        private class InternalDeleteTimer : Timer
        {
            private AzuriteChest m_Chest;
            public InternalDeleteTimer(AzuriteChest chest, DateTime deleteTime) : base(deleteTime - DateTime.UtcNow)
            {
                m_Chest = chest;
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                if (m_Chest != null && !m_Chest.Deleted)
                {
                    if (m_Chest.IsBeingMined) // Extend life if actively being mined
                    {
                        m_Chest.DeleteTime = DateTime.UtcNow + TimeSpan.FromMinutes(15);
                        Stop(); // Stop this instance
                        m_Chest.m_DeleteTimer = new InternalDeleteTimer(m_Chest, m_Chest.DeleteTime); // Create new one
                        m_Chest.m_DeleteTimer.Start();
                        return;
                    }
                    m_Chest.Delete();
                }
            }
        }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();
            if (m_DeleteTimer != null) m_DeleteTimer.Stop();
            if (m_MiningTimer != null) m_MiningTimer.Stop();

            if (m_Guardians != null)
            {
                // Create a copy for safe iteration while deleting
                List<Mobile> toDelete = new List<Mobile>(m_Guardians.Where(g => g != null && !g.Deleted));
                foreach (Mobile m in toDelete) { m.Delete(); }
                m_Guardians.Clear();
            }
        }
        #endregion
    }

    // Example Guardian (you would have these defined elsewhere or use existing mobiles)
    public class OreGolem : BaseCreature { [Constructable] public OreGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4) { Name = "Ore Golem"; Body = 752; BaseSoundID = 268; /* TODO: Stats */ } public OreGolem(Serial serial) : base(serial) { } public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); } public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); } }
    public class AncientOreGuardian : BaseCreature { [Constructable] public AncientOreGuardian() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.1, 0.2) { Name = "Ancient Ore Guardian"; Body = 752; Hue = 1176; BaseSoundID = 268; /* TODO: Boss Stats & Skills */ } public AncientOreGuardian(Serial serial) : base(serial) { } public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); } public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); } }

}