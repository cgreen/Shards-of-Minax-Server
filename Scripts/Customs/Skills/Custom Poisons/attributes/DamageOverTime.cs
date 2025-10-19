using Server.Mobiles;
using Server;
using System;

namespace Server.CustomPoisons.Effects
{
	public sealed class DamageOverTime : IPoisonEffect
	{
		public string Id => "DamageOverTime";
		public string Label => "Damage Over Time";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }

		static DamageOverTime() => PoisonEffectRegistry.Register(new DamageOverTime());

		public void Apply(Mobile attacker, Mobile defender)
		{
			defender.ApplyPoison(attacker, Poison.Lesser);
		}
	}

}
