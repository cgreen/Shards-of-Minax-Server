using System;
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    public struct TileDef
    {
        public Point3D Offset;
        public int ItemID;
        public int Hue;
    }

    public static class PDungeonGenerator
    {
        private const int Size = 21; // 21x21 grid
        private const int TileID = 0x04E7;

		public static IEnumerable<TileDef> Generate()
		{
			// Customize gridSize, roomCount, etc. as desired
			return RoomMazeGenerator.Generate(gridSize: 100, roomCount: 10, minRoomSize: 5, maxRoomSize: 10);
		}

    }
}
