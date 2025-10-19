// Scripts/CustomPoisons/Effects/ToxicSludge.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class ToxicSludge : IPoisonEffect
    {
        public string Id    => "ToxicSludge";
        public string Label => "Toxic Sludge";
        public int SoundId  => -1; // No sound in original effect

        private static readonly TimeSpan Refractory = TimeSpan.FromMinutes(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static ToxicSludge() => PoisonEffectRegistry.Register(new ToxicSludge());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            var loc = GetSpawnPosition(2, attacker);

            if (loc != Point3D.Zero)
            {
				Server.Effects.SendLocationParticles(
					EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
					0x3728, 10, 30, 1154, 0, 0, 0);
                attacker.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* A pool of toxic sludge forms! *");

                foreach (Mobile m in attacker.Map.GetMobilesInRange(loc, 2))
                {
                    if (m != attacker && m.Alive)
                    {
                        m.SendMessage("You are poisoned by the toxic sludge!");
                        m.ApplyPoison(attacker, Poison.Lethal);
                    }
                }

                _nextAllowed = DateTime.UtcNow + Refractory;
            }
        }

        private Point3D GetSpawnPosition(int range, Mobile owner)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = owner.X + Utility.RandomMinMax(-range, range);
                int y = owner.Y + Utility.RandomMinMax(-range, range);
                int z = owner.Map.GetAverageZ(x, y);

                Point3D p = new Point3D(x, y, z);

                if (owner.Map.CanSpawnMobile(p))
                    return p;
            }

            return Point3D.Zero;
        }

        public void Visual(Mobile m)
        {
            // This effect is visualized at the location, not on the mobile, so this is intentionally left empty
        }
    }
}
