using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.MiniChamps
{
    public enum MiniChampType
    {
        CrimsonVeins,
        FairyDragonLair,
        AbyssalLair,
        DiscardedCavernClanRibbon,
        DiscardedCavernClanScratch,
        DiscardedCavernClanChitter,
        PassageofTears,
        LandsoftheLich,
        SecretGarden,
        FireTemple,
        EnslavedGoblins,
        SkeletalDragon,
        LavaCaldera,
		Encounter1,
		Encounter2,
		Encounter3,
		Encounter4,
		Encounter5,
		Encounter6,
		Encounter7,
		Encounter8,
		Encounter9,
		Encounter10,
		Encounter11,
		Encounter12,
		Encounter13,
		Encounter14,
		Encounter15,
		Encounter16,
		Encounter17,
		Encounter18,
		Encounter19,
		Encounter20,
		Encounter21,
		Encounter22,
		Encounter23,
		Encounter24,
		Encounter25,
		Encounter26,
		Encounter27,
		Encounter28,
		Encounter29,
		Encounter30,
		Encounter31,
		Encounter32,
		Encounter33,
		Encounter34,
		Encounter35,
		Encounter36,
		Encounter37,
		Encounter38,
		Encounter39,
		Encounter40,
		Encounter41,
		Encounter42,
		Encounter43,
		Encounter44,
		Encounter45,
		Encounter46,
		Encounter47,
		Encounter48,
		Encounter49,
		Encounter50,
		Encounter51,
		Encounter52,
		Encounter53,
		Encounter54,
		Encounter55,
		Encounter56,
		Encounter57,
		Encounter58,
		Encounter59,
		Encounter60,
		Encounter61,
		Encounter62,
		Encounter63,
		Encounter64,
		Encounter65,
		Encounter66,
		Encounter67,
		Encounter68,
		Encounter69,
		Encounter70,
		Encounter71,
		Encounter72,
		Encounter73,
		Encounter74,
		Encounter75,
		Encounter76,
		Encounter77,
		Encounter78,
		Encounter79,
		Encounter80,
		Encounter81,
		Encounter82,
		Encounter83,
		Encounter84,
		Encounter85,
		Encounter86,
		Encounter87,
		Encounter88,
		Encounter89,
		Encounter90,
		Encounter91,
		Encounter92,
		Encounter93,
		Encounter94,
		Encounter95,
		Encounter96,
		Encounter97,
		Encounter98,
		Encounter99,
		Encounter100,
		Encounter101,
		Encounter102,
		Encounter103,
		Encounter104,
		Encounter105,
		Encounter106,
		Encounter107,
		Encounter108,
		Encounter109,
		Encounter110,
		Encounter111,
		Encounter112,
		Encounter113,
		Encounter114,
		Encounter115,
		Encounter116,
		Encounter117,
		Encounter118,
		Encounter119,
		Encounter120,
		Encounter121,
		Encounter122,
		Encounter123,
		Encounter124,
		Encounter125,
		Encounter126,
		Encounter127,
		Encounter128,
		Encounter129,
		Encounter130,
		Encounter131,
		Encounter132,
		Encounter133,
		Encounter134,
		Encounter135,
		Encounter136,
		Encounter137,
		Encounter138,
		Encounter139,
		Encounter140,
		Encounter141,
		Encounter142,
		Encounter143,
		Encounter144,
		Encounter145,
		Encounter146,
		Encounter147,
		Encounter148,
		Encounter149,
		Encounter150,
		Encounter151,
		Encounter152,
		Encounter153,
		Encounter154,
		Encounter155,
		Encounter156,
		Encounter157,
		Encounter158,
		Encounter159,
		Encounter160,
		Encounter161,
		Encounter162,
		Encounter163,
		Encounter164,
		Encounter165,
		Encounter166,
		Encounter167,
		Encounter168,
		Encounter169,
		Encounter170,
		Encounter171,
		Encounter172,
		Encounter173,
		Encounter174,
		Encounter175,
		Encounter176,
		Encounter177,
		Encounter178,
		Encounter179,
		Encounter180,
		Encounter181,
		Encounter182,
		Encounter183,
		Encounter184,
		Encounter185,
		Encounter186,
		Encounter187,
		Encounter188,
		Encounter189,
		Encounter190,
		Encounter191,
		Encounter192,
		Encounter193,
		Encounter194,
		Encounter195,
		Encounter196,
		Encounter197,
		Encounter198,
		Encounter199,
		Encounter200,
		Encounter201,
		Encounter202,
		Encounter203,
		Encounter204,
		Encounter205,
		Encounter206,
		Encounter207,
		Encounter208,
		Encounter209,
		Encounter210,
		Encounter211,
		Encounter212,
		Encounter213,
		Encounter214,
		Encounter215,
		Encounter216,
		Encounter217,
		Encounter218,
		Encounter219,
		Encounter220,
		Encounter221,
		Encounter222,
		Encounter223,
		Encounter224,
		Encounter225,
		Encounter226,
		Encounter227,
		Encounter228,
		Encounter229,
		Encounter230,
		Encounter231,
		Encounter232,
		Encounter233,
		Encounter234,
		Encounter235,
		Encounter236,
		Encounter237,
		Encounter238,
		Encounter239,
		Encounter240,
		Encounter241,
		Encounter242,
		Encounter243,
		Encounter244,
		Encounter245,
		Encounter246,
		Encounter247,
		Encounter248,
		Encounter249,
		Encounter250,
		Encounter251,
		Encounter252,
		Encounter253,
		Encounter254,
		Encounter255,
		Encounter256,
		Encounter257,
		Encounter258,
		Encounter259,
		Encounter260,
		Encounter261,
		Encounter262,
		Encounter263,
		Encounter264,
		Encounter265,
		Encounter266,
		Encounter267,
		Encounter268,
		Encounter269,
		Encounter270,
		Encounter271,
		Encounter272,
		Encounter273,
		Encounter274,
		Encounter275,
		Encounter276,
		Encounter277,
		Encounter278,
		Encounter279,
		Encounter280,
		Encounter281,
		Encounter282,
		Encounter283,
		Encounter284,
		Encounter285,
		Encounter286,
		Encounter287,
		Encounter288,
		Encounter289,
		Encounter290,
		Encounter291,
		Encounter292,
		Encounter293,
		Encounter294,
		Encounter295,
		Encounter296,
		Encounter297,
		Encounter298,
		Encounter299,
		Encounter300,
		Encounter301,
		Encounter302,
		Encounter303,
		Encounter304,
		Encounter305,
		Encounter306,
		Encounter307,
		Encounter308,
		Encounter309,
		Encounter310,
		Encounter311,
		Encounter312,
		Encounter313,
		Encounter314,
		Encounter315,
		Encounter316,
		Encounter317,
		Encounter318,
		Encounter319,
		Encounter320,
		Encounter321,
		Encounter322,
		Encounter323,
		Encounter324,
		Encounter325,
		Encounter326,
		Encounter327,
		Encounter328,
		Encounter329,
		Encounter330,
		Encounter331,
		Encounter332,
		Encounter333,
		Encounter334,
		Encounter335,
		Encounter336,
		Encounter337,
		Encounter338,
		Encounter339,
		Encounter340,
		Encounter341,
		Encounter342,
		Encounter343,
		Encounter344,
		Encounter345,
		Encounter346,
		Encounter347,
		Encounter348,
		Encounter349,
		Encounter350,
		Encounter351,
		Encounter352,
		Encounter353,
		Encounter354,
		Encounter355,
		Encounter356,
		Encounter357,
		Encounter358,
		Encounter359,
		Encounter360,
		Encounter361,
		Encounter362,
		Encounter363,
		Encounter364,
		Encounter365,
		Encounter366,
		Encounter367,
		Encounter368,
		Encounter369,
		Encounter370,
		Encounter371,
		Encounter372,
		Encounter373,
		Encounter374,
		Encounter375,
		Encounter376,
		Encounter377,
		Encounter378,
		Encounter379,
		Encounter380,
		Encounter381,
		Encounter382,
		Encounter383,
		Encounter384,
		Encounter385,
		Encounter386,
		Encounter387,
		Encounter388,
		Encounter389,
		Encounter390,
		Encounter391,
		Encounter392,
		Encounter393,
		Encounter394,
		Encounter395,
		Encounter396,
		Encounter397,
		Encounter398,
		Encounter399,
		Encounter400,
		Encounter401,
		Encounter402,
		Encounter403,
		Encounter404,
		Encounter405,
		Encounter406,
		Encounter407,
		Encounter408,
		Encounter409,
		Encounter410,
		Encounter411,
		Encounter412,
		Encounter413,
		Encounter414,
		Encounter415,
		Encounter416,
		Encounter417,
		Encounter418,
		Encounter419,
		Encounter420,
		Encounter421,
		Encounter422,
		Encounter423,
		Encounter424,
		Encounter425,
		Encounter426,
		Encounter427,
		Encounter428,
		Encounter429,
		Encounter430,
		Encounter431,
		Encounter432,
		Encounter433,
		Encounter434,
		Encounter435,
		Encounter436,
		Encounter437,
		Encounter438,
		Encounter439,
		Encounter440,
		Encounter441,
		Encounter442,
		Encounter443,
		Encounter444,
		Encounter445,
		Encounter446,
		Encounter447,
		Encounter448,
		Encounter449,
		Encounter450,
		Encounter451,
		Encounter452,
		Encounter453,
		Encounter454,
		Encounter455,
		Encounter456,
		Encounter457,
		Encounter458,
		Encounter459,
		Encounter460,
		Encounter461,
		Encounter462,
		Encounter463,
		Encounter464,
		Encounter465,
		Encounter466,
		Encounter467,
		Encounter468,
		Encounter469,
		Encounter470,
		Encounter471,
		Encounter472,
		Encounter473,
		Encounter474,
		Encounter475,
		Encounter476,
		Encounter477,
		Encounter478,
		Encounter479,
		Encounter480,
		Encounter481,
		Encounter482,
		Encounter483,
		Encounter484,
		Encounter485,
		Encounter486,
		Encounter487,
		Encounter488,
		Encounter489,
		Encounter490,
		Encounter491,
		Encounter492,
		Encounter493,
		Encounter494,
		Encounter495,
		Encounter496,
		Encounter497,
		Encounter498,
		Encounter499,
		Encounter500,
		Encounter501,
		Encounter502,
		Encounter503,
		Encounter504,
		Encounter505,
		Encounter506,
		Encounter507,
		Encounter508,
		Encounter509,
		Encounter510,
		Encounter511,
		Encounter512,
		Encounter513,
		Encounter514,
		Encounter515,
		Encounter516,
		Encounter517,
		Encounter518,
		Encounter519,
		Encounter520,
		Encounter521,
		Encounter522,
		Encounter523,
		Encounter524,
		Encounter525,
		Encounter526,
		Encounter527,
		Encounter528,
		Encounter529,
		Encounter530,
		Encounter531,
		Encounter532,
		Encounter533,
		Encounter534,
		Encounter535,
		Encounter536,
		Encounter537,
		Encounter538,
		Encounter539,
		Encounter540,
		Encounter541,
		Encounter542,
		Encounter543,
		Encounter544,
		Encounter545,
		Encounter546,
		Encounter547,
		Encounter548,
		Encounter549,
		Encounter550,
		Encounter551,
		Encounter552,
		Encounter553,
		Encounter554,
		Encounter555,
		Encounter556,
		Encounter557,
		Encounter558,
		Encounter559,
		Encounter560,
		Encounter561,
		Encounter562,
		Encounter563,
		Encounter564,
		Encounter565,
		Encounter566,
		Encounter567,
		Encounter568,
		Encounter569,
		Encounter570,
		Encounter571,
		Encounter572,
		Encounter573,
		Encounter574,
		Encounter575,
		Encounter576,
		Encounter577,
		Encounter578,
		Encounter579,
		Encounter580,
		Encounter581,
		Encounter582,
		Encounter583,
		Encounter584,
		Encounter585,
		Encounter586,
		Encounter587,
		Encounter588,
		Encounter589,
		Encounter590,
		Encounter591,
		Encounter592,
		Encounter593,
		Encounter594,
		Encounter595,
		Encounter596,
		Encounter597,
		Encounter598,
		Encounter599,
		Encounter600,
		Encounter601,
		Encounter602,
		Encounter603,
		Encounter604,
		Encounter605,
		Encounter606,
		Encounter607,
		Encounter608,
		Encounter609,
		Encounter610,
		Encounter611,
		Encounter612,
		Encounter613,
		Encounter614,
		Encounter615,
		Encounter616,
		Encounter617,
		Encounter618,
		Encounter619,
		Encounter620,
		Encounter621,
		Encounter622,
		Encounter623,
		Encounter624,
		Encounter625,
		Encounter626,
		Encounter627,
		Encounter628,
		Encounter629,
		Encounter630,
		Encounter631,
		Encounter632,
		Encounter633,
		Encounter634,
		Encounter635,
		Encounter636,
		Encounter637,
		Encounter638,
		Encounter639,
		Encounter640,
		Encounter641,
		Encounter642,
		Encounter643,
		Encounter644,
		Encounter645,
		Encounter646,
		Encounter647,
		Encounter648,
		Encounter649,
		Encounter650,
		Encounter651,
		Encounter652,
		Encounter653,
		Encounter654,
		Encounter655,
		Encounter656,
		Encounter657,
		Encounter658,
		Encounter659,
		Encounter660,
		Encounter661,
		Encounter662,
		Encounter663,
		Encounter664,
		Encounter665,
		Encounter666,
		Encounter667,
		Encounter668,
		Encounter669,
		Encounter670,
		Encounter671,
		Encounter672,
		Encounter673,
		Encounter674,
		Encounter675,
		Encounter676,
		Encounter677,
		Encounter678,
		Encounter679,
		Encounter680,
		Encounter681,
		Encounter682,
		Encounter683,
		Encounter684,
		Encounter685,
		Encounter686,
		Encounter687,
		Encounter688,
		Encounter689,
		Encounter690,
		Encounter691,
		Encounter692,
		Encounter693,
		Encounter694,
		Encounter695,
		Encounter696,
		Encounter697,
		Encounter698,
		Encounter699,
		Encounter700,
		Encounter701,
		Encounter702,
		Encounter703,
		Encounter704,
		Encounter705,
		Encounter706,
		Encounter707,
		Encounter708,
		Encounter709,
		Encounter710,
		Encounter711,
		Encounter712,
		Encounter713,
		Encounter714,
		Encounter715,
		Encounter716,
		Encounter717,
		Encounter718,
		Encounter719,
		Encounter720,
		Encounter721,
		Encounter722,
		Encounter723,
		Encounter724,
		Encounter725,
		Encounter726,
		Encounter727,
		Encounter728,
		Encounter729,
		Encounter730,
		Encounter731,
		Encounter732,
		Encounter733,
		Encounter734,
		Encounter735,
		Encounter736,
		Encounter737,
		Encounter738,
		Encounter739,
		Encounter740,
		Encounter741,
		Encounter742,
		Encounter743,
		Encounter744,
		Encounter745,
		Encounter746,
		Encounter747,
		Encounter748,
		Encounter749,
		Encounter750,
		Encounter751,
		Encounter752,
		Encounter753,
		Encounter754,
		Encounter755,
        MeraktusTheTormented
    }

    public class MiniChampTypeInfo
    {
        public int Required { get; set; }
        public Type SpawnType { get; set; }

        public MiniChampTypeInfo(int required, Type spawnType)
        {
            Required = required;
            SpawnType = spawnType;
        }
    }

    public class MiniChampLevelInfo
    {
        public MiniChampTypeInfo[] Types { get; set; }

        public MiniChampLevelInfo(params MiniChampTypeInfo[] types)
        {
            Types = types;
        }
    }

    public class MiniChampInfo
    {
        public MiniChampLevelInfo[] Levels { get; set; }
        public Type EssenceType { get; set; }

        public int MaxLevel { get { return Levels == null ? 0 : Levels.Length; } }

        public MiniChampInfo(Type essenceType, params MiniChampLevelInfo[] levels)
        {
            Levels = levels;
            EssenceType = essenceType;
        }

        public MiniChampLevelInfo GetLevelInfo(int level)
        {
            level--;

            if (level >= 0 && level < Levels.Length)
                return Levels[level];

            return null;
        }

        public static MiniChampInfo[] Table { get { return m_Table; } }

        private static readonly MiniChampInfo[] m_Table = new MiniChampInfo[]
        {
            new MiniChampInfo // Crimson Veins
            (
                typeof(EssencePrecision),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(20, typeof(FireAnt)),
                    new MiniChampTypeInfo(10, typeof(LavaSnake)),
                    new MiniChampTypeInfo(10, typeof(LavaLizard))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(5, typeof(Efreet)),
                    new MiniChampTypeInfo(5, typeof(FireGargoyle))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(10, typeof(LavaElemental)),
                    new MiniChampTypeInfo(5, typeof(FireDaemon))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(FireElementalRenowned))
                )
            ),
            new MiniChampInfo // Fairy Dragon Lair
            (
                typeof(EssenceDiligence),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(25, typeof(FairyDragon))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(Wyvern))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(10, typeof(ForgottenServant))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(WyvernRenowned))
                )
            ),
            new MiniChampInfo // Abyssal Lair
            (
                typeof(EssenceAchievement),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(20, typeof(GreaterMongbat)),
                    new MiniChampTypeInfo(20, typeof(Imp))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(Daemon))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(PitFiend))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(DevourerRenowned))
                )
            ),
            new MiniChampInfo // Discarded Cavern Clan Ribbon
            (
                typeof(EssenceBalance),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(ClanRibbonPlagueRat)),
                    new MiniChampTypeInfo(10, typeof(ClanRS))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(ClanRibbonPlagueRat)),
                    new MiniChampTypeInfo(10, typeof(ClanRC))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(VitaviRenowned))
                )
            ),
            new MiniChampInfo // Discarded Cavern Clan Scratch
            (
                typeof(EssenceBalance),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(ClanSSW)),
                    new MiniChampTypeInfo(10, typeof(ClanSS))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(ClanSSW)),
                    new MiniChampTypeInfo(10, typeof(ClanSH))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(TikitaviRenowned))
                )
            ),
            new MiniChampInfo // Discarded Cavern Clan Chitter
            (
                typeof(EssenceBalance),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
                    new MiniChampTypeInfo(10, typeof(ClanCA))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
                    new MiniChampTypeInfo(10, typeof(ClanCT))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(RakktaviRenowned))
                )
            ),
            new MiniChampInfo // Passage of Tears
            (
                typeof(EssenceSingularity),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(AcidSlug)),
                    new MiniChampTypeInfo(20, typeof(CorrosiveSlime))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(AcidElemental))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(3, typeof(InterredGrizzle))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(AcidElementalRenowned))
                )
            ),
            new MiniChampInfo // Lands of the Lich
            (
                typeof(EssenceDirection),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(5, typeof(Wraith)),
                    new MiniChampTypeInfo(10, typeof(Spectre)),
                    new MiniChampTypeInfo(5, typeof(Shade)),
                    new MiniChampTypeInfo(30, typeof(Skeleton)),
                    new MiniChampTypeInfo(20, typeof(Zombie))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(5, typeof(BoneMagi)),
                    new MiniChampTypeInfo(10, typeof(SkeletalMage)),
                    new MiniChampTypeInfo(10, typeof(BoneKnight)),
                    new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
                    new MiniChampTypeInfo(10, typeof(WailingBanshee))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(SkeletalLich)),
                    new MiniChampTypeInfo(20, typeof(RottingCorpse))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(AncientLichRenowned))
                )
            ),
            new MiniChampInfo // Secret Garden
            (
                typeof(EssenceFeeling),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(20, typeof(Pixie))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(15, typeof(Wisp))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(10, typeof(DarkWisp))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(PixieRenowned))
                )
            ),
            new MiniChampInfo // Fire Temple Ruins
            (
                typeof(EssenceOrder),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(20, typeof(LavaSnake)),
                    new MiniChampTypeInfo(10, typeof(LavaLizard)),
                    new MiniChampTypeInfo(10, typeof(FireAnt))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(LavaSerpent)),
                    new MiniChampTypeInfo(10, typeof(HellCat)),
                    new MiniChampTypeInfo(10, typeof(HellHound))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(FireDaemon)),
                    new MiniChampTypeInfo(10, typeof(LavaElemental))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(FireDaemonRenowned))
                )
            ),
            new MiniChampInfo // Enslaved Goblins
            (
                typeof(EssenceControl),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(EnslavedGrayGoblin)),
                    new MiniChampTypeInfo(15, typeof(EnslavedGreenGoblin))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(EnslavedGoblinScout)),
                    new MiniChampTypeInfo(10, typeof(EnslavedGoblinKeeper))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(EnslavedGoblinMage)),
                    new MiniChampTypeInfo(5, typeof(EnslavedGreenGoblinAlchemist))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(GrayGoblinMageRenowned)),
                    new MiniChampTypeInfo(1, typeof(GreenGoblinAlchemistRenowned))
                )
            ),
            new MiniChampInfo // Skeletal Dragon
            (
                typeof(EssencePersistence),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(5, typeof(PatchworkSkeleton)),
                    new MiniChampTypeInfo(15, typeof(Skeleton))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(5, typeof(BoneKnight)),
                    new MiniChampTypeInfo(5, typeof(SkeletalKnight))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(BoneMagi)),
                    new MiniChampTypeInfo(2, typeof(SkeletalMage))
                ),
                new MiniChampLevelInfo // Level 4
                (
                    new MiniChampTypeInfo(2, typeof(SkeletalLich))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(SkeletalDragonRenowned))
                )
            ),
            new MiniChampInfo // Lava Caldera
            (
                typeof(EssencePassion),
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(10, typeof(LavaSnake)),
                    new MiniChampTypeInfo(10, typeof(LavaLizard)),
                    new MiniChampTypeInfo(20, typeof(FireAnt))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(10, typeof(LavaSerpent)),
                    new MiniChampTypeInfo(10, typeof(HellCat)),
                    new MiniChampTypeInfo(10, typeof(HellHound))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(5, typeof(FireDaemon)),
                    new MiniChampTypeInfo(10, typeof(LavaElemental))
                ),
                new MiniChampLevelInfo // Renowned
                (
                    new MiniChampTypeInfo(1, typeof(FireDaemonRenowned))
                )
            ),
            new MiniChampInfo // Meraktus the Tormented
            (
                null,
                new MiniChampLevelInfo // Level 1
                (
                    new MiniChampTypeInfo(20, typeof(Minotaur))
                ),
                new MiniChampLevelInfo // Level 2
                (
                    new MiniChampTypeInfo(20, typeof(MinotaurScout))
                ),
                new MiniChampLevelInfo // Level 3
                (
                    new MiniChampTypeInfo(15, typeof(MinotaurCaptain))
                ),
                new MiniChampLevelInfo // Level 4
                (
                    new MiniChampTypeInfo(15, typeof(MinotaurCaptain))
                ),
                new MiniChampLevelInfo // Champion
                (
                    new MiniChampTypeInfo(1, typeof(Meraktus))
                )
            ),
		new MiniChampInfo // Anvil Hurler Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(IronSmith)),
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BronzeElemental)),
				new MiniChampTypeInfo(5, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AnvilHurler))
			)
		),
		new MiniChampInfo // Aquatic Tamer Lagoon
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(15, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Kraken)),
				new MiniChampTypeInfo(10, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AquaticTamer))
			)
		),
		new MiniChampInfo // Arcane Scribe Enclave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(ElementalWizard))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArcaneScribe))
			)
		),
		new MiniChampInfo // Arctic Naturalist Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IceSnake)),
				new MiniChampTypeInfo(10, typeof(IceElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArcticNaturalist))
			)
		),
		new MiniChampInfo // Armor Curer Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(BattleDressmaker)),
				new MiniChampTypeInfo(15, typeof(ArrowFletcher)),
				new MiniChampTypeInfo(15, typeof(GemCutter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SlimeMage)),
				new MiniChampTypeInfo(10, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArmorCurer))
			)
		),
		new MiniChampInfo // Arrow Fletcher's Roost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(CrossbowMarksman)),
				new MiniChampTypeInfo(15, typeof(LongbowSniper)),
				new MiniChampTypeInfo(10, typeof(JavelinAthlete))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShieldBearer)),
				new MiniChampTypeInfo(5, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArrowFletcher))
			)
		),
		new MiniChampInfo // Ascetic Hermit's Refuge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SpiritMedium)),
				new MiniChampTypeInfo(15, typeof(ZenMonk)),
				new MiniChampTypeInfo(10, typeof(QiGongHealer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AsceticHermit))
			)
		),
		new MiniChampInfo // Astrologer's Observatory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScrollMage)),
				new MiniChampTypeInfo(15, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(FireMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Astrologer))
			)
		),
		new MiniChampInfo // Banneret's Bastion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwordDefender)),
				new MiniChampTypeInfo(15, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(10, typeof(KnightOfJustice))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RapierDuelist)),
				new MiniChampTypeInfo(10, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(5, typeof(KnightOfValor))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Banneret))
			)
		),
		new MiniChampInfo // Battle Dressmaker's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GemCutter)),
				new MiniChampTypeInfo(15, typeof(BattleWeaver)),
				new MiniChampTypeInfo(10, typeof(ToxicologistChef))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WoolWeaver)),
				new MiniChampTypeInfo(10, typeof(AnvilHurler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BattlefieldHealer)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BattleDressmaker))
			)
		),
		new MiniChampInfo // Battlefield Healer's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CombatMedic)),
				new MiniChampTypeInfo(15, typeof(CombatNurse)),
				new MiniChampTypeInfo(10, typeof(FieldCommander))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(QiGongHealer)),
				new MiniChampTypeInfo(5, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BattlefieldHealer))
			)
		),
		new MiniChampInfo // Battle Herbalist Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkWisp)),
				new MiniChampTypeInfo(5, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BattleHerbalist))
			)
		),
		new MiniChampInfo // Battle Storm Caller's Eye
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(StormConjurer)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(ElementalWizard))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AirElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BattleHerbalist))
			)
		),
		new MiniChampInfo // Battle Weaver Loom
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BattleWeaver)),
				new MiniChampTypeInfo(15, typeof(WoolWeaver)),
				new MiniChampTypeInfo(10, typeof(ArrowFletcher))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GemCutter)),
				new MiniChampTypeInfo(10, typeof(ToxicologistChef))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BattleWeaver))
			)
		),
		new MiniChampInfo // Beastmaster's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Lion)),
				new MiniChampTypeInfo(15, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Cougar)),
				new MiniChampTypeInfo(10, typeof(BigCatTamer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(Beastmaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Beastmaster))
			)
		),
		new MiniChampInfo // Big Cat Tamer Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Cougar)),
				new MiniChampTypeInfo(10, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DireWolf)),
				new MiniChampTypeInfo(10, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WhiteWolf)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BigCatTamer))
			)
		),
		new MiniChampInfo // Biologist’s Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PestilentBandage)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Biologist))
			)
		),
		new MiniChampInfo // Bird Trainer’s Aviary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Bird)),
				new MiniChampTypeInfo(10, typeof(Chicken)),
				new MiniChampTypeInfo(10, typeof(Macaw))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Phoenix)),
				new MiniChampTypeInfo(5, typeof(Crane))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BirdTrainer))
			)
		),
		new MiniChampInfo // Bone Shielder Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneKnight)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BoneShielder))
			)
		),
		new MiniChampInfo // Boomerang Thrower Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CrossbowMarksman)),
				new MiniChampTypeInfo(15, typeof(JavelinAthlete))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BoomerangThrower))
			)
		),
		new MiniChampInfo // Cabinet Maker's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(BattleWeaver)),
				new MiniChampTypeInfo(10, typeof(WoolWeaver))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AnvilHurler)),
				new MiniChampTypeInfo(10, typeof(GemCutter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IronSmith)),
				new MiniChampTypeInfo(5, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CabinetMaker))
			)
		),
		new MiniChampInfo // Carver's Atelier
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ArrowFletcher)),
				new MiniChampTypeInfo(15, typeof(BattleDressmaker)),
				new MiniChampTypeInfo(10, typeof(GemCutter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(AnvilHurler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(5, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Carver))
			)
		),
		new MiniChampInfo // Chemist's Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(SlimeMage)),
				new MiniChampTypeInfo(10, typeof(ToxicologistChef))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(BloodElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Chemist))
			)
		),
		new MiniChampInfo // Choir Singer's Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Flutist)),
				new MiniChampTypeInfo(10, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChoirSinger))
			)
		),
		new MiniChampInfo // Clockwork Engineer's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IronSmith)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ClockworkEngineer))
			)
		),
		new MiniChampInfo // Clue Seeker's Puzzle Grounds
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SafeCracker)),
				new MiniChampTypeInfo(5, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ClueSeeker))
			)
		),
		new MiniChampInfo // Combat Medic's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FieldCommander)),
				new MiniChampTypeInfo(10, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(10, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer)),
				new MiniChampTypeInfo(10, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(QiGongHealer)),
				new MiniChampTypeInfo(5, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CombatMedic))
			)
		),
		new MiniChampInfo // Combat Nurse's Recovery Ward
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CombatNurse)),
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HolyKnight)),
				new MiniChampTypeInfo(5, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CombatNurse))
			)
		),
		new MiniChampInfo // Con Artist's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapSetter)),
				new MiniChampTypeInfo(5, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ConArtist))
			)
		),
		new MiniChampInfo // Contortionist's Circus
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(5, typeof(MushroomWitch))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Contortionist))
			)
		),
		new MiniChampInfo // Crime Scene Tech Investigation
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(15, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NoirDetective)),
				new MiniChampTypeInfo(5, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrimeSceneTech))
			)
		),
		new MiniChampInfo // Crossbow Marksman Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LongbowSniper)),
				new MiniChampTypeInfo(15, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(BoomerangThrower))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrossbowMarksman))
			)
		),
		new MiniChampInfo // Crying Orphan Refuge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(15, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CryingOrphan))
			)
		),
		new MiniChampInfo // Cryptologist's Chamber
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkElf)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Cryptologist))
			)
		),
		new MiniChampInfo // Dark Sorcerer Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DarkSorcerer))
			)
		),
		new MiniChampInfo // Death Cultist Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(15, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(GhostScout))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WailingBanshee)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Revenant)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DeathCultist))
			)
		),
		new MiniChampInfo // Decoy Deployer Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Infiltrator)),
				new MiniChampTypeInfo(5, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DecoyDeployer))
			)
		),
		new MiniChampInfo // Deep Miner Excavation
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Golem)),
				new MiniChampTypeInfo(15, typeof(IronSmith)),
				new MiniChampTypeInfo(10, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BronzeElemental)),
				new MiniChampTypeInfo(10, typeof(DullCopperElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(ValoriteElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DeepMiner))
			)
		),
		new MiniChampInfo // Demolition Expert Quarry
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapEngineer)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DemolitionExpert))
			)
		),
		new MiniChampInfo // Desert Naturalist Oasis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(Lizardman)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Lizardman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Yamandon)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DesertNaturalist))
			)
		),
		new MiniChampInfo // Desert Tracker's Oasis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(EarthElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EarthElemental)),
				new MiniChampTypeInfo(10, typeof(CopperElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Yamandon)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DesertTracker))
			)
		),
		new MiniChampInfo // Diplomat's Parley
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Diplomat))
			)
		),
		new MiniChampInfo // Disguise Master's Haven
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapSetter)),
				new MiniChampTypeInfo(5, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DisguiseMaster))
			)
		),
		new MiniChampInfo // Diviner's Peak
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ZenMonk)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PsychedelicShaman)),
				new MiniChampTypeInfo(10, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StormConjurer)),
				new MiniChampTypeInfo(5, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Diviner))
			)
		),
		new MiniChampInfo // Drum Boy's Spectacle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Flutist)),
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DrumBoy))
			)
		),
		new MiniChampInfo // Drummer's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Flutist)),
				new MiniChampTypeInfo(15, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RaveRogue)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Drummer))
			)
		),
		new MiniChampInfo // Dual Wielder Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(15, typeof(SabreFighter)),
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DualWielder))
			)
		),
		new MiniChampInfo // Earth Alchemist's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SlimeMage)),
				new MiniChampTypeInfo(15, typeof(ToxicologistChef)),
				new MiniChampTypeInfo(10, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(DullCopperElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EarthAlchemist))
			)
		),
		new MiniChampInfo // Electrician's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LightningBearer)),
				new MiniChampTypeInfo(15, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Electrician))
			)
		),
		new MiniChampInfo // Elemental Wizard's Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(FireElemental)),
				new MiniChampTypeInfo(10, typeof(IceElemental)),
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AirElemental)),
				new MiniChampTypeInfo(10, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ElementalWizard))
			)
		),
		new MiniChampInfo // Enchanter's Labyrinth
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Magician)),
				new MiniChampTypeInfo(15, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Enchanter))
			)
		),
		new MiniChampInfo // Epee Specialist Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FencingMaster)),
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SabreFighter)),
				new MiniChampTypeInfo(5, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EpeeSpecialist))
			)
		),
		new MiniChampInfo // Escape Artist Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(Spy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EscapeArtist))
			)
		),
		new MiniChampInfo // Evidence Analyst's Bureau
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(15, typeof(NoirDetective)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EvidenceAnalyst))
			)
		),
		new MiniChampInfo // Evil Map Maker's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(15, typeof(ArrowFletcher)),
				new MiniChampTypeInfo(10, typeof(GemCutter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EvilMapMaker))
			)
		),
		new MiniChampInfo // Explorer's Expedition
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(UrbanTracker)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwampThing)),
				new MiniChampTypeInfo(5, typeof(Treefellow))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Explorer))
			)
		),
		new MiniChampInfo // Explosive Demolitionist's Foundry
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(OrcBomber)),
				new MiniChampTypeInfo(15, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ExplosiveDemolitionist))
			)
		),
		new MiniChampInfo // Feast Master's Banquet
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(Lion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantToad)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FeastMaster))
			)
		),
		new MiniChampInfo // Fencing Master's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FencingMaster)),
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(5, typeof(LongbowSniper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FencingMaster))
			)
		),
		new MiniChampInfo // Field Commander Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfValor)),
				new MiniChampTypeInfo(15, typeof(Banneret)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FieldCommander)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SabreFighter)),
				new MiniChampTypeInfo(5, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FieldCommander))
			)
		),
		new MiniChampInfo // Field Medic Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CombatMedic)),
				new MiniChampTypeInfo(15, typeof(CombatNurse)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WardCaster)),
				new MiniChampTypeInfo(10, typeof(QiGongHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SpiritMedium)),
				new MiniChampTypeInfo(5, typeof(ZenMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FieldMedic))
			)
		),
		new MiniChampInfo // Fire Alchemist Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(15, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaElemental)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FireAlchemist))
			)
		),
		new MiniChampInfo // Fire Mage Conclave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireMage)),
				new MiniChampTypeInfo(10, typeof(Magician)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(Efreet))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Balron)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FireMage))
			)
		),
		new MiniChampInfo // Firestarter Pyre
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireAnt)),
				new MiniChampTypeInfo(15, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireGargoyle)),
				new MiniChampTypeInfo(10, typeof(FireElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Efreet)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Firestarter))
			)
		),
		new MiniChampInfo // Flame Welder Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireGargoyle)),
				new MiniChampTypeInfo(10, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(Efreet))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlameWelder))
			)
		),
		new MiniChampInfo // Forager's Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(AppleElemental)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestRanger)),
				new MiniChampTypeInfo(5, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Forager))
			)
		),
		new MiniChampInfo // Forensic Analyst's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(5, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForensicAnalyst))
			)
		),
		new MiniChampInfo // Forest Minstrel's Glen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SatyrPiper)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForestMinstrel))
			)
		),
		new MiniChampInfo // Forest Scout Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(UrbanTracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForestScout))
			)
		),
		new MiniChampInfo // Forest Tracker Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(15, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(UrbanTracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SatyrPiper)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForestTracker))
			)
		),
		new MiniChampInfo // Gem Cutter Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GemCutter)),
				new MiniChampTypeInfo(10, typeof(CrystalElemental)),
				new MiniChampTypeInfo(10, typeof(BronzeElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(CopperElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GemCutter))
			)
		),
		new MiniChampInfo // Ghost Scout Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GhostScout)),
				new MiniChampTypeInfo(10, typeof(RestlessSoul)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GhostScout))
			)
		),
		new MiniChampInfo // Ghost Warrior Battlefield
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GhostWarrior)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GhostWarrior))
			)
		),
		new MiniChampInfo // Gourmet Chef Kitchen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ToxicologistChef)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MushroomWitch)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlimeMage)),
				new MiniChampTypeInfo(5, typeof(BogThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GourmetChef))
			)
		),
		new MiniChampInfo // Grave Digger Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Zombie)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wight)),
				new MiniChampTypeInfo(10, typeof(Ghoul))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GraveDigger))
			)
		),
		new MiniChampInfo // Greco-Roman Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(15, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KnightOfValor)),
				new MiniChampTypeInfo(5, typeof(KnightOfJustice))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GrecoRomanWrestler))
			)
		),
		new MiniChampInfo // Grill Master Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaSnake)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HellHound)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaElemental)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GrillMaster))
			)
		),
		new MiniChampInfo // Hammer Guard Armory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RapierDuelist)),
				new MiniChampTypeInfo(15, typeof(SabreFighter)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AnvilHurler)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IronSmith)),
				new MiniChampTypeInfo(5, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HammerGuard))
			)
		),
		new MiniChampInfo // Harpist's Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ForestRanger)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(Pixie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DarkWisp)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyQueen)),
				new MiniChampTypeInfo(5, typeof(Wisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Harpist))
			)
		),
		new MiniChampInfo // Herbalist Poisoner Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonElemental)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BogThing)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HerbalistPoisoner))
			)
		),
		new MiniChampInfo // Ice Sorcerer Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(IceSnake)),
				new MiniChampTypeInfo(15, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IceElemental)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IceSorcerer))
			)
		),
		new MiniChampInfo // Illusionist's Labyrinth
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkElf)),
				new MiniChampTypeInfo(5, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Illusionist))
			)
		),
		new MiniChampInfo // Infiltrator's Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(Spy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(5, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Infiltrator))
			)
		),
		new MiniChampInfo // Invisible Saboteur's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Saboteur)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InvisibleSaboteur))
			)
		),
		new MiniChampInfo // Iron Smith Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DullCopperElemental)),
				new MiniChampTypeInfo(15, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(10, typeof(BronzeElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CrystalElemental)),
				new MiniChampTypeInfo(10, typeof(GoldenElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ValoriteElemental)),
				new MiniChampTypeInfo(5, typeof(VeriteElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IronSmith))
			)
		),
		new MiniChampInfo // Javelin Athlete Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScoutNinja)),
				new MiniChampTypeInfo(15, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(CrossbowMarksman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoomerangThrower)),
				new MiniChampTypeInfo(10, typeof(LongbowSniper))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SabreFighter)),
				new MiniChampTypeInfo(5, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JavelinAthlete))
			)
		),
		new MiniChampInfo // Joiner Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(15, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(AnvilHurler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GemCutter)),
				new MiniChampTypeInfo(10, typeof(BattleWeaver))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(5, typeof(ArrowFletcher))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Joiner))
			)
		),
		new MiniChampInfo // Jungle Naturalist Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SerpentHandler)),
				new MiniChampTypeInfo(15, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenHag)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JungleNaturalist))
			)
		),
		new MiniChampInfo // Karate Expert Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(10, typeof(Samurai)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenNinja)),
				new MiniChampTypeInfo(5, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KarateExpert))
			)
		),
		new MiniChampInfo // Katana Duelist Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Samurai)),
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kunoichi)),
				new MiniChampTypeInfo(5, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KatanaDuelist))
			)
		),
		new MiniChampInfo // Knife Thrower's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BoomerangThrower)),
				new MiniChampTypeInfo(15, typeof(JavelinAthlete)),
				new MiniChampTypeInfo(10, typeof(CrossbowMarksman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(5, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KnifeThrower))
			)
		),
		new MiniChampInfo // Knight of Justice Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(15, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KnightOfJustice))
			)
		),
		new MiniChampInfo // Knight of Mercy Chapel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(15, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer)),
				new MiniChampTypeInfo(10, typeof(QiGongHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ZenMonk)),
				new MiniChampTypeInfo(5, typeof(EtherealWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KnightOfMercy))
			)
		),
		new MiniChampInfo // Knight of Valor Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfValor)),
				new MiniChampTypeInfo(15, typeof(Banneret))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RamRider)),
				new MiniChampTypeInfo(10, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(FencingMaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KnightOfValor))
			)
		),
		new MiniChampInfo // Kunoichi Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScoutNinja)),
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(Samurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Kunoichi))
			)
		),
		new MiniChampInfo // Librarian Custodian's Archive
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RuneCaster)),
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(ScrollMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkWisp)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LibrarianCustodian))
			)
		),
		new MiniChampInfo // Lightning Bearer's Storm Nexus
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(ElementalWizard))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AirElemental)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LightningBearer))
			)
		),
		new MiniChampInfo // Locksmith's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Spy)),
				new MiniChampTypeInfo(5, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Locksmith))
			)
		),
		new MiniChampInfo // Logician's Puzzle Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Magician)),
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Logician))
			)
		),
		new MiniChampInfo // Longbow Sniper Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CrossbowMarksman)),
				new MiniChampTypeInfo(15, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GrecoRomanWrestler)),
				new MiniChampTypeInfo(5, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LongbowSniper))
			)
		),
		new MiniChampInfo // Luchador Training Grounds
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(15, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SwordDefender)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Samurai)),
				new MiniChampTypeInfo(5, typeof(BoomerangThrower))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Luchador))
			)
		),
		new MiniChampInfo // Magician's Arcane Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScrollMage)),
				new MiniChampTypeInfo(15, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Magician))
			)
		),
		new MiniChampInfo // Martial Monk Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(15, typeof(ZenMonk)),
				new MiniChampTypeInfo(10, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MartialMonk))
			)
		),
		new MiniChampInfo // Master Flutist's Concert
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Flutist)),
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GlamRockMage)),
				new MiniChampTypeInfo(5, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SlyStoryteller))
			)
		),
		new MiniChampInfo // Thieves' Guild Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(5, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MasterPickpocket))
			)
		),
		new MiniChampInfo // Mechanic's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(15, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(Golem))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SlimeMage)),
				new MiniChampTypeInfo(10, typeof(RenaissanceMechanic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CrystalElemental)),
				new MiniChampTypeInfo(5, typeof(BronzeElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Mechanic))
			)
		),
		new MiniChampInfo // Muscle Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(Minotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MuscleBrute))
			)
		),
		new MiniChampInfo // Necromancer's Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lich)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneMagi)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroSummoner))
			)
		),
		new MiniChampInfo // Toxic Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(PestilentBandage)),
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NerveAgent))
			)
		),
		new MiniChampInfo // Net Caster Reef
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(AntLion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NetCaster))
			)
		),
		new MiniChampInfo // Nymph Singer Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(Pixie)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(Wisp))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkWisp)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NymphSinger))
			)
		),
		new MiniChampInfo // Oracle's Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SpiritMedium)),
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(ZenMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Oracle))
			)
		),
		new MiniChampInfo // Pastry Chef's Bakery
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ToxicologistChef)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(WoolWeaver))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(BogThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PastryChef))
			)
		),
		new MiniChampInfo // Patchwork Monster Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(15, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(InterredGrizzle)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PatchworkMonster))
			)
		),
		new MiniChampInfo // Pathologist's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Pathologist))
			)
		),
		new MiniChampInfo // Phantom Assassin's Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SneakyNinja)),
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Kunoichi)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PhantomAssassin))
			)
		),
		new MiniChampInfo // Pickpocket's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ConArtist)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Pickpocket))
			)
		),
		new MiniChampInfo // Pocket Picker's Refuge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PocketPicker))
			)
		),
		new MiniChampInfo // Protester's Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FloridaMan)),
				new MiniChampTypeInfo(15, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Protester)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Protester))
			)
		),
		new MiniChampInfo // Qi Gong Healer Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BattlefieldHealer)),
				new MiniChampTypeInfo(15, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ZenMonk)),
				new MiniChampTypeInfo(10, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(QiGongHealer))
			)
		),
		new MiniChampInfo // Quantum Physicist Research Facility
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(15, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(QuantumPhysicist))
			)
		),
		new MiniChampInfo // Ram Rider Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(Savage)),
				new MiniChampTypeInfo(15, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SavageShaman)),
				new MiniChampTypeInfo(5, typeof(HellHound))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RamRider))
			)
		),
		new MiniChampInfo // Rapier Duelist Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SabreFighter)),
				new MiniChampTypeInfo(10, typeof(LongbowSniper))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FencingMaster)),
				new MiniChampTypeInfo(5, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RapierDuelist))
			)
		),
		new MiniChampInfo // Relativist Observatory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(15, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Relativist))
			)
		),
		new MiniChampInfo // Relic Hunter Expedition
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Infiltrator)),
				new MiniChampTypeInfo(15, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RelicHunter))
			)
		),
		new MiniChampInfo // Rune Caster Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ElementalWizard)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RuneCaster))
			)
		),
		new MiniChampInfo // Rune Keeper Chamber
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkElf)),
				new MiniChampTypeInfo(5, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RuneKeeper))
			)
		),
		new MiniChampInfo // Saboteur Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(15, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(5, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Saboteur))
			)
		),
		new MiniChampInfo // Sabre Fighter Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SabreFighter)),
				new MiniChampTypeInfo(15, typeof(SwordDefender)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RapierDuelist)),
				new MiniChampTypeInfo(5, typeof(LongbowSniper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SabreFighter))
			)
		),
		new MiniChampInfo // Safecracker's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Infiltrator)),
				new MiniChampTypeInfo(5, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SafeCracker))
			)
		),
		new MiniChampInfo // Samurai Master's Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kunoichi)),
				new MiniChampTypeInfo(5, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SamuraiMaster))
			)
		),
		new MiniChampInfo // Satyr Piper's Glen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pixie)),
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HostileDruid)),
				new MiniChampTypeInfo(5, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SatyrPiper))
			)
		),
		new MiniChampInfo // Sawmill Worker's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(BattleWeaver)),
				new MiniChampTypeInfo(15, typeof(ArrowFletcher))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SawmillWorker))
			)
		),
		new MiniChampInfo // Scout Archer's Refuge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(LongbowSniper)),
				new MiniChampTypeInfo(10, typeof(CrossbowMarksman)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(BoomerangThrower))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScoutArcher))
			)
		),
		new MiniChampInfo // Scout Leader Encampment
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ForestScout)),
				new MiniChampTypeInfo(15, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(UrbanTracker)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenNinja)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScoutLeader))
			)
		),
		new MiniChampInfo // Ninja Shadow Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapSetter)),
				new MiniChampTypeInfo(5, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScoutNinja))
			)
		),
		new MiniChampInfo // Scroll Mage’s Tower
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScrollMage)),
				new MiniChampTypeInfo(15, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Magician)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ElementalWizard)),
				new MiniChampTypeInfo(5, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScrollMage))
			)
		),
		new MiniChampInfo // Serpent Handler Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(GiantSerpent)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lizardman)),
				new MiniChampTypeInfo(10, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilverSerpent)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SerpentHandler))
			)
		),
		new MiniChampInfo // Shadow Lurker Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Shade)),
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ghoul)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WailingBanshee)),
				new MiniChampTypeInfo(5, typeof(Revenant))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowLurker))
			)
		),
		new MiniChampInfo // Shadow Priest Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowPriest))
			)
		),
		new MiniChampInfo // Sheepdog Handler's Pen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Dog)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Sheep))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreyWolf)),
				new MiniChampTypeInfo(5, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SheepdogHandler))
			)
		),
		new MiniChampInfo // Shield Bearer's Bastion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SwordDefender)),
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(KnightOfJustice))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HolyKnight)),
				new MiniChampTypeInfo(10, typeof(CombatMedic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(5, typeof(FieldCommander))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShieldBearer))
			)
		),
		new MiniChampInfo // Shield Maiden's Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(KnightOfMercy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwordDefender)),
				new MiniChampTypeInfo(5, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShieldMaiden))
			)
		),
		new MiniChampInfo // Sly Storyteller's Theatre
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Spy)),
				new MiniChampTypeInfo(15, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SlyStoryteller))
			)
		),
		new MiniChampInfo // Sous Chef’s Kitchen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ToxicologistChef)),
				new MiniChampTypeInfo(10, typeof(MushroomWitch)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SousChef))
			)
		),
		new MiniChampInfo // Spear Fisher’s Cove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(CoralSnake)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpearFisher))
			)
		),
		new MiniChampInfo // Spear Sentry Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SabreFighter)),
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SumoWrestler)),
				new MiniChampTypeInfo(5, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpearSentry))
			)
		),
		new MiniChampInfo // Spellbreaker’s Trial
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Magician)),
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Spellbreaker))
			)
		),
		new MiniChampInfo // Spirit Medium’s Seance
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SpiritMedium)),
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WailingBanshee)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpiritMedium))
			)
		),
		new MiniChampInfo // Spy Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Infiltrator)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Spy))
			)
		),
		new MiniChampInfo // Star Reader Observatory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StarReader))
			)
		),
		new MiniChampInfo // Storm Conjurer Summit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(AirElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormConjurer))
			)
		),
		new MiniChampInfo // Strategist’s War Table
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist)),
				new MiniChampTypeInfo(10, typeof(FieldCommander))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SwordDefender)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Samurai)),
				new MiniChampTypeInfo(5, typeof(TaekwondoMaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Strategist))
			)
		),
		new MiniChampInfo // Sumo Wrestler Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(10, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(JavelinAthlete))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantToad)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SumoWrestler))
			)
		),
		new MiniChampInfo // Sword Defender Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RapierDuelist)),
				new MiniChampTypeInfo(5, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SwordDefender))
			)
		),
		new MiniChampInfo // Taekwondo Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenNinja)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TaekwondoMaster))
			)
		),
		new MiniChampInfo // Terrain Scout Encampment
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(UrbanTracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TerrainScout))
			)
		),
		new MiniChampInfo // Toxicologist's Kitchen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(SlimeMage)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicologistChef))
			)
		),
		new MiniChampInfo // Trap Engineer Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapEngineer)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrapEngineer))
			)
		),
		new MiniChampInfo // Trap Maker's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapEngineer)),
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrapMaker))
			)
		),
		new MiniChampInfo // Trap Setter's Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(Spy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Infiltrator)),
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrapSetter))
			)
		),
		new MiniChampInfo // Tree Feller's Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Treefellow)),
				new MiniChampTypeInfo(10, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TreeFeller))
			)
		),
		new MiniChampInfo // Trick Shot Artist's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LongbowSniper)),
				new MiniChampTypeInfo(10, typeof(CrossbowMarksman)),
				new MiniChampTypeInfo(10, typeof(JavelinAthlete))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SabreFighter)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(5, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrickShotArtist))
			)
		),
		new MiniChampInfo // Urban Tracker's Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(UrbanTracker))
			)
		),
		new MiniChampInfo // Trap Maker's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(Mimic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrapMaker))
			)
		),
		new MiniChampInfo // Venomous Assassin's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonElemental)),
				new MiniChampTypeInfo(10, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SpeckledScorpion)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousAssassin))
			)
		),
		new MiniChampInfo // Violinist's Orchestra
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(5, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Violinist))
			)
		),
		new MiniChampInfo // Ward Caster's Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer)),
				new MiniChampTypeInfo(10, typeof(WardCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(QiGongHealer)),
				new MiniChampTypeInfo(10, typeof(ZenMonk))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WardCaster))
			)
		),
		new MiniChampInfo // Water Alchemist's Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SlimeMage)),
				new MiniChampTypeInfo(15, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(CorrosiveSlime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidElemental)),
				new MiniChampTypeInfo(10, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(5, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WaterAlchemist))
			)
		),
		new MiniChampInfo // Weapon Enchanter's Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ElementalWizard)),
				new MiniChampTypeInfo(10, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WeaponEnchanter))
			)
		),
		new MiniChampInfo // Wool Weaver's Loom
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(20, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(JackRabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WoolWeaver)),
				new MiniChampTypeInfo(10, typeof(BattleWeaver))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(5, typeof(Forager))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WoolWeaver))
			)
		),
		new MiniChampInfo // Zen Monk's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(QiGongHealer)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ZenMonk)),
				new MiniChampTypeInfo(10, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(DarkWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ZenMonk))
			)
		),
		new MiniChampInfo // Air Clan Ninja Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AirClanNinja))
			)
		),
		new MiniChampInfo // Air Clan Samurai Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Samurai)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(LongbowSniper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwordDefender)),
				new MiniChampTypeInfo(5, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AirClanSamurai))
			)
		),
		new MiniChampInfo // Alien Warrior Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AlienWarrior))
			)
		),
		new MiniChampInfo // Apple Grove Elemental
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AppleElemental))
			)
		),
		new MiniChampInfo // Assassin Guild Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(15, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ConArtist)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Assassin))
			)
		),
		new MiniChampInfo // Astral Traveler Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(GhostScout))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AstralTraveler))
			)
		),
		new MiniChampInfo // Avatar of Elements Shrine
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(FireElemental)),
				new MiniChampTypeInfo(10, typeof(WaterElemental)),
				new MiniChampTypeInfo(10, typeof(AirElemental)),
				new MiniChampTypeInfo(10, typeof(EarthElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidElemental)),
				new MiniChampTypeInfo(10, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CrystalElemental)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AvatarOfElements))
			)
		),
		new MiniChampInfo // Baroque Barbarian Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BaroqueBarbarian)),
				new MiniChampTypeInfo(15, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HolyKnight)),
				new MiniChampTypeInfo(5, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BaroqueBarbarian))
			)
		),
		new MiniChampInfo // Beetle Juice Summoning Circle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(AntLion)),
				new MiniChampTypeInfo(10, typeof(BlackSolenWarrior)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BeetleJuiceSummoner))
			)
		),
		new MiniChampInfo // Biomancer’s Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BogThing)),
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Biomancer))
			)
		),
		new MiniChampInfo // Blues Singing Gorgon Amphitheater
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BluesSingingGorgon))
			)
		),
		new MiniChampInfo // B-Movie Beastmaster Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(VorpalBunny))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CabaretKrakenGirl)),
				new MiniChampTypeInfo(10, typeof(AntLion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantIceWorm)),
				new MiniChampTypeInfo(5, typeof(PatchworkMonster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BmovieBeastmaster))
			)
		),
		new MiniChampInfo // Bounty Hunter Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Brigand)),
				new MiniChampTypeInfo(10, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Infiltrator)),
				new MiniChampTypeInfo(5, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BountyHunter))
			)
		),
		new MiniChampInfo // Cabaret Kraken Stage
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CabaretKrakenGirl)),
				new MiniChampTypeInfo(10, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RaveRogue)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CabaretKrakenGirl))
			)
		),
		new MiniChampInfo // Cannibal Tribe Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Savage)),
				new MiniChampTypeInfo(10, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(PatchworkMonster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Cannibal))
			)
		),
		new MiniChampInfo // Caveman Scientist Experiment Site
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Ogre)),
				new MiniChampTypeInfo(15, typeof(Cyclops)),
				new MiniChampTypeInfo(15, typeof(Ettin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(PatchworkMonster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CavemanScientist))
			)
		),
		new MiniChampInfo // Celestial Samurai Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Samurai)),
				new MiniChampTypeInfo(15, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialSamurai))
			)
		),
		new MiniChampInfo // Chris Roberts Galactic Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChrisRoberts))
			)
		),
		new MiniChampInfo // Corporate Executive Tower
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Spy)),
				new MiniChampTypeInfo(5, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CorporateExecutive))
			)
		),
		new MiniChampInfo // Country Cowgirl Cyclops Ranch
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Cougar)),
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(Minotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CountryCowgirlCyclops))
			)
		),
		new MiniChampInfo // Wild West Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Cowboy))
			)
		),
		new MiniChampInfo // Cyberpunk Nexus
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(5, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CyberpunkSorcerer))
			)
		),
		new MiniChampInfo // Harvest Festival Frenzy
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AppleElemental))
			)
		),
		new MiniChampInfo // Dark Elf Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TwistedCultist)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyQueen)),
				new MiniChampTypeInfo(5, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DarkElf))
			)
		),
		new MiniChampInfo // Shadow Lord's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DarkLord))
			)
		),
		new MiniChampInfo // Dino Rider Expedition
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GreatHart)),
				new MiniChampTypeInfo(10, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CuSidhe)),
				new MiniChampTypeInfo(10, typeof(Hiryu))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SerpentineDragon)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DinoRider))
			)
		),
		new MiniChampInfo // Disco Druid Festival
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pixie)),
				new MiniChampTypeInfo(15, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DiscoDruid))
			)
		),
		new MiniChampInfo // Dog the Bounty Hunter's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Brigand)),
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Spy)),
				new MiniChampTypeInfo(5, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DogtheBountyHunter))
			)
		),
		new MiniChampInfo // Duelist Poet Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RapierDuelist)),
				new MiniChampTypeInfo(15, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SwordDefender)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GlamRockMage)),
				new MiniChampTypeInfo(5, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DuelistPoet))
			)
		),
		new MiniChampInfo // Earth Clan Ninja Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(15, typeof(Kunoichi)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(TrapSetter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EarthClanNinja))
			)
		),
		new MiniChampInfo // Earth Clan Samurai Encampment
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(15, typeof(Samurai)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(JukaWarrior)),
				new MiniChampTypeInfo(5, typeof(JukaLord))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EarthClanSamurai))
			)
		),
		new MiniChampInfo // Evil Alchemist Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SlimeMage)),
				new MiniChampTypeInfo(15, typeof(PoisonElemental)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EvilAlchemist))
			)
		),
		new MiniChampInfo // Evil Clown Carnival
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GlamRockMage)),
				new MiniChampTypeInfo(15, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EvilClown))
			)
		),
		new MiniChampInfo // Fairy Queen Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pixie)),
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DarkWisp)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenHag)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FairyQueen))
			)
		),
		new MiniChampInfo // Fast Explorer Expedition
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScoutNinja)),
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FastExplorer))
			)
		),
		new MiniChampInfo // Fire Clan Ninja Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(10, typeof(FireMage)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FireClanNinja))
			)
		),
		new MiniChampInfo // Fire Clan Samurai Dojo
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Samurai)),
				new MiniChampTypeInfo(10, typeof(SwordDefender)),
				new MiniChampTypeInfo(10, typeof(BoomerangThrower))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(SumoWrestler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FireClanSamurai))
			)
		),
		new MiniChampInfo // Flapper Elementalist Altar
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(AirElemental)),
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WindElemental)),
				new MiniChampTypeInfo(5, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlapperElementalist))
			)
		),
		new MiniChampInfo // Florida Man’s Carnival
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Protester)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(10, typeof(GhostScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FloridaMan))
			)
		),
		new MiniChampInfo // Forest Ranger Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BigCatTamer)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CuSidhe)),
				new MiniChampTypeInfo(5, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForestRanger))
			)
		),
		new MiniChampInfo // Funk Fungi Familiar Garden
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(15, typeof(MushroomWitch))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BogThing)),
				new MiniChampTypeInfo(5, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FunkFungiFamiliar))
			)
		),
		new MiniChampInfo // Gang Leader's Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pickpocket)),
				new MiniChampTypeInfo(15, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Saboteur)),
				new MiniChampTypeInfo(5, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GangLeader))
			)
		),
		new MiniChampInfo // Glam Rock Mage Concert
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(15, typeof(Flutist)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GlamRockMage))
			)
		),
		new MiniChampInfo // Gothic Novelist Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RestlessSoul)),
				new MiniChampTypeInfo(15, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GhostScout)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lich)),
				new MiniChampTypeInfo(5, typeof(GhostWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GothicNovelist))
			)
		),
		new MiniChampInfo // Graffiti Gargoyle Alley
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GraffitiGargoyle))
			)
		),
		new MiniChampInfo // Greaser Gryphon Rider’s Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GlamRockMage)),
				new MiniChampTypeInfo(15, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(MegaDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GreaserGryphonRider))
			)
		),
		new MiniChampInfo // Green Hag’s Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonElemental)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenHag)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GreenHag))
			)
		),
		new MiniChampInfo // Green Ninja’s Hidden Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GreenNinja))
			)
		),
		new MiniChampInfo // Hippie Hoplite’s Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(Pixie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestRanger)),
				new MiniChampTypeInfo(5, typeof(HippieHoplite))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HippieHoplite))
			)
		),
		new MiniChampInfo // Holy Knight’s Cathedral
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(10, typeof(KnightOfValor))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HolyKnight)),
				new MiniChampTypeInfo(10, typeof(Paladin))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SpiritMedium)),
				new MiniChampTypeInfo(5, typeof(QiGongHealer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HolyKnight2))
			)
		),
		new MiniChampInfo // Sanctuary of the Holy Knight
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(SwordDefender)),
				new MiniChampTypeInfo(15, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(15, typeof(KnightOfMercy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FieldCommander)),
				new MiniChampTypeInfo(5, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HolyKnight))
			)
		),
		new MiniChampInfo // Hostile Druid’s Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HostileDruid))
			)
		),
		new MiniChampInfo // Hostile Princess’ Court
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DisguiseMaster)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HostilePrincess))
			)
		),
		new MiniChampInfo // Ice King’s Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(IceSnake)),
				new MiniChampTypeInfo(15, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IceElemental)),
				new MiniChampTypeInfo(10, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDragon)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IceKing))
			)
		),
		new MiniChampInfo // Inferno Dragon’s Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoDragon))
			)
		),
		new MiniChampInfo // Insane Roboticist Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InsaneRoboticist))
			)
		),
		new MiniChampInfo // Jazz Age Brawl
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NoirDetective)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JazzAgeJuggernaut))
			)
		),
		new MiniChampInfo // Jester’s Court
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(Flutist)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GothicNovelist)),
				new MiniChampTypeInfo(5, typeof(MushroomWitch))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Jester))
			)
		),
		new MiniChampInfo // Lawyer’s Tribunal
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ConArtist)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SafeCracker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(10, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Lawyer))
			)
		),
		new MiniChampInfo // Line Dragon’s Ascent
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(15, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Dragon)),
				new MiniChampTypeInfo(10, typeof(Drake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PlatinumDrake)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LineDragon))
			)
		),
		new MiniChampInfo // Lord Blackthorn's Dominion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(DarkElf)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Infiltrator)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Assassin)),
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LordBlackthorn))
			)
		),
		new MiniChampInfo // Lord British's Summoning Circle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HolyKnight)),
				new MiniChampTypeInfo(15, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LordBritishSummoner))
			)
		),
		new MiniChampInfo // Magma Elemental Rift
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaLizard)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(FireGargoyle))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MagmaElemental))
			)
		),
		new MiniChampInfo // Medieval Meteorologist's Observatory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(LightningBearer)),
				new MiniChampTypeInfo(10, typeof(AirElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SnowElemental)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MedievalMeteorologist))
			)
		),
		new MiniChampInfo // Mega Dragon's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Drake)),
				new MiniChampTypeInfo(15, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyDragon)),
				new MiniChampTypeInfo(10, typeof(SerpentineDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MegaDragon))
			)
		),
		new MiniChampInfo // Minax Sorceress Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(DarkElf)),
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(ScrollMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MinaxSorceress))
			)
		),
		new MiniChampInfo // Mischievous Witch Coven
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MischievousWitch))
			)
		),
		new MiniChampInfo // Motown Mermaid Lagoon
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Kraken)),
				new MiniChampTypeInfo(10, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MotownMermaid))
			)
		),
		new MiniChampInfo // Mushroom Witch Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bogling)),
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MushroomWitch))
			)
		),
		new MiniChampInfo // Musketeer Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RapierDuelist)),
				new MiniChampTypeInfo(15, typeof(SabreFighter)),
				new MiniChampTypeInfo(10, typeof(EpeeSpecialist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DualWielder)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShieldBearer)),
				new MiniChampTypeInfo(5, typeof(CombatMedic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Musketeer))
			)
		),
		new MiniChampInfo // NeoVictorian Vampire Court
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(DarkElf)),
				new MiniChampTypeInfo(10, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VampireBat)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodElemental)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NeoVictorianVampire))
			)
		),
		new MiniChampInfo // Ninja Librarian Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScoutNinja)),
				new MiniChampTypeInfo(15, typeof(Kunoichi)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Saboteur)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NinjaLibrarian))
			)
		),
		new MiniChampInfo // Noir Detective Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(NoirDetective)),
				new MiniChampTypeInfo(15, typeof(SafeCracker)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Spy)),
				new MiniChampTypeInfo(10, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapSetter)),
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NoirDetective))
			)
		),
		new MiniChampInfo // Ogre Master's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ogre)),
				new MiniChampTypeInfo(15, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(Ettin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(OgreMaster))
			)
		),
		new MiniChampInfo // Phoenix Style Master's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SumoWrestler)),
				new MiniChampTypeInfo(15, typeof(TaekwondoMaster)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(10, typeof(BoomerangThrower))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PhoenixStyleMaster))
			)
		),
		new MiniChampInfo // Pig Farmer's Pen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(JackRabbit)),
				new MiniChampTypeInfo(10, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PigFarmer))
			)
		),
		new MiniChampInfo // Pinup Pandemonium Parlor
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GlamRockMage)),
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Flutist)),
				new MiniChampTypeInfo(5, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PinupPandemonium))
			)
		),
		new MiniChampInfo // Pirate's Cove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Brigand)),
				new MiniChampTypeInfo(15, typeof(GhostWarrior)),
				new MiniChampTypeInfo(10, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Kraken)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CoralSnake)),
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Pirate))
			)
		),
		new MiniChampInfo // Pirate of the Stars Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(15, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(RetroAndroid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PirateOfTheStars))
			)
		),
		new MiniChampInfo // PK Murderer's Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Assassin)),
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(DecoyDeployer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MasterPickpocket)),
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ScoutNinja)),
				new MiniChampTypeInfo(5, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PKMurderer))
			)
		),
		new MiniChampInfo // Bloodstained Fields
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Assassin)),
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DualWielder)),
				new MiniChampTypeInfo(5, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PKMurdererLord))
			)
		),
		new MiniChampInfo // Corrupted Orchard
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(Slime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PestilentBandage)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PoisonAppleTree))
			)
		),
		new MiniChampInfo // Mystic Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PsychedelicShaman)),
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(Wisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DarkWisp)),
				new MiniChampTypeInfo(10, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PsychedelicShaman))
			)
		),
		new MiniChampInfo // Alchemical Lab
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(15, typeof(SlimeMage)),
				new MiniChampTypeInfo(10, typeof(GemCutter))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicologistChef)),
				new MiniChampTypeInfo(10, typeof(BattlefieldHealer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(BloodElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PulpyPotionPurveyor))
			)
		),
		new MiniChampInfo // Rebel Cathedral
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GlamRockMage)),
				new MiniChampTypeInfo(15, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HolyKnight)),
				new MiniChampTypeInfo(5, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PunkRockPaladin))
			)
		),
		new MiniChampInfo // Ra King's Pyramid
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lich)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RaKing))
			)
		),
		new MiniChampInfo // Ranch Master's Prairie
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(Cow)),
				new MiniChampTypeInfo(10, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bull)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreatHart)),
				new MiniChampTypeInfo(5, typeof(Lion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RanchMaster))
			)
		),
		new MiniChampInfo // Rap Ranger's Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ForestScout)),
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(UrbanTracker))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kirin)),
				new MiniChampTypeInfo(5, typeof(Unicorn))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RapRanger))
			)
		),
		new MiniChampInfo // Rave Rogue's Underground
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(15, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(Pickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(5, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RaveRogue))
			)
		),
		new MiniChampInfo // Red Queen's Court
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HolyKnight)),
				new MiniChampTypeInfo(10, typeof(KnightOfMercy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RapierDuelist)),
				new MiniChampTypeInfo(5, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RedQueen))
			)
		),
		new MiniChampInfo // Reggae Runesmith Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(ArcaneScribe))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireMage)),
				new MiniChampTypeInfo(5, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ReggaeRunesmith))
			)
		),
		new MiniChampInfo // Renaissance Mechanic Factory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapEngineer)),
				new MiniChampTypeInfo(15, typeof(Carpenter)),
				new MiniChampTypeInfo(10, typeof(IronSmith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RenaissanceMechanic))
			)
		),
		new MiniChampInfo // Retro Android Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(StarCitizen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RetroAndroid))
			)
		),
		new MiniChampInfo // Retro Futurist Dome
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(15, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RetroFuturist))
			)
		),
		new MiniChampInfo // Retro Robot Romancer's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(15, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RetroRobotRomancer))
			)
		),
		new MiniChampInfo // Ringmaster's Circus
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Flutist)),
				new MiniChampTypeInfo(10, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CabaretKrakenGirl)),
				new MiniChampTypeInfo(5, typeof(SlyStoryteller))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Ringmaster))
			)
		),
		new MiniChampInfo // Rockabilly Revenant's Stage
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(GhostScout)),
				new MiniChampTypeInfo(15, typeof(GothicNovelist)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Revenant)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(GhostWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RockabillyRevenant))
			)
		),
		new MiniChampInfo // Scorpomancer's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SpeckledScorpion)),
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Scorpomancer))
			)
		),
		new MiniChampInfo // Silent Movie Studio
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(15, typeof(NoirDetective)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Spy)),
				new MiniChampTypeInfo(5, typeof(ConArtist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SilentMovieMonk))
			)
		),
		new MiniChampInfo // Silver Slime Caverns
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Sith))
			)
		),
		new MiniChampInfo // Sith Academy
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(10, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(10, typeof(Impaler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(Balron))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Sith))
			)
		),
		new MiniChampInfo // Ska Skald Concert Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DrumBoy)),
				new MiniChampTypeInfo(15, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SkaSkald))
			)
		),
		new MiniChampInfo // Skeleton Lord Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SkeletonLord))
			)
		),
		new MiniChampInfo // Slime Mage Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SlimeMage))
			)
		),
		new MiniChampInfo // Sneaky Ninja Clan
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScoutNinja)),
				new MiniChampTypeInfo(15, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SneakyNinja))
			)
		),
		new MiniChampInfo // Star Citizen Outpost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StarCitizen))
			)
		),
		new MiniChampInfo // Starfleet Captain's Command
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(15, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StarfleetCaptain))
			)
		),
		new MiniChampInfo // Starfleet Command Center
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(15, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AncientWyrm))
			)
		),
		new MiniChampInfo // Steampunk Samurai Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(RetroAndroid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Saboteur)),
				new MiniChampTypeInfo(10, typeof(DualWielder))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(BloodElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SteampunkSamurai))
			)
		),
		new MiniChampInfo // Stormtrooper Academy
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Balron))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EvilAlchemist))
			)
		),
		new MiniChampInfo // Surfer Summoner Cove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WaterElemental)),
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AquaticTamer)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(Kraken))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SurferSummoner))
			)
		),
		new MiniChampInfo // Swamp Thing Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SwampThing))
			)
		),
		new MiniChampInfo // Swingin' Sorceress Ballroom
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GlamRockMage)),
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RaveRogue)),
				new MiniChampTypeInfo(5, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SwinginSorceress))
			)
		),
		new MiniChampInfo // Texan Rancher Prairie
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Horse)),
				new MiniChampTypeInfo(15, typeof(Cow)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(RidableLlama))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(GreatHart))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TexanRancher))
			)
		),
		new MiniChampInfo // Twisted Cultist Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TwistedCultist)),
				new MiniChampTypeInfo(10, typeof(DarkElf)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TwistedCultist))
			)
		),
		new MiniChampInfo // Vaudeville Valkyrie Stage
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkaSkald)),
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VaudevilleValkyrie))
			)
		),
		new MiniChampInfo // Wasteland Biker Compound
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(15, typeof(OrcBrute)),
				new MiniChampTypeInfo(10, typeof(Brigand))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SavageShaman)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(OgreLord)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WastelandBiker))
			)
		),
		new MiniChampInfo // Water Clan Ninja Hideout
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(15, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(Kunoichi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(Saboteur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WaterElemental)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WaterClanNinja))
			)
		),
		new MiniChampInfo // Water Clan Samurai Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Samurai)),
				new MiniChampTypeInfo(15, typeof(KatanaDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AquaticTamer)),
				new MiniChampTypeInfo(5, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WaterClanSamurai))
			)
		),
		new MiniChampInfo // Wild West Wizard Canyon
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(15, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WildWestWizard))
			)
		),
		new MiniChampInfo // Abbadon the Abyssal
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Imp)),
				new MiniChampTypeInfo(15, typeof(GreaterMongbat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Daemon)),
				new MiniChampTypeInfo(10, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Balron)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbbadonTheAbyssal))
			)
		),
		new MiniChampInfo // Abyssal Warden
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(15, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(EffetePutridGargoyle))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbyssalWarden))
			)
		),
		new MiniChampInfo // Abyssinian Tracker
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ForestScout)),
				new MiniChampTypeInfo(15, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(GreenGoblinScout))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbyssinianTracker))
			)
		),
		new MiniChampInfo // Acidic Alligator
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(AcidSlug)),
				new MiniChampTypeInfo(15, typeof(CorrosiveSlime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidElemental)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BullFrog)),
				new MiniChampTypeInfo(5, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AcidicAlligator))
			)
		),
		new MiniChampInfo // Ancient Alligator
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BullFrog)),
				new MiniChampTypeInfo(15, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lizardman)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilverSerpent)),
				new MiniChampTypeInfo(5, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AncientAlligator))
			)
		),
		new MiniChampInfo // Ancient Dragon's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Drake)),
				new MiniChampTypeInfo(15, typeof(SerpentineDragon)),
				new MiniChampTypeInfo(10, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostDragon)),
				new MiniChampTypeInfo(10, typeof(PlatinumDrake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(GreaterDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AncientDragon))
			)
		),
		new MiniChampInfo // Angus Berserker's Camp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwordDefender)),
				new MiniChampTypeInfo(15, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(10, typeof(RapierDuelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(CombatMedic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DualWielder)),
				new MiniChampTypeInfo(5, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AngusBerserker))
			)
		),
		new MiniChampInfo // Banshee's Wail
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Lich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WailingBanshee)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Banshee))
			)
		),
		new MiniChampInfo // Banshee Crab's Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(CoralSnake)),
				new MiniChampTypeInfo(10, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WailingBanshee)),
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BansheeCrab))
			)
		),
		new MiniChampInfo // Bengal Storm's Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Cougar)),
				new MiniChampTypeInfo(15, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Beastmaster)),
				new MiniChampTypeInfo(5, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BengalStorm))
			)
		),
		new MiniChampInfo // Bison Brute Plateau
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bull)),
				new MiniChampTypeInfo(15, typeof(GreatHart)),
				new MiniChampTypeInfo(10, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BisonBrute))
			)
		),
		new MiniChampInfo // Black Widow's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(AntLion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlackWidowQueen))
			)
		),
		new MiniChampInfo // Blight Demon Fissure
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlightDemon))
			)
		),
		new MiniChampInfo // Blood Dragon Roost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(CrimsonDrake)),
				new MiniChampTypeInfo(15, typeof(Dragon)),
				new MiniChampTypeInfo(10, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Drake)),
				new MiniChampTypeInfo(10, typeof(SerpentineDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(GreaterDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BloodDragon))
			)
		),
		new MiniChampInfo // Bloodthirsty Vines Thicket
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Forager)),
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(BogThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BloodthirstyVines))
			)
		),
		new MiniChampInfo // Abyssal Bouncer's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(10, typeof(OrcBrute)),
				new MiniChampTypeInfo(10, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Minotaur)),
				new MiniChampTypeInfo(10, typeof(OgreLord))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DemonKnight)),
				new MiniChampTypeInfo(5, typeof(Balron))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbyssalBouncer))
			)
		),
		new MiniChampInfo // Abyssal Panther's Prowl
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(ScoutNinja)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbyssalPanther))
			)
		),
		new MiniChampInfo // Abyssal Tide's Surge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AbyssalTide))
			)
		),
		new MiniChampInfo // Acererak's Necropolis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Acererak))
			)
		),
		new MiniChampInfo // Acidic Slime's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(CorrosiveSlime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidElemental)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(InterredGrizzle))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AcidicSlime))
			)
		),
		new MiniChampInfo // Aegis Construct Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Golem)),
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CrystalElemental)),
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BronzeElemental)),
				new MiniChampTypeInfo(5, typeof(AcidElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AegisConstruct))
			)
		),
		new MiniChampInfo // Akhenaten's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(Wight)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lich)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AkhenatenTheHeretic))
			)
		),
		new MiniChampInfo // Akhenaten's Heretic Shrine
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lich)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AkhenatenTheHeretic))
			)
		),
		new MiniChampInfo // Albert's Squirrel Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(JackRabbit)),
				new MiniChampTypeInfo(10, typeof(Bird))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VorpalBunny)),
				new MiniChampTypeInfo(10, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantToad)),
				new MiniChampTypeInfo(5, typeof(Wisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AlbertsSquirrel))
			)
		),
		new MiniChampInfo // Ancient Wolf Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(LeatherWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AncientWolf))
			)
		),
		new MiniChampInfo // Anthrax Rat Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantRat)),
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonElemental)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AnthraxRat))
			)
		),
		new MiniChampInfo // Arbiter Drone Hive
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(AntLion)),
				new MiniChampTypeInfo(15, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WolfSpider)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArbiterDrone))
			)
		),
		new MiniChampInfo // Arcane Satyr Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(Pixie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DarkElf)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wisp)),
				new MiniChampTypeInfo(5, typeof(DarkWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArcaneSatyr))
			)
		),
		new MiniChampInfo // Arcane Sentinel Bastion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Enchanter)),
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ArcaneSentinel))
			)
		),
		new MiniChampInfo // Aries Harpy Aerie
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Crane)),
				new MiniChampTypeInfo(15, typeof(Eagle)),
				new MiniChampTypeInfo(15, typeof(Parrot))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Phoenix)),
				new MiniChampTypeInfo(10, typeof(Harpy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StoneHarpy)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AriesHarpy))
			)
		),
		new MiniChampInfo // Aries Ram Bear Plateau
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(15, typeof(MountainGoat)),
				new MiniChampTypeInfo(15, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AriesRamBear))
			)
		),
		new MiniChampInfo // Azalin Rex's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(10, typeof(Lich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RottingCorpse)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AzalinRex))
			)
		),
		new MiniChampInfo // Azure Mirage's Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Wisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DarkWisp)),
				new MiniChampTypeInfo(10, typeof(Pixie))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyDragon)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AzureMirage))
			)
		),
		new MiniChampInfo // Azure Moose Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ForestScout)),
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CuSidhe)),
				new MiniChampTypeInfo(5, typeof(Kirin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(AzureMoose))
			)
		),
		new MiniChampInfo // Babirusa Beast's Bog
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PatchworkMonster)),
				new MiniChampTypeInfo(5, typeof(PlatinumDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BabirusaBeast))
			)
		),
		new MiniChampInfo // Alpha Baboon Troop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Gorilla)),
				new MiniChampTypeInfo(15, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Savage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreatHart)),
				new MiniChampTypeInfo(5, typeof(Yamandon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BaboonsAlpha))
			)
		),
		new MiniChampInfo // Bearded Goat Pastures
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Goat)),
				new MiniChampTypeInfo(15, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BeardedGoat))
			)
		),
		new MiniChampInfo // Beldings Ground Squirrel Burrow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(JackRabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(LeatherWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VorpalBunny)),
				new MiniChampTypeInfo(5, typeof(GreatHart))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BeldingsGroundSquirrel))
			)
		),
		new MiniChampInfo // Black Death Rat Sewers
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRibbonPlagueRat)),
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlackDeathRat))
			)
		),
		new MiniChampInfo // Black Widow Queen Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(AntLion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlackWidowQueen))
			)
		),
		new MiniChampInfo // Blighted Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BullFrog)),
				new MiniChampTypeInfo(10, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(Slime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlightedToad))
			)
		),
		new MiniChampInfo // Blood Lich's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Ghoul)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BloodLich))
			)
		),
		new MiniChampInfo // Blood Serpent's Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Snake)),
				new MiniChampTypeInfo(10, typeof(IceSnake)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(SilverSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantSerpent)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BloodSerpent))
			)
		),
		new MiniChampInfo // Bonecrusher Ogre's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(Ettin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(Minotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BonecrusherOgre))
			)
		),
		new MiniChampInfo // Bone Golem's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneMagi)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BoneGolem))
			)
		),
		new MiniChampInfo // Borneo Pigsty
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pig)),
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(Rabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BorneoPig))
			)
		),
		new MiniChampInfo // Bubblegum Blaster Factory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(Bogling))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Imp)),
				new MiniChampTypeInfo(5, typeof(Mimic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BubblegumBlaster))
			)
		),
		new MiniChampInfo // Bush Pig Encampment
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Pig)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreatHart)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BushPig))
			)
		),
		new MiniChampInfo // Cactus Llama Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CrystalElemental)),
				new MiniChampTypeInfo(5, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CactusLlama))
			)
		),
		new MiniChampInfo // Cancer Harpy Aerie
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Harpy)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WailingBanshee)),
				new MiniChampTypeInfo(10, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(Lich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CancerHarpy))
			)
		),
		new MiniChampInfo // Cancer Shell Bear Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneKnight)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CancerShellBear))
			)
		),
		new MiniChampInfo // Candy Corn Creep's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PestilentBandage)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonElemental)),
				new MiniChampTypeInfo(5, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CandyCornCreep))
			)
		),
		new MiniChampInfo // Capricorn Harpy's Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Chicken)),
				new MiniChampTypeInfo(15, typeof(Crane)),
				new MiniChampTypeInfo(10, typeof(Eagle))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Parrot)),
				new MiniChampTypeInfo(10, typeof(Macaw))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Phoenix)),
				new MiniChampTypeInfo(5, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CapricornHarpy))
			)
		),
		new MiniChampInfo // Capricorn Mountain Bear's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BrownBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreyWolf)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CapricornMountainBear))
			)
		),
		new MiniChampInfo // Capuchin Trickster's Playground
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SneakyNinja)),
				new MiniChampTypeInfo(15, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapSetter)),
				new MiniChampTypeInfo(10, typeof(DisguiseMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilentMovieMonk)),
				new MiniChampTypeInfo(5, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CapuchinTrickster))
			)
		),
		new MiniChampInfo // Caramel Conjurer's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(15, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CaramelConjurer))
			)
		),
		new MiniChampInfo // Celestial Horror Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(GothicNovelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(WandererOfTheVoid))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialHorror))
			)
		),
		new MiniChampInfo // Celestial Python Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantSerpent)),
				new MiniChampTypeInfo(10, typeof(Snake)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaSerpent)),
				new MiniChampTypeInfo(5, typeof(SerpentineDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialPython))
			)
		),
		new MiniChampInfo // Celestial Satyr Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyQueen)),
				new MiniChampTypeInfo(5, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialSatyr))
			)
		),
		new MiniChampInfo // Celestial Wolf Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(DireWolf)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TimberWolf)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialWolf))
			)
		),
		new MiniChampInfo // Chamois Hill
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Goat)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Chamois))
			)
		),
		new MiniChampInfo //  Chaos Hare
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(VorpalBunny)),
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(5, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChaosHare))
			)
		),
		new MiniChampInfo //  Charro Llama
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RidableLlama)),
				new MiniChampTypeInfo(15, typeof(PackHorse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Horse)),
				new MiniChampTypeInfo(10, typeof(GreatHart))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(5, typeof(Beastmaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CharroLlama))
			)
		),
		new MiniChampInfo //  Cheese Golem
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Mimic)),
				new MiniChampTypeInfo(10, typeof(Ravager)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Goat)),
				new MiniChampTypeInfo(5, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Slime)),
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CheeseGolem))
			)
		),
		new MiniChampInfo //  Chimpanzee Berserker
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Gorilla)),
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bull)),
				new MiniChampTypeInfo(5, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackBear)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChimpanzeeBerserker))
			)
		),
		new MiniChampInfo //  Chocolate Truffle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(DrumBoy)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RaveRogue)),
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChocolateTruffle))
			)
		),
		new MiniChampInfo // Cholera Rat Infestation
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRS)),
				new MiniChampTypeInfo(15, typeof(ClanRC)),
				new MiniChampTypeInfo(15, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantRat)),
				new MiniChampTypeInfo(5, typeof(Slime))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CholeraRat))
			)
		),
		new MiniChampInfo // Chromatic Ogre Clan
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(OrcBomber)),
				new MiniChampTypeInfo(10, typeof(OrcChopper)),
				new MiniChampTypeInfo(10, typeof(OrcCaptain))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(GrecoRomanWrestler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SavageShaman)),
				new MiniChampTypeInfo(5, typeof(OrcishMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ChromaticOgre))
			)
		),
		new MiniChampInfo // Cleopatra the Enigmatic
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyQueen)),
				new MiniChampTypeInfo(5, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CleopatraTheEnigmatic))
			)
		),
		new MiniChampInfo // Cliff Goat Dominion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MountainGoat)),
				new MiniChampTypeInfo(15, typeof(RamRider)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackBear)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CliffGoat))
			)
		),
		new MiniChampInfo // Coral Sentinel's Reef
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(Dolphin)),
				new MiniChampTypeInfo(10, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(5, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CoralSentinel))
			)
		),
		new MiniChampInfo // Corrosive Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantToad)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PestilentBandage)),
				new MiniChampTypeInfo(5, typeof(CorrosiveSlime))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CorrosiveToad))
			)
		),
		new MiniChampInfo // Cosmic Bouncer Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StarCitizen)),
				new MiniChampTypeInfo(15, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(5, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(3, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CosmicBouncer))
			)
		),
		new MiniChampInfo // Cosmic Stalker Void
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(5, typeof(Balron))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CosmicStalker))
			)
		),
		new MiniChampInfo // Crimson Mule Valley
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Horse)),
				new MiniChampTypeInfo(10, typeof(RidableLlama)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GrayGoblin)),
				new MiniChampTypeInfo(5, typeof(Boar))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrimsonMule))
			)
		),
		new MiniChampInfo // Crystal Golem Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(IronSmith)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BronzeElemental)),
				new MiniChampTypeInfo(5, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrystalGolem))
			)
		),
		new MiniChampInfo // Crystal Ooze Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(5, typeof(CrystalElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BogThing)),
				new MiniChampTypeInfo(3, typeof(Bogling))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrystalOoze))
			)
		),
		new MiniChampInfo // Cursed Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(Slime))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CursedToad))
			)
		),
		new MiniChampInfo // Cursed White Tail Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(PatchworkSkeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SpectralWolf)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CursedWolf))
			)
		),
		new MiniChampInfo // Cursed Wolf's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wolf)),
				new MiniChampTypeInfo(15, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SpectralWolf)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CursedWolf))
			)
		),
		new MiniChampInfo // Dall Sheep Highland
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(MountainGoat)),
				new MiniChampTypeInfo(15, typeof(DallSheep)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(BrownBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(5, typeof(IceElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DallSheep))
			)
		),
		new MiniChampInfo // Death Rat Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRS)),
				new MiniChampTypeInfo(20, typeof(ClanRC)),
				new MiniChampTypeInfo(15, typeof(ClanSS))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(5, typeof(Zombie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DeathRat))
			)
		),
		new MiniChampInfo // Dia de Los Muertos Llama
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Zombie)),
				new MiniChampTypeInfo(15, typeof(PlagueRat)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DiaDeLosMuertosLlama))
			)
		),
		new MiniChampInfo // Displacer Beast Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(GiantSpider)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(DisplacerBeast))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DisplacerBeast))
			)
		),
		new MiniChampInfo // Domestic Swine Retreat
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(25, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(5, typeof(Troll))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DomesticSwine))
			)
		),
		new MiniChampInfo // Douglas Squirrel Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DouglasSquirrel)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DouglasSquirrel))
			)
		),
		new MiniChampInfo // Dreadnaught Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BaroqueBarbarian)),
				new MiniChampTypeInfo(5, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ravager)),
				new MiniChampTypeInfo(5, typeof(Mimic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Dreadnaught))
			)
		),
		new MiniChampInfo // Earthquake Wolf Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(TimberWolf)),
				new MiniChampTypeInfo(10, typeof(LeatherWolf)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(EarthElemental)),
				new MiniChampTypeInfo(5, typeof(StoneGolem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EarthquakeWolf))
			)
		),
		new MiniChampInfo // Eastern Gray Squirrel Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(JackRabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestScout)),
				new MiniChampTypeInfo(5, typeof(Beastmaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(Forager))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EasternGraySquirrel))
			)
		),
		new MiniChampInfo // Eclipse Reindeer Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Rat)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EclipseReindeer))
			)
		),
		new MiniChampInfo // Eldritch Harbinger Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(Succubus)),
				new MiniChampTypeInfo(5, typeof(DemonKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EldritchHarbinger))
			)
		),
		new MiniChampInfo //  Eldritch Hare's Warren
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(VorpalBunny)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(GhostScout))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EldritchHare))
			)
		),
		new MiniChampInfo //  Eldritch Toad's Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantToad)),
				new MiniChampTypeInfo(20, typeof(BullFrog)),
				new MiniChampTypeInfo(10, typeof(Slime))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantIceWorm)),
				new MiniChampTypeInfo(5, typeof(Bogling))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(GhostWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EldritchToad))
			)
		),
		new MiniChampInfo //  Electric Slime's Labyrinth
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(Rabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(GhostWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ElectricSlime))
			)
		),
		new MiniChampInfo //  Electro Wraith's Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ElectroWraith))
			)
		),
		new MiniChampInfo //  El Mariachi Llama's Fiesta
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(Horse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Flutist)),
				new MiniChampTypeInfo(10, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkaSkald)),
				new MiniChampTypeInfo(5, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ElMariachiLlama))
			)
		),
		new MiniChampInfo //  Ember Axis Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaElemental)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireGargoyle)),
				new MiniChampTypeInfo(5, typeof(Efreet))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EmberAxis))
			)
		),
		new MiniChampInfo //  Ember Wolf Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireElemental)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(EmberWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EmberWolf))
			)
		),
		new MiniChampInfo //  Emperor Cobra Temple
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(GiantSerpent)),
				new MiniChampTypeInfo(10, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(EmperorCobra))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EmperorCobra))
			)
		),
		new MiniChampInfo //  Enigmatic Satyr Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(EnigmaticSatyr))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EnigmaticSatyr))
			)
		),
		new MiniChampInfo //  Enigmatic Skipper Reef
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CoralSnake)),
				new MiniChampTypeInfo(10, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kraken)),
				new MiniChampTypeInfo(5, typeof(EnigmaticSkipper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EnigmaticSkipper))
			)
		),
		new MiniChampInfo // Ethereal Panthra's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CuSidhe)),
				new MiniChampTypeInfo(15, typeof(EtherealWarrior)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BakeKitsune)),
				new MiniChampTypeInfo(10, typeof(Reptalon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kirin)),
				new MiniChampTypeInfo(5, typeof(Yamandon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EtherealPanthra))
			)
		),
		new MiniChampInfo // Fainting Goat's Pasture
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Goat)),
				new MiniChampTypeInfo(15, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FaintingGoat))
			)
		),
		new MiniChampInfo // Fever Rat's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PlagueRat)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(Ratman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(10, typeof(Bogling))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Slime)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FeverRat))
			)
		),
		new MiniChampInfo // Fiesta Llama's Celebration
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RidableLlama)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Llama))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Pig)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodFox)),
				new MiniChampTypeInfo(5, typeof(Goat))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FiestaLlama))
			)
		),
		new MiniChampInfo // Flameborne Knight's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlameborneKnight))
			)
		),
		new MiniChampInfo // Flamebringer Ogre Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ogre)),
				new MiniChampTypeInfo(15, typeof(OrcChopper)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(OrcChopper)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(FlameElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlamebringerOgre))
			)
		),
		new MiniChampInfo // Flesh Eater Ogre Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(20, typeof(GrayGoblin)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(GrayGoblin))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(Revenant))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FleshEaterOgre))
			)
		),
		new MiniChampInfo // Flying Squirrel Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(Pig)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FlyingSquirrel)),
				new MiniChampTypeInfo(5, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlyingSquirrel))
			)
		),
		new MiniChampInfo // Forgotten Warden Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ForgottenWarden))
			)
		),
		new MiniChampInfo // Fox Squirrel Glen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(5, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodFox)),
				new MiniChampTypeInfo(5, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FoxSquirrel))
			)
		),
		new MiniChampInfo // Frenzied Satyr's Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrenziedSatyr))
			)
		),
		new MiniChampInfo // Frostbite Wolf's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(DireWolf)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(TimberWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostbiteWolf))
			)
		),
		new MiniChampInfo // Frostbound Champion's Hall
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(HolyKnight)),
				new MiniChampTypeInfo(10, typeof(KnightOfValor))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(KnightOfValor))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostboundChampion))
			)
		),
		new MiniChampInfo // Frost Droid Factory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(RetroAndroid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(ValoriteElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostDroid))
			)
		),
		new MiniChampInfo // Frost Lich's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostLich))
			)
		),
		new MiniChampInfo // Frost Ogre Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(15, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostOgre)),
				new MiniChampTypeInfo(5, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostOgre))
			)
		),
		new MiniChampInfo // Frost Wapiti Grounds
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(25, typeof(FrostDrake)),
				new MiniChampTypeInfo(20, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(5, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostWapiti))
			)
		),
		new MiniChampInfo // Frost Warden Watch
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(15, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PolarBear)),
				new MiniChampTypeInfo(5, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostWarden))
			)
		),
		new MiniChampInfo // Frozen Ooze Cave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(PlagueRat)),
				new MiniChampTypeInfo(10, typeof(FrozenOoze)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(FrozenOoze)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SlimeMage)),
				new MiniChampTypeInfo(5, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrozenOoze))
			)
		),
		new MiniChampInfo // Fungal Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantToad)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FungalToad)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FungalToad))
			)
		),
		new MiniChampInfo // Gemini Harpy's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(GreenNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GeminiHarpy))
			)
		),
		new MiniChampInfo // Gemini Twin Bear's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BrownBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GeminiTwinBear))
			)
		),
		new MiniChampInfo // Gentle Satyr's Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenNinja)),
				new MiniChampTypeInfo(5, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GentleSatyr))
			)
		),
		new MiniChampInfo // Giant Forest Hog's Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(GiantToad)),
				new MiniChampTypeInfo(15, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GiantForestHog))
			)
		),
		new MiniChampInfo // Giant Wolf Spider's Web
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SentinelSpider)),
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GiantWolfSpider))
			)
		),
		new MiniChampInfo //  Gibbon Mystic's Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GreenNinja)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(10, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GibbonMystic))
			)
		),
		new MiniChampInfo //  Glistening Ooze's Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GlisteningOoze))
			)
		),
		new MiniChampInfo //  Gloom Ogre's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(Cyclops))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GloomOgre))
			)
		),
		new MiniChampInfo //  Gloom Wolf's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(TimberWolf)),
				new MiniChampTypeInfo(10, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(LeatherWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GloomWolf))
			)
		),
		new MiniChampInfo //  Golden Orb Weaver's Web
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(5, typeof(GiantSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GoldenOrbWeaver))
			)
		),
		new MiniChampInfo // Goliath Birdeater's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantIceWorm)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GoliathBirdeater))
			)
		),
		new MiniChampInfo // Goral's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Savage)),
				new MiniChampTypeInfo(5, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Goral))
			)
		),
		new MiniChampInfo // Grappler Drone's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(10, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(10, typeof(Assassin))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(RamRider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CombatMedic)),
				new MiniChampTypeInfo(5, typeof(CrossbowMarksman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GrapplerDrone))
			)
		),
		new MiniChampInfo // Grave Knight's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GraveKnight))
			)
		),
		new MiniChampInfo // Gummy Sheep's Pasture
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Sheep))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(WoolWeaver))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantToad)),
				new MiniChampTypeInfo(5, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GummySheep))
			)
		),
		new MiniChampInfo //  Hatshepsut the Queen's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GothicNovelist)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(BoneKnight)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HatshepsutTheQueen))
			)
		),
		new MiniChampInfo //  Hog Wild's Swine Pen
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Pig)),
				new MiniChampTypeInfo(5, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Savage)),
				new MiniChampTypeInfo(10, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodFox)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HogWild))
			)
		),
		new MiniChampInfo //  Howler Monkey's Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HowlerMonkey)),
				new MiniChampTypeInfo(15, typeof(Gorilla)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Gorilla)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Gorilla)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HowlerMonkey))
			)
		),
		new MiniChampInfo //  Huntsman Spider's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HuntsmanSpider))
			)
		),
		new MiniChampInfo //  Hydrokinetic Warden's Water Shrine
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WaterElemental)),
				new MiniChampTypeInfo(15, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(SeaHorse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Leviathan)),
				new MiniChampTypeInfo(10, typeof(AquaticTamer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(CrystalElemental)),
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HydrokineticWarden))
			)
		),
		new MiniChampInfo //  Ibex Highland
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GreatHart)),
				new MiniChampTypeInfo(15, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(Boar))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Ibex))
			)
		),
		new MiniChampInfo //  Indian Palm Squirrel Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(JackRabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Goat)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ferret)),
				new MiniChampTypeInfo(5, typeof(RidableLlama))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IndianPalmSquirrel))
			)
		),
		new MiniChampInfo //  Infernal Lich Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(20, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernalLich))
			)
		),
		new MiniChampInfo //  Infernal Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(BullFrog)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(3, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernalToad))
			)
		),
		new MiniChampInfo //  Inferno Sentinel Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoSentinel))
			)
		),
		new MiniChampInfo // Inferno Stallion Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireElemental)),
				new MiniChampTypeInfo(15, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HellHound)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoStallion))
			)
		),
		new MiniChampInfo // Infinite Pouncer's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wolf)),
				new MiniChampTypeInfo(15, typeof(Cougar)),
				new MiniChampTypeInfo(10, typeof(Lion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Lion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WhiteWolf)),
				new MiniChampTypeInfo(5, typeof(Lion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfinitePouncer))
			)
		),
		new MiniChampInfo // Ironclad Defender's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(5, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IroncladDefender))
			)
		),
		new MiniChampInfo // Ironclad Ogre's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Cyclops)),
				new MiniChampTypeInfo(10, typeof(Brigand))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantTurkey)),
				new MiniChampTypeInfo(5, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IroncladOgre))
			)
		),
		new MiniChampInfo // Iron Golem's Workshop
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(15, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(AnvilHurler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IronSmith)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(Mimic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IronGolem))
			)
		),
		new MiniChampInfo // Iron Steed Stables
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RamRider)),
				new MiniChampTypeInfo(10, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HolyKnight)),
				new MiniChampTypeInfo(10, typeof(ShieldMaiden))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BaroqueBarbarian)),
				new MiniChampTypeInfo(5, typeof(KnightOfMercy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IronSteed))
			)
		),
		new MiniChampInfo // Javelina Jinx Hunt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Boar)),
				new MiniChampTypeInfo(15, typeof(Hind)),
				new MiniChampTypeInfo(10, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SavageShaman)),
				new MiniChampTypeInfo(10, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JavelinaJinx))
			)
		),
		new MiniChampInfo // Jellybean Jester's Carnival
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RaveRogue)),
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JellybeanJester))
			)
		),
		new MiniChampInfo // Kas the Bloody-Handed Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ghoul)),
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Zombie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KasTheBloodyHanded))
			)
		),
		new MiniChampInfo // Kel'Thuzad's Frozen Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(IceElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostDragon)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lich)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KelThuzad))
			)
		),
		new MiniChampInfo // Khufu the Great Builder's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LichLord)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(KhufuTheGreatBuilder))
			)
		),
		new MiniChampInfo // Larloch the Shadow King's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(Lich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LarlochTheShadowKing))
			)
		),
		new MiniChampInfo // Leo the Harpy's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Harpy)),
				new MiniChampTypeInfo(15, typeof(AirElemental)),
				new MiniChampTypeInfo(5, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wyvern))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WyvernRenowned)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LeoHarpy))
			)
		),
		new MiniChampInfo // Leo the Sun Bear's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BrownBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(Savage)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SavageShaman)),
				new MiniChampTypeInfo(5, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LeoSunBear))
			)
		),
		new MiniChampInfo // Leprosy Rat Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Rat)),
				new MiniChampTypeInfo(20, typeof(PestilentBandage)),
				new MiniChampTypeInfo(10, typeof(PlagueRat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(5, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ratman)),
				new MiniChampTypeInfo(10, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LeprosyRat))
			)
		),
		new MiniChampInfo //  Libra Balance Bear
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BrownBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LibraBalanceBear))
			)
		),
		new MiniChampInfo //  Libra Harpy
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bird)),
				new MiniChampTypeInfo(15, typeof(Chicken)),
				new MiniChampTypeInfo(10, typeof(Crane))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(5, typeof(Phoenix))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LibraHarpy))
			)
		),
		new MiniChampInfo //  Licorice Sheep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Sheep)),
				new MiniChampTypeInfo(10, typeof(Goat)),
				new MiniChampTypeInfo(10, typeof(Llama))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WoolWeaver)),
				new MiniChampTypeInfo(5, typeof(BattleWeaver))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LicoriceSheep))
			)
		),
		new MiniChampInfo //  Lollipop Lord
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(15, typeof(RaveRogue)),
				new MiniChampTypeInfo(10, typeof(DrumBoy))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(10, typeof(VaudevilleValkyrie))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkaSkald)),
				new MiniChampTypeInfo(5, typeof(GlamRockMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LollipopLord))
			)
		),
		new MiniChampInfo //  Luchador Llama
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Horse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SumoWrestler)),
				new MiniChampTypeInfo(10, typeof(TaekwondoMaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KatanaDuelist)),
				new MiniChampTypeInfo(5, typeof(SteampunkSamurai))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LuchadorLlama))
			)
		),
		new MiniChampInfo // MalariaRat Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRS)),
				new MiniChampTypeInfo(15, typeof(ClanRibbonPlagueRat)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PlagueRat)),
				new MiniChampTypeInfo(5, typeof(Zombie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MalariaRat))
			)
		),
		new MiniChampInfo // MandrillShaman Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Savage)),
				new MiniChampTypeInfo(15, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(OrcCaptain))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SavageShaman)),
				new MiniChampTypeInfo(5, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MandrillShaman))
			)
		),
		new MiniChampInfo // Markhor Peaks
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Markhor)),
				new MiniChampTypeInfo(15, typeof(SavageShaman)),
				new MiniChampTypeInfo(10, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Lion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lion)),
				new MiniChampTypeInfo(5, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Markhor))
			)
		),
		new MiniChampInfo // MeatGolem Laboratory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(Mimic)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MeatGolem)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneKnight)),
				new MiniChampTypeInfo(5, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MeatGolem))
			)
		),
		new MiniChampInfo // MelodicSatyr Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MelodicSatyr)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MelodicSatyr))
			)
		),
		new MiniChampInfo // Mentuhotep the Wise Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Lich)),
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MentuhotepTheWise))
			)
		),
		new MiniChampInfo // Metallic Windsteed Peaks
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(15, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(MetallicWindsteed))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MetallicWindsteed)),
				new MiniChampTypeInfo(10, typeof(AirElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MetallicWindsteed))
			)
		),
		new MiniChampInfo // Mimicron’s Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(Mimic)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ravager)),
				new MiniChampTypeInfo(10, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Mimicron))
			)
		),
		new MiniChampInfo // Mire Spawner Marsh
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bogling)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PestilentBandage)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Slime)),
				new MiniChampTypeInfo(5, typeof(Bogling))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MireSpawner))
			)
		),
		new MiniChampInfo // Molten Slime Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaLizard)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MoltenSlime))
			)
		),
		new MiniChampInfo //  Mountain Gorilla
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Gorilla)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodFox)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MountainGorilla))
			)
		),
		new MiniChampInfo //  Muck Golem
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PestilentBandage)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MuckGolem)),
				new MiniChampTypeInfo(5, typeof(BogThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MuckGolem))
			)
		),
		new MiniChampInfo //  Mystic Fallow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(GreatHart)),
				new MiniChampTypeInfo(10, typeof(Hind))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestRanger)),
				new MiniChampTypeInfo(5, typeof(ForestScout))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MysticFallow))
			)
		),
		new MiniChampInfo //  Mystic Satyr
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MysticSatyr)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MysticSatyr))
			)
		),
		new MiniChampInfo //  Nagash
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(5, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Nagash))
			)
		),
		new MiniChampInfo // Nano Swarm Lab
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(10, typeof(StarCitizen))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(5, typeof(RenaissanceMechanic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NanoSwarm))
			)
		),
		new MiniChampInfo // Nebula Cat's Celestial Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Phoenix)),
				new MiniChampTypeInfo(15, typeof(Macaw)),
				new MiniChampTypeInfo(10, typeof(Crane))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(10, typeof(Parrot))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NebulaCat))
			)
		),
		new MiniChampInfo // Necrotic General's Battlefield
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneDemon)),
				new MiniChampTypeInfo(5, typeof(Revenant))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroticGeneral))
			)
		),
		new MiniChampInfo // Necrotic Lich's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Spectre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(InterredGrizzle))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroticLich))
			)
		),
		new MiniChampInfo // Necrotic Ogre's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroticOgre))
			)
		),
		new MiniChampInfo //  Nefertiti's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Ghoul))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Nefertiti))
			)
		),
		new MiniChampInfo // Nemesis Unit Facility
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(RetroAndroid))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NemesisUnit))
			)
		),
		new MiniChampInfo // Nightmare Leaper Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Nightmare)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NightmareLeaper))
			)
		),
		new MiniChampInfo // Nightmare Panther's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(SpectralWolf)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(10, typeof(DarkWisp))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Nightmare)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NightmarePanther))
			)
		),
		new MiniChampInfo // Omega Sentinel's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(StarCitizen))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StarCitizen)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(OmegaSentinel))
			)
		),
		new MiniChampInfo // Orangutan Sage Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Gorilla)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestRanger)),
				new MiniChampTypeInfo(5, typeof(CuSidhe))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(OrangutanSage))
			)
		),
		new MiniChampInfo // Overlord MkII Stronghold
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(15, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(CyberpunkSorcerer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(5, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(OverlordMkII))
			)
		),
		new MiniChampInfo // Peccary Protector Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Horse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Gorilla)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lion)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PeccaryProtector))
			)
		),
		new MiniChampInfo // Peppermint Puff Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SlyStoryteller)),
				new MiniChampTypeInfo(15, typeof(BluesSingingGorgon)),
				new MiniChampTypeInfo(10, typeof(Flutist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GlamRockMage)),
				new MiniChampTypeInfo(5, typeof(SkaSkald))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VaudevilleValkyrie)),
				new MiniChampTypeInfo(5, typeof(RaveRogue))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PeppermintPuff))
			)
		),
		new MiniChampInfo // Phantom Automaton Vault
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Mimic)),
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PhantomAutomaton))
			)
		),
		new MiniChampInfo // Phantom Panther's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Spectre)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PhantomPanther))
			)
		),
		new MiniChampInfo // Plague Lich's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Zombie)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mummy)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PlagueLich))
			)
		),
		new MiniChampInfo // Plasma Juggernaut's Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(15, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(IronSmith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IronSmith)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PlasmaJuggernaut))
			)
		),
		new MiniChampInfo // Purse Spider's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PurseSpider))
			)
		),
		new MiniChampInfo // Quantum Guardian's Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CyberpunkSorcerer)),
				new MiniChampTypeInfo(15, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(StarCitizen)),
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(QuantumGuardian))
			)
		),
		new MiniChampInfo // Rabid Rat Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRS)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(15, typeof(ClanRibbonPlagueRat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GrayGoblin)),
				new MiniChampTypeInfo(5, typeof(GrayGoblinMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ratman)),
				new MiniChampTypeInfo(5, typeof(Bogling))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RabidRat))
			)
		),
		new MiniChampInfo // Radiant Slime Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(CorrosiveSlime)),
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ValoriteElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RadiantSlime))
			)
		),
		new MiniChampInfo // Raistlin Majere's Tower
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(15, typeof(Magician)),
				new MiniChampTypeInfo(10, typeof(ScrollMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(ElementalWizard)),
				new MiniChampTypeInfo(5, typeof(Enchanter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RaistlinMajere))
			)
		),
		new MiniChampInfo // Ramses the Immortal Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(AncientLich)),
				new MiniChampTypeInfo(15, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneDemon)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RamsesTheImmortal))
			)
		),
		new MiniChampInfo // Red Squirrel Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(RedSquirrel)),
				new MiniChampTypeInfo(10, typeof(Rabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(Rabbit))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RedSquirrel))
			)
		),
		new MiniChampInfo // Red-Tailed Squirrel Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(JackRabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BloodFox)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RedTailedSquirrel))
			)
		),
		new MiniChampInfo // Rhythmic Satyr’s Glade
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(15, typeof(FairyQueen))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Satyr)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Pixie)),
				new MiniChampTypeInfo(10, typeof(Nymph))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RhythmicSatyr))
			)
		),
		new MiniChampInfo // Rock Squirrel Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GrayGoblin)),
				new MiniChampTypeInfo(5, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RockSquirrel))
			)
		),
		new MiniChampInfo // Sable Antelope Savanna
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SableAntelope)),
				new MiniChampTypeInfo(10, typeof(Goat)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreatHart)),
				new MiniChampTypeInfo(5, typeof(Cougar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SableAntelope))
			)
		),
		new MiniChampInfo // Sagittarius Archer Bear Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(GreatHart)),
				new MiniChampTypeInfo(15, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyDragon)),
				new MiniChampTypeInfo(5, typeof(Harpy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Dryad)),
				new MiniChampTypeInfo(10, typeof(Centaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SagittariusArcherBear))
			)
		),
		new MiniChampInfo // Sagittarius Harpy’s Perch
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FairyDragon)),
				new MiniChampTypeInfo(15, typeof(Harpy)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyDragon)),
				new MiniChampTypeInfo(10, typeof(Dryad)),
				new MiniChampTypeInfo(5, typeof(Centaur))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Centaur)),
				new MiniChampTypeInfo(5, typeof(Dryad))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SagittariusHarpy))
			)
		),
		new MiniChampInfo // Sand Golem’s Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StoneGolem)),
				new MiniChampTypeInfo(15, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(SkeletonWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(SkeletonWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mummy)),
				new MiniChampTypeInfo(5, typeof(StoneGolem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SandGolem))
			)
		),
		new MiniChampInfo // Scorpio Harpy's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Harpy)),
				new MiniChampTypeInfo(10, typeof(Scorpion)),
				new MiniChampTypeInfo(5, typeof(StoneGolem))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StoneGolem)),
				new MiniChampTypeInfo(10, typeof(Mummy)),
				new MiniChampTypeInfo(10, typeof(Harpy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mummy)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioHarpy))
			)
		),
		new MiniChampInfo // Scorpion Spider’s Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Scorpion)),
				new MiniChampTypeInfo(10, typeof(ScorpionSpider)),
				new MiniChampTypeInfo(5, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScorpionSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpionSpider))
			)
		),
		new MiniChampInfo // Scorpio Venom Bear’s Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackBear)),
				new MiniChampTypeInfo(15, typeof(Scorpion)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(Scorpion)),
				new MiniChampTypeInfo(5, typeof(ScorpionSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonElemental)),
				new MiniChampTypeInfo(5, typeof(ScorpioVenomBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // Seti the Avenger's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BoneKnight)),
				new MiniChampTypeInfo(15, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // Shadowblade Assassin's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(10, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SneakyNinja)),
				new MiniChampTypeInfo(5, typeof(ShadowGolem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // Shadow Golem's Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(15, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(PatchworkMonster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // Shadow Lich's Necropolis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wraith)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(LichLord))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // Shadow Muntjac's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DireWolf)),
				new MiniChampTypeInfo(10, typeof(ShadowGolem))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowGolem)),
				new MiniChampTypeInfo(5, typeof(ShadowMuntjac))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpioVenomBear))
			)
		),
		new MiniChampInfo // ShadowOgre's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(5, typeof(OrcBrute))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowOgre))
			)
		),
		new MiniChampInfo // ShadowProwler's Hunt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Spectre)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorQueen))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowProwler))
			)
		),
		new MiniChampInfo // ShadowSludge's Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(10, typeof(Slime))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidSlug)),
				new MiniChampTypeInfo(5, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowSludge))
			)
		),
		new MiniChampInfo // ShadowToad's Bog
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(BlackSolenWorker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AcidElemental)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowToad))
			)
		),
		new MiniChampInfo // SifakaWarrior's Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WildTiger)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SifakaWarrior))
			)
		),
		new MiniChampInfo //  Smallpox Rat Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClanRibbonPlagueRat)),
				new MiniChampTypeInfo(15, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PestilentBandage)),
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SmallpoxRat))
			)
		),
		new MiniChampInfo //  Sombrero de Sol Llama
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Llama)),
				new MiniChampTypeInfo(15, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(BigCatTamer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SombreroDeSolLlama))
			)
		),
		new MiniChampInfo //  Sombrero Llama
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(Goat)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Sheep))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lion)),
				new MiniChampTypeInfo(5, typeof(Horse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SombreroLlama))
			)
		),
		new MiniChampInfo //  Soth the Death Knight
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneMagi)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SothTheDeathKnight))
			)
		),
		new MiniChampInfo //  Soul Eater Lich
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(LichLord)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(3, typeof(BoneDemon)),
				new MiniChampTypeInfo(2, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SoulEaterLich))
			)
		),
		new MiniChampInfo // Spectral Automaton Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(15, typeof(AnvilHurler)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(10, typeof(Golem))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mimic)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpectralAutomaton))
			)
		),
		new MiniChampInfo // Spectral Toad Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(Bogling))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(InterredGrizzle))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(SpectralToad))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpectralToad))
			)
		),
		new MiniChampInfo // Spectral Warden Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpectralWarden))
			)
		),
		new MiniChampInfo // Spiderling Minion Broodmother
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SentinelSpider)),
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorQueen)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpiderlingMinionBroodmother))
			)
		),
		new MiniChampInfo // Spider Monkey Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SpiderMonkey)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SpiderMonkey))
			)
		),
		new MiniChampInfo // Starborn Predator Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(10, typeof(SerpentineDragon)),
				new MiniChampTypeInfo(10, typeof(PlatinumDrake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CrimsonDrake)),
				new MiniChampTypeInfo(10, typeof(GreaterDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreaterDragon)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StarbornPredator))
			)
		),
		new MiniChampInfo // Steam Leviathan Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(15, typeof(InsaneRoboticist)),
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RetroAndroid)),
				new MiniChampTypeInfo(10, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StarCitizen)),
				new MiniChampTypeInfo(5, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SteamLeviathan))
			)
		),
		new MiniChampInfo // Stone Golem Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(StoneGolem)),
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(SkeletalDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StoneGolem))
			)
		),
		new MiniChampInfo // Stone Steed Stables
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(StoneGolem)),
				new MiniChampTypeInfo(15, typeof(PatchworkSkeleton)),
				new MiniChampTypeInfo(10, typeof(Horse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(SkeletalDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StoneSteed))
			)
		),
		new MiniChampInfo // Storm Bone Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneDemon)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormBone))
			)
		),
		new MiniChampInfo // Skeleton - The Tempest's Wrath
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(StormConjurer)),
				new MiniChampTypeInfo(15, typeof(WindElemental)),
				new MiniChampTypeInfo(10, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WindElemental)),
				new MiniChampTypeInfo(5, typeof(PsychedelicShaman))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormLich))
			)
		),
		new MiniChampInfo // StormLich - The Storm of Death
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(LichLord))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LichLord)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormLich))
			)
		),
		new MiniChampInfo // StormOgre - The Wrath of the Thunder King
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(15, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Cyclops)),
				new MiniChampTypeInfo(5, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(BaroqueBarbarian))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormOgre))
			)
		),
		new MiniChampInfo // StormSika - The Forest Tempest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(15, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CuSidhe)),
				new MiniChampTypeInfo(10, typeof(Unicorn))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kirin)),
				new MiniChampTypeInfo(5, typeof(Reptalon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormSika))
			)
		),
		new MiniChampInfo // StormWolf - The Tempest's Fury
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TimberWolf)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SilverSerpent)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormWolf))
			)
		),
		new MiniChampInfo // Synthroid Prime Factory
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RetroAndroid)),
				new MiniChampTypeInfo(15, typeof(RetroRobotRomancer)),
				new MiniChampTypeInfo(10, typeof(InsaneRoboticist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StarCitizen)),
				new MiniChampTypeInfo(5, typeof(StarfleetCaptain))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StarfleetCaptain)),
				new MiniChampTypeInfo(5, typeof(RenaissanceMechanic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SynthroidPrime))
			)
		),
		new MiniChampInfo // Szass Tam's Necropolis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Lich)),
				new MiniChampTypeInfo(15, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SzassTam))
			)
		),
		new MiniChampInfo // Taco Llama Festival
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(25, typeof(Squirrel)),
				new MiniChampTypeInfo(15, typeof(Llama)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DireWolf)),
				new MiniChampTypeInfo(5, typeof(VorpalBunny))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TacoLlama))
			)
		),
		new MiniChampInfo // Tactical Enforcer Operations
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SteampunkSamurai)),
				new MiniChampTypeInfo(15, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(10, typeof(KnightOfJustice))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RapierDuelist)),
				new MiniChampTypeInfo(10, typeof(ShieldBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FieldCommander)),
				new MiniChampTypeInfo(5, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TacticalEnforcer))
			)
		),
		new MiniChampInfo // Taffy Titan's Arena
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Banneret)),
				new MiniChampTypeInfo(15, typeof(CombatMedic)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(5, typeof(SabreFighter))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(KnightOfMercy)),
				new MiniChampTypeInfo(5, typeof(KnightOfValor))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TaffyTitan))
			)
		),
		new MiniChampInfo // Tahr's Wild Horde
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Savage)),
				new MiniChampTypeInfo(15, typeof(SavageShaman)),
				new MiniChampTypeInfo(10, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenGoblin)),
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Troll)),
				new MiniChampTypeInfo(5, typeof(Ogre))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Tahr))
			)
		),
		new MiniChampInfo // TalonMachine's Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(AnvilHurler)),
				new MiniChampTypeInfo(15, typeof(IronSmith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(Mimic))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TalonMachine))
			)
		),
		new MiniChampInfo // TaurusEarthBear's Dominion
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Boar)),
				new MiniChampTypeInfo(15, typeof(BrownBear)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Gorilla)),
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TaurusEarthBear))
			)
		),
		new MiniChampInfo // TaurusHarpy's Skies
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Parrot)),
				new MiniChampTypeInfo(15, typeof(Eagle)),
				new MiniChampTypeInfo(10, typeof(Crane))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wyvern)),
				new MiniChampTypeInfo(10, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Dragon)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TaurusHarpy))
			)
		),
		new MiniChampInfo // TempestSatyr's Storm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(15, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TempestSatyr))
			)
		),
		new MiniChampInfo // Tequila Llama Tavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(RidableLlama)),
				new MiniChampTypeInfo(10, typeof(Pig)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Gorilla)),
				new MiniChampTypeInfo(10, typeof(Llama))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(Lion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TequilaLlama))
			)
		),
		new MiniChampInfo // Thutmose the Conqueror's Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(15, typeof(Savage)),
				new MiniChampTypeInfo(10, typeof(OrcCaptain))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(JukaWarrior)),
				new MiniChampTypeInfo(5, typeof(JukaLord)),
				new MiniChampTypeInfo(10, typeof(Brigand))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoonElite)),
				new MiniChampTypeInfo(5, typeof(Minotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ThutmoseTheConqueror))
			)
		),
		new MiniChampInfo // Tidal Mare's Deep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(AquaticTamer)),
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Leviathan)),
				new MiniChampTypeInfo(10, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(5, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TidalMare))
			)
		),
		new MiniChampInfo // Toxic Lich's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(RottingCorpse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicLich))
			)
		),
		new MiniChampInfo // Toxic Ogre's Stronghold
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoonElite)),
				new MiniChampTypeInfo(5, typeof(SavageRider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicOgre))
			)
		),
		new MiniChampInfo // Toxic Sludge Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(15, typeof(Slime)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(VeriteElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicSludge))
			)
		),
		new MiniChampInfo // Trapdoor Spider Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TrapdoorSpider))
			)
		),
		new MiniChampInfo // Tsunami Titan's Deep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Kraken))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(SerpentineDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TsunamiTitan))
			)
		),
		new MiniChampInfo // Tutankhamun The Cursed Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TutankhamunTheCursed))
			)
		),
		new MiniChampInfo // Typhus Rat Infestation
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GrayGoblin)),
				new MiniChampTypeInfo(15, typeof(GrayGoblinMage)),
				new MiniChampTypeInfo(10, typeof(GrayGoblinKeeper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PlagueRat)),
				new MiniChampTypeInfo(5, typeof(OrcBomber))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ratman)),
				new MiniChampTypeInfo(5, typeof(Savage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TyphusRat))
			)
		),
		new MiniChampInfo // Vampiric Blade's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(GhostScout))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VampiricBlade))
			)
		),
		new MiniChampInfo // Vecna's Sanctum
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(15, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lich)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Vecna))
			)
		),
		new MiniChampInfo // Venomous Roe's Marsh
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(VenomousWolf)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(15, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(VenomousSerpent)),
				new MiniChampTypeInfo(10, typeof(SerpentHandler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(VenomousDragon)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousRoe))
			)
		),
		new MiniChampInfo // Venomous Toad's Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(ToxicElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(SerpentHandler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousToad))
			)
		),
		new MiniChampInfo // Venomous Wolf's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(VenomousWolf)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(VenomousSerpent)),
				new MiniChampTypeInfo(10, typeof(SilverSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilverSerpent)),
				new MiniChampTypeInfo(5, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousWolf))
			)
		),
		new MiniChampInfo // VietnamesePig
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pig)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(LeatherWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(Savage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SavageRider)),
				new MiniChampTypeInfo(5, typeof(GrayGoblin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VietnamesePig))
			)
		),
		new MiniChampInfo // VileToad
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantToad)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(15, typeof(Snake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VileToad))
			)
		),
		new MiniChampInfo // VirgoHarpy
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FairyDragon)),
				new MiniChampTypeInfo(15, typeof(Harpy)),
				new MiniChampTypeInfo(10, typeof(Phoenix))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(10, typeof(Crane))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenHag)),
				new MiniChampTypeInfo(5, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VirgoHarpy))
			)
		),
		new MiniChampInfo // VirgoPurityBear
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BlackBear)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PolarBear)),
				new MiniChampTypeInfo(5, typeof(Cougar))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VirgoPurityBear))
			)
		),
		new MiniChampInfo // VoidCat
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(LeatherWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorQueen))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VoidCat))
			)
		),
		new MiniChampInfo // VoidSlime
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Slime)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AcidSlug)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VoidSlime))
			)
		),
		new MiniChampInfo // VolcanicCharger
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaSnake)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(HellCat))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VolcanicCharger))
			)
		),
		new MiniChampInfo // VortexConstruct
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ClockworkEngineer)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer)),
				new MiniChampTypeInfo(10, typeof(Golem))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VortexConstruct))
			)
		),
		new MiniChampInfo // VortexWraith
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VortexWraith))
			)
		),
		new MiniChampInfo // WarthogWarrior
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Pig)),
				new MiniChampTypeInfo(5, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Boar)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WarthogWarrior))
			)
		),
		new MiniChampInfo // Whispering Pooka Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Pixie)),
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(3, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WhisperingPooka))
			)
		),
		new MiniChampInfo // Wicked Satyr's Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(Satyr)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(Succubus))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyQueen)),
				new MiniChampTypeInfo(3, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WickedSatyr))
			)
		),
		new MiniChampInfo // Wood Golem's Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Treefellow)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(5, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Forager)),
				new MiniChampTypeInfo(3, typeof(Treefellow))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WoodGolem))
			)
		),
		new MiniChampInfo // Woodland Charger Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WildTiger)),
				new MiniChampTypeInfo(15, typeof(Lion)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Lion)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WoodlandCharger)),
				new MiniChampTypeInfo(3, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WoodlandCharger))
			)
		),
		new MiniChampInfo // Woodland Spirit Horse Meadow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Horse)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SpiritWolf)),
				new MiniChampTypeInfo(5, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WoodlandSpiritHorse)),
				new MiniChampTypeInfo(3, typeof(FairyDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WoodlandSpiritHorse))
			)
		),
		new MiniChampInfo // WraithLich Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(20, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WraithLich))
			)
		),
		new MiniChampInfo // YangStallion Plains
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HolyKnight)),
				new MiniChampTypeInfo(15, typeof(KnightOfValor)),
				new MiniChampTypeInfo(10, typeof(RamRider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(KnightOfJustice)),
				new MiniChampTypeInfo(10, typeof(KnightOfMercy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SabreFighter)),
				new MiniChampTypeInfo(5, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(YangStallion))
			)
		),
		new MiniChampInfo // YinSteed Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(YinSteed))
			)
		),
		new MiniChampInfo // Breeze Phantom Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BreezePhantom))
			)
		),
		new MiniChampInfo // Bubble Ferret Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BubbleFerret)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SerpentHandler)),
				new MiniChampTypeInfo(10, typeof(SheepdogHandler))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Llama)),
				new MiniChampTypeInfo(5, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BubbleFerret))
			)
		),
		new MiniChampInfo // Celestial Dragon Shrine
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FairyDragon)),
				new MiniChampTypeInfo(10, typeof(Dragon)),
				new MiniChampTypeInfo(10, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CrimsonDrake)),
				new MiniChampTypeInfo(10, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SerpentineDragon)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CelestialDragon))
			)
		),
		new MiniChampInfo // Cerebral Ettin Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(JukaLord)),
				new MiniChampTypeInfo(10, typeof(JukaWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantTurkey)),
				new MiniChampTypeInfo(10, typeof(Ogre))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(OgreLord)),
				new MiniChampTypeInfo(5, typeof(Troll))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CerebralEttin))
			)
		),
		new MiniChampInfo // Chaneque Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Chaneque)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(FairyQueen))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Chaneque))
			)
		),
		new MiniChampInfo // Chimereon Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(10, typeof(MegaDragon)),
				new MiniChampTypeInfo(10, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Chimereon))
			)
		),
		new MiniChampInfo // Cinder Wraith Ruins
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FireDaemon)),
				new MiniChampTypeInfo(15, typeof(HellHound)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(FireElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CinderWraith))
			)
		),
		new MiniChampInfo // Corrupting Creeper Forest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(15, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Bogling)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(Slime))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CorruptingCreeper))
			)
		),
		new MiniChampInfo // Crystal Dragon Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(CrystalElemental)),
				new MiniChampTypeInfo(15, typeof(GoldenElemental)),
				new MiniChampTypeInfo(10, typeof(SilverSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(CrystalDragon)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ValoriteElemental)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrystalDragon))
			)
		),
		new MiniChampInfo // Crystal Warden Temple
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SkeletalMage)),
				new MiniChampTypeInfo(15, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CrystalWarden))
			)
		),
		new MiniChampInfo // Cursed Harbinger Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GhostScout)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WailingBanshee)),
				new MiniChampTypeInfo(5, typeof(GhostWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(3, typeof(InterredGrizzle))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CursedHarbinger))
			)
		),
		new MiniChampInfo // Cyclone Demon Plains
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(Imp)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(10, typeof(Daemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(TormentedMinotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(CycloneDemon))
			)
		),
		new MiniChampInfo // Dairy Wraith Field
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(Wight)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(InterredGrizzle)),
				new MiniChampTypeInfo(5, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DairyWraith))
			)
		),
		new MiniChampInfo // Deadlord Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneDemon)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Deadlord))
			)
		),
		new MiniChampInfo // Dreaded Creeper Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DreadedCreeper))
			)
		),
		new MiniChampInfo // Dreamy Ferret Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ferret)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(VorpalBunny)),
				new MiniChampTypeInfo(5, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(3, typeof(GrayGoblin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(DreamyFerret))
			)
		),
		new MiniChampInfo // Drolatic Wastes
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantIceWorm)),
				new MiniChampTypeInfo(10, typeof(BogThing)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwampThing)),
				new MiniChampTypeInfo(5, typeof(Bogling))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Drolatic))
			)
		),
		new MiniChampInfo // Dryad Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Dryad)),
				new MiniChampTypeInfo(15, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HostileDruid)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Dryad))
			)
		),
		new MiniChampInfo // Earthquake Ettin Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ogre)),
				new MiniChampTypeInfo(20, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ettin)),
				new MiniChampTypeInfo(5, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Cyclops)),
				new MiniChampTypeInfo(3, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EarthquakeEttin))
			)
		),
		new MiniChampInfo // Elder Tendril Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(SwampThing)),
				new MiniChampTypeInfo(15, typeof(Bogling))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ElderTendril))
			)
		),
		new MiniChampInfo // Ember Serpent Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaSnake)),
				new MiniChampTypeInfo(15, typeof(LavaLizard)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireElemental)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EmberSerpent))
			)
		),
		new MiniChampInfo // Ember Spirit Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireMage)),
				new MiniChampTypeInfo(15, typeof(FlameElemental)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSerpent)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Succubus)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EmberSpirit))
			)
		),
		new MiniChampInfo // Ethereal Crab Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(IceCrab)),
				new MiniChampTypeInfo(15, typeof(EtherealWarrior)),
				new MiniChampTypeInfo(10, typeof(AquaticTamer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EtherealWarrior)),
				new MiniChampTypeInfo(5, typeof(EtherealCrab))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AquaticTamer)),
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EtherealCrab))
			)
		),
		new MiniChampInfo // Ethereal Dragon's Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(EtherealWarrior)),
				new MiniChampTypeInfo(10, typeof(Dragon)),
				new MiniChampTypeInfo(5, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EtherealWarrior)),
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(EtherealDragon))
			)
		),
		new MiniChampInfo // Firebreath Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Alligator)),
				new MiniChampTypeInfo(15, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(GrayGoblin))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilverSerpent)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FirebreathAlligator))
			)
		),
		new MiniChampInfo // Fire Rooster Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireAnt)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireElemental)),
				new MiniChampTypeInfo(5, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FireRooster))
			)
		),
		new MiniChampInfo // Flame Bearer Cave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Pig))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlameBear))
			)
		),
		new MiniChampInfo // Flame Warden Ettin Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(FlameElemental)),
				new MiniChampTypeInfo(10, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(OrcCaptain))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(OrcBrute)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FlameWardenEttin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlameWardenEttin))
			)
		),
		new MiniChampInfo // Flare Imp Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Imp)),
				new MiniChampTypeInfo(15, typeof(FlareImp)),
				new MiniChampTypeInfo(10, typeof(PitFiend))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(10, typeof(DemonKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FlareImp))
			)
		),
		new MiniChampInfo // Fossil Elemental Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BoneKnight)),
				new MiniChampTypeInfo(15, typeof(SkeletalMage)),
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneMagi)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FossilElemental))
			)
		),
		new MiniChampInfo // Frost Bear Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PolarBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostBear))
			)
		),
		new MiniChampInfo // Frostbite Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Alligator)),
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IceElemental)),
				new MiniChampTypeInfo(5, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostbiteAlligator))
			)
		),
		new MiniChampInfo // Frostbound Behemoth Cave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantTurkey)),
				new MiniChampTypeInfo(15, typeof(Cyclops)),
				new MiniChampTypeInfo(10, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OgreLord))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostboundBehemoth))
			)
		),
		new MiniChampInfo // Frost Drakon Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FrostDragon)),
				new MiniChampTypeInfo(15, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostbiteAlligator)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SnowElemental)),
				new MiniChampTypeInfo(5, typeof(IceElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostDrakon))
			)
		),
		new MiniChampInfo // Frost Hen's Perch
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Chicken)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WhiteWolf)),
				new MiniChampTypeInfo(5, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostHen))
			)
		),
		new MiniChampInfo // Frost Serpent Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(IceSnake)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(WhiteWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostSerpent))
			)
		),
		new MiniChampInfo // Frost Warden Ettin Stronghold
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(GiantTurkey)),
				new MiniChampTypeInfo(10, typeof(Ogre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(10, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostWardenEttin))
			)
		),
		new MiniChampInfo // Frosty Ferret's Burrow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ferret)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SnowElemental)),
				new MiniChampTypeInfo(5, typeof(IceElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(FrostyFerret))
			)
		),
		new MiniChampInfo // Gale Wisp's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Wisp)),
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AirElemental)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GaleWisp))
			)
		),
		new MiniChampInfo // Giant Trapdoor Spider Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion)),
				new MiniChampTypeInfo(10, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GiantTrapdoorSpider))
			)
		),
		new MiniChampInfo // Giant Wolf Spider Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GiantIceWorm)),
				new MiniChampTypeInfo(5, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GiantWolfSpider))
			)
		),
		new MiniChampInfo // Glimmering Ferret Burrow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ferret)),
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Squirrel))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BigCatTamer)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Beastmaster)),
				new MiniChampTypeInfo(5, typeof(AquaticTamer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GlimmeringFerret))
			)
		),
		new MiniChampInfo // Golden Orb Weaver Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(15, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(5, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GoldenOrbWeaver))
			)
		),
		new MiniChampInfo // Goliath Birdeater Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(15, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(5, typeof(GiantIceWorm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GoliathBirdeater))
			)
		),
		new MiniChampInfo // Gorgon Viper's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(15, typeof(Snake)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonElemental)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GorgonViper))
			)
		),
		new MiniChampInfo // Granite Colossus Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Golem)),
				new MiniChampTypeInfo(15, typeof(StoneElemental)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(10, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BronzeElemental)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GraniteColossus))
			)
		),
		new MiniChampInfo // Grimorie's Tome
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ScrollMage)),
				new MiniChampTypeInfo(15, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ElementalWizard)),
				new MiniChampTypeInfo(10, typeof(EvilAlchemist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(5, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Grimorie))
			)
		),
		new MiniChampInfo // Grotesque of Rouen's Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(Ghoul)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GrotesqueOfRouen))
			)
		),
		new MiniChampInfo // Grymalkin the Watcher's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PatchworkMonster)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GrymalkinTheWatcher))
			)
		),
		new MiniChampInfo // Guernsey Guardian Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Bull)),
				new MiniChampTypeInfo(15, typeof(Goat)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RamRider)),
				new MiniChampTypeInfo(10, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShieldBearer)),
				new MiniChampTypeInfo(5, typeof(KnightOfJustice))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(GuernseyGuardian))
			)
		),
		new MiniChampInfo // Harmony Ferret Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ferret)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(BirdTrainer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestScout)),
				new MiniChampTypeInfo(5, typeof(Beastmaster))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HarmonyFerret))
			)
		),
		new MiniChampInfo // Hellfire Juggernaut Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HellCat)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(HellHound)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HellfireJuggernaut))
			)
		),
		new MiniChampInfo // Hereford Warlock Tower
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Enchanter)),
				new MiniChampTypeInfo(15, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Magician)),
				new MiniChampTypeInfo(10, typeof(ScrollMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(FireMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HerefordWarlock))
			)
		),
		new MiniChampInfo // Highland Bull Herd
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HighlandBull)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(RamRider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Savage)),
				new MiniChampTypeInfo(10, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(5, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HighlandBull))
			)
		),
		new MiniChampInfo // Huntsman Spider's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(DreadSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorQueen)),
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(HuntsmanSpider))
			)
		),
		new MiniChampInfo // Ice Crab Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(15, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist)),
				new MiniChampTypeInfo(10, typeof(SnowElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IceCrab)),
				new MiniChampTypeInfo(5, typeof(WhiteWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IceCrab))
			)
		),
		new MiniChampInfo // Illusionary Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwampThing)),
				new MiniChampTypeInfo(10, typeof(PatchworkMonster)),
				new MiniChampTypeInfo(10, typeof(GothicNovelist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Mimic))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwampThing)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IllusionaryAlligator))
			)
		),
		new MiniChampInfo // Illusion Hen's Paradise
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Chicken)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Sheep))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Chicken)),
				new MiniChampTypeInfo(10, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkWisp)),
				new MiniChampTypeInfo(5, typeof(Pixie))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IllusionHen))
			)
		),
		new MiniChampInfo // Illusionist Ettin's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(15, typeof(OrcBomber)),
				new MiniChampTypeInfo(10, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(JukaMage)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mimic)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IllusionistEttin))
			)
		),
		new MiniChampInfo // Infernal Duke's Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(Imp)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernalDuke))
			)
		),
		new MiniChampInfo // Infernal Incinerator Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(FireElemental)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(Succubus))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(AbysmalHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernalIncinerator))
			)
		),
		new MiniChampInfo // Inferno Drakon's Roost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(PlatinumDrake)),
				new MiniChampTypeInfo(10, typeof(Drake)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(Dragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoDrakon))
			)
		),
		new MiniChampInfo // Inferno Python Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantSerpent)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(SilverSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SeaSerpent)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoPython))
			)
		),
		new MiniChampInfo // Inferno Warden's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(15, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(MaddeningHorror))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(InfernoWarden))
			)
		),
		new MiniChampInfo // Ish Kar the Forgotten Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DarkElf)),
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalLich)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(IshKarTheForgotten))
			)
		),
		new MiniChampInfo // Jersey Enchantress Coven
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(NymphSinger)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyDragon)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreenHag)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(JerseyEnchantress))
			)
		),
		new MiniChampInfo // Lava Crab Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaLizard)),
				new MiniChampTypeInfo(15, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LavaCrab))
			)
		),
		new MiniChampInfo // Lava Fiend Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaSerpent)),
				new MiniChampTypeInfo(15, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(FireAnt))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LavaFiend))
			)
		),
		new MiniChampInfo // Leaf Bear Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Hind))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Cougar)),
				new MiniChampTypeInfo(5, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LeafBear))
			)
		),
		new MiniChampInfo // Leprechaun's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GreenGoblin)),
				new MiniChampTypeInfo(15, typeof(GrayGoblin)),
				new MiniChampTypeInfo(10, typeof(Pixie))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Pixie)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FairyQueen)),
				new MiniChampTypeInfo(5, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Leprechaun))
			)
		),
		new MiniChampInfo // Light Bearer's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Enchanter)),
				new MiniChampTypeInfo(15, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(10, typeof(FireMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(AvatarOfElements))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(LightBear))
			)
		),
		new MiniChampInfo // Magma Golem Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaSerpent)),
				new MiniChampTypeInfo(15, typeof(FireAnt)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(HellCat))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MagmaGolem))
			)
		),
		new MiniChampInfo // Magnetic Crab Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SentinelSpider)),
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Golem)),
				new MiniChampTypeInfo(5, typeof(TrapEngineer))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MagneticCrab))
			)
		),
		new MiniChampInfo // Maine Coon Titan's Roost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Cougar)),
				new MiniChampTypeInfo(15, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(Lion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Gorilla)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MaineCoonTitan))
			)
		),
		new MiniChampInfo // Milking Demon Stables
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Imp)),
				new MiniChampTypeInfo(15, typeof(DemonKnight)),
				new MiniChampTypeInfo(10, typeof(Succubus))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(10, typeof(EffetePutridGargoyle))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MilkingDemon))
			)
		),
		new MiniChampInfo // Molten Golem Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LavaElemental)),
				new MiniChampTypeInfo(15, typeof(LavaSerpent)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireDaemon)),
				new MiniChampTypeInfo(10, typeof(HellHound))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireElemental)),
				new MiniChampTypeInfo(5, typeof(HellCat))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MoltenGolem))
			)
		),
		new MiniChampInfo // Mordrake's Manor
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GhostWarrior)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wraith))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mummy)),
				new MiniChampTypeInfo(5, typeof(Revenant))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Mordrake))
			)
		),
		new MiniChampInfo // Mud Golem Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(MudGolem)),
				new MiniChampTypeInfo(15, typeof(Bogling)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(10, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(BogThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MudGolem))
			)
		),
		new MiniChampInfo // Mystic Ferret Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(MysticFerret)),
				new MiniChampTypeInfo(15, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(BloodFox))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MysticFerret))
			)
		),
		new MiniChampInfo // Mystic Fowl Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Phoenix)),
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(15, typeof(Chicken))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Macaw)),
				new MiniChampTypeInfo(10, typeof(Parrot))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Parrot)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MysticFowl))
			)
		),
		new MiniChampInfo // Mystic Wisp Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(Wisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(MysticWisp))
			)
		),
		new MiniChampInfo // Nature Dragon's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(CuSidhe)),
				new MiniChampTypeInfo(10, typeof(Unicorn)),
				new MiniChampTypeInfo(10, typeof(Hiryu))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Reptalon)),
				new MiniChampTypeInfo(10, typeof(Nightmare))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Kirin)),
				new MiniChampTypeInfo(5, typeof(Dragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NatureDragon))
			)
		),
		new MiniChampInfo // Necro Ettin Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneKnight)),
				new MiniChampTypeInfo(10, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Lich)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroEttin))
			)
		),
		new MiniChampInfo // Necro Rooster Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ghoul)),
				new MiniChampTypeInfo(10, typeof(InterredGrizzle))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(Ghoul))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NecroRooster))
			)
		),
		new MiniChampInfo // Nightshade Bramble Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Forager)),
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorQueen)),
				new MiniChampTypeInfo(10, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NightshadeBramble))
			)
		),
		new MiniChampInfo // Nymph's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(NymphSinger)),
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(10, typeof(SatyrPiper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DarkElf)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Nymph))
			)
		),
		new MiniChampInfo // Nyx Rith Ruins
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(NyxRith))
			)
		),
		new MiniChampInfo // Persian Shade Tomb
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GothicNovelist)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalMage)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PersianShade))
			)
		),
		new MiniChampInfo // Phantom Vines Overgrowth
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SwampThing)),
				new MiniChampTypeInfo(15, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(BlackSolenQueen))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Treefellow)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mimic)),
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PhantomVines))
			)
		),
		new MiniChampInfo // Poisonous Crab Cove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Scorpion)),
				new MiniChampTypeInfo(15, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(10, typeof(GiantSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonElemental)),
				new MiniChampTypeInfo(10, typeof(AcidSlug))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(SkitteringHopper))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PoisonousCrab))
			)
		),
		new MiniChampInfo // Poison Pullet Farm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SerpentHandler)),
				new MiniChampTypeInfo(15, typeof(BirdTrainer)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(PoisonElemental)),
				new MiniChampTypeInfo(5, typeof(Wisp))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PoisonPullet))
			)
		),
		new MiniChampInfo // Puck's Mischief
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(FairyQueen)),
				new MiniChampTypeInfo(15, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(TwistedCultist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(NymphSinger)),
				new MiniChampTypeInfo(5, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Puck))
			)
		),
		new MiniChampInfo // Puffy Ferret Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SerpentHandler)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Horse)),
				new MiniChampTypeInfo(10, typeof(GrizzlyBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RidableLlama)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PuffyFerret))
			)
		),
		new MiniChampInfo // Purse Spider Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(10, typeof(SentinelSpider)),
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantSpider)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(5, typeof(Shade))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PurseSpider))
			)
		),
		new MiniChampInfo // Pyroclastic Golem Forge
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaElemental)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(10, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(LavaLizard))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireElemental)),
				new MiniChampTypeInfo(5, typeof(BronzeElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(PyroclasticGolem))
			)
		),
		new MiniChampInfo // Quake Bringer Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Cyclops)),
				new MiniChampTypeInfo(15, typeof(GiantTurkey)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ogre)),
				new MiniChampTypeInfo(5, typeof(Troll))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(StoneElemental)),
				new MiniChampTypeInfo(5, typeof(Golem))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(QuakeBringer))
			)
		),
		new MiniChampInfo // Quor Zael's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(DemonKnight)),
				new MiniChampTypeInfo(15, typeof(Imp)),
				new MiniChampTypeInfo(10, typeof(AbysmalHorror))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Devourer)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(QuorZael))
			)
		),
		new MiniChampInfo // Ragdoll Guardian Citadel
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(15, typeof(Mimic)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(5, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GhostWarrior)),
				new MiniChampTypeInfo(5, typeof(RestlessSoul))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RagdollGuardian))
			)
		),
		new MiniChampInfo // Raging Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Alligator)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GiantSerpent)),
				new MiniChampTypeInfo(5, typeof(WildTiger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(WolfSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RagingAlligator))
			)
		),
		new MiniChampInfo // RathZor the Shattered's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Golem)),
				new MiniChampTypeInfo(10, typeof(Mimic)),
				new MiniChampTypeInfo(10, typeof(PatchworkSkeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Ravager)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RathZorTheShattered))
			)
		),
		new MiniChampInfo // Riptide Crab Cove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SeaSerpent)),
				new MiniChampTypeInfo(15, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(10, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Kraken)),
				new MiniChampTypeInfo(10, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RiptideCrab))
			)
		),
		new MiniChampInfo // Rock Bear Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(15, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(BrownBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TimberWolf)),
				new MiniChampTypeInfo(5, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(RockBear))
			)
		),
		new MiniChampInfo // Sahiwal Shaman's Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(HostileDruid)),
				new MiniChampTypeInfo(15, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(ArcticNaturalist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DesertNaturalist)),
				new MiniChampTypeInfo(10, typeof(ForestRanger))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ForestRanger)),
				new MiniChampTypeInfo(5, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SahiwalShaman))
			)
		),
		new MiniChampInfo // Sandstorm Elemental Desert
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Shade)),
				new MiniChampTypeInfo(15, typeof(ForestRanger)),
				new MiniChampTypeInfo(10, typeof(Scorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SpiritMedium)),
				new MiniChampTypeInfo(10, typeof(DesertNaturalist))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SandstormElemental)),
				new MiniChampTypeInfo(5, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SandstormElemental))
			)
		),
		new MiniChampInfo // Scorpion Spider Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(SpeckledScorpion))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScorpionSpider))
			)
		),
		new MiniChampInfo // Scottish Fold Sentinel Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShieldBearer)),
				new MiniChampTypeInfo(10, typeof(CombatMedic)),
				new MiniChampTypeInfo(10, typeof(SwordDefender))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShieldMaiden)),
				new MiniChampTypeInfo(5, typeof(HolyKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(RamRider)),
				new MiniChampTypeInfo(5, typeof(CombatNurse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ScottishFoldSentinel))
			)
		),
		new MiniChampInfo // Selkie Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SerpentHandler)),
				new MiniChampTypeInfo(10, typeof(AquaticTamer)),
				new MiniChampTypeInfo(10, typeof(SeaHorse))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaHorse)),
				new MiniChampTypeInfo(5, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DeepSeaSerpent)),
				new MiniChampTypeInfo(5, typeof(Dolphin))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Selkie))
			)
		),
		new MiniChampInfo // Shadow Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Alligator)),
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(Boar))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(5, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior)),
				new MiniChampTypeInfo(5, typeof(Wraith))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowAlligator))
			)
		),
		new MiniChampInfo // Shadow Anaconda Jungle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantSerpent)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Lizardman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(5, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SilverSerpent)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowAnaconda))
			)
		),
		new MiniChampInfo // Shadow Bear's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackBear)),
				new MiniChampTypeInfo(15, typeof(Wolf)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowBear))
			)
		),
		new MiniChampInfo // Shadow Chick's Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Chicken)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(BlackSolenWorker))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowChick))
			)
		),
		new MiniChampInfo // Shadow Crab's Tidepool
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(15, typeof(IceCrab)),
				new MiniChampTypeInfo(10, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(Kraken))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowCrab))
			)
		),
		new MiniChampInfo // Shadow Dragon's Roost
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(15, typeof(Wyvern)),
				new MiniChampTypeInfo(20, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalDragon)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowDragon)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowDragon))
			)
		),
		new MiniChampInfo // Shadow Drifter's Mists
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GhostScout)),
				new MiniChampTypeInfo(15, typeof(Spectre)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ShadowDrifter))
			)
		),
		new MiniChampInfo // Siamese Illusionist Chamber
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Enchanter)),
				new MiniChampTypeInfo(15, typeof(ArcaneScribe)),
				new MiniChampTypeInfo(10, typeof(Magician))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ScrollMage)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(EvilAlchemist)),
				new MiniChampTypeInfo(5, typeof(SlimeMage))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SiameseIllusionist))
			)
		),
		new MiniChampInfo // Siberian Frostclaw's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WhiteWolf)),
				new MiniChampTypeInfo(15, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SnowElemental)),
				new MiniChampTypeInfo(10, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(FrostDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SiberianFrostclaw))
			)
		),
		new MiniChampInfo // Sidhe Fae Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FairyQueen)),
				new MiniChampTypeInfo(15, typeof(SatyrPiper)),
				new MiniChampTypeInfo(10, typeof(NymphSinger))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(GreenHag)),
				new MiniChampTypeInfo(10, typeof(DarkElf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MegaDragon)),
				new MiniChampTypeInfo(5, typeof(Dragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Sidhe))
			)
		),
		new MiniChampInfo // Sinister Root Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(AppleElemental)),
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Treefellow)),
				new MiniChampTypeInfo(10, typeof(BogThing))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SinisterRoot))
			)
		),
		new MiniChampInfo // Sky Seraph's Aerie
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Eagle)),
				new MiniChampTypeInfo(15, typeof(Parrot)),
				new MiniChampTypeInfo(10, typeof(Macaw))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Crane)),
				new MiniChampTypeInfo(10, typeof(Phoenix))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(StarCitizen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SkySeraph))
			)
		),
		new MiniChampInfo // Solar Elemental Summit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FireElemental)),
				new MiniChampTypeInfo(15, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(ValoriteElemental))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(BronzeElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SolarElemental))
			)
		),
		new MiniChampInfo // Spark Ferret Wilds
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(25, typeof(SparkFerret)),
				new MiniChampTypeInfo(15, typeof(Rabbit)),
				new MiniChampTypeInfo(10, typeof(Goat))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(Hind))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WildTiger)),
				new MiniChampTypeInfo(5, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SparkFerret))
			)
		),
		new MiniChampInfo // Sphinx Cat's Riddle
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(SphinxCat)),
				new MiniChampTypeInfo(20, typeof(Cat)),
				new MiniChampTypeInfo(10, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(BoneKnight))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletalKnight)),
				new MiniChampTypeInfo(5, typeof(BoneMagi))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SphinxCat))
			)
		),
		new MiniChampInfo // Spiderling Overlord Broodmother
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackSolenWorker)),
				new MiniChampTypeInfo(15, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(5, typeof(GiantWolfSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SentinelSpider))
			)
		),
		new MiniChampInfo // Starry Ferret's Celestial Realm
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(25, typeof(StarryFerret)),
				new MiniChampTypeInfo(10, typeof(Squirrel)),
				new MiniChampTypeInfo(10, typeof(Hind))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Hind)),
				new MiniChampTypeInfo(10, typeof(Bird))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Crane)),
				new MiniChampTypeInfo(5, typeof(Phoenix))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StarryFerret))
			)
		),
		new MiniChampInfo // Steel Bear Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(BrownBear))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wolf)),
				new MiniChampTypeInfo(5, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SteelBear))
			)
		),
		new MiniChampInfo // Stone Guardian Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BoneKnight)),
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SkeletalLich)),
				new MiniChampTypeInfo(10, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SkeletonLord)),
				new MiniChampTypeInfo(5, typeof(SkeletalDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StoneGuardian))
			)
		),
		new MiniChampInfo // Stone Rooster Crypt
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Skeleton)),
				new MiniChampTypeInfo(10, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Shade)),
				new MiniChampTypeInfo(10, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wraith)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StoneRooster))
			)
		),
		new MiniChampInfo // Storm Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Alligator)),
				new MiniChampTypeInfo(15, typeof(Snake)),
				new MiniChampTypeInfo(10, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(Snake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaSnake)),
				new MiniChampTypeInfo(5, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormAlligator))
			)
		),
		new MiniChampInfo // Skeleton Ettin Stronghold
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(15, typeof(Orc)),
				new MiniChampTypeInfo(10, typeof(OrcBrute))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormCrab))
			)
		),
		new MiniChampInfo // Storm Crab's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(15, typeof(SentinelSpider)),
				new MiniChampTypeInfo(10, typeof(SkitteringHopper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(IceCrab)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(IceCrab)),
				new MiniChampTypeInfo(5, typeof(BlackSolenWarrior))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormCrab))
			)
		),
		new MiniChampInfo // Storm Daemon's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(15, typeof(Impaler)),
				new MiniChampTypeInfo(10, typeof(ArcaneDaemon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(10, typeof(Daemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WandererOfTheVoid)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormDaemon))
			)
		),
		new MiniChampInfo // Storm Dragon's Peak
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Dragon)),
				new MiniChampTypeInfo(15, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(PlatinumDrake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Dragon)),
				new MiniChampTypeInfo(10, typeof(GreaterDragon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormDragon))
			)
		),
		new MiniChampInfo // Storm Herald's Sanctuary
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(10, typeof(WindElemental)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(AvatarOfElements)),
				new MiniChampTypeInfo(10, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(SpiritMedium))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(StormHerald))
			)
		),
		new MiniChampInfo // Strix's Perch
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(Strix))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Strix)),
				new MiniChampTypeInfo(5, typeof(GreyWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(GreyWolf)),
				new MiniChampTypeInfo(5, typeof(Ferret))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Strix))
			)
		),
		new MiniChampInfo // Sunbeam Ferret Hollow
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Ferret)),
				new MiniChampTypeInfo(15, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(Rabbit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SunbeamFerret)),
				new MiniChampTypeInfo(5, typeof(GoldenElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Squirrel)),
				new MiniChampTypeInfo(5, typeof(PolarBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(SunbeamFerret))
			)
		),
		new MiniChampInfo // Tarantula Warrior Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorWarrior)),
				new MiniChampTypeInfo(5, typeof(SentinelSpider))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TarantulaWarrior))
			)
		),
		new MiniChampInfo // Tarantula Worrior Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WolfSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(10, typeof(TrapdoorSpider))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(10, typeof(BlackSolenInfiltratorWarrior))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BlackSolenQueen)),
				new MiniChampTypeInfo(5, typeof(BlackSolenInfiltratorQueen))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(BlackSolenQueen))
			)
		),
		new MiniChampInfo // Tempest Spirit Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(TempestSpirit))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(5, typeof(TempestSpirit))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(AirElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TempestSpirit))
			)
		),
		new MiniChampInfo // Tempest Wyrm Spire
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(FrostDrake)),
				new MiniChampTypeInfo(10, typeof(Wyvern)),
				new MiniChampTypeInfo(10, typeof(SerpentineDragon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(TempestWyrm)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientWyrm)),
				new MiniChampTypeInfo(5, typeof(ShadowWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TempestWyrm))
			)
		),
		new MiniChampInfo // Terra Wisp Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Treefellow)),
				new MiniChampTypeInfo(5, typeof(SwampThing))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TerraWisp))
			)
		),
		new MiniChampInfo // Thorned Horror Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Bogling)),
				new MiniChampTypeInfo(15, typeof(BogThing)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(DreadSpider)),
				new MiniChampTypeInfo(5, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(SwampThing)),
				new MiniChampTypeInfo(5, typeof(MegaDragon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ThornedHorror))
			)
		),
		new MiniChampInfo // Thul Gor the Forsaken Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(AncientLich)),
				new MiniChampTypeInfo(10, typeof(WailingBanshee))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WailingBanshee)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(InterredGrizzle)),
				new MiniChampTypeInfo(5, typeof(AncientLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ThulGorTheForsaken))
			)
		),
		new MiniChampInfo // Thunder Bear Highlands
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BlackBear)),
				new MiniChampTypeInfo(15, typeof(GrizzlyBear)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PolarBear)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(Gorilla))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ThunderBear))
			)
		),
		new MiniChampInfo // Thunderbird Mountain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Eagle)),
				new MiniChampTypeInfo(15, typeof(Macaw)),
				new MiniChampTypeInfo(10, typeof(Parrot))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(FairyDragon)),
				new MiniChampTypeInfo(5, typeof(Thunderbird))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Wyvern)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Thunderbird))
			)
		),
		new MiniChampInfo // Thunder Serpent Cavern
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(LightningBearer)),
				new MiniChampTypeInfo(15, typeof(Wyvern)),
				new MiniChampTypeInfo(10, typeof(Stormtrooper2))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Wyvern)),
				new MiniChampTypeInfo(10, typeof(RuneCaster))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ThunderSerpent)),
				new MiniChampTypeInfo(5, typeof(PlatinumDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ThunderSerpent))
			)
		),
		new MiniChampInfo // Tidal Ettin Marsh
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(AquaticTamer)),
				new MiniChampTypeInfo(15, typeof(SeaSerpent)),
				new MiniChampTypeInfo(10, typeof(CoralSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Leviathan)),
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TidalEttin)),
				new MiniChampTypeInfo(5, typeof(Minotaur))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TidalEttin))
			)
		),
		new MiniChampInfo // Titan Boa Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Snake)),
				new MiniChampTypeInfo(10, typeof(SerpentHandler)),
				new MiniChampTypeInfo(15, typeof(GiantSerpent))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(LavaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TitanBoa)),
				new MiniChampTypeInfo(5, typeof(SeaSerpent))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TitanBoa))
			)
		),
		new MiniChampInfo // Toxic Alligator Swamps
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BloodFox)),
				new MiniChampTypeInfo(10, typeof(GrayGoblin)),
				new MiniChampTypeInfo(10, typeof(GreenGoblinAlchemist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ToxicElemental)),
				new MiniChampTypeInfo(10, typeof(PoisonElemental))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicAlligator)),
				new MiniChampTypeInfo(5, typeof(BlackBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicAlligator))
			)
		),
		new MiniChampInfo // Toxic Reaver Necropolis
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Zombie)),
				new MiniChampTypeInfo(10, typeof(InterredGrizzle)),
				new MiniChampTypeInfo(10, typeof(SkeletalKnight))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BoneDemon)),
				new MiniChampTypeInfo(10, typeof(Mummy))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicReaver)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ToxicReaver))
			)
		),
		new MiniChampInfo // Turkish Angora Enchanter's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Enchanter)),
				new MiniChampTypeInfo(15, typeof(Magician)),
				new MiniChampTypeInfo(10, typeof(ScrollMage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(RuneCaster)),
				new MiniChampTypeInfo(10, typeof(ArcaneScribe))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ElementalWizard)),
				new MiniChampTypeInfo(5, typeof(Enchanter))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TurkishAngoraEnchanter))
			)
		),
		new MiniChampInfo // Twin Terror Ettin's Fortress
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Ettin)),
				new MiniChampTypeInfo(15, typeof(OrcCaptain)),
				new MiniChampTypeInfo(10, typeof(GiantTurkey))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Ogre)),
				new MiniChampTypeInfo(10, typeof(OrcishLord))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(5, typeof(Troll))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(TwinTerrorEttin))
			)
		),
		new MiniChampInfo // Uru Koth's Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(GreenGoblin)),
				new MiniChampTypeInfo(15, typeof(GrayGoblin)),
				new MiniChampTypeInfo(10, typeof(OrcChopper))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(OrcBomber))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoonElite)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(UruKoth))
			)
		),
		new MiniChampInfo // Vengeful Pit Viper's Pit
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(PitFiend)),
				new MiniChampTypeInfo(15, typeof(SerpentHandler)),
				new MiniChampTypeInfo(10, typeof(Snake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(PlatinumDrake)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LavaSerpent)),
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VengefulPitViper))
			)
		),
		new MiniChampInfo // Venom Bear's Den
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(BloodFox)),
				new MiniChampTypeInfo(15, typeof(SheepdogHandler)),
				new MiniChampTypeInfo(10, typeof(Wolf))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(BlackBear)),
				new MiniChampTypeInfo(10, typeof(DireWolf))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomBear))
			)
		),
		new MiniChampInfo // Venomous Alligator Swamp
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Alligator)),
				new MiniChampTypeInfo(10, typeof(Boar)),
				new MiniChampTypeInfo(15, typeof(GiantToad))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SerpentHandler)),
				new MiniChampTypeInfo(5, typeof(Snake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ToxicElemental)),
				new MiniChampTypeInfo(5, typeof(Leviathan))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousAlligator))
			)
		),
		new MiniChampInfo // Venomous Dragon Lair
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(Snake)),
				new MiniChampTypeInfo(15, typeof(LavaSnake)),
				new MiniChampTypeInfo(5, typeof(IceSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWyrm)),
				new MiniChampTypeInfo(5, typeof(Drake))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FrostDrake)),
				new MiniChampTypeInfo(5, typeof(CrimsonDrake))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousDragon))
			)
		),
		new MiniChampInfo // Venomous Ettin Cave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GiantTurkey)),
				new MiniChampTypeInfo(10, typeof(Troll)),
				new MiniChampTypeInfo(10, typeof(Ogre))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(Ettin)),
				new MiniChampTypeInfo(10, typeof(Ogre))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(10, typeof(OgreLord)),
				new MiniChampTypeInfo(5, typeof(BoneDemon))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousEttin))
			)
		),
		new MiniChampInfo // Venomous Ivy Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(AppleElemental)),
				new MiniChampTypeInfo(15, typeof(PoisonAppleTree)),
				new MiniChampTypeInfo(10, typeof(Forager))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(AppleElemental)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(HostileDruid)),
				new MiniChampTypeInfo(5, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VenomousIvy))
			)
		),
		new MiniChampInfo // Vespa Hive
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(SkitteringHopper)),
				new MiniChampTypeInfo(10, typeof(MoundOfMaggots)),
				new MiniChampTypeInfo(10, typeof(PestilentBandage))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(15, typeof(TrapdoorSpider)),
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(10, typeof(GiantBlackWidow)),
				new MiniChampTypeInfo(5, typeof(AppleElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Vespa))
			)
		),
		new MiniChampInfo // Vile Blossom Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(AppleElemental)),
				new MiniChampTypeInfo(15, typeof(Forager)),
				new MiniChampTypeInfo(10, typeof(PoisonAppleTree))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ForestScout)),
				new MiniChampTypeInfo(10, typeof(HostileDruid))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(TwistedCultist)),
				new MiniChampTypeInfo(5, typeof(GreenHag))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VileBlossom))
			)
		),
		new MiniChampInfo // Vitrail the Mosaic
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ShadowWisp)),
				new MiniChampTypeInfo(15, typeof(CrystalElemental)),
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ClockworkScorpion)),
				new MiniChampTypeInfo(10, typeof(Golem))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Mimic)),
				new MiniChampTypeInfo(5, typeof(ClockworkScorpion))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VitrailTheMosaic))
			)
		),
		new MiniChampInfo // Void Stalker Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Skeleton)),
				new MiniChampTypeInfo(15, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(10, typeof(WandererOfTheVoid))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(MaddeningHorror)),
				new MiniChampTypeInfo(5, typeof(ChaosDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ArcaneDaemon)),
				new MiniChampTypeInfo(5, typeof(VoidStalker))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VoidStalker))
			)
		),
		new MiniChampInfo // Volcanic Titan Crater
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(LavaSerpent)),
				new MiniChampTypeInfo(15, typeof(HellCat)),
				new MiniChampTypeInfo(10, typeof(LavaSnake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(LavaElemental)),
				new MiniChampTypeInfo(10, typeof(FireDaemon))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(FireDaemon)),
				new MiniChampTypeInfo(5, typeof(AncientWyrm))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VolcanicTitan))
			)
		),
		new MiniChampInfo // Vorgath the Destroyer
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(ChaosDragoon)),
				new MiniChampTypeInfo(15, typeof(JukaLord)),
				new MiniChampTypeInfo(10, typeof(JukaWarrior))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(SavageRider)),
				new MiniChampTypeInfo(10, typeof(OrcBomber))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(BoneDemon)),
				new MiniChampTypeInfo(5, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(Vorgath))
			)
		),
		new MiniChampInfo // Vortex Crab Reef
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WaterElemental)),
				new MiniChampTypeInfo(15, typeof(Leviathan)),
				new MiniChampTypeInfo(10, typeof(SavageShaman))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WaterElemental)),
				new MiniChampTypeInfo(10, typeof(DeepSeaSerpent))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Leviathan)),
				new MiniChampTypeInfo(5, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VortexCrab))
			)
		),
		new MiniChampInfo // Vortex Guardian Keep
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(WindElemental)),
				new MiniChampTypeInfo(15, typeof(AirElemental)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(StormConjurer)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WindElemental)),
				new MiniChampTypeInfo(5, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(VortexGuardian))
			)
		),
		new MiniChampInfo // Whirlwind Fiend Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WindElemental)),
				new MiniChampTypeInfo(10, typeof(AirElemental)),
				new MiniChampTypeInfo(10, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WhirlwindFiend)),
				new MiniChampTypeInfo(10, typeof(StormConjurer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WhirlwindFiend)),
				new MiniChampTypeInfo(5, typeof(WaterElemental))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WhirlwindFiend))
			)
		),
		new MiniChampInfo // Will-O-The-Wisp Enclave
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Wisp)),
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(LightningBearer))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(LightningBearer)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WillOTheWisp))
			)
		),
		new MiniChampInfo // Wind Bear Grove
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(WhiteWolf)),
				new MiniChampTypeInfo(10, typeof(GreyWolf)),
				new MiniChampTypeInfo(10, typeof(FrostDrake))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(WindElemental)),
				new MiniChampTypeInfo(10, typeof(WindBear))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(WindElemental)),
				new MiniChampTypeInfo(5, typeof(FrostBear))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WindBear))
			)
		),
		new MiniChampInfo // Wind Chicken Nest
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Chicken)),
				new MiniChampTypeInfo(15, typeof(Bird)),
				new MiniChampTypeInfo(10, typeof(Crane))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(5, typeof(Phoenix))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Stormtrooper2)),
				new MiniChampTypeInfo(5, typeof(Skeleton))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(WindChicken))
			)
		),
		new MiniChampInfo // Xal'Rath Cult
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(TwistedCultist)),
				new MiniChampTypeInfo(10, typeof(Eagle)),
				new MiniChampTypeInfo(10, typeof(ChaosDragoon))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(ChaosDaemon)),
				new MiniChampTypeInfo(5, typeof(AbyssalAbomination))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(3, typeof(AbysmalHorror)),
				new MiniChampTypeInfo(3, typeof(DemonKnight))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(XalRath))
			)
		),
		new MiniChampInfo // Zebu Zealot Ruins
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(Orc)),
				new MiniChampTypeInfo(20, typeof(OrcChopper)),
				new MiniChampTypeInfo(10, typeof(OrcBrute))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(5, typeof(OrcishLord)),
				new MiniChampTypeInfo(5, typeof(OrcCaptain))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ChaosDragoonElite)),
				new MiniChampTypeInfo(5, typeof(Horse))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ZebuZealot))
			)
		),
		new MiniChampInfo // Zel'Vrak Stronghold
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(10, typeof(DecoyDeployer)),
				new MiniChampTypeInfo(10, typeof(SneakyNinja)),
				new MiniChampTypeInfo(15, typeof(MasterPickpocket))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(ShadowWisp)),
				new MiniChampTypeInfo(10, typeof(Infiltrator))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(ShadowIronElemental)),
				new MiniChampTypeInfo(5, typeof(Spy))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ZelVrak))
			)
		),
		new MiniChampInfo // Zephyr Warden's Domain
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(20, typeof(Spectre)),
				new MiniChampTypeInfo(15, typeof(Wraith)),
				new MiniChampTypeInfo(10, typeof(Shade))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Skeleton)),
				new MiniChampTypeInfo(5, typeof(SkeletalMage))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(AncientLich)),
				new MiniChampTypeInfo(5, typeof(SkeletalLich))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ZephyrWarden))
			)
		),
		new MiniChampInfo // Zor'Thul Abyss
		(
			typeof(MaxxiaScroll),
			new MiniChampLevelInfo // Level 1
			(
				new MiniChampTypeInfo(15, typeof(GreenGoblin)),
				new MiniChampTypeInfo(20, typeof(GrayGoblin)),
				new MiniChampTypeInfo(10, typeof(GreenGoblinAlchemist))
			),
			new MiniChampLevelInfo // Level 2
			(
				new MiniChampTypeInfo(10, typeof(Imp)),
				new MiniChampTypeInfo(10, typeof(PitFiend))
			),
			new MiniChampLevelInfo // Level 3
			(
				new MiniChampTypeInfo(5, typeof(Daemon)),
				new MiniChampTypeInfo(5, typeof(AbysmalHorror))
			),
			new MiniChampLevelInfo // Renowned
			(
				new MiniChampTypeInfo(1, typeof(ZorThul))
			)
		),
        };

        public static MiniChampInfo GetInfo(MiniChampType type)
        {
            int v = (int)type;

            if (v < 0 || v >= m_Table.Length)
                v = 0;

            return m_Table[v];
        }
    }
}