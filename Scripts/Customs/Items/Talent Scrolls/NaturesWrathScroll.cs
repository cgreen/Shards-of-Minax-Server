using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Nature's Wrath Scroll
    // This Scroll, when socketed, grants the bearer a nature's wrath effect on weapon hit
    // ---------------------------------------------------

    public class NaturesWrathScroll : BaseSocketAugmentation
    {
        [Constructable]
        public NaturesWrathScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Nature's Wrath Talent Scroll";
            Hue = 1365; // Unique hue for this scroll (feel free to change)
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public NaturesWrathScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a nature's wrath effect on hit, damaging and paralyzing nearby enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Nature's Wrath effect with example parameters: damage 15, refractory 5 seconds
                XmlAttach.AttachTo(target, new XmlNaturesWrath(15, 5.0));
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
