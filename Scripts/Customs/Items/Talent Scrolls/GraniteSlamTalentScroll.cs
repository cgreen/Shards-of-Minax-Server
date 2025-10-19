using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Granite Slam Talent Scroll
    // This Scroll, when socketed, grants the bearer a powerful slam effect on weapon hit
    // ---------------------------------------------------

    public class GraniteSlamTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public GraniteSlamTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Granite Slam Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public GraniteSlamTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a powerful granite slam effect on weapon hit, dealing damage and possibly knocking back the target.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Granite Slam effect with example parameters: minDamage 50, maxDamage 70, refractory 30 seconds
                XmlAttach.AttachTo(target, new XmlGraniteSlam(50, 70, 30.0));
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
