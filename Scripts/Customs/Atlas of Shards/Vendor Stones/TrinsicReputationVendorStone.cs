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
    public class TrinsicReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public TrinsicReputationVendorStone()
        {
            Name = "Trinsic Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Trinsic‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Trinsic property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Trinsic", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Trinsic faction level.
            //
			// inside TrinsicReputationVendorStone()
			
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
			
			
			// Trinsic Faction Power Scrolls - 100 Skill Level
			AddStock<PowerScroll>(
				price:       250,
				title:       "Chivalry 100 Power Scroll",
				description: "A scroll that trains Chivalry to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Chivalry;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       250,
				title:       "Parry 100 Power Scroll",
				description: "A scroll that trains Parry to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Parry;
					ps.Value = 100;
				}
			);

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
				price:       250,
				title:       "Focus 100 Power Scroll",
				description: "A scroll that trains Focus to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Focus;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       250,
				title:       "DetectHidden 100 Power Scroll",
				description: "A scroll that trains DetectHidden to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.DetectHidden;
					ps.Value = 100;
				}
			);

			// Trinsic Faction Power Scrolls - 120 Skill Level
			AddStock<PowerScroll>(
				price:       500,
				title:       "Chivalry 120 Power Scroll",
				description: "A scroll that trains Chivalry to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Chivalry;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "Parry 120 Power Scroll",
				description: "A scroll that trains Parry to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Parry;
					ps.Value = 120;
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

			AddStock<PowerScroll>(
				price:       500,
				title:       "Focus 120 Power Scroll",
				description: "A scroll that trains Focus to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Focus;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       500,
				title:       "DetectHidden 120 Power Scroll",
				description: "A scroll that trains DetectHidden to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.DetectHidden;
					ps.Value = 120;
				}
			);
        
			AddStock<BrickHouseDeed>(
				price:       6000,
				description: "A sturdy brick home, favored by Trinsic's citizens for its security."
			);

			AddStock<TwoStoryBrickHomeDeed>(
				price:       12000,
				description: "A spacious two-story brick home, perfect for growing households."
			);

			AddStock<TrinsicKeepDeed>(
				price:       100000,
				description: "A fortified keep, fit for defenders of honor and the city of Trinsic."
			);

			AddStock<StoneFortDeed>(
				price:       25000,
				description: "A fortified stone structure, ideal for those who value defense."
			);

			AddStock<FortressOfLestatDeed>(
				price:       45000,
				description: "A brooding, gothic fortress—its walls echo with the tales of legendary paladins."
			);

			AddStock<VillaDeed>(
				price:       14000,
				description: "A luxurious villa in the classic style of Trinsic’s noble families."
			);

			AddStock<RaisedBrickHomeDeed>(
				price:       9000,
				description: "A charming brick home raised above the bustle of the street."
			);

			AddStock<BrickArenaDeed>(
				price:       22000,
				description: "A small arena, ideal for hosting honorable duels and training."
			);

			AddStock<SmallBrickCastleDeed>(
				price:       75000,
				description: "A compact but formidable castle, adorned with Trinsic’s heraldry."
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
        public TrinsicReputationVendorStone(Serial serial) : base(serial) { }
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
