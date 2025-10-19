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
    public class VesperReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public VesperReputationVendorStone()
        {
            Name = "Vesper Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Vesper‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Vesper property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Vesper", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Vesper faction level.
            //
			// inside VesperReputationVendorStone()
			// Vesper faction Power Scrolls

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


			// Mining
			AddStock<PowerScroll>(
				price:       200,
				title:       "Mining 100 Power Scroll",
				description: "A scroll that trains Mining to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Mining 120 Power Scroll",
				description: "A scroll that trains Mining to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 120;
				}
			);

			// Tinkering
			AddStock<PowerScroll>(
				price:       200,
				title:       "Tinkering 100 Power Scroll",
				description: "A scroll that trains Tinkering to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tinkering;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Tinkering 120 Power Scroll",
				description: "A scroll that trains Tinkering to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tinkering;
					ps.Value = 120;
				}
			);

			// Blacksmith
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

			// Cartography
			AddStock<PowerScroll>(
				price:       200,
				title:       "Cartography 100 Power Scroll",
				description: "A scroll that trains Cartography to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cartography;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Cartography 120 Power Scroll",
				description: "A scroll that trains Cartography to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cartography;
					ps.Value = 120;
				}
			);

			// ArmsLore
			AddStock<PowerScroll>(
				price:       200,
				title:       "ArmsLore 100 Power Scroll",
				description: "A scroll that trains ArmsLore to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.ArmsLore;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "ArmsLore 120 Power Scroll",
				description: "A scroll that trains ArmsLore to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.ArmsLore;
					ps.Value = 120;
				}
			);

			// ItemID
			AddStock<PowerScroll>(
				price:       200,
				title:       "ItemID 100 Power Scroll",
				description: "A scroll that trains ItemID to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.ItemID;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "ItemID 120 Power Scroll",
				description: "A scroll that trains ItemID to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.ItemID;
					ps.Value = 120;
				}
			);
         
			// Vesper Faction Vendor Stock Definitions

			AddStock<SmallBrickHouseDeed>(
				price:       3500,
				description: "A compact brick house for industrious settlers."
			);

			AddStock<BrickHomeWithFrontDeckDeed>(
				price:       6500,
				description: "A comfortable brick home with a welcoming front deck."
			);

			AddStock<BrickHomeWithLargePorchDeed>(
				price:       8000,
				description: "A spacious brick house with a large porch—perfect for gatherings."
			);

			AddStock<NeoTwoStoryBrickHouseDeed>(
				price:       12000,
				description: "A modern two-story brick residence reflecting Vesper's progress."
			);

			AddStock<StoneWorkshopDeed>(
				price:       9000,
				description: "A sturdy stone workshop ideal for crafters and miners."
			);

			AddStock<MarbleWorkshopDeed>(
				price:       12000,
				description: "A high-status marble workshop for expert artisans."
			);

			AddStock<OldStoneHomeShoppeDeed>(
				price:       6000,
				description: "An old-fashioned stone shop and home in one."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       5000,
				description: "A petite stone shop suitable for humble merchants."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       4800,
				description: "A simple stone storefront, perfect for launching a small business."
			);

			AddStock<BrickArenaDeed>(
				price:       30000,
				description: "A grand brick arena for public duels and competitions."
			);

			// Optionally, for castle/keep-style deeds if you wish to give Vesper a few prestige items:
			AddStock<LargeMarbleDeed>(
				price:       90000,
				description: "A massive marble estate reserved for Vesper's industrial elite."
			);

			AddStock<CastleOfOceaniaDeed>(
				price:       120000,
				description: "A legendary castle inspired by oceanic might and Vesper's prosperity."
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
        public VesperReputationVendorStone(Serial serial) : base(serial) { }
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
