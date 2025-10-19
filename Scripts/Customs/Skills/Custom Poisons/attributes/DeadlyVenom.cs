// Scripts/CustomPoisons/Effects/DeadlyVenom.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class DeadlyVenom : IPoisonEffect
    {
        public string Id    => "DeadlyVenom";
        public string Label => "Deadly Venom";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static DeadlyVenom() => PoisonEffectRegistry.Register(new DeadlyVenom());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.ApplyPoison(attacker, Poison.Deadly);
            defender.PlaySound(0x18C);
            defender.FixedParticles(0x36B0, 10, 30, 5005, 0x46F, 0, EffectLayer.Waist);
        }
    }
}
