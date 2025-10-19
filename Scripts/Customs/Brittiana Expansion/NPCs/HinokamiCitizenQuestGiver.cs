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
    [CorpseName("the remains of a Hinokami villager")]
    public class HinokamiCitizenQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------------- HINOKAMI EQUIPMENT POOL ------------------------
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

        // Japanese/Tokuno/Hinokami-appropriate outfit only
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.98,
                () => new NinjaTabi(),
                () => new SamuraiTabi(),
                () => new Waraji()
            )},

            { "Robe", new SlotDef(0.35,
                () => new MaleKimono(),
                () => new FemaleKimono(),
                () => new Kamishimo(),
                () => new HakamaShita()
            )},

            { "Back", new SlotDef(0.15,
                () => new Obi() // Obi sometimes worn at back
            )},

            { "Head", new SlotDef(0.45,
                () => new Kasa(),
                () => new StrawHat(),
                () => new ClothNinjaHood(),
                () => new DecorativePlateKabuto(),
                () => new PlateBattleKabuto()
            )},

            { "Shirt", new SlotDef(0.75,
                () => new JinBaori(),
                () => new FancyShirt(),
                () => new ClothNinjaJacket()
            )},

            { "Chest", new SlotDef(0.25,
                () => new LeatherDo(),
                () => new PlateDo(),
                () => new LeatherNinjaJacket()
            )},

            { "Legs", new SlotDef(0.80,
                () => new Hakama(),
                () => new TattsukeHakama(),
                () => new LeatherNinjaPants()
            )},

            { "Skirt", new SlotDef(0.20,
                () => new Hakama()
            )},

            { "Arms", new SlotDef(0.30,
                () => new LeatherHiroSode(),
                () => new PlateHiroSode()
            )},

            { "Hands", new SlotDef(0.50,
                () => new LeatherNinjaMitts()
            )},

            { "Belt", new SlotDef(0.75,
                () => new Obi()
            )},

            { "Neck", new SlotDef(0.10,
                () => new LeatherGorget()
            )},

            // **Optional jewelry, very rare**
            { "Earring", new SlotDef(0.04, () => new GoldEarrings()) },
            { "Bracelet", new SlotDef(0.03, () => new GoldBracelet()) },
            { "Ring", new SlotDef(0.03, () => new GoldRing()) },

            // Weapons, focus on Tokuno style
            { "RightHand", new SlotDef(0.80,
                () => new Katana(),
                () => new Wakizashi(),
                () => new Daisho(),
                () => new Bokuto(),
                () => new Kama(),
                () => new Nunchaku(),
                () => new Tessen(),
                () => new Tekagi(),
                () => new Tetsubo(),
                () => new Yumi()
            )},

            { "LeftHand", new SlotDef(0.20,
                () => new Lantern(), // some flavor
                () => new WoodenShield()
            )},
        };

        // -------------- QUESTS: Hinokami Faction only --------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Replace/add with Hinokami-specific quests if you want
            () => new FactionCollectionQuestScroll("Rice Bundle", 10, "Hinokami", 300), // Sample: gather rice for the town
            () => new FactionKillQuestScroll("Ninja", 5, "Hinokami", 800), // Defeat enemy ninja
            () => new FactionDeliveryQuestScroll("Herbs", "Hinokami", 5), // Deliver rare herbs
			
            () => new FactionCollectionQuestScroll("SmallPlateJingasa", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("StandardPlateKabuto", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("StuddedMempo", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("TigerPeltHelm", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("VultureHelm", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("PlateHatsuburi", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("BoneHelm", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("DragonHelm", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("HeavyPlateJingasa", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("WingedHelm", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FancyShirt", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("Tunic", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("BodySash", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("Shirt", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("ElvenShirt", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FormalShirt", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("ClothNinjaJacket", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("Doublet", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("Surcoat", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("JinBaori", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("JesterSuit", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("PlateChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("RingmailChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("ChainChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LeatherChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FemaleLeatherChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FemalePlateChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("StuddedChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("BoneChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("DragonChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("DragonTurtleHideChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FemaleLeafChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("FemaleStuddedChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("HideFemaleChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LeafChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LeatherNinjaJacket", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("TigerPeltChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("WoodlandChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("HideChest", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LeatherDo", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("PlateDo", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("StuddedDo", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("DragonTurtleHideBustier", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("TigerPeltBustier", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LongPants", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("ShortPants", 25, "Hinokami", 750),
            () => new FactionCollectionQuestScroll("LeatherShorts", 25, "Hinokami", 750),			


            () => new FactionKillQuestScroll("RedSolenInfiltratorQueen", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RedSolenInfiltratorWarrior", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RedSolenQueen", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RedSolenWarrior", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RedSolenWorker", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RenegadeChangeling", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Reptalon", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RestlessSoul", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Revenant", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RevenantLion", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RidableLlama", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Ridgeback", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Ronin", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RottingCorpse", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Rotworm", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RuddyBoura", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RuneBeetle", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SabertoothedTiger", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SandVortex", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SAPixie", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Satyr", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Savage", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SavageRider", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SavageRidgeback", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SavageShaman", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ScaledSwampDragon", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Scorpion", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SeaHorse", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SeaSerpent", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SentinelSpider", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SerpentineDragon", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SerpentsFangAssassin", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SerpentsFangHighExecutioner", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SewerRat", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Shade", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowDweller", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowIronElemental", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowWisp", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowWyrm", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WhiteWolf", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WhiteWyrm", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Wight", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WildTiger", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Windrunner", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Wisp", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WolfSpider", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Wraith", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Wyvern", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Yamandon", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("YomotsuElder", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("YomotsuPriest", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("YomotsuWarrior", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("YoungNinja", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("YoungRonin", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("Zombie", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("BreezePhantom ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("CycloneDemon ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("GaleWisp ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("MysticWisp ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowDrifter ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SkySeraph ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("StormHerald ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("TempestSpirit ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("TempestWyrm ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("VortexGuardian ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WhirlwindFiend ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ZephyrWarden ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("AcidicAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("AncientAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("FirebreathAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("FrostbiteAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("IllusionaryAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RagingAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("StormAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ToxicAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("VenomousAlligator ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("FlameBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("FrostBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("LeafBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("LightBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("RockBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ShadowBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("SteelBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("ThunderBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("VenomBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("WindBear ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("AngusBerserker ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("BisonBrute ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("DairyWraith ", "5", "Hinokami", "500"),
            () => new FactionKillQuestScroll("GuernseyGuardian ", "5", "Hinokami", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Hinokami, 350),				
			
            // ... Add more as needed!
        };

        // -------------- NAMES & TITLES: Japanese Style --------------
        private static readonly string[] FirstNames = new[]
        {
            "Akio", "Daichi", "Haruto", "Itsuki", "Kaito", "Kenshin", "Makoto", "Ren", "Sora", "Takumi",
            "Yamato", "Yori", "Asuka", "Chiyo", "Emi", "Hana", "Kaede", "Mio", "Rin", "Suzu",
            "Yuna", "Naoki", "Shin", "Yui", "Keiko", "Minato", "Sho", "Koharu", "Ayame", "Rei"
        };

        private static readonly string[] LastNames = new[]
        {
            "Watanabe", "Takahashi", "Kobayashi", "Nakamura", "Yamamoto", "Ito", "Sato", "Tanaka", "Suzuki", "Yoshida",
            "Fujimoto", "Ogawa", "Sasaki", "Inoue", "Kondo", "Ishida", "Miyazaki", "Nakajima", "Ueda", "Morita"
        };

        private static readonly string[] Titles = new[]
        {
            "the Merchant", "the Farmer", "the Monk", "the Ronin", "the Fisherman", "the Artisan",
            "of Hinokami", "the Herbalist", "the Weaver", "the Bamboo Cutter",
            "of the Cherry Blossoms", "the Crane Keeper", "the Teahouse Keeper", "the Potter", "the Lantern Maker"
        };

        [Constructable]
        public HinokamiCitizenQuestGiver()
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
                Name = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(50, 90));
            SetDex(Utility.RandomMinMax(60, 100));
            SetInt(Utility.RandomMinMax(50, 90));
            SpeechHue = Utility.RandomMinMax(1100, 1150); // A bit more neutral for Hinokami
        }

        private static string GenerateRandomName()
        {
            string first = FirstNames[Utility.Random(FirstNames.Length)];
            string last = LastNames[Utility.Random(LastNames.Length)];
            string title = Titles[Utility.Random(Titles.Length)];
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
                    // Subtle dye hues, favoring natural, brown, black, grey, navy, dark red
                    item.Hue = Utility.RandomList(0, 1109, 1208, 1150, 1161, 1102, 1258, 2406, 2407, 2408, 1175, 2413, 2101, 2115, 2419);
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this); // Use dark, straight, or topknot for flavor
            HairHue = Utility.RandomList(1102, 1109, 1175, 2101, 2413, 2419); // Dark colors
            if (!Female && Utility.RandomBool())
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
                player.SendMessage($"Please, return in {wait.Minutes} minute(s) when I am ready with another request.");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Apologies. Something went wrong.");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("This task is for the honor of Hinokami. Please accept it.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly HinokamiCitizenQuestGiver _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, HinokamiCitizenQuestGiver npc)
                : base(6156) // “Talk” icon id
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

        public HinokamiCitizenQuestGiver(Serial serial) : base(serial) { }

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
