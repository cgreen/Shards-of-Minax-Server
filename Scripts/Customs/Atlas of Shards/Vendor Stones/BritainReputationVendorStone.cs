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
    public class BritainReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public BritainReputationVendorStone()
        {
            Name = "Britain Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Britain‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Britain property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Britain", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Britain faction level.
            //
			// inside BritainReputationVendorStone()
			
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
			
			
			// Britain Faction Power Scrolls (100 and 120 skill levels)
			AddStock<PowerScroll>(
				price:       250,
				title:       "Anatomy 100 Power Scroll",
				description: "A scroll that trains Anatomy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Anatomy 120 Power Scroll",
				description: "A scroll that trains Anatomy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 120;
				}
			);

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

			AddStock<PowerScroll>(
				price:       250,
				title:       "Healing 100 Power Scroll",
				description: "A scroll that trains Healing to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Healing;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Healing 120 Power Scroll",
				description: "A scroll that trains Healing to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Healing;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       250,
				title:       "Cooking 100 Power Scroll",
				description: "A scroll that trains Cooking to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cooking;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Cooking 120 Power Scroll",
				description: "A scroll that trains Cooking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Cooking;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       250,
				title:       "ItemID 100 Power Scroll",
				description: "A scroll that trains Item Identification to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.ItemID;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "ItemID 120 Power Scroll",
				description: "A scroll that trains Item Identification to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.ItemID;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       250,
				title:       "Forensics 100 Power Scroll",
				description: "A scroll that trains Forensics to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       500,
				title:       "Forensics 120 Power Scroll",
				description: "A scroll that trains Forensics to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Forensics;
					ps.Value = 120;
				}
			);
           
			
			AddStock<StonePlasterHouseDeed>(
				price:       6000,
				description: "A classic Britannian home of sturdy stone and plaster."
			);

			AddStock<TwoStoryStonePlasterHouseDeed>(
				price:       18000,
				description: "A grand two-story residence in the traditional Britannian style."
			);

			AddStock<TowerDeed>(
				price:       45000,
				description: "A tall stone tower — the mark of noble Britannian houses."
			);

			AddStock<KeepDeed>(
				price:       120000,
				description: "A formidable Britannian keep with inner courtyard. True power and prestige."
			);

			AddStock<CastleDeed>(
				price:       250000,
				description: "The legendary Britannian stone castle. Only for the realm’s most devoted."
			);

			AddStock<LargePatioDeed>(
				price:       24000,
				description: "A stately manor with an expansive open patio, perfect for gatherings."
			);

			AddStock<LargeMarbleDeed>(
				price:       28000,
				description: "A mansion of gleaming marble, fit for Britannian nobility."
			);

			AddStock<SmallTowerDeed>(
				price:       15000,
				description: "A modest tower home favored by up-and-coming Britons."
			);

			AddStock<PlainStoneHouseDeed>(
				price:       5500,
				description: "A humble stone house for the industrious citizen of Britain."
			);

			AddStock<TheCastleCascadeDeed>(
				price:       275000,
				description: "A breathtaking palace known for its cascading towers. The height of Britannian luxury."
			);

			AddStock<TheQueensRetreatKeepDeed>(
				price:       135000,
				description: "A royal retreat keep, once rumored to house the Queen herself."
			);

			AddStock<TheKeepCalmAndCarryOnKeepDeed>(
				price:       125000,
				description: "A fortified keep that embodies the Britannian spirit: calm and enduring."
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
        public BritainReputationVendorStone(Serial serial) : base(serial) { }
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
