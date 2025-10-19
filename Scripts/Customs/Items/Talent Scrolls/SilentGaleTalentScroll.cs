using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // ---------------------------------------------------
    // Silent Gale Talent Scroll
    // This Scroll, when socketed, grants the bearer the ability to move silently through the air with a cooldown
    // ---------------------------------------------------

    public class SilentGaleTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public SilentGaleTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Silent Gale Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } } // Icon for socketing menu

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public SilentGaleTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the ability to move silently through the air with a 30 second cooldown.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is Mobile)
            {
                // Attach the Silent Gale effect with example parameter: refractory 30 seconds
                XmlAttach.AttachTo(target, new XmlSilentGale(30.0));
                return true;
            }
            return false;
        }

        public override bool CanAugment(Mobile from, object target)
        {
            return target is Mobile;
        }

        public override bool CanRecover(Mobile from, object target, int version)
        {
            return target is Mobile;
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
