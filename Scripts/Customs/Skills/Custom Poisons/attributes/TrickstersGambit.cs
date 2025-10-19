using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class TrickstersGambit : IPoisonEffect
    {
        public string Id    => "TrickstersGambit";
        public string Label => "Trickster's Gambit";
        public int SoundId  => -1; // No sound defined in XML, set -1 or add a sound ID if desired.

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(6); // 0.1 minutes = 6 seconds
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static TrickstersGambit() => PoisonEffectRegistry.Register(new TrickstersGambit());

        public void Visual(Mobile m)
        {
            m.SendMessage("You feel a surge of power course through your body!");
            // Add particle/sound effects here if you'd like visual feedback
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null)
                return;

            attacker.AddStatMod(new StatMod(StatType.Str, "TrickstersGambitStr", 20, TimeSpan.FromSeconds(30)));
            attacker.AddStatMod(new StatMod(StatType.Dex, "TrickstersGambitDex", 20, TimeSpan.FromSeconds(30)));

            Visual(attacker);
            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
