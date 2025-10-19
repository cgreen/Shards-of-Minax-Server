using System;
using Server;
using Server.Items;
using Server.Multis;

namespace Server.Multis.Deeds
{
    public class NewPyramidDeed : HouseDeed
    {
        [Constructable]
        public NewPyramidDeed()
            : base(0x48, new Point3D(-4, 5, 0)) 
            // The itemID (0x4E) matches the house's itemID
            // and the Point3D offset matches the ban location if desired.
        {
        }

        public NewPyramidDeed(Serial serial)
            : base(serial)
        {
        }

        // If you have a localized label, use that here. Otherwise you can leave as-is or set to a custom number.
        public override int LabelNumber 
        { 
            get { return 1041211; } 
        }

        // Matches the same area used by the house (useful for “Placement Preview”).
        public override Rectangle2D[] Area
        {
            get { return NewPyramid.AreaArray; }
        }

        public override BaseHouse GetHouse(Mobile owner)
        {
            return new NewPyramid(owner);
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
