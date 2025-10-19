using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

public interface IDynamicVendor
{
    Mobile Host { get; }
    string VendorName { get; }
    Dictionary<Type, DynamicStockInfo> CurrentSellItems { get; }
    Dictionary<Type, DynamicStockInfo> CurrentBuyItems { get; }
    bool OnBuyItem(Mobile buyer, Type itemType, int price, int quantity);
    void StartSellItem(Mobile seller, Type itemType, DynamicStockInfo info);
}

