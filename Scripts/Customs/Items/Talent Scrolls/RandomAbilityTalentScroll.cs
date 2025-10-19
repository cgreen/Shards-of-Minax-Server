using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Random Ability Talent Scroll
    // This scroll, when socketed, attaches a random set of abilities to the bearer.
    // ---------------------------------------------------

    public class RandomAbilityTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public RandomAbilityTalentScroll() : base(0x1F4E) // Choose a suitable scroll/item ID
        {
            Name = "Random Ability Talent Scroll";
            Hue = 1365; // Unique hue for this scroll
        }

        public override int SocketsRequired => 2; // Adjust as needed

        public override int Icon => 0x1F4E; // Icon for socketing menu

        public override int IconXOffset => 8;

        public override int IconYOffset => 20;

        public RandomAbilityTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the bearer a random set of abilities upon socketing.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is Mobile || target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the XmlRandomAbility with example min 1 and max 5 abilities
                XmlAttach.AttachTo(target, new XmlRandomAbility(1, 5));
                return true;
            }
            return false;
        }

        public override bool CanAugment(Mobile from, object target)
        {
            return target is Mobile || target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature;
        }

        public override bool CanRecover(Mobile from, object target, int version)
        {
            return target is Mobile || target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature;
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
