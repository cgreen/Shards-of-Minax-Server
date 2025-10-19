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
    public class SerpentsHoldReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public SerpentsHoldReputationVendorStone()
        {
            Name = "SerpentsHold Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s SerpentsHold‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.SerpentsHold property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("SerpentsHold", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their SerpentsHold faction level.
            //
			// inside SerpentsHoldReputationVendorStone()
			
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
			
			
			// Alchemy Scrolls
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
				price:       300,
				title:       "Alchemy 120 Power Scroll",
				description: "A scroll that trains Alchemy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Alchemy;
					ps.Value = 120;
				}
			);

			// Anatomy Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Anatomy 100 Power Scroll",
				description: "A scroll that trains Anatomy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Anatomy 120 Power Scroll",
				description: "A scroll that trains Anatomy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Anatomy;
					ps.Value = 120;
				}
			);

			// DetectHidden Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Detect Hidden 100 Power Scroll",
				description: "A scroll that trains Detect Hidden to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.DetectHidden;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Detect Hidden 120 Power Scroll",
				description: "A scroll that trains Detect Hidden to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.DetectHidden;
					ps.Value = 120;
				}
			);

			// Meditation Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Meditation 100 Power Scroll",
				description: "A scroll that trains Meditation to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Meditation;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Meditation 120 Power Scroll",
				description: "A scroll that trains Meditation to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Meditation;
					ps.Value = 120;
				}
			);

			// Poisoning Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Poisoning 100 Power Scroll",
				description: "A scroll that trains Poisoning to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Poisoning 120 Power Scroll",
				description: "A scroll that trains Poisoning to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 120;
				}
			);

			// SpiritSpeak Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Spirit Speak 100 Power Scroll",
				description: "A scroll that trains Spirit Speak to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Spirit Speak 120 Power Scroll",
				description: "A scroll that trains Spirit Speak to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 120;
				}
			);

			// Stealth Scrolls
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
				price:       300,
				title:       "Stealth 120 Power Scroll",
				description: "A scroll that trains Stealth to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Stealth;
					ps.Value = 120;
				}
			);

			// RemoveTrap Scrolls
			AddStock<PowerScroll>(
				price:       150,
				title:       "Remove Trap 100 Power Scroll",
				description: "A scroll that trains Remove Trap to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.RemoveTrap;
					ps.Value = 100;
				}
			);
			AddStock<PowerScroll>(
				price:       300,
				title:       "Remove Trap 120 Power Scroll",
				description: "A scroll that trains Remove Trap to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.RemoveTrap;
					ps.Value = 120;
				}
			);
         
			AddStock<StoneFortDeed>(
				price:       25000,
				description: "A well-fortified stone keep, built for defense."
			);

			AddStock<FortressOfLestatDeed>(
				price:       45000,
				description: "A grand stone fortress with impressive battlements."
			);

			AddStock<SpiresDeed>(
				price:       32000,
				description: "A striking residence with soaring towers and spires."
			);

			AddStock<FancyStoneWoodHomeDeed>(
				price:       16000,
				description: "A stately home crafted from fine stone and timber."
			);

			AddStock<SmallStoneTowerDeed>(
				price:       8000,
				description: "A compact stone tower for the aspiring defender."
			);

			AddStock<TowerDeed>(
				price:       30000,
				description: "A classic stone tower, visible from great distance."
			);

			AddStock<KeepDeed>(
				price:       75000,
				description: "A traditional fortified keep—iconic and formidable."
			);

			AddStock<TraditionalKeepDeed>(
				price:       82000,
				description: "A time-honored stronghold, revered by knights."
			);

			AddStock<CastleDeed>(
				price:      150000,
				description: "A massive castle, symbol of power and command."
			);

			AddStock<TheCastleCascadeDeed>(
				price:      175000,
				description: "A legendary castle with sweeping views and grandeur."
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
        public SerpentsHoldReputationVendorStone(Serial serial) : base(serial) { }
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
