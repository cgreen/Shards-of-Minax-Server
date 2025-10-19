using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Gust Barrier Talent Scroll
    // This scroll, when socketed, grants the bearer a gust barrier effect on weapon hit
    // that temporarily boosts virtual armor for nearby allied creatures.
    // ---------------------------------------------------

    public class GustBarrierTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public GustBarrierTalentScroll() : base(0x1F4E) // Replace with appropriate item ID for your scroll
        {
            Name = "Gust Barrier Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public GustBarrierTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a gust barrier effect on hit, boosting virtual armor of nearby allies temporarily.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Gust Barrier effect with example parameters:
                // virtualArmorBoost = 20, duration = 1 minute, refractory = 180 seconds (3 minutes)
                XmlAttach.AttachTo(target, new XmlGustBarrier(20, 1.0, 180.0));
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
