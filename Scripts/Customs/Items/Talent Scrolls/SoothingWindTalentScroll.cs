using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Soothing Wind Talent Scroll
    // This Scroll, when socketed, grants the bearer a soothing wind effect on weapon hit
    // that temporarily increases speed of nearby allies.
    // ---------------------------------------------------

    public class SoothingWindTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SoothingWindTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Soothing Wind Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SoothingWindTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a soothing wind effect on hit, temporarily increasing speed of nearby allies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Soothing Wind effect with example parameters: speedIncrease 20, duration 30 sec, nextWindDelay 240 sec
                XmlAttach.AttachTo(target, new XmlSoothingWind(20, 30.0, 240.0));
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
