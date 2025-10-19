using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class AncientSkull : IJewelProperty
    {
        public string Id    => "AncientSkull";
        public string Label => "Ancient Skull: +2 Leech Mana/Life, +1 Regen, +20 Hits";
        public int    Icon  => 0x2203;

        static AncientSkull() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                a.Attributes.RegenHits += 1;
                a.Attributes.RegenMana += 1;
            }
            else if (target is BaseWeapon w)
            {
                w.WeaponAttributes.HitLeechHits += 2;
                w.WeaponAttributes.HitLeechMana += 2;
            }
            else if (target is BaseCreature c)
            {
                c.HitsMaxSeed += 20;
            }
        }
    }
}
