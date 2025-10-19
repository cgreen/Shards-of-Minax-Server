using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Trap Circle Scroll
    // This Scroll, when socketed, grants the bearer a circular fire trap effect on weapon hit
    // ---------------------------------------------------

    public class TrapCircleScroll : BaseSocketAugmentation
    {
        [Constructable]
        public TrapCircleScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Trap Circle Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 3; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public TrapCircleScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a circular fire trap effect on hit, dealing area damage around the bearer.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Trap Circle effect with example parameters:
                // refractory = 10 seconds, damage = 20, radius = 5, thickness = 4
                XmlAttach.AttachTo(target, new XmlTrapCircle(10.0, 20, 5, 4));
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
