using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.CustomPies;

public class RandomFancyPotion : CustomPie
{
    private static string[] Part1 = new string[]
    {
        "Healing", "Mana", "Stamina", "Revitalizing", "Rejuvenating", "Empowering",
        "Energizing", "Vigor", "Swiftness", "Strength", "Agility", "Intelligence",
        "Restorative", "Fortitude", "Endurance", "Enlightening", "Focus", "Clarity",
        "Stealth", "Resistance", "Vitality", "Wisdom", "Courage", "Illusion",
        "Mystic", "Life", "Spirit", "Power", "Speed", "Fleet", "Mighty",
        "Quickening", "Smart", "Mental", "Invisibility", "Elemental", "Arcane",
        "Protection", "Balance", "Nimble", "Furtive", "Guardian", "Champion",
		"Eternal", "Divine", "Radiant", "Celestial", "Empyreal", "Effervescent",
        "Elysian", "Epic", "Heroic", "Legendary", "Mythic", "Nebulous",
        "Ethereal", "Omnipotent", "Resplendent", "Transcendent", "Unfathomable",
        "Venerated", "Zenith", "Vivacious", "Renewing", "Blazing", "Vibrant",
        "Wholesome", "Nourishing", "Exalted", "Pristine", "Immaculate",
        "Sovereign", "Infinite", "Harmonious", "Celestial", "Illustrious",
        "Sublime", "Spectral", "Empyrean", "Divinely", "Enchanted", "Mythical"
    };

    private static string[] Part2 = new string[]
    {
        "Elixir", "Draught", "Philter", "Tonic", "Potion", "Brew",
        "Concoction", "Mixture", "Infusion", "Decoction", "Tincture", "Libation",
        "Ambrosia", "Nectar", "Potion", "Remedy", "Cure", "Antidote",
        "Syrup", "Lotion", "Essence", "Extract", "Dose", "Formula",
        "Vial", "Draft", "Blend", "Solution", "Spirit", "Extract", "Essence",
        "Charm", "Balm", "Blessing", "Flask", "Poultice", "Salve", "Aid",
        "Panacea", "Emanation", "Fusion", "Potion", "Elixir", "Miracle",
		"Catalyst", "Reagent", "Solvent", "Suspension", "Colloid", "Galaxy",
		"Tinct", "Compound", "Remedy", "Restorative", "Healing", "Rejuvenator",
		"Antivenom", "Cordial", "Dew", "Dosis", "Drops", "Emulsion",
		"Enchantment", "Fluid", "Galene", "Herbicide", "Injection", "Juice",
		"Lixir", "Medicament", "Nostrum", "Ointment", "Philtre", "Poison",
		"Reagent", "Serum", "Soda", "Sudorific", "Theriac", "Unguent",
		"Venom", "Wine", "Zymosis"
    };

    private static int[] Graphics = new int[]
    {
        0x0E24, 0x0E25, 0x0E26, 0x0E27, 0x0E28, 0x0E29, 0x0E2A, 0x0E2B, 0x0E2C, 0x0F06, 0x0F07, 0x0F08, 0x0F09
    };

    public static string GeneratePotionName()
    {
        return Part1[Utility.Random(Part1.Length)] + " " + Part2[Utility.Random(Part2.Length)];
    }

    [Constructable]
    public RandomFancyPotion() : base()
    {
        Name = GeneratePotionName();
        Hue = Utility.Random(1, 3000);
		ItemID = Graphics[Utility.Random(Graphics.Length)];

        // Setting the weight to be consistent with potion items
        Weight = 1.0;
    }

    public RandomFancyPotion(Serial serial) : base(serial)
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
