using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class BlazeStrike : IPoisonEffect
    {
        public string Id    => "BlazeStrike";
        public string Label => "Blaze Strike";
        public int SoundId  => -1; // No custom sound defined; you can assign one if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(8);
        private static readonly int DamagePerTick = 6; // Adjust as desired

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static BlazeStrike()
        {
            PoisonEffectRegistry.Register(new BlazeStrike());
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || defender.Deleted || !defender.Alive)
                return;

            if (defender.BeginAction(typeof(BlazeStrike)))
            {
                defender.SendMessage("You've been set on fire!");

                new InternalTimer(defender).Start();
                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }

        public void Visual(Mobile m)
        {
            m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
        }

        private class InternalTimer : Timer
        {
            private readonly Mobile _defender;
            private int _ticks;

            public InternalTimer(Mobile defender) 
                : base(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
            {
                _defender = defender;
                _ticks = 0;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (_defender == null || _defender.Deleted || !_defender.Alive)
                {
                    Stop();
                    return;
                }

                if (_ticks >= Duration.TotalSeconds)
                {
                    _defender.EndAction(typeof(BlazeStrike));
                    Stop();
                    return;
                }

                _defender.Damage(DamagePerTick, _defender);
                _defender.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
                _ticks++;
            }
        }
    }
}
