// Scripts/CustomPoisons/Effects/DeadlyLingering.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers;

namespace Server.CustomPoisons.Effects
{
    public sealed class DeadlyLingering : IPoisonEffect
    {
        public string Id => "DeadlyLingering";
        public string Label => "Deadly Lingering";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(6, 9);
        private static readonly int DamagePerTick = Utility.RandomMinMax(6, 10); 
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(1.5);

        static DeadlyLingering() => PoisonEffectRegistry.Register(new DeadlyLingering());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A deadly, unyielding pain lingers within you!");
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x374A, 20, 30, 5021, EffectLayer.Waist); 
            AOS.Damage(defender, attacker, Utility.RandomMinMax(50,100), 100,0,0,0,0); // Initial burst

            new LingeringDamageTimer(defender, attacker, Ticks, Interval, DamagePerTick, 100, 0, 0, 0, 0).Start();
        }
    }
}