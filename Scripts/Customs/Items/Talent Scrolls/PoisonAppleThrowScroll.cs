using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Poison Apple Throw Scroll
    // This Scroll, when socketed, grants the bearer a poison apple throw effect on weapon hit
    // ---------------------------------------------------

    public class PoisonAppleThrowScroll : BaseSocketAugmentation
    {
        [Constructable]
        public PoisonAppleThrowScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Poison Apple Throw Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public PoisonAppleThrowScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a poison apple throw effect on hit, damaging nearby enemies with poison and area effect.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Poison Apple Throw effect with example parameters: refractory 10 sec, damage 20, range 8
                XmlAttach.AttachTo(target, new XmlPoisonAppleThrow(10.0, 20, 8));
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
