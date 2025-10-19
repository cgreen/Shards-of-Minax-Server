using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfColombia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfColombia()
        {
            Name = "Treasure Chest of El Dorado";
            Hue = 2129; // Shimmering gold hue

            // Add themed loot
            AddItem(CreateEmerald(), 0.25);
            AddItem(CreateNamedItem<GoldBracelet>("Quimbaya Sun Disk Bracelet"), 0.15);
            AddItem(CreateNamedItem<SilverEarrings>("Muisca Nose Ring"), 0.12);
            AddItem(CreateDecorativeRelic(), 0.18);
            AddItem(CreateCoffee(), 0.30);
            AddItem(CreateCacao(), 0.20);
            AddItem(CreateNamedItem<Gold>("Royal Escudo Coin"), 0.16);
            AddItem(CreatePoncho(), 0.17);
            AddItem(CreateAndesBoots(), 0.17);
            AddItem(CreateCrown(), 0.13);
            AddItem(CreateBolivarSaber(), 0.20);
            AddItem(CreateArmorOfTheLiberator(), 0.17);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateMapToGuatavita(), 0.09);
            AddItem(CreateElDoradoPotion(), 0.10);
            AddItem(CreateRareBotanical(), 0.15);
            AddItem(CreateDecorativeStatue(), 0.13);
            AddItem(new Gold(Utility.Random(3000, 8000)), 0.19);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateEmerald()
        {
            Ruby emerald = new Ruby();
            emerald.Name = "Fabled Emerald of Muzo";
            emerald.Hue = 2108; // Emerald green
            return emerald;
        }

        private Item CreateCoffee()
        {
            RandomFancyPotion coffee = new RandomFancyPotion();
            coffee.Name = "Fine Colombian Coffee";
            coffee.Hue = 1951;
            return coffee;
        }

        private Item CreateCacao()
        {
            DarkChocolate cacao = new DarkChocolate();
            cacao.Name = "Pure Cacao of Tumaco";
            cacao.Hue = 1195;
            return cacao;
        }

        private Item CreateElDoradoPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Brew of Guatavita";
            potion.Hue = 2212; // Deep blue (lake color)
            return potion;
        }

        private Item CreateDecorativeRelic()
        {
            ArtifactLargeVase relic = new ArtifactLargeVase();
            relic.Name = "Quimbaya Gold Offering";
            relic.Hue = 2129;
            return relic;
        }

        private Item CreateDecorativeStatue()
        {
            Sculpture1Artifact statue = new Sculpture1Artifact();
            statue.Name = "Jaguar Guardian Statue";
            statue.Hue = 1175;
            return statue;
        }

        private Item CreateRareBotanical()
        {
            DecorativePlant plant = new DecorativePlant();
            plant.Name = "Mutis’ Rare Orchid";
            plant.Hue = 1417;
            return plant;
        }

        private Item CreatePoncho()
        {
            Cloak poncho = new Cloak();
            poncho.Name = "Poncho of the Andes";
            poncho.Hue = Utility.RandomMinMax(1357, 1397); // Colorful
            poncho.Attributes.Luck = 60;
            poncho.Attributes.BonusStam = 8;
            poncho.SkillBonuses.SetValues(0, SkillName.Herding, 15.0);
            poncho.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(poncho, new XmlLevelItem());
            return poncho;
        }

        private Item CreateAndesBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the High Andes";
            boots.Hue = Utility.RandomMinMax(1281, 1285);
            boots.Attributes.BonusHits = 12;
            boots.Attributes.BonusDex = 10;
            boots.SkillBonuses.SetValues(0, SkillName.MagicResist, 8.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tracking, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Emerald Crown of Bogotá";
            crown.Hue = 2108;
            crown.Attributes.BonusMana = 10;
            crown.Attributes.SpellDamage = 10;
            crown.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 10.0);
            crown.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateBolivarSaber()
        {
            Katana saber = new Katana();
            saber.Name = "Bolívar’s Liberator Saber";
            saber.Hue = 2129;
            saber.WeaponAttributes.HitLightning = 30;
            saber.Attributes.AttackChance = 15;
            saber.Attributes.WeaponSpeed = 18;
            saber.Attributes.BonusStr = 10;
            saber.Slayer = SlayerName.DragonSlaying;
            saber.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            saber.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        private Item CreateArmorOfTheLiberator()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Libertador";
            armor.Hue = 2219;
            armor.BaseArmorRating = Utility.Random(50, 80);
            armor.Attributes.BonusHits = 18;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.DefendChance = 14;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMapToGuatavita()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Lake Guatavita";
            map.Bounds = new Rectangle2D(2500, 1800, 400, 400);
            map.NewPin = new Point2D(2650, 1950);
            map.Protected = true;
            return map;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfElDorado();
        }

        public TreasureChestOfColombia(Serial serial) : base(serial)
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

    // Themed Lore Book
    public class ChroniclesOfElDorado : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of El Dorado", "Juan de Castellanos",
            new BookPageInfo
            (
                "In the shadow of the Andes,",
                "the land breathes gold and emeralds.",
                "From the high Muisca plains,",
                "echo the legends of El Dorado,",
                "where the Zipa would bathe in gold,",
                "and gods walked among men."
            ),
            new BookPageInfo
            (
                "Rivers twist through emerald jungles.",
                "Ancient Tayrona built their terraces,",
                "and the Quimbaya shaped sun and spirit",
                "into golden artifacts, gifts for gods.",
                "Conquistadors came in fire and steel,",
                "seeking a city made of dreams."
            ),
            new BookPageInfo
            (
                "The people hid their treasures,",
                "but never their stories.",
                "The Lake Guatavita gleamed,",
                "a mirror for the sun and secrets.",
                "Those who entered sought fortune,",
                "but found only the silence of depths."
            ),
            new BookPageInfo
            (
                "Centuries turned. The mountains",
                "sang with the thunder of revolution.",
                "Bolívar rode beneath new banners.",
                "Liberty kindled in the valleys,",
                "from Bogotá to Cartagena.",
                "The chains of empire, broken."
            ),
            new BookPageInfo
            (
                "In coffee groves and misty cloud forests,",
                "new riches bloomed—emerald and bean,",
                "the heartbeat of a land untamed.",
                "From the Magdalena to the Orinoco,",
                "the spirit of Colombia endures:",
                "diverse, unbroken, ever bright."
            ),
            new BookPageInfo
            (
                "Now, the legends wait in shadowed chests.",
                "Gold for the bold. Lore for the wise.",
                "The journey calls, as it once did,",
                "to all who seek the treasures and truths",
                "of El Dorado. May fortune guide",
                "your footsteps through history."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfElDorado() : base(false)
        {
            Hue = 2129; // Golden
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of El Dorado");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of El Dorado");
        }

        public ChroniclesOfElDorado(Serial serial) : base(serial) { }

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
