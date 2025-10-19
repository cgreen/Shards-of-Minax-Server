using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.CustomPies;

public class RandomFancyFish : CustomPie
{
    private static string[] Part1 = new string[]
    {
        "Golden", "Silver", "Bronze", "Rainbow", "Midnight", "Sapphire",
        "Ruby", "Emerald", "Pearl", "Diamond", "Crystal", "Obsidian",
        "Amber", "Jade", "Topaz", "Amethyst", "Garnet", "Opal", "Tiger",
        "Zebra", "Clown", "Angel", "Blue", "Red", "Green", "Black",
        "White", "Yellow", "Purple", "Orange", "Pink", "Brown", "Gray",
        "Cobalt", "Crimson", "Azure", "Violet", "Indigo", "Maroon",
        "Turquoise", "Coral", "Lavender", "Ivory", "Ebony", "Hazel",
        "Sienna", "Steel", "Platinum", "Copper", "Aqua", "Magenta",
        "Fuchsia", "Lime", "Teal", "Navy", "Cerulean", "Mauve",
        "Taupe", "Beige", "Chestnut", "Khaki", "Olive", "Sepia",
		"Azure", "Cobalt", "Crimson", "Ebony", "Fuchsia", "Indigo",
		"Ivory", "Jet", "Lavender", "Magenta", "Maroon", "Mauve",
		"Mint", "Navy", "Olive", "Plum", "Rose", "Saffron",
		"Scarlet", "Teal", "Turquoise", "Violet", "Vermilion", "Yellowish",
		"Cyan", "Beige", "Cerulean", "Chartreuse", "Coral", "Cream",
		"Goldenrod", "Lime", "Mahogany", "Midnight Blue", "Mocha", "Mulberry",
		"Aquamarine", "Celestial", "Aurora", "Neptune", "Galactic",
        "Enchanted", "Phoenix", "Titanium", "Orchid", "Spectral",
        "Starlight", "Cosmic", "Nebula", "Solar", "Lunar",
        "Eclipse", "Celestial", "Nova", "Abyssal", "Eternal"
		
    };

    private static string[] Part2 = new string[]
    {
        "Trout", "Salmon", "Tuna", "Bass", "Carp", "Catfish",
        "Shark", "Eel", "Pike", "Perch", "Herring", "Sardine",
        "Anchovy", "Mackerel", "Halibut", "Cod", "Flounder", "Snapper",
        "Grouper", "Tilapia", "Crayfish", "Lobster", "Crab", "Shrimp",
        "Oyster", "Mussel", "Clam", "Squid", "Octopus", "Starfish",
        "Sturgeon", "Puffer", "Angelfish", "Seahorse", "Manta", "Ray",
        "Marlin", "Swordfish", "Turbot", "Pollock", "Haddock", "Skate",
        "Barracuda", "Dolphinfish", "Parrotfish", "Goby", "Minnow", "Cusk",
        "Gar", "Sunfish", "Eagle Ray", "Bluegill", "Piranha", "Jellyfish",
		"Pufferfish", "Seahorse", "Stingray", "Swordfish", "Tarpon", "Turbot",
		"Wahoo", "Walleye", "Wrasse", "Angelfish", "Barracuda", "Bluegill",
		"Bonefish", "Butterflyfish", "Cichlid", "Damselfish", "Gar", "Goby",
		"Grouper", "Gudgeon", "Haddock", "Hake", "Hammerhead", "Jellyfish",
		"Koi", "Marlin", "Minnow", "Moray", "Parrotfish", "Piranha",
		"Pollock", "Porgy", "Rockfish", "Skate", "Sole", "Sturgeon",
		"Dragonfish", "Mermaid", "Kraken", "Leviathan", "Siren",
        "Phoenixfish", "Luminescent", "Aurorafish", "Stardust",
        "Moonfish", "Sunburst", "Galaxyfish", "Supernova", "Cosmicray",
        "Voidfish", "Eclipsefish", "Abyssalfish", "Celestialfish"
    };

    private static int[] Graphics = new int[]
    {
        0x09CC, 0x09CD, 0x09CE, 0x09CF
    };

    public static string GenerateFishName()
    {
        return Part1[Utility.Random(Part1.Length)] + " " + Part2[Utility.Random(Part2.Length)];
    }

    [Constructable]
    public RandomFancyFish() : base()
    {
        Name = GenerateFishName();
        Hue = Utility.Random(1, 3000);
        Weight = 1.0;
		ItemID = Graphics[Utility.Random(Graphics.Length)];
    }

    public RandomFancyFish(Serial serial) : base(serial)
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
