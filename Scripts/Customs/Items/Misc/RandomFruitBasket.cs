using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.CustomPies;

public class RandomFruitBasket : CustomPie
{
    private static string[] Part1 = new string[]
    {
        "Apple", "Banana", "Cherry", "Date", "Elderberry", "Fig",
        "Grape", "Honeydew", "Kiwi", "Lemon", "Mango", "Nectarine",
        "Orange", "Peach", "Quince", "Raspberry", "Strawberry", "Tangerine",
        "Uva", "Watermelon", "Xigua", "Yellow Passion Fruit", "Zucchini",
        "Apricot", "Blueberry", "Clementine", "Dragon Fruit", "Feijoa",
        "Guava", "Huckleberry", "Jabuticaba", "Kumquat", "Lychee",
        "Mulberry", "Nashi Pear", "Olallieberry", "Pomegranate", "Quenepa",
        "Rambutan", "Salal Berry", "Tamarillo", "Ugli Fruit", "Victoria Plum",
        "Wax Apple", "Yuzu", "Zapote",
        "Ambarella", "Bilimbi", "Cupuaçu", "Durian", "Eggfruit",
        "Finger Lime", "Gac Fruit", "Hala Fruit", "Imbe", "Jujube",
        "Kiwano", "Longan", "Mangosteen", "Noni Fruit", "Olive",
        "Papaya", "Quararibea Cordata", "Roselle", "Soursop", "Tamarind",
        "Uvaria", "Vanilla Bean", "Wampee", "Xylocarp", "Yumberry",
        "Zalzalak", "Açaí", "Barbadine", "Cupuacu", "Duku", "Elaeagnus Latifolia",
        "Fennel Fruit", "Galia Melon", "Horned Melon", "Ice Cream Bean",
        "Jatoba", "Kiwiberry", "Limequat", "Muntingia Calabura", "Nance",
        "Oca", "Papino", "Quandong", "Rutabaga", "Sugar Apple",
        "Tangor", "Ulluco", "Vanilla Clamshell", "White Sapote", "Ximenia",
        "Yacón", "Zig Zag Vine Fruit"
    };

    private static string[] Part2 = new string[]
    {
        "Delight", "Surprise", "Indulgence", "Bliss", "Joy", "Pleasure",
        "Euphoria", "Ecstasy", "Harmony", "Serenity", "Luxury", "Opulence",
        "Decadence", "Rapture", "Reverie", "Extravagance", "Splendor", "Panache",
        "Elegance", "Finesse", "Glamour", "Charm", "Grandeur", "Sumptuousness",
        "Savory", "Sensation", "Satisfaction", "Exquisite", "Perfection", "Magnificence",
        "Epicurean", "Culinary", "Sumptuous", "Divine", "Aromatic", "Enchanting",
        "Gourmet", "Succulent", "Delectable", "Temptation", "Luscious", "Exotic",
        "Heavenly", "Irresistible", "Plush", "Rich", "Velvety", "Voluptuous"
    };

    public static string GenerateFruitName()
    {
        return Part1[Utility.Random(Part1.Length)] + " " + Part2[Utility.Random(Part2.Length)];
    }

    [Constructable]
    public RandomFruitBasket() : base()
    {
        Name = GenerateFruitName();
        Hue = Utility.Random(1, 3000);
		ItemID = 0x0993;

        // Setting the weight to be consistent with food items
        Weight = 1.0;
    }

    public RandomFruitBasket(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
