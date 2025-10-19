using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{

	public sealed class HitFireArea40 : IJewelProperty
	{
		public string Id    => "HitFireArea40";
		public string Label => "Hit Fire Area 40%";
		public int    Icon  => 0x9A8; // Ruby icon

		static HitFireArea40() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.HitFireArea += 40;
		}
	}

	public sealed class FireResist25 : IJewelProperty
	{
		public string Id    => "FireResist25";
		public string Label => "Fire Resist +25";
		public int    Icon  => 0x9A8; // Ruby icon

		static FireResist25() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s) s.FireBonus += 25;
		}
	}

	public sealed class BonusHits32 : IJewelProperty
	{
		public string Id    => "BonusHits32";
		public string Label => "+32 Hits";
		public int    Icon  => 0x9A8; // Ruby icon

		static BonusHits32() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a) a.Attributes.BonusHits += 32;
		}
	}

	public sealed class CreatureArmor32 : IJewelProperty
	{
		public string Id    => "CreatureArmor32";
		public string Label => "+32 Armor";
		public int    Icon  => 0x9A8; // Ruby icon

		static CreatureArmor32() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseCreature c) c.VirtualArmor += 32;
		}
	}

	public sealed class HitFireArea25 : IJewelProperty
	{
		public string Id    => "HitFireArea25";
		public string Label => "Hit Fire Area 25%";
		public int    Icon  => 0x9A8;

		static HitFireArea25() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.HitFireArea += 25;
		}
	}

	public sealed class FireResist15 : IJewelProperty
	{
		public string Id    => "FireResist15";
		public string Label => "Fire Resist +15";
		public int    Icon  => 0x9A8;

		static FireResist15() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s) s.FireBonus += 15;
		}
	}

	public sealed class BonusHits20 : IJewelProperty
	{
		public string Id    => "BonusHits20";
		public string Label => "+20 Hits";
		public int    Icon  => 0x9A8;

		static BonusHits20() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a) a.Attributes.BonusHits += 20;
		}
	}

	public sealed class CreatureArmor20 : IJewelProperty
	{
		public string Id    => "CreatureArmor20";
		public string Label => "+20 Armor";
		public int    Icon  => 0x9A8;

		static CreatureArmor20() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseCreature c) c.VirtualArmor += 20;
		}
	}

	public sealed class HitFireArea10 : IJewelProperty
	{
		public string Id    => "HitFireArea10";
		public string Label => "Hit Fire Area 10%";
		public int    Icon  => 0x9A8;

		static HitFireArea10() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w) w.WeaponAttributes.HitFireArea += 10;
		}
	}

	public sealed class FireResist6 : IJewelProperty
	{
		public string Id    => "FireResist6";
		public string Label => "Fire Resist +6";
		public int    Icon  => 0x9A8;

		static FireResist6() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s) s.FireBonus += 6;
		}
	}

	public sealed class BonusHits8 : IJewelProperty
	{
		public string Id    => "BonusHits8";
		public string Label => "+8 Hits";
		public int    Icon  => 0x9A8;

		static BonusHits8() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a) a.Attributes.BonusHits += 8;
		}
	}

	public sealed class CreatureArmor8 : IJewelProperty
	{
		public string Id    => "CreatureArmor8";
		public string Label => "+8 Armor";
		public int    Icon  => 0x9A8;

		static CreatureArmor8() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseCreature c) c.VirtualArmor += 8;
		}
	}

}