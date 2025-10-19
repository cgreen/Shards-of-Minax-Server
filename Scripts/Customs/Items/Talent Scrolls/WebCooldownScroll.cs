using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Web Cooldown Scroll
    // This Scroll, when socketed, grants the bearer a 5% chance to paralyze the target on weapon hit with a cooldown
    // ---------------------------------------------------

    public class WebCooldownScroll : BaseSocketAugmentation
    {
        [Constructable]
        public WebCooldownScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Web Cooldown Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public WebCooldownScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a 5% chance to paralyze the target on hit for " 
                   + TimeSpan.FromSeconds(3).TotalSeconds + " seconds with cooldown.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Web Cooldown effect with example cooldown duration of 3 seconds
                XmlAttach.AttachTo(target, new XmlWebCooldown(3.0));
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
