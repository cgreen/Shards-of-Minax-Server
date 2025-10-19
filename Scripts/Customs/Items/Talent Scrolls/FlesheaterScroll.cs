using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Flesheater Talent Scroll
    // This Scroll, when socketed, grants the bearer the Flesheater bleed effect on weapon hit
    // ---------------------------------------------------

    public class FlesheaterScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FlesheaterScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Flesheater Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public FlesheaterScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a bleed effect on hit that damages enemies over time and restores health to the bearer.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Flesheater effect with example parameters:
                // cooldown 60 seconds, bleedDamage 40, duration 15 seconds, healthRestore 100
                XmlAttach.AttachTo(target, new XmlFlesheater(60.0, 40, 15, 100));
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
