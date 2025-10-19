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
    [CorpseName("the remains of a Moonglow citizen")]
    public class MoonglowCitizen : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // --- Equipment: Only mage/scholar/citizen types ---
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool) { Chance = chance; Pool = pool; }
        }

        // Moonglow equipment pool: No armor, almost all mage/scholar gear, sashes, books, crystal balls, etc.
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            // Always shoes/sandals
            { "Footwear", new SlotDef(1.0, () => new Shoes(), () => new Sandals(), () => new Boots()) },
            // Robes/scholar garb (common)
            { "Robe", new SlotDef(0.9, 
                () => new Robe(), 
                () => new MonkRobe(), 
                () => new Robe(), 
                () => new HoodedShroudOfShadows(), 
                () => new FloweredDress(), 
                () => new MaleKimono(), 
                () => new FemaleKimono(),
                () => new ElvenShirt(),
                () => new Robe()
            )},
            // Sashes/scarves (common)
            { "Sash", new SlotDef(0.7, 
                () => new BodySash(), 
                () => new Doublet(), 
                () => new BodySash()
            )},
            // Head: Wizard hats, circlets, no helmets
            { "Head", new SlotDef(0.5, 
                () => new WizardsHat(), 
                () => new Circlet(), 
                () => new FlowerGarland(), 
                () => new HoodedShroudOfShadows()
            )},
            // Shirt/tunic for under-robe
            { "Shirt", new SlotDef(0.6, 
                () => new Shirt(), 
                () => new FancyShirt(), 
                () => new Tunic(), 
                () => new BodySash()
            )},
            // Book, scroll, or staff in hand (Moonglow signature!)
            { "RightHand", new SlotDef(0.7, 
                () => new GnarledStaff(), 
                () => new BlackStaff(), 
                () => new MagicWand(), 
                () => new Spellbook(), 
                () => new CrystalBall(), 
                () => new PenAndInk()
            )},
            // Left hand: crystal, scroll, or nothing (rare)
            { "LeftHand", new SlotDef(0.2, 
                () => new CrystalBall(), 
                () => new Spellbook()
            )},
            // Cloak, rare
            { "Back", new SlotDef(0.2, () => new Cloak()) }
        };

        // Only Moonglow-faction quest scrolls (assuming your quest scrolls take a faction or location param)
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Replace these with your actual Moonglow-only quest constructors if available:
            () => new FactionCollectionQuestScroll("MandrakeRoot", 20, "Moonglow", 700),
            () => new FactionDeliveryQuestScroll("Arcane Supplies", "Moonglow", 1500),
            () => new FactionKillQuestScroll("Lich", 5, "Moonglow", 2000),
            () => new DeliveryQuestScroll("Spell Components", 500, typeof(Bottle)),  // fallback generic
            () => new CollectionQuestScroll("Reagents", 30, 7000),
			
            () => new FactionCollectionQuestScroll("ReactiveArmorScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ClumsyScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("CreateFoodScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("FeeblemindScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("HealScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MagicArrowScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("NightSightScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("WeakenScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("AgilityScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("CunningScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("CureScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("HarmScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MagicTrapScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MagicUntrapScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ProtectionScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("StrengthScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("BlessScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("FireballScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MagicLockScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("PoisonScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("TelekinisisScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("TeleportScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("UnlockScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("WallOfStoneScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ArchCureScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ArchProtectionScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("CurseScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("FireFieldScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("GreaterHealScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("LightningScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ManaDrainScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("RecallScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("BladeSpiritsScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("DispelFieldScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("IncognitoScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MagicReflectScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MindBlastScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ParalyzeScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("PoisonFieldScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("SummonCreatureScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("DispelScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("EnergyBoltScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ExplosionScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("InvisibilityScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MarkScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("MassCurseScroll", 25, "Moonglow", 750),
            () => new FactionCollectionQuestScroll("ParalyzeFieldScroll", 25, "Moonglow", 750),
			
			
            () => new FactionKillQuestScroll("CultDrake", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CultGargoyle", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CultLibrarian", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CultMatriarch", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CultMonster", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CultVoicebearer", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CursedSolenWarrior", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DaemonicFerret", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DemonicGrizzly", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomedGrizzle", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomedSkree", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomGuardian", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomriddenPackhorse", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomscaleAlligator", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomsCaptain", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("Doomwood", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("EntropyElemental", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("GoblinCultist", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("MatriarchOfDespair", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("NightmareMongbat", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("OblivionServant", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("PhantomCat", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("PutrescentBulb", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("ShadowWolf", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("VoidEowmu", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("VoidPriest", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("VoidRabbit", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("VoidWebspinner", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("AbyssalManefall", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("AgedAlloyWraith", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BoneboundMarksman", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CadaverousWarlord", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("CinderedShade", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DecaybruteTroll", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DesolateOoze", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DireRevenant", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DoomedDrake", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DuskwroughtStalker", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("DustboundArcanist", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("EternalWatcher", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("EternalWoe", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FallenKnightOfExodus", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FlickeringRemnant", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("ForsakenDominion", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FrozenFenrir", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("GhoststripeLeopard", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("GraveclawUrsus", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("GraveWhispers", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("MournfulVapors", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("NecroticWyrm", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("PhantomTrickster", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("PlagueboundFeline", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("RaggedRemains", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("RestlessSpirit", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("RotfangGoblin", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SepulchralArchmage", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("ShadowclawBandit", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("ShatteredMajesty", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("ShiveringSpecter", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SkullfangReaper", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SpectralCharger", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SpectralSentry", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SpectralUrsus", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("StygianHellhound", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("SunkenAurumWraith", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("WailingSprite", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("AshWraith", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BlazingBones", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BlazingBoura", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BlazingLlama", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BlazingShade", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BlazingTitan", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BurningCorpse", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BurningGargoyle", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("BurningRavager", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("EmberKitsune", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FireScorchedSkeleton", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FirestoneElemental", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FlameBird", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("Flamebot", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("FlameController", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("GoblinArsonist", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("HellDragon", "5", "Moonglow", "500"),
            () => new FactionKillQuestScroll("HellfireProtector", "5", "Moonglow", "500"),			

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Moonglow, 350),				
			
        };

        // --- Moonglow names/titles: Academic, mystical, or Lyceum-centric
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Selene", "Orin", "Mira", "Galiel", "Lira", "Tyrus", "Ilyana", "Fenton", "Merith", "Darian",
                "Rhiannon", "Elowen", "Erasmus", "Elara", "Lyra", "Zoren", "Sable", "Tirion", "Ariane", "Evander",
                "Thaddeus", "Seren", "Fiora", "Azrael", "Jadzia", "Cyrus", "Sabine", "Jasper", "Iolana", "Noira"
            };
            string[] lastNames = new[]
            {
                "of the Lyceum", "the Scribe", "the Starwatcher", "the Sage", "the Astrologer", "the Archivist",
                "the Scrollkeeper", "the Loremaster", "the Chronicler", "the Seeker", "the Philosopher",
                "the Spellwright", "the Magister", "of Verity Isle", "the Crystal Seer", "the Reagentmaster",
                "the Illusionist", "the Theurgist", "of Moonglow"
            };
            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            return $"{first} {last}";
        }

        [Constructable]
        public MoonglowCitizen()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            InitBody();
            InitOutfit();
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
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
                Name = parts[0];
                Title = fullName.Substring(parts[0].Length + 1); // preserves full title
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(30, 50));
            SetDex(Utility.RandomMinMax(30, 50));
            SetInt(Utility.RandomMinMax(60, 100));
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
                    item.Hue = Utility.RandomMinMax(1, 1281); // mage-like hues
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 3000);
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
                player.SendMessage($"I need to restock my scrolls. Come back in {wait.Minutes} minute(s).");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Hmm, something went wrong. Try again later.");
                return;
            }

            if (scroll != null)
            {
                // If quest scroll has a Faction property, set it to "Moonglow" here (pseudo-code):
                // if (scroll is FactionQuestScroll fq) fq.Faction = "Moonglow";
                player.AddToBackpack(scroll);
                player.SendMessage("Here, take this quest scroll for Moonglow!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly MoonglowCitizen _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, MoonglowCitizen npc)
                : base(6156) { _npc = npc; _from = from; Enabled = true; }
            public override void OnClick()
            {
                if (_from == null || _npc == null) return;
                _npc.TryGiveQuest(_from);
            }
        }

        // Persistence
        public MoonglowCitizen(Serial serial) : base(serial) { }
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
