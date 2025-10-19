using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class Lightning : IPoisonEffect
    {
        public string Id    => "Lightning";
        public string Label => "Lightning";
        public int SoundId  => -1; // No sound associated in original XML, set to -1 or assign if needed

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static Lightning() => PoisonEffectRegistry.Register(new Lightning());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            int damage = Utility.RandomMinMax(50, 215); // Adjustable based on XML behavior (random within max)

            // Visual effect
            defender.BoltEffect(0);

            // Apply energy damage
            SpellHelper.Damage(TimeSpan.Zero, defender, attacker, damage, 0, 0, 0, 0, 100);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile target)
        {
            // Optional: you can implement this for passive visual cues if needed.
        }
    }
}
