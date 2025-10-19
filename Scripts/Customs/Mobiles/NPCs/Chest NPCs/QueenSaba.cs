using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Saba")]
    public class QueenSaba : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenSaba() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Saba";
            Title = "the Wise";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 70;
            Int = 120;
            Hits = 100;

            // Unique Outfit (All with unique names/hues)
            AddItem(new FancyDress() { Name = "Robe of Ancient Saba", Hue = 2957 });
            AddItem(new BodySash() { Name = "Sash of Red Sea Gold", Hue = 2112 });
            AddItem(new Sandals() { Name = "Sandals of D'mt", Hue = 2635 });
            AddItem(new Circlet() { Name = "Crown of Sheba", Hue = 2415 });
            AddItem(new Cloak() { Name = "Cloak of Incense Winds", Hue = 1359 });

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Scepter of Makeda", Hue = 1177 });

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
                Say("I am Saba, once called Makeda, Queen of Sheba and guardian of Eritrea’s ancient secrets.");
            }
            else if (speech.Contains("job"))
            {
                Say("I ruled over Saba, a kingdom where the frankincense winds carried stories beyond the Red Sea.");
            }
            else if (speech.Contains("health"))
            {
                Say("The body may age, but the wisdom of Sheba endures across the sands and centuries.");
            }
            else if (speech.Contains("sheba"))
            {
                Say("Sheba, my kingdom, flourished where the incense caravans met the sea. Seek knowledge in the echoes of the past.");
            }
            else if (speech.Contains("eritrea"))
            {
                Say("Eritrea’s coasts saw the birth of legends and merchants. Its mountains still hold my footprints.");
            }
            else if (speech.Contains("makeda"))
            {
                Say("Makeda is the name my mother whispered. Saba is the legacy I left upon the world.");
            }
            else if (speech.Contains("red sea"))
            {
                Say("The Red Sea shimmers with the gold of traders, and reflects the journeys of queens and kings.");
            }
            else if (speech.Contains("frankincense"))
            {
                Say("Frankincense—the holy gift—was once worth its weight in gold. Its scent still haunts the temples.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold bought many things, but wisdom and peace are not found in coins.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My true legacy is the knowledge shared and the peace woven among distant peoples.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is a river: always flowing, always seeking the sea. Ask, and you may learn something precious.");
            }
            else if (speech.Contains("ethiopia"))
            {
                Say("Eritrea and Ethiopia were once sister lands. Our stories entwined like roots beneath the earth.");
            }
            else if (speech.Contains("king"))
            {
                Say("Some call me queen, some call me king. In my land, strength and wisdom held the crown.");
            }
            else if (speech.Contains("temple"))
            {
                Say("In the temples of Yeha and Adulis, prayers rose like incense to the heavens.");
            }
            else if (speech.Contains("adulis"))
            {
                Say("Adulis was the jewel of the coast, a city where Roman, Arab, and African traders met.");
            }
            else if (speech.Contains("caravan"))
            {
                Say("The incense caravans crossed deserts and mountains, their stories whispering through every grain of sand.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert tests all travelers. Its silence remembers every secret and every promise.");
            }
            else if (speech.Contains("promise"))
            {
                Say("A promise, like incense, lingers in the air long after it is spoken.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A true queen serves her people and listens to the wind and the wisdom of elders.");
            }
            else if (speech.Contains("wind") || speech.Contains("winds"))
            {
                Say("The winds carry tales from distant lands. Listen closely, and you may learn of places unseen.");
            }
            else if (speech.Contains("trade") || speech.Contains("trader"))
            {
                Say("Trade built empires on these coasts. Ivory, myrrh, and incense shaped our destiny.");
            }
            else if (speech.Contains("myrrh"))
            {
                Say("Myrrh was gathered from wild thorn trees, as precious as any treasure to ancient healers.");
            }
            else if (speech.Contains("ivory"))
            {
                Say("Ivory, white as the moon, journeyed from the African heart to the palaces of Rome.");
            }
            else if (speech.Contains("secrets"))
            {
                Say("All true seekers crave secrets. Some are written in stone, others are hidden in scent and song.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("The songs of Saba told of stars, rivers, and the meeting of distant souls.");
            }
			else if (speech.Contains("ancestors"))
			{
				Say("My ancestors built great stone circles, and their wisdom echoes in the mountains of Eritrea.");
			}
			else if (speech.Contains("yeha"))
			{
				Say("Yeha is the oldest temple of these lands, its stones kissed by both sun and prayer.");
			}
			else if (speech.Contains("stone"))
			{
				Say("Stone remembers what people forget. Our temples, our roads, even our names are etched in the rock.");
			}
			else if (speech.Contains("trade route") || speech.Contains("routes"))
			{
				Say("The ancient trade routes linked Saba to Egypt, Rome, India, and beyond. Their paths still cross beneath the shifting sands.");
			}
			else if (speech.Contains("lion") || speech.Contains("lions"))
			{
				Say("The lion walks with pride through my homeland. To walk with courage is to walk with the lion’s spirit.");
			}
			else if (speech.Contains("oracle") || speech.Contains("prophecy"))
			{
				Say("The oracles of Saba spoke with the voice of the wind. Sometimes their prophecies arrived with the morning dew.");
			}
			else if (speech.Contains("rain") || speech.Contains("rainfall"))
			{
				Say("Rain is both a blessing and a memory. It brings green to the dry earth and hope to weary travelers.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("The mountains watch in silence. Their peaks remember every crown and every fallen star.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Under the stars, my people danced and told stories that stitched the night with wonder.");
			}
			else if (speech.Contains("faith") || speech.Contains("belief"))
			{
				Say("Faith is the light within, brighter than gold, stronger than stone.");
			}
			else if (speech.Contains("heart"))
			{
				Say("The heart of a queen must be strong yet gentle, like the acacia tree in the desert wind.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the first kingdom we know, the one we defend most fiercely.");
			}
			else if (speech.Contains("peace"))
			{
				Say("True peace is not the silence after war, but the laughter of children, the song of birds, and the promise of tomorrow.");
			}
			else if (speech.Contains("journey") || speech.Contains("travel"))
			{
				Say("Every journey shapes the soul. Walk the land with respect, and she will reveal her secrets to you.");
			}
			else if (speech.Contains("camel") || speech.Contains("camels"))
			{
				Say("Camels are the ships of the desert, carrying dreams and treasures from coast to coast.");
			}
			else if (speech.Contains("treasure"))
			{
				Say("Not all treasures glitter. The truest riches are knowledge, kindness, and the stories we share.");
			}
			else if (speech.Contains("mirror"))
			{
				Say("The Red Sea is a mirror to the sky, and sometimes to the soul. Gaze deeply, and see what is reflected.");
			}			
            else if (speech.Contains("river"))
            {
                Say("Rivers bring life to the driest land, just as wisdom brings hope to the darkest hour.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the light that led my caravans through storm and sand alike.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("incense"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the sweetest incense must not be burned too quickly, patient traveler.");
                }
                else
                {
                    Say("You have followed the path of the ancients. Take this Treasure Chest of Eritrean Legacy—may its mysteries enrich your journey.");
                    from.AddToBackpack(new TreasureChestOfEritreanLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go in peace. May the winds of Sheba guide your way, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of incense, Sheba, Adulis, or the secrets of Eritrea’s sands.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenSaba(Serial serial) : base(serial) { }

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
