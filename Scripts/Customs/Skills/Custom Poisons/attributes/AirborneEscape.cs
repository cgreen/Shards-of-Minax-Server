using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class AirborneEscape : IPoisonEffect
    {
        public string Id    => "AirborneEscape";
        public string Label => "Airborne Escape";
        public int SoundId  => -1; // No sound specified in the original

        private static readonly TimeSpan Refractory = TimeSpan.FromMinutes(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static AirborneEscape() => PoisonEffectRegistry.Register(new AirborneEscape());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || defender == null || defender.Combatant == null)
                return;

            Point3D newLocation = GetSpawnPosition(10, defender);

            if (newLocation != Point3D.Zero)
            {
                defender.Location = newLocation;
                defender.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Evades with a swift maneuver! *");
				Server.Effects.SendLocationParticles(
					EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
					0x3709, 10, 30, 1154, 0, 0, 0);
                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }

        private Point3D GetSpawnPosition(int range, Mobile m)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = m.X + Utility.RandomMinMax(-range, range);
                int y = m.Y + Utility.RandomMinMax(-range, range);
                int z = m.Map.GetAverageZ(x, y);
                Point3D point = new Point3D(x, y, z);

                if (m.Map.CanSpawnMobile(point))
                    return point;
            }

            return Point3D.Zero;
        }

        public void Visual(Mobile m)
        {
            // Optional: include if you want separate visual logic. Otherwise, kept inline in Apply().
        }
    }
}
