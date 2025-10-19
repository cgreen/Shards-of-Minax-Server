// Scripts/CustomPoisons/Effects/Backstab.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Backstab : IPoisonEffect
    {
        public string Id    => "Backstab";
        public string Label => "Backstab";
        public int SoundId  => -1; // No specific sound; adjust if desired

        private static readonly TimeSpan CheckInterval = TimeSpan.FromSeconds(5);
        private static DateTime _lastStealthCheck = DateTime.MinValue;
        private static bool _activated = false;

        static Backstab() => PoisonEffectRegistry.Register(new Backstab());

        public void Visual(Mobile defender)
        {
            defender.FixedParticles(0x3779, 10, 15, 5004, 0x3F3, 0, EffectLayer.CenterFeet); // Optional effect
            defender.SendMessage("You were struck from the shadows!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            if (DateTime.UtcNow - _lastStealthCheck > CheckInterval)
            {
                _activated = attacker.Hidden;
                _lastStealthCheck = DateTime.UtcNow;
            }

            if (_activated)
            {
                int baseDamage = 200; // Fallback base damage, in case needed
                int additionalDamage = (int)(baseDamage * 1.5); // Adjust this if using damageGiven in Apply()

                defender.Damage(additionalDamage, attacker);
                attacker.Say("Backstab!");
                Visual(defender);

                _activated = false; // Reset after use
            }
        }
    }
}
