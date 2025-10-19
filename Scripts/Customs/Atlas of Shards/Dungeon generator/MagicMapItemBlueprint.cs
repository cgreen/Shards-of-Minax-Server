using System;
using System.Collections.Generic;
using System.Linq;
using Server.Items;        // for MagicMapBase, MapModifier
using Server.Mobiles;     // for Mobile

namespace Server.Engines.ProceduralDungeon
{
    /// <summary>
    /// Adapter that captures a *specific* MagicMapBase item
    /// (with its rolled modifiers) and turns it into a blueprint.
    /// </summary>
    public class MagicMapItemBlueprint : IMapBlueprint
    {
        private readonly MagicMapBase _item;
        private readonly List<MapModifier> _modsSnap;

        public MagicMapItemBlueprint(MagicMapBase item)
        {
            _item     = item;
            // freeze the mods so nobody can reroll mid-run
            _modsSnap = item.ActiveModifiers.ToList();
        }

        /// <summary>
        /// Expose the underlying scroll so Gump can internalize it.
        /// </summary>
        public MagicMapBase MapItem => _item;

        public string   Id          => _item.GetType().Name;
        public string   DisplayName => _item.Name;
        public int      Tier        => _item.Tier;
        public TimeSpan Lifetime    => _item.ExpirationTime;

		// Amend the GenerateTiles method inside MagicMapItemBlueprint
		public IEnumerable<TileDef> GenerateTiles(Point3D centre)
		{
			if (_item is IProvidesTiles p)
				return p.GenerateTiles(centre);          // ==> carve the map first
			return Enumerable.Empty<TileDef>();          //  normal magic-map
		}


        public void SpawnContent(Point3D centre, Map map, Mobile owner)
        {
            // exactly re-use the original pipeline
            var content = new MagicMapBase.SpawnedContent(
                              _item, owner, centre, map, Lifetime);

            _item.SpawnChallenges(centre, map, content, owner);
            foreach (var mod in _modsSnap)
                mod.Apply(_item, content);
        }

        public void OnCleanup()
        {
            // consume the scroll, PoE style
            _item.Delete();
        }
    }
}
