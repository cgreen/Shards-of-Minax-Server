using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPies.Attributes
{
    public sealed class RestoreStam : IPieAttribute
    {
        public string Id    { get { return "RestoreStam"; } }
        public string Label { get { return "Restore Stam"; } }

        public int SoundId
        {
            get { return 0x1F8; } // chime sound
        }

        public void Visual(Mobile m)
        {
            m.FixedEffect(0x374A, 10, 20); // blue sparkles
        }

        static RestoreStam()
        {
            PieAttributeRegistry.Register(new RestoreStam());
        }

		public void Apply(Mobile eater)
		{
			int baseStam = Utility.RandomMinMax(10, 20);

			// TasteID skill bonus
			double tasteSkill = eater.Skills[SkillName.TasteID].Value;
			double multiplier = 1.0 + (tasteSkill / 100.0); // 100 TasteID = x2 Stam gain
			int totalStam = (int)Math.Round(baseStam * multiplier);

			int newStam = eater.Stam + totalStam;
			if (newStam > eater.StamMax)
				newStam = eater.StamMax;

			int actualGain = newStam - eater.Stam; // in case of hitting max

			eater.Stam = newStam;
			eater.SendMessage($"+{actualGain} Stam");

			if (SoundId >= 0)
				eater.PlaySound(SoundId);

			Visual(eater);
		}

    }
}
