using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Teleport Ability Talent Scroll
    // This scroll, when socketed, grants the bearer a teleport ability on weapon hit with a cooldown.
    // ---------------------------------------------------

    public class TeleportAbilityTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public TeleportAbilityTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Teleport Ability Talent Scroll";
            Hue = 1157; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust if needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public TeleportAbilityTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a teleport ability on hit with a 60-second cooldown.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Teleport Ability effect with default cooldown 60 seconds
                XmlAttach.AttachTo(target, new XmlTeleportAbility(60.0));
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
