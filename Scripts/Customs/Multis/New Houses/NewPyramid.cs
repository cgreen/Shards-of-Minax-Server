using System;
using Server;
using Server.Items;
using Server.Multis;
using Server.Multis.Deeds;

namespace Server.Multis
{
    public class NewPyramid : BaseHouse
    {
        // Same area you used in the original code
        public static Rectangle2D[] AreaArray = new Rectangle2D[]
        {
            new Rectangle2D(-15, -15, 32, 32)
        };

        // Constructor in the "new style"
        public NewPyramid(Mobile owner)
            : base(0x48, owner, 1370, 10) // <--- Adjust the lockdowns/secures as you wish
        {
            uint keyValue = CreateKeys(owner);

			BaseDoor door = MakeDoor( false, DoorFacing.NorthCCW );

			if ( door is BaseHouseDoor )
				((BaseHouseDoor)door).Facing = DoorFacing.NorthCCW;

            // If you want *double* south-facing doors at (1,5,5):
            AddSouthDoors( false, 0, 13, 5, keyValue );
			AddEastDoor( false, -4, -6, 5 );
			AddDoor( door, -4, -7, 5 );

            // Place the house sign near (-4,5,0). You can adjust Z if needed:
            SetSign(3, 16, 5);

			/* -------- defer the big brick addon until the house is on the map -------- */
			Timer.DelayCall( TimeSpan.Zero, () =>
			{
				if ( Deleted || Map == Map.Internal )
					return;                       // safety-net: house never made it out

			
				// ──────────── begin manual addon spawn ────────────
				var addon = new PyramidAddon();
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
        public NewPyramid(Serial serial)
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
            get { return new Point3D(3, 16, 0); }
        }

        // The “classic” price of the building if you want one
        public override int DefaultPrice
        {
            get { return 192400; } // Adjust to whatever price you like
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
            return new NewPyramidDeed();
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
