using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;

namespace Server.CustomJewels
{
    [Flipable(0x1026, 0x1027)]          // chisel art
    public class JewelersChisel : Item
    {
        [Constructable] public JewelersChisel() : base(0x1026)
        { Weight = 2.0; Name = "Jeweler's Chisel"; }

        public JewelersChisel(Serial s) : base(s) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            { from.SendLocalizedMessage(1042001); return; }
            from.CloseGump(typeof(JewelersGump));
            from.SendGump(new JewelersGump(from, this));
        }

        public override void Serialize(GenericWriter w) { base.Serialize(w); w.Write(0); }
        public override void Deserialize(GenericReader r) { base.Deserialize(r); _ = r.ReadInt(); }
    }
}
