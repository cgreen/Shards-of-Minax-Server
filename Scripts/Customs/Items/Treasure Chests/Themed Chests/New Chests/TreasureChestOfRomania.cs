using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfRomania : WoodenChest
    {
        [Constructable]
        public TreasureChestOfRomania()
        {
            Name = "Treasure Chest of Romania";
            Hue = 1161; // Dark red to evoke Romania's flag and blood/legend

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Dacian Wolf Vase", 1154), 0.20);
            AddItem(CreateDecorativeItem<MedusaStatue>("Statue of Decebalus", 1172), 0.10);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Wallachian Sword Display", 1175), 0.13);
            AddItem(CreateDecorativeItem<AncientDrum>("Carpathian Ritual Drum", 2101), 0.12);
            AddItem(CreateDecorativeItem<AncientWeapon2>("Roman Gladius Relic", 242), 0.09);
            AddItem(CreateDecorativeItem<RandomFancyStatue>("Vampire Bat Idol", 1175), 0.11); // You can use any statue you like
            AddItem(CreateDecorativeItem<GargishPortraitArtifact>("Portrait of Vlad the Impaler", 1166), 0.13);
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Danube Treasure Ship Model", 1165), 0.10);

            // Unique consumables and gems
            AddItem(CreateConsumableItem<GreaterHealPotion>("Transylvanian Red Wine", 1157), 0.20);
            AddItem(CreateConsumableItem<GreaterHealPotion>("Dracula's Nightshade Elixir", 1153), 0.13);
            AddItem(CreateConsumableItem<GreaterHealPotion>("Crown of Dacia Brew", 1174), 0.15);
            AddItem(CreateGem("Blood Ruby of Wallachia", 1157), 0.08);

            // Themed gear
            AddItem(CreateUniqueWeapon(), 0.18);
            AddItem(CreateUniqueArmor(), 0.17);
            AddItem(CreateCloak(), 0.16);
            AddItem(CreateUniquePants(), 0.13);
            AddItem(CreateUniqueHat(), 0.15);

            // Consumables and currency
            AddItem(CreateRomanianGold(), 0.19);
            AddItem(CreateConsumableItem<GreaterHealPotion>("Vial of Carpathian Mist", 1170), 0.11);

            // Lore Book
            AddItem(new ChroniclesOfRomania(), 1.0);

            // Treasure Map to Bran Castle
            AddItem(CreateBranCastleMap(), 0.09);

            // Gold
            AddItem(new Gold(Utility.Random(1500, 8000)), 0.14);
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

        private Item CreateGem(string name, int hue)
        {
            Ruby gem = new Ruby();
            gem.Name = name;
            gem.Hue = hue;
            return gem;
        }

        private Item CreateRomanianGold()
        {
            Gold gold = new Gold();
            gold.Name = "Dacian Gold Coins";
            return gold;
        }

        private Item CreateBranCastleMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Bran Castle";
            map.Bounds = new Rectangle2D(1520, 2540, 350, 350);
            map.NewPin = new Point2D(1600, 2600);
            map.Protected = true;
            return map;
        }

        // Unique Equipment Examples

        private Item CreateUniqueWeapon()
        {
            Longsword sword = new Longsword();
            sword.Name = "Vlad's Blade of the Night";
            sword.Hue = 1153; // Blood red
            sword.MaxDamage = Utility.Random(50, 90);
            sword.MinDamage = Utility.Random(30, 50);
            sword.Attributes.WeaponDamage = 45;
            sword.Attributes.BonusStr = 15;
            sword.WeaponAttributes.HitLowerAttack = 30;
            sword.WeaponAttributes.HitPoisonArea = 20;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.CastSpeed = 1;
            sword.Attributes.Luck = 100;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Dacian Wolf Plate";
            armor.Hue = 1109; // Steel blue
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.BonusHits = 30;
            armor.Attributes.DefendChance = 15;
            armor.Attributes.RegenHits = 8;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ColdBonus = 15;
            armor.FireBonus = 15;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Transylvanian Cloak";
            cloak.Hue = 1175; // Deep dark color
            cloak.Attributes.Luck = 75;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusMana = 15;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateUniquePants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Breeches of the Carpathians";
            pants.Hue = 1102;
            pants.Attributes.BonusDex = 10;
            pants.Attributes.BonusStam = 8;
            pants.Attributes.Luck = 30;
            pants.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Anatomy, 5.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateUniqueHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Boyar's Feathered Hat";
            hat.Hue = 1146;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.BonusMana = 7;
            hat.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        public TreasureChestOfRomania(Serial serial) : base(serial)
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

    public class ChroniclesOfRomania : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Romania", "Nicolae the Chronicler",
            new BookPageInfo
            (
                "From the mists of Dacia,",
                "where the wolf's cry echoes,",
                "to the Roman legions carving",
                "roads through ancient forest,",
                "my homeland endures.",
                "Empires rise and fall; the",
                "Carpathians watch in silence."
            ),
            new BookPageInfo
            (
                "Here Decebalus defied Rome,",
                "and Trajan forged bridges over",
                "the Danube. Blood and gold,",
                "faith and fire. Saxon towns,",
                "gypsy camps, Byzantium's shadow.",
                "Our roots are deep and tangled."
            ),
            new BookPageInfo
            (
                "Wallachia and Moldavia,",
                "Transylvania ringed by hills.",
                "Here reigned Vlad Tepes,",
                "called Dracula: defender,",
                "tyrant, and legend.",
                "Turkish drums at the gates,",
                "castles lit by moonlight."
            ),
            new BookPageInfo
            (
                "Under Ottoman yoke,",
                "we plotted freedom.",
                "Mountains gave shelter.",
                "Peasants grew wheat,",
                "priests whispered in Latin.",
                "Wolves and men alike",
                "roamed the haunted woods."
            ),
            new BookPageInfo
            (
                "Bran Castle stands as silent",
                "sentinel. The Danube flows,",
                "bringing stories and storms.",
                "In shadow, vampires prowl.",
                "In the light, scholars write.",
                "A tapestry woven of sorrow,",
                "glory, and hope."
            ),
            new BookPageInfo
            (
                "Now, our banners rise anew.",
                "Romania, united and proud.",
                "Let these chronicles remind",
                "the finder: history is never",
                "truly past. It walks beside us,",
                "in the mountains and the mists.",
                "",
                "- Nicolae the Chronicler"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfRomania() : base(false)
        {
            Hue = 1161; // Deep red for Romania
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Romania");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Romania");
        }

        public ChroniclesOfRomania(Serial serial) : base(serial) { }

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
