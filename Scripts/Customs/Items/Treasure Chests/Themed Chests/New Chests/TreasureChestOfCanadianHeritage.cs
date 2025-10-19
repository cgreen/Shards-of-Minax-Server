using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCanadianHeritage : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCanadianHeritage()
        {
            Name = "Treasure Chest of Canadian Heritage";
            Hue = 33; // A red hue reminiscent of the Canadian flag

            // Add items to the chest
            AddItem(CreateDecor("Maple Leaf Statuette", typeof(FlowersArtifact), 33), 0.25);
            AddItem(CreateDecor("Northern Lights Lamp", typeof(LightOfTheWinterSolstice), 1175), 0.17);
            AddItem(CreateDecor("Totem Pole Replica", typeof(StatueSouth), 2406), 0.20);
            AddItem(CreateDecor("Miniature Canoe Model", typeof(AncientShipModelOfTheHMSCape)), 0.15);
            AddItem(CreateDecor("Beaver Plush", typeof(PolarBearZooStatuette), 2010), 0.15);
            AddItem(CreateConsumable("Bottle of Maple Syrup", typeof(GreenBottle), 1153), 0.14);
            AddItem(CreateConsumable("Poutine Bowl", typeof(WoodenBowlOfStew), 1886), 0.14);
            AddItem(CreateConsumable("Box of Timbits", typeof(Cookies), 2117), 0.12);
            AddItem(CreateEquipment(), 0.45); // Powerful unique equipment (armor, weapon, clothing)
            AddItem(CreateMountiesTunic(), 0.20);
            AddItem(CreateFurHat(), 0.18);
            AddItem(CreateSnowshoes(), 0.17);
            AddItem(CreateLumberjackAxe(), 0.17);
            AddItem(CreateLeatherCoat(), 0.18);
            AddItem(new ChroniclesOfTheNorth(), 1.0);
            AddItem(new Gold(Utility.Random(1, 4000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string name, Type type, int hue = 0)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            if (hue != 0) item.Hue = hue;
            return item;
        }

        private Item CreateConsumable(string name, Type type, int hue = 0)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            if (hue != 0) item.Hue = hue;
            // Add a simple heal/buff effect with XML attachments if you use XMLSpawner2
            return item;
        }

        // Unique Equipment (randomly selects one of several themed items)
        private Item CreateEquipment()
        {
            int pick = Utility.Random(5);
            switch (pick)
            {
                case 0: return CreateMountiesTunic();
                case 1: return CreateFurHat();
                case 2: return CreateSnowshoes();
                case 3: return CreateLumberjackAxe();
                case 4: return CreateLeatherCoat();
                default: return CreateMountiesTunic();
            }
        }

        private Item CreateMountiesTunic()
        {
            Tunic tunic = new Tunic();
            tunic.Name = "Mountie's Red Serge Tunic";
            tunic.Hue = 33; // Canadian red
            tunic.Attributes.Luck = 50;
            tunic.Attributes.BonusHits = 25;
            tunic.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 10.0);
            tunic.SkillBonuses.SetValues(1, SkillName.Tracking, 15.0);
            tunic.Attributes.BonusStr = 5;
            tunic.Attributes.NightSight = 1;
            XmlAttach.AttachTo(tunic, new XmlLevelItem());
            return tunic;
        }

        private Item CreateFurHat()
        {
            BearMask hat = new BearMask();
            hat.Name = "Hudson Bay Fur Hat";
            hat.Hue = 2105;
            hat.Attributes.BonusInt = 5;
            hat.Attributes.LowerManaCost = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Camping, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Hiding, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateSnowshoes()
        {
            FurBoots boots = new FurBoots();
            boots.Name = "Explorer's Snowshoes";
            boots.Hue = 1153;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.RegenStam = 2;
            boots.SkillBonuses.SetValues(0, SkillName.Herding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tracking, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateLumberjackAxe()
        {
            DoubleAxe axe = new DoubleAxe();
            axe.Name = "Lumberjack's Axe of the North";
            axe.Hue = 1936; // Deep maple wood color
            axe.WeaponAttributes.HitFireball = 30;
            axe.WeaponAttributes.UseBestSkill = 1;
            axe.MinDamage = 30;
            axe.MaxDamage = 80;
            axe.Attributes.BonusStr = 15;
            axe.Attributes.AttackChance = 12;
            axe.SkillBonuses.SetValues(0, SkillName.Lumberjacking, 20.0);
            axe.Attributes.Luck = 30;
            axe.WeaponAttributes.SelfRepair = 6;
            XmlAttach.AttachTo(axe, new XmlLevelItem());
            return axe;
        }

        private Item CreateLeatherCoat()
        {
            LeatherDo coat = new LeatherDo();
            coat.Name = "Trapper's Leather Coat";
            coat.Hue = 2412;
            coat.Attributes.BonusHits = 20;
            coat.Attributes.BonusDex = 8;
            coat.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            coat.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            coat.PoisonBonus = 8;
            coat.ColdBonus = 20;
            coat.PhysicalBonus = 10;
            XmlAttach.AttachTo(coat, new XmlLevelItem());
            return coat;
        }

        public TreasureChestOfCanadianHeritage(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheNorth : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the North: A History of Canada", "Laurent LaPierre",
            new BookPageInfo
            (
                "From the time before",
                "the first footsteps on snow,",
                "the land we now call Canada",
                "was home to many nations.",
                "The First Peoples thrived",
                "on rivers, in forests,",
                "across prairies, by the sea."
            ),
            new BookPageInfo
            (
                "Then came the explorers,",
                "the Norse, the French,",
                "and the English, crossing",
                "icy seas, seeking furs,",
                "fish, and fortunes. They",
                "mapped the wild, built",
                "forts, and traded stories."
            ),
            new BookPageInfo
            (
                "The land grew, stitched",
                "by rail and hope. Confederation",
                "in 1867 bound colonies",
                "together, from sea to sea.",
                "The Maple Leaf rose, a",
                "symbol of peace, of unity,",
                "of endurance through cold."
            ),
            new BookPageInfo
            (
                "Great forests yielded timber,",
                "fields bore wheat, mines",
                "gave gold. Newcomers arrived",
                "from every land, and",
                "in the world’s wars,",
                "Canadians stood tall,",
                "at Vimy Ridge, Juno Beach."
            ),
            new BookPageInfo
            (
                "From Inuit to Acadian,",
                "Cree to Québécois, Coast",
                "Salish to Nova Scotian,",
                "the North embraces all.",
                "Our winters are long, but",
                "our hearts, warm. Our",
                "spirit, unbroken."
            ),
            new BookPageInfo
            (
                "Today, in city and",
                "village, mountain and tundra,",
                "Canada stands a tapestry,",
                "woven with many threads.",
                "The story is still",
                "being written—by you.",
                "",
                "- O Canada"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheNorth() : base(false)
        {
            Hue = 33; // Canadian red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the North: A History of Canada");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the North: A History of Canada");
        }

        public ChroniclesOfTheNorth(Serial serial) : base(serial) { }

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
