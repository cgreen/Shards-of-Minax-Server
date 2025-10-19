using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.MiniChamps;
using Server.Engines.ProceduralDungeon;

namespace Server.Items
{
    public class CrimsonEmeraldMazeMap : ProceduralMagicMapBase
    {
        private const int kRadius = 50;

        // Mini-champ settings (example)
        public List<MiniChampType> AllowedChampTypes => new List<MiniChampType>
        {
            MiniChampType.Encounter150, // pick any champ
            MiniChampType.Encounter393
        };

        public int ChampsToSpawn => Tier + 1;

        [Constructable]
        public CrimsonEmeraldMazeMap()
            : base(0x14F0, "Map to the Crimson & Emerald Maze", 650)
        {
        }

        public CrimsonEmeraldMazeMap(Serial serial)
            : base(serial)
        {
        }

        public override IEnumerable<TileDef> GenerateTiles(Point3D centre)
        {
            // pass in custom floor/fill and hues
            return RoomsMazesGeneratorB.Generate(
                gridSize:            80,
                numRoomTries:        60,
                minRoomSize:         5,
                maxRoomSize:        13,
                extraConnectorChance:15,
                windingPercent:     25,
                floorItemID:        0x005A,  // e.g. smooth stone
                fillItemID:         0x088C,  // e.g. cobblestone
                floorHue:           1154,    // a deep crimson
                fillHue:            69       // a bright emerald
            );
        }

        public override void SpawnChallenges(Point3D centre, Map map,
                                             SpawnedContent content, Mobile owner)
        {
            // spawn a few mini-champs randomly
            for (int i = 0; i < ChampsToSpawn; i++)
            {
                var type = AllowedChampTypes[Utility.Random(AllowedChampTypes.Count)];
                var pt   = new Point3D(
                    centre.X + Utility.RandomMinMax(-12, 12),
                    centre.Y + Utility.RandomMinMax(-12, 12),
                    centre.Z);

                var ctrl = MiniChamp.CreateMiniChampOnFacet(type, SpawnRadius, pt, map);
                content.SpawnedEntities.Add(ctrl);
            }

            base.SpawnChallenges(centre, map, content, owner);
        }

        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write(0); // version
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            _ = r.ReadInt();
        }
    }
}
