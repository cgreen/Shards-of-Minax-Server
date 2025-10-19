using System;
using System.Reflection;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using System.CustomizableVendor;
using Server.Multis.Deeds;
using Server.CustomPoisons;
using Server.CustomJewels;
using Server.CustomPies;

namespace Server.CustomVendors
{
    public class NewHavenReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public NewHavenReputationVendorStone()
        {
            Name = "NewHaven Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s NewHaven‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.NewHaven property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("NewHaven", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their NewHaven faction level.
            //
			// inside NewHavenReputationVendorStone()
			// NewHaven faction PowerScroll vendor stock

			AddStock<MaxxiaScroll>(
				price:       50,
				description: "A mysterious scroll inscribed with arcane runes. Its power is unknown until identified."
			);

			AddStock<CraftingBlueprint>(
				price:       100,
				description: "A mysterious blueprint inscribed with arcane runes. Its power is unknown until identified."
			);

			AddStock<CustomPie>(
				price:       10,
				description: "A fresh-baked pie ready to be flavored or decorated to order."
			);

			AddStock<CustomPoison>(
				price:       10,
				description: "A vial of toxin awaiting refinement or customization for special purposes."
			);

			AddStock<UnidentifiedArmor>(
				price:       400,
				description: "An unmarked piece of armor. Its origin and properties remain a mystery."
			);

			AddStock<UnidentifiedShield>(
				price:       350,
				description: "A shield with enigmatic markings. Its true nature is revealed only through expert appraisal."
			);

			AddStock<UnidentifiedJewelry>(
				price:       600,
				description: "A piece of jewelry whose enchantments and value are unknown until identified."
			);

			AddStock<UnidentifiedClothing>(
				price:       200,
				description: "A garment of uncertain origin. Identification may reveal hidden qualities."
			);

			AddStock<UnidentifiedWeapon>(
				price:       420,
				description: "A weapon with unclear craftsmanship and abilities. Needs identification to unveil its secrets."
			);

			AddStock<UnidentifiedPotion>(
				price:       150,
				description: "A potion of unknown effects. Only experimentation or identification can reveal its purpose."
			);

			AddStock<UnidentifiedCrystal>(
				price:       280,
				description: "A mysterious crystal, possibly magical. Its properties are unclear without identification."
			);

			AddStock<UnidentifiedCuriosity>(
				price:       230,
				description: "An unusual object of unknown significance. Perhaps valuable or powerful when identified."
			);

			AddStock<UnidentifiedMagicMap>(
				price:       350,
				description: "A magical map whose destination and secrets remain hidden until revealed."
			);

			AddStock<UnidentifiedOrb>(
				price:       380,
				description: "A cryptic orb radiating strange energies. Its true power is only discovered through identification."
			);

			AddStock<UnidentifiedDocument>(
				price:       190,
				description: "A document written in an unfamiliar script. Its contents are a mystery until deciphered."
			);

			AddStock<UnidentifiedTreasure>(
				price:       500,
				description: "A trove of valuables whose true nature and worth are not yet known."
			);

			AddStock<CustomJewel>(
				price:       250,
				description: "A crafted jewel awaiting personalization or enchantment."
			);


