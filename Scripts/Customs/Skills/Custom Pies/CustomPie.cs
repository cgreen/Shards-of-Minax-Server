using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomPies
{
    public class CustomPie : Item
    {
        // ── List of attribute IDs this pie carries ─────────────────
        public List<string> AttributeIds { get; set; }

        // Each serving is “one eat” (reduce Servings by 1 on double-click)
        [CommandProperty(AccessLevel.GameMaster)]
        public int Servings { get; set; }

        // A small wordlist to build pie names: adjectives and nouns.
        // Feel free to expand or replace these.
        private static readonly string[] _Adjectives = new string[]
        {
			"Apple", "Blueberry", "Cherry", "Chocolate", "Coconut", "Coffee",
			"Custard", "Lemon", "Pecan", "Pumpkin", "Raspberry", "Strawberry",
			"Vanilla", "Walnut", "Banana", "Carrot", "Cheese", "Cinnamon",
			"Ginger", "Honey", "Orange", "Pineapple", "Poppy", "Raisin",
			"Rum", "Almond", "Apricot", "Blackberry", "Caramel", "Fig",
			"Grapefruit", "Hazelnut", "Kiwi", "Lime", "Mango", "Maple",
			"Nutmeg", "Oatmeal", "Peanut", "Quince", "Rose", "Sesame",
			"Tangerine", "Ube", "Violet", "Watermelon", "Xmas", "Zucchini",
			"Cinnamon", "Coconut", "Cream", "Date", "Ginger", "Honey",
			"Maple", "Mincemeat", "Pineapple", "Poppy", "Raisin", "Red Velvet",
			"Rhubarb", "Rum", "Sour Cream", "Spice", "Yellow",
			"Avocado", "Baileys", "Basil", "Blackcurrant", "Butterscotch", "Cherry",
			"Chili", "Citrus", "Cointreau", "Crème Brûlée", "Dulce de Leche", "Earl Grey",
			"Espresso", "Fudge", "Galangal", "Green Tea", "Hibiscus", "Icing",
			"Jam", "Kahlúa", "Lavender", "Marzipan", "Nougat", "Oreo",
			"Pistachio", "Quark", "Ricotta", "Saffron", "Tiramisu", "Umami",
			"Vanilla Bean", "Whiskey", "Yogurt", "Zest", "Pumpkin Spice", "Matcha",
			"Cardamom", "Buttermilk", "Cranberry", "Hazelnut Praline", "Ganache",
			"Black Forest", "Passion Fruit", "Baklava", "Peach", "Mint", "Coconut Cream",
			"Lemon Zest", "Cherry Blossom", "Earl Grey Tea", "Blueberry Lemon", "Raspberry Rose",
			"Mocha", "Salted Caramel", "Pineapple Coconut", "Lavender Honey", "Chai Spice",
			"Toffee", "Earl Grey Lavender", "Strawberry Basil", "Chocolate Orange", "Almond Joy",
			"Lemon Poppy Seed", "Gingerbread", "Peach Cobbler", "Raspberry White Chocolate",
			"Mango Tango", "Coconut Lime", "Lemon Blueberry", "Orange Cranberry", "Pistachio Rosewater",
			"Apple", "Banana", "Cherry", "Date", "Elderberry", "Fig",
			"Grape", "Honeydew", "Kiwi", "Lemon", "Mango", "Nectarine",
			"Orange", "Peach", "Quince", "Raspberry", "Strawberry", "Tangerine",
			"Uva", "Watermelon", "Xigua", "Yellow Passion Fruit", "Zucchini",
			"Apricot", "Blueberry", "Clementine", "Dragon Fruit", "Feijoa",
			"Guava", "Huckleberry", "Jabuticaba", "Kumquat", "Lychee",
			"Mulberry", "Nashi Pear", "Olallieberry", "Pomegranate", "Quenepa",
			"Rambutan", "Salal Berry", "Tamarillo", "Ugli Fruit", "Victoria Plum",
			"Wax Apple", "Yuzu", "Zapote",
			"Ambarella", "Bilimbi", "Cupuaçu", "Durian", "Eggfruit",
			"Finger Lime", "Gac Fruit", "Hala Fruit", "Imbe", "Jujube",
			"Kiwano", "Longan", "Mangosteen", "Noni Fruit", "Olive",
			"Papaya", "Quararibea Cordata", "Roselle", "Soursop", "Tamarind",
			"Uvaria", "Vanilla Bean", "Wampee", "Xylocarp", "Yumberry",
			"Zalzalak", "Açaí", "Barbadine", "Cupuacu", "Duku", "Elaeagnus Latifolia",
			"Fennel Fruit", "Galia Melon", "Horned Melon", "Ice Cream Bean",
			"Jatoba", "Kiwiberry", "Limequat", "Muntingia Calabura", "Nance",
			"Oca", "Papino", "Quandong", "Rutabaga", "Sugar Apple",
			"Tangor", "Ulluco", "Vanilla Clamshell", "White Sapote", "Ximenia",
			"Yacón", "Zig Zag Vine Fruit"			
        };

		private static readonly string[] _Nouns = new string[]
		{
			"Pie",
			"Tart",
			"Fritter",
			"Turnover",
			"Pastry",
			"Strudel",
			"Crumb",
			"Delight",
			"Treat",
			"Surprise",
			"Bite",
			"Slice",
			"Crust",
			"Feast",
			"Concoction",
			"Layer",
			"Swirl",
			"Twist",
			"Morsel",
			"Stack",
			"Pudding",
			"Cruller",
			"Puff",
			"Crumble",
			"Torte",
			"Flan",
			"Clafoutis",
			"Soufflé",
			"Galette",
			"Empanada",
			"Cobbler",
			"Dumpling",
			"Quiche",
			"Foldover",
			"Roll",
			"Pouch",
			"Bundle",
			"Pocket",
			"Knead",
			"Dough",
			"Brûlée",
			"Pasty",
			"Slicelet",
			"Drizzle",
			"Filling",
			"Infusion",
			"Dusting",
			"Topping",
			"Layercake",
			"Wedge",
			"Nibbler",
			"Shell",
			"Cakelet",
			"Ripple",
			"Goblet",
			"Infusion",
			"Fusion",
			"Compote",
			"Sliver",
			"Graham",
			"Flake",
			"Drip",
			"Crescent",
			"Spoonful",
			"Nest",
			"Whip",
			"Charm",
			"Mystery",
			"Wonder",
			"Sweetling",
			"Indulgence",
			"Bliss",
			"Sin",
			"Temptation",
			"Whirl",
			"Spiral",
			"Crave",
			"Decadence",
			"Luxury",
			"Elation",
			"Cheesecake",
			"Mash",
			"Froth",
			"Muffin",
			"Bun",
			"Tuffet",
			"Roulade",
			"Brownie",
			"Bar",
			"Loaf",
			"Slab",
			"Plait",
			"Weave",
			"Knot",
			"Braid",
			"Eclair",
			"Profiterole",
			"Choux",
			"Croissant"
		};

        [Constructable]
        public CustomPie() : base(0x1041)  // 0x1041 is pie graphic
        {
            Weight = 1.0;
            // We'll override Hue after generating it
            Hue    = 0;             
            Name   = "unlabeled pie"; 

            // Initialize the list
            AttributeIds = new List<string>();
            Servings     = 1;

            RandomiseIfBlank();
            GenerateNameAndHue();      // ← set Name & Hue based on AttributeIds
        }

        public CustomPie(Serial serial) : base(serial)
        {
            // Deserialization will call Deserialize below
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001);
                return;
            }

            if (from.Hits < from.HitsMax)
                from.PlaySound(0x03A);

            if (AttributeIds != null)
            {
                foreach (string id in AttributeIds)
                {
                    IPieAttribute attr = PieAttributeRegistry.Get(id);
                    if (attr != null)
                        attr.Apply(from);
                }
            }

            Servings--;
            if (Servings <= 0)
                Delete();
            else
                InvalidateProperties();
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (AttributeIds != null && AttributeIds.Count > 0)
            {
                List<string> labels = new List<string>();
                foreach (string id in AttributeIds)
                {
                    IPieAttribute pa = PieAttributeRegistry.Get(id);
                    if (pa != null)
                        labels.Add(pa.Label);
                    else
                        labels.Add(id);
                }

                string joined = String.Join(", ", labels);
                list.Add(1060662, "Properties\t{0}", joined);
            }
            else
            {
                list.Add(1060662, "Properties\tNone");
            }

            list.Add(1060663, "Servings\t{0}", Servings);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

            writer.Write(Servings);

            if (AttributeIds != null)
            {
                writer.Write(AttributeIds.Count);
                foreach (string id in AttributeIds)
                    writer.Write(id);
            }
            else
            {
                writer.Write(0);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            Servings = reader.ReadInt();
            int count = reader.ReadInt();

            AttributeIds = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                string id = reader.ReadString();
                AttributeIds.Add(id);
            }

            // If someone spawned this pie via loot tables, it might have no attributes; fix it.
            RandomiseIfBlank();
            GenerateNameAndHue();
        }

        // ── If no attributes were ever set, pick 1–3 random ones ───────────────
        private void RandomiseIfBlank()
        {
            if (AttributeIds != null && AttributeIds.Count > 0)
                return;

            List<IPieAttribute> pool = PieAttributeRegistry.All.ToList();
            if (pool.Count == 0)
                return;

            // Fisher–Yates shuffle
            for (int i = pool.Count - 1; i > 0; i--)
            {
                int j = Utility.Random(i + 1);
                IPieAttribute tmp = pool[i];
                pool[i] = pool[j];
                pool[j] = tmp;
            }

            int toTake = Utility.RandomMinMax(1, Math.Min(3, pool.Count));
            AttributeIds = new List<string>();
            for (int k = 0; k < toTake; k++)
                AttributeIds.Add(pool[k].Id);

            Servings = Utility.RandomMinMax(1, 3);
        }

        // ── Derive Name & Hue from the sorted list of AttributeIds ────────────────
        public void GenerateNameAndHue()
        {
            if (AttributeIds == null || AttributeIds.Count == 0)
            {
                // In case someone calls it early; just pick a fallback name
                Name = "Ordinary Pie";
                Hue  = 1;
                return;
            }

            // 1) Sort the IDs so the order is deterministic
            List<string> sorted = new List<string>(AttributeIds);
            sorted.Sort(StringComparer.Ordinal);

            // 2) Build a single string “id1|id2|id3…”
            string seedStr = String.Join("|", sorted);

            // 3) Get a stable hash code (int can be negative)
            int hash = seedStr.GetHashCode();
            int absHash = (hash < 0 ? -hash : hash);

            // 4) Pick adjective and noun
            int adjIndex = absHash % _Adjectives.Length;
            int nounIndex = (absHash >> 8) % _Nouns.Length;
            if (nounIndex < 0) nounIndex = -nounIndex % _Nouns.Length;

            Name = _Adjectives[adjIndex] + " " + _Nouns[nounIndex];

            // 5) Compute a hue between 1 and 3000
            //    (take some bits of the hash so it isn't too obvious)
            int hueCandidate = ((absHash >> 16) % 3000) + 1;
            if (hueCandidate < 1) hueCandidate = 1;
            if (hueCandidate > 3000) hueCandidate = hueCandidate % 3000 + 1;
            Hue = hueCandidate;
        }
    }
}
