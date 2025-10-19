// Scripts/CustomPoisons/Effects/Paralysis.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Paralysis : IPoisonEffect
    {
        public string Id    => "Paralysis";
        public string Label => "Paralysis";
		public int SoundId => -1;
		public void Visual(Mobile defender) { }		

        static Paralysis() => PoisonEffectRegistry.Register(new Paralysis());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.Paralyze(TimeSpan.FromSeconds(3));
            defender.PlaySound(0x204);
            defender.FixedEffect(0x376A, 6, 16);
        }
    }
}
