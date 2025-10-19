// Scripts/CustomPoisons/Effects/Weak.cs 
// (If "Weak" is meant to be a poison type, not a prefix)
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Weak : IPoisonEffect // Assuming "Weak" is the name of the poison effect
    {
        public string Id   => "Weak";
        public string Label => "Weak Poison";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static Weak() => PoisonEffectRegistry.Register(new Weak());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.ApplyPoison(attacker, Poison.Lesser);
            defender.PlaySound(0x231); // Generic poison sound
            defender.FixedParticles(0x36B0, 20, 40, 5005, 0x46F, 0, EffectLayer.Waist); // Particles from DeadlyVenom
            defender.SendMessage("You feel a mild sickness!");
        }
    }
}