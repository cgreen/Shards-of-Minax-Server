using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{

	public sealed class HitColdArea40 : IJewelProperty
	{
		public string Id    => "HitColdArea40";
		public string Label => "Hit Cold Area 40%";
		public int    Icon  => 0x9a8; // Sapphire

		static HitColdArea40() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w)
				w.WeaponAttributes.HitColdArea += 40;
		}
	}

	public sealed class ColdResist25 : IJewelProperty
	{
		public string Id    => "ColdResist25";
		public string Label => "Cold Resist +25";
		public int    Icon  => 0x9a8; // Sapphire

		static ColdResist25() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s)
				s.ColdBonus += 25;
		}
	}

	public sealed class BonusInt15 : IJewelProperty
	{
		public string Id    => "BonusInt15";
		public string Label => "+15 Intelligence";
		public int    Icon  => 0x9a8; // Sapphire

		static BonusInt15() => JewelPropertyRegistry.Get("");

		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a)
				a.Attributes.BonusInt += 15;
			else if (target is BaseCreature c)
				c.RawInt += 32;
		}
	}

	public sealed class HitColdArea25 : IJewelProperty
	{
		public string Id    => "HitColdArea25";
		public string Label => "Hit Cold Area 25%";
		public int    Icon  => 0x9a8;
		static HitColdArea25() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w)
				w.WeaponAttributes.HitColdArea += 25;
		}
	}

	public sealed class ColdResist15 : IJewelProperty
	{
		public string Id    => "ColdResist15";
		public string Label => "Cold Resist +15";
		public int    Icon  => 0x9a8;
		static ColdResist15() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s)
				s.ColdBonus += 15;
		}
	}

	public sealed class BonusInt8 : IJewelProperty
	{
		public string Id    => "BonusInt8";
		public string Label => "+8 Intelligence";
		public int    Icon  => 0x9a8;
		static BonusInt8() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a)
				a.Attributes.BonusInt += 8;
			else if (target is BaseCreature c)
				c.RawInt += 20;
		}
	}

	public sealed class HitColdArea10 : IJewelProperty
	{
		public string Id    => "HitColdArea10";
		public string Label => "Hit Cold Area 10%";
		public int    Icon  => 0x9a8;
		static HitColdArea10() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseWeapon w)
				w.WeaponAttributes.HitColdArea += 10;
		}
	}

	public sealed class ColdResist6 : IJewelProperty
	{
		public string Id    => "ColdResist6";
		public string Label => "Cold Resist +6";
		public int    Icon  => 0x9a8;
		static ColdResist6() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseShield s)
				s.ColdBonus += 6;
		}
	}

	public sealed class BonusInt3 : IJewelProperty
	{
		public string Id    => "BonusInt3";
		public string Label => "+3 Intelligence";
		public int    Icon  => 0x9a8;
		static BonusInt3() => JewelPropertyRegistry.Get("");
		public void Apply(Mobile crafter, object target)
		{
			if (target is BaseArmor a)
				a.Attributes.BonusInt += 3;
			else if (target is BaseCreature c)
				c.RawInt += 3;
		}
	}

}