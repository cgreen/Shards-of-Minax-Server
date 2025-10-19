using System;
using System.Linq;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class ItemIDBuff : IPieAttribute
    {
        public string Id    { get { return "ItemIDBuff"; } }
        public string Label { get { return "ItemID Bonus"; } }

        public int SoundId
        {
            get { return 0x057; } // bubbling/potion sound
        }

        public void Visual(Mobile m)
        {
            // A quick head‐cloud effect to show “ItemID” flavor
            m.FixedParticles(0x374A, 10, 15, 5036, 0x8A5, 3, EffectLayer.Head);
        }

        static ItemIDBuff()
        {
            PieAttributeRegistry.Register(new ItemIDBuff());
        }

        public void Apply(Mobile eater)
        {
            int baseBonus = 5;

            // ── 1) Compute TasteID‐scaled bonus (1 extra per 20 points) ────────
            double tasteSkill = eater.Skills[SkillName.TasteID].Value;
            int bonus = baseBonus + (int)(tasteSkill / 20.0);
            bonus = Math.Min(bonus, 15); // cap at +15 total

            TimeSpan dur = TimeSpan.FromMinutes(3);

            // ── 2) If there’s an existing ItemID TimedSkillMod from a pie, remove it ─
            // We look for any SkillMod on “ItemID” that came from a previous pie, and remove it.
            // (Assumes that all pie‐created ItemID mods are TimedSkillMod instances.)
            foreach (SkillMod sk in eater.SkillMods.ToArray())
            {
                // Cast safe: TimedSkillMod exposes a .Skill property in ServUO
                if (sk is TimedSkillMod tsm && tsm.Skill == SkillName.ItemID)
                    tsm.Remove();
            }

            // ── 3) Create and apply the new TimedSkillMod ────────────────────────
            SkillMod mod = new TimedSkillMod(
                SkillName.ItemID,   // the skill to buff
                true,                // relative buff (adds on top of current)
                bonus,               // amount to add
                dur                  // how long before it expires
            );
            eater.AddSkillMod(mod);

            // ── 4) Feedback to the player ────────────────────────────────────────
            eater.SendMessage($"You feel chemically attuned! (+{bonus} ItemID for {dur.TotalMinutes:0} min)");
            if (SoundId >= 0)
                eater.PlaySound(SoundId);
            Visual(eater);
        }
    }
}
