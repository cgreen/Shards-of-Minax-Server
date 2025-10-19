using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Devour Scroll
    // This Scroll, when socketed, grants the bearer the ability to consume nearby corpses to heal.
    // ---------------------------------------------------

    public class DevourScroll : BaseSocketAugmentation
    {
        [Constructable]
        public DevourScroll() : base(0x1F4E) // Use an appropriate scroll/item ID
        {
            Name = "Devour Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } }

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public DevourScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the ability to consume nearby corpses to heal a portion of your max health.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Devour effect with example parameters: 15% heal, 1 minute cooldown
                XmlAttach.AttachTo(target, new XmlDevour(15.0, 1.0));
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
