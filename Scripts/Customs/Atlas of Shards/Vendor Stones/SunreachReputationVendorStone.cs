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
    public class SunreachReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public SunreachReputationVendorStone()
        {
            Name = "Sunreach Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Sunreach‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Sunreach property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Sunreach", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Sunreach faction level.
            //
			// inside SunreachReputationVendorStone()
			// Sunreach Powerscroll Vendor Stock

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


			// Lockpicking
			AddStock<PowerScroll>(
				price:       200,
				title:       "Lockpicking 100 Power Scroll",
				description: "A scroll that trains Lockpicking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Lockpicking;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       800,
				title:       "Lockpicking 120 Power Scroll",
				description: "A scroll that trains Lockpicking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Lockpicking;
					ps.Value = 120;
				}
			);

			// Stealth
			AddStock<PowerScroll>(
				price:       200,
				title:       "Stealth 100 Power Scroll",
				description: "A scroll that trains Stealth to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealth;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       800,
				title:       "Stealth 120 Power Scroll",
				description: "A scroll that trains Stealth to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealth;
					ps.Value = 120;
				}
			);

			// Poisoning
			AddStock<PowerScroll>(
				price:       200,
				title:       "Poisoning 100 Power Scroll",
				description: "A scroll that trains Poisoning to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       800,
				title:       "Poisoning 120 Power Scroll",
				description: "A scroll that trains Poisoning to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
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
				price:       800,
				title:       "Tinkering 120 Power Scroll",
				description: "A scroll that trains Tinkering to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tinkering;
					ps.Value = 120;
				}
			);

			// Snooping
			AddStock<PowerScroll>(
				price:       200,
				title:       "Snooping 100 Power Scroll",
				description: "A scroll that trains Snooping to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Snooping;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       800,
				title:       "Snooping 120 Power Scroll",
				description: "A scroll that trains Snooping to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Snooping;
					ps.Value = 120;
				}
			);

			// Forensics
			AddStock<PowerScroll>(
				price:       200,
				title:       "Forensics 100 Power Scroll",
				description: "A scroll that trains Forensics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       800,
				title:       "Forensics 120 Power Scroll",
				description: "A scroll that trains Forensics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
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
				price:       800,
				title:       "ItemID 120 Power Scroll",
				description: "A scroll that trains ItemID to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.ItemID;
					ps.Value = 120;
				}
			);
           
            AddStock<SmallBoatDeed>(
                price:       3500,
                description: "A modest boat for coastal exploration or fishing."
            );
            AddStock<MediumBoatDeed>(
                price:       8000,
                description: "A sturdy vessel, ideal for traders and adventurers alike."
            );
            AddStock<LargeBoatDeed>(
                price:       18000,
                description: "A grand merchant’s ship, fit for a Sunreach fleet captain."
            );
            AddStock<FancyWoodenStoneHouseDeed>(
                price:       7000,
                description: "A fashionable home blending wood and stone, suited to prosperous traders."
            );
            AddStock<WoodenHomeUpperDeckDeed>(
                price:       6000,
                description: "A wooden house with an upper deck, perfect for coastal views."
            );
            AddStock<TwoStorySmallWoodenDwellingDeed>(
                price:       7500,
                description: "A two-story wooden dwelling, popular with Sunreach's wealthier citizens."
            );
            AddStock<RaisedBrickHomeDeed>(
                price:       8500,
                description: "A brick home with a raised foundation—stylish and practical in harbor districts."
            );
            AddStock<LargePatioDeed>(
                price:       14000,
                description: "A luxurious estate with an expansive patio for grand gatherings."
            );
            AddStock<TheQueensRetreatKeepDeed>(
                price:       65000,
                description: "A regal keep, known as the Queen’s Retreat, for those who dominate the trade routes."
            );
            // Optionally, include a classic castle if you want an ultra-high-end purchase:
            AddStock<CastleDeed>(
                price:       110000,
                description: "A massive, fortified castle—the ultimate symbol of Sunreach power and prestige."
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
        public SunreachReputationVendorStone(Serial serial) : base(serial) { }
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
