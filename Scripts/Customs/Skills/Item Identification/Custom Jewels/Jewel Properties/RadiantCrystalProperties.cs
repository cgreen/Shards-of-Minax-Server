using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    // --------------------------------------------------
    // Radiant Rho: +3 Faster Casting
    // --------------------------------------------------
    public sealed class RadiantRho : IJewelProperty
    {
        public string Id    => "RadiantRho";
        public string Label => "+3 Faster Casting";
        public int    Icon  => 0x3DB;    // generic blue gem

        static RadiantRho() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.CastSpeed += 3;
            else if (target is BaseShield s)
                s.Attributes.CastSpeed += 3;
            else if (target is BaseArmor a)
                a.Attributes.CastSpeed += 3;
            else if (target is BaseJewel j)
                j.Attributes.CastSpeed += 3;
        }
    }

    // --------------------------------------------------
    // Radiant Rys: +3 Faster Cast Recovery
    // --------------------------------------------------
    public sealed class RadiantRys : IJewelProperty
    {
        public string Id    => "RadiantRys";
        public string Label => "+3 Faster Cast Recovery";
        public int    Icon  => 0x3DB;    // generic blue gem

        static RadiantRys() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.CastRecovery += 3;
            else if (target is BaseShield s)
                s.Attributes.CastRecovery += 3;
            else if (target is BaseArmor a)
                a.Attributes.CastRecovery += 3;
            else if (target is BaseJewel j)
                j.Attributes.CastRecovery += 3;
        }
    }

    // --------------------------------------------------
    // Radiant Wyr: +200 Luck
    // --------------------------------------------------
    public sealed class RadiantWyr : IJewelProperty
    {
        public string Id    => "RadiantWyr";
        public string Label => "+200 Luck";
        public int    Icon  => 0x3DB;

        static RadiantWyr() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.Luck += 200;
            else if (target is BaseShield s)
                s.Attributes.Luck += 200;
            else if (target is BaseArmor a)
                a.Attributes.Luck += 200;
            else if (target is BaseJewel j)
                j.Attributes.Luck += 200;
        }
    }

    // --------------------------------------------------
    // Radiant Fre: +25 Enhance Potions
    // --------------------------------------------------
    public sealed class RadiantFre : IJewelProperty
    {
        public string Id    => "RadiantFre";
        public string Label => "+25 Enhance Potions";
        public int    Icon  => 0x3DB;

        static RadiantFre() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.EnhancePotions += 25;
            else if (target is BaseShield s)
                s.Attributes.EnhancePotions += 25;
            else if (target is BaseArmor a)
                a.Attributes.EnhancePotions += 25;
            else if (target is BaseJewel j)
                j.Attributes.EnhancePotions += 25;
        }
    }

    // --------------------------------------------------
    // Radiant Tor: +25 Lower Reagent Cost
    // --------------------------------------------------
    public sealed class RadiantTor : IJewelProperty
    {
        public string Id    => "RadiantTor";
        public string Label => "+25 Lower Reagent Cost";
        public int    Icon  => 0x3DB;

        static RadiantTor() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.LowerRegCost += 25;
            else if (target is BaseShield s)
                s.Attributes.LowerRegCost += 25;
            else if (target is BaseArmor a)
                a.Attributes.LowerRegCost += 25;
            // Note: Original socket disallowed jewelry here
        }
    }

    // --------------------------------------------------
    // Radiant Vel: +10 Lower Mana Cost
    // --------------------------------------------------
    public sealed class RadiantVel : IJewelProperty
    {
        public string Id    => "RadiantVel";
        public string Label => "+10 Lower Mana Cost";
        public int    Icon  => 0x3DB;

        static RadiantVel() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.LowerManaCost += 10;
            else if (target is BaseShield s)
                s.Attributes.LowerManaCost += 10;
            else if (target is BaseArmor a)
                a.Attributes.LowerManaCost += 10;
            else if (target is BaseJewel j)
                j.Attributes.LowerManaCost += 10;
        }
    }

    // --------------------------------------------------
    // Radiant Xen: +12 Spell Damage
    // --------------------------------------------------
    public sealed class RadiantXen : IJewelProperty
    {
        public string Id    => "RadiantXen";
        public string Label => "+12 Spell Damage";
        public int    Icon  => 0x3DB;

        static RadiantXen() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.SpellDamage += 12;
            else if (target is BaseShield s)
                s.Attributes.SpellDamage += 12;
            else if (target is BaseArmor a)
                a.Attributes.SpellDamage += 12;
            else if (target is BaseJewel j)
                j.Attributes.SpellDamage += 12;
        }
    }

    // --------------------------------------------------
    // Radiant Pol: Weapon/Armor +125 Durability, Jewelry +15 Attack Chance
    // --------------------------------------------------
    public sealed class RadiantPol : IJewelProperty
    {
        public string Id    => "RadiantPol";
        public string Label => "+125 Durability (Weapon/Armor), +15 Attack Chance (Jewelry)";
        public int    Icon  => 0x3DB;

        static RadiantPol() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.DurabilityBonus += 125;
            else if (target is BaseShield s)
                s.ArmorAttributes.DurabilityBonus += 125;
            else if (target is BaseArmor a)
                a.ArmorAttributes.DurabilityBonus += 125;
            else if (target is BaseJewel j)
                j.Attributes.AttackChance += 15;
        }
    }

    // --------------------------------------------------
    // Radiant Wol: Weapon/Armor +5 Self-Repair, Jewelry +15 Defend Chance
    // --------------------------------------------------
    public sealed class RadiantWol : IJewelProperty
    {
        public string Id    => "RadiantWol";
        public string Label => "+5 Self-Repair (Weapon/Armor), +15 Defend Chance (Jewelry)";
        public int    Icon  => 0x3DB;

        static RadiantWol() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.SelfRepair += 5;
            else if (target is BaseShield s)
                s.ArmorAttributes.SelfRepair += 5;
            else if (target is BaseArmor a)
                a.ArmorAttributes.SelfRepair += 5;
            else if (target is BaseJewel j)
                j.Attributes.DefendChance += 15;
        }
    }

    // --------------------------------------------------
    // Radiant Bal: +25 Fire Resist (Weapon: WeaponAttributes, Armor/Shield: .FireBonus, Jewelry: .Resistances.Fire)
    // --------------------------------------------------
    public sealed class RadiantBal : IJewelProperty
    {
        public string Id    => "RadiantBal";
        public string Label => "+25 Resist Fire";
        public int    Icon  => 0x3DB;

        static RadiantBal() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.ResistFireBonus += 25;
            else if (target is BaseShield s)
                s.FireBonus += 25;
            else if (target is BaseArmor a)
                a.FireBonus += 25;
            else if (target is BaseJewel j)
                j.Resistances.Fire += 25;
        }
    }

    // --------------------------------------------------
    // Radiant Tal: +25 Cold Resist
    // --------------------------------------------------
    public sealed class RadiantTal : IJewelProperty
    {
        public string Id    => "RadiantTal";
        public string Label => "+25 Resist Cold";
        public int    Icon  => 0x3DB;

        static RadiantTal() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.ResistColdBonus += 25;
            else if (target is BaseShield s)
                s.ColdBonus += 25;
            else if (target is BaseArmor a)
                a.ColdBonus += 25;
            else if (target is BaseJewel j)
                j.Resistances.Cold += 25;
        }
    }

    // --------------------------------------------------
    // Radiant Jal: +25 Poison Resist
    // --------------------------------------------------
    public sealed class RadiantJal : IJewelProperty
    {
        public string Id    => "RadiantJal";
        public string Label => "+25 Resist Poison";
        public int    Icon  => 0x3DB;

        static RadiantJal() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.ResistPoisonBonus += 25;
            else if (target is BaseShield s)
                s.PoisonBonus += 25;
            else if (target is BaseArmor a)
                a.PoisonBonus += 25;
            else if (target is BaseJewel j)
                j.Resistances.Poison += 25;
        }
    }

    // --------------------------------------------------
    // Radiant Ral: +25 Energy Resist
    // --------------------------------------------------
    public sealed class RadiantRal : IJewelProperty
    {
        public string Id    => "RadiantRal";
        public string Label => "+25 Resist Energy";
        public int    Icon  => 0x3DB;

        static RadiantRal() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.ResistEnergyBonus += 25;
            else if (target is BaseShield s)
                s.EnergyBonus += 25;
            else if (target is BaseArmor a)
                a.EnergyBonus += 25;
            else if (target is BaseJewel j)
                j.Resistances.Energy += 25;
        }
    }

    // --------------------------------------------------
    // Radiant Kal: +25 Physical Resist
    // --------------------------------------------------
    public sealed class RadiantKal : IJewelProperty
    {
        public string Id    => "RadiantKal";
        public string Label => "+25 Resist Physical";
        public int    Icon  => 0x3DB;

        static RadiantKal() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.ResistPhysicalBonus += 25;
            else if (target is BaseShield s)
                s.PhysicalBonus += 25;
            else if (target is BaseArmor a)
                a.PhysicalBonus += 25;
            else if (target is BaseJewel j)
                j.Resistances.Physical += 25;
        }
    }
}
