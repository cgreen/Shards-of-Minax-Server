using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Misc;

namespace Server.CustomPoisons.Effects
{
    public sealed class AstralStrike : IPoisonEffect
    {
        public string Id    => "AstralStrike";
        public string Label => "Astral Strike";
        public int SoundId  => -1; // Optional: No sound, or choose a fitting one

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(10);
        private static readonly int DamagePerTick = 5; // Adjust as needed

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static AstralStrike()
        {
            PoisonEffectRegistry.Register(new AstralStrike());
        }

        public void Visual(Mobile target)
        {
            if (target == null || target.Deleted) return;

            target.FixedParticles(0x3A9C, 10, 30, 5052, EffectLayer.LeftFoot);
            target.SendMessage("You are struck by astral energy!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || defender == null || attacker == null)
                return;

            if (defender.BeginAction(typeof(AstralStrike)))
            {
                Visual(defender);

                int totalTicks = (int)Duration.TotalSeconds;
                int currentTick = 0;

                Timer astralTimer = null;
                astralTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(1), () =>
                {
                    if (defender == null || defender.Deleted || !defender.Alive || currentTick >= totalTicks)
                    {
                        defender?.EndAction(typeof(AstralStrike));
                        astralTimer?.Stop();
                        return;
                    }

                    defender.Damage(DamagePerTick, attacker);
                    defender.FixedParticles(0x3A9C, 10, 30, 5052, EffectLayer.LeftFoot);

                    currentTick++;
                });

                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }
    }
}
