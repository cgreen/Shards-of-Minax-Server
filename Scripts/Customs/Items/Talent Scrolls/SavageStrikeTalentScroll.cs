using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Savage Strike Scroll
    // This Scroll, when socketed, grants the bearer a savage strike effect on weapon hit
    // ---------------------------------------------------

    public class SavageStrikeTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SavageStrikeTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Savage Strike Talent Scroll";
            Hue = 1360; // Unique hue for this scroll (choose as you like)
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SavageStrikeTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a savage strike effect on hit, dealing damage and causing bleeding.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Savage Strike effect with default parameters
                XmlAttach.AttachTo(target, new XmlSavageStrike());
                return true;
            }
            return false;
        }

        public override bool CanAugment(Mobile from, object target)
        {
            return target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature;
        }

        public override bool CanRecover(Mobile from, object target, int version)
        {
            return target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
