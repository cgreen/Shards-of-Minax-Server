// File: Server/Items/TestGroveC.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.MiniChamps;
using Server.Engines.ProceduralDungeon;

namespace Server.Items
{
    public class TestGroveC : ProceduralMagicMapBase
    {
        private const int kRadius = 55;

        public List<MiniChampType> AllowedChampTypes => new List<MiniChampType>
        {
            MiniChampType.Encounter393
        };

        public int ChampsToSpawn => Tier;

        [Constructable]
        public TestGroveC()
            : base(0x14EB, "Map to the Lair of the Enigmatic Satyr Grove", 550)
        { }

        public TestGroveC(Serial serial) : base(serial) { }

        public override IEnumerable<TileDef> GenerateTiles(Point3D centre)
        {
            // Example: custom floor/fill and hues for fun!
			return RoomAndMazesGeneratorC.Generate(
				width: 101,
				height: 81,
				numRoomTries: 60,
				roomMin: 5,
				roomMax: 13,
				extraConnectorChance: 15,
				windingPercent: 5,
				floorItemID: 0x177D, fillItemID: 0x1797,
				floorHue: 1417,      fillHue: 298
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
