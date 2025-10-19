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
    public class QasariaReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public QasariaReputationVendorStone()
        {
            Name = "Qasaria Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Qasaria‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Qasaria property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Qasaria", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Qasaria faction level.
            //
			// inside QasariaReputationVendorStone()
			// Qasaria Powerscrolls (100 and 120)

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
				title:       "Cartography 100 Power Scroll",
				description: "A scroll that trains Cartography to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cartography;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "Cartography 120 Power Scroll",
				description: "A scroll that trains Cartography to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cartography;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "Spellweaving 100 Power Scroll",
				description: "A scroll that trains Spellweaving to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Spellweaving;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "Spellweaving 120 Power Scroll",
				description: "A scroll that trains Spellweaving to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Spellweaving;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "Imbuing 100 Power Scroll",
				description: "A scroll that trains Imbuing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Imbuing;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "Imbuing 120 Power Scroll",
				description: "A scroll that trains Imbuing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Imbuing;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "Alchemy 100 Power Scroll",
				description: "A scroll that trains Alchemy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "Alchemy 120 Power Scroll",
				description: "A scroll that trains Alchemy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "Mysticism 100 Power Scroll",
				description: "A scroll that trains Mysticism to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mysticism;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "Mysticism 120 Power Scroll",
				description: "A scroll that trains Mysticism to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Mysticism;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "TasteID 100 Power Scroll",
				description: "A scroll that trains TasteID to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       450,
				title:       "TasteID 120 Power Scroll",
				description: "A scroll that trains TasteID to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
					ps.Value = 120;
				}
			);
       
			// Qasaria Faction Vendor Stock Definitions

			AddStock<SandstonePatioDeed>(
				price:       6000,
				description: "A spacious desert patio, favored in Qasaria’s merchant quarters."
			);

			AddStock<DesertRoseDeed>(
				price:       12000,
				description: "An elegant home inspired by Qasaria’s desert roses and ancient design."
			);

			AddStock<TheSandstoneCastleDeed>(
				price:       90000,
				description: "A sprawling fortress of golden sandstone, worthy of a Qasarian prince."
			);

			AddStock<TheSandstoneFortressOfGrandDeed>(
				price:       110000,
				description: "The greatest fortress of the desert: fit for a merchant-king of Qasaria."
			);

			AddStock<LargePatioDeed>(
				price:       15000,
				description: "A lavish estate with an expansive patio for grand Qasarian gatherings."
			);

			AddStock<CasaMogaDeed>(
				price:       20000,
				description: "A unique, stylish home known among Qasaria’s wealthy traders."
			);

			AddStock<NewTwoStoryBrickHouseDeed>(
				price:       12000,
				description: "A stately two-story brick dwelling, suited for an ambitious merchant."
			);

			AddStock<VillaDeed>(
				price:       18000,
				description: "A luxurious villa overlooking the Qasarian sands."
			);

			AddStock<SmallStoneTempleDeed>(
				price:       8500,
				description: "A humble stone temple in the desert’s heart, honoring the Ancients."
			);

			AddStock<LargeMarbleDeed>(
				price:       25000,
				description: "A palace of shining marble, built for Qasaria’s elite."
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
        public QasariaReputationVendorStone(Serial serial) : base(serial) { }
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
