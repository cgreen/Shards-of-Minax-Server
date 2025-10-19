using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class PoisonCloud : IPoisonEffect
    {
        public string Id    => "PoisonCloud";
        public string Label => "Poison Cloud";
        public int SoundId  => 0x22F; // Generic poison sound effect, adjust as needed

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private static readonly int Radius = 2;
        private static readonly int Intensity = 3; // 1 = Lesser ... 5 = Lethal

        static PoisonCloud() => PoisonEffectRegistry.Register(new PoisonCloud());

        public void Visual(Mobile target)
        {
            if (target == null)
                return;

            target.FixedParticles(0x36BD, 20, 10, 5044, 0x8A5, 0, EffectLayer.Waist); // Poison cloud effect
            target.PlaySound(SoundId);
            target.SendMessage("You are engulfed in a poisonous cloud!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(Radius))
            {
                if (m != attacker && m.Alive && attacker.CanBeHarmful(m))
                {
                    ApplyPoisonLevel(attacker, m);
                    Visual(m);
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private void ApplyPoisonLevel(Mobile attacker, Mobile target)
        {
            Poison level = Poison.Regular;

            switch (Intensity)
            {
                case 1: level = Poison.Lesser; break;
                case 2: level = Poison.Regular; break;
                case 3: level = Poison.Greater; break;
                case 4: level = Poison.Deadly; break;
                case 5: level = Poison.Lethal; break;
            }

            target.ApplyPoison(attacker, level);
        }
    }
}
