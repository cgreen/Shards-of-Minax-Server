using Server.Mobiles;
using Server;
using System;

namespace Server.CustomPoisons.Effects
{
    public sealed class FlameStrikeVisual : IPoisonEffect
    {
        public string Id => "FlameStrikeVisual";
        public string Label => "Flame Strike FX";
        public int SoundId => 0x208; // Sword slash (pick any sound you want)
        public void Visual(Mobile d) =>
            d.FixedParticles(0x3709, 10, 30, 5005, 0x25, 0, EffectLayer.Waist); // blood drips			

        static FlameStrikeVisual() => PoisonEffectRegistry.Register(new FlameStrikeVisual());

        public void Apply(Mobile attacker, Mobile defender)
        {
            // Cosmetic only.
            Visual(defender);
        }


    }
}
