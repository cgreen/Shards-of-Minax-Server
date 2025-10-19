/*  TokenVendorStone.cs  –  a ready-to-spawn, self-contained vendor stone
 *  Drop into Scripts/Custom/Vendors – compile, then   [add TokenVendorStone
 */

using System;
using Server;
using Server.Items;
using System.CustomizableVendor;   // <— namespace from the package you pasted

namespace Server.CustomVendors
{
    public class TokenVendorStone : StoneRewardVendor
    {
        [Constructable]
        public TokenVendorStone()
        {
            Name      = "Token Reward Stone";
            Hue       = 1153;                       // aqua, easy to see
            Movable   = false;

            /* ---- 1) choose ANY item as currency ---- */
            ((IRewardVendor)this).Payment = new Currency(new MaxxiaScroll());   // <— replace with whatever you want

            /* ---- 2) add pre-configured stock ---- */
            // helper adds a reward + an auto-restock rule in one line
            AddStock(new BladeOfTheStars      { Name = "Sword of Power"      }, 250);
            AddStock(new MaxxiaScroll{ Name = "Fine Scroll" },  30);
            AddStock(new DyeTub           { Name = "Special Dye Tub"     }, 100,
                     restockStart:5, restockEvery: 60, restockCap:10);   // custom restock example
					 
        }

        /* small convenience wrapper so the constructor stays tidy */
        private void AddStock(Item item, int price,
                              int restockStart = 20,
                              int restockEvery = 30,      // minutes
                              int restockCap   = -1)      // -1 = unlimited
        {
            var r = new Reward(item, price, item.Name, "");        // description optional
            r.Restock = restockEvery > 0
                ? (restockCap > 0
                     ? new Reward.RestockInfo(0, restockEvery, restockStart, 1, restockCap)
                     : new Reward.RestockInfo(0, restockEvery, restockStart, 1))
                : null;                                           // no restock rule
            ((IRewardVendor)this).AddReward(r);
        }

        /* ----- serialisation boiler-plate ----- */
        public TokenVendorStone(Serial s) : base(s) { }

        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write(0);        // version
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            int version = r.ReadInt();
        }
    }
}
