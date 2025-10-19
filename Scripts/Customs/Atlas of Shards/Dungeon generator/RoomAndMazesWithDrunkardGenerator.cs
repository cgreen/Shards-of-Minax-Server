using System;
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    public static class RoomAndMazesWithDrunkardGenerator
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
            int drunkardSteps = 1000,
            int floorItemID = 0x04E7,
            int fillItemID  = 0x0C91,
            int floorHue    = 0,
            int fillHue     = 0
        )
        {
            if (width  % 2 == 0) width--;
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

            for (int i = 0; i < numRoomTries; i++)
            {
                int size = rnd.Next(roomMin, roomMax + 1);
                int w = size % 2 == 1 ? size : size - 1;
                int h = w;
                int x = rnd.Next(1, (width - w) / 2 + 1) * 2 - 1;
                int y = rnd.Next(1, (height - h) / 2 + 1) * 2 - 1;

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

            void GrowMaze(int startX, int startY)
            {
                var cells = new List<(int x,int y)> { (startX, startY) };
                (int dx,int dy)? lastDir = null;
                StartRegion();
                Carve(startX, startY);

                while (cells.Count > 0)
                {
                    var (cx, cy) = cells[cells.Count - 1];
                    var neighbors = new List<(int dx,int dy)>
                    {
                        (2,0), (-2,0), (0,2), (0,-2)
                    };

                    var valid = new List<(int dx, int dy)>();
                    foreach (var d in neighbors)
                    {
                        int nx = cx + d.dx;
                        int ny = cy + d.dy;
                        if (nx > 0 && nx < width - 1 && ny > 0 && ny < height - 1 && grid[nx,ny] == WALL)
                            valid.Add(d);
                    }

                    if (valid.Count > 0)
                    {
                        (int dx, int dy) dir;
                        if (lastDir.HasValue && valid.Contains(lastDir.Value) && rnd.Next(100) > windingPercent)
                            dir = lastDir.Value;
                        else
                            dir = valid[rnd.Next(valid.Count)];

                        Carve(cx + dir.dx / 2, cy + dir.dy / 2);
                        Carve(cx + dir.dx, cy + dir.dy);
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

            var connectorRegions = new Dictionary<(int x,int y), HashSet<int>>();
            for (int x = 1; x < width-1; x++)
            for (int y = 1; y < height-1; y++)
            {
                if (grid[x,y] != WALL) continue;
                var regs = new HashSet<int>();
                foreach (var (dx,dy) in new[] { (1,0), (-1,0), (0,1), (0,-1) })
                {
                    var r = regions[x + dx, y + dy];
                    if (r != null) regs.Add(r.Value);
                }
                if (regs.Count >= 2)
                    connectorRegions[(x,y)] = regs;
            }

            var connectors = new List<(int x,int y)>(connectorRegions.Keys);
            var merged = new Dictionary<int,int>();
            for (int i = 0; i <= currentRegion; i++) merged[i] = i;
            int Find(int r) { while (merged[r] != r) r = merged[r]; return r; }

            var openRegions = new HashSet<int>(merged.Keys);
            while (openRegions.Count > 1)
            {
                var (cx, cy) = connectors[rnd.Next(connectors.Count)];
                AddJunction(cx, cy);

                var regs = new List<int>();
                foreach (var r in connectorRegions[(cx,cy)])
                    regs.Add(Find(r));
                int dest = regs[0];
                for (int i = 1; i < regs.Count; i++) merged[regs[i]] = dest;

                openRegions.Clear();
                foreach (var kv in merged)
                    openRegions.Add(Find(kv.Key));

                var newConnectors = new List<(int x,int y)>();
                foreach (var pos in connectors)
                {
                    if (Math.Abs(pos.x - cx) + Math.Abs(pos.y - cy) < 2) continue;
                    var regs2 = new HashSet<int>();
                    foreach (var r in connectorRegions[pos]) regs2.Add(Find(r));
                    if (regs2.Count >= 2)
                        newConnectors.Add(pos);
                    else if (rnd.Next(extraConnectorChance) == 0)
                        AddJunction(pos.x, pos.y);
                }
                connectors = newConnectors;
            }

            bool done = false;
            while (!done)
            {
                done = true;
                for (int x = 1; x < width-1; x++)
                for (int y = 1; y < height-1; y++)
                {
                    if (grid[x,y] != FLOOR) continue;
                    int exits = 0;
                    foreach (var (dx,dy) in new[] { (1,0), (-1,0), (0,1), (0,-1) })
                        if (grid[x + dx, y + dy] != WALL) exits++;
                    if (exits == 1)
                    {
                        done = false;
                        grid[x,y] = WALL;
                    }
                }
            }

            // --- STEP 5: Drunkard’s Walk ---
            int px = width / 2;
            int py = height / 2;

            for (int i = 0; i < drunkardSteps; i++)
            {
                int dir = rnd.Next(4);
                if (dir == 0 && px < width - 2)  px++;
                if (dir == 1 && px > 1)          px--;
                if (dir == 2 && py < height - 2) py++;
                if (dir == 3 && py > 1)          py--;

                grid[px, py] = FLOOR;
            }

            int halfX = width / 2;
            int halfY = height / 2;
            var placed = new HashSet<(int x,int y)>();

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                if (grid[x,y] == FLOOR || grid[x,y] == DOOR)
                {
                    placed.Add((x,y));
                    yield return new TileDef {
                        Offset = new Point3D(x - halfX, y - halfY, 0),
                        ItemID = floorItemID,
                        Hue = floorHue
                    };
                }
            }

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                if (!placed.Contains((x,y)))
                    yield return new TileDef {
                        Offset = new Point3D(x - halfX, y - halfY, 0),
                        ItemID = fillItemID,
                        Hue = fillHue
                    };
            }
        }
    }
}
