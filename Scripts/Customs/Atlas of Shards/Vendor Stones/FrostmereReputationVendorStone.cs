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
    public class FrostmereReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public FrostmereReputationVendorStone()
        {
            Name = "Frostmere Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Frostmere‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Frostmere property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Frostmere", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Frostmere faction level.
            //
			// inside FrostmereReputationVendorStone()
			// Frostmere Powerscrolls: 100 and 120 skill caps with price difference

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


			// Alchemy 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Alchemy 100 Power Scroll",
				description: "A scroll that trains Alchemy to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 100;
				}
			);

			// Alchemy 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Alchemy 120 Power Scroll",
				description: "A scroll that trains Alchemy to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 120;
				}
			);

			// Mysticism 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Mysticism 100 Power Scroll",
				description: "A scroll that trains Mysticism to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Mysticism;
					ps.Value = 100;
				}
			);

			// Mysticism 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Mysticism 120 Power Scroll",
				description: "A scroll that trains Mysticism to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Mysticism;
					ps.Value = 120;
				}
			);

			// Focus 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Focus 100 Power Scroll",
				description: "A scroll that trains Focus to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Focus;
					ps.Value = 100;
				}
			);

			// Focus 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Focus 120 Power Scroll",
				description: "A scroll that trains Focus to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Focus;
					ps.Value = 120;
				}
			);

			// Mining 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "Mining 100 Power Scroll",
				description: "A scroll that trains Mining to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 100;
				}
			);

			// Mining 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "Mining 120 Power Scroll",
				description: "A scroll that trains Mining to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.Mining;
					ps.Value = 120;
				}
			);

			// MagicResist 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "MagicResist 100 Power Scroll",
				description: "A scroll that trains MagicResist to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.MagicResist;
					ps.Value = 100;
				}
			);

			// MagicResist 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "MagicResist 120 Power Scroll",
				description: "A scroll that trains MagicResist to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.MagicResist;
					ps.Value = 120;
				}
			);

			// EvalInt 100 Power Scroll
			AddStock<PowerScroll>(
				price:       100,
				title:       "EvalInt 100 Power Scroll",
				description: "A scroll that trains EvalInt to 100", 
				configure:   ps =>
				{
					ps.Skill = SkillName.EvalInt;
					ps.Value = 100;
				}
			);

			// EvalInt 120 Power Scroll
			AddStock<PowerScroll>(
				price:       300,
				title:       "EvalInt 120 Power Scroll",
				description: "A scroll that trains EvalInt to 120", 
				configure:   ps =>
				{
					ps.Skill = SkillName.EvalInt;
					ps.Value = 120;
				}
			);
           
			
			AddStock<StonePlasterHouseDeed>(
				price:       7000,
				description: "A rugged stone-and-plaster dwelling, warm against Frostmere’s bitter winds."
			);

			AddStock<TwoStorySmallStoneDwellingDeed>(
				price:       8500,
				description: "A modest two-story stone home, suited to withstand northern storms."
			);

			AddStock<TwoStorySmallStoneHomeDeed>(
				price:       9000,
				description: "A two-story stone house, built for families braving the Frostmere tundra."
			);

			AddStock<TwoStorySmallStoneHouseDeed>(
				price:       9500,
				description: "A sturdy two-story stone dwelling, favored by Frostmere’s hardy settlers."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       6500,
				description: "A compact stone shoppe, perfect for crafting or trade in harsh climates."
			);

			AddStock<MarbleWorkshopDeed>(
				price:       12000,
				description: "An elegant marble workshop, for artisans and crafters of the frostlands."
			);

			AddStock<ElsaCastleDeed>(
				price:       45000,
				description: "A majestic castle sculpted in icy grandeur, fit for Frostmere’s nobility."
			);

			AddStock<SallyTreesRefurbishedKeepDeed>(
				price:       35000,
				description: "A refurbished keep, offering unmatched protection from the frozen wilds."
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
        public FrostmereReputationVendorStone(Serial serial) : base(serial) { }
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
