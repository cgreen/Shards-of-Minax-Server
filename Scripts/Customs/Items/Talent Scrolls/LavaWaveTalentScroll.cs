using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Lava Wave Talent Scroll
    // This Scroll, when socketed, grants the bearer a lava wave effect on weapon hit
    // ---------------------------------------------------

    public class LavaWaveTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public LavaWaveTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Lava Wave Talent Scroll";
            Hue = 1350; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public LavaWaveTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a lava wave effect on hit, damaging and burning nearby enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Lava Wave effect with example parameters: minDamage 10, maxDamage 20, activationTime 30 seconds
                XmlAttach.AttachTo(target, new XmlLavaWave(10, 20, 30.0));
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
