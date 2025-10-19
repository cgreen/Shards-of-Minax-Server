// Scripts/CustomPoisons/Effects/StaticStrike.cs
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class StaticStrike : IPoisonEffect
    {
        public string Id    => "StaticStrike";
        public string Label => "Static Strike";
        public int SoundId  => -1; // No sound specified in original XML

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration   = TimeSpan.FromSeconds(20);
        private static readonly int DamagePerTick   = 5; // Adjust this based on your needs

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static StaticStrike() => PoisonEffectRegistry.Register(new StaticStrike());

        public void Visual(Mobile m)
        {
            m.FixedParticles(0x3973, 10, 30, 5052, EffectLayer.LeftFoot);
            m.SendMessage("You've been electrocuted!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || !defender.Alive || defender.Deleted)
                return;

            if (!defender.BeginAction(typeof(StaticStrike)))
                return;

            Visual(defender);

            Timer.DelayCall(
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1),
                (int)Duration.TotalSeconds,
                new TimerStateCallback(ApplyTick),
                new object[] { defender, 0 }
            );

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private void ApplyTick(object state)
        {
            var states = (object[])state;
            var defender = (Mobile)states[0];
            int tickCount = (int)states[1];

            if (defender == null || defender.Deleted || !defender.Alive)
            {
                defender?.EndAction(typeof(StaticStrike));
                return;
            }

            if (tickCount < Duration.TotalSeconds)
            {
                defender.Damage(DamagePerTick, defender); // self-inflicted to trigger resist checks if needed
                Visual(defender);
                states[1] = tickCount + 1;
            }
            else
            {
                defender.EndAction(typeof(StaticStrike));
            }
        }
    }
}
