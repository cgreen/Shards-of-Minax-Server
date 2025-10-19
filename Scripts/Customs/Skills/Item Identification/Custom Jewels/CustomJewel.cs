using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2; // for BaseSocketAugmentation
using Server.CustomJewels;        // for IJewelProperty & JewelPropertyRegistry

namespace Server.CustomJewels
{
    public class CustomJewel : BaseSocketAugmentation
    {
        // ── Stored property IDs ─────────────────────────────────────────────
        public List<string> PropertyIds { get; set; }

        // ---- Deterministic name/hue generator (identical logic to the poison system) ------------
        private static readonly string[] _Adj = new string[]
        {
            "Glinting", "Radiant", "Gleaming", "Polished", "Lustrous", "Enchanted", "Brilliant", "Faceted",
            "Prismatic", "Mystic", "Glowing", "Refined", "Glimmering", "Lucid", "Starlit", "Twinkling",
            "Shimmering", "Crystalline", "Ethereal", "Dazzling", "Flickering", "Iridescent", "Celestial",
            "Twilight", "Moonlit", "Sunforged", "Burnished", "Runed", "Arcane", "Glittering", "Sacred",
            "Blazing", "Frosted", "Obsidian", "Violet", "Amber", "Verdant", "Azure", "Carmine", "Sable",
            "Viridian", "Umbral", "Solar", "Abyssal", "Opalescent", "Chromatic", "Onyx", "Stormy", "Luminous",
            "Auric", "Silken", "Resplendent", "Dusky", "Searing", "Frozen", "Molten", "Whispering", "Warded",
            "Antique", "Celestine", "Thundering", "Enigmatic", "Gloaming", "Jeweled", "Shadowed", "Radiative",
            "Beaming", "Fabled", "Runic", "Mythic", "Hallowed", "Gilded", "Scarlet", "Cerulean", "Glacial",
            "Infernal", "Tarnished", "Opulent", "Mystical"
        };

        private static readonly string[] _Noun = new string[]
        {
            "Ruby", "Emerald", "Sapphire", "Topaz", "Amethyst", "Diamond", "Garnet", "Opal",
            "Spinel", "Jade", "Quartz", "Peridot", "Zircon", "Obsidian", "Onyx", "Moonstone",
            "Tourmaline", "Citrine", "Aquamarine", "Amber", "Crystal", "Gem", "Stone", "Shard",
            "Prism", "Facet", "Core", "Heart", "Eye", "Focus", "Tear", "Flame", "Whisper",
            "Star", "Glow", "Spark", "Lode", "Soul", "Dust", "Relic", "Sigil", "Ember", "Echo",
            "Chime", "Nova", "Glint", "Blaze", "Wisp", "Rune", "Beacon", "Pulse", "Charge",
            "Vein", "Spire", "Crown", "Band", "Cluster", "Link", "Knot", "Drop", "Clasp",
            "Mirror", "Halo", "Ring", "Loop", "Fang", "Shardling", "Crux", "Seed", "Hue",
            "Glare", "Trace", "Helix", "Bond", "Orb", "Mark", "Thread", "Charm"
        };
        // ──────────────────────────────────────────────────────────────────────

        // ── Constructors & Randomisation ─────────────────────────────────────
        public CustomJewel(Serial serial) : base(serial)
        {
            PropertyIds = new List<string>();
        }

        [Constructable]
        public CustomJewel() : base(0x468A) // little gem art
        {
            Weight      = 1.0;
            PropertyIds = new List<string>();

            // If no properties were assigned “by hand,” pick some at random:
            RandomiseIfBlank();

            // Now set Name + Hue based on those randomized PropertyIds
            GenerateNameAndHue();
        }

