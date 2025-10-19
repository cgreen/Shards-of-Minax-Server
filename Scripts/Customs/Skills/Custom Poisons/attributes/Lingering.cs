// Scripts/CustomPoisons/Effects/Lingering.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers; // For LingeringDamageTimer

namespace Server.CustomPoisons.Effects
{
    public sealed class Lingering : IPoisonEffect
    {
        public string Id => "Lingering";
        public string Label => "Lingering";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(3, 5);
        private static readonly int DamagePerTick = Utility.RandomMinMax(20, 40); // Physical damage
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(2.5);

        static Lingering() => PoisonEffectRegistry.Register(new Lingering());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A lingering pain sets in.");
            defender.PlaySound(0x231); // Drip sound
            defender.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist); // Blood Drips

            new LingeringDamageTimer(defender, attacker, Ticks, Interval, DamagePerTick, 100, 0, 0, 0, 0).Start();
        }
    }
}