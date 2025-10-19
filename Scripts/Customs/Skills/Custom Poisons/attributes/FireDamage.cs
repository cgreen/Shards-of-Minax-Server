using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.CustomPoisons.Effects
{
    public sealed class FireDamage : IPoisonEffect
    {
        public string Id    => "FireDamage";
        public string Label => "Fire Damage";
        public int SoundId  => 0x15E;
		public void Visual(Mobile defender) { }		

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static FireDamage()
        {
            PoisonEffectRegistry.Register(new FireDamage());
        }

        public void Visual(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null) return;

            attacker.MovingParticles(defender, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
            attacker.PlaySound(SoundId);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            int damage = Utility.RandomMinMax(40, 100); // Adjust damage range as needed

            Visual(attacker, defender);

            SpellHelper.Damage(TimeSpan.Zero, defender, attacker, damage, 0, 100, 0, 0, 0);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
