using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Weaken : IPoisonEffect
    {
        public string Id    => "Weaken";
        public string Label => "Weaken";
        public int SoundId  => -1; // Optional: Set if you want to play a sound on trigger

        private static readonly TimeSpan Duration    = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan Cooldown    = TimeSpan.FromMilliseconds(500); // Prevents rapid retriggering
        private static DateTime _nextAllowed         = DateTime.UtcNow;

        private static readonly Random Rand = new Random();

        static Weaken() => PoisonEffectRegistry.Register(new Weaken());

        public void Visual(Mobile defender)
        {
            defender.SendMessage("You feel your strength fade...");
            defender.Say("*Weakened*");

            // Optional: Add particles or sound effects if desired
            // defender.FixedParticles(0x3779, 10, 20, 5005, 0x2A, 2, EffectLayer.Head);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            if (DateTime.UtcNow < _nextAllowed)
                return;

            // 15% proc chance
            if (Utility.RandomDouble() > 0.15)
                return;

            int strLoss = 10;
            int dexLoss = 10;
            int intLoss = 10;

            // Apply the debuff
            defender.Str -= strLoss;
            defender.Dex -= dexLoss;
            defender.Int -= intLoss;

            Visual(defender);

            Timer.DelayCall(Duration, () =>
            {
                if (!defender.Deleted)
                {
                    defender.Str += strLoss;
                    defender.Dex += dexLoss;
                    defender.Int += intLoss;
                }
            });

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }
    }
}
