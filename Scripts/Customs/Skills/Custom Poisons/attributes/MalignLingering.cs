// Scripts/CustomPoisons/Effects/MalignLingering.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers;

namespace Server.CustomPoisons.Effects
{
    public sealed class MalignLingering : IPoisonEffect
    {
        public string Id => "MalignLingering";
        public string Label => "Malign Lingering";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(5, 7);
        private static readonly int DamagePerTick = Utility.RandomMinMax(1, 50); 
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(2.0);

        static MalignLingering() => PoisonEffectRegistry.Register(new MalignLingering());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A malign, lingering agony spreads through you.");
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x374A, 15, 25, 5021, EffectLayer.Waist); 

            new LingeringDamageTimer(defender, attacker, Ticks, Interval, DamagePerTick, 100, 0, 0, 0, 0).Start();
        }
    }
}