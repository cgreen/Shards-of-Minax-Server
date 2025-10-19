using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    // Mythic Diamond Effects

    public sealed class HitPhysicalArea40 : IJewelProperty
    {
        public string Id    => "HitPhysicalArea40";
        public string Label => "+40% Hit Physical Area";
        public int    Icon  => 0x9a8; // diamond gem

        static HitPhysicalArea40() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.HitPhysicalArea += 40;
        }
    }

    public sealed class ShieldAllResist5 : IJewelProperty
    {
        public string Id    => "ShieldAllResist5";
        public string Label => "+5 All Resists (Shield)";
        public int    Icon  => 0x9a8;

        static ShieldAllResist5() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
            {
                s.EnergyBonus   += 5;
                s.FireBonus     += 5;
                s.PoisonBonus   += 5;
                s.PhysicalBonus += 5;
                s.ColdBonus     += 5;
            }
        }
    }

    public sealed class AttackChance32 : IJewelProperty
    {
        public string Id    => "AttackChance32";
        public string Label => "+32% Attack Chance";
        public int    Icon  => 0x9a8;

        static AttackChance32() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.AttackChance += 32;
        }
    }

    public sealed class CreatureStr32 : IJewelProperty
    {
        public string Id    => "CreatureStr32";
        public string Label => "+32 Strength (Creature)";
        public int    Icon  => 0x9a8;

        static CreatureStr32() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.RawStr += 32;
        }
    }

    // -----------------------------------------
    // Legendary Diamond Effects

    public sealed class HitPhysicalArea25 : IJewelProperty
    {
        public string Id    => "HitPhysicalArea25";
        public string Label => "+25% Hit Physical Area";
        public int    Icon  => 0x9a8;

        static HitPhysicalArea25() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.HitPhysicalArea += 25;
        }
    }

    public sealed class ShieldAllResist3 : IJewelProperty
    {
        public string Id    => "ShieldAllResist3";
        public string Label => "+3 All Resists (Shield)";
        public int    Icon  => 0x9a8;

        static ShieldAllResist3() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
            {
                s.EnergyBonus   += 3;
                s.FireBonus     += 3;
                s.PoisonBonus   += 3;
                s.PhysicalBonus += 3;
                s.ColdBonus     += 3;
            }
        }
    }

    public sealed class AttackChance20 : IJewelProperty
    {
        public string Id    => "AttackChance20";
        public string Label => "+20% Attack Chance";
        public int    Icon  => 0x9a8;

        static AttackChance20() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.AttackChance += 20;
        }
    }

    public sealed class CreatureStr20 : IJewelProperty
    {
        public string Id    => "CreatureStr20";
        public string Label => "+20 Strength (Creature)";
        public int    Icon  => 0x9a8;

        static CreatureStr20() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.RawStr += 20;
        }
    }

    // -----------------------------------------
    // Ancient Diamond Effects

    public sealed class HitPhysicalArea10 : IJewelProperty
    {
        public string Id    => "HitPhysicalArea10";
        public string Label => "+10% Hit Physical Area";
        public int    Icon  => 0x9a8;

        static HitPhysicalArea10() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.HitPhysicalArea += 10;
        }
    }

    public sealed class ShieldAllResist1 : IJewelProperty
    {
        public string Id    => "ShieldAllResist1";
        public string Label => "+1 All Resists (Shield)";
        public int    Icon  => 0x9a8;

        static ShieldAllResist1() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
            {
                s.EnergyBonus   += 1;
                s.FireBonus     += 1;
                s.PoisonBonus   += 1;
                s.PhysicalBonus += 1;
                s.ColdBonus     += 1;
            }
        }
    }

    public sealed class AttackChance8 : IJewelProperty
    {
        public string Id    => "AttackChance8";
        public string Label => "+8% Attack Chance";
        public int    Icon  => 0x9a8;

        static AttackChance8() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.AttackChance += 8;
        }
    }

    public sealed class CreatureStr8 : IJewelProperty
    {
        public string Id    => "CreatureStr8";
        public string Label => "+8 Strength (Creature)";
        public int    Icon  => 0x9a8;

        static CreatureStr8() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.RawStr += 8;
        }
    }
}
