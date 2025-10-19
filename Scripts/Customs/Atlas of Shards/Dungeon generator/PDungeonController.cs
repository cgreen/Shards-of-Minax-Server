using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Regions;

namespace Server.Engines.ProceduralDungeon
{
    public class PDungeonController : Item
    {
        public static PDungeonController Instance;

        public List<PDungeonInstance> Instances { get; private set; } = new List<PDungeonInstance>();

        /// <summary>How long until the dungeon auto-expires.</summary>
        public TimeSpan LifeTime = TimeSpan.FromMinutes(30);

        /// <summary>Where players return when they exit.</summary>
        public Point3D KickLoc = new Point3D(505, 2192, 25);

        /// <summary>Portal visuals / sounds</summary>
        public int PortalHue = 0x492;
        public int PortalSound = 0x1FE;

        public PDungeonController() : base(0x9CEF)
        {
            Movable = false;
            Name = "Map Device";
            Instance = this;

            // Default pad setup if placed via [add
            if (Instances.Count == 0)
            {
                Instances.Add(new PDungeonInstance(this, new Point3D(6330, 2150, 0), 40));
                Instances.Add(new PDungeonInstance(this, new Point3D(6390, 2150, 0), 40));
            }
        }

        [Constructable]
        public PDungeonController(Point3D loc, Map map) : this()
        {
            MoveToWorld(loc, map);
            KickLoc = loc;
        }

		/// <summary>
		/// Returns true if any OriginPortal or ReturnPortal exists 
		/// within a few tiles of this controller.
		/// </summary>
		private bool HasActivePortals()
		{
			// scan within 5 tiles of the device
			foreach (var item in Map.GetItemsInRange(Location, 5))
			{
				if (item is OriginPortal || item is ReturnPortal)
					return true;
			}
			return false;
		}


		public override void OnDoubleClick(Mobile from)
		{
			if (!from.InRange(this, 3))
				return;

			// NEW: block if any portals are still up
			if (HasActivePortals())
			{
				from.SendMessage("The device is still linked to an active dungeon.  Close all portals before using it again.");
				return;
			}

			from.SendGump(new PDungeonGump((PlayerMobile)from));
		}


        public void Tick()
        {
            foreach (var inst in Instances)
                inst.Tick();
        }

        public static void Initialize()
        {
            CommandSystem.Register("AddPDungeonController", AccessLevel.Administrator, e =>
            {
                if (Instance == null)
                {
                    var ctrl = new PDungeonController(e.Mobile.Location, e.Mobile.Map);
                    ctrl.KickLoc = e.Mobile.Location;
                }
                else
                    e.Mobile.SendMessage("Controller already exists.");
            });

            Timer.DelayCall(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1),
                () => Instance?.Tick());
        }

        // ──────────────────────────────────────────────────────
        // Serialization
        // ──────────────────────────────────────────────────────

        public PDungeonController(Serial serial) : base(serial)
        {
            Instance = this;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(KickLoc);
            writer.Write(PortalHue);
            writer.Write(PortalSound);

            writer.Write(Instances.Count);
            foreach (var inst in Instances)
            {
                writer.Write(inst.Center);
                writer.Write(inst.Radius);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            KickLoc = reader.ReadPoint3D();
            PortalHue = reader.ReadInt();
            PortalSound = reader.ReadInt();

            Instances = new List<PDungeonInstance>();
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                var center = reader.ReadPoint3D();
                int radius = reader.ReadInt();

                Instances.Add(new PDungeonInstance(this, center, radius));
            }

            Instance = this;
        }
    }
}
