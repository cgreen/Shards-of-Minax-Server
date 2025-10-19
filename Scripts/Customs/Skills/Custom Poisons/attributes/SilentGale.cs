using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class SilentGale : IPoisonEffect
    {
        public string Id    => "SilentGale";
        public string Label => "Silent Gale";
        public int SoundId  => -1; // No sound effect specified in original

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static SilentGale() => PoisonEffectRegistry.Register(new SilentGale());

        public void Visual(Mobile m)
        {
            if (m == null)
                return;

            m.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Moves silently through the air! *");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null)
                return;

            attacker.Skills[SkillName.Stealth].Base = 100.0; // You can adjust this value
            Visual(attacker);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
