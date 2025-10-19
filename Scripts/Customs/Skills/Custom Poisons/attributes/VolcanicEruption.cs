using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class VolcanicEruption : IPoisonEffect
    {
        public string Id    => "VolcanicEruption";
        public string Label => "Volcanic Eruption";
        public int SoundId  => 0x5CF;

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(25);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static VolcanicEruption()
        {
            PoisonEffectRegistry.Register(new VolcanicEruption());
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Map == null)
                return;

            attacker.PublicOverheadMessage(MessageType.Emote, 0x3B2, true, "* Erupts in a burst of molten lava *");
            attacker.PlaySound(SoundId);
			Server.Effects.SendLocationParticles(
				EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
				0x36B0, 10, 30, 1154, 0, 0, 0);

            List<Mobile> targets = new List<Mobile>();
            IPooledEnumerable eable = attacker.GetMobilesInRange(3);

            foreach (Mobile m in eable)
            {
                if (m != attacker && attacker.CanBeHarmful(m))
                {
                    targets.Add(m);
                }
            }

            eable.Free();

            foreach (Mobile m in targets)
            {
                int damage = Utility.RandomMinMax(50, 140);
                AOS.Damage(m, attacker, damage, 0, 100, 0, 0, 0); // Pure fire damage
                m.PlaySound(0x1DD);
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }

        public void Visual(Mobile d)
        {
            // Optional: This could remain unused if you don’t need per-target visuals.
        }
    }
}
