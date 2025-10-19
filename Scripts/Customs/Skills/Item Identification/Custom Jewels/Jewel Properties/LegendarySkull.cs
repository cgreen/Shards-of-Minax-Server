using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class LegendarySkull : IJewelProperty
    {
        public string Id    => "LegendarySkull";
        public string Label => "Legendary Skull: +5 Leech Mana/Life, +3 Regen, +50 Hits";
        public int    Icon  => 0x2203;

        static LegendarySkull() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                a.Attributes.RegenHits += 3;
                a.Attributes.RegenMana += 3;
            }
            else if (target is BaseWeapon w)
            {
                w.WeaponAttributes.HitLeechHits += 5;
                w.WeaponAttributes.HitLeechMana += 5;
            }
            else if (target is BaseCreature c)
            {
                c.HitsMaxSeed += 50;
            }
        }
    }
}
