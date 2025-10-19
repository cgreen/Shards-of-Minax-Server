// Scripts/CustomPoisons/Effects/WeakParalysis.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class WeakParalysis : IPoisonEffect
    {
        public string Id => "WeakParalysis";
        public string Label => "Weak Paralysis";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        static WeakParalysis() => PoisonEffectRegistry.Register(new WeakParalysis());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.Paralyze(TimeSpan.FromSeconds(Utility.RandomMinMax(1, 2)));
            defender.PlaySound(0x204); // Paralyze sound
            defender.FixedEffect(0x376A, 6, 10); // Paralyze field
            defender.SendMessage("You are momentarily held in place!");
        }
    }
}