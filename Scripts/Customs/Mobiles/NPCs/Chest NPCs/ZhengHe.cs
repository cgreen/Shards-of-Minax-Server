using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Zheng He")]
    public class ZhengHe : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ZhengHe() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zheng He";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 75;
            Int = 105;
            Hits = 80;

            // Unique Appearance: Ming Dynasty Admiral
            AddItem(new FancyShirt() { Name = "Imperial Silk Tunic of the Seven Voyages", Hue = 1157 });
            AddItem(new FancyKilt() { Name = "Ming Sapphire Sash", Hue = 1325 });
            AddItem(new Cloak() { Name = "Navigator's Cloak of Star-Patterns", Hue = 2407 });
            AddItem(new TallStrawHat() { Name = "Voyager's Straw Hat of the Fleet", Hue = 2010 });
            AddItem(new Shoes() { Name = "Traveler's Lotus Shoes", Hue = 1181 });
            AddItem(new BodySash() { Name = "Crimson Explorer's Sash", Hue = 1161 });

            // Weapon: Scimitar renamed and hued
            AddItem(new Scimitar() { Name = "Jade Sea Blade of Zheng He", Hue = 1426 });

            SpeechHue = 2125;

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
            {
                Say("I am Zheng He, admiral of the Ming Treasure Fleet and servant of the Dragon Throne.");
            }
            else if (speech.Contains("job"))
            {
                Say("I led the emperor’s great armada to faraway lands, carrying silk, porcelain, and the will of China.");
            }
            else if (speech.Contains("health"))
            {
                Say("The sea air fills me with strength, though storms have taken their toll.");
            }
            else if (speech.Contains("voyage") || speech.Contains("voyages"))
            {
                Say("I sailed seven great voyages beyond the South Seas, braving storm and shadow.");
            }
            else if (speech.Contains("fleet"))
            {
                Say("My fleet was the wonder of the world—hundreds of mighty ships and thousands of men.");
            }
            else if (speech.Contains("ship") || speech.Contains("ships"))
            {
                Say("We sailed in great treasure ships, larger than palaces, bearing gifts for distant rulers.");
            }
            else if (speech.Contains("emperor"))
            {
                Say("The Yongle Emperor commanded me to show the glory of Ming to all under heaven.");
            }
            else if (speech.Contains("china"))
            {
                Say("China’s heart beats in its rivers and mountains, but its spirit sails the sea.");
            }
            else if (speech.Contains("sea") || speech.Contains("ocean"))
            {
                Say("The sea is endless, sometimes calm as jade, sometimes wild as dragons. My crew learned to respect its moods.");
            }
            else if (speech.Contains("crew") || speech.Contains("sailor") || speech.Contains("sailors"))
            {
                Say("My sailors were men of every province, skilled in craft and loyal to the red flag.");
            }
            else if (speech.Contains("star") || speech.Contains("stars"))
            {
                Say("We read the stars to guide our course, for without them, even the bravest ship is lost.");
            }
            else if (speech.Contains("map") || speech.Contains("maps"))
            {
                Say("Our maps grew with every journey, showing islands, spice ports, and realms unknown.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Spices from the Indies filled our holds—pepper, cinnamon, and the scent of adventure.");
            }
            else if (speech.Contains("adventure"))
            {
                Say("Each voyage brought new wonders—jungles, palaces, and strange animals never seen in China.");
            }
            else if (speech.Contains("animal") || speech.Contains("animals"))
            {
                Say("We brought giraffes from Africa, tribute for the emperor, symbols of heavenly harmony.");
            }
            else if (speech.Contains("tribute"))
            {
                Say("Gifts flowed both ways: gold and silk for distant rulers, pearls and ivory for China.");
            }
            else if (speech.Contains("ivory") || speech.Contains("pearl") || speech.Contains("pearls"))
            {
                Say("The treasures of the sea and the jungle, pearls and ivory, dazzled the court.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("True treasure lies in discovery and friendship, not in gold or gems.");
            }
			else if (speech.Contains("dragon") || speech.Contains("dragons"))
			{
				Say("The dragon is the emperor’s symbol—a sign of power, wisdom, and the deep mysteries of the sea.");
			}
			else if (speech.Contains("admiral"))
			{
				Say("As admiral, I bore the emperor’s trust and the fate of a thousand souls with every voyage.");
			}
			else if (speech.Contains("silk"))
			{
				Say("Chinese silk dazzled foreign courts—soft as the breeze, brilliant as the sun on water.");
			}
			else if (speech.Contains("porcelain"))
			{
				Say("Porcelain from Jingdezhen is called ‘white gold’ by foreign kings. Our gifts became legends.");
			}
			else if (speech.Contains("malacca") || speech.Contains("melaka"))
			{
				Say("Malacca’s sultans welcomed our fleet with feasts and songs. The straits were a gateway to the world.");
			}
			else if (speech.Contains("africa"))
			{
				Say("Africa was the farthest reach of our sails. Its people greeted us with respect, and its wonders astonished my men.");
			}
			else if (speech.Contains("jungles"))
			{
				Say("The jungles we found were alive with strange birds and fruit, their air heavy with the promise of secrets.");
			}
			else if (speech.Contains("emissary") || speech.Contains("diplomat") || speech.Contains("envoy"))
			{
				Say("Often, I served as emissary, bearing the words of the Son of Heaven to kings and chieftains alike.");
			}
			else if (speech.Contains("loyalty") || speech.Contains("loyal"))
			{
				Say("Loyalty to emperor and crew was my anchor in the shifting tides of fate.");
			}
			else if (speech.Contains("legend") || speech.Contains("legends"))
			{
				Say("Legends grow with every telling. My voyages became tales of dragons, storms, and golden cities.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A true legacy is not found in riches, but in the journeys that inspire new explorers.");
			}
			else if (speech.Contains("star chart") || speech.Contains("chart"))
			{
				Say("We drew new star charts, mapping heavens and seas alike. Each line brought the world closer.");
			}
			else if (speech.Contains("forbidden city"))
			{
				Say("The Forbidden City is the heart of the Ming—red walls, golden roofs, and the emperor’s silent gaze.");
			}
			else if (speech.Contains("mandate") || speech.Contains("heaven"))
			{
				Say("The Mandate of Heaven gave the emperor the right to rule. As his servant, I carried that mandate beyond the horizon.");
			}
			else if (speech.Contains("giant") || speech.Contains("giants"))
			{
				Say("Our treasure ships were giants of the sea—some said they were large enough to carry a thousand men.");
			}
			else if (speech.Contains("festival"))
			{
				Say("We celebrated festivals at sea—lanterns bright as stars, drums echoing over the waves.");
			}
			else if (speech.Contains("tea"))
			{
				Say("Tea was our comfort on long nights. Its warmth reminded us of home across the endless water.");
			}
			else if (speech.Contains("compass"))
			{
				Say("The compass was our silent guide, its needle pointing us toward new wonders and new dangers.");
			}
			else if (speech.Contains("scroll") || speech.Contains("scrolls"))
			{
				Say("We recorded our journeys on scrolls—drawings of distant coasts and tales of what we saw.");
			}
			else if (speech.Contains("friendship") || speech.Contains("friend"))
			{
				Say("Friendship was our greatest treasure. On distant shores, a shared meal could bridge all worlds.");
			}			
            else if (speech.Contains("calm"))
            {
                Say("In the calm between storms, we shared stories, mended sails, and watched the horizon.");
            }
            else if (speech.Contains("gift") || speech.Contains("gifts"))
            {
                // Gift is the reward keyword!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. Even the greatest gift requires time to prepare. Return soon.");
                }
                else
                {
                    Say("For your spirit of curiosity, I present you with a Treasure Chest of Chinese History. May you find wisdom and wonder within.");
                    from.AddToBackpack(new TreasureChestOfChineseHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("farewell") || speech.Contains("goodbye"))
            {
                Say("May the wind fill your sails and fortune guide your journey.");
            }
            else
            {
                // Random prompt for discovery
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of voyages, fleet, map, or the gifts we found across the world.");
                }
            }

            base.OnSpeech(e);
        }

        public ZhengHe(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write(lastRewardTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            lastRewardTime = reader.ReadDateTime();
        }
    }
}
