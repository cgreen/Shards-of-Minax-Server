// Scripts/CustomPoisons/Effects/BladeStrike.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class BladeStrike : IPoisonEffect
    {
        public string Id    => "BladeStrike";
        public string Label => "Blade Strike";
        public int SoundId  => -1; // Set to a valid sound if needed	

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration   = TimeSpan.FromSeconds(7);
        private const int TickDamage = 7; // Adjust to reflect desired damage per tick
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static BladeStrike() => PoisonEffectRegistry.Register(new BladeStrike());

        public void Visual(Mobile m)
        {
            m.FixedParticles(0x37A0, 10, 30, 5052, EffectLayer.LeftFoot);
            m.SendMessage("You've been hit by a blast!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || !defender.Alive)
                return;

            defender.SendMessage("You've been hit by a blade whirlwind!");
            defender.BeginAction(typeof(BladeStrike));

            Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(1), (int)Duration.TotalSeconds, () =>
            {
                if (defender == null || defender.Deleted || !defender.Alive)
                {
                    defender?.EndAction(typeof(BladeStrike));
                    return;
                }

                defender.Damage(TickDamage, attacker); // Damage per tick
                Visual(defender);
            });

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

    }
}
