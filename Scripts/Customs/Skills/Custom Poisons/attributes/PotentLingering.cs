// Scripts/CustomPoisons/Effects/PotentLingering.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers;

namespace Server.CustomPoisons.Effects
{
    public sealed class PotentLingering : IPoisonEffect
    {
        public string Id => "PotentLingering";
        public string Label => "Potent Lingering";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(45, 69);
        private static readonly int DamagePerTick = Utility.RandomMinMax(3, 5); 
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(2.0);

        static PotentLingering() => PoisonEffectRegistry.Register(new PotentLingering());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A potent, lingering pain takes hold.");
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x374A, 10, 20, 5021, EffectLayer.Waist); 

            new LingeringDamageTimer(defender, attacker, Ticks, Interval, DamagePerTick, 100, 0, 0, 0, 0).Start();
        }
    }
}