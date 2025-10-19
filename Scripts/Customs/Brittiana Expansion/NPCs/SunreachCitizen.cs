using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;
using Server.Engines.XmlSpawner2;
using Server.Custom;

namespace Server.Mobiles
{
    [CorpseName("the remains of a Sunreach citizen")]
    public class SunreachCitizen : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------ SUNREACH CITIZEN EQUIPMENT ---------------
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;

            public SlotDef(double chance, params Func<Item>[] pool)
            {
                Chance = chance;
                Pool = pool;
            }
        }

        // Limit clothing to what fits a Sunreach civilian/merchant/sailor:
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>( StringComparer.OrdinalIgnoreCase )
        {
            // Shoes/sandals/soft boots
            { "Footwear", new SlotDef(0.98,
                () => new Sandals(),
                () => new Shoes(),
                () => new Boots(),
                () => new ThighBoots()
            )},

            // Loose shirts, vests, sashes
            { "Shirt", new SlotDef(0.90,
                () => new Shirt(),
                () => new FancyShirt(),
                () => new BodySash(),
                () => new Doublet(),
                () => new Surcoat()
            )},

            // Vests and robes (for merchants)
            { "Vest", new SlotDef(0.55,
                () => new FancyDress(),
                () => new GildedDress(),
                () => new Robe(),
                () => new Tunic()
            )},

            // Sash/belt
            { "Belt", new SlotDef(0.80,
                () => new BodySash(),
                () => new HalfApron(),
                () => new FullApron()
            )},

            // Skirts or short pants
            { "Lower", new SlotDef(0.75,
                () => new Skirt(),
                () => new Kilt(),
                () => new ShortPants(),
                () => new LongPants()
            )},

            // Light hats, turbans, veils
            { "Head", new SlotDef(0.40,
                () => new Cap(),
                () => new Bandana(),
                () => new FloppyHat(),
                () => new WideBrimHat()
            )},

            // Jewelry
            { "Jewelry", new SlotDef(0.30,
                () => new GoldEarrings(),
                () => new GoldRing(),
                () => new GoldBracelet(),
                () => new Necklace()
            )},

            // Carryable city trinkets/tools (sometimes)
            { "Trinket", new SlotDef(0.15,
                () => new SmithHammer(),
                () => new Spellbook(),
                () => new Spyglass(),
                () => new Lantern()
            )}
        };

        // ----------- QUESTS: Only Sunreach Faction --------------
        // If you want ONLY Sunreach Faction quests, prune the _questFactories:
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Only Sunreach faction quest scrolls!
            () => new FactionCollectionQuestScroll("Silk", 10, "Sunreach", 1200),
            () => new FactionDeliveryQuestScroll("Smuggled Spices", "Sunreach", 500),
            () => new FactionKillQuestScroll("Buccaneer", 4, "Sunreach", 1500),
			
            () => new FactionCollectionQuestScroll("LeatherGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("PlateGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("StuddedGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("BoneGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WoodlandGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("DragonGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("RingmailGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("HideGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("LeafGloves", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("LeatherNinjaMitts", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("FullApron", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Obi", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WoodlandBelt", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("HalfApron", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("LeatherGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("PlateGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("StuddedGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("ElegantCollar", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("HideGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("TigerPeltCollar", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WoodlandGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("LeafGorget", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("RandomTalisman", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Longsword", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Broadsword", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Cutlass", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Katana", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Scimitar", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("VikingSword", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Axe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("BattleAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("DoubleAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("ExecutionersAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("LargeBattleAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("TwoHandedAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WarAxe", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Club", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("HammerPick", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Mace", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Maul", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WarHammer", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WarMace", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Bardiche", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Halberd", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Lance", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Pike", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("ShortSpear", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("Spear", 25, "Sunreach", 750),
            () => new FactionCollectionQuestScroll("WarFork", 25, "Sunreach", 750),

            () => new FactionKillQuestScroll("PitFiend", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Pixie", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PlagueBeast", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PlagueBeastLord", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PlagueRat", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PlagueSpawn", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PlatinumDrake", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PoisonElemental", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PolarBear", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PredatorHellCat", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Protector", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PutridUndeadGargoyle", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PutridUndeadGuardian", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Quagmire", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Rabbit", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("RagingGrizzlyBear", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("RaiJu", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Raptor", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Rat", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Ratman", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("RatmanArcher", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("RatmanMage", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Ravager", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Reaper", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("HerefordWarlock ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("HighlandBull ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("JerseyEnchantress ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("MilkingDemon ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("SahiwalShaman ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("ZebuZealot ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("AbyssinianTracker ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("BengalStorm ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("MaineCoonTitan ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PersianShade ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("RagdollGuardian ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("ScottishFoldSentinel ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("SiameseIllusionist ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("SiberianFrostclaw ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("SphinxCat ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("TurkishAngoraEnchanter ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("FireRooster ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("FrostHen ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("IllusionHen ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("MysticFowl ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("NecroRooster ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PoisonPullet ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("ShadowChick ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("StoneRooster ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("Thunderbird ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("WindChicken ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("BloodthirstyVines ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("CorruptingCreeper ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("DreadedCreeper ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("ElderTendril ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("NightshadeBramble ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PhantomVines ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("SinisterRoot ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("ThornedHorror ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("VenomousIvy ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("VileBlossom ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("BansheeCrab ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("EtherealCrab ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("IceCrab ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("LavaCrab ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("MagneticCrab ", "5", "Sunreach", "500"),
            () => new FactionKillQuestScroll("PoisonousCrab ", "5", "Sunreach", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Sunreach, 350),				
			
            // Add more Sunreach-appropriate quests as needed
        };

        [Constructable]
        public SunreachCitizen()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            InitBody();
            InitOutfit();
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);			
        }

        private void InitBody()
        {
            Female = Utility.RandomBool();
            Body = Female ? 0x191 : 0x190;
            Hue = Utility.RandomSkinHue();

            string fullName = GenerateRandomName();
            string[] parts = fullName.Split(new[] { ' ' }, 3);

            if (parts.Length >= 2)
            {
                Name  = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(40, 80));
            SetDex(Utility.RandomMinMax(45, 95));
            SetInt(Utility.RandomMinMax(45, 90));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private static string GenerateRandomName()
        {
            // First names, last names, and titles with a Sunreach/Arabian/port-city vibe
            string[] firstNames = new[] {
                "Jamal","Selene","Rashid","Layla","Samir","Farah","Tarek","Amira","Malik","Yasmin",
                "Khalil","Safiya","Zayd","Nadira","Bashir","Iman","Hakeem","Ranya","Nasir","Soraya",
                "Darius","Sabir","Tariq","Amina","Razi","Karim","Dina","Azhar","Salim","Lina",
                "Fadil","Samira","Bahram","Zara","Nabil","Rima","Idris","Salma","Hassan","Leila",
                // Add a few “Britannian port” types for cosmopolitan feel
                "Morgan","Selwyn","Adira","Rufio","Marina","Cyrus","Lucan","Isolde","Bastian","Nessa"
            };
            string[] lastNames = new[] {
                "al-Sunreach","of the Docks","of Qasaria","the Trader","the Spicer","the Lanternbearer",
                "of the Bazaars","the Smuggler","of the Market","the Mariner","the Jewelbroker",
                "the Sailmaker","the Saltborn","of the Shimmering Sands","the Coinkeeper","the Mapmaker",
                "Sandwalker","Sunseeker","Windcaller","Saltbreeze","Duneborn","Seabright","Wavecutter",
                "Goldentide","Nightbreeze","Caravansar","Stormhand","Stonepier","of the Wharf","Dockside",
                "al-Ahmar","al-Khattab","bin Idris","bint Yasmin","ibn Rashid","of the Gates","of the Spice Road"
            };
            string[] titles = new[] {
                "the Merchant","the Sailor","the Dockworker","the Spicemonger","the Smuggler","the Navigator",
                "the Scribe","the Fisherman","the Shipwright","the Cartographer","the Glassblower",
                "the Camelherd","the Artisan","the Nightwatch","the Bargemaster","the Perfumer",
                "the Appraiser","the Coinmaster","the Pearl Diver","the Salt Steward","the Streetwise",
                "the Silkmonger","the Candle-Maker","the Glassmaker","the Interpreter","the River Pilot",
                "the Haggler","the Street Vendor","the Lamp-Lighter","the Storyteller","the Nomad",
                "the Dockside Gossip","the Intriguer","the Informant","the Bazaar Guard","the Slaver",
                "the Pickpocket","the Beggar","the Sandwalker","the Caravan Scout","the Peddler",
                "the Spice Runner","the Swindler","the Bookkeeper","the Auctioneer"
            };
            string first  = firstNames[Utility.Random(firstNames.Length)];
            string last   = lastNames[Utility.Random(lastNames.Length)];
            string title  = titles[Utility.Random(titles.Length)];
            return $"{first} {last} {title}";
        }

        private void InitOutfit()
        {
            foreach (var kv in _slotDefs)
            {
                if (Utility.RandomDouble() <= kv.Value.Chance)
                {
                    var factories = kv.Value.Pool;
                    var item = factories[Utility.Random(factories.Length)]();
                    // Sunreach palette: warm/gold/earthy/desert colors (sample palette, adjust for your world)
                    item.Hue = Utility.RandomList(2401, 2425, 2413, 1109, 2125, 2402, 2406, 2213, 2101, 2309, 2112, 2051);
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomList(1109, 1110, 1102, 2403, 2425, 2413, 2101, 2213, 2402, 2309, 2406, 2109, 2051);
            if (!Female && Utility.RandomBool())
                FacialHairItemID = Utility.RandomList(0x204B, 0x204C, 0x204D, 0x204E);
            FacialHairHue = HairHue;
        }

        // Everything else (context menu, quest handout, serialization) can remain as in your original RandomQuestGiver.
        // Replace all "RandomQuestGiver" with "SunreachCitizen" for class/constructor.

        // ... Rest of your code ...
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new QuestEntry(from, this));
        }

        private void TryGiveQuest(Mobile player)
        {
            if (DateTime.UtcNow < _nextQuestUtc)
            {
                TimeSpan wait = _nextQuestUtc - DateTime.UtcNow;
                player.SendMessage($"I must prepare more scrolls. Please return in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Apologies, my scrolls are missing. Please try again soon.");
                return;
            }
            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("A quest for Sunreach awaits you—read this scroll.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly SunreachCitizen _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, SunreachCitizen npc)
                : base(6156)
            {
                _npc = npc;
                _from = from;
                Enabled = true;
            }

            public override void OnClick()
            {
                if (_from == null || _npc == null) return;
                _npc.TryGiveQuest(_from);
            }
        }

        public SunreachCitizen(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
            writer.Write(_nextQuestUtc);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            _nextQuestUtc = reader.ReadDateTime();
        }		
    }
}
