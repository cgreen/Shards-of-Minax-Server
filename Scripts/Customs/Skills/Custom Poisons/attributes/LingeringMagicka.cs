// Scripts/CustomPoisons/Effects/LingeringMagicka.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.CustomPoisons.Effects.Helpers;

namespace Server.CustomPoisons.Effects
{
    public sealed class LingeringMagicka : IPoisonEffect
    {
        public string Id => "LingeringMagicka";
        public string Label => "Lingering Magicka Drain";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        private static readonly int Ticks = Utility.RandomMinMax(30, 50);
        private static readonly int DrainPerTick = Utility.RandomMinMax(5, 10);
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(2.5);

        static LingeringMagicka() => PoisonEffectRegistry.Register(new LingeringMagicka());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("Your magicka slowly seeps away.");
            defender.PlaySound(0x1F8); // Mana Drain
            new StatDrainTimer(defender, Ticks, Interval, DrainPerTick, StatToDrain.Mana).Start();
        }
    }
}