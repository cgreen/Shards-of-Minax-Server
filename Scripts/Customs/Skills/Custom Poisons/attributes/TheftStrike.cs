// Scripts/CustomPoisons/Effects/TheftStrike.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomPoisons.Effects
{
    public sealed class TheftStrike : IPoisonEffect
    {
        public string Id    => "TheftStrike";
        public string Label => "Theft Strike";
        public int SoundId  => -1; // No sound defined in original logic

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(10);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static TheftStrike() => PoisonEffectRegistry.Register(new TheftStrike());

        public void Visual(Mobile target)
        {
            target?.SendMessage("An item has been stolen from you!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null)
                return;

            Container targetPack = defender.Backpack;
            if (targetPack == null || targetPack.Items.Count == 0)
                return;

            List<Item> stealable = targetPack.Items
                .Where(i => !i.CheckBlessed(defender))
                .ToList();

            if (stealable.Count == 0)
            {
                attacker.SendMessage("You couldn't find anything to steal!");
                return;
            }

            Item stolen = stealable[Utility.Random(stealable.Count)];
            if (stolen == null)
                return;

            targetPack.RemoveItem(stolen);

            Container attackerPack = attacker.Backpack;
            if (attackerPack == null)
            {
                attackerPack = new Backpack();
                attacker.AddItem(attackerPack);
            }

            attackerPack.DropItem(stolen);

            attacker.SendMessage("You have stolen an item!");
            Visual(defender);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
