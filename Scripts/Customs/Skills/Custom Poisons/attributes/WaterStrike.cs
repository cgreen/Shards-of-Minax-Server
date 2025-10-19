// Scripts/CustomPoisons/Effects/WaterStrike.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class WaterStrike : IPoisonEffect
    {
        public string Id    => "WaterStrike";
        public string Label => "Water Strike";
        public int SoundId  => -1; // No sound specified in original effect, can be added if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration   = TimeSpan.FromSeconds(10);
        private const int DamagePerTick = 7; // You can adjust this or make it configurable
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static WaterStrike() => PoisonEffectRegistry.Register(new WaterStrike());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || !defender.Alive)
                return;

            if (!defender.BeginAction(typeof(WaterStrike)))
                return;

            defender.SendMessage("You've been engulfed by water!");
            int totalTicks = (int)Duration.TotalSeconds;

            Timer.DelayCall(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), totalTicks, state =>
            {
                if (defender == null || defender.Deleted || !defender.Alive)
                {
                    defender?.EndAction(typeof(WaterStrike));
                    return;
                }

                defender.Damage(DamagePerTick, attacker);
                Visual(defender);

            }, null);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile d)
        {
            d.FixedParticles(0x3511, 10, 30, 5052, EffectLayer.LeftFoot);
            // You could add a sound here if desired: d.PlaySound(SoundId);
        }
    }
}
