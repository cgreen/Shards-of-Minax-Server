using System;
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    public static class RoomsMazesGeneratorB
    {
        private const int WALL = 0;
        private const int FLOOR = 1;

        public static IEnumerable<TileDef> Generate(
            int gridSize = 41,
            int numRoomTries = 50,
            int minRoomSize = 3,
            int maxRoomSize = 9,
            int extraConnectorChance = 20,
            int windingPercent = 0,
            int floorItemID = 0x04E7,    // Default floor
            int fillItemID = 0x0C91,     // Default fill
            int floorHue = 0,            // Default floor hue
            int fillHue = 0              // Default fill hue
        )
        {
            var rnd = new Random();
            int half = gridSize / 2;

            // 1) Initialize
            var grid = new int[gridSize, gridSize];
            var regions = new int[gridSize, gridSize];
            for (int x = 0; x < gridSize; x++)
            for (int y = 0; y < gridSize; y++)
                regions[x, y] = -1;

            int currentRegion = -1;
            var rooms = new List<(int x, int y, int w, int h)>();

            // helpers
            void StartRegion() => currentRegion++;
            void Carve(int x, int y)
            {
                grid[x, y] = FLOOR;
                regions[x, y] = currentRegion;
            }

            // 2) Add Rooms
            for (int i = 0; i < numRoomTries; i++)
            {
                // pick odd dimensions
                int w = rnd.Next(minRoomSize, maxRoomSize + 1) | 1;
                int h = rnd.Next(minRoomSize, maxRoomSize + 1) | 1;
                int x = rnd.Next(1, (gridSize - w) / 2 + 1) * 2 - 1;
                int y = rnd.Next(1, (gridSize - h) / 2 + 1) * 2 - 1;

                // check overlap
                bool overlap = false;
                foreach (var r in rooms)
                {
                    if (x < r.x + r.w && x + w > r.x &&
                        y < r.y + r.h && y + h > r.y)
                    {
                        overlap = true; break;
                    }
                }
                if (overlap) continue;

                // carve room
                rooms.Add((x, y, w, h));
                StartRegion();
                for (int xx = x; xx < x + w; xx++)
                for (int yy = y; yy < y + h; yy++)
                    Carve(xx, yy);
            }

            // 3) Grow mazes in remaining walls (growing tree)
            foreach (var sy in IterateOdd(1, gridSize - 2))
            foreach (var sx in IterateOdd(1, gridSize - 2))
            {
                if (grid[sx, sy] != WALL) continue;

                var cells = new List<(int x, int y)>();
                (int x, int y) lastDir = (0, 0);

                StartRegion();
                Carve(sx, sy);
                cells.Add((sx, sy));

                while (cells.Count > 0)
                {
                    var (cx, cy) = cells[cells.Count - 1];
                    var options = new List<(int dx, int dy)>();

                    foreach (var d in new[] { (2, 0), (-2, 0), (0, 2), (0, -2) })
                    {
                        var (dx, dy) = d;
                        int nx = cx + dx, ny = cy + dy;
                        if (nx <= 0 || nx >= gridSize - 1 || ny <= 0 || ny >= gridSize - 1) continue;
                        if (grid[nx, ny] == WALL)
                            options.Add((dx, dy));
                    }

                    if (options.Count > 0)
                    {
                        (int dx, int dy) dir = (0, 0);
                        if (options.Contains(lastDir) && rnd.Next(100) > windingPercent)
                        {
                            dir = lastDir;
                        }
                        else
                        {
                            dir = options[rnd.Next(options.Count)];
                        }

                        int carve1x = cx + dir.dx / 2, carve1y = cy + dir.dy / 2;
                        int carve2x = cx + dir.dx, carve2y = cy + dir.dy;

                        Carve(carve1x, carve1y);
                        Carve(carve2x, carve2y);
                        cells.Add((carve2x, carve2y));
                        lastDir = dir;
                    }
                    else
                    {
                        cells.RemoveAt(cells.Count - 1);
                        lastDir = (0, 0);
                    }
                }
            }

            // 4) Connect Regions
            // build connector list
            var connectorRegions = new Dictionary<(int x, int y), HashSet<int>>();
            for (int x = 1; x < gridSize - 1; x++)
            for (int y = 1; y < gridSize - 1; y++)
            {
                if (grid[x, y] != WALL) continue;
                var neigh = new HashSet<int>();
                foreach (var d in new[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
                {
                    int r = regions[x + d.Item1, y + d.Item2];
                    if (r >= 0) neigh.Add(r);
                }
                if (neigh.Count >= 2)
                    connectorRegions[(x, y)] = neigh;
            }

            var connectors = new List<(int x, int y)>(connectorRegions.Keys);
            // union-find map
            var parent = new Dictionary<int, int>();
            for (int i = 0; i <= currentRegion; i++) parent[i] = i;
            int Find(int r)
            {
                while (parent[r] != r) r = parent[r];
                return r;
            }

            var open = new HashSet<int>();
            for (int i = 0; i <= currentRegion; i++) open.Add(Find(i));

            while (open.Count > 1 && connectors.Count > 0)
            {
                var idx = rnd.Next(connectors.Count);
                var (cx, cy) = connectors[idx];
                // carve connector
                Carve(cx, cy);

                // merge regions
                var regs = connectorRegions[(cx, cy)];
                var list = new List<int>(regs);
                int a = Find(list[0]), b = Find(list[1]);
                parent[b] = a;

                // rebuild open
                open.Clear();
                for (int i = 0; i <= currentRegion; i++)
                    open.Add(Find(i));

                // prune connectors
                var next = new List<(int, int)>();
                foreach (var pos in connectors)
                {
                    if (Math.Abs(pos.x - cx) + Math.Abs(pos.y - cy) < 2) continue;
                    var rr = connectorRegions[pos];
                    var set = new HashSet<int>();
                    foreach (var r in rr) set.Add(Find(r));
                    if (set.Count >= 2)
                        next.Add(pos);
                    else if (rnd.Next(extraConnectorChance) == 0)
                        Carve(pos.x, pos.y);
                }
                connectors = next;
            }

            // 5) Remove Dead-ends
            bool removed;
            do
            {
                removed = false;
                for (int x = 1; x < gridSize - 1; x++)
                for (int y = 1; y < gridSize - 1; y++)
                {
                    if (grid[x, y] != FLOOR) continue;
                    int exits = 0;
                    foreach (var d in new[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
                        if (grid[x + d.Item1, y + d.Item2] != WALL)
                            exits++;
                    if (exits == 1)
                    {
                        grid[x, y] = WALL;
                        removed = true;
                    }
                }
            } while (removed);

            // 6) Yield TileDefs
            var placed = new HashSet<(int x, int y)>();
            for (int x = 0; x < gridSize; x++)
            for (int y = 0; y < gridSize; y++)
            {
                if (grid[x, y] == FLOOR)
                {
                    placed.Add((x, y));
                    yield return new TileDef
                    {
                        Offset = new Point3D(x - half, y - half, 0),
                        ItemID = floorItemID,
                        Hue = floorHue
                    };
                }
            }

            for (int x = 0; x < gridSize; x++)
            for (int y = 0; y < gridSize; y++)
            {
                if (!placed.Contains((x, y)))
                {
                    yield return new TileDef
                    {
                        Offset = new Point3D(x - half, y - half, 0),
                        ItemID = fillItemID,
                        Hue = fillHue
                    };
                }
            }
        }

        // helper to iterate odd numbers from start to end inclusive
        private static IEnumerable<int> IterateOdd(int start, int end)
        {
            for (int i = start | 1; i <= end; i += 2)
                yield return i;
        }
    }
}
