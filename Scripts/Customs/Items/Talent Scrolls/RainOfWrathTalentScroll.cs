using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Rain of Wrath Talent Scroll
    // This scroll grants the bearer the Rain of Wrath effect on weapon hit
    // ---------------------------------------------------

    public class RainOfWrathTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public RainOfWrathTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Rain of Wrath Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public RainOfWrathTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a Rain of Wrath effect on hit, dealing area damage to nearby enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Rain of Wrath effect with example parameter: interval 2 minutes
                XmlAttach.AttachTo(target, new XmlRainOfWrath(2.0));
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
