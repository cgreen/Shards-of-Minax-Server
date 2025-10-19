// Scripts/CustomPoisons/Effects/FrostbiteVenom.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class FrostbiteVenom : IPoisonEffect
    {
        public string Id => "FrostbiteVenom";
        public string Label => "Frostbite Venom";
        public int SoundId => -1;
        public void Visual(Mobile d) { }

        static FrostbiteVenom() => PoisonEffectRegistry.Register(new FrostbiteVenom());

        public void Apply(Mobile attacker, Mobile defender)
        {
            defender.SendMessage("A biting frost and venom course through you!");
            
            // Cold Damage
            AOS.Damage(defender, attacker, Utility.RandomMinMax(50, 100), 0, 0, 100, 0, 0);
            defender.PlaySound(0x1FB); // Cold sound
            defender.FixedParticles(0x374A, 10, 30, 5005, 0x480, 0, EffectLayer.Waist); // Ice particles

            // Standard Poison
            defender.ApplyPoison(attacker, Poison.Regular); // Or Poison.Greater
            defender.PlaySound(0x231); // Poison sound
            // Add poison particles if desired, or let the standard poison system handle it
        }
    }
}