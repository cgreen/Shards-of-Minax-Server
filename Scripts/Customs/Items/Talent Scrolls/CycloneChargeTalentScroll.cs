using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Cyclone Charge Talent Scroll
    // This scroll grants the bearer the Cyclone Charge effect on weapon hit
    // ---------------------------------------------------

    public class CycloneChargeTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public CycloneChargeTalentScroll() : base(0x1F4E) // Replace with appropriate scroll/item ID
        {
            Name = "Cyclone Charge Talent Scroll";
            Hue = 1359; // Unique hue for the scroll
        }

        public override int SocketsRequired => 2; // Adjust as needed

        public override int Icon => 0x1F4E; // Icon for socketing menu

        public override int IconXOffset => 8;

        public override int IconYOffset => 20;

        public CycloneChargeTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a powerful Cyclone Charge effect on weapon hit, dealing damage and charging the target.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Cyclone Charge effect with default damage 20 and cooldown 1 minute
                XmlAttach.AttachTo(target, new XmlCycloneCharge(20, 1.0));
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
