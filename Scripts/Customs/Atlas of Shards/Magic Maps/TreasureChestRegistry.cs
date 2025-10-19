using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    /// <summary>Describes one concrete chest implementation.</summary>
    public sealed class TreasureChestType
    {
        public string Id { get; }
        public string DisplayName { get; }
        public Func<MagicMapBase, Mobile, int, LockableContainer> Factory { get; }

        public TreasureChestType(
            string id,
            string displayName,
            Func<MagicMapBase, Mobile, int, LockableContainer> factory)
        {
            Id          = id;
            DisplayName = displayName;
            Factory     = factory;
        }
    }

    public static class TreasureChestRegistry
    {
        static readonly Dictionary<string, TreasureChestType> _byId =
            new Dictionary<string, TreasureChestType>(StringComparer.OrdinalIgnoreCase);

        public static void Register(TreasureChestType t)
        {
            _byId[t.Id] = t;
        }

        public static TreasureChestType Get(string id)
        {
            TreasureChestType t;
            return _byId.TryGetValue(id, out t) ? t : null;
        }

        public static IEnumerable<TreasureChestType> All => _byId.Values;


        // ──── Built-in registrations ─────────────────────────────────
        static TreasureChestRegistry()
        {
            // 1) Standard treasure
            Register(new TreasureChestType(
                "Standard",
                "Buried Treasure",
                (map, owner, level) =>
                {
                    var chest = new TreasureMapChest(owner, level, false);

                    // chest quality
                    if (level >= 5)
                        chest.ChestQuality = ChestQuality.Gold;
                    else if (level >= 3)
                        chest.ChestQuality = ChestQuality.Standard;
                    else
                        chest.ChestQuality = ChestQuality.Rusty;

                    // random facet
                    var facets = new[]
                    {
                        TreasureFacet.Trammel,
                        TreasureFacet.Felucca,
                        TreasureFacet.Tokuno,
                        TreasureFacet.TerMur,
                        TreasureFacet.Ilshenar,
                        TreasureFacet.Malas
                    };
                    var rndFacet = facets[Utility.RandomMinMax(0, facets.Length - 1)];

                    Map resolvedMap = Map.Trammel;
                    switch (rndFacet)
                    {
                        case TreasureFacet.Felucca:  resolvedMap = Map.Felucca;  break;
                        case TreasureFacet.Tokuno:   resolvedMap = Map.Tokuno;   break;
                        case TreasureFacet.TerMur:   resolvedMap = Map.TerMur;   break;
                        case TreasureFacet.Ilshenar: resolvedMap = Map.Ilshenar; break;
                        case TreasureFacet.Malas:    resolvedMap = Map.Malas;    break;
                    }

                    // random package
                    var packages = (TreasurePackage[])Enum.GetValues(typeof(TreasurePackage));
                    var pkgIndex = Utility.RandomMinMax(0, packages.Length - 1);

                    var tmap = new TreasureMap
                    {
                        Level         = level,
                        Package       = packages[pkgIndex],
                        TreasureLevel = (TreasureLevel)level,
                        Map           = resolvedMap,
                        Location      = Point3D.Zero
                    };

                    chest.TreasureMap = tmap;
                    TreasureMapInfo.Fill(owner, chest, tmap);

                    return chest;
                }));

            // 2) Azurite mining challenge
/*             Register(new TreasureChestType(
                "Azurite",
                "Azurite Deposit",
                (map, owner, level) =>
                {
                    // Uses your AzuriteChest class
                    return new AzuriteChest(owner, level, false);
                })); */
        }
    }
}
