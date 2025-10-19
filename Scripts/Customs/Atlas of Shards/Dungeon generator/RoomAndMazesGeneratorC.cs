using System;
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    public static class RoomAndMazesGeneratorC
    {
        private const int WALL = 0, FLOOR = 1, DOOR = 2;

        public static IEnumerable<TileDef> Generate(
            int width = 51,
            int height = 51,
            int numRoomTries = 50,
            int roomMin = 3,
            int roomMax = 9,
            int extraConnectorChance = 20,
            int windingPercent = 0,
            int floorItemID = 0x04E7,
            int fillItemID  = 0x0C91,
            int floorHue    = 0,
            int fillHue     = 0
        )
        {
            // enforce odd dimensions
            if (width  % 2 == 0) width --;
            if (height % 2 == 0) height--;

            var rnd = new Random();
            var grid    = new int[width, height];
            var regions = new int?[width, height];
            int currentRegion = -1;
            var rooms = new List<(int x,int y,int w,int h)>();

            void StartRegion() => currentRegion++;
            void Carve(int x, int y, int tile = FLOOR)
            {
                grid[x,y]    = tile;
                regions[x,y] = currentRegion;
            }
            void AddJunction(int x, int y)
            {
                grid[x,y] = (rnd.Next(4) == 0 ? DOOR : FLOOR);
            }

            // --- STEP 1: add rooms ---
            for (int i = 0; i < numRoomTries; i++)
            {
                int size = rnd.Next(roomMin, roomMax + 1);
                // make odd
                int w = size % 2 == 1 ? size : size - 1;
                int h = w;
                int x = rnd.Next(1, (width - w) / 2 + 1) * 2 - 1;
                int y = rnd.Next(1, (height - h) / 2 + 1) * 2 - 1;

                // overlap?
                bool fails = false;
                foreach (var r in rooms)
                {
                    if (!(x + w < r.x || r.x + r.w < x || y + h < r.y || r.y + r.h < y))
                    {
                        fails = true;
                        break;
                    }
                }
                if (fails) continue;

                rooms.Add((x,y,w,h));
                StartRegion();
                for (int yy = y; yy < y + h; yy++)
                    for (int xx = x; xx < x + w; xx++)
                        Carve(xx, yy);
            }

            // --- STEP 2: grow mazes ---
            void GrowMaze(int startX, int startY)
            {
                var cells = new List<(int x,int y)>{ (startX, startY) };
                (int dx,int dy)? lastDir = null;
                StartRegion();
                Carve(startX, startY);

                while (cells.Count > 0)
                {
                    var (cx, cy) = cells[cells.Count - 1];
                    var neighbors = new List<(int dx,int dy)>();

                    foreach (var d in new[] { (2,0), (-2,0), (0,2), (0,-2) })
                    {
                        int nx = cx + d.Item1, ny = cy + d.Item2;
                        if (nx > 0 && nx < width-1 && ny > 0 && ny < height-1 && grid[nx,ny] == WALL)
                            neighbors.Add(d);
                    }

                    if (neighbors.Count > 0)
                    {
                        (int dx,int dy) dir;
                        if (lastDir != null && neighbors.Contains(lastDir.Value) && rnd.Next(100) > windingPercent)
                            dir = lastDir.Value;
                        else
                            dir = neighbors[rnd.Next(neighbors.Count)];

                        Carve(cx + dir.dx/2, cy + dir.dy/2);
                        Carve(cx + dir.dx,     cy + dir.dy);
                        cells.Add((cx + dir.dx, cy + dir.dy));
                        lastDir = dir;
                    }
                    else
                    {
                        cells.RemoveAt(cells.Count - 1);
                        lastDir = null;
                    }
                }
            }

            for (int x = 1; x < width;  x += 2)
                for (int y = 1; y < height; y += 2)
                    if (grid[x,y] == WALL)
                        GrowMaze(x,y);

            // --- STEP 3: connect regions ---
            // find all potential connectors
            var connectorRegions = new Dictionary<(int x,int y), HashSet<int>>();
            for (int x = 1; x < width-1; x++)
            for (int y = 1; y < height-1; y++)
            {
                if (grid[x,y] != WALL) continue;
                var regs = new HashSet<int>();
                foreach (var d in new[] { (1,0), (-1,0), (0,1), (0,-1) })
                {
                    var r = regions[x + d.Item1, y + d.Item2];
                    if (r != null) regs.Add(r.Value);
                }
                if (regs.Count >= 2)
                    connectorRegions[(x,y)] = regs;
            }
            var connectors = new List<(int x,int y)>(connectorRegions.Keys);

            // union-find setup
            var merged = new Dictionary<int,int>();
            for (int i = 0; i <= currentRegion; i++) merged[i] = i;
            int Find(int r) { while (merged[r] != r) r = merged[r]; return r; }

            var openRegions = new HashSet<int>();
            foreach (var kv in merged) openRegions.Add(Find(kv.Key));

            while (openRegions.Count > 1)
            {
                var (cx, cy) = connectors[rnd.Next(connectors.Count)];
                AddJunction(cx, cy);

                var regs = new List<int>();
                foreach (var r in connectorRegions[(cx,cy)])
                    regs.Add(Find(r));
                int dest = regs[0];
                for (int i = 1; i < regs.Count; i++)
                    merged[regs[i]] = dest;

                openRegions.Clear();
                foreach (var kv in merged)
                    openRegions.Add(Find(kv.Key));

                // prune connectors
                var newConnectors = new List<(int x,int y)>();
                foreach (var pos in connectors)
                {
                    if (Math.Abs(pos.x - cx) + Math.Abs(pos.y - cy) < 2) 
                        continue;
                    var regs2 = new HashSet<int>();
                    foreach (var r in connectorRegions[pos])
                        regs2.Add(Find(r));
                    if (regs2.Count >= 2)
                        newConnectors.Add(pos);
                    else if (rnd.Next(extraConnectorChance) == 0)
                    {
                        AddJunction(pos.x, pos.y);
                    }
                }
                connectors = newConnectors;
            }

            // --- STEP 4: remove dead ends ---
            bool done = false;
            while (!done)
            {
                done = true;
                for (int x = 1; x < width-1; x++)
                for (int y = 1; y < height-1; y++)
                {
                    if (grid[x,y] != FLOOR) continue;
                    int exits = 0;
                    foreach (var d in new[] { (1,0), (-1,0), (0,1), (0,-1) })
                        if (grid[x + d.Item1, y + d.Item2] != WALL)
                            exits++;
                    if (exits == 1)
                    {
                        done = false;
                        grid[x,y] = WALL;
                    }
                }
            }

            // --- output tiles ---
            int halfX = width  / 2;
            int halfY = height / 2;
            var placed = new HashSet<(int x,int y)>();

            for (int x = 0; x < width;  x++)
            for (int y = 0; y < height; y++)
            {
                if (grid[x,y] == FLOOR || grid[x,y] == DOOR)
                {
                    placed.Add((x,y));
                    yield return new TileDef {
                        Offset = new Point3D(x - halfX, y - halfY, 0),
                        ItemID = floorItemID,
                        Hue    = floorHue
                    };
                }
            }

            for (int x = 0; x < width;  x++)
            for (int y = 0; y < height; y++)
            {
                if (!placed.Contains((x,y)))
                    yield return new TileDef {
                        Offset = new Point3D(x - halfX, y - halfY, 0),
                        ItemID = fillItemID,
                        Hue    = fillHue
                    };
            }
        }
    }
}
