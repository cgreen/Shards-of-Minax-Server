using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName

namespace Server.Items
{
    public class UnidentifiedPotion : BaseUnidentifiedItem
    {
        // ———— POTION TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(LesserHealPotion),
            typeof(LesserCurePotion)
        };
        private static readonly Type[] Tier2Potions = {
            typeof(HealPotion),
            typeof(CurePotion)
        };
        private static readonly Type[] Tier3Potions = {
            typeof(GreaterHealPotion),
            typeof(GreaterCurePotion)
        };
        private static readonly Type[] Tier4Potions = {
            typeof(AgilityPotion),
            typeof(StrengthPotion)
        };
        private static readonly Type[] Tier5Potions = {
            typeof(RefreshPotion),
            typeof(GreaterAgilityPotion)
        };
        private static readonly Type[] Tier6Potions = {
            typeof(LesserPoisonPotion),
            typeof(LesserExplosionPotion)   // replace with your own
        };
        private static readonly Type[] Tier7Potions = {
            typeof(GreaterPoisonPotion),
            typeof(ExplosionPotion)
        };
        private static readonly Type[] Tier8Potions = {
            typeof(DeadlyPoisonPotion),
            typeof(InvisibilityPotion)
        };
        private static readonly Type[] Tier9Potions = {
            typeof(TotalRefreshPotion),
            typeof(GreaterCurePotion)
        };
        private static readonly Type[] Tier10Potions = {
            typeof(ElixirOfRebirth),
            typeof(GreaterStrengthPotion)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedPotion() : base(0x0F0C) // bottle ID
        {
            Name = "Unidentified Potion";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedPotion(int quality) : base(0x0F0C, quality)
        {
            Name = "Unidentified Potion";
			Hue = 2274;
        }

        public UnidentifiedPotion(Serial serial) : base(serial) { }

        // ———— IDENTIFY METHOD ————
        public override void Identify(Mobile from)
        {
            // 1) Roll tier
            int skillBonus = (int)(from.Skills[SkillName.ItemID].Base / 10);
            int roll       = Utility.RandomMinMax(1, 100) + Quality + skillBonus;
            int tier;

            if      (roll >= 100) tier = 10;
            else if (roll >= 98)  tier =  9;
            else if (roll >= 95)  tier =  8;
            else if (roll >= 90)  tier =  7;
            else if (roll >= 82)  tier =  6;
            else if (roll >= 71)  tier =  5;
            else if (roll >= 58)  tier =  4;
            else if (roll >= 42)  tier =  3;
            else if (roll >= 22)  tier =  2;
            else                  tier =  1;

            // 2) Pick a potion for that tier
            Item newPotion = CreateFromTier(tier);

            // 3) Place it in the world or container
            if (Parent is Container c)
                c.AddItem(newPotion);
            else
                newPotion.MoveToWorld(Location, Map);

            // 4) Notify & delete
            from.SendMessage(
                $"You identify the potion (Quality {Quality}) – it becomes “{newPotion.Name}” (Tier {tier})."
            );
            Delete();
        }

        // ———— HELPER TO SELECT POTION BY TIER ————
        private static Item CreateFromTier(int tier)
        {
            Type[] list;

            switch (tier)
            {
                case  1: list = Tier1Potions;  break;
                case  2: list = Tier2Potions;  break;
                case  3: list = Tier3Potions;  break;
                case  4: list = Tier4Potions;  break;
                case  5: list = Tier5Potions;  break;
                case  6: list = Tier6Potions;  break;
                case  7: list = Tier7Potions;  break;
                case  8: list = Tier8Potions;  break;
                case  9: list = Tier9Potions;  break;
                case 10: list = Tier10Potions; break;
                default: list = Tier1Potions;  break;
            }

            if (list == null || list.Length == 0)
                return new LesserHealPotion(); // fallback

            var t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        // ———— SERIALIZE / DESERIALIZE ————
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
