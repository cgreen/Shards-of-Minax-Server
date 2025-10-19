using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Spike Circle Scroll
    // This Scroll, when socketed, grants the bearer a circular spike fire attack on weapon hit
    // ---------------------------------------------------

    public class SpikeCircleScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SpikeCircleScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Spike Circle Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 3; } } // Adjust sockets required as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SpikeCircleScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a circular spike fire attack on hit, dealing 20 damage in a radius of 5 with thickness 4 every 10 seconds.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Spike Circle effect with default parameters: refractory 10s, damage 20, radius 5, thickness 4
                XmlAttach.AttachTo(target, new XmlSpikeCircle(10.0, 20, 5, 4));
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
