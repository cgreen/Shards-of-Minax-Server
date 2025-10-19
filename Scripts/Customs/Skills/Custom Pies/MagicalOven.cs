using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPies
{
    [Flipable(0xA84C, 0xA84E)] // a generic oven sprite
    public class MagicalOven : Item
    {
        [Constructable]
        public MagicalOven() : base(0xA84C)
        {
            Weight = 15.0;
            Name   = "magical oven";

        }

        public MagicalOven(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from == null || from.Deleted)
                return;

            from.CloseGump(typeof(MagicalOvenGump));
            from.SendGump(new MagicalOvenGump(from, this));
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
