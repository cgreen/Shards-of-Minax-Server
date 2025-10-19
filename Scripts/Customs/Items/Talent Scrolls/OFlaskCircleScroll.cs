using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    // ---------------------------------------------------
    // OFlask Circle Scroll
    // Grants a circular fire effect on weapon hit
    // ---------------------------------------------------

    public class OFlaskCircleScroll : BaseSocketAugmentation
    {
        [Constructable]
        public OFlaskCircleScroll() : base(0x1F4E) // Use a scroll graphic or one you prefer
        {
            Name = "Circle of Fire Talent Scroll";
            Hue = 2075; // Custom hue for uniqueness
        }

        public override int SocketsRequired { get { return 2; } } // Adjust based on your balance
        public override int Icon { get { return 0x1F4E; } }
        public override int IconXOffset { get { return 8; } }
        public override int IconYOffset { get { return 20; } }

        public OFlaskCircleScroll(Serial serial) : base(serial) { }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a fiery circle attack on weapon hits, damaging all nearby enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Parameters: refractory time, damage, radius, thickness
                XmlAttach.AttachTo(target, new XmlOFlaskCircle(10.0, 20, 5, 4));
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
