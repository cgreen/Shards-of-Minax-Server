// Scripts/CustomPoisons/Effects/StaminaDrain.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class StaminaDrain : IPoisonEffect
    {
        public string Id    => "StaminaDrain";
        public string Label => "Stamina Drain";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static StaminaDrain() => PoisonEffectRegistry.Register(new StaminaDrain());

        public void Apply(Mobile attacker, Mobile defender)
        {
            int drain = Utility.RandomMinMax(50, 150);
            defender.Stam = Math.Max(0, defender.Stam - drain);
            defender.PlaySound(0x213);
            defender.FixedParticles(0x374A, 10, 15, 5052, 0x453, 0, EffectLayer.Waist);
        }
    }
}
