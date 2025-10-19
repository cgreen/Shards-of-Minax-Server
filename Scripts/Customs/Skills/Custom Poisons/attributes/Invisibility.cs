// Scripts/CustomPoisons/Effects/Invisibility.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Engines.XmlSpawner2;

namespace Server.CustomPoisons.Effects
{
    public sealed class Invisibility : IPoisonEffect
    {
        public string Id    => "Invisibility";
        public string Label => "Invisibility";
        public int SoundId  => 0x22F;
		public void Visual(Mobile defender) { }		

        private static readonly TimeSpan Duration    = TimeSpan.FromSeconds(10);  // Adjust as needed
        private static readonly TimeSpan Refractory  = TimeSpan.FromSeconds(60);  // Adjust as needed

        private static DateTime _nextAllowed = DateTime.MinValue;
        private static DateTime _invisibilityEnd = DateTime.MinValue;

        static Invisibility()
        {
            PoisonEffectRegistry.Register(new Invisibility());
        }

        public void Visual(Mobile m, bool hiding)
        {
            if (hiding)
            {
                m.PlaySound(SoundId);
                m.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, "* Vanishes *");
            }
            else
            {
                m.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, "* Reappears *");
            }
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || attacker.Deleted || attacker.Map == null)
                return;

            if (DateTime.UtcNow >= _nextAllowed && !attacker.Hidden)
            {
                // Go invisible
                attacker.Hidden = true;
                Visual(attacker, hiding: true);
                _invisibilityEnd = DateTime.UtcNow + Duration;
                _nextAllowed = DateTime.UtcNow + Refractory;
            }
            else if (DateTime.UtcNow >= _invisibilityEnd && attacker.Hidden)
            {
                // Become visible again
                attacker.Hidden = false;
                Visual(attacker, hiding: false);
            }
        }
    }
}
