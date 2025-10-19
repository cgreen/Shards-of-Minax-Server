using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPoisons.Effects
{
    public sealed class Whirlwind : IPoisonEffect
    {
        public string Id    => "Whirlwind";
        public string Label => "Whirlwind";
        public int SoundId  => 0; // Optional: add a sound ID if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int Range = 1; // Default range of 1 tile
        private const int MinDamage = 35; // Set to taste
        private const int MaxDamage = 80; // Set to taste

        static Whirlwind() => PoisonEffectRegistry.Register(new Whirlwind());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || !attacker.Alive)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(Range))
            {
                if (m == attacker || !m.Alive || !attacker.CanBeHarmful(m))
                    continue;

                int damage = Utility.RandomMinMax(MinDamage, MaxDamage);
                attacker.DoHarmful(m);
                m.Damage(damage, attacker);

                Visual(m);
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile m)
        {
            // Optionally add a visual effect for whirlwind
            m.FixedParticles(0x3728, 10, 15, 5013, 0x481, 0, EffectLayer.Waist);
            m.SendMessage("You are struck by a swirling force!");
        }
    }
}
