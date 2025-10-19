using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomPoisons
{
    public class PropertyListGump : Gump
    {
        public PropertyListGump(Mobile viewer, Item ingredient)
            : base(100, 100)
        {
            Closable   = true;
            Disposable = true;

            AddPage(0);
            AddBackground(0, 0, 340, 260, 9270);

            AddLabel(95, 15, 0x44F, "Ingredient Properties");

            // Show the ingredient’s name (or its type name if Name is null/empty)
            string ingName = !String.IsNullOrWhiteSpace(ingredient.Name)
                             ? ingredient.Name
                             : ingredient.GetType().Name;
            AddLabel(30, 45, 0x34, ingName);

            //
            // ── NEW: Show “Poisoning Skill Required: X%” ───────────────────
            //
            double reqSkill = PoisonersGump.GetIngredientSkillReq(ingredient);
            AddLabel(30, 75, 0x44F, $"Poisoning Skill Required: {reqSkill:0}%");
            //
            // ── SHIFT the rest of the content downward ───────────────────
            //

            // Headers (Property / Skill Needed)
            AddLabel(30, 100, 0x44F, "Property");
            AddLabel(240, 100, 0x44F, "Skill Needed");

            // Determine how many rows to show, based on the viewer’s Poisoning skill
            double poisonSkill = 0.0;
            var poisonObj = viewer.Skills[SkillName.Poisoning];
            if (poisonObj != null)
                poisonSkill = poisonObj.Value;

            int visibleCount;
            if (poisonSkill >= 100.0) visibleCount = 4;
            else if (poisonSkill >= 75.0)  visibleCount = 3;
            else if (poisonSkill >= 50.0)  visibleCount = 2;
            else if (poisonSkill >= 25.0)  visibleCount = 1;
            else                           visibleCount = 0;

            // Get the full (0–4) effect IDs for this ingredient
            List<string> allEffects = PoisonersGump.GetEffectsFor(ingredient);

            int y = 125; // start below the headers

            if (visibleCount == 0)
            {
                AddLabel(30, y, 0xFF0000, "You can't discern any properties.");
                return;
            }

            // Only display up to visibleCount rows
            int toRender = Math.Min(visibleCount, allEffects.Count);

            // These thresholds match the “poison‐effect” thresholds (25, 50, 75, 100)
            double[] reqs = { 25.0, 50.0, 75.0, 100.0 };

            for (int i = 0; i < toRender; i++, y += 25)
            {
                var effDef = PoisonEffectRegistry.Get(allEffects[i]);
                string label = (effDef != null ? effDef.Label : allEffects[i]);

                // Draw the effect name
                AddLabel(30, y, 0x66D, label);

                // Draw the “Skill Needed” text: e.g. "25%" or "50%" etc.
                AddLabel(260, y, 0x44F, $"{reqs[i]:0}%");
            }
        }
    }
}
