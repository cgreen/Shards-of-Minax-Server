using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class PoisonStrike : IPoisonEffect
    {
        public string Id    => "PoisonStrike";
        public string Label => "Poison Strike";
        public int SoundId  => 0x0; // No specific sound, but you can assign one if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        // Adjust this as needed — Regular is default but could be made configurable
        private static readonly Poison DefaultPoison = Poison.Regular;

        static PoisonStrike() => PoisonEffectRegistry.Register(new PoisonStrike());

        public void Visual(Mobile target)
        {
            if (target == null)
                return;

            target.FixedParticles(0x3E02, 10, 30, 5052, EffectLayer.LeftFoot); // Green poison cloud
            target.SendMessage("You've been poisoned!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            if (!defender.Poisoned)
            {
                defender.ApplyPoison(attacker, DefaultPoison);
                Visual(defender);
                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }
    }
}
