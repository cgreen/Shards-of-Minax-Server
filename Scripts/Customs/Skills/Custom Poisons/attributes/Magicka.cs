// Scripts/CustomPoisons/Effects/Magicka.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Magicka : IPoisonEffect
    {
        public string Id => "Magicka";
        public string Label => "Magicka"; // Or "Magicka Drain"
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int ManaDrain = Utility.RandomMinMax(15, 50);

        static Magicka() => PoisonEffectRegistry.Register(new Magicka());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("Your magicka is drained!");
            defender.PlaySound(0x1F8); // Mana Drain sound
            defender.FixedParticles(0x374A, 10, 30, 5022, 0x05, 0, EffectLayer.Head); // Blue sparkles

            defender.Mana -= ManaDrain;
        }
    }
}