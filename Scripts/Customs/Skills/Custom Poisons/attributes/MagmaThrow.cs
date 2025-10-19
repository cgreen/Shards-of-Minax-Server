// Scripts/CustomPoisons/Effects/MagmaThrow.cs
using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.CustomPoisons.Effects
{
    public sealed class MagmaThrow : IPoisonEffect
    {
        public string Id    => "MagmaThrow";
        public string Label => "Magma Throw";
        public int SoundId  => 0x208;
		public void Visual(Mobile defender) { }		

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;
        private const int BaseDamage = 120;
        private const int Range = 8;

        static MagmaThrow() => PoisonEffectRegistry.Register(new MagmaThrow());

        public void Visual(Mobile caster, Mobile target)
        {
            if (target?.Map == null) return;

            caster.Say("Taste the heat of magma!");
			Server.Effects.SendLocationParticles(
				EffectItem.Create(caster.Location, caster.Map, EffectItem.DefaultDuration),
				0x376A, 10, 30, 1154, 0, 0, 0);

        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || attacker.Map == null || DateTime.UtcNow < _nextAllowed)
                return;

            if (defender == null || !defender.InRange(attacker, Range))
                return;

            Visual(attacker, defender);

            foreach (Mobile m in attacker.GetMobilesInRange(2))
            {
                if (m == attacker || !attacker.CanBeHarmful(m, false))
                    continue;

                attacker.DoHarmful(m);
                int dmg = Utility.RandomMinMax(BaseDamage, BaseDamage * 2);
                AOS.Damage(m, attacker, dmg, 0, 0, 0, 100, 0); // 100% fire
            }

            Map map = defender.Map;
            for (int i = 0; i < 5; i++)
            {
                Point3D dropPoint = new Point3D(
                    defender.X + Utility.RandomMinMax(-1, 1),
                    defender.Y + Utility.RandomMinMax(-1, 1),
                    defender.Z
                );

                if (map.CanFit(dropPoint, 0, true, false))
                {
					Server.Effects.SendLocationParticles(
						EffectItem.Create(attacker.Location, attacker.Map, EffectItem.DefaultDuration),
						0x376A, 10, 30, 1154, 0, 0, 0);
                    Item hotLavaTile = new HotLavaTile();
                    hotLavaTile.MoveToWorld(dropPoint, map);
                }
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
