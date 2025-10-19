using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Chill Touch Talent Scroll
    // This Scroll, when socketed, grants the bearer a Chill Touch effect on weapon hit
    // ---------------------------------------------------

    public class ChillTouchScroll : BaseSocketAugmentation
    {
        [Constructable]
        public ChillTouchScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Chill Touch Talent Scroll";
            Hue = 1154; // Unique hue for this scroll, adjust as desired
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public ChillTouchScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a chance to inflict Chill Touch on hit, dealing damage and slowing enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Chill Touch effect with example parameters:
                // 15% trigger chance, 20 damage, 15% attack speed reduction, 15 seconds duration
                XmlAttach.AttachTo(target, new XmlChillTouch(0.15, 20, 0.15, 15.0));
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
