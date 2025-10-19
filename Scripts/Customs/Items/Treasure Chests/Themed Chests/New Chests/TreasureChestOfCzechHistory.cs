using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCzechHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCzechHistory()
        {
            Name = "Treasure Chest of Czech History";
            Hue = 1153; // Royal blue

            // Add items to the chest
            AddItem(CreateNamedDeco<ArtifactVase>("Hussite Chalice of Prague", 1266), 0.12);
            AddItem(CreateNamedDeco<CrystalBallStatuette>("Crystal of Karel IV", 2125), 0.10);
            AddItem(CreateNamedDeco<WolfStatue>("Bohemian Wolf Guardian", 1107), 0.10);
            AddItem(CreateNamedDeco<OrigamiDragon>("Paper Dragon of Vyšehrad", 86), 0.10);
            AddItem(CreateNamedDeco<GoldBricks>("Golden Bricks of Charles Bridge", 1365), 0.10);
            AddItem(CreateNamedDeco<TarotCardsArtifact>("Prophetic Cards of Jan Hus", 1980), 0.11);

            AddItem(CreateUniquePotion("Alchemist’s Brew of Rudolf II", 1193), 0.16);
            AddItem(CreateUniqueFood("Svatovaclavska Koruna Honey Cake"), 0.14);

            AddItem(CreateNamedItem<ElvenShirt>("Robe of the Velvet Revolution"), 0.20);
            AddItem(CreateNamedItem<WideBrimHat>("Crown of Saint Wenceslas"), 0.10);
            AddItem(CreateNamedItem<Cloak>("Cloak of Jan Žižka"), 0.13);

            AddItem(CreatePowerfulWeapon(), 0.20);
            AddItem(CreatePowerfulArmor(), 0.20);
            AddItem(CreateArtifactShield(), 0.12);

            AddItem(new ChroniclesOfCzechLands(), 1.0); // Custom lore book, see below

            AddItem(new Gold(Utility.Random(2500, 3000)), 0.20);
            AddItem(CreateUniqueMap(), 0.06);
            AddItem(CreateUniqueNote(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedDeco<T>(string name, int hue = 0) where T : Item, new()
        {
            T deco = new T();
            deco.Name = name;
            if (hue != 0)
                deco.Hue = hue;
            return deco;
        }

        private Item CreateUniquePotion(string name, int hue)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            return potion;
        }

        private Item CreateUniqueFood(string name)
        {
            Cake cake = new Cake();
            cake.Name = name;
            cake.Hue = 1237; // honey gold
            return cake;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = Utility.RandomList(1153, 1237, 1161, 1266, 1980); // Blues, gold, red, purple, etc.
            return item;
        }

        private Item CreatePowerfulWeapon()
        {
            // Hussite Warhammer, high mods, skill bonuses
            WarHammer weapon = new WarHammer();
            weapon.Name = "Hussite Warhammer";
            weapon.Hue = 1161;
            weapon.MinDamage = 40;
            weapon.MaxDamage = 75;
            weapon.Attributes.BonusStam = 20;
            weapon.Attributes.WeaponSpeed = 40;
            weapon.Attributes.WeaponDamage = 50;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitPhysicalArea = 10;
            weapon.WeaponAttributes.HitDispel = 8;
            weapon.SkillBonuses.SetValues(0, SkillName.Macing, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreatePowerfulArmor()
        {
            // PlateChest: "Armor of Přemyslid Kings"
            PlateChest chest = new PlateChest();
            chest.Name = "Armor of the Přemyslid Kings";
            chest.Hue = 1266;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.RegenHits = 3;
            chest.ArmorAttributes.SelfRepair = 5;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            chest.PhysicalBonus = 15;
            chest.FireBonus = 10;
            chest.ColdBonus = 10;
            chest.PoisonBonus = 5;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateArtifactShield()
        {
            // DecorativeShield: "Shield of Blaník Knights"
            ChaosShield shield = new ChaosShield();
            shield.Name = "Shield of the Blaník Knights";
            shield.Hue = 1153;
            shield.Attributes.DefendChance = 15;
            shield.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            return shield;
        }

        private Item CreateUniqueMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Secret Map of Bohemia";
            map.Bounds = new Rectangle2D(1440, 1450, 400, 400);
            map.NewPin = new Point2D(1647, 1702);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueNote()
        {
            SimpleNote note = new SimpleNote();
            note.NoteString = "Whoever holds this chest, know the stones of Prague remember every age: from Přemyslid, through Hus and Charles, to Velvet freedom. Seek wisdom at Vyšehrad, and beware the alchemists’ riddles!";
            note.TitleString = "Message from the Golem’s Creator";
            return note;
        }

        public TreasureChestOfCzechHistory(Serial serial) : base(serial) { }

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

    public class ChroniclesOfCzechLands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Czech Lands", "Master Jan of Prague",
            new BookPageInfo
            (
                "From ancient Boiohaemum,",
                "forests and rivers called",
                "tribes to settle, ruled by",
                "legendary Princess Libuše,",
                "who foresaw the city of",
                "Prague: 'I see a city, whose",
                "glory will touch the stars.'",
                "Thus rose Bohemia."
            ),
            new BookPageInfo
            (
                "Knights and kings forged",
                "kingdoms: Přemyslids and",
                "Luxembourgs, with Charles IV,",
                "the Wise, crowning Prague",
                "in gold and stone, founding",
                "the Charles Bridge and",
                "Europe's oldest university."
            ),
            new BookPageInfo
            (
                "Faith and fire swept the",
                "land: Jan Hus, preacher and",
                "martyr, ignited hope and",
                "the Hussite wars. The",
                "defenestrations of Prague",
                "echoed through Europe.",
                "The Golem watched in silence."
            ),
            new BookPageInfo
            (
                "Alchemy flourished under",
                "Rudolf II, who gathered",
                "mystics, scholars, and",
                "dreamers to the castle. Gold",
                "sought, secrets hidden, and",
                "legends born beneath the",
                "city’s winding stones."
            ),
            new BookPageInfo
            (
                "Centuries turned, empires",
                "rose and fell. In 1918,",
                "Masaryk raised a flag of",
                "independence. Shadows fell",
                "again, but the Velvet",
                "Revolution brought peace,",
                "and the Czech lion roared",
                "free once more."
            ),
            new BookPageInfo
            (
                "Now the bridges and towers",
                "whisper: every age endures,",
                "and every heart remembers.",
                "Prague’s stones hold the",
                "stories of a thousand years,",
                "waiting for seekers of",
                "treasure, wisdom, and hope.",
                "",
                "- Finis -"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfCzechLands() : base(false)
        {
            Hue = 1153; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Czech Lands");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Czech Lands");
        }

        public ChroniclesOfCzechLands(Serial serial) : base(serial) { }

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
