using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBeninKingdom : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfBeninKingdom()
        {
            Name = "Treasure Chest of the Benin Kingdom";
            Hue = 2413; // Bronze-gold hue

            // Add themed loot
            AddItem(CreateBeninBronzePlaque(), 0.20);
            AddItem(CreateRoyalMask(), 0.17);
            AddItem(CreateObaBlessingPotion(), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Royal Guild"), 0.19);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Ivory Guild"), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Iyoba"), 0.10);
            AddItem(CreateNamedItem<GreaterCurePotion>("Herbal Draught of Ugie"), 0.13);
            AddItem(CreateNamedItem<Bottle>("Oil of Sacred Groves"), 0.10);
            AddItem(CreateBeninSculpture(), 0.11);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateRobe(), 0.13);
            AddItem(CreateLeatherCap(), 0.11);
            AddItem(CreateBeninDagger(), 0.15);
            AddItem(CreateRoyalBrocade(), 0.15);
            AddItem(new ChroniclesOfBeninKingdom(), 1.0); // Always include lore book
            AddItem(new Gold(Utility.Random(1000, 7000)), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateBeninBronzePlaque()
        {
            ArtifactVase bronzePlaque = new ArtifactVase();
            bronzePlaque.Name = "Benin Bronze Plaque";
            bronzePlaque.Hue = 2413;
            return bronzePlaque;
        }

        private Item CreateRoyalMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Ivory Mask of Queen Idia";
            mask.Hue = 1175; // Ivory shade
            mask.Attributes.BonusInt = 8;
            mask.Attributes.BonusMana = 15;
            mask.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateObaBlessingPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Oba’s Blessing Elixir";
            potion.Hue = 2207; // Deep gold
            XmlAttach.AttachTo(potion, new XmlLevelItem());
            return potion;
        }

        private Item CreateBeninSculpture()
        {
            Sculpture1Artifact sculpture = new Sculpture1Artifact();
            sculpture.Name = "Royal Oba Statuette";
            sculpture.Hue = 2413;
            return sculpture;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Broadsword(), new Spear(), new MagicWand()
            );
            weapon.Name = "Sword of the Leopard Guard";
            weapon.Hue = 2130; // Earthy, mystical
            weapon.WeaponAttributes.HitLightning = 30;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.WeaponDamage = 20;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusHits = 20;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            weapon.Slayer = SlayerName.ReptilianDeath;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm()
            );
            armor.Name = "Armor of the Bronze Warrior";
            armor.Hue = 2413;
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.Attributes.Luck = 40;
            armor.Attributes.BonusStr = 8;
            armor.Attributes.BonusHits = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Court Sorcerer";
            robe.Hue = 1164; // Deep maroon
            robe.Attributes.BonusMana = 25;
            robe.Attributes.BonusInt = 8;
            robe.Attributes.SpellDamage = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLeatherCap()
        {
            LeatherCap cap = new LeatherCap();
            cap.Name = "Cap of the Leopard Hunter";
            cap.Hue = 2115;
            cap.BaseArmorRating = Utility.Random(22, 45);
            cap.ArmorAttributes.SelfRepair = 3;
            cap.Attributes.BonusDex = 18;
            cap.Attributes.NightSight = 1;
            cap.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            cap.SkillBonuses.SetValues(1, SkillName.Archery, 8.0);
            cap.PoisonBonus = 8;
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateBeninDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Mystic Guild";
            dagger.Hue = 1165;
            dagger.MinDamage = 22;
            dagger.MaxDamage = 66;
            dagger.WeaponAttributes.HitMagicArrow = 18;
            dagger.WeaponAttributes.HitLowerAttack = 12;
            dagger.Attributes.BonusMana = 10;
            dagger.Attributes.CastSpeed = 2;
            dagger.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Poisoning, 12.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateRoyalBrocade()
        {
            Doublet brocade = new Doublet();
            brocade.Name = "Royal Brocade of the Benin Court";
            brocade.Hue = 2213; // Vibrant cloth
            brocade.Attributes.Luck = 30;
            brocade.Attributes.BonusHits = 8;
            brocade.SkillBonuses.SetValues(0, SkillName.Tailoring, 10.0);
            XmlAttach.AttachTo(brocade, new XmlLevelItem());
            return brocade;
        }

        public TreasureChestOfBeninKingdom(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBeninKingdom : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Benin", "Oba Ewuare",
            new BookPageInfo
            (
                "In the heart of the rainforest,",
                "the city of Edo rose in splendor.",
                "Walls as high as the trees, streets",
                "planned like veins, all beneath",
                "the gaze of the Oba, chosen by",
                "the spirits and ancestors.",
                "",
                "From bronze and ivory we shaped",
                "our legacy."
            ),
            new BookPageInfo
            (
                "Let it be known:",
                "The Leopard Guards stand watch.",
                "The bronze casters summon spirits.",
                "The Iyoba, Queen Mother, sits in",
                "council, her wisdom sought by all.",
                "",
                "Benin’s bronze plaques and",
                "regalia shine as bright as the sun."
            ),
            new BookPageInfo
            (
                "We are a people of artistry,",
                "of trade, of ceremony. Our",
                "festivals echo with drumming.",
                "Coral beads encircle the necks",
                "of kings, while the guilds shape",
                "the will of the realm.",
                "",
                "Ivory, brass, magic—woven together."
            ),
            new BookPageInfo
            (
                "Beware, traveler, for magic lingers",
                "in the blood-red earth. The Groves",
                "are sacred, the spirits restless. Speak",
                "to the ancestors with respect, and",
                "they may grant their blessing… or",
                "curse.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "If you hold this book, you have",
                "opened the chest of the Oba.",
                "Remember: true riches are not",
                "measured in gold or bronze,",
                "but in the memory of kings, the",
                "craft of guilds, and the spirits",
                "who watch all.",
                "",
                "May Benin’s glory guide you."
            ),
            new BookPageInfo
            (
                "Edo shall endure.",
                "",
                "- Oba Ewuare,",
                "Lord of all Benin."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBeninKingdom() : base(false)
        {
            Hue = 2413; // Bronze-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Benin");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Benin");
        }

        public ChroniclesOfBeninKingdom(Serial serial) : base(serial) { }

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
