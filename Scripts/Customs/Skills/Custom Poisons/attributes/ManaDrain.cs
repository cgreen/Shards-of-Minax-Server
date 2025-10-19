// Scripts/CustomPoisons/Effects/ManaDrain.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class ManaDrain : IPoisonEffect
    {
        public string Id    => "ManaDrain";
        public string Label => "Mana Drain";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static ManaDrain() => PoisonEffectRegistry.Register(new ManaDrain());

        public void Apply(Mobile attacker, Mobile defender)
        {
            int drain = Utility.RandomMinMax(15, 35);
            defender.Mana = Math.Max(0, defender.Mana - drain);
            defender.PlaySound(0x1F9);
            defender.FixedParticles(0x37B9, 10, 15, 5044, 0x551, 0, EffectLayer.Head);
        }
    }
}
