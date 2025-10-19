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
    public class YewReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public YewReputationVendorStone()
        {
            Name = "Yew Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Yew‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Yew property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Yew", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Yew faction level.
            //
			// inside YewReputationVendorStone()
			// Yew Faction Power Scrolls - Price and definitions

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


			// Tracking 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "Tracking 100 Power Scroll",
				description: "A scroll that trains Tracking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 100;
				}
			);

			// Tracking 120 Power Scroll
			AddStock<PowerScroll>(
				price:       500,
				title:       "Tracking 120 Power Scroll",
				description: "A scroll that trains Tracking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 120;
				}
			);

			// SpiritSpeak 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "SpiritSpeak 100 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 100;
				}
			);

			// SpiritSpeak 120 Power Scroll
			AddStock<PowerScroll>(
				price:       500,
				title:       "SpiritSpeak 120 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 120;
				}
			);

			// Camping 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "Camping 100 Power Scroll",
				description: "A scroll that trains Camping to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 100;
				}
			);

			// Camping 120 Power Scroll
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

			// Herding 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "Herding 100 Power Scroll",
				description: "A scroll that trains Herding to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Herding;
					ps.Value = 100;
				}
			);

			// Herding 120 Power Scroll
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

			// Healing 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "Healing 100 Power Scroll",
				description: "A scroll that trains Healing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Healing;
					ps.Value = 100;
				}
			);

			// Healing 120 Power Scroll
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

			// Forensics 100 Power Scroll
			AddStock<PowerScroll>(
				price:       150,
				title:       "Forensics 100 Power Scroll",
				description: "A scroll that trains Forensics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
					ps.Value = 100;
				}
			);

			// Forensics 120 Power Scroll
			AddStock<PowerScroll>(
				price:       500,
				title:       "Forensics 120 Power Scroll",
				description: "A scroll that trains Forensics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
					ps.Value = 120;
				}
			);
          
			AddStock<PlainPlasterHouseDeed>(
				price: 7500,
				description: "A modest plaster cottage, typical of Yew's peaceful countryside."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price: 9000,
				description: "A humble thatched-roof cottage nestled among the trees of Yew."
			);

			AddStock<PlasterHomeDirtDeckDeed>(
				price: 11000,
				description: "A rustic plaster home with a dirt deck, perfect for a rural life."
			);

			AddStock<PlasterHousePictureWindowDeed>(
				price: 12500,
				description: "A plaster cottage with a wide window to enjoy Yew's woodland views."
			);

			AddStock<SmallStoneTempleDeed>(
				price: 14000,
				description: "A small stone temple, inspired by Yew's ancient abbey."
			);

			AddStock<RobinsNestDeed>(
				price: 15000,
				description: "A cozy woodland retreat, favored by hermits and druids."
			);

			AddStock<RobinsRoostDeed>(
				price: 15500,
				description: "A rustic treehouse, reminiscent of Yew's spiritual roots."
			);

			AddStock<TheTerraceGardensDeed>(
				price: 18000,
				description: "A tranquil dwelling surrounded by terraced gardens and quiet meditation spaces."
			);

			// Optional: Rare, very expensive castle/keep (for high Yew rep)
			AddStock<TraditionalKeepDeed>(
				price: 200000,
				description: "A vast, timeworn keep built to defend the forests and Virtues of Yew."
			);

			AddStock<ThreeStoryStoneVillaDeed>(
				price: 110000,
				description: "A stately stone villa, large enough for a family of spiritual stewards."
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
        public YewReputationVendorStone(Serial serial) : base(serial) { }
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
