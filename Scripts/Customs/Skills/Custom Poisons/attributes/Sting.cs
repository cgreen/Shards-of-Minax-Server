// Scripts/CustomPoisons/Effects/Sting.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class Sting : IPoisonEffect
    {
        public string Id    => "Sting";
        public string Label => "Sting";
        public int SoundId  => -1; // No sound effect, update if needed

        private const int ExtraDamage = 50;

        static Sting() => PoisonEffectRegistry.Register(new Sting());

        public void Visual(Mobile defender)
        {
            // Optionally add particle effects or messages
            defender.SendMessage("The poison stings deeper!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            if (defender.Poisoned)
            {
                // Deal extra damage that ignores armor
                defender.Damage(ExtraDamage, attacker, true); // 'true' => ignores armor
                Visual(defender);
                attacker.Say("Stings!");
            }
        }
    }
}
