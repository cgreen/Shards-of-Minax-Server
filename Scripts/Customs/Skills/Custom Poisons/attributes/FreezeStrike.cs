// Scripts/CustomPoisons/Effects/FreezeStrike.cs
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomPoisons.Effects
{
    public sealed class FreezeStrike : IPoisonEffect
    {
        public string Id    => "FreezeStrike";
        public string Label => "Freeze Strike";
        public int SoundId  => -1; // Optional: define a sound effect ID if needed

        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static FreezeStrike() => PoisonEffectRegistry.Register(new FreezeStrike());

        public void Visual(Mobile m)
        {
            m.SendMessage("You've been frozen!");
            // Optional: Add particle effects here if you want
            // Example: m.FixedEffect(0x376A, 10, 20); // ice-like effect
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (defender == null || DateTime.UtcNow < _nextAllowed)
                return;

            defender.Freeze(Duration);
            Visual(defender);

            _nextAllowed = DateTime.UtcNow + Duration;
        }
    }
}
