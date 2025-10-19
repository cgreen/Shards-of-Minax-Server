using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Earthquake Talent Scroll
    // This Scroll, when socketed, grants the bearer an earthquake attack effect on weapon hit
    // ---------------------------------------------------

    public class EarthquakeTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public EarthquakeTalentScroll() : base(0x1F4E) // Replace with suitable scroll/item ID
        {
            Name = "Earthquake Talent Scroll";
            Hue = 1359; // Unique hue for this scroll, change as desired
        }

        public override int SocketsRequired { get { return 2; } } // Adjust based on power/cost

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public EarthquakeTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants an earthquake attack on hit, dealing damage and freezing nearby enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Earthquake effect with default parameters
                XmlAttach.AttachTo(target, new XmlEarthquake());
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
