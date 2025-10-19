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
    public class MinocReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public MinocReputationVendorStone()
        {
            Name = "Minoc Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Minoc‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Minoc property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Minoc", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Minoc faction level.
            //
			// inside MinocReputationVendorStone()
			// Minoc Power Scrolls - Level 100 and 120 with pricing difference

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


			// Carpentry 100
			AddStock<PowerScroll>(
				price:       150,  // faction points cost
				title:       "Carpentry 100 Power Scroll",
				description: "A scroll that trains Carpentry to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Carpentry;
					ps.Value = 100;
				}
			);

			// Carpentry 120
			AddStock<PowerScroll>(
				price:       400,  // much higher cost
				title:       "Carpentry 120 Power Scroll",
				description: "A scroll that trains Carpentry to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Carpentry;
					ps.Value = 120;
				}
			);

			// Tailoring 100
			AddStock<PowerScroll>(
				price:       150,
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
				price:       400,
				title:       "Tailoring 120 Power Scroll",
				description: "A scroll that trains Tailoring to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tailoring;
					ps.Value = 120;
				}
			);

			// Lumberjacking 100
			AddStock<PowerScroll>(
				price:       150,
				title:       "Lumberjacking 100 Power Scroll",
				description: "A scroll that trains Lumberjacking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Lumberjacking;
					ps.Value = 100;
				}
			);

			// Lumberjacking 120
			AddStock<PowerScroll>(
				price:       400,
				title:       "Lumberjacking 120 Power Scroll",
				description: "A scroll that trains Lumberjacking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Lumberjacking;
					ps.Value = 120;
				}
			);

			// Mining 100
			AddStock<PowerScroll>(
				price:       150,
				title:       "Mining 100 Power Scroll",
				description: "A scroll that trains Mining to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 100;
				}
			);

			// Mining 120
			AddStock<PowerScroll>(
				price:       400,
				title:       "Mining 120 Power Scroll",
				description: "A scroll that trains Mining to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 120;
				}
			);

			// Blacksmith 100
			AddStock<PowerScroll>(
				price:       150,
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
				price:       400,
				title:       "Blacksmith 120 Power Scroll",
				description: "A scroll that trains Blacksmith to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Blacksmith;
					ps.Value = 120;
				}
			);

			// ArmsLore 100
			AddStock<PowerScroll>(
				price:       150,
				title:       "ArmsLore 100 Power Scroll",
				description: "A scroll that trains ArmsLore to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.ArmsLore;
					ps.Value = 100;
				}
			);

			// ArmsLore 120
			AddStock<PowerScroll>(
				price:       400,
				title:       "ArmsLore 120 Power Scroll",
				description: "A scroll that trains ArmsLore to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.ArmsLore;
					ps.Value = 120;
				}
			);
         
			AddStock<LogCabinDeed>(
				price:       5000,
				description: "A sturdy log cabin, a testament to Minoc’s tradition of woodcraft."
			);

			AddStock<SmallLogCabinDeed>(
				price:       3500,
				description: "A compact log cabin, perfect for humble beginnings."
			);

			AddStock<SmallLogCabinWithDeckDeed>(
				price:       4000,
				description: "A small log cabin with a wooden deck for enjoying the outdoors."
			);

			AddStock<FancyWoodenStoneHouseDeed>(
				price:       6500,
				description: "A craftsman’s dream: elegant stonework with warm wooden accents."
			);

			AddStock<SmallBrickHouseDeed>(
				price:       3500,
				description: "A classic small brick house, built to last."
			);

			AddStock<WoodHouseDeed>(
				price:       3000,
				description: "A simple wooden house, reflecting Minoc’s rustic roots."
			);

			AddStock<WoodPlasterHouseDeed>(
				price:       3500,
				description: "A wooden house with a touch of plaster for charm and strength."
			);

			AddStock<SmallWoodenShackPorchDeed>(
				price:       3000,
				description: "A humble wooden shack with a welcoming porch."
			);

			AddStock<WoodenHomePorchDeed>(
				price:       4000,
				description: "A wooden home with a spacious porch for gathering."
			);

			AddStock<WoodenHomeUpperDeckDeed>(
				price:       4500,
				description: "A two-story wooden home with an upper deck—perfect for craftsmen."
			);

			AddStock<WoodenMansionDeed>(
				price:       12000,
				description: "A grand wooden mansion, built for the master artisan."
			);

			AddStock<StoneWorkshopDeed>(
				price:       6000,
				description: "A practical stone workshop for artisans and miners alike."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       4000,
				description: "A small stone shop, ideal for a tradesperson’s business."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       4200,
				description: "A modest stone storefront, ready for commerce."
			);

			AddStock<RaisedBrickHomeDeed>(
				price:       7000,
				description: "A brick home built high for defense and storage."
			);

			AddStock<SmallTowerDeed>(
				price:       9000,
				description: "A modest stone tower, a symbol of sturdy Minoc engineering."
			);

			AddStock<LogCabinDeed>(
				price:       5000,
				description: "A classic log cabin built from the forests of Minoc."
			);

			AddStock<FancyWoodenStoneHouseDeed>(
				price:       6500,
				description: "An elegant blend of stone and wood for the refined crafter."
			);

			AddStock<SmallStoneTowerDeed>(
				price:       9500,
				description: "A sturdy stone tower for those who value both form and function."
			);

			AddStock<LargePatioDeed>(
				price:       25000,
				description: "A spacious home with a large patio, ideal for gatherings and workspaces."
			);

			AddStock<KeepDeed>(
				price:       60000,
				description: "A massive stone keep, the pride of Minoc’s masons. Only the most respected can earn this."
			);

			AddStock<CastleDeed>(
				price:       100000,
				description: "A sprawling stone castle—Minoc’s ultimate achievement in architecture and perseverance."
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
        public MinocReputationVendorStone(Serial serial) : base(serial) { }
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
