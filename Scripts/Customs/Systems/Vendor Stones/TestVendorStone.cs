/*************************************************************************
 * TestVendorStone.cs  –  drop into Scripts/Custom/Vendors, compile,
 *                        then  [add TestVendorStone
 *************************************************************************/
using System;
using Server;
using Server.Items;
using System.CustomizableVendor;          // IRewardVendor, Reward, Currency, …

namespace Server.CustomVendors
{
    public class TestVendorStone : StoneRewardVendor
    {
        [Constructable]
        public TestVendorStone()
        {
            Name    = "Maxxia Reward Stone";
            Hue     = 1153;
            Movable = false;

            /* pick ANY item to act as currency */
            ((IRewardVendor)this).Payment = new Currency(new MaxxiaScroll());

            /* ----------------------------------------------------------------
             *  EXAMPLES – just repeat AddStock(…) for every product you want
             * ----------------------------------------------------------------*/

			// Adds a regular Recall Rune for 10 tokens
			AddStock<RecallRune>(
				price: 10,
				description: "A blank recall rune, ready for marking."
			);

			// Adds a blank Spellbook for 40 tokens
			AddStock<Spellbook>(
				price: 40,
				description: "An empty spellbook for learning new spells."
			);

			// Adds a stack of 100 Bandages for 5 tokens
			AddStock<Bandage>(
				price: 5,
				description: "A stack of 100 clean bandages.",
				configure: b => b.Amount = 100
			);

			// Adds a plain Greater Heal Potion for 8 tokens
			AddStock<GreaterHealPotion>(
				price: 8,
				description: "Restores a large amount of health."
			);

			// Adds a Dye Tub for 75 tokens
			AddStock<DyeTub>(
				price: 75,
				description: "Use to dye cloth and leather items."
			);
			
			// 1) Bandages, 5 tokens each
			AddStock<Bandage>( price: 5 );

			// 2) Arrows, 1 token per shot
			AddStock<Arrow>( price: 1 );

			// 3) Greater Heal Potions, 150 tokens
			AddStock<GreaterHealPotion>( price: 150 );

			// 4) Fireball Scrolls, 300 tokens
			AddStock<FireballScroll>( price: 300 );

			// 5) A simple dyed gem (optional hue override)
			AddStock<Ruby>( price: 50, hue: 2118 );  // 2118 = deep red gem

			// 6) A named ring—still “default” stats, but custom name
			AddStock<RingmailGloves>(
				price: 200,
				title: "Explorer’s Ringmail Gloves"
			);			


            /* 1) a fully-tuned katana, restocks 1 per day up to 5 total */
            AddStock<Katana>(
                price: 500,
                hue:   1157,                             // crimson
                title: "Crimson Katana",
                description:
                    "Forged in dragon-fire • +50% dmg • Spell-channel • +10 Swords",
                configure: k =>
                {
                    k.Attributes.WeaponDamage    = 50;
                    k.Attributes.SpellChanneling = 1;
                    k.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
                },
                restockEveryMinutes: 1440,   // 24 h
                restockStart:        1,
                restockCap:          5
            );

            /* 2) a container package – a dyed platemail suit, unlimited stock */
            AddStock<Bag>(
                price: 2000,
                hue:   1289,
                title: "Mystic Marine Suit (6-pc)",
                description: "Complete dyed platemail set • +5 Hits on each piece",
                configure: bag =>
                {
                    var pieces = new Item[]
                    {
                        new PlateChest(), new PlateArms(), new PlateGloves(),
                        new PlateGorget(), new PlateHelm(), new PlateLegs()
                    };
                    foreach (var p in pieces)
                    {
                        p.Hue = 1289;
                        ((BaseArmor)p).Attributes.BonusHits = 5;
                        bag.DropItem(p);
                    }
                }
                // restockEveryMinutes defaults to 0 → infinite stock
            );
        }

        /* ================================================================
         *  AddStock helper – ONE method does all the heavy lifting
         * ================================================================*/
        private void AddStock<T>(
            int      price,
            int      hue                 = -1,
            string   title               = null,
            string   description         = null,
            Action<T> configure          = null,
            int      restockEveryMinutes = 0,
            int      restockStart        = 20,
            int      restockCap          = -1
        ) where T : Item, new()
        {
            /* build (or receive) the item */
            var item = new T();
            if (hue >= 0)              item.Hue = hue;
            if (!string.IsNullOrEmpty(title))
                                        item.Name = title;
            configure?.Invoke(item);   // let caller tweak props

            /* wrap in Reward */
            var reward = new Reward(
                item,
                price,
                title ?? item.Name ?? typeof(T).Name,
                description ?? string.Empty
            );

            if (restockEveryMinutes > 0)
            {
                reward.Restock = (restockCap > 0)
                    ? new Reward.RestockInfo(0, restockEveryMinutes, restockStart, 1, restockCap)
                    : new Reward.RestockInfo(0, restockEveryMinutes, restockStart, 1);
            }

            /* push into vendor via the interface */
            ((IRewardVendor)this).AddReward(reward);
        }

        /* ===== serialisation boiler-plate (unchanged) ===== */
        public TestVendorStone(Serial s) : base(s) { }
        public override void Serialize(GenericWriter w) { base.Serialize(w); w.Write(0); }
        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r); int version = r.ReadInt();
        }
    }
}
