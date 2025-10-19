using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class RestoreMana : IPieAttribute
    {
        public string Id    { get { return "RestoreMana"; } }
        public string Label { get { return "Restore Mana"; } }

        public int SoundId
        {
            get { return 0x1F8; } // chime sound
        }

        public void Visual(Mobile m)
        {
            m.FixedEffect(0x374A, 10, 20); // blue sparkles
        }

        static RestoreMana()
        {
            PieAttributeRegistry.Register(new RestoreMana());
        }

		public void Apply(Mobile eater)
		{
			int baseMana = Utility.RandomMinMax(10, 20);

			// TasteID skill bonus
			double tasteSkill = eater.Skills[SkillName.TasteID].Value;
			double multiplier = 1.0 + (tasteSkill / 100.0); // 100 TasteID = x2 mana gain
			int totalMana = (int)Math.Round(baseMana * multiplier);

			int newMana = eater.Mana + totalMana;
			if (newMana > eater.ManaMax)
				newMana = eater.ManaMax;

			int actualGain = newMana - eater.Mana; // in case of hitting max

			eater.Mana = newMana;
			eater.SendMessage($"+{actualGain} Mana");

			if (SoundId >= 0)
				eater.PlaySound(SoundId);

			Visual(eater);
		}

    }
}
