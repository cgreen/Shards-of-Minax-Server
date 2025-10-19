// Scripts/CustomPoisons/Effects/RuneLine.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.CustomPoisons.Effects
{
    public sealed class RuneLine : IPoisonEffect
    {
        public string Id    => "RuneLine";
        public string Label => "Line Breath Attack";
        public int SoundId  => -1; // No specific sound defined in original

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private static int Damage => 70;
        private static int Range  => 10;

        static RuneLine() => PoisonEffectRegistry.Register(new RuneLine());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            PerformLineBreathAttack(attacker);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        private void PerformLineBreathAttack(Mobile owner)
        {
            Map map = owner.Map;
            Direction d = owner.Direction;
            int dx = 0, dy = 0;

            switch (d & Direction.Mask)
            {
                case Direction.North: dy = -1; break;
                case Direction.East:  dx = 1;  break;
                case Direction.South: dy = 1;  break;
                case Direction.West:  dx = -1; break;
                case Direction.Right: dx = 1; dy = -1; break; // NE
                case Direction.Down:  dx = 1; dy = 1;  break; // SE
                case Direction.Left:  dx = -1; dy = 1; break; // SW
                case Direction.Up:    dx = -1; dy = -1; break; // NW
            }

            Point3D start = new Point3D(owner.X + dx, owner.Y + dy, owner.Z);
            int perpDx = dy;
            int perpDy = -dx;

            for (int i = 0; i < Range; i++)
            {
                int targetX = start.X + i * dx;
                int targetY = start.Y + i * dy;

                for (int t = -1; t <= 1; t++) // 3-tile thick line
                {
                    int thickX = targetX + t * perpDx;
                    int thickY = targetY + t * perpDy;

                    Point3D p = new Point3D(thickX, thickY, start.Z);

                    if (!map.CanFit(p, 16, false, false))
                        continue;

					Server.Effects.SendLocationParticles(
						EffectItem.Create(owner.Location, owner.Map, EffectItem.DefaultDuration),
						0x0E62, 10, 30, 1154, 0, 0, 0);

                    foreach (Mobile m in map.GetMobilesInRange(p, 0))
                    {
                        if (m != null && m != owner && (m is PlayerMobile || m is BaseCreature))
                        {
                            m.Damage(Damage, owner);
                        }
                    }
                }
            }
        }

        public void Visual(Mobile target)
        {
            // No visual effect tied to the victim in original XML, only area effects
        }
    }
}
