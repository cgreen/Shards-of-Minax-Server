using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class MythicAmethystWeaponDamage : IJewelProperty
    {
        public string Id => "MythicAmethystWeaponDamage";
        public string Label => "+17 Weapon Damage";
        public int Icon => 0x9a8; // Amethyst icon

        static MythicAmethystWeaponDamage() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponDamage += 17;
        }
    }

    public sealed class MythicAmethystStrShield : IJewelProperty
    {
        public string Id => "MythicAmethystStrShield";
        public string Label => "+9 Strength (Shield)";
        public int Icon => 0x9a8;

        static MythicAmethystStrShield() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
                s.Attributes.BonusStr += 9;
        }
    }

    public sealed class MythicAmethystDefendArmor : IJewelProperty
    {
        public string Id => "MythicAmethystDefendArmor";
        public string Label => "+16 Defend Chance (Armor)";
        public int Icon => 0x9a8;

        static MythicAmethystDefendArmor() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.DefendChance += 16;
        }
    }

    public sealed class MythicAmethystDamageMaxCreature : IJewelProperty
    {
        public string Id => "MythicAmethystDamageMaxCreature";
        public string Label => "+5 Max Damage (Creature)";
        public int Icon => 0x9a8;

        static MythicAmethystDamageMaxCreature() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.DamageMax += 5;
        }
    }
}



namespace Server.CustomJewels.Properties
{
    public sealed class LegendaryAmethystWeaponDamage : IJewelProperty
    {
        public string Id => "LegendaryAmethystWeaponDamage";
        public string Label => "+10 Weapon Damage";
        public int Icon => 0x9a8;

        static LegendaryAmethystWeaponDamage() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponDamage += 10;
        }
    }

    public sealed class LegendaryAmethystStrShield : IJewelProperty
    {
        public string Id => "LegendaryAmethystStrShield";
        public string Label => "+5 Strength (Shield)";
        public int Icon => 0x9a8;

        static LegendaryAmethystStrShield() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
                s.Attributes.BonusStr += 5;
        }
    }

    public sealed class LegendaryAmethystDefendArmor : IJewelProperty
    {
        public string Id => "LegendaryAmethystDefendArmor";
        public string Label => "+10 Defend Chance (Armor)";
        public int Icon => 0x9a8;

        static LegendaryAmethystDefendArmor() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.DefendChance += 10;
        }
    }

    public sealed class LegendaryAmethystDamageMaxCreature : IJewelProperty
    {
        public string Id => "LegendaryAmethystDamageMaxCreature";
        public string Label => "+3 Max Damage (Creature)";
        public int Icon => 0x9a8;

        static LegendaryAmethystDamageMaxCreature() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.DamageMax += 3;
        }
    }
}



namespace Server.CustomJewels.Properties
{
    public sealed class AncientAmethystWeaponDamage : IJewelProperty
    {
        public string Id => "AncientAmethystWeaponDamage";
        public string Label => "+4 Weapon Damage";
        public int Icon => 0x9a8;

        static AncientAmethystWeaponDamage() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponDamage += 4;
        }
    }

    public sealed class AncientAmethystStrShield : IJewelProperty
    {
        public string Id => "AncientAmethystStrShield";
        public string Label => "+2 Strength (Shield)";
        public int Icon => 0x9a8;

        static AncientAmethystStrShield() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
                s.Attributes.BonusStr += 2;
        }
    }

    public sealed class AncientAmethystDefendArmor : IJewelProperty
    {
        public string Id => "AncientAmethystDefendArmor";
        public string Label => "+4 Defend Chance (Armor)";
        public int Icon => 0x9a8;

        static AncientAmethystDefendArmor() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.DefendChance += 4;
        }
    }

    public sealed class AncientAmethystDamageMaxCreature : IJewelProperty
    {
        public string Id => "AncientAmethystDamageMaxCreature";
        public string Label => "+1 Max Damage (Creature)";
        public int Icon => 0x9a8;

        static AncientAmethystDamageMaxCreature() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.DamageMax += 1;
        }
    }
}


