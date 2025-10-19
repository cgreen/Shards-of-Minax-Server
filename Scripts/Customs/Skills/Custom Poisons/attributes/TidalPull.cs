// Scripts/CustomPoisons/Effects/TidalPull.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.XmlSpawner2;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class TidalPull : IPoisonEffect
    {
        public string Id    => "TidalPull";
        public string Label => "Tidal Pull";
        public int SoundId  => -1; // No sound defined, set one if desired

        private static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(40);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static TidalPull()
        {
            PoisonEffectRegistry.Register(new TidalPull());
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(5))
            {
                if (m != attacker && m.Player)
                {
                    m.Location = attacker.Location;
                    m.SendMessage("You are pulled toward the Abyssal Tide!");
                }
            }

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }

        public void Visual(Mobile m)
        {
            // No specific visuals in original; you may add particles/sound if desired.
        }
    }
}
