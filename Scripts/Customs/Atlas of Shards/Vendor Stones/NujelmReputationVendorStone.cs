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
    public class NujelmReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public NujelmReputationVendorStone()
        {
            Name = "Nujelm Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Nujelm‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Nujelm property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Nujelm", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Nujelm faction level.
            //
			// inside NujelmReputationVendorStone()
			// Nujel'm Power Scrolls - 100 and 120 Levels

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
				title:       "Begging 100 Power Scroll",
				description: "A scroll that trains Begging to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Begging;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Begging 120 Power Scroll",
				description: "A scroll that trains Begging to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Begging;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "TasteID 100 Power Scroll",
				description: "A scroll that trains Taste Identification to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "TasteID 120 Power Scroll",
				description: "A scroll that trains Taste Identification to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.TasteID;
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
				price:       400,
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
				title:       "Inscription 100 Power Scroll",
				description: "A scroll that trains Inscription to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Inscribe;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Inscription 120 Power Scroll",
				description: "A scroll that trains Inscription to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Inscribe;
					ps.Value = 120;
				}
			);

			AddStock<PowerScroll>(
				price:       150,
				title:       "Musicianship 100 Power Scroll",
				description: "A scroll that trains Musicianship to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Musicianship;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Musicianship 120 Power Scroll",
				description: "A scroll that trains Musicianship to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Musicianship;
					ps.Value = 120;
				}
			);
        
			AddStock<MarbleWorkshopDeed>(
				price:       12000,
				description: "A refined marble workshop, ideal for artisans."
			);

			AddStock<LargeMarbleDeed>(
				price:       35000,
				description: "An opulent large marble villa, symbol of luxury."
			);

			AddStock<CasaMogaDeed>(
				price:       32000,
				description: "An exotic Nujel’m-style palace, fit for nobility."
			);

			AddStock<DesertRoseDeed>(
				price:       28000,
				description: "A stunning Desert Rose residence, adorned with mosaics."
			);

			AddStock<TheSandstoneCastleDeed>(
				price:       75000,
				description: "A monumental sandstone castle, ultimate symbol of power."
			);

			AddStock<TheTerraceGardensDeed>(
				price:       20000,
				description: "A luxurious home with expansive terraced gardens."
			);

			AddStock<MarbleShoppeDeed>(
				price:       15000,
				description: "A sophisticated marble shoppe for high-class commerce."
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
        public NujelmReputationVendorStone(Serial serial) : base(serial) { }
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
