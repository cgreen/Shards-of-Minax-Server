// Scripts/CustomPoisons/Effects/CursedTouch.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class CursedTouch : IPoisonEffect
    {
        public string Id    => "CursedTouch";
        public string Label => "Cursed Touch";
        public int SoundId  => 0x22E; // Optional: pick an appropriate sound or remove this

        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(10);
        private static readonly double DamageMultiplier = 1.2; // 20% extra damage
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static CursedTouch()
        {
            PoisonEffectRegistry.Register(new CursedTouch());
        }

        public void Visual(Mobile target)
        {
            if (target == null) return;

            target.FixedParticles(0x374A, 10, 15, 5013, 0x22, 0, EffectLayer.Waist);
            target.PlaySound(SoundId);
            target.SendMessage("You've been cursed!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            if (DateTime.UtcNow < _nextAllowed)
                return;

            int baseDamage = Utility.RandomMinMax(50, 100); // You can fine-tune this range
            int extraDamage = (int)(baseDamage * (DamageMultiplier - 1.0));
            int totalDamage = baseDamage + extraDamage;

            defender.Damage(totalDamage, attacker);

            Visual(defender);

            _nextAllowed = DateTime.UtcNow + Duration;
        }
    }
}
