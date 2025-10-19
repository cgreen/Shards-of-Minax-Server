using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.XmlSpawner2;
using Server.Targeting;
using Server.Gumps;

namespace Server.Engines.XmlSpawner2
{
    
    public class XmlDynamicVendor : XmlAttachment, IDynamicVendor
    {
        // ------------ configurable ------------
        private static readonly Dictionary<Type, int> PriceList = new Dictionary<Type, int>()
        {
            { typeof(Arrow),     2  },
            { typeof(Bandage),   3  },
            { typeof(IronIngot), 6  },
            // …add more here
        };

        private static readonly HashSet<Type> ExcludedTypes = new HashSet<Type>()
        {
            typeof(Backpack),   // the vendor’s own backpack
            typeof(Gold)        // gold coins
            // add any other types you want to block here…
        };

        public Mobile Host { get { return this.AttachedTo as Mobile; } }

        private const double PriceVariance = 0.15;   // ±15 %
        private const int UnknownMin = 25;           // gp
        private const int UnknownMax = 5000;
        // --------------------------------------

        private Dictionary<Type, DynamicStockInfo> _sellCache;
        private Dictionary<Type, DynamicStockInfo> _buyCache;

        public string VendorName
        {
            get
            {
                Mobile m = this.AttachedTo as Mobile;
                return (m != null ? m.Name : "Vendor");
            }
        }

        public Dictionary<Type, DynamicStockInfo> CurrentSellItems { get { return _sellCache; } }
        public Dictionary<Type, DynamicStockInfo> CurrentBuyItems { get { return _buyCache; } }

        // Default constructor (needed for adding via [addatt])
		[Attachable]
        public XmlDynamicVendor() : base()
        {
            _sellCache = new Dictionary<Type, DynamicStockInfo>();
            _buyCache = new Dictionary<Type, DynamicStockInfo>();
        }

        // Required serialization constructor for XmlSpawner2
        public XmlDynamicVendor(ASerial serial) : base(serial)
        {
            // Make sure dictionaries are always initialized before deserialization
            _sellCache = new Dictionary<Type, DynamicStockInfo>();
            _buyCache = new Dictionary<Type, DynamicStockInfo>();
        }

        public override bool HandlesOnSpeech { get { return true; } }

        public override void OnAttach()
        {
            base.OnAttach();
            BuildCaches();
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            // 1) Basic deleted/null checks
            if (Deleted || AttachedTo == null || e.Mobile == null)
                return;

            // 2) Cast the attached object to Mobile
            Mobile host = AttachedTo as Mobile;
            if (host == null)
                return;

            // 3) Make sure speaker is close enough
            if (!e.Mobile.InRange(host.Location, 5))
                return;

            // 4) Check for “buy” / “sell” keywords
            string spoken = e.Speech.ToLower();
            if (spoken.IndexOf("buy") >= 0 || spoken.IndexOf("sell") >= 0
                || e.HasKeyword(0x3C) || e.HasKeyword(0x3D)
                || e.HasKeyword(0x177) || e.HasKeyword(0x171))
            {
                e.Handled = true;

                // Refresh the snapshot of items & prices
                BuildCaches();

                // Open the gump, passing (buyer, vendorMobile, thisAttachment)
                e.Mobile.SendGump(new DynamicVendorGump(e.Mobile, host, this));
            }
        }

        private void BuildCaches()
        {
            if (_sellCache == null) _sellCache = new Dictionary<Type, DynamicStockInfo>();
            if (_buyCache == null) _buyCache = new Dictionary<Type, DynamicStockInfo>();

            _sellCache.Clear();
            _buyCache.Clear();

            Mobile m = this.AttachedTo as Mobile;
            if (m == null)
                return;

            // backpack items
            if (m.Backpack != null)
            {
                foreach (Item it in m.Backpack.Items)
                    AddItemToSellRecursive(it);
            }

            // equipped layers
            foreach (Item it in m.Items)
                AddItemToSell(it);

            // buy list = mirror of sell prices, unlimited qty
            foreach (KeyValuePair<Type, DynamicStockInfo> kv in _sellCache)
            {
                DynamicStockInfo info = kv.Value;
                _buyCache[kv.Key] = new DynamicStockInfo(info.Price, 999);
            }
        }

        private void AddItemToSellRecursive(Item item)
        {
            if (item == null || item.Deleted)
                return;

            // Skip excluded types like gold or backpacks
            if (ExcludedTypes.Contains(item.GetType()))
                return;

            if (item is Container container)
            {
                // Recurse into container
                foreach (Item subItem in container.Items)
                {
                    AddItemToSellRecursive(subItem);
                }
                return; // Skip the container itself
            }

            // Sellable item
            AddItemToSell(item);
        }

        private void AddItemToSell(Item it)
        {
            if (it == null || it.Deleted)
                return;

            // 1) skip anything in our exclusion list
            if (ExcludedTypes.Contains(it.GetType()))
                return;

            // 2) optionally skip *all* containers (if you never want any container sold)
            if (it is Container)
                return;

            // now the existing logic:
            Type t = it.GetType();
            int qty = (it.Amount < 1 ? 1 : it.Amount);

            DynamicStockInfo info;
            if (!_sellCache.TryGetValue(t, out info))
            {
                info = new DynamicStockInfo(GetPrice(t), 0);
                _sellCache[t] = info;
            }
            info.Quantity += qty;
        }

