// Scripts/CustomPoisons/Effects/PrismaticSpray.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class PrismaticSpray : IPoisonEffect
    {
        public string Id => "PrismaticSpray";
        public string Label => "Prismatic Spray";
		public int SoundId  => 0x22F; // Generic poison sound effect, adjust as needed

        private static readonly int Damage = 50;
        private static readonly int Range = 10;
        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;
        private static readonly Random _random = new Random();

        static PrismaticSpray() => PoisonEffectRegistry.Register(new PrismaticSpray());

        public void Apply(Mobile attacker, Mobile defender)
        {
            // Ignore standard hit logic; instead, simulate a frontal spray from the attacker
            if (DateTime.UtcNow < _nextAllowed || attacker?.Map == null)
                return;

            PerformSpray(attacker);
            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private void PerformSpray(Mobile owner)
        {
            Map map = owner.Map;
            Direction dir = owner.Direction;

            int dx = 0, dy = 0;

            switch (dir & Direction.Mask)
            {
                case Direction.North: dy = -1; break;
                case Direction.South: dy = 1; break;
                case Direction.East: dx = 1; break;
                case Direction.West: dx = -1; break;
                case Direction.Right: dx = 1; dy = -1; break;
                case Direction.Down: dx = 1; dy = 1; break;
                case Direction.Left: dx = -1; dy = 1; break;
                case Direction.Up: dx = -1; dy = -1; break;
            }

            List<Point3D>[] rows = new List<Point3D>[Range];
            for (int i = 0; i < Range; i++) rows[i] = new List<Point3D>();

            for (int i = 1; i <= Range; i++)
            {
                int baseX = owner.X + i * dx;
                int baseY = owner.Y + i * dy;
                int side = i / 2;

                for (int j = -side; j <= side; j++)
                {
                    int x = baseX, y = baseY;

                    if (dx == 0)
                        x += j;
                    else if (dy == 0)
                        y += j;
                    else
                    {
                        x += j;
                        y += (dx * dy > 0) ? -j : j;
                    }

                    Point3D point = new Point3D(x, y, owner.Z);
                    if (!map.CanFit(x, y, owner.Z, 16, false, false))
                        point = new Point3D(x, y, map.GetAverageZ(x, y));

                    if (map.CanFit(point.X, point.Y, point.Z, 16, false, false))
                        rows[i - 1].Add(point);
                }
            }

            TimeSpan delay = TimeSpan.Zero;
            TimeSpan step = TimeSpan.FromSeconds(0.1);

            foreach (List<Point3D> row in rows)
            {
                Timer.DelayCall(delay, () =>
                {
                    foreach (Point3D p in row)
                    {
                        int hue = _random.Next(1, 3001);
						Server.Effects.SendLocationParticles(
							EffectItem.Create(owner.Location, owner.Map, EffectItem.DefaultDuration),
							0x3709, 10, 30, 1154, 0, 0, 0);

                        foreach (Mobile m in map.GetMobilesInRange(p, 0))
                        {
                            if (m != owner && (m is PlayerMobile || m is BaseCreature) && owner.InLOS(m))
                            {
                                m.Damage(Damage, owner);
                            }
                        }
                    }
                });

                delay += step;
            }
        }

        public void Visual(Mobile m)
        {
            // Optional visual if you want a fallback or direct-target visual
            m.FixedParticles(0x3709, 10, 15, 5013, _random.Next(1, 3001), 0, EffectLayer.Head);
            m.SendMessage("A burst of prismatic energy engulfs you!");
        }
    }
}
