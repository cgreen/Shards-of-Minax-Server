using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.CustomPoisons;

namespace Server.CustomPoisons
{
    [Flipable(0xAD78, 0xAD77)]     // a mortar & pestle sprite → looks like an alchemy kit
    public class PoisonersKit : Item
    {
        [Constructable]
        public PoisonersKit() : base(0xAD77)
        {
            Weight = 2.0;
            Name   = "Poisoner's Kit";
        }

        public PoisonersKit(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // must be in pack
                return;
            }

            from.CloseGump(typeof(PoisonersGump));
            from.SendGump(new PoisonersGump(from, this));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);   // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
