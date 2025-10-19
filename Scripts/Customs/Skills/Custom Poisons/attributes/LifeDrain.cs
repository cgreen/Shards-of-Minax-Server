// Scripts/CustomPoisons/Effects/LifeDrain.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class LifeDrain : IPoisonEffect
    {
        public string Id    => "LifeDrain";
        public string Label => "Life Drain";
        public int SoundId  => 0x231;

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(5);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        public void Visual(Mobile d)
        {
            d.FixedParticles(0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist);
            d.SendMessage("You feel the life drain out of you!");
        }

        static LifeDrain() => PoisonEffectRegistry.Register(new LifeDrain());

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            int drain = Utility.RandomMinMax(30, 80); // You can adjust this range to suit your desired strength

            defender.Hits -= drain;
            if (defender.Hits < 0)
                defender.Hits = 0;

            attacker.Hits += drain;
            if (attacker.Hits > attacker.HitsMax)
                attacker.Hits = attacker.HitsMax;

            Visual(defender);
            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
