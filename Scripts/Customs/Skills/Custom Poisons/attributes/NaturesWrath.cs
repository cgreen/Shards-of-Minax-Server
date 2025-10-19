using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class NaturesWrath : IPoisonEffect
    {
        public string Id    => "NaturesWrath";
        public string Label => "Nature's Wrath";
        public int SoundId  => -1; // You can assign a sound effect ID here if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static NaturesWrath() => PoisonEffectRegistry.Register(new NaturesWrath());

        public void Visual(Mobile m)
        {
            m.SendMessage("You are entangled by nature's wrath!");
            // You can add particle effects here if you'd like, e.g.:
            // m.FixedParticles(0x376A, 10, 15, 5030, 0x7E2, 0, EffectLayer.Waist);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || !attacker.Alive)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(2)) // 2 tile range
            {
                if (m != attacker && m.Alive && attacker.CanBeHarmful(m))
                {
                    int damage = Utility.RandomMinMax(30, 80); // Adjust this range if needed

                    m.Damage(damage, attacker);
                    Visual(m);
                    m.Paralyze(TimeSpan.FromSeconds(2));
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
