using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Malik Al-Harith")]
    public class MalikAlHarith : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MalikAlHarith() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Malik Al-Harith";
            Body = 0x190; // Human male body

            // Unique Appearance: Legendary Sailor of Sohar (Oman)
            AddItem(new ElvenShirt() { Name = "Tunic of the Dhow Captain", Hue = 2301 });
            AddItem(new GuildedKilt() { Name = "Sash of the Spice Route", Hue = 1357 });
            AddItem(new Cloak() { Name = "Cloak of the Monsoon Winds", Hue = 1260 });
            AddItem(new Bandana() { Name = "Sea-Worn Headscarf", Hue = 1150 });
            AddItem(new Sandals() { Name = "Sandals of the Shifting Dunes", Hue = 2415 });
            AddItem(new BodySash() { Name = "Sash of Pearled Wisdom", Hue = 1153 });
            AddItem(new Scimitar() { Name = "Blade of the Indian Ocean", Hue = 1281 });

            SpeechHue = 1152;

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
                Say("I am Malik Al-Harith, once captain of the grandest dhow to sail from Sohar’s harbor.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a sailor, trader, and teller of secrets. The ocean’s currents are my roadways.");
            }
            else if (speech.Contains("health"))
            {
                Say("My bones creak like a ship’s hull, but my spirit is unbroken, as endless as the sea.");
            }
            else if (speech.Contains("oman"))
            {
                Say("Oman is the land where sand kisses the sea, home to merchants, poets, and dreamers.");
            }
            else if (speech.Contains("sohar"))
            {
                Say("Sohar is the jewel of the coast—my birthplace, and the starting point of many grand journeys.");
            }
            else if (speech.Contains("dhow"))
            {
                Say("The dhow is our mighty ship, swift upon the waves, her sails swollen with monsoon wind.");
            }
            else if (speech.Contains("monsoon"))
            {
                Say("Monsoon winds shape our fate, bringing rains, fortune, and sometimes, disaster.");
            }
            else if (speech.Contains("spice") || speech.Contains("trade"))
            {
                Say("Spices from Zanzibar, silk from India, and pearls from the Gulf—all found their way to Oman’s markets.");
            }
            else if (speech.Contains("pearl"))
            {
                Say("The Gulf’s pearls are coveted by kings and merchants alike, each a secret from the deep.");
            }
            else if (speech.Contains("captain"))
            {
                Say("A captain’s greatest duty is to his crew—and to the stories waiting on the horizon.");
            }
            else if (speech.Contains("indian ocean") || speech.Contains("sea"))
            {
                Say("The Indian Ocean is a highway of opportunity, but she has teeth as well as treasures.");
            }
            else if (speech.Contains("legend") || speech.Contains("story"))
            {
                Say("Some say I sailed farther than Sinbad himself, though I never did meet a roc—only storms and stars.");
            }
            else if (speech.Contains("sinbad"))
            {
                Say("Sinbad is both truth and tale in Oman—perhaps we all are, in time.");
            }
            else if (speech.Contains("ship") || speech.Contains("sailing"))
            {
                Say("A well-built ship is a friend for life. But tell me—do you know the secret of the caravel?");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is like a good compass—it keeps you off the reefs and toward brighter horizons.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert is silent, but she teaches patience, endurance, and respect for water.");
            }
            else if (speech.Contains("water") || speech.Contains("ocean"))
            {
                Say("Water remembers every voyage. The ocean whispers to those who listen deeply.");
            }
            else if (speech.Contains("star") || speech.Contains("navigation"))
            {
                Say("Stars guide us at night, silent friends shining above every sailor’s doubt.");
            }
			else if (speech.Contains("sultan"))
			{
				Say("The sultans of Oman once ruled from Zanzibar to Gwadar. Their word rode on the wind, and their ships shaped the world.");
			}
			else if (speech.Contains("zanzibar"))
			{
				Say("Zanzibar—jewel of the east. Our traders brought back cloves, ivory, and tales of distant sultans.");
			}
			else if (speech.Contains("ivory"))
			{
				Say("Ivory, smooth and pale as moonlight, fetched a high price. Yet the stories of its origin are bittersweet.");
			}
			else if (speech.Contains("crew"))
			{
				Say("A wise captain treasures his crew, for their laughter and loyalty can calm even the fiercest storm.");
			}
			else if (speech.Contains("storm"))
			{
				Say("Storms test a sailor’s mettle. Survive one, and you’ll know the true meaning of courage.");
			}
			else if (speech.Contains("fortune"))
			{
				Say("Fortune is a fickle tide. Today you haul pearls, tomorrow your nets come up empty.");
			}
			else if (speech.Contains("net"))
			{
				Say("A good net catches more than fish—sometimes, it catches lost letters and whispers from the deep.");
			}
			else if (speech.Contains("harbor"))
			{
				Say("Every harbor tells a story. Some are of joyful reunions, others of farewells whispered to the waves.");
			}
			else if (speech.Contains("map"))
			{
				Say("Maps? Ha! I trust the stars and the memory of currents more than any paper made by men.");
			}
			else if (speech.Contains("date"))
			{
				Say("Dates are the fruit of survival in Oman’s deserts. Sweetness, stored sunshine, and the taste of home.");
			}
			else if (speech.Contains("camel"))
			{
				Say("Camels are ships of the desert, just as dhows are ships of the sea—both patient, both stubborn.");
			}
			else if (speech.Contains("patience"))
			{
				Say("A sailor without patience soon becomes a story told by others, not by himself.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is like salt—you miss it when it’s lacking, but too much can spoil even the finest stew.");
			}
			else if (speech.Contains("stew"))
			{
				Say("Fish stew at dawn, with spices from Zanzibar, will warm even the coldest bones after a long voyage.");
			}
			else if (speech.Contains("music") || speech.Contains("song"))
			{
				Say("Songs of the sea echo in every Omani tavern. Listen closely, and you’ll hear legends between the notes.");
			}
			else if (speech.Contains("legend") || speech.Contains("tale"))
			{
				Say("The best legends grow with every telling—like a pearl forming in the deep.");
			}
			else if (speech.Contains("deep"))
			{
				Say("The deep sea keeps her secrets well. Only the bravest—or the luckiest—bring something back from her depths.");
			}
			else if (speech.Contains("lucky") || speech.Contains("luck"))
			{
				Say("Luck favors the bold, but a prudent sailor keeps a little for himself and gives thanks for the rest.");
			}			
            else if (speech.Contains("merchant"))
            {
                Say("A merchant’s true wealth is in the tales he brings home, not just the gold.");
            }
            else if (speech.Contains("caravel")) // *** SECRET REWARD KEYWORD ***
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, my friend. Even the most seasoned sailor must wait for the right tide.");
                }
                else
                {
                    Say("Ah, the caravel! Not every traveler knows of her. You have earned this Treasure Chest of Oman’s Golden Age. Use it well.");
                    from.AddToBackpack(new TreasureChestOfOman());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the monsoon winds always favor your sails.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Sohar, dhows, pearls, or the monsoon’s fortune. Who knows what tales you’ll unlock?");
                }
            }

            base.OnSpeech(e);
        }

        public MalikAlHarith(Serial serial) : base(serial) { }

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
