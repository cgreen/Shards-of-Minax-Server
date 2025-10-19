using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheIcelandicSagas : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheIcelandicSagas()
        {
            Name = "Treasure Chest of the Icelandic Sagas";
            Hue = 1150; // Frosty blue

            // Decorative/Lore Items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Volcanic Vase of Hekla", 2052), 0.15);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Orb of the Northern Lights", 1266), 0.13);
            AddItem(CreateDecorativeItem<ChangelingStatue>("Elfstone of the Hidden People", 1139), 0.14);
            AddItem(CreateDecorativeItem<RunebookDyeTub>("Runestone of Snorri Sturluson", 1109), 0.11);
            AddItem(CreateDecorativeItem<MedusaStatue>("Troll Guardian of the Fjords", 1107), 0.13);
            AddItem(CreateDecorativeItem<ArcaneTable>("Table of the Thingvellir", 2055), 0.12);
            AddItem(CreateDecorativeItem<BlueBook>("Saga Book: Egil’s Poems", 1153), 0.16);

            // Unique Consumables
            AddItem(CreateConsumableItem<GreaterHealPotion>("Eir’s Elixir of Healing", 96), 0.16);
            AddItem(CreateConsumableItem<RandomDrink>("Viking Mead of Reykjavik", 2213), 0.12);
            AddItem(CreateConsumableItem<RandomFancyFish>("Smoked Puffin Feast", 2054), 0.09);
            AddItem(CreateConsumableItem<BowlOfBlackrockStew>("Hot Geysir Stew", 1172), 0.13);
            AddItem(CreateConsumableItem<CheeseWheel>("Wheel of Skyr Cheese", 1150), 0.11);

            // Equipment (icy, volcanic, and Norse myth themed)
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateCloak(), 0.17);
            AddItem(CreateHelm(), 0.18);

            // Special Clothing
            AddItem(CreateClothing(), 0.21);

            // Gold/Wealth
            AddItem(new Gold(Utility.Random(3000, 8000)), 0.20);

            // Lore Book
            DropItem(new LoreOfTheIcelandicSagas());

            // Rare: "Elf Blessing" artifact, very low chance
            AddItem(CreateDecorativeItem<ElvenBoots>("Boots of the Huldufólk", 1289), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Epic Weapon: “Frostbrand of Egil”
        private Item CreateWeapon()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Frostbrand of Egil";
            sword.Hue = 1150; // Icy blue
            sword.MinDamage = 35;
            sword.MaxDamage = 72;
            sword.WeaponAttributes.HitColdArea = 30;
            sword.WeaponAttributes.HitLeechHits = 15;
            sword.WeaponAttributes.HitLightning = 20;
            sword.WeaponAttributes.SelfRepair = 8;
            sword.Attributes.BonusStr = 8;
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.SpellChanneling = 1;
            sword.Attributes.Luck = 100;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Epic Armor: “Mail of the Eruption”
        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Mail of the Eruption";
            armor.Hue = 1367; // Volcanic red
            armor.BaseArmorRating = 65;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.LowerManaCost = 10;
            armor.FireBonus = 20;
            armor.ColdBonus = 20;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 10;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Epic Cloak: “Mantle of the Aurora”
        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Mantle of the Aurora";
            cloak.Hue = 1266; // Aurora green/blue
            cloak.Attributes.RegenMana = 5;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.Luck = 75;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Epic Helm: “Helm of Snorri Sturluson”
        private Item CreateHelm()
        {
            NorseHelm helm = new NorseHelm();
            helm.Name = "Helm of Snorri Sturluson";
            helm.Hue = 1157; // Steel blue
            helm.BaseArmorRating = 40;
            helm.Attributes.BonusInt = 10;
            helm.ArmorAttributes.LowerStatReq = 20;
            helm.SkillBonuses.SetValues(0, SkillName.Inscribe, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        // Epic Clothing: “Skald’s Saga Robe”
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Skald’s Saga Robe";
            robe.Hue = 1153; // Deep blue
            robe.Attributes.BonusMana = 20;
            robe.Attributes.LowerRegCost = 20;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.CastSpeed = 2;
            robe.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfTheIcelandicSagas(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    // --- Custom Lore Book: LoreOfTheIcelandicSagas ---
    public class LoreOfTheIcelandicSagas : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Lore of the Icelandic Sagas", "Skald Ólafur the Wise",
            new BookPageInfo
            (
                "Land of Fire and Ice,",
                "Where glaciers meet lava,",
                "and the Northern Lights",
                "paint runes on the sky.",
                "",
                "In 874, Ingólfur Arnarson",
                "raised his hall by smoky",
                "bays and set the land’s",
                "destiny in motion."
            ),
            new BookPageInfo
            (
                "Vikings braved seas and",
                "frostbitten winds, weaving",
                "law at the Thingvellir.",
                "Here was spoken the",
                "Althing, oldest assembly.",
                "",
                "From these stones, sagas",
                "rose: tales of heroes,",
                "poets, and trolls."
            ),
            new BookPageInfo
            (
                "Egil Skallagrímsson sang",
                "his wrath and sorrows.",
                "Snorri Sturluson wrote",
                "the Eddas, shaping the",
                "world’s memory of gods,",
                "elves, and Ragnarok.",
                "",
                "Magic thrived in shadowed",
                "valleys, whispered by elves."
            ),
            new BookPageInfo
            (
                "The land itself is alive:",
                "Hekla erupts, geysers sing,",
                "volcano and glacier war.",
                "",
                "Those who cross the",
                "fjords may yet meet the",
                "Huldufólk — hidden folk",
                "who bless or trick."
            ),
            new BookPageInfo
            (
                "From the icy caves of",
                "Vatnajökull to the deep",
                "roots of the World Tree,",
                "Iceland stands between",
                "saga and reality, shaped",
                "by courage, wit, and",
                "the magic of survival.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May you find wisdom",
                "in runes, strength in",
                "the storm, and always,",
                "wonder in this ancient",
                "isle.",
                "",
                "- Skald Ólafur"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LoreOfTheIcelandicSagas() : base(false)
        {
            Hue = 1150; // Icy blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Lore of the Icelandic Sagas");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Lore of the Icelandic Sagas");
        }

        public LoreOfTheIcelandicSagas(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadEncodedInt();
        }
    }
}
