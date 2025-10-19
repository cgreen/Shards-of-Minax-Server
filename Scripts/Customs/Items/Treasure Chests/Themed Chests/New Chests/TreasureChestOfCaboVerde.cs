using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCaboVerde : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCaboVerde()
        {
            Name = "Treasure Chest of Cabo Verde";
            Hue = 2107; // Ocean blue-green

            // Add items to the chest
            AddItem(CreateNamedArtifact<ArtifactLargeVase>("Morna Song Vase", 2129), 0.13);
            AddItem(CreateNamedArtifact<CrabBushel>("Bushel of Sal Island Crab", 2787), 0.18);
            AddItem(CreateNamedArtifact<DecorativeFishTank>("Atlantic Soul Aquarium", 1876), 0.16);
            AddItem(CreateColoredItem<Sandals>("Sailor’s Drift Sandals", 2405), 0.15);
            AddItem(CreatePirateCloak(), 0.17);
            AddItem(CreateNavigatorHat(), 0.17);
            AddItem(CreateNamedArtifact<BlueBeaker>("Potion of Brava Breezes", 1154), 0.13);
            AddItem(CreateNamedArtifact<RandomFancyCoin>("Coin of Mindelo", 2967), 0.14);
            AddItem(CreateNamedArtifact<FancyPainting>("Portrait of Cesária Évora", 2519), 0.09);
            AddItem(CreateNamedArtifact<SwordDisplay2NorthArtifact>("Sword of the Windward Islands", 2608), 0.10);
            AddItem(CreateNamedArtifact<GreenTea>("Infusion of Santo Antão", 1406), 0.13);
            AddItem(CreateTreasureWeapon(), 0.19);
            AddItem(CreateTreasureArmor(), 0.18);
            AddItem(CreateCreoleShirt(), 0.20);
            AddItem(CreateTidalSkirt(), 0.17);
            AddItem(CreateLavaDagger(), 0.14);
            AddItem(new LegendsOfCaboVerde(), 1.0);
            AddItem(CreateMap(), 0.07);
            AddItem(new Gold(Utility.Random(1000, 5000)), 0.12);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreatePirateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Pirate Cloak of Praia";
            cloak.Hue = 1175;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.BonusDex = 8;
            cloak.Attributes.BonusStam = 5;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Snooping, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateNavigatorHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Navigator’s Tricorne of São Vicente";
            hat.Hue = 2414;
            hat.Attributes.NightSight = 1;
            hat.Attributes.BonusInt = 5;
            hat.Attributes.BonusMana = 7;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateTreasureWeapon()
        {
            Cutlass weapon = new Cutlass();
            weapon.Name = "Corsair’s Cutlass of Mindelo";
            weapon.Hue = 1779;
            weapon.MinDamage = 38;
            weapon.MaxDamage = 67;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.WeaponDamage = 25;
            weapon.Attributes.BonusHits = 10;
            weapon.WeaponAttributes.HitLeechStam = 12;
            weapon.WeaponAttributes.HitHarm = 16;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateTreasureArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Volcanic Breastplate of Fogo";
            armor.Hue = 1157;
            armor.BaseArmorRating = 60;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.ReflectPhysical = 15;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ColdBonus = 10;
            armor.FireBonus = 20;
            armor.PoisonBonus = 5;
            armor.EnergyBonus = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCreoleShirt()
        {
            FancyShirt shirt = new FancyShirt();
            shirt.Name = "Creole Songweaver’s Shirt";
            shirt.Hue = 2966;
            shirt.Attributes.BonusMana = 12;
            shirt.Attributes.RegenMana = 2;
            shirt.Attributes.LowerManaCost = 8;
            shirt.SkillBonuses.SetValues(0, SkillName.Musicianship, 18.0);
            shirt.SkillBonuses.SetValues(1, SkillName.Peacemaking, 12.0);
            XmlAttach.AttachTo(shirt, new XmlLevelItem());
            return shirt;
        }

        private Item CreateTidalSkirt()
        {
            Skirt skirt = new Skirt();
            skirt.Name = "Tidal Skirt of Santiago";
            skirt.Hue = 2108;
            skirt.Attributes.BonusStam = 7;
            skirt.Attributes.RegenStam = 2;
            skirt.Attributes.Luck = 17;
            skirt.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            skirt.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            XmlAttach.AttachTo(skirt, new XmlLevelItem());
            return skirt;
        }

        private Item CreateLavaDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Fogo Lava Dagger";
            dagger.Hue = 1161;
            dagger.MinDamage = 27;
            dagger.MaxDamage = 58;
            dagger.Attributes.BonusDex = 8;
            dagger.Attributes.WeaponSpeed = 10;
            dagger.WeaponAttributes.HitFireball = 20;
            dagger.WeaponAttributes.SelfRepair = 4;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Cape Verde Islands";
            map.Bounds = new Rectangle2D(4300, 1800, 600, 450); // Arbitrary coords for RP
            map.NewPin = new Point2D(4550, 2050);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfCaboVerde(Serial serial) : base(serial)
        {
        }

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

    public class LegendsOfCaboVerde : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of Cabo Verde", "Chronicler João Vaz",
            new BookPageInfo
            (
                "Upon the great blue cloak,",
                "the isles of Cabo Verde rest,",
                "birthed from fire and cooled",
                "by the Atlantic’s breath.",
                "Here the salt and the song",
                "mingle, from Africa to Europa,",
                "with every wind a tale to tell."
            ),
            new BookPageInfo
            (
                "Once uninhabited, the islands",
                "were found by Portuguese sails,",
                "swept westward by fate in 1460.",
                "They became crossroads for",
                "merchants, slaves, pirates, and",
                "wanderers—a forge of new peoples,",
                "tongues, and musics."
            ),
            new BookPageInfo
            (
                "The sea both blessed and cursed:",
                "ships laden with hope and with",
                "chains, with coffee and morna.",
                "Drought and famine would test",
                "the spirit of the isle, but never",
                "quench the fire of her people.",
                ""
            ),
            new BookPageInfo
            (
                "From Mindelo’s harbor songs to",
                "the volcanoes of Fogo, from",
                "the green valleys of Santo Antão",
                "to the salt pans of Sal, every",
                "isle whispers a legend. Every",
                "breeze carries a longing—sodade,",
                "the bittersweet yearning of home."
            ),
            new BookPageInfo
            (
                "In these chests, treasures from",
                "every tide: Creole gold, music",
                "made solid, a pirate’s hope,",
                "and the pulse of the earth itself.",
                "",
                "May you honor these isles,",
                "and never lose your way upon",
                "the sea."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LegendsOfCaboVerde() : base(false)
        {
            Hue = 2107; // Deep blue-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of Cabo Verde");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of Cabo Verde");
        }

        public LegendsOfCaboVerde(Serial serial) : base(serial) { }

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
