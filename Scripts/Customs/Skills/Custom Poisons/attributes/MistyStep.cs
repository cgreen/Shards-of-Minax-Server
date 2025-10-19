using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class MistyStep : IPoisonEffect
    {
        public string Id    => "MistyStep";
        public string Label => "Misty Step";
        public int SoundId  => -1; // Optional: assign a sound if needed

        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;
        private static readonly int Range = 10; // Default teleport range

        static MistyStep() => PoisonEffectRegistry.Register(new MistyStep());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Combatant == null || attacker.Map == null)
                return;

            Point3D newLocation = GetSafeLocation(attacker, Range);
            if (newLocation != Point3D.Zero)
            {
                attacker.Location = newLocation;
                attacker.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* A swift maneuver evades the danger! *");

				Server.Effects.SendLocationParticles(
					EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
					0x3709, 10, 30, 1154, 0, 0, 0);
            }

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }

        private Point3D GetSafeLocation(Mobile m, int range)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = m.X + Utility.RandomMinMax(-range, range);
                int y = m.Y + Utility.RandomMinMax(-range, range);
                int z = m.Map.GetAverageZ(x, y);
                Point3D p = new Point3D(x, y, z);

                if (m.Map.CanSpawnMobile(p))
                    return p;
            }

            return Point3D.Zero;
        }

        public void Visual(Mobile m)
        {
            // Optional: You can define additional visuals here if desired
        }
    }
}
