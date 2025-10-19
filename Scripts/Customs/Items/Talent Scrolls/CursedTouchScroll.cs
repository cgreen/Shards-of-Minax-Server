using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Cursed Touch Scroll
    // This Scroll, when socketed, grants the bearer a cursed touch effect on weapon hit
    // ---------------------------------------------------

    public class CursedTouchScroll : BaseSocketAugmentation
    {
        [Constructable]
        public CursedTouchScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Cursed Touch Talent Scroll";
            Hue = 1172; // Unique hue for this scroll (adjust as desired)
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public CursedTouchScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a cursed touch effect on hit, increasing damage taken by the target for a duration.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Cursed Touch effect with example parameters:
                // damage increase 1.2 (20% more damage), duration 10 seconds
                XmlAttach.AttachTo(target, new XmlCursedTouch(1.2, 10.0));
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
