using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class ManaBurn : IPoisonEffect
    {
        public string Id    => "ManaBurn";
        public string Label => "Mana Burn";
        public int SoundId  => 0x1E1; // Optional: pick a burning/energy sound if preferred

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        // Adjust these as needed for balancing
        private const int MaxManaDrain = 25;
        private const double DamageMultiplier = 1.5;

        static ManaBurn()
        {
            PoisonEffectRegistry.Register(new ManaBurn());
        }

        public void Visual(Mobile target)
        {
            target.FixedParticles(0x3709, 10, 30, 5052, 0x481, 0, EffectLayer.Head);
            target.SendMessage("Your mana has been burned!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            int manaToDrain = Math.Min(defender.Mana, MaxManaDrain);
            int damage = (int)(manaToDrain * DamageMultiplier);

            defender.Mana -= manaToDrain;
            defender.Damage(damage, attacker);

            Visual(defender);
            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
