// Scripts/CustomPoisons/Effects/BoilingSurge.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class BoilingSurge : IPoisonEffect
    {
        public string Id    => "BoilingSurge";
        public string Label => "Boiling Surge";
        public int SoundId  => -1; // No specific sound assigned in original effect

        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan BuffDuration = TimeSpan.FromSeconds(15);
        private static readonly int DamageIncrease = 10;

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static BoilingSurge() => PoisonEffectRegistry.Register(new BoilingSurge());

        public void Visual(Mobile owner)
        {
			Server.Effects.SendLocationParticles(
				EffectItem.Create(owner.Location, owner.Map, EffectItem.DefaultDuration),
				0x36D4, 10, 30, 1154, 0, 0, 0);
            owner.SendMessage("A boiling aura intensifies your power!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker is BaseCreature creature)
            {
                int min = creature.DamageMin + DamageIncrease;
                int max = creature.DamageMax + DamageIncrease;

                creature.SetDamage(min, max);
                Visual(attacker);

                Timer.DelayCall(BuffDuration, () =>
                {
                    creature.SetDamage(min - DamageIncrease, max - DamageIncrease);
                });

                _nextAllowed = DateTime.UtcNow + Cooldown;
            }
            else
            {
                attacker.SendMessage("You cannot use this ability.");
            }
        }
    }
}
