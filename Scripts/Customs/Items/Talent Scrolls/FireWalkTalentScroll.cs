using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Fire Walk Talent Scroll
    // This Scroll, when socketed, grants the bearer a teleportation burst with fire damage on weapon hit
    // ---------------------------------------------------

    public class FireWalkTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FireWalkTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Fire Walk Talent Scroll";
            Hue = 1350; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public FireWalkTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a teleportation burst with fire damage on weapon hit, cooldown 1 minute.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Fire Walk effect with default cooldown of 1 minute
                XmlAttach.AttachTo(target, new XmlFireWalk(1.0));
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
