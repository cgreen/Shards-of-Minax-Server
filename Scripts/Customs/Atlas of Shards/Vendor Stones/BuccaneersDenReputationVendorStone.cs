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
    public class BuccaneersDenReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public BuccaneersDenReputationVendorStone()
        {
            Name = "BuccaneersDen Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s BuccaneersDen‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.BuccaneersDen property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("BuccaneersDen", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their BuccaneersDen faction level.
            //
			// inside BuccaneersDenReputationVendorStone()
			
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
			
			
			// Stealing 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Stealing 100 Power Scroll",
				description: "A scroll that trains Stealing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealing;
					ps.Value = 100;
				}
			);

			// Stealing 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Stealing 120 Power Scroll",
				description: "A scroll that trains Stealing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealing;
					ps.Value = 120;
				}
			);

			// Snooping 100
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

			// Snooping 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Snooping 120 Power Scroll",
				description: "A scroll that trains Snooping to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Snooping;
					ps.Value = 120;
				}
			);

			// Hiding 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Hiding 100 Power Scroll",
				description: "A scroll that trains Hiding to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 100;
				}
			);

			// Hiding 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Hiding 120 Power Scroll",
				description: "A scroll that trains Hiding to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 120;
				}
			);

			// Poisoning 100
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

			// Poisoning 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Poisoning 120 Power Scroll",
				description: "A scroll that trains Poisoning to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 120;
				}
			);

			// Lockpicking 100
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

			// Lockpicking 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Lockpicking 120 Power Scroll",
				description: "A scroll that trains Lockpicking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Lockpicking;
					ps.Value = 120;
				}
			);

			// Fencing 100
			AddStock<PowerScroll>(
				price:       200,
				title:       "Fencing 100 Power Scroll",
				description: "A scroll that trains Fencing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fencing;
					ps.Value = 100;
				}
			);

			// Fencing 120
			AddStock<PowerScroll>(
				price:       600,
				title:       "Fencing 120 Power Scroll",
				description: "A scroll that trains Fencing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fencing;
					ps.Value = 120;
				}
			);
         
			// Buccaneer's Den Faction Deed Vendor Stock

			AddStock<SmallBoatDeed>(
				price:       2500,
				description: "A modest boat, perfect for coastal piracy or fishing."
			);

			AddStock<MediumBoatDeed>(
				price:       7500,
				description: "A sturdy vessel for longer sea raids and cargo."
			);

			AddStock<LargeBoatDeed>(
				price:       18000,
				description: "A massive galleon, fit for a pirate admiral."
			);

			AddStock<SmallDragonBoatDeed>(
				price:       4000,
				description: "A sleek, eastern-style vessel for swift piracy."
			);

			AddStock<MediumDragonBoatDeed>(
				price:       12000,
				description: "A large dragon boat, both fast and intimidating."
			);

			AddStock<LargeDragonBoatDeed>(
				price:       24000,
				description: "A grand dragon boat, the envy of any seafaring rogue."
			);

			AddStock<SmallWoodenShackPorchDeed>(
				price:       2200,
				description: "A weathered shack with a porch, perfect for laying low."
			);

			AddStock<BrickArenaDeed>(
				price:       10000,
				description: "A brick arena, ideal for underground duels and gambling."
			);

			AddStock<TheDragonstoneCastleDeed>(
				price:       85000,
				description: "A colossal castle with draconic motifs, worthy of a pirate lord. (Extremely exclusive!)"
			);

			AddStock<SmallTowerDeed>(
				price:       11000,
				description: "A defensible small stone tower for keeping watch on your plunder."
			);

			AddStock<SmallBrickCastleDeed>(
				price:       28000,
				description: "A brickwork stronghold for the up-and-coming pirate baron."
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
        public BuccaneersDenReputationVendorStone(Serial serial) : base(serial) { }
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
