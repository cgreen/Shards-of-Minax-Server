using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomPies
{
    public class IngredientPropertiesGump : Gump
    {
        public IngredientPropertiesGump(Mobile viewer, Item ing)
            : base(150, 100)
        {
            Closable   = true;
            Disposable = true;

            AddPage(0);
            AddBackground(0, 0, 340, 260, 9270);
            AddLabel(70, 15, 0x44F, "Ingredient Properties");

            // Show the item’s name (or its class name if Name is empty)
            string displayName = String.IsNullOrWhiteSpace(ing.Name)
                ? ing.GetType().Name
                : ing.Name;
            AddLabel(30, 45, 0x34, displayName);

            //
            // ── NEW: Show “Cooking Skill Required: X%” for this ingredient ────────
            //
            double reqSkill = MagicalOvenGump.GetIngredientSkillReq(ing);
            AddLabel(30, 75, 0x44F, $"Cooking Skill Required: {reqSkill:0}%");
            //
            // Adjust the Y‐offset for the rest of the content accordingly.
            //
            // Determine how many rows to show, based on TasteID skill
            double tasteSkill = 0.0;
            Skill tasteObj = viewer.Skills[SkillName.TasteID];
            if (tasteObj != null)
                tasteSkill = tasteObj.Value;

            int visibleCount;
            if (tasteSkill >= 100.0) visibleCount = 4;
            else if (tasteSkill >=  75.0) visibleCount = 3;
            else if (tasteSkill >=  50.0) visibleCount = 2;
            else if (tasteSkill >=  25.0) visibleCount = 1;
            else                       visibleCount = 0;

            // Get the full (0–4) attribute IDs for this ingredient
            List<string> allEffects = MagicalOvenGump.EffectsFor(ing);

            int y = 115; // start here so it’s below the “Cooking Skill Required” line

            if (visibleCount == 0)
            {
                AddLabel(30, y, 0xFF0000, "You can't discern any properties.");
                return;
            }

            // Only display up to visibleCount rows
            int toRender = Math.Min(visibleCount, allEffects.Count);
            double[] req = new double[] { 25.0, 50.0, 75.0, 100.0 };

            for (int i = 0; i < toRender; i++, y += 25)
            {
                string id = allEffects[i];
                IPieAttribute pa = PieAttributeRegistry.Get(id);
                string label = (pa != null) ? pa.Label : id;

                // Draw the property name and the “Skill Needed” column
                AddLabel(30, y, 0x66D, label);
                AddLabel(260, y, 0x44F, $"{req[i]:0}%");
            }
        }
    }
}
