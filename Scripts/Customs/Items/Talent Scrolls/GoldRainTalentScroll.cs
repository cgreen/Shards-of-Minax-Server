using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Gold Rain Talent Scroll
    // This Scroll, when socketed, grants the bearer the Gold Rain effect on weapon hit
    // ---------------------------------------------------

    public class GoldRainTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public GoldRainTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Gold Rain Talent Scroll";
            Hue = 1154; // Unique hue for this scroll, change as you see fit
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public GoldRainTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return $"Grants a gold rain effect on hit, causing gold to fall every 5 seconds by default.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Gold Rain effect with example refractory time: 5 seconds
                XmlAttach.AttachTo(target, new XmlGoldRain(5.0));
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
