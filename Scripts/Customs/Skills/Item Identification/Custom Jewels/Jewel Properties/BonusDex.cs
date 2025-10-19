using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class BonusDex : IJewelProperty
    {
        public string Id    => "BonusDex";
        public string Label => "+5 Dexterity";
        public int    Icon  => 0x3DB;                      // small blue gem

        static BonusDex() => JewelPropertyRegistry.Get("");    // force static ctor

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)        a.Attributes.BonusDex += 5;
            else if (target is BaseCreature c) c.Dex += 5;
            // add more cases if you like
        }
    }

    public sealed class HitLightning : IJewelProperty
    {
        public string Id    => "HitLightning";
        public string Label => "Hit Lightning 15%";
        public int    Icon  => 0x3E8;                      // yellow gem

        static HitLightning() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w) w.WeaponAttributes.HitLightning += 15;
        }
    }
}
