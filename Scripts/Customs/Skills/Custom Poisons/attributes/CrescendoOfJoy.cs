using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class CrescendoOfJoy : IPoisonEffect
    {
        public string Id    => "CrescendoOfJoy";
        public string Label => "Crescendo of Joy";
        public int SoundId  => 0x1F6;

        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan FreezeDuration = TimeSpan.FromSeconds(4);
        private static readonly int Damage = 50;

        private static DateTime _nextAllowed = DateTime.UtcNow;

        static CrescendoOfJoy() => PoisonEffectRegistry.Register(new CrescendoOfJoy());

        public void Visual(Mobile owner)
        {
            if (owner == null) return;

            owner.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Unleashes a powerful crescendo of joy *");
            owner.PlaySound(SoundId);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            Visual(attacker);

            foreach (Mobile m in attacker.GetMobilesInRange(10))
            {
                if (m != attacker)
                {
                    m.Damage(Damage, attacker);
                    m.SendMessage("You are struck by a burst of musical energy!");
                    m.SendMessage("You feel your movement slowed down!");
                    m.Freeze(FreezeDuration);
                }
            }

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }
    }
}
