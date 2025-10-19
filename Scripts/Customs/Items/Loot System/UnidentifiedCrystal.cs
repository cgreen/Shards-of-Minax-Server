using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName

namespace Server.Items
{
    public class UnidentifiedCrystal : BaseUnidentifiedItem
    {
        // ———— CRYSTAL TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(AlchemyAugmentCrystal),
            typeof(AnatomyAugmentCrystal),
            typeof(AnimalLoreAugmentCrystal),
            typeof(AnimalTamingAugmentCrystal),
            typeof(ArcheryAugmentCrystal),
            typeof(ArmsLoreAugmentCrystal),
            typeof(BeggingAugmentCrystal),
            typeof(BlacksmithyAugmentCrystal),
            typeof(BushidoAugmentCrystal),
            typeof(CampingAugmentCrystal),
            typeof(CarpentryAugmentCrystal),
            typeof(CartographyAugmentCrystal),
            typeof(ChivalryAugmentCrystal),
            typeof(ColdHitAreaCrystal),
            typeof(ColdResistAugmentCrystal),
            typeof(CookingAugmentCrystal),
            typeof(CurseAugmentCrystal),
            typeof(DetectingHiddenAugmentCrystal),
            typeof(DiscordanceAugmentCrystal),
            typeof(DispelAugmentCrystal),
            typeof(EnergyHitAreaCrystal)			
        };
        private static readonly Type[] Tier2Potions = {
            typeof(EnergyResistAugmentCrystal),
            typeof(FatigueAugmentCrystal),
            typeof(FencingAugmentCrystal),
            typeof(FireballAugmentCrystal),
            typeof(FireHitAreaCrystal),
            typeof(FireResistAugmentCrystal),
            typeof(FishingAugmentCrystal),
            typeof(FletchingAugmentCrystal),
            typeof(FocusAugmentCrystal),
            typeof(ForensicEvaluationAugmentCrystal),
            typeof(HarmAugmentCrystal),
            typeof(HealingAugmentCrystal),
            typeof(HerdingAugmentCrystal),
            typeof(HidingAugmentCrystal),
            typeof(ImbuingAugmentCrystal),
            typeof(InscriptionAugmentCrystal),
            typeof(ItemIdentificationAugmentCrystal),
            typeof(LifeLeechAugmentCrystal),
            typeof(LightningAugmentCrystal),
            typeof(LockpickingAugmentCrystal)			
        };
        private static readonly Type[] Tier3Potions = {
            typeof(LowerAttackAugmentCrystal),
            typeof(LuckAugmentCrystal),
            typeof(LumberjackingAugmentCrystal),
            typeof(MaceFightingAugmentCrystal)			
        };
        private static readonly Type[] Tier4Potions = {
            typeof(MageryAugmentCrystal),
            typeof(ManaDrainAugmentCrystal),
            typeof(ManaLeechAugmentCrystal),
            typeof(MeditationAugmentCrystal)
        };
        private static readonly Type[] Tier5Potions = {
            typeof(MiningAugmentCrystal),
            typeof(MusicianshipAugmentCrystal),
            typeof(NecromancyAugmentCrystal),
            typeof(NinjitsuAugmentCrystal)
        };
        private static readonly Type[] Tier6Potions = {
            typeof(ParryingAugmentCrystal),
            typeof(PeacemakingAugmentCrystal),
            typeof(PhysicalHitAreaCrystal),
            typeof(PhysicalResistAugmentCrystal),
            typeof(PoisonHitAreaCrystal)
        };
        private static readonly Type[] Tier7Potions = {
            typeof(PoisoningAugmentCrystal),
            typeof(PoisonResistAugmentCrystal),
            typeof(ProvocationAugmentCrystal),
            typeof(RemoveTrapAugmentCrystal),
            typeof(ResistingSpellsAugmentCrystal)
        };
        private static readonly Type[] Tier8Potions = {
            typeof(SnoopingAugmentCrystal),
            typeof(SpellweavingAugmentCrystal),
            typeof(SpiritSpeakAugmentCrystal),
            typeof(StaminaLeechAugmentCrystal),
            typeof(StealingAugmentCrystal)
        };
        private static readonly Type[] Tier9Potions = {
            typeof(StealthAugmentCrystal),
            typeof(SwingSpeedAugmentCrystal),
            typeof(SwordsmanshipAugmentCrystal),
            typeof(TacticsAugmentCrystal),
            typeof(TailoringAugmentCrystal)
        };
        private static readonly Type[] Tier10Potions = {
            typeof(TasteIDAugmentCrystal),
            typeof(ThrowingAugmentCrystal),
            typeof(TinkeringAugmentCrystal),
            typeof(TrackingAugmentCrystal),
            typeof(VeterinaryAugmentCrystal),
            typeof(WeaponSpeedAugmentCrystal),
            typeof(WrestlingAugmentCrystal)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedCrystal() : base(0x1F1D) // bottle ID
        {
            Name = "Unidentified Crystal";
        }

        [Constructable]
        public UnidentifiedCrystal(int quality) : base(0x1F1D, quality)
        {
            Name = "Unidentified Crystal";
        }

        public UnidentifiedCrystal(Serial serial) : base(serial) { }

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
