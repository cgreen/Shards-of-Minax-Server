using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Lava Flow Talent Scroll
    // This Scroll, when socketed, grants the bearer a lava flow effect on weapon hit
    // ---------------------------------------------------

    public class LavaFlowTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public LavaFlowTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Lava Flow Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public LavaFlowTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a lava flow effect on hit, dealing damage to targets within 3 tiles every cooldown period.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Lava Flow effect with example parameters: damage 20, cooldown 30 seconds
                XmlAttach.AttachTo(target, new XmlLavaFlow(20, 30.0));
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
