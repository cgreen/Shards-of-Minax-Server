using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class Devour : IPoisonEffect
    {
        public string Id    => "Devour";
        public string Label => "Devour";
        public int SoundId  => -1; // No specific sound defined, set one if desired.

        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(1);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private const double HealPercent = 25.0; // Adjust this if you want it configurable per instance.

        static Devour() => PoisonEffectRegistry.Register(new Devour());

        public void Visual(Mobile m)
        {
            m.Say("Consumes Corpses!");
            m.SendMessage("You have consumed a corpse and healed yourself.");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
            {
                attacker?.SendMessage("This ability is on cooldown.");
                return;
            }

            if (attacker == null || attacker.Deleted || (!attacker.Alive))
                return;

            bool corpseFound = false;

            foreach (Item item in attacker.GetItemsInRange(2))
            {
                if (item is Corpse)
                {
                    item.Delete(); // Consume the corpse
                    corpseFound = true;
                    break;
                }
            }

            if (corpseFound)
            {
                int healAmount = (int)(attacker.HitsMax * (HealPercent / 100.0));
                attacker.Hits += healAmount;

                if (attacker.Hits > attacker.HitsMax)
                    attacker.Hits = attacker.HitsMax;

                Visual(attacker);
                _nextAllowed = DateTime.UtcNow + Cooldown;
            }
            else
            {
                attacker.SendMessage("No corpses nearby to consume.");
            }
        }
    }
}
