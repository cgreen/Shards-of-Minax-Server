using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.CustomJewels.Properties
{
    public sealed class BonusAlchemy : IJewelProperty
    {
        public string Id    => "BonusAlchemy";
        public string Label => "+5 Alchemy";
        public int    Icon  => 0x3DB; // small blue gem

        static BonusAlchemy() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Alchemy, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Alchemy, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusAnatomy : IJewelProperty
    {
        public string Id    => "BonusAnatomy";
        public string Label => "+5 Anatomy";
        public int    Icon  => 0x3DB;

        static BonusAnatomy() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Anatomy, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Anatomy, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusAnimalLore : IJewelProperty
    {
        public string Id    => "BonusAnimalLore";
        public string Label => "+5 AnimalLore";
        public int    Icon  => 0x3DB;

        static BonusAnimalLore() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.AnimalLore, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.AnimalLore, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusAnimalTaming : IJewelProperty
    {
        public string Id    => "BonusAnimalTaming";
        public string Label => "+5 AnimalTaming";
        public int    Icon  => 0x3DB;

        static BonusAnimalTaming() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.AnimalTaming, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.AnimalTaming, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusArchery : IJewelProperty
    {
        public string Id    => "BonusArchery";
        public string Label => "+5 Archery";
        public int    Icon  => 0x3DB;

        static BonusArchery() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Archery, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Archery, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusArmsLore : IJewelProperty
    {
        public string Id    => "BonusArmsLore";
        public string Label => "+5 ArmsLore";
        public int    Icon  => 0x3DB;

        static BonusArmsLore() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.ArmsLore, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.ArmsLore, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusBegging : IJewelProperty
    {
        public string Id    => "BonusBegging";
        public string Label => "+5 Begging";
        public int    Icon  => 0x3DB;

        static BonusBegging() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Begging, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Begging, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusBlacksmith : IJewelProperty
    {
        public string Id    => "BonusBlacksmith";
        public string Label => "+5 Blacksmith";
        public int    Icon  => 0x3DB;

        static BonusBlacksmith() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Blacksmith, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Blacksmith, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusBushido : IJewelProperty
    {
        public string Id    => "BonusBushido";
        public string Label => "+5 Bushido";
        public int    Icon  => 0x3DB;

        static BonusBushido() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Bushido, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Bushido, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusCamping : IJewelProperty
    {
        public string Id    => "BonusCamping";
        public string Label => "+5 Camping";
        public int    Icon  => 0x3DB;

        static BonusCamping() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Camping, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Camping, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusCarpentry : IJewelProperty
    {
        public string Id    => "BonusCarpentry";
        public string Label => "+5 Carpentry";
        public int    Icon  => 0x3DB;

        static BonusCarpentry() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Carpentry, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Carpentry, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusCartography : IJewelProperty
    {
        public string Id    => "BonusCartography";
        public string Label => "+5 Cartography";
        public int    Icon  => 0x3DB;

        static BonusCartography() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Cartography, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Cartography, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusChivalry : IJewelProperty
    {
        public string Id    => "BonusChivalry";
        public string Label => "+5 Chivalry";
        public int    Icon  => 0x3DB;

        static BonusChivalry() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Chivalry, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Chivalry, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusCooking : IJewelProperty
    {
        public string Id    => "BonusCooking";
        public string Label => "+5 Cooking";
        public int    Icon  => 0x3DB;

        static BonusCooking() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Cooking, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Cooking, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusDetectHidden : IJewelProperty
    {
        public string Id    => "BonusDetectHidden";
        public string Label => "+5 DetectHidden";
        public int    Icon  => 0x3DB;

        static BonusDetectHidden() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.DetectHidden, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.DetectHidden, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusDiscordance : IJewelProperty
    {
        public string Id    => "BonusDiscordance";
        public string Label => "+5 Discordance";
        public int    Icon  => 0x3DB;

        static BonusDiscordance() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Discordance, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Discordance, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusEvalInt : IJewelProperty
    {
        public string Id    => "BonusEvalInt";
        public string Label => "+5 EvalInt";
        public int    Icon  => 0x3DB;

        static BonusEvalInt() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.EvalInt, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.EvalInt, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusFencing : IJewelProperty
    {
        public string Id    => "BonusFencing";
        public string Label => "+5 Fencing";
        public int    Icon  => 0x3DB;

        static BonusFencing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Fencing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Fencing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusFishing : IJewelProperty
    {
        public string Id    => "BonusFishing";
        public string Label => "+5 Fishing";
        public int    Icon  => 0x3DB;

        static BonusFishing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Fishing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Fishing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusFletching : IJewelProperty
    {
        public string Id    => "BonusFletching";
        public string Label => "+5 Fletching";
        public int    Icon  => 0x3DB;

        static BonusFletching() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Fletching, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Fletching, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusFocus : IJewelProperty
    {
        public string Id    => "BonusFocus";
        public string Label => "+5 Focus";
        public int    Icon  => 0x3DB;

        static BonusFocus() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Focus, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Focus, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusForensics : IJewelProperty
    {
        public string Id    => "BonusForensics";
        public string Label => "+5 Forensics";
        public int    Icon  => 0x3DB;

        static BonusForensics() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Forensics, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Forensics, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusHealing : IJewelProperty
    {
        public string Id    => "BonusHealing";
        public string Label => "+5 Healing";
        public int    Icon  => 0x3DB;

        static BonusHealing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Healing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Healing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusHerding : IJewelProperty
    {
        public string Id    => "BonusHerding";
        public string Label => "+5 Herding";
        public int    Icon  => 0x3DB;

        static BonusHerding() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Herding, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Herding, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusHiding : IJewelProperty
    {
        public string Id    => "BonusHiding";
        public string Label => "+5 Hiding";
        public int    Icon  => 0x3DB;

        static BonusHiding() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Hiding, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Hiding, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusImbuing : IJewelProperty
    {
        public string Id    => "BonusImbuing";
        public string Label => "+5 Imbuing";
        public int    Icon  => 0x3DB;

        static BonusImbuing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Imbuing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Imbuing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusInscribe : IJewelProperty
    {
        public string Id    => "BonusInscribe";
        public string Label => "+5 Inscribe";
        public int    Icon  => 0x3DB;

        static BonusInscribe() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Inscribe, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Inscribe, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusItemID : IJewelProperty
    {
        public string Id    => "BonusItemID";
        public string Label => "+5 ItemID";
        public int    Icon  => 0x3DB;

        static BonusItemID() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.ItemID, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.ItemID, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusLockpicking : IJewelProperty
    {
        public string Id    => "BonusLockpicking";
        public string Label => "+5 Lockpicking";
        public int    Icon  => 0x3DB;

        static BonusLockpicking() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Lockpicking, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Lockpicking, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusLumberjacking : IJewelProperty
    {
        public string Id    => "BonusLumberjacking";
        public string Label => "+5 Lumberjacking";
        public int    Icon  => 0x3DB;

        static BonusLumberjacking() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Lumberjacking, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Lumberjacking, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMacing : IJewelProperty
    {
        public string Id    => "BonusMacing";
        public string Label => "+5 Macing";
        public int    Icon  => 0x3DB;

        static BonusMacing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Macing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Macing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMagicResist : IJewelProperty
    {
        public string Id    => "BonusMagicResist";
        public string Label => "+5 MagicResist";
        public int    Icon  => 0x3DB;

        static BonusMagicResist() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.MagicResist, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.MagicResist, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMeditation : IJewelProperty
    {
        public string Id    => "BonusMeditation";
        public string Label => "+5 Meditation";
        public int    Icon  => 0x3DB;

        static BonusMeditation() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Meditation, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Meditation, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMining : IJewelProperty
    {
        public string Id    => "BonusMining";
        public string Label => "+5 Mining";
        public int    Icon  => 0x3DB;

        static BonusMining() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Mining, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Mining, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMusicianship : IJewelProperty
    {
        public string Id    => "BonusMusicianship";
        public string Label => "+5 Musicianship";
        public int    Icon  => 0x3DB;

        static BonusMusicianship() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Musicianship, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Musicianship, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusMysticism : IJewelProperty
    {
        public string Id    => "BonusMysticism";
        public string Label => "+5 Mysticism";
        public int    Icon  => 0x3DB;

        static BonusMysticism() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Mysticism, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Mysticism, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusNecromancy : IJewelProperty
    {
        public string Id    => "BonusNecromancy";
        public string Label => "+5 Necromancy";
        public int    Icon  => 0x3DB;

        static BonusNecromancy() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Necromancy, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Necromancy, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusNinjitsu : IJewelProperty
    {
        public string Id    => "BonusNinjitsu";
        public string Label => "+5 Ninjitsu";
        public int    Icon  => 0x3DB;

        static BonusNinjitsu() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Ninjitsu, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Ninjitsu, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusParry : IJewelProperty
    {
        public string Id    => "BonusParry";
        public string Label => "+5 Parry";
        public int    Icon  => 0x3DB;

        static BonusParry() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Parry, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Parry, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusPeacemaking : IJewelProperty
    {
        public string Id    => "BonusPeacemaking";
        public string Label => "+5 Peacemaking";
        public int    Icon  => 0x3DB;

        static BonusPeacemaking() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Peacemaking, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Peacemaking, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusPoisoning : IJewelProperty
    {
        public string Id    => "BonusPoisoning";
        public string Label => "+5 Poisoning";
        public int    Icon  => 0x3DB;

        static BonusPoisoning() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Poisoning, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Poisoning, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusProvocation : IJewelProperty
    {
        public string Id    => "BonusProvocation";
        public string Label => "+5 Provocation";
        public int    Icon  => 0x3DB;

        static BonusProvocation() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Provocation, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Provocation, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusRemoveTrap : IJewelProperty
    {
        public string Id    => "BonusRemoveTrap";
        public string Label => "+5 RemoveTrap";
        public int    Icon  => 0x3DB;

        static BonusRemoveTrap() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.RemoveTrap, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.RemoveTrap, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusSnooping : IJewelProperty
    {
        public string Id    => "BonusSnooping";
        public string Label => "+5 Snooping";
        public int    Icon  => 0x3DB;

        static BonusSnooping() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Snooping, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Snooping, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusSpellweaving : IJewelProperty
    {
        public string Id    => "BonusSpellweaving";
        public string Label => "+5 Spellweaving";
        public int    Icon  => 0x3DB;

        static BonusSpellweaving() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Spellweaving, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Spellweaving, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusSpiritSpeak : IJewelProperty
    {
        public string Id    => "BonusSpiritSpeak";
        public string Label => "+5 SpiritSpeak";
        public int    Icon  => 0x3DB;

        static BonusSpiritSpeak() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.SpiritSpeak, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.SpiritSpeak, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusStealing : IJewelProperty
    {
        public string Id    => "BonusStealing";
        public string Label => "+5 Stealing";
        public int    Icon  => 0x3DB;

        static BonusStealing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Stealing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Stealing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusStealth : IJewelProperty
    {
        public string Id    => "BonusStealth";
        public string Label => "+5 Stealth";
        public int    Icon  => 0x3DB;

        static BonusStealth() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Stealth, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Stealth, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusSwords : IJewelProperty
    {
        public string Id    => "BonusSwords";
        public string Label => "+5 Swords";
        public int    Icon  => 0x3DB;

        static BonusSwords() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Swords, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Swords, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusTactics : IJewelProperty
    {
        public string Id    => "BonusTactics";
        public string Label => "+5 Tactics";
        public int    Icon  => 0x3DB;

        static BonusTactics() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Tactics, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Tactics, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusTailoring : IJewelProperty
    {
        public string Id    => "BonusTailoring";
        public string Label => "+5 Tailoring";
        public int    Icon  => 0x3DB;

        static BonusTailoring() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Tailoring, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Tailoring, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusTasteID : IJewelProperty
    {
        public string Id    => "BonusTasteID";
        public string Label => "+5 TasteID";
        public int    Icon  => 0x3DB;

        static BonusTasteID() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.TasteID, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.TasteID, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusThrowing : IJewelProperty
    {
        public string Id    => "BonusThrowing";
        public string Label => "+5 Throwing";
        public int    Icon  => 0x3DB;

        static BonusThrowing() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Throwing, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Throwing, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusTinkering : IJewelProperty
    {
        public string Id    => "BonusTinkering";
        public string Label => "+5 Tinkering";
        public int    Icon  => 0x3DB;

        static BonusTinkering() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Tinkering, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Tinkering, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusTracking : IJewelProperty
    {
        public string Id    => "BonusTracking";
        public string Label => "+5 Tracking";
        public int    Icon  => 0x3DB;

        static BonusTracking() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Tracking, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Tracking, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusVeterinary : IJewelProperty
    {
        public string Id    => "BonusVeterinary";
        public string Label => "+5 Veterinary";
        public int    Icon  => 0x3DB;

        static BonusVeterinary() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Veterinary, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Veterinary, 5.0);
                        break;
                    }
            }
        }
    }

    public sealed class BonusWrestling : IJewelProperty
    {
        public string Id    => "BonusWrestling";
        public string Label => "+5 Wrestling";
        public int    Icon  => 0x3DB;

        static BonusWrestling() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseArmor a)
            {
                for (int i = 0; i < 5; i++)
                    if (a.SkillBonuses.GetBonus(i) == 0)
                    {
                        a.SkillBonuses.SetValues(i, SkillName.Wrestling, 5.0);
                        break;
                    }
            }
            else if (target is BaseJewel j)
            {
                for (int i = 0; i < 5; i++)
                    if (j.SkillBonuses.GetBonus(i) == 0)
                    {
                        j.SkillBonuses.SetValues(i, SkillName.Wrestling, 5.0);
                        break;
                    }
            }
        }
    }
}
