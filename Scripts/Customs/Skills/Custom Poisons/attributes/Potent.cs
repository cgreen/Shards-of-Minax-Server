// Scripts/CustomPoisons/Effects/Potent.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Potent : IPoisonEffect
    {
        public string Id   => "Potent";
        public string Label => "Potent Poison";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static Potent() => PoisonEffectRegistry.Register(new Potent());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.ApplyPoison(attacker, Poison.Greater);
            defender.PlaySound(0x231); 
            defender.FixedParticles(0x36B0, 20, 40, 5005, 0x46F, 0, EffectLayer.Waist); // Particles from DeadlyVenom
            defender.SendMessage("A potent toxin courses through your veins!");
        }
    }
}