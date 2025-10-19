// Scripts/CustomPoisons/Effects/Deadly.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Deadly : IPoisonEffect 
    {
        public string Id   => "Deadly";
        public string Label => "Deadly Poison";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static Deadly() => PoisonEffectRegistry.Register(new Deadly());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.ApplyPoison(attacker, Poison.Lethal);
            defender.PlaySound(0x18C); // Sound from DeadlyVenom example
            defender.FixedParticles(0x36B0, 20, 40, 5005, 0x46F, 0, EffectLayer.Waist); // Particles from DeadlyVenom
            defender.SendMessage("A lethal poison courses through you!");
        }
    }
}