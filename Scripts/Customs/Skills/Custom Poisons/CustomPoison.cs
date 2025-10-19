using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.XmlSpawner2;
using Server.CustomPoisons;

namespace Server.CustomPoisons
{
    public class CustomPoison : Item
    {
        // ---- EFFECTS ----
        public List<string> EffectIds { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hits { get; set; }

        // ── NEW: Wordlists for deterministic name generation ──────────────────
        // You can expand these as you like. Any set of effects will hash into one adjective + one noun.
        private static readonly string[] _Adjectives = new string[]
        {
			"Ibu", "Ace", "Para", "Hydro", "Oxy", "Meth",
			"Bupre", "Morph", "Code", "Fenta", "Trama", "Dexa",
			"Keta", "Prop", "Phen", "Gaba", "Lor", "Diaz",
			"Clon", "Ondan", "Zol", "Ropi", "Alpra", "Fluni",
			"Buspi", "Amitri", "Mirtaz", "Venla", "Trazod", "Nefazod",
			"Aci", "Algi", "Brom", "Calci", "Cephal", "Chlor", "Dex", "Diazep",
			"Doxy", "Erythro", "Fluox", "Guaifen", "Hydro", "Ibupro", "Lorat",
			"Metro", "Napro", "Omepraz", "Paracet", "Penicil", "Pseudo",
			"Ranitid", "Sertral", "Tetracycl", "Venlafax", "Zolpidem",
			"Cetirizine", "Levo", "Rabeprazole", "Azithro", "Montelukast", "Pantoprazole",
			"Risperidone", "Quetiapine", "Olanzapine", "Aripiprazole", "Citalopram", "Escitalopram",
			"Duloxetine", "Metformin", "Glipizide", "Pioglitazone", "Sitagliptin", "Rosiglitazone",
			"Losartan", "Valsartan", "Telmisartan", "Amlodipine", "Hydrochlorothiazide", "Furosemide",
			"Atorvastatin", "Rosuvastatin", "Simvastatin", "Pravastatin", "Fluvastatin", "Lovastatin",
			"Cipro", "Azithro", "Amoxi", "Nitro", "Sulf", "Metform",
			"Predni", "Carbi", "Levo", "Risper", "Queti", "Olanzapine",
			"Aripiprazole", "Fluvoxamine", "Duloxetine", "Escitalopram", "Bupropion"
        };

        private static readonly string[] _Nouns = new string[]
        {
			"profen", "tamin", "codone", "nex", "cet", "dol",
			"nol", "pam", "azepam", "pin", "zolam", "zepam",
			"clone", "stan", "azodone", "zodone", "pride", "lafin",
			"prazole", "zolem", "zapine", "faxine", "zone", "xetine",
			"pirone", "pine", "zine", "zodone", "zodone", "zodone",
			"Tane", "Pam", "Mycin", "Cillin", "Fen", "Phen", "Cet", "Tussin",
			"Stat", "Tab", "Caps", "Gel", "Syrup", "Drops", "Cream", "Ointment",
			"Lotion", "Spray", "Patch", "Inhaler",
			"sartan", "mide", "statin", "glitazone", "diptin", "pril",
			"artan", "vir", "floxacin", "cyclobenzaprine", "oxetine", "irptase",
			"ate", "olol", "ine", "azole", "mab", "nib",
			"Sulfate", "Mide", "Caine", "Pen", "Quine", "Vir",
			"Glipizide", "Mab", "Nib", "Pril", "Sartan", "Tinib",
			"Citalopram", "Ramipril", "Losartan", "Metoprolol", "Hydrochlorothiazide", "Simvastatin"
        };
        // ──────────────────────────────────────────────────────────────────────

        [Constructable]
        public CustomPoison() : base(0xF0A) // Default bottle art
        {
            Weight    = 1.0;
            // We'll override Hue and Name after we know EffectIds:
            Hue       = 0;
            Name      = "unlabeled poison";

            // Initialize collections
            EffectIds = new List<string>();
            Hits       = 3;

            RandomiseIfBlank();
            GenerateNameAndHue();
        }

        public CustomPoison(Serial serial) : base(serial)
        {
            // Deserialization will fill fields; see Deserialize below.
        }

        // --- Double-click: select weapon and apply poison attachment ---
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack to use.
                return;
            }

            from.SendMessage("Select the weapon you wish to coat with this poison.");
            from.Target = new InternalTarget(this);
        }

        private class InternalTarget : Target
        {
            private readonly CustomPoison m_Poison;
            public InternalTarget(CustomPoison poison) : base(2, false, TargetFlags.None)
            {
                m_Poison = poison;
                CheckLOS = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Poison.Deleted)
                    return;