        /// <summary>
        /// If PropertyIds is empty, pick 1–3 random IJewelProperty.Id from the registry.
        /// (Same pattern as CustomPoison.RandomiseIfBlank.)
        /// </summary>
        private void RandomiseIfBlank()
        {
            if (PropertyIds != null && PropertyIds.Count > 0)
                return; // already has properties

            // Build a mutable list of all registered IJewelProperty
            var pool = JewelPropertyRegistry.All.ToList();
            if (pool.Count == 0)
                return; // no properties registered at all

            // Shuffle via Fisher–Yates (Utility.Random is Ultima’s RNG)
            for (int i = pool.Count - 1; i > 0; i--)
            {
                int j = Utility.Random(i + 1);
                var tmp = pool[i];
                pool[i]   = pool[j];
                pool[j]   = tmp;
            }

            // Decide how many properties to take: 1–3 (you can tweak this)
            int toTake = Utility.RandomMinMax(2, Math.Min(6, pool.Count));
            PropertyIds = new List<string>();
            for (int i = 0; i < toTake; i++)
                PropertyIds.Add(pool[i].Id);
        }
        // ────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Deterministic name/hue generator (identical logic to the poison system).
        /// </summary>
        public void GenerateNameAndHue()
        {
            if (PropertyIds == null || PropertyIds.Count == 0)
            {
                Name = "Common Jewel";
                Hue  = 1;
                return;
            }

            // 1) Sort property IDs so the seed is consistent
            var sorted = new List<string>(PropertyIds);
            sorted.Sort(StringComparer.Ordinal);

            // 2) Join → hash → choose adjective & noun
            string seedStr = String.Join("|", sorted);
            int    rawHash = seedStr.GetHashCode();
            int    absHash = rawHash < 0 ? -rawHash : rawHash;

            int adjIndex  = absHash % _Adj.Length;
            int nounIndex = ((absHash >> 8) & 0x7FFFFFFF) % _Noun.Length;

            Name = _Adj[adjIndex] + " " + _Noun[nounIndex];

            // 3) Hue in [1..3000]
            int candidate = (((absHash >> 16) & 0x7FFFFFFF) % 3000) + 1;
            Hue = candidate < 1
                ? 1
                : (candidate > 3000 ? ((candidate % 3000) + 1) : candidate);
        }

        /// <summary>
        /// Only weapons, armor, shields, and creatures are valid targets.
        /// </summary>
        public override bool CanAugment(Mobile from, object target)
        {
            return (target is BaseWeapon) || (target is BaseArmor)
                   || (target is BaseShield) || (target is BaseCreature);
        }

        public override bool OnAugment(Mobile from, object target)
        {
            // Apply every stored property. (Reverse effects would go in OnRecover if desired.)
            if (PropertyIds != null)
            {
                foreach (string id in PropertyIds)
                {
                    IJewelProperty prop = JewelPropertyRegistry.Get(id);
                    prop?.Apply(from, target);
                }
            }
            return true;
        }

        public override bool OnRecover(Mobile from, object target, int version)
        {
            // If you want to “undo” each property at removal time, implement that here.
            return true;
        }

        // ── These five overrides replace the assignments that were causing CS0200 errors ───────────────────
        public override bool UseGumpArt       => true;
        public override int  Icon             => ItemID;
        public override int  IconXOffset      => 15;
        public override int  IconYOffset      => 15;
        public override int  SocketsRequired  => 1;
		public override string OnIdentify(Mobile from) => "Socket Jewel";

        // ──────────────────────────────────────────────────────────────────────────────────────────────────



		// ❷ List the stored property labels (or “None”)
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (PropertyIds != null && PropertyIds.Count > 0)
			{
				var labels = new List<string>();
				foreach (string id in PropertyIds)
				{
					IJewelProperty p = JewelPropertyRegistry.Get(id);
					labels.Add(p != null ? p.Label : id);
				}

				string joined = string.Join(", ", labels);
				// 1060662 = “~1_NOTHING~”
				list.Add(1060662, "Properties\t{0}", joined);
			}
			else
			{
				list.Add(1060662, "Properties\tNone");
			}
		}

        // ── Serialization ────────────────────────────────────────────────────
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

            if (PropertyIds == null)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write(PropertyIds.Count);
                foreach (string id in PropertyIds)
                    writer.Write(id);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            int count = reader.ReadInt();
            PropertyIds = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                string id = reader.ReadString();
                PropertyIds.Add(id);
            }

            // If somehow no properties survived, fill them now
            RandomiseIfBlank();

            // Recompute name & hue so it matches those PropertyIds
            GenerateNameAndHue();
        }
    }
}
