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
    public class JhelomReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public JhelomReputationVendorStone()
        {
            Name = "Jhelom Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Jhelom‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Jhelom property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Jhelom", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Jhelom faction level.
            //
			// inside JhelomReputationVendorStone()
			// Wrestling 100 Power Scroll
			
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
				title:       "Wrestling 100 Power Scroll",
				description: "A scroll that trains Wrestling to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Wrestling;
					ps.Value = 100;
				}
			);

			// Wrestling 120 Power Scroll
			AddStock<PowerScroll>(
				price:       600,
				title:       "Wrestling 120 Power Scroll",
				description: "A scroll that trains Wrestling to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Wrestling;
					ps.Value = 120;
				}
			);

			// Fencing 100 Power Scroll
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

			// Fencing 120 Power Scroll
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

			// Tactics 100 Power Scroll
			AddStock<PowerScroll>(
				price:       200,
				title:       "Tactics 100 Power Scroll",
				description: "A scroll that trains Tactics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 100;
				}
			);

			// Tactics 120 Power Scroll
			AddStock<PowerScroll>(
				price:       600,
				title:       "Tactics 120 Power Scroll",
				description: "A scroll that trains Tactics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Tactics;
					ps.Value = 120;
				}
			);

			// Parry 100 Power Scroll
			AddStock<PowerScroll>(
				price:       200,
				title:       "Parry 100 Power Scroll",
				description: "A scroll that trains Parry to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Parry;
					ps.Value = 100;
				}
			);

			// Parry 120 Power Scroll
			AddStock<PowerScroll>(
				price:       600,
				title:       "Parry 120 Power Scroll",
				description: "A scroll that trains Parry to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Parry;
					ps.Value = 120;
				}
			);

			// Anatomy 100 Power Scroll
			AddStock<PowerScroll>(
				price:       200,
				title:       "Anatomy 100 Power Scroll",
				description: "A scroll that trains Anatomy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 100;
				}
			);

			// Anatomy 120 Power Scroll
			AddStock<PowerScroll>(
				price:       600,
				title:       "Anatomy 120 Power Scroll",
				description: "A scroll that trains Anatomy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 120;
				}
			);

			// Focus 100 Power Scroll
			AddStock<PowerScroll>(
				price:       200,
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
				price:       600,
				title:       "Focus 120 Power Scroll",
				description: "A scroll that trains Focus to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Focus;
					ps.Value = 120;
				}
			);
          
			AddStock<LogCabinDeed>(
				price:       5000,
				description: "A sturdy cabin of rough-hewn logs, perfect for the hardy."
			);

			AddStock<SmallBrickHouseDeed>(
				price:       6500,
				description: "A compact, brick-walled house, built for defense."
			);

			AddStock<StonePlasterHouseDeed>(
				price:       7500,
				description: "A classic stone-and-plaster home, favored by Jhelom’s veterans."
			);

			AddStock<BrickHouseDeed>(
				price:       8500,
				description: "A larger, two-room brick home for established fighters."
			);

			AddStock<WoodHouseDeed>(
				price:       6000,
				description: "A practical, no-nonsense wooden dwelling."
			);

			AddStock<ThatchedRoofCottageDeed>(
				price:       6800,
				description: "A simple thatched cottage—humble but homey."
			);

			AddStock<SmallTowerDeed>(
				price:       15000,
				description: "A compact two-story tower—easy to defend, with great visibility."
			);

			AddStock<TwoStoryStonePlasterHouseDeed>(
				price:       17000,
				description: "A solid two-story house of stone and plaster for families or squads."
			);

			AddStock<StoneFortDeed>(
				price:       24000,
				description: "A stone-walled fort, designed for defense and group living."
			);

			AddStock<VillaDeed>(
				price:       18500,
				description: "A larger, villa-style home with room for guests and trophies."
			);

			AddStock<TwoStoryBrickHomeDeed>(
				price:       22000,
				description: "A tall, brick manor suited for retired champions."
			);

			AddStock<TowerDeed>(
				price:       35000,
				description: "A proper stone tower, iconic on Jhelom’s skyline."
			);

			AddStock<KeepDeed>(
				price:       60000,
				description: "A mighty keep—bastion of valor, symbol of Jhelom’s strength."
			);

			AddStock<TrinsicKeepDeed>(
				price:       70000,
				description: "A grand, fortified keep, built for holding the line."
			);

			AddStock<CastleDeed>(
				price:       120000,
				description: "A legendary stone castle, only for the most valiant and dedicated."
			);

			AddStock<TraditionalKeepDeed>(
				price:       90000,
				description: "A time-honored, multi-story keep; massive and secure."
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
        public JhelomReputationVendorStone(Serial serial) : base(serial) { }
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
