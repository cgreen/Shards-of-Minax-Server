using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.CustomJewels;            // <-- your jewel namespace
using Server.CustomJewels.Properties; // <-- if you need to resolve the registry

namespace Server.CustomJewels
{
    public class JewelPropertyListGump : Gump
    {
        public JewelPropertyListGump(Mobile viewer, Item ingredient)
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
            // ── NEW: Show “Item ID Skill Required: X%” ───────────────────
            //
            double reqSkill = JewelersGump.GetIngredientSkillReq(ingredient);
            AddLabel(30, 75, 0x44F, $"Item ID Skill Required: {reqSkill:0}%");
            //
            // ── SHIFT the rest of the content downward ───────────────────
            //

            // Headers (“Property” / “Skill Needed”)
            AddLabel(30, 100, 0x44F, "Property");
            AddLabel(240, 100, 0x44F, "Skill Needed");

            // Determine how many rows to show, based on the viewer’s ItemID skill
            double itemIdSkill = 0.0;
            var skillObj = viewer.Skills[SkillName.ItemID];
            if (skillObj != null)
                itemIdSkill = skillObj.Value;

            int visibleCount;
            if (itemIdSkill >= 100.0)      visibleCount = 4;
            else if (itemIdSkill >= 75.0)  visibleCount = 3;
            else if (itemIdSkill >= 50.0)  visibleCount = 2;
            else if (itemIdSkill >= 25.0)  visibleCount = 1;
            else                           visibleCount = 0;

            // Get the full (0–4) property IDs for this ingredient
            List<string> allProps = JewelersGump.GetEffectsFor(ingredient);

            int y = 125; // start below the headers

            if (visibleCount == 0)
            {
                AddLabel(30, y, 0xFF0000, "You can't discern any properties.");
                return;
            }

            // Only display up to visibleCount rows
            int toRender = Math.Min(visibleCount, allProps.Count);

            // These thresholds match the “jewel‐property” thresholds (25, 50, 75, 100)
            double[] reqs = { 25.0, 50.0, 75.0, 100.0 };

            for (int i = 0; i < toRender; i++, y += 25)
            {
                // Look up the IJewelProperty by ID
                var propDef = JewelPropertyRegistry.Get(allProps[i]);
                string label = (propDef != null ? propDef.Label : allProps[i]);

                // Draw the property name
                AddLabel(30, y, 0x66D, label);

                // Draw the “Skill Needed” text: 25%, 50%, etc.
                AddLabel(260, y, 0x44F, $"{reqs[i]:0}%");
            }
        }
    }
}
