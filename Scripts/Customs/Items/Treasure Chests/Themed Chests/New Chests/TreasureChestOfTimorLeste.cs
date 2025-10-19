using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTimorLeste : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTimorLeste()
        {
            Name = "Treasure Chest of Timor-Leste";
            Hue = 1152; // Deep blue, representing the ocean around Timor

            // Add themed items to the chest
            AddItem(CreateTaisCloth(), 0.25);
            AddItem(CreateSacredSandalwood(), 0.20);
            AddItem(CreateCoffeeBasket(), 0.18);
            AddItem(CreateTimoreseStatue(), 0.10);
            AddItem(CreateAncientSpiritMask(), 0.12);
            AddItem(CreateNamedItem<GoldRing>("Ring of Maubere Resilience"), 0.17);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateFightingSarong(), 0.18);
            AddItem(CreateWovenCap(), 0.18);
            AddItem(CreateDagger(), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Sacred Water from Mt. Ramelau", 1266), 0.22);
            AddItem(CreateColoredItem<ObsidianSkull>("Obsidian of Atauro", 1109), 0.11);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Sandalwood Princess"), 0.15);
            AddItem(new Gold(Utility.Random(2000, 3500)), 0.15);
            AddItem(CreateBookOfLore(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateTaisCloth()
        {
            BodySash tais = new BodySash();
            tais.Name = "Handwoven Tais of Lospalos";
            tais.Hue = 2101; // Bright, festive color
            tais.Attributes.Luck = 20;
            tais.SkillBonuses.SetValues(0, SkillName.Tailoring, 15.0);
            return tais;
        }

        private Item CreateSacredSandalwood()
        {
            DecoFlower sandalwood = new DecoFlower();
            sandalwood.Name = "Sacred Sandalwood Branch";
            sandalwood.Hue = 2209;
            return sandalwood;
        }

        private Item CreateCoffeeBasket()
        {
            Basket1Artifact coffee = new Basket1Artifact();
            coffee.Name = "Basket of Maubisse Coffee Beans";
            coffee.Hue = 1275;
            return coffee;
        }

        private Item CreateTimoreseStatue()
        {
            ManStatuetteSouthArtifact statue = new ManStatuetteSouthArtifact();
            statue.Name = "Statue of a Timorese Warrior";
            statue.Hue = 1175;
            return statue;
        }

        private Item CreateAncientSpiritMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Ancient Spirit Mask of the Fataluku";
            mask.Hue = 1801;
            mask.Attributes.BonusHits = 8;
            mask.Attributes.BonusStam = 8;
            mask.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
            mask.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            return mask;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateWeapon()
        {
            // Katana as the "Surik" (Timorese sword)
            Katana weapon = new Katana();
            weapon.Name = "Surik of Independence";
            weapon.Hue = 2053;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.HitLeechHits = 12;
            weapon.Attributes.WeaponDamage = 38;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.DefendChance = 12;
            weapon.Attributes.Luck = 18;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of Ramelau";
            armor.Hue = 1157;
            armor.BaseArmorRating = 48;
            armor.ArmorAttributes.SelfRepair = 6;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.BonusStam = 15;
            armor.Attributes.NightSight = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateFightingSarong()
        {
            Skirt sarong = new Skirt();
            sarong.Name = "Fighting Sarong of Dili";
            sarong.Hue = 2077;
            sarong.Attributes.Luck = 30;
            sarong.Attributes.BonusDex = 8;
            sarong.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            sarong.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(sarong, new XmlLevelItem());
            return sarong;
        }

        private Item CreateWovenCap()
        {
            SkullCap cap = new SkullCap();
            cap.Name = "Woven Cap of Baucau";
            cap.Hue = 1886;
            cap.Attributes.BonusMana = 10;
            cap.Attributes.NightSight = 1;
            cap.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Lulik Shrine";
            dagger.Hue = 1195;
            dagger.MinDamage = Utility.Random(18, 27);
            dagger.MaxDamage = Utility.Random(37, 55);
            dagger.Attributes.BonusHits = 8;
            dagger.Attributes.ReflectPhysical = 7;
            dagger.WeaponAttributes.HitLightning = 12;
            dagger.WeaponAttributes.SelfRepair = 4;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateBookOfLore()
        {
            return new ChroniclesOfTimorLeste();
        }

        public TreasureChestOfTimorLeste(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTimorLeste : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Timor-Leste", "The Voice of Maubere",
            new BookPageInfo
            (
                "In the far southeast, where",
                "the mountains meet the sea,",
                "lies Timor-Leste, the island",
                "of resilience. From the",
                "ancient kingdom of Wehali,",
                "to the Lulik shrines, our",
                "ancestors carved tales into",
                "stone and memory."
            ),
            new BookPageInfo
            (
                "The sandalwood trade brought",
                "fortune and conflict. We stood",
                "through centuries of foreign",
                "flags. The spirit of the",
                "people—Maubere—refused to fade.",
                "Our tais bear the colors of",
                "our land, woven with hope."
            ),
            new BookPageInfo
            (
                "When the world forgot us,",
                "we remembered ourselves. The",
                "mountains gave shelter. The",
                "sea gave food. Sacred Ramelau",
                "watched our pain. Yet, through",
                "darkness, we sang for dawn.",
                "Freedom was our prayer."
            ),
            new BookPageInfo
            (
                "From the ashes of struggle,",
                "we rose. On May 20, 2002,",
                "the sun rose on independence.",
                "Our wounds are deep, but our",
                "joy is deeper. Our children",
                "dance beside the ancestors.",
                "Our future is our own."
            ),
            new BookPageInfo
            (
                "Take these treasures. Learn our",
                "story. We are Timor-Leste:",
                "born of mountains, shaped by",
                "ocean, crowned with courage.",
                "May our spirit guide you,",
                "wherever your journey leads.",
                "",
                "- The Voice of Maubere"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTimorLeste() : base(false)
        {
            Hue = 1175; // Gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Timor-Leste");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Timor-Leste");
        }

        public ChroniclesOfTimorLeste(Serial serial) : base(serial) { }

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
