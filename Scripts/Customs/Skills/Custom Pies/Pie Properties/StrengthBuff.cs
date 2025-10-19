using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class StrengthBuff : IPieAttribute
    {
        public string Id    { get { return "StrengthBuff"; } }
        public string Label { get { return "Strength"; } }

        public int SoundId
        {
            get { return 0x03A; } // grunt / power‐up
        }

        public void Visual(Mobile m)
        {
            m.FixedParticles(0x3779, 1, 15, 2013, 0x48, 7, EffectLayer.Waist);
        }

        static StrengthBuff()
        {
            PieAttributeRegistry.Register(new StrengthBuff());
        }

		public void Apply(Mobile eater)
		{
			int baseBonus = 5;

			double tasteSkill = eater.Skills[SkillName.TasteID].Value;
			int bonus = baseBonus + (int)Math.Floor(tasteSkill / 20.0); // +1 STR per 20 TasteID
			TimeSpan dur = TimeSpan.FromMinutes(2);

			// Remove old mod (if any), then reapply updated one
			eater.RemoveStatMod("PieStr");

			StatMod mod = new StatMod(StatType.Str, "PieStr", bonus, dur);
			eater.AddStatMod(mod);

			eater.SendMessage($"+{bonus} STR for {dur.TotalMinutes:0} min.");

			if (SoundId >= 0)
				eater.PlaySound(SoundId);

			Visual(eater);
		}

    }
}
