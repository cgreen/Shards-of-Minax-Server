using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    // +40 Hit Poison Area (Weapon only)
    public sealed class MythicEmeraldHitPoisonArea : IJewelProperty
    {
        public string Id    => "MythicEmeraldHitPoisonArea";
        public string Label => "Hit Poison Area +40%";
        public int    Icon  => 0x9A8;

        static MythicEmeraldHitPoisonArea() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.WeaponAttributes.HitPoisonArea += 40;
        }
    }

    // +25 Poison Resist (Shield only)
    public sealed class MythicEmeraldPoisonResist : IJewelProperty
    {
        public string Id    => "MythicEmeraldPoisonResist";
        public string Label => "Poison Resist +25";
        public int    Icon  => 0x9A8;

        static MythicEmeraldPoisonResist() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseShield s)
                s.PoisonBonus += 25;
        }
    }

    // +25 Dex (Armor only)
    public sealed class MythicEmeraldBonusDex : IJewelProperty
    {
        public string Id    => "MythicEmeraldBonusDex";
        public string Label => "+25 Dexterity";
        public int    Icon  => 0x9A8;

        static MythicEmeraldBonusDex() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
                a.Attributes.BonusDex += 25;
        }
    }

    // +32 Dex (Creature only)
    public sealed class MythicEmeraldCreatureDex : IJewelProperty
    {
        public string Id    => "MythicEmeraldCreatureDex";
        public string Label => "+32 Dexterity (Creature)";
        public int    Icon  => 0x9A8;

        static MythicEmeraldCreatureDex() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseCreature c)
                c.RawDex += 32;
        }
    }
}
