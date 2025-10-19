// File: Server/Items/TestGrove.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.MiniChamps;
using Server.Engines.ProceduralDungeon;

namespace Server.Items
{
    public class TestGrove : ProceduralMagicMapBase
    {
        private const int kRadius = 55;

        public List<MiniChampType> AllowedChampTypes => new List<MiniChampType>
        {
            MiniChampType.Encounter393
        };

        public int ChampsToSpawn => Tier;

        [Constructable]
        public TestGrove()
            : base(0x14EB, "Map to the Lair of the Enigmatic Satyr Grove", 550)
        { }

        public TestGrove(Serial serial) : base(serial) { }

        public override IEnumerable<TileDef> GenerateTiles(Point3D centre)
        {
            // Example: custom floor/fill and hues for fun!
            return RoomMazeGenerator.Generate(
                gridSize: 100,
                roomCount: 8,
                minRoomSize: 6,
                maxRoomSize: 11,
                floorItemID: 0x177D,  // mossy floor
                fillItemID: 0x1797,   // forest grass
                floorHue: 1417,       // green hue
                fillHue: 298          // brown hue
            );
        }

        public override void SpawnChallenges(Point3D centre, Map map,
                                             SpawnedContent content, Mobile owner)
        {
            for (int i = 0; i < ChampsToSpawn; i++)
            {
                var type = AllowedChampTypes[Utility.Random(AllowedChampTypes.Count)];
                var pt = new Point3D(
                    centre.X + Utility.RandomMinMax(-10, 10),
                    centre.Y + Utility.RandomMinMax(-10, 10),
                    centre.Z);

                var ctrl = MiniChamp.CreateMiniChampOnFacet(
                               type, SpawnRadius, pt, map);
                content.SpawnedEntities.Add(ctrl);
            }

            base.SpawnChallenges(centre, map, content, owner);
        }

        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write(0);
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            _ = r.ReadInt();
        }
    }
}
