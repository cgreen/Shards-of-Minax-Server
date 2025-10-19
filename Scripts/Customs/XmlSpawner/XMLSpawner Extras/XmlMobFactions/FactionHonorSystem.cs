using System;
using System.Collections.Generic;
using Server;
using Server.Customs.Invasion_System;        // gives us TownInvasion etc.
using Server.Engines.XmlSpawner2;            // gives us XmlMobFactions

namespace Server.Customs.Invasion_System
{
    public static class FactionHonorSystem
    {
        private class Entry
        {
            public int Max  = 5000;           // tune in config
            public int Current;
        }

        private static readonly Dictionary<XmlMobFactions.GroupTypes, Entry> _honor =
            new Dictionary<XmlMobFactions.GroupTypes, Entry>();

        /* ---------- bootstrap & persistence ---------- */

        static FactionHonorSystem()
        {
            foreach (XmlMobFactions.GroupTypes g in Enum.GetValues(typeof(XmlMobFactions.GroupTypes)))
            {
                if (g != XmlMobFactions.GroupTypes.End_Unused)
                    _honor[g] = new Entry { Current = 5000 };
            }

            EventSink.WorldSave   += OnSave;
            EventSink.WorldLoad   += OnLoad;
        }

        /* ---------- public helpers ---------- */

        public static int  Get(XmlMobFactions.GroupTypes g)                => _honor[g].Current;
        public static void Set(XmlMobFactions.GroupTypes g,int v)          => _honor[g].Current = Math.Max(0,Math.Min(v,_honor[g].Max));

        /// Call this when a MOB that belongs to **g** dies.
        public static void LoseHonor(XmlMobFactions.GroupTypes g, int amount = 1)
        {
            Entry e = _honor[g];
            e.Current = Math.Max(0, e.Current - amount);

            if (e.Current == 0)
            {
                TriggerInvasion(g);
                e.Current = e.Max;            // restore missing honor
            }
        }

        /* ---------- invasion trigger ---------- */

        private static readonly Dictionary<XmlMobFactions.GroupTypes, TownMonsterType> _map =
            new Dictionary<XmlMobFactions.GroupTypes, TownMonsterType>
        {
            { XmlMobFactions.GroupTypes.Undead,      TownMonsterType.Undead     },
            { XmlMobFactions.GroupTypes.Humanoid,    TownMonsterType.Humanoid   },
            { XmlMobFactions.GroupTypes.Arachnid,    TownMonsterType.Arachnid   },
            { XmlMobFactions.GroupTypes.Reptilian,   TownMonsterType.DragonKind },
            { XmlMobFactions.GroupTypes.Elemental,   TownMonsterType.Elementals },
            { XmlMobFactions.GroupTypes.Abyss,       TownMonsterType.Abyss      }
            /* extend as desired */
        };

        private static void TriggerInvasion(XmlMobFactions.GroupTypes g)
        {
            if (!_map.TryGetValue(g, out var monster)) return;

			Array towns = Enum.GetValues(typeof(InvasionTowns));
			InvasionTowns town = (InvasionTowns)towns.GetValue(Utility.Random(towns.Length));

			Array champs = Enum.GetValues(typeof(TownChampionType));
			TownChampionType champ = (TownChampionType)champs.GetValue(Utility.Random(champs.Length));

            var inv = new TownInvasion(town, monster, champ, DateTime.UtcNow);
            inv.OnStart();

            InvasionControl.Invasions.Add(inv);
            World.Broadcast(38, true,
                $"The {g} have mustered an invasion at {town}!");
        }

        /* ---------- simple binary persistence ---------- */
        private static readonly string File = "Saves/Factions/Honor.bin";

        private static void OnSave(WorldSaveEventArgs e)
        {
            Persistence.Serialize(File, w =>
            {
                w.Write(0);                        // version
                w.Write(_honor.Count);
                foreach (var kv in _honor)
                {
                    w.Write((int)kv.Key);
                    w.Write(kv.Value.Current);
                    w.Write(kv.Value.Max);
                }
            });
        }

        private static void OnLoad()
        {
            Persistence.Deserialize(File, r =>
            {
                if (r.ReadInt() != 0) return;      // version
                int count = r.ReadInt();
                for (int i = 0; i < count; i++)
                {
                    var g   = (XmlMobFactions.GroupTypes)r.ReadInt();
                    var cur = r.ReadInt();
                    var max = r.ReadInt();
                    if (_honor.ContainsKey(g))
                    {
                        _honor[g].Current = cur;
                        _honor[g].Max     = max;
                    }
                }
            });
        }
    }
}
