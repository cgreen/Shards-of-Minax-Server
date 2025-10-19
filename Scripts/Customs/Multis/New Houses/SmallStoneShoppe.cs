using System;
using Server;
using Server.Items;
using Server.Multis;
using Server.Multis.Deeds;

namespace Server.Multis
{
    public class SmallStoneShoppe : BaseHouse
    {
        // Same area you used in the original code
        public static Rectangle2D[] AreaArray = new Rectangle2D[]
        {
            new Rectangle2D(-7, -5, 14, 12)
        };

        // Constructor in the "new style"
        public SmallStoneShoppe(Mobile owner)
            : base(0x4A, owner, 1370, 10) // <--- Adjust the lockdowns/secures as you wish
        {
            uint keyValue = CreateKeys(owner);
			
            AddSouthDoors( -2, 5, 5, keyValue);
			AddSouthDoor( -3, -1, 5, 0x6A5 );
			AddEastDoor( -2, -3, 5, 0x6AF );		

            SetSign(-5, 6, 5);

			/* -------- defer the big brick addon until the house is on the map -------- */
			Timer.DelayCall( TimeSpan.Zero, () =>
			{
				if ( Deleted || Map == Map.Internal )
					return;                       // safety-net: house never made it out

			
				// ──────────── begin manual addon spawn ────────────
				var addon = new SmallStoneShoppeAddon();
				// Place it at the exact same origin as the house foundation:
				addon.MoveToWorld(this.Location, this.Map);
				// ───────────── end manual addon spawn ─────────────	
			});	
        }

        // —— TENT-STYLE REGION CHECK ——
        public override bool IsInside(Point3D p, int height)
        {
            if (Deleted)
                return false;
    
            // translate world coords to local (0-based) house coords
            var local = new Point2D(p.X - X, p.Y - Y);
    
            // any point inside any AreaArray rect is valid for lockdown/secure
            foreach (var rect in AreaArray)
            {
                if (rect.Contains(local))
                    return true;
            }
    
            return false;
        }

        // Deserialization constructor
        public SmallStoneShoppe(Serial serial)
            : base(serial)
        {
        }

        // Override the house area
        public override Rectangle2D[] Area
        {
            get { return AreaArray; }
        }

        // Where players are sent if they are banned/ejected
        public override Point3D BaseBanLocation
        {
            get { return new Point3D(6, 4, 0); }
        }

        // The “classic” price of the building if you want one
        public override int DefaultPrice
        {
            get { return 160500; } // Adjust to whatever price you like
        }

        // If you’re allowing conversion to custom foundations in House Customization
        public override HousePlacementEntry ConvertEntry
        {
            get { return HousePlacementEntry.ThreeStoryFoundations[37]; }
        }

        // If the foundation shifts slightly in the Y direction
        public override int ConvertOffsetY
        {
            get { return -1; }
        }

        // Return our custom deed for redeeding
        public override HouseDeed GetDeed()
        {
            return new SmallStoneShoppeDeed();
        }

        // Serialization
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        // Deserialization
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
