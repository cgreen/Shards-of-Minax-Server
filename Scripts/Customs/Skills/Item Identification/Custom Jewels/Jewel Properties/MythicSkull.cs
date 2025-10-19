using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class MythicSkull : IJewelProperty
    {
        public string Id    => "MythicSkull";
        public string Label => "Mythic Skull: +9 Leech Mana/Life, +5 Regen, +85 Hits";
        public int    Icon  => 0x2203; // Use the skull icon

        static MythicSkull() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                a.Attributes.RegenHits += 5;
                a.Attributes.RegenMana += 5;
            }
            else if (target is BaseWeapon w)
            {
                w.WeaponAttributes.HitLeechHits += 9;
                w.WeaponAttributes.HitLeechMana += 9;
            }
            else if (target is BaseCreature c)
            {
                c.HitsMaxSeed += 85;
            }
        }
    }
}
