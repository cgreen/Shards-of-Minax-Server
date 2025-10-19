using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Dreamy Aura Talent Scroll
    // This scroll, when socketed, grants the bearer a dreamy aura effect on weapon hit
    // ---------------------------------------------------

    public class DreamyAuraTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public DreamyAuraTalentScroll() : base(0x1F4E) // Choose an appropriate item ID for the scroll
        {
            Name = "Dreamy Aura Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } }

        public override int Icon { get { return 0x1F4E; } }

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public DreamyAuraTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a dreamy aura effect on weapon hit, damaging and freezing nearby players.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Dreamy Aura effect with example parameters: damage 5, cooldown 40 seconds
                XmlAttach.AttachTo(target, new XmlDreamyAura(5, 40.0));
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
