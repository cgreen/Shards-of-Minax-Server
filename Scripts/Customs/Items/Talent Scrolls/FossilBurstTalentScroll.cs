using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Fossil Burst Talent Scroll
    // This Scroll, when socketed, grants the bearer the Fossil Burst effect on weapon hit
    // ---------------------------------------------------

    public class FossilBurstTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FossilBurstTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Fossil Burst Talent Scroll";
            Hue = 1365; // Unique hue for this scroll, change as desired
        }

        public override int SocketsRequired { get { return 2; } } // Adjust socket count as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public FossilBurstTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the Fossil Burst effect on hit, dealing 20-30 physical damage to nearby targets and lowering their physical resistance.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Fossil Burst effect with example parameters: minDamage=20, maxDamage=30, cooldown=30 seconds
                XmlAttach.AttachTo(target, new XmlFossilBurst(20, 30, 30.0));
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
