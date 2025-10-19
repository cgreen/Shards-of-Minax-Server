using System;
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    public static class RoomMazeGenerator
    {
        private struct Cell { public bool IsRoom, Visited; }

        public static IEnumerable<TileDef> Generate(
            int gridSize = 41,
            int roomCount = 16,
            int minRoomSize = 30,
            int maxRoomSize = 100,
            int floorItemID = 0x04E7,
            int fillItemID = 0x0C91,
            int floorHue = 0,
            int fillHue = 0
        )
        {
            var rnd = new Random();
            int half = gridSize / 2;

            // 1. Initialize grid
            var grid = new Cell[gridSize, gridSize];

            // 2. Place random rooms
            var rooms = new List<(int x, int y, int w, int h)>();
            for (int i = 0; i < roomCount; i++)
            {
                int w = rnd.Next(minRoomSize, maxRoomSize + 1);
                int h = rnd.Next(minRoomSize, maxRoomSize + 1);
                int x = rnd.Next(1, gridSize - w - 1);
                int y = rnd.Next(1, gridSize - h - 1);

                // avoid overlapping existing rooms
                bool overlaps = false;
                foreach (var r in rooms)
                {
                    if (x < r.x + r.w && x + w > r.x && y < r.y + r.h && y + h > r.y)
                    {
                        overlaps = true; break;
                    }
                }
                if (overlaps) continue;

                // carve room
                rooms.Add((x, y, w, h));
                for (int yy = y; yy < y + h; yy++)
                    for (int xx = x; xx < x + w; xx++)
                        grid[xx, yy].IsRoom = true;
            }

            // 3. Carve a perfect maze in non-room cells using DFS backtracker
            var stack = new Stack<(int x, int y)>();
            int sx = rnd.Next(0, gridSize / 2) * 2 + 1, sy = rnd.Next(0, gridSize / 2) * 2 + 1;
            stack.Push((sx, sy));
            grid[sx, sy].Visited = true;

            while (stack.Count > 0)
            {
                var (cx, cy) = stack.Peek();
                var dirs = new List<(int dx, int dy)> { (2, 0), (-2, 0), (0, 2), (0, -2) };
                // randomize order
                for (int j = dirs.Count - 1; j > 0; j--)
                {
                    int k = rnd.Next(j + 1);
                    var tmp = dirs[j]; dirs[j] = dirs[k]; dirs[k] = tmp;
                }

                bool carved = false;
                foreach (var (dx, dy) in dirs)
                {
                    int nx = cx + dx, ny = cy + dy;
                    if (nx <= 0 || nx >= gridSize - 1 || ny <= 0 || ny >= gridSize - 1) continue;
                    if (grid[nx, ny].Visited || grid[nx, ny].IsRoom) continue;

                    // carve passage
                    grid[nx, ny].Visited = true;
                    grid[cx + dx / 2, cy + dy / 2].Visited = true;
                    stack.Push((nx, ny));
                    carved = true;
                    break;
                }

                if (!carved)
                    stack.Pop();
            }

            // 4. Connect each room to the maze by drilling a door
            foreach (var (rx, ry, rw, rh) in rooms)
            {
                // find a border cell of the room adjacent to a carved maze cell
                var candidates = new List<(int x, int y, int dx, int dy)>();
                for (int xx = rx; xx < rx + rw; xx++)
                {
                    foreach (var dy in new[] { -1, rh })
                        if (cyWithin(xx, ry + dy - (dy < 0 ? 0 : 1), gridSize)
                            && grid[xx, ry + dy].Visited)
                            candidates.Add((xx, ry + (dy < 0 ? 0 : rh - 1), 0, dy < 0 ? -1 : 1));
                }
                for (int yy = ry; yy < ry + rh; yy++)
                {
                    foreach (var dx in new[] { -1, rw })
                        if (cxWithin(rx + dx - (dx < 0 ? 0 : 1), yy, gridSize)
                            && grid[rx + dx, yy].Visited)
                            candidates.Add((rx + (dx < 0 ? 0 : rw - 1), yy, dx < 0 ? -1 : 1, 0));
                }
                if (candidates.Count > 0)
                {
                    var c = candidates[rnd.Next(candidates.Count)];
                    grid[c.x + c.dx, c.y + c.dy].Visited = true; // carve door
                }
            }

            // 5. Track where we've placed floor
            var placed = new HashSet<(int x, int y)>();

            for (int x = 0; x < gridSize; x++)
            for (int y = 0; y < gridSize; y++)
                if (grid[x, y].IsRoom || grid[x, y].Visited)
                {
                    yield return new TileDef
                    {
                        Offset = new Point3D(x - half, y - half, 0),
                        ItemID = floorItemID,
                        Hue = floorHue
                    };
                    placed.Add((x, y));
                }

            // 6. Fill the rest with wall tile
            for (int x = 0; x < gridSize; x++)
            for (int y = 0; y < gridSize; y++)
                if (!placed.Contains((x, y)))
                    yield return new TileDef
                    {
                        Offset = new Point3D(x - half, y - half, 0),
                        ItemID = fillItemID,
                        Hue = fillHue
                    };
        }

        private static bool cxWithin(int x, int y, int size) => x >= 0 && x < size && y >= 0 && y < size;
        private static bool cyWithin(int x, int y, int size) => x >= 0 && x < size && y >= 0 && y < size;
    }
}
