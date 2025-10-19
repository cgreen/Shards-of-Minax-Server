using Server.Mobiles;
using Server;
using System;


namespace Server.CustomPoisons.Effects
{
    public sealed class Bleed : IPoisonEffect
    {
        public string Id => "Bleed";
        public string Label => "Bleed";

        static Bleed() => PoisonEffectRegistry.Register(new Bleed());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.Damage(Utility.RandomMinMax(50, 200), attacker);
            Visual(defender);
        }

        public int SoundId => 0x028; // Sword slash (pick any sound you want)
        public void Visual(Mobile d) =>
            d.FixedParticles(0x36B0, 10, 30, 5005, 0x25, 0, EffectLayer.Waist); // blood drips
    }
}
