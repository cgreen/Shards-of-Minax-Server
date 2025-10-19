using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Static Shock Talent Scroll
    // This Scroll, when socketed, grants the bearer a static shock effect on weapon hit
    // ---------------------------------------------------

    public class StaticShockTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public StaticShockTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Static Shock Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public StaticShockTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a static shock effect on hit, damaging, freezing, and potentially stunning enemies.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Static Shock effect with example parameters:
                // MinDamage=5, MaxDamage=15, StunChance=0.5, FreezeDuration=2s, StunDuration=1s
                XmlAttach.AttachTo(target, new XmlStaticShock(5, 15, 0.5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1)));
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
