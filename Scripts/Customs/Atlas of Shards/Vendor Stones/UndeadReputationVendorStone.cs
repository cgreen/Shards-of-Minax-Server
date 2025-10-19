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
    public class UndeadReputationVendorStone : StoneRewardVendor
    {
        [Constructable]
        public UndeadReputationVendorStone()
        {
            Name = "Undead Reputation Vendor";
            Hue  = 1161;    // choose whatever hue you like
            Movable = false;

            //
            // 1) Bind our vendor’s “coins” to the player’s Undead‐faction value.
            //
            //    - bindedTo:   we just need an instance whose type is Mobile, so we pass a new PlayerMobile()
            //    - attachType: the attachment type that holds the faction data
            //    - attachProp: the XmlMobFactions.Undead property
            //
            var attachType = typeof(XmlMobFactions);
            var prop       = attachType.GetProperty("Undead", BindingFlags.Public | BindingFlags.Instance);

            ((IRewardVendor)this).Payment = new Currency(
                bindedTo:   new PlayerMobile(), 
                attachType: attachType,
                attachProp: prop
            );

            //
            // 2) Add whatever stock you like.  Players will “pay” by reducing their Undead faction level.
            //
			// inside UndeadReputationVendorStone()
			
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
			
			
			// Necromancy 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
				title:       "Necromancy 100 Power Scroll",
				description: "A scroll that trains Necromancy to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Necromancy;
					ps.Value = 100;
				}
			);

			// Necromancy 120 Power Scroll
			AddStock<PowerScroll>(
				price:       50,
				title:       "Necromancy 120 Power Scroll",
				description: "A scroll that trains Necromancy to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Necromancy;
					ps.Value = 120;
				}
			);

			// SpiritSpeak 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
				title:       "SpiritSpeak 100 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 100;
				}
			);

			// SpiritSpeak 120 Power Scroll
			AddStock<PowerScroll>(
				price:       50,
				title:       "SpiritSpeak 120 Power Scroll",
				description: "A scroll that trains SpiritSpeak to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.SpiritSpeak;
					ps.Value = 120;
				}
			);

			// Poisoning 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
				title:       "Poisoning 100 Power Scroll",
				description: "A scroll that trains Poisoning to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 100;
				}
			);

			// Poisoning 120 Power Scroll
			AddStock<PowerScroll>(
				price:       50,
				title:       "Poisoning 120 Power Scroll",
				description: "A scroll that trains Poisoning to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Poisoning;
					ps.Value = 120;
				}
			);

			// Meditation 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
				title:       "Meditation 100 Power Scroll",
				description: "A scroll that trains Meditation to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Meditation;
					ps.Value = 100;
				}
			);

			// Meditation 120 Power Scroll
			AddStock<PowerScroll>(
				price:       50,
				title:       "Meditation 120 Power Scroll",
				description: "A scroll that trains Meditation to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Meditation;
					ps.Value = 120;
				}
			);

			// Wrestling 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
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
				price:       50,
				title:       "Wrestling 120 Power Scroll",
				description: "A scroll that trains Wrestling to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Wrestling;
					ps.Value = 120;
				}
			);

			// Hiding 100 Power Scroll
			AddStock<PowerScroll>(
				price:       25,
				title:       "Hiding 100 Power Scroll",
				description: "A scroll that trains Hiding to 100",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 100;
				}
			);

			// Hiding 120 Power Scroll
			AddStock<PowerScroll>(
				price:       50,
				title:       "Hiding 120 Power Scroll",
				description: "A scroll that trains Hiding to 120",
				configure:   ps =>
				{
					ps.Skill = SkillName.Hiding;
					ps.Value = 120;
				}
			);

			AddStock<GothicRoseCastleDeed>(
				price:       150000,
				description: "A grand, gothic castle shrouded in eternal gloom."
			);

			AddStock<GrimswindSistersDeed>(
				price:       90000,
				description: "A haunted mansion echoing with the voices of the lost."
			);

			AddStock<TheRavenloftKeepDeed>(
				price:       200000,
				description: "An imposing keep said to be cursed by ancient powers."
			);

			AddStock<DarkthornKeepDeed>(
				price:       160000,
				description: "A dark and twisted fortress woven with wicked thorns."
			);

			AddStock<KeepIncarceratedDeed>(
				price:       175000,
				description: "A dreaded keep that once served as a prison for the damned."
			);

			AddStock<TheHouseBuiltOnTheRuinsDeed>(
				price:       35000,
				description: "A shattered manor raised atop ancient, crumbling ruins."
			);

			AddStock<TheRavenloftKeepDeed>(
				price:       220000,
				description: "A legendary keep veiled in perpetual shadow."
			);

			AddStock<SmallBrickCastleDeed>(
				price:       90000,
				description: "A modest, brooding castle favored by minor lich lords."
			);

			AddStock<TheDragonstoneCastleDeed>(
				price:       180000,
				description: "A castle of black stone, carved with ominous draconic runes."
			);

			AddStock<SmallStoneTowerDeed>(
				price:       12000,
				description: "A lone stone tower, perfect for a solitary necromancer."
			);
          
			
			AddStock<RecallRune>(
                price:       5,
                description: "A blank recall rune, inscribed with your glyph."
            );

            AddStock<Bandage>(
                price:       2,
                description: "A bundle of 100 clean bandages.",
                configure:   b => b.Amount = 100
            );

            AddStock<GreaterHealPotion>(
                price:       10,
                description: "A strong healing potion."
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
        public UndeadReputationVendorStone(Serial serial) : base(serial) { }
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
