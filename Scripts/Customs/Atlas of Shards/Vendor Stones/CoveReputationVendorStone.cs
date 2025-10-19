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
    public class CoveReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public CoveReputationVendorStone()
        {
            Name = "Cove Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Cove‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Cove property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Cove", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Cove faction level.
            //
			// inside CoveReputationVendorStone()
			// Cove faction Power Scroll stock definitions

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
				title:       "Veterinary 100 Power Scroll",
				description: "A scroll that trains Veterinary to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Veterinary;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,
				title:       "Veterinary 120 Power Scroll",
				description: "A scroll that trains Veterinary to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Veterinary;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Fishing 100 Power Scroll",
				description: "A scroll that trains Fishing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fishing;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,
				title:       "Fishing 120 Power Scroll",
				description: "A scroll that trains Fishing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fishing;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Cooking 100 Power Scroll",
				description: "A scroll that trains Cooking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cooking;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,
				title:       "Cooking 120 Power Scroll",
				description: "A scroll that trains Cooking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cooking;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,
				title:       "Animal Lore 100 Power Scroll",
				description: "A scroll that trains Animal Lore to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalLore;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,
				title:       "Animal Lore 120 Power Scroll",
				description: "A scroll that trains Animal Lore to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalLore;
					ps.Value = 120;
				}
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
				price:       300,
				title:       "Camping 120 Power Scroll",
				description: "A scroll that trains Camping to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 120;
				}
			);
         
			// Cove Faction House Deed Vendor Stock

			AddStock<FieldStoneHouseDeed>(
				price: 3000,
				description: "A humble stone house, built with the resilience of Cove's people."
			);

			AddStock<PlainStoneHouseDeed>(
				price: 3500,
				description: "Simple stone dwelling, reflecting Cove’s practical spirit."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price: 3500,
				description: "A modest shop, perfect for merchants on the Compassion coast."
			);

			AddStock<SmallStoneShoppeDeed>(
				price: 4000,
				description: "A small shoppe for crafters and traders in Cove."
			);

			AddStock<SmallStoneTempleDeed>(
				price: 4000,
				description: "A tranquil stone temple for personal reflection or small gatherings."
			);

			AddStock<StoneWorkshopDeed>(
				price: 5000,
				description: "A robust workshop for dedicated artisans of Cove."
			);

			AddStock<SmallTowerDeed>(
				price: 6500,
				description: "A sturdy tower, offering security for those defending Cove."
			);

			// Large/Prestige Structures (expensive!)
			AddStock<KeepDeed>(
				price: 22000,
				description: "A mighty keep, fit for Cove’s greatest defenders."
			);

			AddStock<CastleDeed>(
				price: 35000,
				description: "A grand castle – the pride of any Compassionate soul."
			);

			AddStock<LargePatioDeed>(
				price: 18000,
				description: "A sprawling home with a spacious patio, perfect for gatherings."
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
        public CoveReputationVendorStone(Serial serial) : base(serial) { }
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
