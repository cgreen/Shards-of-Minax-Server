// Scripts/CustomPoisons/Effects/WeakLingering.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers;

namespace Server.CustomPoisons.Effects
{
    public sealed class WeakLingering : IPoisonEffect
    {
        public string Id => "WeakLingering";
        public string Label => "Weak Lingering";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(2, 4);
        private static readonly int DamagePerTick = Utility.RandomMinMax(10, 30); 
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(3.0);

        static WeakLingering() => PoisonEffectRegistry.Register(new WeakLingering());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A faint, lingering discomfort begins.");
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x374A, 5, 10, 5021, EffectLayer.Waist); 

            new LingeringDamageTimer(defender, attacker, Ticks, Interval, DamagePerTick, 100, 0, 0, 0, 0).Start();
        }
    }
}