                if (targeted is BaseWeapon weapon)
                {
                    if (!weapon.IsChildOf(from.Backpack) && weapon.Parent != from)
                    {
                        from.SendLocalizedMessage(1062334); // Must have weapon in pack or equipped.
                        return;
                    }

                    // Remove any existing CustomPoisonAttachment
                    object oldObj = XmlAttach.FindAttachment(weapon, typeof(CustomPoisonAttachment));
                    CustomPoisonAttachment old = oldObj as CustomPoisonAttachment;
                    if (old != null && !old.Deleted)
                        old.Delete();

                    // Attach new poison effects
                    CustomPoisonAttachment attach = new CustomPoisonAttachment();
                    if (m_Poison.EffectIds != null)
                    {
                        foreach (string id in m_Poison.EffectIds)
                            attach.AddEffect(id);
                    }
                    attach.Hits = m_Poison.Hits;

                    XmlAttach.AttachTo(weapon, attach);
                    from.SendMessage("You carefully coat the weapon with your custom poison.");
                    m_Poison.Delete();
                }
                else
                {
                    from.SendMessage("That is not a weapon.");
                }
            }
        }

        // ---- UI: show the generated Name instead of “Custom Poison” ----
        public override void AddNameProperty(ObjectPropertyList list)
        {
            // Now Title = Name property (which we generated in GenerateNameAndHue)
            if (!String.IsNullOrEmpty(Name))
                list.Add(Name);
            else
                list.Add("Custom Poison"); // fallback
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            // Show Effects
            if (EffectIds != null && EffectIds.Count > 0)
            {
                List<string> labels = new List<string>();
                foreach (string id in EffectIds)
                {
                    IPoisonEffect pe = PoisonEffectRegistry.Get(id);
                    if (pe != null)
                        labels.Add(pe.Label);
                    else
                        labels.Add(id);
                }

                string joined = String.Join(", ", labels);
                list.Add(1060662, "Effects\t{0}", joined);
            }
            else
            {
                list.Add(1060662, "Effects\tNone");
            }

            // Show Hits
            list.Add(1060663, "Hits\t{0}", Hits);
        }

        // ---- Effect list helpers ----
        public void ClearEffects() 
        {
            if (EffectIds != null)
                EffectIds.Clear();
        }

        public void AddEffect(string id)
        {
            if (EffectIds == null)
                EffectIds = new List<string>();

            if (!EffectIds.Contains(id))
                EffectIds.Add(id);
        }

        // ---- Serialization ----
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

            // Save Effects
            if (EffectIds != null)
            {
                writer.Write(EffectIds.Count);
                foreach (string id in EffectIds)
                    writer.Write(id);
            }
            else
            {
                writer.Write(0);
            }

            // Save Hits
            writer.Write(Hits);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            int count = reader.ReadInt();
            EffectIds = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                string id = reader.ReadString();
                EffectIds.Add(id);
            }

            Hits = reader.ReadInt();

            // If someone placed a “blank” poison (no effects), fill it now
            RandomiseIfBlank();
            GenerateNameAndHue();
        }

        // ---- Utility: roll random effect(s) if blank ----
        private void RandomiseIfBlank()
        {
            if (EffectIds != null && EffectIds.Count > 0)
                return;                  // already configured

            List<IPoisonEffect> pool = PoisonEffectRegistry.All.ToList();
            if (pool.Count == 0)
                return;                 // nothing registered!

            // Shuffle (Fisher–Yates)
            for (int i = pool.Count - 1; i > 0; i--)
            {
                int j = Utility.Random(i + 1);
                IPoisonEffect tmp = pool[i];
                pool[i] = pool[j];
                pool[j] = tmp;
            }

            int toTake = Utility.RandomMinMax(1, Math.Min(3, pool.Count));
            EffectIds = new List<string>();
            for (int k = 0; k < toTake; k++)
                EffectIds.Add(pool[k].Id);

            Hits = Utility.RandomMinMax(2, 5);
        }

        // ── NEW: Deterministic name & hue generator based on sorted EffectIds ──
        public void GenerateNameAndHue()
        {
            if (EffectIds == null || EffectIds.Count == 0)
            {
                // Fallback if somehow no effects exist
                Name = "Common Poison";
                Hue  = 1;
                return;
            }

            // 1) Sort effect IDs so order is consistent
            List<string> sortedIds = new List<string>(EffectIds);
            sortedIds.Sort(StringComparer.Ordinal);

            // 2) Join them into one seed string
            string seedStr = String.Join("|", sortedIds);

            // 3) Compute a (possibly negative) hash code
            int rawHash = seedStr.GetHashCode();
            int absHash = (rawHash < 0 ? -rawHash : rawHash);

            // 4) Pick adjective index and noun index from that hash
            int adjIndex = absHash % _Adjectives.Length;
            int nounIndex = (absHash >> 8) % _Nouns.Length;
            if (nounIndex < 0)
                nounIndex = -nounIndex % _Nouns.Length;

            Name = _Adjectives[adjIndex] + _Nouns[nounIndex];

            // 5) Pick a hue in [1..3000]
            int candidate = ((absHash >> 16) % 3000) + 1;
            if (candidate < 1)
                candidate = 1;
            if (candidate > 3000)
                candidate = (candidate % 3000) + 1;
            Hue = candidate;
        }
        // ──────────────────────────────────────────────────────────────────────
    }
}
