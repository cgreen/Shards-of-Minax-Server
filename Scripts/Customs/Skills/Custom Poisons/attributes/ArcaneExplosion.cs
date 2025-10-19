using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class ArcaneExplosion : IPoisonEffect
    {
        public string Id    => "ArcaneExplosion";
        public string Label => "Arcane Explosion";
        public int SoundId  => -1; // Replace with a valid sound ID if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int Radius = 3; // Explosion range
        private const int MinDamage = 25;
        private const int MaxDamage = 100;

        static ArcaneExplosion()
        {
            PoisonEffectRegistry.Register(new ArcaneExplosion());
        }

        public void Visual(Mobile target)
        {
            target.FixedParticles(0x36BD, 20, 10, 5044, 0x481, 0, EffectLayer.Waist);
            target.SendMessage("You are engulfed in arcane energy!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || !attacker.Alive)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(Radius))
            {
                if (m != attacker && m.Alive && m.Map == attacker.Map)
                {
                    int damage = Utility.RandomMinMax(MinDamage, MaxDamage);
                    m.Damage(damage, attacker);
                    Visual(m);
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
