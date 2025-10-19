// Scripts/CustomPoisons/Effects/Nuke.cs
using System;
using Server;
using Server.Mobiles;
using Server.Spells;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.CustomPoisons.Effects
{
    public sealed class Nuke : IPoisonEffect
    {
        public string Id    => "Nuke";
        public string Label => "Nuke";
        public int SoundId  => 0x349;

        private static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(25);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const int BaseDamage = 100;
        private const int Range = 8;

        static Nuke()
        {
            PoisonEffectRegistry.Register(new Nuke());
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || attacker.Map == null || DateTime.UtcNow < _nextAllowed)
                return;

            _nextAllowed = DateTime.UtcNow + Cooldown;

            Map map = attacker.Map;

            attacker.Say("Prepare to be incinerated!");
            Server.Effects.PlaySound(attacker.Location, map, 0x349);

            Timer.DelayCall(TimeSpan.FromSeconds(1.0), () =>
            {
                if (!attacker.Alive) return;



                for (int i = 0; i < Range; i++)
                {
                    Misc.Geometry.Circle2D(attacker.Location, map, i, (point, m) =>
                    {
                        Server.Effects.SendLocationEffect(point, m, 14000, 14, 10, Utility.RandomMinMax(2497, 2499), 2);
                    });
                }
            });

            IPooledEnumerable nearby = map.GetMobilesInRange(attacker.Location, Range);

            foreach (Mobile m in nearby)
            {
                if (m != null && m.Alive && m != attacker && !m.IsDeadBondedPet)
                {
                    Timer.DelayCall(TimeSpan.FromSeconds(1.75), () =>
                    {
                        int fireResist = m.GetResistance(ResistanceType.Fire);
                        int finalDamage = (int)(BaseDamage * (1.0 - fireResist / 100.0));
                        m.Damage(finalDamage, attacker);
                    });
                }
            }

            nearby.Free();
        }

        public void Visual(Mobile target)
        {
            // Optional: you could add a visual effect per target here
        }
    }
}
