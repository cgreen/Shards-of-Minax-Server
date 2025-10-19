/*  WildernessEncounterDistributionSystem.cs
 *  ---------------------------------------------------------------
 *  Distributes wilderness encounters using an XML file and a set
 *  of wilderness spawn points with a larger SpawnRange.
 *
 *  Command syntax (GM+):
 *      [WildernessEncounterDistribution
 *
 *  Author: ChatGPT – Aug 2025, with user customization
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Server;
using Server.Commands;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Commands.Custom
{
    internal sealed class WildernessSpawnEntry
    {
        public string Text { get; }
        public int Count { get; }
        public WildernessSpawnEntry(string text, int count)
        {
            Text = text;
            Count = count;
        }
        public XmlSpawner.SpawnObject ToSpawnObject()
            => new XmlSpawner.SpawnObject(Text, Count);
    }

    internal sealed class WildernessEncounterDefinition
    {
        public string Name { get; }
        public int Weight { get; }
        public XmlSpawner.SpawnObject[] SpawnObjects { get; }
        public WildernessEncounterDefinition(string name, int weight, IEnumerable<WildernessSpawnEntry> entries)
        {
            Name = name;
            Weight = Math.Max(1, weight);
            SpawnObjects = entries.Select(e => e.ToSpawnObject()).ToArray();
        }
    }

    internal readonly struct WildernessSpawnPoint
    {
        public Map Facet { get; }
        public Point3D Loc { get; }
        public WildernessSpawnPoint(Map facet, Point3D loc)
        {
            Facet = facet;
            Loc = loc;
        }
    }

    public static class WildernessEncounterDistributionSystem
    {
        // === Wilderness configuration ===
        private const string ConfigPath = @"Data/WildernessEncounters.xml";
        private const int SpawnRange = 120; // Large range for wilderness encounters

        private static readonly List<WildernessSpawnPoint> _wildernessSpawnPoints = new List<WildernessSpawnPoint>
        {
            new WildernessSpawnPoint(Map.Trammel, new Point3D(2592, 2733, 0)),
            new WildernessSpawnPoint(Map.Trammel, new Point3D(2675, 2512, 2)),
            new WildernessSpawnPoint(Map.Trammel, new Point3D(2709, 2363, 5)),
            new WildernessSpawnPoint(Map.Trammel, new Point3D(3783, 1640, 5)),
            new WildernessSpawnPoint(Map.Trammel, new Point3D(4388, 1666, -8)),
            new WildernessSpawnPoint(Map.Trammel, new Point3D(4548, 1942, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1022, 910, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1230, 1051, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1129, 1151, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(962, 1177, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(791, 1097, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(734, 998, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(761, 695, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(687, 482, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1448, 955, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1400, 1715, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1182, 1732, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1037, 1790, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(924, 1848, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(718, 2003, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(733, 2186, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(793, 2227, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(900, 2164, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1079, 2059, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1266, 2053, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1185, 2157, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1105, 2209, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1005, 2273, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(746, 2418, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(529, 2474, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(789, 2617, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(885, 2783, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1163, 2712, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1310, 2640, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1400, 2414, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1535, 2339, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1824, 2574, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1955, 2614, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2158, 2649, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2274, 2669, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1930, 2956, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1779, 3045, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1690, 2866, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1384, 3028, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1261, 3512, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1418, 3492, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(1637, 3543, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2005, 3472, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2334, 3602, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2578, 3707, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2764, 3711, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3017, 3671, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3377, 3481, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3265, 3127, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2993, 3303, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3096, 3425, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2848, 3543, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3002, 3173, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3129, 2913, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2860, 2933, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2533, 2847, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2421, 2731, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2794, 2377, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2944, 2247, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2962, 1992, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2586, 2001, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2727, 1277, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2630, 1151, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2434, 1173, 12)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2180, 1345, 12)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2079, 1217, 12)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2054, 913, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2113, 685, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2283, 677, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2578, 834, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2261, 398, 3)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2400, 345, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2642, 410, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(2736, 560, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3068, 528, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3202, 632, 10)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3462, 651, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3693, 636, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3845, 625, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4073, 608, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4281, 777, 3)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4179, 971, 3)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3969, 927, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3854, 1011, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3688, 816, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3591, 946, 10)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3482, 1033, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3333, 1268, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3468, 1403, 11)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3622, 1416, 12)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3918, 1407, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4124, 1660, 12)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4345, 1734, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4035, 2364, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4097, 2437, 1)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4354, 2607, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4283, 2925, 0)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(4223, 3087, 2)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3952, 3088, 5)),
            new WildernessSpawnPoint(Map.Map7, new Point3D(3833, 2778, 2)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(164, 49, 34)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(483, 75, 0)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(997, 87, 44)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(1105, 99, 26)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(1053, 649, 30)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(700, 286, -5)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(568, 334, -1)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(415, 262, 54)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(505, 406, 0)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(700, 453, 42)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(721, 583, 12)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(530, 653, -2)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(479, 783, -2)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(362, 916, 6)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(228, 984, 13)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(253, 1113, 13)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(446, 1099, 38)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(858, 1084, 17)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(959, 1245, 0)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(807, 1400, 16)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(684, 1440, 45)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(586, 1463, -1)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(459, 1500, -5)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(365, 1529, -5)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(243, 1570, 32)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(229, 1690, 48)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(375, 1685, -2)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(506, 1681, 41)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(607, 1656, 0)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(716, 1639, 43)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(817, 1615, 0)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(906, 1639, 2)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(1010, 1658, 17)),
            new WildernessSpawnPoint(Map.Map9, new Point3D(1065, 1662, 19)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(985, 660, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1136, 933, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1270, 1004, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1250, 1175, 29)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(878, 1596, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1145, 2500, 4)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(922, 2789, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1440, 2747, 10)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1216, 3024, 7)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(927, 3032, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(847, 3424, 60)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1110, 3527, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1213, 3479, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(1583, 3199, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2221, 2897, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2746, 2327, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3067, 2250, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2965, 2087, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2867, 2010, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2616, 2063, 4)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2556, 1988, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2146, 901, 2)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2624, 661, 21)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2779, 738, 4)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(2890, 746, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3454, 885, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3702, 879, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3854, 1024, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3763, 1236, 10)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3844, 1370, 16)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(4052, 1408, 16)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(4057, 2215, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(4150, 2399, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(4008, 2350, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(4046, 3009, 0)),
            new WildernessSpawnPoint(Map.Map10, new Point3D(3745, 3264, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(738, 930, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1200, 727, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1353, 530, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1837, 665, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1826, 578, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1733, 837, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1565, 1039, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1348, 1203, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1138, 1220, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1126, 1116, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(869, 1367, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(858, 1546, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(961, 1680, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1032, 1818, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1056, 1961, 6)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1074, 2141, 6)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1140, 2215, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1141, 2361, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1405, 2387, 1)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(717, 2446, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1464, 2643, 6)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1654, 2739, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1799, 2673, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2024, 2895, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2179, 3147, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2471, 3225, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2610, 3338, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2715, 3382, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2899, 3343, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3680, 3367, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3927, 3342, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4048, 3334, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4066, 3018, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4172, 1729, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4111, 1659, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3821, 1514, 6)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4068, 1262, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4158, 996, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4088, 441, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(4190, 479, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3969, 806, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3855, 865, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3705, 943, 9)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3429, 969, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3226, 976, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3028, 989, 60)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3056, 817, 6)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(3033, 651, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2644, 539, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2345, 782, 5)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2267, 860, 4)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2163, 964, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(1982, 1147, 12)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(2481, 1120, 2)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(617, 741, 3)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(733, 1077, -5)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(885, 1209, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1342, 1444, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1357, 1744, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1608, 1440, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1665, 1108, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1910, 927, 0)),
            new WildernessSpawnPoint(Map.Map12, new Point3D(1318, 897, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(432, 586, 21)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(396, 502, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(940, 315, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1029, 367, -8)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1001, 426, 15)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(421, 1003, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(410, 913, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(601, 1241, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(708, 1290, 11)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(509, 1521, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(449, 1766, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(414, 1849, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(283, 2001, 42)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(193, 2079, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(320, 2124, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(392, 2214, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(300, 2313, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(215, 2564, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(190, 2799, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(258, 2850, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(449, 2883, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(451, 3023, 12)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(430, 3126, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(575, 2942, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(623, 2776, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(615, 2594, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(608, 2415, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(763, 2367, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(889, 2542, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(921, 2617, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(928, 2756, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(857, 2862, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(991, 2889, 30)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1062, 2934, 30)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1171, 2666, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1358, 2656, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1418, 2759, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1433, 2848, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1624, 2878, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1599, 2995, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1565, 3239, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1245, 3314, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1062, 3356, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1149, 3591, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1739, 3507, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1915, 3475, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2091, 3443, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2223, 3419, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2147, 3682, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2428, 3603, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2652, 3528, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2749, 3497, 3)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2795, 3362, 3)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2802, 3261, 12)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2810, 3125, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2819, 2990, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2825, 2888, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2831, 2786, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2552, 2958, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2733, 2490, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2793, 2330, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2830, 2235, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2868, 2141, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2905, 2047, 19)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2964, 1887, 1)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3014, 1761, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2918, 1725, 30)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2796, 1678, 15)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2678, 1569, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2650, 1406, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2643, 1321, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3018, 1209, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3093, 1319, 12)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3231, 1323, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3406, 1330, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3488, 1442, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3642, 1492, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3858, 1601, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3938, 1656, 80)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3938, 1656, 80)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4296, 1549, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4423, 1505, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4548, 1459, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4490, 1387, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4330, 1334, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4435, 1152, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4512, 962, 12)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4114, 1053, 40)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4026, 826, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3983, 792, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3930, 731, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3906, 631, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3894, 581, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3864, 456, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3743, 387, 6)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3387, 285, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3473, 263, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4388, 401, 75)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4434, 441, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4539, 534, 15)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4574, 565, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4794, 551, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4786, 611, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4760, 819, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4851, 869, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4762, 1060, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4880, 1148, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4578, 1509, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(5103, 1945, 30)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(5064, 1983, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(5137, 2125, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(5079, 2256, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4503, 1946, 12)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4535, 1863, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4625, 2445, 30)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4231, 2433, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4150, 2416, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(4067, 2398, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3526, 2283, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3284, 2232, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(3041, 2179, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2826, 2135, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2554, 2075, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2367, 2035, 20)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2232, 2007, 25)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(2041, 1963, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1852, 1924, 10)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1690, 1889, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1555, 1860, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1459, 1782, 1)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1405, 1695, 15)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1379, 1651, 25)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1289, 1622, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1094, 1612, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(898, 1704, 65)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(738, 1785, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(624, 1851, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(525, 1842, 32)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(566, 1687, 1)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(694, 1628, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(861, 1539, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1086, 1321, 15)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1194, 1206, 0)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1304, 1093, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1385, 1008, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1613, 995, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1692, 883, 33)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1736, 811, 22)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1714, 755, 5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1884, 764, -5)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1920, 859, 2)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1935, 898, 13)),
            new WildernessSpawnPoint(Map.Map13, new Point3D(1759, 990, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(98, 528, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(176, 636, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(156, 784, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(81, 974, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(382, 974, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(401, 859, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(424, 726, 1)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(436, 650, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(487, 571, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(523, 386, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(535, 317, 4)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(772, 370, -8)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(866, 418, 1)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(863, 567, 1)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(754, 658, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(680, 784, 1)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(629, 895, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(543, 1079, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(591, 1130, -8)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(700, 1132, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(844, 1132, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(916, 1132, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(971, 1164, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(967, 1238, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(984, 1375, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(952, 1613, 32)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(961, 1697, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1117, 1657, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1234, 1627, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1342, 1642, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1435, 1676, 7)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1532, 1713, 50)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1623, 1590, 1)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1695, 1500, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1706, 1407, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1595, 1440, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1354, 1472, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1322, 1442, 4)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1358, 1330, -15)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1428, 1153, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1470, 1047, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1609, 946, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1708, 1006, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1539, 807, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1440, 747, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1377, 717, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1231, 648, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(1189, 628, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(930, 580, 2)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(902, 400, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(910, 366, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(888, 316, 0)),
            new WildernessSpawnPoint(Map.Map14, new Point3D(810, 291, 0)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1273, 944, 10)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1287, 778, 1)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1452, 636, 10)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1631, 701, 12)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1723, 855, 10)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(2023, 682, 2)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1998, 955, 2)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1696, 929, 10)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1504, 940, 10)),
            new WildernessSpawnPoint(Map.Map15, new Point3D(1522, 777, 20)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5311, 3257, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5538, 3264, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5702, 3286, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5866, 3303, 10)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(6017, 3283, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5871, 3479, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5897, 3666, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5929, 3890, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5759, 3906, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5682, 3749, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5637, 3700, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5641, 3610, 2)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5491, 3829, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5408, 3923, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5360, 3930, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5240, 3800, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5258, 3539, 0)),
            new WildernessSpawnPoint(Map.Map11, new Point3D(5266, 3423, 0)),			

            // ... add more as desired ...
        };
        // ================================

        // === RANDOM ORG NAME/HUE/TEAM ARRAYS AND HELPERS ===
        private static readonly string[] OrgAdjectives = {
			"Bone", "Shadow", "Iron", "Tree", "Red", "Storm", "Stone", "Frost",
			"Blood", "Moon", "Wolf", "Dusk", "Blight", "Dust", "Oak", "Wind",
			"Thunder", "Night", "Ash", "Gold", "Crystal", "Obsidian", "Steel",
			"Void", "Ancient", "Solar", "Arcane", "Silver", "Radiant", "Elder",
			"Verdant", "Celestial", "Infernal", "Raven", "Cobalt", "Emerald",
			"Azure", "Star", "Spectral", "Rune", "Grim", "Sun", "Deep", "Grave",
			"Feral", "Vortex", "Ivory", "Sable", "Dusky", "Mythic", "Astral",
			"Drake", "Dire", "Lunar", "Serpent", "Blazing", "Gloom", "Tide",
			"Moss", "Pyre", "Echo", "Ghastly", "Mossy", "Nebula", "Tempest",
			"Twilight", "Stormborn", "Gilded", "Ebon", "Crimson", "Violet",
			"Wyrm", "Specter", "Vigilant", "Rune", "Glacial", "Mist", "Phantom",
			"Starborn", "Tarnished", "Galactic", "Gossamer", "Primal", "Coral",
			"Sinister", "Mystic", "Rift", "Solaris", "Thunderous", "Venomous",
			"Shattered", "Platinum", "Sable", "Echoing", "Fey", "Celestine",
			"Tangle", "Fungal", "Sable", "Howling", "Scarlet", "Luminous",
			"Obsidian", "Spectral", "Opaline", "Duskwind", "Hallowed", "Molten",
			"Gale", "Quicksilver", "Stellar", "Ironwood", "Blackthorn", "Eclipse",
			"Feywood", "Sunfire", "Starfall", "Thorn", "Inferno", "Sky", "Rune",
			"Spirit", "Mirror", "Cryptic", "Briar", "Drifting", "Radiant", "Celestium",
			"Frozen", "Torrid", "Marsh", "Wild", "Runed", "Cursed", "Blessed",
			"Aetheric", "Ether", "Astral", "Titan", "Behemoth", "Myriad", "Voidborne",
			"Shadowed", "Stormforged", "Warped", "Lost", "Blinding", "Searing", "Umbral",
			"Cinder", "Ember", "Seaborne", "Ironclad", "Solarian", "Terran", "Eldritch",
			"Hollow", "Quaking", "Tremor", "Wyrd", "Glinting", "Leviathan", "Venerable",
			"Thundering", "Stormwrought", "Sablewing", "Frostfall", "Grove", "Echoing",
			"Sunken", "Pale", "Corrupted", "Elder", "Stygian", "Haunted", "Golden",
			"Thunderbolt", "Ancient", "Luminous", "Silvered", "Runic", "Abyssal",
			"Mirror", "Bramble", "Dread", "Vexing", "Chimeric", "Rune-touched",
			"Spellbound", "Mirrored", "Wisp", "Ebonwing", "Moonlit", "Sablemane",
			"Stormswept", "Wraith", "Lorekeeper", "Celestial", "Frostbite", "Sunblade"
        };

        private static readonly string[] OrgNouns = {
			"Crush", "Walker", "Lover", "Hunter", "Guard", "Rider", "Caller", "Breaker",
			"Seeker", "Watcher", "Ravager", "Reaver", "Howler", "Warden", "Raider",
			"Stalker", "Beast", "Feeder", "Reaper", "Bane", "Shade", "Scribe", "Mage",
			"Blade", "Shadow", "Phoenix", "Elemental", "Rune", "Relic", "Sigil", "Fang",
			"Claw", "Scale", "Storm", "Wolf", "Hawk", "Eagle", "Lion", "Drake", "Wyvern",
			"Dragon", "Talon", "Serpent", "Chimera", "Golem", "Vortex", "Shard", "Star",
			"Moongate", "Ether", "Ankh", "Virtue", "Daemon", "Wisp", "Knight", "Paladin",
			"Shade", "Druid", "Mystic", "Oracle", "Prophet", "Arcanist", "Lich", "Phantom",
			"Ghost", "Specter", "Wraith", "Zombie", "Ghoul", "Skeleton", "Ogre", "Troll",
			"Giant", "Titan", "Sprite", "Nymph", "Dryad", "Satyr", "Pixie", "Imp", "Harpy",
			"Basilisk", "Griffin", "Manticore", "Hydra", "Leviathan", "Kraken", "Djinn",
			"Efreet", "Djinn", "Gargoyle", "Elf", "Drow", "Orc", "Goblin", "Kobold",
			"Bandit", "Corsair", "Buccaneer", "Pirate", "Marauder", "Vagabond", "Wanderer",
			"Nomad", "Outlaw", "Rogue", "Thief", "Assassin", "Cultist", "Witch", "Warlock",
			"Sorcerer", "Alchemist", "Artificer", "Technomancer", "Chronomancer", "Psion",
			"Astromancer", "Geomancer", "Necromancer", "Bloodletter", "Runepriest", "Hexer",
			"Illusionist", "Mindbender", "Stormcaller", "Firebrand", "Frostbinder", "Pyromancer",
			"Cryomancer", "Venomancer", "Windrider", "Earthshaker", "Starborn", "Skywatcher",
			"Sunstalker", "Moonstrider", "Twilight", "Dawn", "Dusk", "Eclipse", "Aurora",
			"Nova", "Comet", "Meteor", "Asteroid", "Celestial", "Cosmos", "Galaxian", "Void",
			"Aether", "Radiant", "Umbra", "Mist", "Fog", "Tempest", "Bolt", "Current", "Stream",
			"Pulse", "Spark", "Inferno", "Ember", "Ash", "Blight", "Plague", "Pox", "Scourge",
			"Mire", "Fen", "Marsh", "Swamp", "Thicket", "Grove", "Vale", "Glen", "Cavern",
			"Hollow", "Peak", "Summit", "Ridge", "Crag", "Cliff", "Gorge", "Chasm", "Abyss",
			"Void", "Depth", "Pillar", "Spire", "Tower", "Citadel", "Fortress", "Keep",
			"Bastion", "Sanctum", "Shrine", "Temple", "Monastery", "Labyrinth", "Maze",
			"Ruins", "Vault", "Archive", "Library", "Sanctuary", "Hermit", "Hermitage",
			"Pilgrim", "Disciple", "Seer", "Shaman", "Visionary", "Crusader", "Champion",
			"Warden", "Sentinel", "Defender", "Protector", "Enforcer", "Marshal", "Legion",
			"Phalanx", "Cohort", "Vanguard", "Battalion", "Squadron", "Regiment", "Platoon",
			"Division", "Fleet", "Armada", "Caravan", "Expedition", "Recon", "Scout",
			"Ranger", "Pathfinder", "Tracker", "Guide", "Explorer", "Pioneer", "Adventurer",
			"Journeyman", "Adept", "Initiate", "Acolyte", "Worshipper", "Fanatic", "Believer",
			"Apostle", "Herald", "Messenger", "Courier", "Harbinger", "Forerunner", "Seeker",
			"Wayfarer", "Navigator", "Pilot", "Captain", "Commander", "Overseer", "Architect",
			"Builder", "Engineer", "Mechanic", "Tinker", "Inventor", "Synth", "Cyborg",
			"Android", "Machina", "Automaton", "Gynoid", "Construct", "Drone", "Probe",
			"Sentience", "Mind", "Soul", "Spirit", "Echo", "Voice", "Chant", "Song", "Choir",
			"Chronicler", "Sage", "Scholar", "Lorekeeper", "Historian", "Archivist", "Cartographer"
        };

        private static readonly string[] OrgTypes = {
			"Clan",
			"Tribe",
			"Order",
			"Brotherhood",
			"Guild",
			"Band",
			"Company",
			"Syndicate",
			"Corporation",
			"Sect",
			"Consortium",
			"Circle",
			"Council",
			"Cabal",
			"Legion",
			"Enclave",
			"Federation",
			"Dynasty",
			"Congregation",
			"Collective",
			"Coalition",
			"Alliance",
			"Conglomerate",
			"Society",
			"Coven",
			"Assembly",
			"Confederacy",
			"Knighthood",
			"Crusade",
			"Academy",
			"Brotherhood",
			"Association",
			"House",
			"Lineage",
			"Sisterhood",
			"Coterie",
			"Horde",
			"Dominion",
			"Empire",
			"Fellowship",
			"Council",
			"Circle",
			"Covenant",
			"Sanctum",
			"Alliance",
			"Watch",
			"Cartel",
			"Pact",
			"Regiment",
			"Syndicate",
			"Garrison",
			"Collegium",
			"Guardianship",
			"Circle",
			"Conclave",
			"Expedition",
			"Sect",
			"Voyagers",
			"Expanse",
			"League",
			"Institute",
			"Institute",
			"Order",
			"Mages",
			"Circle",
			"Chalice",
			"Keepers",
			"Artificers",
			"Wanderers",
			"Navigators",
			"Seekers",
			"Prophets",
			"Heralds",
			"Mystics",
			"Druids",
			"Pilgrims",
			"Sentinels",
			"Stewards",
			"Arbiters",
			"Harbingers",
			"Watches",
			"Alchemists",
			"Archivists",
			"Templars",
			"Celestials",
			"Magistrate",
			"Reclaimers",
			"Forerunners",
			"Enchanters",
			"Defenders",
			"Wardens",
			"Emissaries",
			"Scribes",
			"Technocracy",
			"Dominators",
			"Purifiers",
			"Renegades",
			"Mercenaries",
			"Explorers",
			"Illuminati",
			"Companions",
			"Custodians",
			"Architects",
			"Watchers",
			"Navigators",
			"Acolytes",
			"Expeditionaries",
			"Patrollers",
			"Revenants",
			"Keepers",
			"Assemblage",
			"Chroniclers",
			"Incarnates",
			"Ascendants",
			"Initiates",
			"Circle",
			"Conservators",
			"Healers",
			"Seers",
			"Virtuosi",
			"Guardians",
			"Evokers",
			"Retinue",
			"Vanguard",
			"Overseers",
			"Outriders",
			"Seeker",
			"Restorers",
			"Reclaimers",
			"Technomancers",
			"Synths",
			"Terraformers",
			"Exploratorius",
			"Runeguard",
			"Loremasters",
			"Magisters",
			"Stormcallers",
			"Timekeepers",
			"Realitywalkers",
			"Dawnwalkers",
			"Shadowcasters",
			"Echoes",
			"Phalanx",
			"Nomads",
			"Frontiersmen",
			"Aegis",
			"Firesworn",
			"Starseekers",
			"Dreamers",
			"Mythmakers",
			"Sovereignty",
			"Uplifters",
			"Relictors",
			"Vigilants",
			"Cenobites",
			"Artisans",
			"Ward",
			"Cryptics",
			"Outcasts",
			"Conclave",
			"Judicators",
			"Anachronauts",
			"Runebinders",
			"Sororitas",
			"Arcanists",
			"Wayfarers",
			"Elementalists",
			"Shapers",
			"Aetherians",
			"Transcendents"
        };

        private static string GenerateRandomOrgName(Random rnd)
        {
            string adj = OrgAdjectives[rnd.Next(OrgAdjectives.Length)];
            string noun = OrgNouns[rnd.Next(OrgNouns.Length)];
            string type = OrgTypes[rnd.Next(OrgTypes.Length)];
            return $"{adj} {noun} {type}";
        }

        private static int GenerateRandomHue(Random rnd)
        {
            return rnd.Next(1, 3000); // 1 to 2999 inclusive
        }

        private static int GenerateRandomTeam(Random rnd)
        {
            return rnd.Next(1, 3); // 1 or 2 (upper bound exclusive)
        }
        // ===================================================

        public static void Initialize()
        {
            CommandSystem.Register(
                "WildernessEncounterDistribution",
                AccessLevel.GameMaster,
                new CommandEventHandler(OnCommand)
            );
        }

        private static void OnCommand(CommandEventArgs e)
        {
            var from = e.Mobile;

            List<WildernessEncounterDefinition> defs;
            try
            {
                defs = LoadDefinitions(ConfigPath);
            }
            catch (Exception ex)
            {
                from.SendMessage(0x22, $"[WEDS] XML load error: {ex.Message}");
                return;
            }

            if (defs.Count == 0)
            {
                from.SendMessage(0x22, "[WEDS] No <Encounter> entries found.");
                return;
            }
            if (_wildernessSpawnPoints.Count == 0)
            {
                from.SendMessage(0x22, "[WEDS] No spawn points configured!");
                return;
            }

            // Build weighted list
            var encounters = new List<XmlSpawner.SpawnObject[]>();
            foreach (var def in defs)
                for (int i = 0; i < def.Weight; i++)
                    encounters.Add(def.SpawnObjects);

            var rnd = new Random();
            Shuffle(encounters, rnd);
            Shuffle(_wildernessSpawnPoints, rnd);

            int total = Math.Min(encounters.Count, _wildernessSpawnPoints.Count);

            for (int i = 0; i < total; i++)
            {
                var so = encounters[i];
                var sp = _wildernessSpawnPoints[i];

                int cap = so.Sum(o => o.ActualMaxCount);

                var xml = new XmlSpawner(
                    Guid.NewGuid(),               // uniqueId: a unique identifier for this spawner
                    0,                            // x: region X (not used, 0 for full area)
                    0,                            // y: region Y (not used, 0 for full area)
                    0,                            // width: region width (not used)
                    0,                            // height: region height (not used)
                    $"Wilderness Encounter #{i+1}",// name: spawner name
                    cap,                          // maxCount: maximum creatures/items alive at once
                    TimeSpan.FromMinutes(5),      // minDelay: minimum spawn delay (wilder, longer)
                    TimeSpan.FromMinutes(10),     // maxDelay: maximum spawn delay (wilder, longer)
                    TimeSpan.Zero,                // duration: total time before despawning (-1 disables)
                    -1,                           // proximityRange: distance for proximity triggers (-1 disables)
                    0,                            // proximityTriggerSound: sound played on proximity trigger (0 disables)
                    1,                            // amount: number of times to spawn each cycle (1 is normal)
                    0,                            // team: team assignment (usually 0)
                    SpawnRange,                   // homeRange: allowed wander range from spawner (LARGE for wilds)
                    false,                        // isRelativeHomeRange: if homeRange is relative (false = absolute)
                    so,                           // spawnObjects: what to spawn (your encounter definition)
                    TimeSpan.Zero,                // minRefractory: min delay after all dead before next spawn
                    TimeSpan.Zero,                // maxRefractory: max delay after all dead before next spawn
                    TimeSpan.Zero,                // todStart: time-of-day start (0 disables)
                    TimeSpan.Zero,                // todEnd: time-of-day end (0 disables)
                    (Item)null,                   // objectPropertyItem: for property triggers (rarely used)
                    null,                         // objectPropertyName: for property triggers (rarely used)
                    null,                         // proximityMessage: message on proximity trigger (optional)
                    null,                         // itemTriggerName: item name required to trigger (optional)
                    null,                         // noitemTriggerName: item name that disables spawner (optional)
                    null,                         // speechTrigger: phrase that triggers spawn (optional)
                    null,                         // mobTriggerName: mobile name required to trigger (optional)
                    null,                         // mobPropertyName: mob property required to trigger (optional)
                    null,                         // playerPropertyName: player property required to trigger (optional)
                    1.0,                          // triggerProbability: chance to trigger (1.0 = always)
                    (Item)null,                   // setPropertyItem: item to set property on (optional)
                    false,                        // isGroup: if spawner is a group spawn (rarely used)
                    (XmlSpawner.TODModeType)0,    // todMode: time-of-day mode (0 = always, 1 = range, etc)
                    1,                            // killReset: resets spawn on kill (1 = reset after all killed)
                    false,                        // externalTriggering: only spawn when triggered by external event
                    -1,                           // sequentialSpawning: sequential group (rarely used, -1 disables)
                    null,                         // regionName: region this applies to (optional)
                    false,                        // allowGhost: ghosts can trigger? (usually false)
                    false,                        // allowNPC: NPCs can trigger? (usually false)
                    false,                        // spawnOnTrigger: only spawns on manual or scripted trigger
                    null,                         // configFile: alternate config file (rarely used)
                    TimeSpan.Zero,                // despawnTime: time until spawned things despawn (0 = never)
                    null,                         // skillTrigger: skill required to trigger (optional)
                    false,                        // smartSpawning: use smart spawn logic (usually false)
                    null                          // wayPoint: waypoint for spawned creatures (optional)
                );

                xml.SpawnRange    = SpawnRange;
                xml.PlayerCreated = true;
                xml.MoveToWorld(sp.Loc, sp.Facet);

                from.SendMessage(0x59, "[WEDS] Placed wilderness encounter #{0} (cap {1}) at {2} [{3}].",
                                 i+1, cap, sp.Loc, sp.Facet);
            }

            from.SendMessage(0x59, "[WEDS] Total wilderness spawners: {0}.", total);
        }

        private static List<WildernessEncounterDefinition> LoadDefinitions(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            var list = new List<WildernessEncounterDefinition>();
            XmlNodeList encounters = doc.SelectNodes("/Encounters/Encounter");
            if (encounters == null)
                return list;

            // === Single Random instance for all spawns to avoid similar names ===
            Random rnd = new Random();

            foreach (XmlNode enc in encounters)
            {
                string name = "Unnamed";
                int weight  = 1;
                if (enc.Attributes["name"]   != null) name   = enc.Attributes["name"].Value;
                if (enc.Attributes["weight"] != null)
                    int.TryParse(enc.Attributes["weight"].Value, out weight);

                var entries = new List<WildernessSpawnEntry>();
                foreach (XmlNode sn in enc.SelectNodes("SpawnObject"))
                {
                    string text = "";
                    int    cnt  = 1;
                    if (sn.Attributes["text"]  != null) text = sn.Attributes["text"].Value;
                    if (sn.Attributes["count"] != null)
                        int.TryParse(sn.Attributes["count"].Value, out cnt);

                    // === RANDOMIZATION & APPEND ===
                    string orgName = GenerateRandomOrgName(rnd);
                    int hue = GenerateRandomHue(rnd);
                    int team = GenerateRandomTeam(rnd);

                    text += $"/name/{orgName}/hue/{hue}/team/{team}";

                    entries.Add(new WildernessSpawnEntry(text, cnt));
                }

                list.Add(new WildernessEncounterDefinition(name, weight, entries));
            }

            return list;
        }

        private static void Shuffle<T>(IList<T> list, Random rng)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
