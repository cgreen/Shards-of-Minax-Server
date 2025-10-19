using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class Enrage : IPoisonEffect
    {
        public string Id    => "Enrage";
        public string Label => "Enrage";
        public int SoundId  => -1; // You can assign a sound ID if desired

        private const double ChanceToTrigger = 0.15; // 15% chance to trigger
        private const int BonusDamage = 50;
        private const int EffectDuration = 30; // in seconds

        static Enrage() => PoisonEffectRegistry.Register(new Enrage());

        public void Visual(Mobile m)
        {
            m.Say("Becomes Enraged!");
            m.SendMessage("You feel enraged, increasing your melee damage!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null || attacker.Weapon == null)
                return;

            if (Utility.RandomDouble() > ChanceToTrigger)
                return;

            BaseWeapon weapon = attacker.Weapon as BaseWeapon;

            if (weapon == null)
                return;

            // Apply temporary weapon damage bonus
            weapon.Attributes.WeaponDamage += BonusDamage;

            Visual(attacker);

            Timer.DelayCall(TimeSpan.FromSeconds(EffectDuration), () =>
            {
                // Safely revert the bonus if still holding the same weapon
                if (!attacker.Deleted && weapon != null && !weapon.Deleted)
                {
                    weapon.Attributes.WeaponDamage -= BonusDamage;
                }
            });
        }
    }
}
