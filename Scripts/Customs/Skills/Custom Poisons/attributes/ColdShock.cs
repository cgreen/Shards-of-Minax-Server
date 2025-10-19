// Scripts/CustomPoisons/Effects/ColdShock.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class ColdShock : IPoisonEffect
    {
        public string Id    => "ColdShock";
        public string Label => "Cold Shock";
        public int SoundId => 0x01A; // Sword slash (pick any sound you want)
        public void Visual(Mobile d) =>
            d.FixedParticles(0x374A, 10, 30, 5005, 0x25, 0, EffectLayer.Waist); // blood drips	

        static ColdShock() => PoisonEffectRegistry.Register(new ColdShock());

        public void Apply(Mobile attacker, Mobile defender)
        {
            int dmg = Utility.RandomMinMax(50, 150);
            AOS.Damage(defender, attacker, dmg, 0, 0, 100, 0, 0);

        }
    }
}
