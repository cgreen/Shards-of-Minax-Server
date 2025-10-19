using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Molten Blast Talent Scroll
    // This Scroll, when socketed, grants the bearer the Molten Blast effect on weapon hit
    // ---------------------------------------------------

    public class MoltenBlastTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public MoltenBlastTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Molten Blast Talent Scroll";
            Hue = 1360; // Unique hue for this scroll (adjust as you see fit)
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public MoltenBlastTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a Molten Blast effect on hit with a cooldown of 30 seconds.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Molten Blast effect with cooldown of 30 seconds (default)
                XmlAttach.AttachTo(target, new XmlMoltenBlast(30.0));
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
