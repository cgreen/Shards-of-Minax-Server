using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Fiery Illusion Talent Scroll
    // This Scroll, when socketed, grants the bearer the ability to create a fiery illusion on weapon hit
    // ---------------------------------------------------

    public class FieryIllusionTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FieryIllusionTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Fiery Illusion Talent Scroll";
            Hue = 1360; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public FieryIllusionTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the ability to create a fiery illusion on weapon hit, with a 2-minute cooldown.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Fiery Illusion effect with default 2 minute activation delay
                XmlAttach.AttachTo(target, new XmlFieryIllusion());
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
