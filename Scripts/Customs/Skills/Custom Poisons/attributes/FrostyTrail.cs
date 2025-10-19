using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Engines.XmlSpawner2;

namespace Server.CustomPoisons.Effects
{
    public sealed class FrostyTrail : IPoisonEffect
    {
        public string Id    => "FrostyTrail";
        public string Label => "Frosty Trail";
        public int SoundId  => -1; // No specific sound, adjust if needed

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(35);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static FrostyTrail() => PoisonEffectRegistry.Register(new FrostyTrail());

        public void Visual(Mobile caster)
        {
            if (caster?.Map == null)
                return;

            caster.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Leaves a frosty trail *");
			Server.Effects.SendLocationParticles(
				EffectItem.Create(caster.Location, caster.Map, EffectItem.DefaultDuration),
				0x376A, 10, 30, 1154, 0, 0, 0); // Trail visual
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Map == null)
                return;

            Visual(attacker);

            foreach (Mobile m in attacker.GetMobilesInRange(2))
            {
                if (m != attacker && m.Player)
                {
                    m.SendMessage("You feel a chill as you walk through the frosty trail!");
                    m.Freeze(TimeSpan.FromSeconds(2)); // Freezing nearby players
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
