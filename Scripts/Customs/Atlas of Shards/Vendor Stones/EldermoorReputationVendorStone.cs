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
    public class EldermoorReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public EldermoorReputationVendorStone()
        {
            Name = "Eldermoor Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Eldermoor‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Eldermoor property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Eldermoor", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Eldermoor faction level.
            //
			// inside EldermoorReputationVendorStone()
			// Eldermoor Faction Power Scrolls Vendor Stock

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
				price:       300,                                
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
				title:       "Animal Taming 100 Power Scroll",         
				description: "A scroll that trains Animal Taming to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalTaming;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,                                
				title:       "Animal Taming 120 Power Scroll",         
				description: "A scroll that trains Animal Taming to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalTaming;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,                                
				title:       "Fletching 100 Power Scroll",         
				description: "A scroll that trains Fletching to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Fletching;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,                                
				title:       "Fletching 120 Power Scroll",         
				description: "A scroll that trains Fletching to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Fletching;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       100,                                
				title:       "Tracking 100 Power Scroll",         
				description: "A scroll that trains Tracking to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,                                
				title:       "Tracking 120 Power Scroll",         
				description: "A scroll that trains Tracking to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 120;
				}
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
				title:       "Lumberjacking 100 Power Scroll",         
				description: "A scroll that trains Lumberjacking to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Lumberjacking;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       300,                                
				title:       "Lumberjacking 120 Power Scroll",         
				description: "A scroll that trains Lumberjacking to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Lumberjacking;
					ps.Value = 120;
				}
			);
         
			AddStock<LogCabinDeed>(
				price:       5000,
				description: "A rustic log cabin—ideal for survival in the wilds of Eldermoor."
			);

			AddStock<SmallLogCabinWithDeckDeed>(
				price:       6500,
				description: "A cozy log cabin with a deck, suited for Eldermoor’s rolling hills."
			);

			AddStock<FieldStoneHouseDeed>(
				price:       7000,
				description: "A sturdy stone house built from local fieldstone."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price:       8500,
				description: "A humble cottage with a thatched roof, common in Eldermoor farmlands."
			);

			AddStock<TwoStoryWoodPlasterHouseDeed>(
				price:       11000,
				description: "A two-story home of wood and plaster, for prosperous Eldermoor settlers."
			);

			AddStock<SmallStoneTowerDeed>(
				price:       12500,
				description: "A modest stone tower, offering safety from monsters and bandits."
			);

			AddStock<StonePlasterHouseDeed>(
				price:       13500,
				description: "A strong, plaster-finished stone home, well-defended against raids."
			);

			// **Larger Prestige Homes — expensive!**

			AddStock<KeepDeed>(
				price:       65000,
				description: "A formidable keep, symbol of strength and leadership in Eldermoor."
			);

			AddStock<CastleDeed>(
				price:       120000,
				description: "A grand stone castle, fit for Eldermoor’s legendary founders."
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
        public EldermoorReputationVendorStone(Serial serial) : base(serial) { }
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
