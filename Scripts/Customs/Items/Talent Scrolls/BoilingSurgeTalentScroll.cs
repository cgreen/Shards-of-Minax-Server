using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Boiling Surge Talent Scroll
    // This Scroll, when socketed, grants the bearer a boiling surge effect on weapon hit
    // ---------------------------------------------------

    public class BoilingSurgeTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public BoilingSurgeTalentScroll() : base(0x1F4E) // Replace with suitable scroll/item ID
        {
            Name = "Boiling Surge Talent Scroll";
            Hue = 1359; // Unique hue for the scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public BoilingSurgeTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a boiling surge effect on weapon hit, increasing damage for a short duration with cooldown.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Boiling Surge effect with example parameters: damageIncrease 10, cooldown 2 minutes
                XmlAttach.AttachTo(target, new XmlBoilingSurge(10, 2.0));
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
