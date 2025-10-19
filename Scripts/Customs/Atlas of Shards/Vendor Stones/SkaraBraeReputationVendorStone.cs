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
    public class SkaraBraeReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public SkaraBraeReputationVendorStone()
        {
            Name = "SkaraBrae Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s SkaraBrae‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.SkaraBrae property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("SkaraBrae", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their SkaraBrae faction level.
            //
			// inside SkaraBraeReputationVendorStone()
			// Skara Brae Faction Powerscroll Vendor Stock

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


			// Musicianship
			AddStock<PowerScroll>(
				price:       100,
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

			// Peacemaking
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

			AddStock<PowerScroll>(
				price:       400,
				title:       "Peacemaking 120 Power Scroll",
				description: "A scroll that trains Peacemaking to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Peacemaking;
					ps.Value = 120;
				}
			);

			// Provocation
			AddStock<PowerScroll>(
				price:       100,
				title:       "Provocation 100 Power Scroll",
				description: "A scroll that trains Provocation to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Provocation;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Provocation 120 Power Scroll",
				description: "A scroll that trains Provocation to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Provocation;
					ps.Value = 120;
				}
			);

			// Camping
			AddStock<PowerScroll>(
				price:       100,
				title:       "Camping 100 Power Scroll",
				description: "A scroll that trains Camping to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Camping 120 Power Scroll",
				description: "A scroll that trains Camping to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Camping;
					ps.Value = 120;
				}
			);

			// SpiritSpeak
			AddStock<PowerScroll>(
				price:       100,
				title:       "SpiritSpeak 100 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "SpiritSpeak 120 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 120;
				}
			);

			// Discordance
			AddStock<PowerScroll>(
				price:       100,
				title:       "Discordance 100 Power Scroll",
				description: "A scroll that trains Discordance to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Discordance;
					ps.Value = 100;
				}
			);

			AddStock<PowerScroll>(
				price:       400,
				title:       "Discordance 120 Power Scroll",
				description: "A scroll that trains Discordance to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Discordance;
					ps.Value = 120;
				}
			);
       
			AddStock<ThatchedRoofCottageDeed>(
				price:       4800,
				description: "A cozy cottage with a classic thatched roof—perfect for woodland living."
			);

			AddStock<SmallWoodenShackPorchDeed>(
				price:       4200,
				description: "A modest shack with a porch, blending into the Skara Brae wilds."
			);

			AddStock<RobinsNestDeed>(
				price:       5300,
				description: "A charming home inspired by the forest dwellings of Skara Brae’s pioneers."
			);

			AddStock<RobinsRoostDeed>(
				price:       5500,
				description: "A rustic, two-story woodland home beloved by Skara Brae’s hunters and gatherers."
			);

			AddStock<RaisedBrickHomeDeed>(
				price:       5600,
				description: "A simple brick home, raised against the marshes and mists."
			);

			AddStock<SmallStoneShoppeDeed>(
				price:       4600,
				description: "A quaint stone shop, ideal for craftsfolk and herbalists."
			);

			AddStock<TheTerraceGardensDeed>(
				price:       6800,
				description: "A home with open terraces and lush gardens for those attuned to nature."
			);

			// --- Larger, more prestigious homes ---

			AddStock<ThreeStoryStoneVillaDeed>(
				price:       17000,
				description: "A grand stone villa with three floors—status and comfort for the elite of Skara Brae."
			);

			// --- Skara-adjacent or rare rustic homes ---

			AddStock<PlainPlasterHouseDeed>(
				price:       4000,
				description: "A simple plaster house, common among the modest folk of the Spiritwood."
			);

			AddStock<FieldStoneHouseDeed>(
				price:       4100,
				description: "A small, sturdy house built of local fieldstone."
			);

			// --- Keeps/castles for prestige (expensive!) ---

			AddStock<KeepDeed>(
				price:       100000,
				description: "A mighty stone keep, rarely seen outside Britannia’s lords—status symbol for Skara’s most trusted."
			);

			AddStock<CastleDeed>(
				price:       200000,
				description: "A towering woodland castle, surrounded by nature. Reserved for the legendary protectors of Skara Brae."
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
        public SkaraBraeReputationVendorStone(Serial serial) : base(serial) { }
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
