// Scripts/CustomPoisons/Effects/EnergyArc.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class EnergyArc : IPoisonEffect
    {
        public string Id    => "EnergyArc";
        public string Label => "Energy Arc";
        public int SoundId => 0x28D; // Sword slash (pick any sound you want)
        public void Visual(Mobile d) =>
            d.FixedParticles(0x37B9, 10, 30, 5005, 0x25, 0, EffectLayer.Waist); // blood drips	

        static EnergyArc() => PoisonEffectRegistry.Register(new EnergyArc());

        public void Apply(Mobile attacker, Mobile defender)
        {
            int dmg = Utility.RandomMinMax(40, 180);
            AOS.Damage(defender, attacker, dmg, 0, 0, 0, 0, 100);

        }
    }
}
