// Scripts/CustomPoisons/Effects/NightshadeExtract.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class NightshadeExtract : IPoisonEffect
    {
        public string Id => "NightshadeExtract";
        public string Label => "Nightshade Extract";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        static NightshadeExtract() => PoisonEffectRegistry.Register(new NightshadeExtract());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("The deadly touch of nightshade seeps into your being!");
            defender.ApplyPoison(attacker, Poison.Lethal);
            defender.PlaySound(0x18C); // Deadly poison sound
            defender.FixedParticles(0x36B0, 20, 40, 5005, 0x4F3, 0, EffectLayer.Waist); // Dark green/purple particles
            AOS.Damage(defender, attacker, Utility.RandomMinMax(50, 160), 0,0,0,100,0); // Initial poison type damage
        }
    }
}