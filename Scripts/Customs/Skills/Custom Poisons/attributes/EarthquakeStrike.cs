// Scripts/CustomPoisons/Effects/EarthquakeStrike.cs
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class EarthquakeStrike : IPoisonEffect
    {
        public string Id    => "EarthquakeStrike";
        public string Label => "Earthquake Strike";
        public int SoundId  => -1; // No specific sound, you may add one if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int MaxDamage = 50; // You can adjust this as needed
        private const int Radius = 3;

        static EarthquakeStrike() => PoisonEffectRegistry.Register(new EarthquakeStrike());

        public void Visual(Mobile target)
        {
            if (target == null || !target.Alive)
                return;

            target.SendMessage("The ground shakes violently!");
            target.FixedEffect(0x36BD, 10, 20); // Earthquake-style visual effect
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || !attacker.Alive)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(Radius))
            {
                if (m == attacker || !m.Alive)
                    continue;

                int damage = Utility.Random(MaxDamage);

                if (damage > 0)
                {
                    m.Damage(damage, attacker);
                    Visual(m);
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
