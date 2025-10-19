using System;
using System.Linq;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class CartographyBuff : IPieAttribute
    {
        public string Id    { get { return "CartographyBuff"; } }
        public string Label { get { return "Cartography Bonus"; } }

        public int SoundId
        {
            get { return 0x057; } // bubbling/potion sound
        }

        public void Visual(Mobile m)
        {
            // A quick head‐cloud effect to show “Cartography” flavor
            m.FixedParticles(0x374A, 10, 15, 5036, 0x8A5, 3, EffectLayer.Head);
        }

        static CartographyBuff()
        {
            PieAttributeRegistry.Register(new CartographyBuff());
        }

        public void Apply(Mobile eater)
        {
            int baseBonus = 5;

            // ── 1) Compute TasteID‐scaled bonus (1 extra per 20 points) ────────
            double tasteSkill = eater.Skills[SkillName.TasteID].Value;
            int bonus = baseBonus + (int)(tasteSkill / 20.0);
            bonus = Math.Min(bonus, 15); // cap at +15 total

            TimeSpan dur = TimeSpan.FromMinutes(3);

            // ── 2) If there’s an existing Cartography TimedSkillMod from a pie, remove it ─
            // We look for any SkillMod on “Cartography” that came from a previous pie, and remove it.
            // (Assumes that all pie‐created Cartography mods are TimedSkillMod instances.)
            foreach (SkillMod sk in eater.SkillMods.ToArray())
            {
                // Cast safe: TimedSkillMod exposes a .Skill property in ServUO
                if (sk is TimedSkillMod tsm && tsm.Skill == SkillName.Cartography)
                    tsm.Remove();
            }

            // ── 3) Create and apply the new TimedSkillMod ────────────────────────
            SkillMod mod = new TimedSkillMod(
                SkillName.Cartography,   // the skill to buff
                true,                // relative buff (adds on top of current)
                bonus,               // amount to add
                dur                  // how long before it expires
            );
            eater.AddSkillMod(mod);

            // ── 4) Feedback to the player ────────────────────────────────────────
            eater.SendMessage($"You feel chemically attuned! (+{bonus} Cartography for {dur.TotalMinutes:0} min)");
            if (SoundId >= 0)
                eater.PlaySound(SoundId);
            Visual(eater);
        }
    }
}
