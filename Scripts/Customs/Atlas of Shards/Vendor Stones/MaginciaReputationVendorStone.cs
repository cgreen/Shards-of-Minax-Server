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
    public class MaginciaReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public MaginciaReputationVendorStone()
        {
            Name = "Magincia Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Magincia‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Magincia property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Magincia", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Magincia faction level.
            //
			// inside MaginciaReputationVendorStone()
			// Begging 100 Power Scroll
			
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
				title:       "Begging 100 Power Scroll",
				description: "A scroll that trains Begging to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Begging;
					ps.Value = 100;
				}
			);

			// Begging 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Begging 120 Power Scroll",
				description: "A scroll that trains Begging to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Begging;
					ps.Value = 120;
				}
			);

			// TasteID 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "TasteID 100 Power Scroll",
				description: "A scroll that trains TasteID to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
					ps.Value = 100;
				}
			);

			// TasteID 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "TasteID 120 Power Scroll",
				description: "A scroll that trains TasteID to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
					ps.Value = 120;
				}
			);

			// Fishing 100 Power Scroll
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

			// Fishing 120 Power Scroll
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

			// Tailoring 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Tailoring 100 Power Scroll",
				description: "A scroll that trains Tailoring to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tailoring;
					ps.Value = 100;
				}
			);

			// Tailoring 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Tailoring 120 Power Scroll",
				description: "A scroll that trains Tailoring to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tailoring;
					ps.Value = 120;
				}
			);

			// Peacemaking 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Peacemaking 100 Power Scroll",
				description: "A scroll that trains Peacemaking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Peacemaking;
					ps.Value = 100;
				}
			);

			// Peacemaking 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Peacemaking 120 Power Scroll",
				description: "A scroll that trains Peacemaking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Peacemaking;
					ps.Value = 120;
				}
			);
      
			
			AddStock<VillaDeed>(
				price:       9000,
				description: "A graceful villa reflecting Magincia’s pastoral renewal."
			);

			AddStock<TheSandstoneCastleDeed>(
				price:       60000,
				description: "A sprawling castle of golden sandstone—a symbol of Magincia’s rebirth."
			);

			AddStock<TheSandstoneFortressOfGrandDeed>(
				price:       45000,
				description: "A formidable fortress in the Magincian style, for those with true humility and vision."
			);

			AddStock<StoneHomeWithEnclosedPatioDeed>(
				price:       11000,
				description: "A cozy stone home with a sheltered patio, ideal for peaceful living."
			);

			AddStock<TheHouseBuiltOnTheRuinsDeed>(
				price:       17000,
				description: "A sturdy dwelling raised upon ancient Magincian foundations."
			);

			AddStock<PlainPlasterHouseDeed>(
				price:       7500,
				description: "A modest plaster home, echoing the humility of New Magincia."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price:       6500,
				description: "A thatched cottage nestled in tranquil Magincian fields."
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
        public MaginciaReputationVendorStone(Serial serial) : base(serial) { }
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
