using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class Disarm : IPoisonEffect
    {
        public string Id    => "Disarm";
        public string Label => "Disarm";
        public int SoundId  => 0x3B9;

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static Disarm() => PoisonEffectRegistry.Register(new Disarm());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            BaseWeapon weapon = defender.FindItemOnLayer(Layer.OneHanded) as BaseWeapon
                             ?? defender.FindItemOnLayer(Layer.TwoHanded) as BaseWeapon;

            if (weapon != null)
            {
                defender.AddToBackpack(weapon);
                defender.PlaySound(SoundId);
                defender.SendMessage("You've been disarmed!");

                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }

        public void Visual(Mobile m)
        {
            // No particles defined in original XML, so this is intentionally left empty
        }
    }
}
