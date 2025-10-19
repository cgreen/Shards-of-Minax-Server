// Scripts/CustomPoisons/Effects/SparkleBlast.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class SparkleBlast : IPoisonEffect
    {
        public string Id    => "SparkleBlast";
        public string Label => "Sparkle Blast";
        public int SoundId  => -1; // No sound used in the original XML

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static SparkleBlast() => PoisonEffectRegistry.Register(new SparkleBlast());

        public void Visual(Mobile source)
        {
            if (source?.Map == null)
                return;

            source.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* Emits a burst of glittery particles! *");
			Server.Effects.SendLocationParticles(
				EffectItem.Create(source.Location, source.Map, EffectItem.DefaultDuration),
				0x3728, 10, 30, 1154, 0, 0, 0);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || attacker.Map == null)
                return;

            Visual(attacker);

            foreach (Mobile m in attacker.GetMobilesInRange(5))
            {
                if (m != attacker && m.Player)
                {
                    m.SendMessage("You are dazzled and confused by the glimmering blast!");
                    m.Freeze(TimeSpan.FromSeconds(5));
                    m.SendMessage("You feel slowed down!");

                    Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
                    {
                        if (m.Alive && attacker.Alive)
                            m.Damage(5, attacker);
                    });
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
