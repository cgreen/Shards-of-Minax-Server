// IronSwordBlueprint.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Items
{
    public class IronSwordBlueprint : CraftingBlueprint
    {
        // Parameterless ctor used when the blueprint spawns or is created
        [Constructable]
        public IronSwordBlueprint()
            : base(
                // ① The product: create an IronSword (no extra ctor args)
                new BlueprintTarget(typeof(VikingSword)),

                // ② The fixed recipe: 30 Iron Ingots + 5 Leather Straps
                new[]
                {
                    new MaterialEntry(typeof(IronIngot), 30),
                    new MaterialEntry(typeof(Hides), 5)
                },

                // ③ Is it an “original”? false = finite‐runs copy
                original: false,

                // ④ Number of runs
                runs: 10,

                // ⑤ out params—these will still pick a random skill req.
                out SkillName skillReq,
                out double  skillVal
            )
        {
            // (optional) rename to highlight it's a special blueprint
            Name = $"Iron Sword Blueprint ({RunsRemaining} runs) — requires {skillReq} ≥ {skillVal:0}";
        }

        // Deserialization ctor
        public IronSwordBlueprint(Serial serial) : base(serial)
        {
        }

        // Explicitly override Serialize and Deserialize
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
