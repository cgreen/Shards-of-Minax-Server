using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class GravityWarp : IPoisonEffect
    {
        public string Id    => "GravityWarp";
        public string Label => "Gravity Warp";
        public int SoundId  => -1; // No sound assigned, update if needed

        private static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(45);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int Damage = 15;
        private const double SlowChance = 0.25;
        private const int DexReduction = 10;
        private const int Range = 5;

        static GravityWarp()
        {
            PoisonEffectRegistry.Register(new GravityWarp());
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker == null || attacker.Map == null)
                return;

            attacker.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Warps the gravity around you *");
			Server.Effects.SendLocationParticles(
				EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
				0x376A, 10, 30, 1154, 0, 0, 0);

            foreach (Mobile m in attacker.GetMobilesInRange(Range))
            {
                if (m != attacker && m.Alive)
                {
                    m.SendMessage("The gravity warp throws you off balance!");
                    m.Damage(Damage, attacker);

                    if (Utility.RandomDouble() < SlowChance)
                    {
                        m.Dex -= DexReduction;
                        if (m.Dex < 1)
                            m.Dex = 1;
                    }
                }
            }

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }

        public void Visual(Mobile d)
        {
            // No personal effect visuals required; global visuals handled in Apply()
        }
    }
}
