// File: Server/Items/TestGroveB.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.MiniChamps;
using Server.Engines.ProceduralDungeon;

namespace Server.Items
{
    /// <summary>
    /// A *true* magic-map scroll:
    ///  • keeps all MagicMapBase modifiers / rerolls
    ///  • implements GenerateTiles so the Map-Device will carve a maze first
    /// </summary>
    public class TestGroveB : ProceduralMagicMapBase
    {
        // –– How big the device should cut out around its pad ––
        private const int kRadius = 55;

        // –– Mini-champ parameters ––
		public List<MiniChampType> AllowedChampTypes => new List<MiniChampType>
		{
			MiniChampType.Encounter393
		};

        public int ChampsToSpawn => Tier;

		[Constructable]
		public TestGroveB()
			: base(0x14EB, "Map to the Lair of the Enigmatic Satyr Grove", 550) // ← three args
		{ }

		public TestGroveB(Serial serial) : base(serial) { }


        /*  ───────────────────────────────────────
         *  TERRAIN : this is the *new* bit
         *  ─────────────────────────────────────── */
		public override IEnumerable<TileDef> GenerateTiles(Point3D centre)
		{
			return RoomsMazesGeneratorB.Generate(
				gridSize: 100,
				numRoomTries: 50,
				minRoomSize: 5,
				maxRoomSize: 11,
				extraConnectorChance: 20,
				windingPercent: 0,
                floorItemID:        0x177D,  // e.g. smooth stone
                fillItemID:         0x0178,  // e.g. cobblestone
                floorHue:           1154,    // a deep crimson
                fillHue:            69       // a bright emerald				
			);
		}


        /*  ───────────────────────────────────────
         *  CONTENT : identical to your old map
         *  ─────────────────────────────────────── */
        public override void SpawnChallenges(Point3D centre, Map map,
                                             SpawnedContent content, Mobile owner)
        {
            for (int i = 0; i < ChampsToSpawn; i++)
            {
                var type = AllowedChampTypes[Utility.Random(AllowedChampTypes.Count)];
                var pt   = new Point3D(
                    centre.X + Utility.RandomMinMax(-10, 10),
                    centre.Y + Utility.RandomMinMax(-10, 10),
                    centre.Z);

                var ctrl = MiniChamp.CreateMiniChampOnFacet(
                               type, SpawnRadius, pt, map);
                content.SpawnedEntities.Add(ctrl);
            }

            base.SpawnChallenges(centre, map, content, owner);
        }

        /*  ───────────────────────────────────────
         *  SERIALISATION : unchanged
         *  ─────────────────────────────────────── */
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
