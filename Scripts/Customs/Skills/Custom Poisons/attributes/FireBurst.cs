// Scripts/CustomPoisons/Effects/FireBurst.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class FireBurst : IPoisonEffect
    {
        public string Id    => "FireBurst";
        public string Label => "Fire Burst";
        public int SoundId => 0x15E; // Debuff sound
        public void Visual(Mobile d) =>
            d.FixedParticles(0x36BD, 6, 16, 5044, 0x489, 0, EffectLayer.Waist);	

        static FireBurst() => PoisonEffectRegistry.Register(new FireBurst());

        public void Apply(Mobile attacker, Mobile defender)
        {
            int dmg = Utility.RandomMinMax(40, 180);
            // positional parameters: phys, fire, cold, pois, energy
            AOS.Damage(defender, attacker, dmg, 0, 100, 0, 0, 0);
            // sound + visual

        }
    }
}
