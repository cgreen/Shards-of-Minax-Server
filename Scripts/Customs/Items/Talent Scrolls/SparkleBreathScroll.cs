using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Sparkle Breath Scroll
    // This Scroll, when socketed, grants the bearer a sparkle breath attack on weapon hit
    // ---------------------------------------------------

    public class SparkleBreathScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SparkleBreathScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Sparkle Breath Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 3; } } // Adjust based on how powerful you want it

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SparkleBreathScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a sparkle breath attack on hit, dealing 30 damage over 10 tiles every 1 second.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Sparkle Breath effect with default parameters: refractory 1 second, damage 30, range 10
                XmlAttach.AttachTo(target, new XmlSparkleBreath(1.0, 30, 10));
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
