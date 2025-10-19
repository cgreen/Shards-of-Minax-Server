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
using Server.Multis;

namespace Server.CustomVendors
{
    public class OclloReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public OclloReputationVendorStone()
        {
            Name = "Ocllo Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Ocllo‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Ocllo property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Ocllo", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Ocllo faction level.
            //
			// inside OclloReputationVendorStone()
			// Ocllo Faction Power Scrolls Vendor Stock
			
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
			
			

			AddStock<PowerScroll>(
				price:       100,
				title:       "Camping 100 Power Scroll",
				description: "A scroll that trains Camping to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "Camping 120 Power Scroll",
				description: "A scroll that trains Camping to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Healing 100 Power Scroll",
				description: "A scroll that trains Healing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Healing;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "Healing 120 Power Scroll",
				description: "A scroll that trains Healing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Healing;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Tactics 100 Power Scroll",
				description: "A scroll that trains Tactics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "Tactics 120 Power Scroll",
				description: "A scroll that trains Tactics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Herding 100 Power Scroll",
				description: "A scroll that trains Herding to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Herding;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "Herding 120 Power Scroll",
				description: "A scroll that trains Herding to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Herding;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "AnimalLore 100 Power Scroll",
				description: "A scroll that trains AnimalLore to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalLore;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "AnimalLore 120 Power Scroll",
				description: "A scroll that trains AnimalLore to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalLore;
					ps.Value = 120;
				}
			);
        
			// 🏡 Ocllo House Deed Vendor Stock

			AddStock<StonePlasterHouseDeed>(
				price:       3200,
				description: "A simple house of stone and plaster."
			);

			AddStock<FieldStoneHouseDeed>(
				price:       2800,
				description: "A modest home built of rough fieldstone."
			);

			AddStock<SmallBrickHouseDeed>(
				price:       2900,
				description: "A cozy, durable brick cottage."
			);

			AddStock<WoodHouseDeed>(
				price:       2400,
				description: "A basic wooden dwelling, perfect for new arrivals."
			);

			AddStock<WoodPlasterHouseDeed>(
				price:       2600,
				description: "A small home of wood with a white plaster finish."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price:       3300,
				description: "A charming cottage with a thatched roof."
			);

			AddStock<SmallLogCabinDeed>(
				price:       3200,
				description: "A small cabin made of sturdy logs."
			);

			AddStock<SmallLogCabinWithDeckDeed>(
				price:       3600,
				description: "A log cabin with a welcoming wooden deck."
			);

			AddStock<SmallWoodenShackPorchDeed>(
				price:       2200,
				description: "A humble shack with a small front porch."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       3400,
				description: "A small stone shop, ideal for new tradesfolk."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       3600,
				description: "A simple stone storefront for small business."
			);

			AddStock<PlainPlasterHouseDeed>(
				price:       2500,
				description: "A plain house of whitewashed plaster."
			);

			AddStock<SmallStoneTempleDeed>(
				price:       3900,
				description: "A small stone temple for quiet worship."
			);

			AddStock<BrickHomeWithFrontDeckDeed>(
				price:       4300,
				description: "A brick home with a sturdy front deck."
			);

			AddStock<NeoTwoStoryBrickHouseDeed>(
				price:       5600,
				description: "A modern, two-story brick house with spacious rooms."
			);

			AddStock<WoodenHomePorchDeed>(
				price:       3800,
				description: "A wooden home with a comfortable porch."
			);

			AddStock<PlasterHomeDirtDeckDeed>(
				price:       3700,
				description: "A plaster house with a simple dirt-floored deck."
			);

			AddStock<OldStoneHomeShoppeDeed>(
				price:       3500,
				description: "An old stone house with a small shop attached."
			);

			// 🚤 Small Boat Deeds for Newcomers
			AddStock<SmallBoatDeed>(
				price:       6500,
				description: "A basic small boat for coastal exploration."
			);

			// 🏰 High-Tier Homes (Very Expensive for Ocllo Reputation)
			AddStock<TowerDeed>(
				price:       18000,
				description: "A classic tower for those seeking security and prestige."
			);

			AddStock<KeepDeed>(
				price:       36000,
				description: "A grand fortress keep; a true mark of status."
			);

			AddStock<CastleDeed>(
				price:       70000,
				description: "A legendary stone castle—ownership reserved for the greatest adventurers."
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
        public OclloReputationVendorStone(Serial serial) : base(serial) { }
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