			// Blacksmith 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Blacksmith 100 Power Scroll",
				description: "A scroll that trains Blacksmith to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Blacksmith;
					ps.Value = 100;
				}
			);

			// Blacksmith 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Blacksmith 120 Power Scroll",
				description: "A scroll that trains Blacksmith to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Blacksmith;
					ps.Value = 120;
				}
			);

			// Alchemy 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Alchemy 100 Power Scroll",
				description: "A scroll that trains Alchemy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 100;
				}
			);

			// Alchemy 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Alchemy 120 Power Scroll",
				description: "A scroll that trains Alchemy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 120;
				}
			);

			// EvalInt 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "EvalInt 100 Power Scroll",
				description: "A scroll that trains Evaluating Intelligence to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.EvalInt;
					ps.Value = 100;
				}
			);

			// EvalInt 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "EvalInt 120 Power Scroll",
				description: "A scroll that trains Evaluating Intelligence to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.EvalInt;
					ps.Value = 120;
				}
			);

			// Swordsmanship 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Swordsmanship 100 Power Scroll",
				description: "A scroll that trains Swordsmanship to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Swords;
					ps.Value = 100;
				}
			);

			// Swordsmanship 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Swordsmanship 120 Power Scroll",
				description: "A scroll that trains Swordsmanship to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Swords;
					ps.Value = 120;
				}
			);

			// Tailoring 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Tailoring 100 Power Scroll",
				description: "A scroll that trains Tailoring to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tailoring;
					ps.Value = 100;
				}
			);

			// Tailoring 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Tailoring 120 Power Scroll",
				description: "A scroll that trains Tailoring to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tailoring;
					ps.Value = 120;
				}
			);
           
			AddStock<SmallBrickHouseDeed>(
				price:       2000,
				description: "A modest brick home for humble beginnings."
			);

			AddStock<WoodHouseDeed>(
				price:       2000,
				description: "A simple wooden dwelling, cozy and practical."
			);

			AddStock<WoodPlasterHouseDeed>(
				price:       2500,
				description: "A cottage of wood and plaster, perfect for new arrivals."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price:       3000,
				description: "A quaint cottage with a classic thatched roof."
			);

			AddStock<FieldStoneHouseDeed>(
				price:       3000,
				description: "A sturdy home built of field stone."
			);

			AddStock<PlainPlasterHouseDeed>(
				price:       3500,
				description: "A simple plastered house with ample living space."
			);

			AddStock<SmallWoodenShackPorchDeed>(
				price:       4000,
				description: "A small wooden shack with a welcoming porch."
			);

			AddStock<SmallLogCabinDeed>(
				price:       4000,
				description: "A rustic log cabin for peaceful living."
			);

			AddStock<SmallLogCabinWithDeckDeed>(
				price:       4250,
				description: "A compact log cabin with a deck for enjoying the view."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       4500,
				description: "A small stone shop, ideal for budding entrepreneurs."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       4500,
				description: "A simple stone storefront, perfect for trade."
			);

			AddStock<PlasterHomeDirtDeckDeed>(
				price:       4750,
				description: "A plaster house with a dirt-floored deck for country charm."
			);

			AddStock<PlasterHousePictureWindowDeed>(
				price:       5000,
				description: "A plaster home with a large window for natural light."
			);

			AddStock<OldStoneHomeShoppeDeed>(
				price:       5000,
				description: "An old stone home with a small shop attached."
			);

			AddStock<SmallStoneTempleDeed>(
				price:       5200,
				description: "A small temple of stone, a place of quiet worship."
			);

			AddStock<SmallTowerDeed>(
				price:       6000,
				description: "A compact tower, perfect for watchful adventurers."
			);

			AddStock<TwoStoryBrickHomeDeed>(
				price:       10000,
				description: "A two-story brick home with ample space for families."
			);

			AddStock<TwoStoryWoodPlasterHouseDeed>(
				price:       12000,
				description: "A spacious two-story home with wood and plaster."
			);

			AddStock<TwoStorySmallPlasterDwellingDeed>(
				price:       12000,
				description: "A modest two-story plaster dwelling for new citizens."
			);

			AddStock<TwoStorySmallStoneDwellingDeed>(
				price:       14000,
				description: "A two-story stone dwelling, both sturdy and comfortable."
			);

			AddStock<TwoStorySmallStoneHomeDeed>(
				price:       14000,
				description: "A two-story stone home for growing households."
			);

			AddStock<TwoStorySmallStoneHouseDeed>(
				price:       14500,
				description: "A durable two-story stone house."
			);

			AddStock<TwoStorySmallWoodenDwellingDeed>(
				price:       15000,
				description: "A two-story wooden dwelling for the ambitious."
			);

			AddStock<NeoTwoStoryBrickHouseDeed>(
				price:       18000,
				description: "A modern two-story brick house with updated comforts."
			);

			AddStock<NeoTwoStorySandstoneHouseDeed>(
				price:       18000,
				description: "A modern two-story house with sandstone exterior."
			);

			AddStock<NewTwoStoryBrickHouseDeed>(
				price:       20000,
				description: "A newly designed brick house spanning two stories."
			);

			AddStock<StonePlasterHouseDeed>(
				price:       25000,
				description: "A robust stone and plaster house with ample space."
			);

			AddStock<TowerDeed>(
				price:       35000,
				description: "A tall and sturdy stone tower."
			);

			AddStock<KeepDeed>(
				price:       120000,
				description: "A massive fortress keep, fit for a lord or lady."
			);

			AddStock<CastleDeed>(
				price:       250000,
				description: "A legendary castle of immense size and grandeur."
			);

        }

        /* ================================================================
         *  AddStock helper – ONE method does all the heavy lifting
         * ================================================================*/
        private void AddStock<T>(
            int      price,
            int      hue                 = -1,
            string   title               = null,
            string   description         = null,
            Action<T> configure          = null,
            int      restockEveryMinutes = 0,
            int      restockStart        = 20,
            int      restockCap          = -1
        ) where T : Item, new()
        {
            /* build (or receive) the item */
            var item = new T();
            if (hue >= 0)              item.Hue = hue;
            if (!string.IsNullOrEmpty(title))
                                        item.Name = title;
            configure?.Invoke(item);   // let caller tweak props

            /* wrap in Reward */
            var reward = new Reward(
                item,
                price,
                title ?? item.Name ?? typeof(T).Name,
                description ?? string.Empty
            );

            if (restockEveryMinutes > 0)
            {
                reward.Restock = (restockCap > 0)
                    ? new Reward.RestockInfo(0, restockEveryMinutes, restockStart, 1, restockCap)
                    : new Reward.RestockInfo(0, restockEveryMinutes, restockStart, 1);
            }

            /* push into vendor via the interface */
            ((IRewardVendor)this).AddReward(reward);
        }

        // Boilerplate serialization
        public NewHavenReputationVendorStone(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
