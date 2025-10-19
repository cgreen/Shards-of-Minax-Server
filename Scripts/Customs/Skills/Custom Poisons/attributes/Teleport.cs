using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Teleport : IPoisonEffect
    {
        public string Id    => "Teleport";
        public string Label => "Teleport";
        public int SoundId  => -1; // No specific sound, but can be added if desired

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(7);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static Teleport() => PoisonEffectRegistry.Register(new Teleport());

        public void Visual(Mobile m)
        {
            if (m?.Map == null) return;

            m.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Teleports with a burst *");
			Server.Effects.SendLocationParticles(
				EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration),
				0x376A, 10, 30, 1154, 0, 0, 0);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Map == null)
                return;

            Point3D newLocation = new Point3D(
                attacker.X + Utility.RandomMinMax(-10, 10),
                attacker.Y + Utility.RandomMinMax(-10, 10),
                attacker.Z
            );

            if (attacker.Map.CanSpawnMobile(newLocation))
            {
                Visual(attacker);
                attacker.MoveToWorld(newLocation, attacker.Map);

                foreach (Mobile m in attacker.GetMobilesInRange(5))
                {
                    if (m != attacker && m.Alive)
                    {
                        m.SendMessage("A creature disappears in a puff and reappears somewhere else!");
                    }
                }

                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }
    }
}
