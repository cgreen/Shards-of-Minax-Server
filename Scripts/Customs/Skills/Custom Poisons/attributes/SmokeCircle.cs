using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class SmokeCircle : IPoisonEffect
    {
        public string Id    => "SmokeCircle";
        public string Label => "Smoke Circle";
        public int SoundId  => 0; // You can assign a sound ID if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int Radius = 5;
        private const int Thickness = 4;
        private const int Damage = 50;

        static SmokeCircle() => PoisonEffectRegistry.Register(new SmokeCircle());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Deleted || attacker.Map == null)
                return;

            Map map = attacker.Map;

            for (int i = -Radius; i <= Radius; i++)
            {
                for (int j = -Radius; j <= Radius; j++)
                {
                    int distSq = i * i + j * j;
                    if (distSq <= Radius * Radius && distSq >= (Radius - Thickness) * (Radius - Thickness))
                    {
                        Point3D point = new Point3D(attacker.X + i, attacker.Y + j, attacker.Z);
                        if (map.CanFit(point.X, point.Y, point.Z, 16, false, false))
                        {
							Server.Effects.SendLocationParticles(
								EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
								0x3728, 10, 30, 1154, 0, 0, 0);
                            DealDamageAtPoint(point, map, attacker);
                        }
                    }
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private void DealDamageAtPoint(Point3D p, Map map, Mobile attacker)
        {
            foreach (Mobile m in map.GetMobilesInRange(p, 0))
            {
                if (m != null && m != attacker && (m is PlayerMobile || m is BaseCreature))
                {
                    m.Damage(Damage, attacker);
                }
            }
        }

        public void Visual(Mobile m)
        {
            // Optional: show an effect on the defender (not required)
        }
    }
}