        private int GetPrice(Type t)
        {
            int basePrice;
            if (PriceList.TryGetValue(t, out basePrice))
                return ApplyVariance(basePrice);

            return Utility.RandomMinMax(UnknownMin, UnknownMax);
        }

        private int ApplyVariance(int basePrice)
        {
            double delta = (Utility.RandomDouble() * 2.0 - 1.0) * PriceVariance;
            int price = (int)(basePrice * (1.0 + delta));
            return (price > 0 ? price : 1);
        }

        public bool OnBuyItem(Mobile buyer, Type itemType, int price, int quantity)
        {
            DynamicStockInfo info;
            if (quantity < 1
                || !_sellCache.TryGetValue(itemType, out info)
                || info.Price != price
                || quantity > info.Quantity)
            {
                buyer.SendMessage("Vendor: Please check my stock again – something changed.");
                return false;
            }

            Container pack = buyer.Backpack;
            if (pack == null)
                return false;

            int cost = price * quantity;
            if (!Banker.Withdraw(buyer, cost) && !pack.ConsumeTotal(typeof(Gold), cost))
            {
                buyer.SendMessage("You cannot afford that");
                return false;
            }

            Mobile npc = this.AttachedTo as Mobile;
            if (npc == null)
                return false;

            MoveItems(npc, buyer, itemType, quantity);

            info.Quantity -= quantity;
            if (info.Quantity <= 0)
                _sellCache.Remove(itemType);

            buyer.SendMessage("Here is your purchase");
            return true;
        }

        /// <summary>
        /// Moves up to 'amount' items of the given type from one Mobile to another.
        /// Splits stackable items as needed using SplitItem.
        /// </summary>
        private static void MoveItems(Mobile from, Mobile to, Type itemType, int amount)
        {
            int moved = 0;

            // Gather all items recursively
            List<Item> found = new List<Item>();
            if (from.Backpack != null)
                GatherItemsRecursive(from.Backpack, itemType, found);

            // Also check equipped (non-backpack) layers
            foreach (Item it in new List<Item>(from.Items))
            {
                if (it.Layer == Layer.Backpack)
                    continue;

                if (it.GetType() == itemType)
                    found.Add(it);
            }

            foreach (Item it in found)
            {
                if (moved >= amount)
                    break;

                int take = Math.Min(it.Amount, amount - moved);
                Item slice = (take == it.Amount ? it : SplitItem(it, take));

                // Move to buyer's backpack
                if (!to.Backpack.TryDropItem(to, slice, false))
                    slice.MoveToWorld(to.Location, to.Map); // fallback drop on ground

                moved += take;
            }
        }

        private static void GatherItemsRecursive(Container container, Type itemType, List<Item> results)
        {
            foreach (Item item in container.Items)
            {
                if (item == null || item.Deleted)
                    continue;

                if (item.GetType() == itemType)
                {
                    results.Add(item);
                }
                else if (item is Container subContainer)
                {
                    GatherItemsRecursive(subContainer, itemType, results);
                }
            }
        }

        // Helper to split a stackable item without relying on Item.Split(int)
        private static Item SplitItem(Item it, int amount)
        {
            // If it's not stackable, or we're taking the whole stack, just return it
            if (!it.Stackable || it.Amount <= amount)
                return it;

            // Create a new instance of the same type
            Item slice = Activator.CreateInstance(it.GetType()) as Item;
            if (slice != null)
            {
                slice.Amount = amount;
                it.Amount -= amount;
                // Make sure the new piece goes into the same container
                if (it.Parent is Container c)
                    c.DropItem(slice);
            }
            return slice;
        }

        public void StartSellItem(Mobile seller, Type itemType, DynamicStockInfo info)
        {
            seller.SendMessage("Target the " + GetItemName(itemType) + " you want to sell (any amount).");
            seller.Target = new SellTarget(this, itemType, info);
        }

        private class SellTarget : Target
        {
            private XmlDynamicVendor _att;
            private Type _type;
            private DynamicStockInfo _info;

            public SellTarget(XmlDynamicVendor att, Type t, DynamicStockInfo info)
                : base(3, false, TargetFlags.None)
            {
                _att = att;
                _type = t;
                _info = info;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                Item it = targeted as Item;
                if (it == null || it.GetType() != _type || it.Parent != from.Backpack)
                {
                    from.SendMessage("That’s not what I asked for.");
                    return;
                }

                int pay = _info.Price * it.Amount;
                from.Backpack.DropItem(new Gold(pay));
                from.SendLocalizedMessage(1042971, pay.ToString("#,0"));
                Mobile npc = _att.AttachedTo as Mobile;
                if (npc != null && npc.Backpack != null)
                    npc.Backpack.DropItem(it);
            }
        }

        private string GetItemName(Type t)
        {
            // split PascalCase into words
            return Regex.Replace(t.Name, "(?<!^)([A-Z])", " $1");
        }

        // Serialization for XmlSpawner2
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            // (no need to write caches; they’re rebuilt on attach/deserialize)
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = 0;
            try { version = reader.ReadInt(); }
            catch { /* tolerate pre-version saves */ }

            if (_sellCache == null) _sellCache = new Dictionary<Type, DynamicStockInfo>();
            if (_buyCache == null) _buyCache = new Dictionary<Type, DynamicStockInfo>();
            BuildCaches();
        }
    }
}
