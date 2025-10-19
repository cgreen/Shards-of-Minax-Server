// Scripts/CustomPoisons/Effects/Virulent.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Virulent : IPoisonEffect
    {
        public string Id   => "Virulent";
        public string Label => "Virulent Poison";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static Virulent() => PoisonEffectRegistry.Register(new Virulent());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.ApplyPoison(attacker, Poison.Deadly);
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x36B0, 20, 40, 5005, 0x46F, 0, EffectLayer.Waist); // Particles from DeadlyVenom
            defender.SendMessage("A virulent poison attacks your system!");
        }
    }
}