using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class DreamWeave : IPoisonEffect
    {
        public string Id    => "DreamWeave";
        public string Label => "Dream Weave";
        public int SoundId  => -1; // No specific sound; add if needed

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(45);
        private static readonly TimeSpan Duration   = TimeSpan.FromSeconds(45);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int HealAmount = 15;

        static DreamWeave() => PoisonEffectRegistry.Register(new DreamWeave());

		public void Visual(Mobile caster)
		{
			if (caster?.Map == null) return;

			caster.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* The creature weaves a comforting illusion! *");

			Server.Effects.SendLocationParticles(
				EffectItem.Create(caster.Location, caster.Map, EffectItem.DefaultDuration),
				0x3728, 10, 30, 1154, 0, 0, 0
			);


		}


        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            Visual(attacker);

            foreach (Mobile target in attacker.GetMobilesInRange(5))
            {
                if (target == attacker || !target.Alive)
                    continue;

                target.SendMessage("You feel a soothing aura that heals your wounds and strengthens your resolve.");
                target.Heal(HealAmount);
                target.SendMessage("You feel stronger and more resilient!");

                target.AddStatMod(new StatMod(StatType.Str, "DreamWeave", 10, Duration));
                target.AddStatMod(new StatMod(StatType.Dex, "DreamWeave", 10, Duration));
                target.AddStatMod(new StatMod(StatType.Int, "DreamWeave", 10, Duration));
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
