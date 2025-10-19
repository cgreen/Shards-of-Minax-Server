using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    // --------------------------------------------------
    // Mythic Tourmaline Property
    // --------------------------------------------------
    public sealed class MythicTourmalineProperty : IJewelProperty
    {
        public string Id    => "MythicTourmaline";
        public string Label => "Mythic Tourmaline: +25 Weapon Speed, +15 Reflect, +5 All Resists";
        public int    Icon  => 0x9a8;

        static MythicTourmalineProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponSpeed += 25;
            else if (target is BaseArmor a)
                a.Attributes.ReflectPhysical += 15;
            else if (target is BaseCreature c)
            {
                c.PhysicalResistanceSeed += 5;
                c.FireResistSeed += 5;
                c.ColdResistSeed += 5;
                c.PoisonResistSeed += 5;
                c.EnergyResistSeed += 5;
            }
        }
    }

    // --------------------------------------------------
    // Legendary Tourmaline Property
    // --------------------------------------------------
    public sealed class LegendaryTourmalineProperty : IJewelProperty
    {
        public string Id    => "LegendaryTourmaline";
        public string Label => "Legendary Tourmaline: +15 Weapon Speed, +8 Reflect, +3 All Resists";
        public int    Icon  => 0x9a8;

        static LegendaryTourmalineProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponSpeed += 15;
            else if (target is BaseArmor a)
                a.Attributes.ReflectPhysical += 8;
            else if (target is BaseCreature c)
            {
                c.PhysicalResistanceSeed += 3;
                c.FireResistSeed += 3;
                c.ColdResistSeed += 3;
                c.PoisonResistSeed += 3;
                c.EnergyResistSeed += 3;
            }
        }
    }

    // --------------------------------------------------
    // Ancient Tourmaline Property
    // --------------------------------------------------
    public sealed class AncientTourmalineProperty : IJewelProperty
    {
        public string Id    => "AncientTourmaline";
        public string Label => "Ancient Tourmaline: +5 Weapon Speed, +3 Reflect, +1 All Resists";
        public int    Icon  => 0x9a8;

        static AncientTourmalineProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon w)
                w.Attributes.WeaponSpeed += 5;
            else if (target is BaseArmor a)
                a.Attributes.ReflectPhysical += 3;
            else if (target is BaseCreature c)
            {
                c.PhysicalResistanceSeed += 1;
                c.FireResistSeed += 1;
                c.ColdResistSeed += 1;
                c.PoisonResistSeed += 1;
                c.EnergyResistSeed += 1;
            }
        }
    }
}
