// Scripts/CustomPoisons/Effects/Stamina.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Stamina : IPoisonEffect
    {
        public string Id => "Stamina";
        public string Label => "Stamina"; // Or "Stamina Drain"
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int StamDrain = Utility.RandomMinMax(20, 40);

        static Stamina() => PoisonEffectRegistry.Register(new Stamina());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("Your stamina is drained!");
            defender.PlaySound(0x1EE); // Stamina Loss sound
            defender.FixedParticles(0x374A, 10, 30, 5006, 0x34, 0, EffectLayer.Waist); // Yellow sparkles

            defender.Stam -= StamDrain;
        }
    }
}