using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Network; // For MessageType and Effects

namespace Server.Items
{
    // ---------------------------------------------------
    // Airborne Escape Talent Scroll
    // This Scroll, when socketed, grants the bearer a swift escape maneuver effect on demand with a cooldown.
    // ---------------------------------------------------

    public class AirborneEscapeTalentScroll : BaseSocketAugmentation
    {
        [Constructable]
        public AirborneEscapeTalentScroll() : base(0x1F4E) // Use a suitable scroll/item ID here
        {
            Name = "Airborne Escape Talent Scroll";
            Hue = 1359; // Unique hue for this scroll
        }

        public override int SocketsRequired { get { return 2; } } // Adjust as needed

        public override int Icon { get { return 0x1F4E; } }

        public override int IconXOffset { get { return 8; } }

        public override int IconYOffset { get { return 20; } }

        public AirborneEscapeTalentScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants the ability to evade with a swift maneuver once per minute.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is Mobile m)
            {
                XmlAttach.AttachTo(target, new XmlAirborneEscape(1.0)); // 1 minute refractory default
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
