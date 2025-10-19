using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Mushroom Line Breath Scroll
    // This Scroll, when socketed, grants the bearer a line breath attack effect on weapon hit
    // ---------------------------------------------------

    public class MushroomLineScroll : BaseSocketAugmentation
    {
        [Constructable]
        public MushroomLineScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Mushroom Line Breath Talent Scroll";
            Hue = 0x8A; // Mushroom theme hue
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public MushroomLineScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a line breath attack: 30 damage over 10 tiles every 1 second.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Mushroom Line effect with default parameters: refractory 1 second, damage 30, range 10
                XmlAttach.AttachTo(target, new XmlMushroomLine(1.0, 30, 10));
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
