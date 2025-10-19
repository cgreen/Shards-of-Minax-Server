using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class FrostStrike : IPoisonEffect
    {
        public string Id    => "FrostStrike";
        public string Label => "Frost Strike";
        public int SoundId  => -1; // Optional: You can add a sound if you'd like

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(10);
        private static readonly int DamagePerTick = 7; // Adjust to your liking

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static FrostStrike() => PoisonEffectRegistry.Register(new FrostStrike());

        public void Visual(Mobile defender)
        {
            defender.FixedParticles(0x37CC, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
            defender.SendMessage("You feel the bite of cold!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || defender.Deleted || !defender.Alive)
                return;

            defender.BeginAction(typeof(FrostStrike));
            Visual(defender);

            Timer.DelayCall(
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1),
                (int)Duration.TotalSeconds,
                FrostEffectCallback,
                new object[] { defender, 0 }
            );

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private static void FrostEffectCallback(object state)
        {
            object[] states = (object[])state;
            Mobile defender = (Mobile)states[0];
            int tickCount = (int)states[1];

            if (defender == null || defender.Deleted || !defender.Alive)
            {
                defender?.EndAction(typeof(FrostStrike));
                return;
            }

            if (tickCount < Duration.TotalSeconds)
            {
                defender.Damage(DamagePerTick, defender);
                defender.FixedParticles(0x37CC, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
                states[1] = tickCount + 1;
            }
            else
            {
                defender.EndAction(typeof(FrostStrike));
            }
        }
    }
}
