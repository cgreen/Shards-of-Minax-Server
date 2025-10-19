using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Illusion Ability Talent Scroll
    // This Scroll, when socketed, grants the bearer a chance to create an illusionary duplicate on weapon hit
    // ---------------------------------------------------

    public class IllusionAbilityTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public IllusionAbilityTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Illusion Ability Talent Scroll";
            Hue = 1154; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public IllusionAbilityTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a chance to create an illusionary duplicate on weapon hit.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Illusion Ability with example parameters: 25% chance, 2-minute cooldown
                XmlAttach.AttachTo(target, new XmlIllusionAbility(0.25, TimeSpan.FromMinutes(2)));
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
