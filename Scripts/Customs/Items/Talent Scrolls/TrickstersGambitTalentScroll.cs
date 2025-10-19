using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Trickster's Gambit Talent Scroll
    // This Scroll, when socketed, grants the bearer a boost to Strength and Dexterity on weapon hit
    // ---------------------------------------------------

    public class TrickstersGambitTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public TrickstersGambitTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Trickster's Gambit Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public TrickstersGambitTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Boosts strength and dexterity by 20 for 30 seconds every 6 seconds.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Trickster's Gambit effect with refractory 6 seconds (0.1 minutes = 6 seconds)
                XmlAttach.AttachTo(target, new XmlTrickstersGambit(6.0));
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
