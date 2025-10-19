using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class StamDrain : IPoisonEffect
    {
        public string Id    => "StamDrain";
        public string Label => "Stamina Drain";
        public int SoundId  => -1; // No sound in original, add one if desired (e.g., 0x231)

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static StamDrain() => PoisonEffectRegistry.Register(new StamDrain());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            int drain = Utility.RandomMinMax(37, 89); // Adjust this range to suit your balance

            defender.Stam -= drain;
            if (defender.Stam < 0)
                defender.Stam = 0;

            attacker.Stam += drain;
            if (attacker.Stam > attacker.StamMax)
                attacker.Stam = attacker.StamMax;

            Visual(defender);
            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile d)
        {
            // Add particle effects and message if desired
            d.FixedParticles(0x3779, 10, 15, 5004, 0x47D, 0, EffectLayer.Waist);
            d.SendMessage("Your stamina is being drained!");
        }
    }
}
