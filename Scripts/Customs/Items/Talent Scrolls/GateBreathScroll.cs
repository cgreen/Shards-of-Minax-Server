using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // Gate Breath Talent Scroll
    // This scroll, when socketed, grants the bearer a breath attack effect on weapon hit.
    // ---------------------------------------------------

    public class GateBreathScroll : BaseSocketAugmentation
    {
        [Constructable]
        public GateBreathScroll() : base(0x1F4E) // Change to a fitting item ID if needed
        {
            Name = "Gate Breath Talent Scroll";
            Hue = 1359; // Unique color for this scroll
        }

        public override int SocketsRequired => 2; // Adjust socket count as appropriate

        public override int Icon => 0x1F4E; // Icon used in socketing menu

        public override int IconXOffset => 8;

        public override int IconYOffset => 20;

        public GateBreathScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a breath attack effect on hit, dealing damage in a cone.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach the Gate Breath effect with example parameters: refractory 1 second, damage 30, range 10
                XmlAttach.AttachTo(target, new XmlGateBreath(1.0, 30, 10));
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
