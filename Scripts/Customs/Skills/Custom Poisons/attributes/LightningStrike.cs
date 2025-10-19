// Scripts/CustomPoisons/Effects/LightningStrike.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class LightningStrike : IPoisonEffect
    {
        public string Id    => "LightningStrike";
        public string Label => "Lightning Strike";
        public int SoundId  => -1; // No specific sound was used in the original effect

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private static readonly int MinDamage = 30;
        private static readonly int MaxDamage = 250;

        static LightningStrike() => PoisonEffectRegistry.Register(new LightningStrike());

        public void Visual(Mobile target)
        {
            if (target == null) return;

			Server.Effects.SendLocationParticles(
				EffectItem.Create(target.Location, target.Map, EffectItem.DefaultDuration),
				0x1F4, 10, 30, 1154, 0, 0, 0);

            target.SendMessage("You are struck by a powerful lightning bolt!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null || DateTime.UtcNow < _nextAllowed)
                return;

            if (!defender.Alive)
                return;

            int damage = Utility.RandomMinMax(MinDamage, MaxDamage);

            defender.Damage(damage, attacker);
            Visual(defender);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
