using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Inferno Aura Scroll
    // This Scroll, when socketed, grants the bearer an inferno aura effect on weapon hit
    // ---------------------------------------------------

    public class InfernoAuraTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public InfernoAuraTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Inferno Aura Talent Scroll";
            Hue = 1350; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public InfernoAuraTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants an inferno aura effect on hit, damaging nearby enemies every minute.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Inferno Aura effect with example parameters: minDamage 5, maxDamage 10, cooldown 1 minute
                XmlAttach.AttachTo(target, new XmlInfernoAura(5, 10, 1.0));
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
