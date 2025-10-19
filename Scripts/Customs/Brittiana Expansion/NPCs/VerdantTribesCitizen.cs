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
    [CorpseName("the remains of a Verdant Tribesfolk")]
    public class VerdantTribesCitizen : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ====== VERDANT TRIBES EQUIPMENT POOL ===========
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

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.7, () => new Sandals(), () => new FurBoots(), () => new NinjaTabi()) },

            { "Robe", new SlotDef(0.0) }, // No robes

            { "Back", new SlotDef(0.15, () => new Cloak(), () => new FurCape()) },

            { "Head", new SlotDef(0.3,
                () => new TribalMask(),
                () => new BearMask(),
                () => new BoneHelm(),
                () => new FlowerGarland()
            )},

            { "Shirt", new SlotDef(0.9,
                () => new FurSarong(),
                () => new BodySash(), // Custom item? If not, comment/remove.
                () => new JesterSuit(),
                () => new Shirt()
            )},

            { "Chest", new SlotDef(0.5,
                () => new LeatherChest(),
                () => new HideChest(),
                () => new WoodlandChest()
            )},

            { "Legs", new SlotDef(0.9,
                () => new LeatherSkirt(),
                () => new HidePants(),
                () => new LeafLegs(),
                () => new FurSarong()
            )},

            { "Skirt", new SlotDef(0.4,
                () => new LeatherSkirt(),
                () => new FurSarong()
            )},

            { "Arms", new SlotDef(0.3,
                () => new LeatherArms(),
                () => new HidePauldrons(),
                () => new WoodlandArms()
            )},

            { "Hands", new SlotDef(0.4,
                () => new LeatherGloves(),
                () => new HideGloves()
            )},

            { "Belt", new SlotDef(0.6,
                () => new HalfApron(),
                () => new WoodlandBelt()
            )},

            { "Neck", new SlotDef(0.2,
                () => new LeafGorget(),
                () => new LeatherGorget()
            )},

            { "Earring", new SlotDef(0.1,
                () => new GoldEarrings()
            )},

            // No bracelet/ring/talisman

            { "RightHand", new SlotDef(0.8,
                () => new Club(),
                () => new ShepherdsCrook(),
                () => new TribalSpear(),
                () => new SkinningKnife(),
                () => new GnarledStaff(),
                () => new TribalSpear(),    // Custom? Remove if not present.
                () => new BoneHarvester()
            )},

            { "LeftHand", new SlotDef(0.25,
                () => new WoodenShield(),
                () => new Torch()
            )}
        };

        // ==== VERDANT TRIBES QUESTS ONLY ====
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // These would be custom/faction-tied versions!
            () => new FactionCollectionQuestScroll("Leather", 15, "VerdantTribes", 600),
            () => new FactionCollectionQuestScroll("Fur", 10, "VerdantTribes", 400),
            () => new FactionDeliveryQuestScroll("Medicinal Herbs", "VerdantTribes", 200),
			
            () => new FactionCollectionQuestScroll("ElvenPants", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("HidePants", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherNinjaPants", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("TattsukeHakama", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("PlateLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("ChainLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("DragonLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("DragonTurtleHideLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeafLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("RingmailLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeafTonlet", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("TigerPeltLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("TigerPeltShorts", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherHaidate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("PlateHaidate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherSkirt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherSuneate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedHaidate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("PlateSuneate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedSuneate", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("WoodlandLegs", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("Skirt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("Kilt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("Hakama", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("FurSarong", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("TigerPeltLongSkirt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("GuildedKilt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("CheckeredKilt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("FancyKilt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("TigerPeltSkirt", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("PlateArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedBustierArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("RingmailArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("DragonArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeafArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("WoodlandArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("BoneArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("DragonTurtleHideArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("HidePauldrons", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherBustierArms", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("LeatherHiroSode", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("PlateHiroSode", 25, "VerdantTribes", 750),
            () => new FactionCollectionQuestScroll("StuddedHiroSode", 25, "VerdantTribes", 750),

            () => new FactionKillQuestScroll("Kappa", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("KazeKemono", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Kepetch", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("KepetchAmbusher", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("KhaldunRevenant", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("KhaldunSummoner", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("KhaldunZealot", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Kirin", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Kraken", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LadyOfTheSnow", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Lasher", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LavaElemental", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LavaLizard", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LavaSerpent", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LavaSnake", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LeatherWolf", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LesserHiryu", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Leviathan", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Lich", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LichLord", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Lifestealer", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Lion", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Lizardman", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Llama", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("LowlandBoura", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Macaw", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MaddeningHorror", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MantraEffervescence", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MeerCaptain", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MeerEternal", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MeerMage", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MeerWarrior", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MilitiaFighter", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Mimic", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MinionOfScelestus", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Minotaur", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MinotaurCaptain", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MinotaurGeneral", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MinotaurScout", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Moloch", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Mongbat", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MoundOfMaggots", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("MountainGoat", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Mummy", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Nightmare", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Niporailem", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Ogre", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OgreLord", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Oni", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OphidianArchmage", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OphidianKnight", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OphidianMage", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OphidianMatriarch", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OphidianWarrior", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Orc", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcBomber", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcBrute", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcCaptain", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcChopper", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcishLord", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcishMage", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OrcScout", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Ortanord", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("OsseinRam", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("PackHorse", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("PackLlama", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("PalaminoHorse", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Panther", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("ParoxysmusSwampDragon", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("PatchworkSkeleton", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("PestilentBandage", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Phoenix", "5", "VerdantTribes", "500"),
            () => new FactionKillQuestScroll("Pig", "5", "VerdantTribes", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.VerdantTribes, 350),				

			
        };

        // ==== CUSTOM NAMES & TITLES FOR VERDANT TRIBES ====
        private static string GenerateRandomName()
        {
            string[] first = {
                "Ash", "Birch", "Cedar", "Dew", "Elm", "Fawn", "Fern", "Grove", "Hawk", "Ivy",
                "Jade", "Kestrel", "Leaf", "Lynx", "Moss", "Oak", "Pine", "Quill", "Rain", "Reed",
                "Rook", "Rowan", "Sable", "Shade", "Sky", "Sparrow", "Stone", "Swift", "Thorn", "Willow",
                "Wolf", "Wren"
            };
            string[] last = {
                "of the Glen", "of the Vale", "of the Wild", "Leafsong", "Raincaller", "Greenbough", "Stonefoot",
                "Wolfbrother", "Earthkeeper", "Dawnwatcher", "Mistwalker", "Moonseer", "Firehand", "Rootbinder", "Stormchild",
                "Brightleaf", "Shadowtracker", "Nightbreeze", "Branchweaver", "Grasswhisper"
            };
            string[] titles = {
                "Tribesfolk", "Hunter", "Gatherer", "Caretaker", "Shaman", "Herbalist", "Scout", "Fisher", "Slingmaker",
                "Woodcarver", "Elder", "Wanderer", "Firekeeper", "Sunwatcher", "Beekeeper", "Healer", "Storyteller",
                "Drummer", "Dreamer", "Leafcrafter"
            };

            return $"{first[Utility.Random(first.Length)]} {last[Utility.Random(last.Length)]} the {titles[Utility.Random(titles.Length)]}";
        }

        [Constructable]
        public VerdantTribesCitizen() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
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
            var parts = fullName.Split(new[] { ' ' }, 3);

            if (parts.Length >= 2)
            {
                Name = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(40, 70));
            SetDex(Utility.RandomMinMax(40, 90));
            SetInt(Utility.RandomMinMax(30, 70));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private void InitOutfit()
        {
            foreach (var kv in _slotDefs)
            {
                if (Utility.RandomDouble() <= kv.Value.Chance)
                {
                    var factories = kv.Value.Pool;
                    var item = factories[Utility.Random(factories.Length)]();
                    item.Hue = Utility.RandomMinMax(1, 3000); // Earthy/green/brown
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1101, 1150); // Brown/black/grey tones
            if (!Female && Utility.RandomDouble() < 0.3)
                FacialHairItemID = Utility.RandomList(0x204B, 0x204C, 0x204D, 0x204E);
            FacialHairHue = HairHue;
        }

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
                player.SendMessage($"Our tribe needs time to prepare. Return in {wait.Minutes} minute(s).");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("The spirits are silent. Try again later.");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Take this task, friend of the Verdant Tribes.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly VerdantTribesCitizen _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, VerdantTribesCitizen npc) : base(6156)
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

        public VerdantTribesCitizen(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
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
