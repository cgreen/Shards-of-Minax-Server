using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class Lumberjacking40 : IJewelProperty
    {
        public string Id    => "Lumberjacking40";
        public string Label => "+40 Lumberjacking";
        public int    Icon  => 0x1bdd; // Mythic wood icon

        static Lumberjacking40() => JewelPropertyRegistry.Get(""); // force static ctor

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                // Find a free slot
                for (int i = 0; i < 5; i++)
                {
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Lumberjacking, 40.0);
                        break;
                    }
                }
            }
        }
    }

    public sealed class Lumberjacking25 : IJewelProperty
    {
        public string Id    => "Lumberjacking25";
        public string Label => "+25 Lumberjacking";
        public int    Icon  => 0x1bdd; // Legendary wood icon (same, but you can change if desired)

        static Lumberjacking25() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Lumberjacking, 25.0);
                        break;
                    }
                }
            }
        }
    }

    public sealed class Lumberjacking10 : IJewelProperty
    {
        public string Id    => "Lumberjacking10";
        public string Label => "+10 Lumberjacking";
        public int    Icon  => 0x1bdd; // Ancient wood icon (same, but can change if desired)

        static Lumberjacking10() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Lumberjacking, 10.0);
                        break;
                    }
                }
            }
        }
    }
}
