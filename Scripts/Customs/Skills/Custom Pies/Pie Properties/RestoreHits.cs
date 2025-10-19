using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class RestoreHits : IPieAttribute
    {
        public string Id    { get { return "RestoreHits"; } }
        public string Label { get { return "Restore Health"; } }

        public int SoundId
        {
            get { return 0x0F9; } // sipping sound
        }

        public void Visual(Mobile m)
        {
            m.FixedEffect(0x373A, 10, 30); // green heal particles
        }

        // Static constructor registers this attribute at startup
        static RestoreHits()
        {
            PieAttributeRegistry.Register(new RestoreHits());
        }

		public void Apply(Mobile eater)
		{
			int baseHeal = Utility.RandomMinMax(10, 25);

			// TasteID skill bonus
			double tasteSkill = eater.Skills[SkillName.TasteID].Value;
			double multiplier = 1.0 + (tasteSkill / 100.0); // e.g., 100 TasteID → x2 healing
			int totalHeal = (int)Math.Round(baseHeal * multiplier);

			eater.Heal(totalHeal);
			eater.SendMessage($"You feel reinvigorated (+{totalHeal} HP).");

			if (SoundId >= 0)
				eater.PlaySound(SoundId);

			Visual(eater);
		}

    }
}
