using System;
using System.Collections.Generic; // Required for List<>
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class SpineBarrage : IPoisonEffect
    {
        public string Id    => "SpineBarrage";
        public string Label => "Spine Barrage";
        public int SoundId  => -1; // You can set a sound ID if desired

        private static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int MaxTargets = 6;
        private const int Radius = 8;
        private const int BaseDamage = 50;

        static SpineBarrage() => PoisonEffectRegistry.Register(new SpineBarrage());

        public void Visual(Mobile target)
        {
            if (target == null) return;

            target.FixedParticles(0x36BD, 20, 10, 5044, 0x3F, 3, EffectLayer.Head); // Visual for projectile hit
            target.SendMessage("You are struck by a barrage of spines!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed || attacker?.Map == null)
                return;

            int targetsHit = 0;
            bool firstTarget = true;

            foreach (Mobile m in attacker.Map.GetMobilesInRange(attacker.Location, Radius))
            {
                if (m == null || m == attacker || !(m is PlayerMobile || m is BaseCreature) || !attacker.InLOS(m))
                    continue;

                int damage = BaseDamage;
                if (firstTarget)
                {
                    damage += (int)(BaseDamage * 0.5); // 50% more to first target
                    firstTarget = false;
                }

                m.Damage(damage, attacker);
                Visual(m);

                if (++targetsHit >= MaxTargets)
                    break;
            }

            attacker.Say("Spine Barrage!");
            _nextAllowed = DateTime.UtcNow + Cooldown;
        }
    }
}
