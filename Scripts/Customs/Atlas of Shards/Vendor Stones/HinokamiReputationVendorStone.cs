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
    public class HinokamiReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public HinokamiReputationVendorStone()
        {
            Name = "Hinokami Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Hinokami‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Hinokami property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Hinokami", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Hinokami faction level.
            //
			// inside HinokamiReputationVendorStone()
			// Bushido Power Scrolls
			
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
				price:       150,
				title:       "Bushido 100 Power Scroll",
				description: "A scroll that trains Bushido to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Bushido;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Bushido 120 Power Scroll",
				description: "A scroll that trains Bushido to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Bushido;
					ps.Value = 120;
				}
			);

			// Ninjitsu Power Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Ninjitsu 100 Power Scroll",
				description: "A scroll that trains Ninjitsu to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Ninjitsu;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Ninjitsu 120 Power Scroll",
				description: "A scroll that trains Ninjitsu to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Ninjitsu;
					ps.Value = 120;
				}
			);

			// Stealth Power Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Stealth 100 Power Scroll",
				description: "A scroll that trains Stealth to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealth;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Stealth 120 Power Scroll",
				description: "A scroll that trains Stealth to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealth;
					ps.Value = 120;
				}
			);

			// Fencing Power Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Fencing 100 Power Scroll",
				description: "A scroll that trains Fencing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fencing;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Fencing 120 Power Scroll",
				description: "A scroll that trains Fencing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Fencing;
					ps.Value = 120;
				}
			);

			// Tactics Power Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Tactics 100 Power Scroll",
				description: "A scroll that trains Tactics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Tactics 120 Power Scroll",
				description: "A scroll that trains Tactics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 120;
				}
			);

			// Hiding Power Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Hiding 100 Power Scroll",
				description: "A scroll that trains Hiding to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Hiding 120 Power Scroll",
				description: "A scroll that trains Hiding to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 120;
				}
			);
       
			AddStock<SmallWoodenShackPorchDeed>(
				price:       3000,
				description: "A humble wooden hut with a small porch, inspired by Tokuno rural homes."
			);

			AddStock<WoodenHomePorchDeed>(
				price:       6000,
				description: "A modest wooden house with a covered porch, suited for disciplined villagers."
			);

			AddStock<WoodenHomeUpperDeckDeed>(
				price:       7500,
				description: "A wooden home with an upper deck, perfect for serene views of the Hinokami gardens."
			);

			AddStock<SmallDragonBoatDeed>(
				price:       8500,
				description: "A compact dragon-prowed boat, reflecting Tokuno craftsmanship."
			);

			AddStock<MediumDragonBoatDeed>(
				price:       15000,
				description: "A medium-sized dragon boat for both travel and ceremonial processions."
			);

			AddStock<LargeDragonBoatDeed>(
				price:       25000,
				description: "A grand dragon boat, suitable for noble journeys or leading a fleet."
			);

			AddStock<FeudalCastleDeed>(
				price:       90000,
				description: "A grand, multi-tiered feudal castle built in the traditional Hinokami style."
			);

			AddStock<CitadelOfTheFarEastDeed>(
				price:       130000,
				description: "An imposing Tokuno-inspired citadel—stronghold of legendary warlords."
			);

			AddStock<OkinawaSweetDreamCastleDeed>(
				price:       150000,
				description: "A vast, dreamy castle echoing the grandeur of old Okinawa, reserved for only the most honored."
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
        public HinokamiReputationVendorStone(Serial serial) : base(serial) { }
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
