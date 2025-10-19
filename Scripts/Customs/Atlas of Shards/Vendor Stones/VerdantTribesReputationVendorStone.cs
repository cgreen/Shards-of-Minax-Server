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
    public class VerdantTribesReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public VerdantTribesReputationVendorStone()
        {
            Name = "VerdantTribes Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s VerdantTribes‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.VerdantTribes property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("VerdantTribes", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their VerdantTribes faction level.
            //
			// inside VerdantTribesReputationVendorStone()
			// Verdant Tribes Power Scrolls - 100 Skill Level
			
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
				price:       200,
				title:       "Animal Taming 100 Power Scroll",
				description: "A scroll that trains Animal Taming to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalTaming;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       200,
				title:       "Tracking 100 Power Scroll",
				description: "A scroll that trains Tracking to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       200,
				title:       "Spirit Speak 100 Power Scroll",
				description: "A scroll that trains Spirit Speak to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       200,
				title:       "Herding 100 Power Scroll",
				description: "A scroll that trains Herding to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Herding;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       200,
				title:       "Camping 100 Power Scroll",
				description: "A scroll that trains Camping to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       200,
				title:       "Peacemaking 100 Power Scroll",
				description: "A scroll that trains Peacemaking to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Peacemaking;
					ps.Value = 100;
				}
			);

			// Verdant Tribes Power Scrolls - 120 Skill Level (Higher Cost)
			AddStock<PowerScroll>(
				price:       600,
				title:       "Animal Taming 120 Power Scroll",
				description: "A scroll that trains Animal Taming to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.AnimalTaming;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Tracking 120 Power Scroll",
				description: "A scroll that trains Tracking to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Tracking;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Spirit Speak 120 Power Scroll",
				description: "A scroll that trains Spirit Speak to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Herding 120 Power Scroll",
				description: "A scroll that trains Herding to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Herding;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Camping 120 Power Scroll",
				description: "A scroll that trains Camping to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       600,
				title:       "Peacemaking 120 Power Scroll",
				description: "A scroll that trains Peacemaking to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Peacemaking;
					ps.Value = 120;
				}
			);
        
			AddStock<SmallWoodenShackPorchDeed>(
				price:       4000,
				description: "A humble wooden hut with a simple porch, typical of Verdant villages."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       6000,
				description: "A compact stone dwelling, ideal for traders in the tribes’ marketplaces."
			);

			AddStock<VillaCrowleyDeed>(
				price:       9000,
				description: "A larger tribal villa, blending natural wood and stone for families of status."
			);

			AddStock<StoneHomeWithEnclosedPatioDeed>(
				price:       11000,
				description: "A sturdy stone home with a sheltered patio for gatherings and rituals."
			);

			AddStock<PlasterHomeDirtDeckDeed>(
				price:       7000,
				description: "A modest plaster dwelling, its dirt deck favored by tribal elders."
			);

			AddStock<WoodenHomePorchDeed>(
				price:       8000,
				description: "A well-built wooden home with a covered porch, perfect for a hunter’s family."
			);

			// For a little overlap and access to slightly larger tribal-style dwellings:
			AddStock<ThatchedRoofCottageDeed>(
				price:       8500,
				description: "A cozy thatched-roof cottage, blending comfort with the wilds."
			);

			AddStock<LogCabinDeed>(
				price:       9500,
				description: "A spacious log cabin crafted from ancient forest timber."
			);

			// Large tribal strongholds (expensive!)
			AddStock<TheSandstoneFortressOfGrandDeed>(
				price:      25000,
				description: "A massive sandstone fortress, home to powerful chieftains and their kin."
			);

			AddStock<TheSandstoneCastleDeed>(
				price:      30000,
				description: "An imposing castle of sunbaked stone, the pride of the Verdant Tribes."
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
        public VerdantTribesReputationVendorStone(Serial serial) : base(serial) { }
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
