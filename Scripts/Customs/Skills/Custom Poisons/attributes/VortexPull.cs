// Scripts/CustomPoisons/Effects/VortexPull.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class VortexPull : IPoisonEffect
    {
        public string Id    => "VortexPull";
        public string Label => "Vortex Pull";
        public int SoundId  => -1; // No sound used in the original effect

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static VortexPull() => PoisonEffectRegistry.Register(new VortexPull());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            foreach (Mobile m in attacker.GetMobilesInRange(5))
            {
                if (m != attacker && m.Alive)
                {
					Server.Effects.SendLocationParticles(
						EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
						0x3709, 10, 30, 1154, 0, 0, 0);

                    m.MoveToWorld(attacker.Location, attacker.Map);
                    m.SendMessage("You are pulled into a powerful vortex!");
                    m.Damage(Utility.RandomMinMax(10, 115), attacker); // Damage as if attacker caused it
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile d)
        {
            // Optional: add visuals on defender if needed
        }
    }
}
