using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Frenzy Scroll
    // This Scroll, when socketed, grants the bearer a chance on melee hit
    // to gain a temporary dexterity boost (frenzy effect)
    // ---------------------------------------------------

    public class FrenzyScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FrenzyScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Frenzy Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public FrenzyScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a 15% chance on melee hit to increase Dexterity by 50 for 30 seconds.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Frenzy effect with default parameters
                XmlAttach.AttachTo(target, new XmlFrenzy());
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
