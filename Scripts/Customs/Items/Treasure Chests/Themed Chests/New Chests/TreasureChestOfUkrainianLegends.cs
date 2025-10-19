using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfUkrainianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfUkrainianLegends()
        {
            Name = "Treasure Chest of Ukrainian Legends";
            Hue = 1153; // Deep blue

            // Add themed items
            AddItem(new UkrainianLoreBook(), 1.0);
            AddItem(CreateDecor("Scythian Gold Pectoral", typeof(GoldBricks), 2213), 0.12);
            AddItem(CreateDecor("Trypillian Pottery Jar", typeof(ArtifactLargeVase), 2411), 0.14);
            AddItem(CreateDecor("Pysanka of Fortune", typeof(Ruby), 1161), 0.16);
            AddItem(CreateDecor("Sunflower of the Steppes", typeof(FlowersArtifact), 1270), 0.20);
            AddItem(CreateDecor("Blessed Wheat Sheaf", typeof(WheatSheaf), 1195), 0.16);
            AddItem(CreateDecor("Kyiv Pechersk Lantern", typeof(LampPostArtifact), 2075), 0.09);
            AddItem(CreateDecor("Kozak Sabre Stand", typeof(SwordDisplay2NorthArtifact), 1177), 0.10);
            AddItem(CreateDecor("Carved Wooden Rushnyk", typeof(Tapestry4W), 1193), 0.10);

            // Special food/drink
            AddItem(CreateConsumable("Loaf of Korovai (Blessed Wedding Bread)", typeof(BreadLoaf), 1170), 0.13);
            AddItem(CreateConsumable("Flask of Horilka", typeof(GreenBottle), 1154), 0.11);
            AddItem(CreateConsumable("Honey from Podillia", typeof(JarHoney), 1196), 0.11);
            AddItem(CreateConsumable("Varenyky Platter", typeof(Cookies), 1193), 0.08);

            // Unique wearables
            AddItem(CreateHat(), 0.18);
            AddItem(CreateShirt(), 0.17);
            AddItem(CreateBoots(), 0.15);

            // Unique weapons and armor
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateShield(), 0.10);

            // Misc
            AddItem(CreateGoldItem("Hryvnia Coins"), 0.14);
            AddItem(CreateMap(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            item.LootType = LootType.Blessed;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(2000, 5000);
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Ancient Kyiv";
            map.Bounds = new Rectangle2D(1500, 1350, 350, 350);
            map.NewPin = new Point2D(1677, 1512);
            map.Protected = true;
            return map;
        }

        private Item CreateHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Kozak Otaman’s Cossack Hat";
            hat.Hue = 1190;
            hat.Attributes.BonusHits = 10;
            hat.Attributes.Luck = 100;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateShirt()
        {
            FancyShirt shirt = new FancyShirt();
            shirt.Name = "Vyshyvanka (Embroidered Shirt of Heroes)";
            shirt.Hue = 1173;
            shirt.Attributes.BonusDex = 8;
            shirt.Attributes.BonusInt = 8;
            shirt.Attributes.BonusStam = 8;
            shirt.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            shirt.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            shirt.Attributes.LowerManaCost = 5;
            shirt.Attributes.RegenMana = 2;
            XmlAttach.AttachTo(shirt, new XmlLevelItem());
            return shirt;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Red Boots of the Kyiv Walker";
            boots.Hue = 2074;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.Luck = 75;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateWeapon()
        {
            Scimitar saber = new Scimitar();
            saber.Name = "Kozak Sabre of Freedom";
            saber.Hue = 1177;
            saber.MinDamage = Utility.Random(25, 35);
            saber.MaxDamage = Utility.Random(45, 60);
            saber.WeaponAttributes.HitLightning = 25;
            saber.WeaponAttributes.HitHarm = 15;
            saber.WeaponAttributes.SelfRepair = 5;
            saber.Attributes.WeaponSpeed = 15;
            saber.Attributes.AttackChance = 10;
            saber.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Golden Chestplate of Prince Volodymyr";
            armor.Hue = 2213;
            armor.BaseArmorRating = 50;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.BonusStr = 8;
            armor.Attributes.ReflectPhysical = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Trident Shield of Tryzub";
            shield.Hue = 1175;
            shield.Attributes.DefendChance = 12;
            shield.Attributes.Luck = 60;
            shield.Attributes.ReflectPhysical = 8;
            shield.SkillBonuses.SetValues(0, SkillName.Tactics, 8.0);
            shield.SkillBonuses.SetValues(1, SkillName.Anatomy, 6.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfUkrainianLegends(Serial serial) : base(serial) { }

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

    public class UkrainianLoreBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Steppe: The Rise of Ukraine", "Volodymyr the Chronicler",
            new BookPageInfo(
                "In the mists before time,",
                "the steppes echoed with",
                "Scythian horsemen, wild and",
                "free. The Dnipro flowed,",
                "untamed, beside golden",
                "fields of wheat. From",
                "Trypillian pottery to",
                "Kyiv's seven hills, a land",
                "awaited its destiny."
            ),
            new BookPageInfo(
                "The Rus' princes forged",
                "a realm of strength and",
                "faith. Olha's wisdom,",
                "Volodymyr's baptism, Yaroslav's",
                "law, the golden domes",
                "of Kyiv—light of the East.",
                "Yet invaders came:",
                "Mongol riders, dark clouds.",
                ""
            ),
            new BookPageInfo(
                "But from the ashes,",
                "rose the Cossacks, fierce",
                "as the falcon. Zaporizhzhia's",
                "Sich, freedom’s fortress.",
                "With sabres drawn and",
                "songs loud, they rode",
                "against tyrant and foe,",
                "dreaming of liberty."
            ),
            new BookPageInfo(
                "Hetmans led, wars raged.",
                "Empires shifted, borders changed,",
                "but the spirit remained.",
                "Villages flourished, songs",
                "and embroidered cloth",
                "kept old stories alive.",
                "The trident flag rose anew",
                "on the wind of hope."
            ),
            new BookPageInfo(
                "O seeker of legends,",
                "within this chest you",
                "find treasures old and",
                "new: gold of princes,",
                "wheat of the land, the",
                "sabres of heroes, and",
                "the heart of Ukraine—",
                "unyielding, eternal."
            ),
            new BookPageInfo(
                "Take with respect, for",
                "the steppes remember.",
                "Every grain of wheat",
                "once drank blood, every",
                "song hides tears, every",
                "hero's name—sacrifice.",
                "",
                ""
            ),
            new BookPageInfo(
                "So carry these relics,",
                "and know: Ukraine’s story",
                "is not finished. The",
                "steppe rides on. The",
                "trident shines. And the",
                "future is written in",
                "golden wheat and blue",
                "sky.",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public UkrainianLoreBook() : base(false)
        {
            Hue = 1153; // Ukrainian blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Steppe: The Rise of Ukraine");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Steppe: The Rise of Ukraine");
        }

        public UkrainianLoreBook(Serial serial) : base(serial) { }

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
