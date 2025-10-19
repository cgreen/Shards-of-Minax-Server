using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Skull Circle Scroll
    // This Scroll, when socketed, grants the bearer a circular fire attack on weapon hit
    // ---------------------------------------------------

    public class SkullCircleScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SkullCircleScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Skull Circle Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 3; } } // Adjust sockets as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SkullCircleScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a circular fire attack dealing 20 damage over a 5 tile radius with 4 tile thickness every 10 seconds.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Skull Circle effect with default parameters: refractory 10 seconds, damage 20, radius 5, thickness 4
                XmlAttach.AttachTo(target, new XmlSkullCircle(10.0, 20, 5, 4));
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
