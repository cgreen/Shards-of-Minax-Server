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
    public class PlantReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public PlantReputationVendorStone()
        {
            Name = "Plant Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Plant‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Plant property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Plant", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Plant faction level.
            //
			// inside PlantReputationVendorStone()
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


			// Archery
			AddStock<PowerScroll>(
				price:       250,
				title:       "Archery 100 Power Scroll",
				description: "A scroll that trains Archery to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Archery;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Archery 120 Power Scroll",
				description: "A scroll that trains Archery to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Archery;
					ps.Value = 120;
				}
			);

			// Swords
			AddStock<PowerScroll>(
				price:       250,
				title:       "Swords 100 Power Scroll",
				description: "A scroll that trains Swords to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Swords;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Swords 120 Power Scroll",
				description: "A scroll that trains Swords to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Swords;
					ps.Value = 120;
				}
			);

			// Macing
			AddStock<PowerScroll>(
				price:       250,
				title:       "Macing 100 Power Scroll",
				description: "A scroll that trains Macing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Macing;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Macing 120 Power Scroll",
				description: "A scroll that trains Macing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Macing;
					ps.Value = 120;
				}
			);

			// Stealing
			AddStock<PowerScroll>(
				price:       250,
				title:       "Stealing 100 Power Scroll",
				description: "A scroll that trains Stealing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealing;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Stealing 120 Power Scroll",
				description: "A scroll that trains Stealing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealing;
					ps.Value = 120;
				}
			);

			// Bushido
			AddStock<PowerScroll>(
				price:       250,
				title:       "Bushido 100 Power Scroll",
				description: "A scroll that trains Bushido to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Bushido;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Bushido 120 Power Scroll",
				description: "A scroll that trains Bushido to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Bushido;
					ps.Value = 120;
				}
			);

			// Camping
			AddStock<PowerScroll>(
				price:       250,
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

			// Tactics
			AddStock<PowerScroll>(
				price:       250,
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
         
			AddStock<StoneFortDeed>(
				price:       20000,
				description: "A rough-hewn stone fortress, sturdy enough for any warband."
			);

			AddStock<SmallLogCabinDeed>(
				price:       5000,
				description: "A humble log cabin, suited for a lone orc or ogre."
			);

			AddStock<SmallLogCabinWithDeckDeed>(
				price:       6500,
				description: "A small log cabin with a simple wooden deck."
			);

			AddStock<SmallStoneStoreFrontDeed>(
				price:       4500,
				description: "A simple stone shopfront, ideal for trading trophies or wares."
			);

			AddStock<PlasterHomeDirtDeckDeed>(
				price:       4200,
				description: "A rough plaster dwelling with a dirt-floored deck."
			);

			AddStock<OldStoneHomeShoppeDeed>(
				price:       4800,
				description: "An old stone shop, suitable for crude repairs or storage."
			);

			AddStock<FortressOfLestatDeed>(
				price:       30000,
				description: "A grim, imposing fortress—fit for a true warlord."
			);

			AddStock<TheSandstoneCastleDeed>(
				price:       40000,
				description: "A massive fortress of sandstone, echoing with power."
			);

			AddStock<StoneHomeWithEnclosedPatioDeed>(
				price:       7500,
				description: "A rough stone home with a walled-in patio for prisoners... or livestock."
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
        public PlantReputationVendorStone(Serial serial) : base(serial) { }
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
