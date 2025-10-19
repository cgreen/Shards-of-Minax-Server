using System;
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Items
{
    // ---------------------------------------------------
    // FTreeLine Scroll
    // This Scroll, when socketed, grants the bearer a flame line breath attack on weapon hit
    // ---------------------------------------------------

    public class FTreeLineScroll : BaseSocketAugmentation
    {
        [Constructable]
        public FTreeLineScroll() : base(0x1F4E) // Choose an appropriate item ID for the scroll
        {
            Name = "Flame Tree Line Talent Scroll";
            Hue = 1359; // Unique color for identification
        }

        public override int SocketsRequired => 2; // Adjust based on balance

        public override int Icon => 0x1F4E; // Icon used in the socketing menu

        public override int IconXOffset => 8;

        public override int IconYOffset => 20;

        public FTreeLineScroll(Serial serial) : base(serial)
        {
        }

        public override string OnIdentify(Mobile from)
        {
            return "Grants a flame line breath attack on hit, damaging enemies in a 3-tile wide line.";
        }

        public override bool OnAugment(Mobile from, object target)
        {
            if (target is BaseWeapon || target is BaseArmor || target is BaseJewel || target is BaseCreature)
            {
                // Attach XmlFTreeLine with example params: refractory 1 sec, damage 30, range 10
                XmlAttach.AttachTo(target, new XmlFTreeLine(1.0, 30, 10));
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
