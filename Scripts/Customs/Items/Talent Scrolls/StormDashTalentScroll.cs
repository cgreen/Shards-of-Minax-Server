using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Storm Dash Talent Scroll
    // This Scroll, when socketed, grants the bearer a storm dash effect on weapon hit
    // ---------------------------------------------------

    public class StormDashTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public StormDashTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Storm Dash Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public StormDashTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a storm dash effect on hit, dealing damage and stunning the target.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Storm Dash effect with example parameters:
                // minDamage=20, maxDamage=30, freezeDuration=1 second, refractory=20 seconds
                XmlAttach.AttachTo(target, new XmlStormDash(20, 30, 1.0, 20.0));
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
