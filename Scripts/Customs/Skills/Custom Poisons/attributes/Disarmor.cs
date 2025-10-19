using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class Disarmor : IPoisonEffect
    {
        public string Id    => "Disarmor";
        public string Label => "Disarmor";
        public int SoundId  => 0x3B9;

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static Disarmor() => PoisonEffectRegistry.Register(new Disarmor());

        public void Visual(Mobile target)
        {
            target.SendMessage("Your armor has been removed!");
            target.PlaySound(SoundId);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            Item[] items = defender.Items.ToArray();
            Item randomArmor = null;

            foreach (Item item in items)
            {
                if (item is BaseArmor || item is BaseClothing)
                {
                    randomArmor = item;
                    break;
                }
            }

            if (randomArmor != null)
            {
                defender.AddToBackpack(randomArmor);
                Visual(defender);
            }

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
