using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class FenCrystalProperty : IJewelProperty
    {
        public string Id    => "FenCrystal";
        public string Label => "Spell Channeling / Mage Armor";
        public int    Icon  => 0xF8E; // You can use the crystal icon or pick a different one.

        static FenCrystalProperty() => JewelPropertyRegistry.Get(""); // static constructor call

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.SpellChanneling = 1;
            else if (target is BaseShield s)
                s.Attributes.SpellChanneling = 1;
            else if (target is BaseArmor a)
                a.ArmorAttributes.MageArmor = 1;
        }
    }
	
	public sealed class RhoCrystalProperty : IJewelProperty
	{
		public string Id    => "RhoCrystal";
		public string Label => "+1 Faster Casting";
		public int    Icon  => 0xF8E;

		static RhoCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.CastSpeed += 1;
			else if (target is BaseShield s) s.Attributes.CastSpeed += 1;
			else if (target is BaseArmor a) a.Attributes.CastSpeed += 1;
			else if (target is BaseJewel j) j.Attributes.CastSpeed += 1;
		}
	}
		
	public sealed class RysCrystalProperty : IJewelProperty
	{
		public string Id    => "RysCrystal";
		public string Label => "+1 Faster Cast Recovery";
		public int    Icon  => 0xF8E;

		static RysCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.CastRecovery += 1;
			else if (target is BaseShield s) s.Attributes.CastRecovery += 1;
			else if (target is BaseArmor a) a.Attributes.CastRecovery += 1;
			else if (target is BaseJewel j) j.Attributes.CastRecovery += 1;
		}
	}
		
	public sealed class WyrCrystalProperty : IJewelProperty
	{
		public string Id    => "WyrCrystal";
		public string Label => "+80 Luck";
		public int    Icon  => 0xF8E;

		static WyrCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.Luck += 80;
			else if (target is BaseShield s) s.Attributes.Luck += 80;
			else if (target is BaseArmor a) a.Attributes.Luck += 80;
			else if (target is BaseJewel j) j.Attributes.Luck += 80;
		}
	}
		
	public sealed class FreCrystalProperty : IJewelProperty
	{
		public string Id    => "FreCrystal";
		public string Label => "+10 Enhance Potions";
		public int    Icon  => 0xF8E;

		static FreCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.EnhancePotions += 10;
			else if (target is BaseShield s) s.Attributes.EnhancePotions += 10;
			else if (target is BaseArmor a) a.Attributes.EnhancePotions += 10;
			else if (target is BaseJewel j) j.Attributes.EnhancePotions += 10;
		}
	}
		
	public sealed class TorCrystalProperty : IJewelProperty
	{
		public string Id    => "TorCrystal";
		public string Label => "+10 Lower Reagent Cost";
		public int    Icon  => 0xF8E;

		static TorCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.LowerRegCost += 10;
			else if (target is BaseShield s) s.Attributes.LowerRegCost += 10;
			else if (target is BaseArmor a) a.Attributes.LowerRegCost += 10;
			else if (target is BaseJewel j) j.Attributes.LowerRegCost += 10;
		}
	}
		
	public sealed class VelCrystalProperty : IJewelProperty
	{
		public string Id    => "VelCrystal";
		public string Label => "+4 Lower Mana Cost";
		public int    Icon  => 0xF8E;

		static VelCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.LowerManaCost += 4;
			else if (target is BaseShield s) s.Attributes.LowerManaCost += 4;
			else if (target is BaseArmor a) a.Attributes.LowerManaCost += 4;
			else if (target is BaseJewel j) j.Attributes.LowerManaCost += 4;
		}
	}
		
	public sealed class XenCrystalProperty : IJewelProperty
	{
		public string Id    => "XenCrystal";
		public string Label => "+5 Spell Damage";
		public int    Icon  => 0xF8E;

		static XenCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.Attributes.SpellDamage += 5;
			else if (target is BaseShield s) s.Attributes.SpellDamage += 5;
			else if (target is BaseArmor a) a.Attributes.SpellDamage += 5;
			else if (target is BaseJewel j) j.Attributes.SpellDamage += 5;
		}
	}
		
	public sealed class PolCrystalProperty : IJewelProperty
	{
		public string Id    => "PolCrystal";
		public string Label => "+50 Durability (Weapon/Armor)\n+6 Attack Chance (Jewelry)";
		public int    Icon  => 0xF8E;

		static PolCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.DurabilityBonus += 50;
			else if (target is BaseShield s) s.ArmorAttributes.DurabilityBonus += 50;
			else if (target is BaseArmor a) a.ArmorAttributes.DurabilityBonus += 50;
			else if (target is BaseJewel j) j.Attributes.AttackChance += 6;
		}
	}
		
	public sealed class WolCrystalProperty : IJewelProperty
	{
		public string Id    => "WolCrystal";
		public string Label => "+2 Self-Repair (Weapon/Armor)\n+6 Defend Chance (Jewelry)";
		public int    Icon  => 0xF8E;

		static WolCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.SelfRepair += 2;
			else if (target is BaseShield s) s.ArmorAttributes.SelfRepair += 2;
			else if (target is BaseArmor a) a.ArmorAttributes.SelfRepair += 2;
			else if (target is BaseJewel j) j.Attributes.DefendChance += 6;
		}
	}
		
	public sealed class BalCrystalProperty : IJewelProperty
	{
		public string Id    => "BalCrystal";
		public string Label => "+10 Fire Resist";
		public int    Icon  => 0xF8E;

		static BalCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.ResistFireBonus += 10;
			else if (target is BaseShield s) s.FireBonus += 10;
			else if (target is BaseArmor a) a.FireBonus += 10;
			else if (target is BaseJewel j) j.Resistances.Fire += 10;
		}
	}
		
	public sealed class TalCrystalProperty : IJewelProperty
	{
		public string Id    => "TalCrystal";
		public string Label => "+10 Cold Resist";
		public int    Icon  => 0xF8E;

		static TalCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.ResistColdBonus += 10;
			else if (target is BaseShield s) s.ColdBonus += 10;
			else if (target is BaseArmor a) a.ColdBonus += 10;
			else if (target is BaseJewel j) j.Resistances.Cold += 10;
		}
	}
		
	public sealed class JalCrystalProperty : IJewelProperty
	{
		public string Id    => "JalCrystal";
		public string Label => "+10 Poison Resist";
		public int    Icon  => 0xF8E;

		static JalCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.ResistPoisonBonus += 10;
			else if (target is BaseShield s) s.PoisonBonus += 10;
			else if (target is BaseArmor a) a.PoisonBonus += 10;
			else if (target is BaseJewel j) j.Resistances.Poison += 10;
		}
	}
		
	public sealed class RalCrystalProperty : IJewelProperty
	{
		public string Id    => "RalCrystal";
		public string Label => "+10 Energy Resist";
		public int    Icon  => 0xF8E;

		static RalCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.ResistEnergyBonus += 10;
			else if (target is BaseShield s) s.EnergyBonus += 10;
			else if (target is BaseArmor a) a.EnergyBonus += 10;
			else if (target is BaseJewel j) j.Resistances.Energy += 10;
		}
	}
		
	public sealed class KalCrystalProperty : IJewelProperty
	{
		public string Id    => "KalCrystal";
		public string Label => "+10 Physical Resist";
		public int    Icon  => 0xF8E;

		static KalCrystalProperty() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.ResistPhysicalBonus += 10;
			else if (target is BaseShield s) s.PhysicalBonus += 10;
			else if (target is BaseArmor a) a.PhysicalBonus += 10;
			else if (target is BaseJewel j) j.Resistances.Physical += 10;
		}
	}	
}
