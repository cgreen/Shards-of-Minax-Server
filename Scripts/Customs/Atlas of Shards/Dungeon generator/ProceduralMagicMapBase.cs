// File: Server/Items/ProceduralMagicMapBase.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.ProceduralDungeon;

namespace Server.Items
{
    /// <summary>
    /// Drop-in replacement for MagicMapBase that also implements IProvidesTiles.
    /// If you *don’t* override GenerateTiles the map behaves exactly like before.
    /// </summary>
    public abstract class ProceduralMagicMapBase : MagicMapBase, IProvidesTiles
    {
        protected ProceduralMagicMapBase(int itemID, string name, int radius)
            : base(itemID, name, radius) { }

		public ProceduralMagicMapBase(Serial serial)
			: base(serial)
		{
		}

        /// <summary>
        /// Override in each concrete map to build a layout:
        ///     return RoomMazeGenerator.Generate(...);
        /// or     return HandCarvedTiles;
        /// </summary>
        public abstract IEnumerable<TileDef> GenerateTiles(Point3D centre);
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version 0 — no extra fields yet
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			// No fields to restore (yet)
		}
		
    }
}
