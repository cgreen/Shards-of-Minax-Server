using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the memory of Scheherazade")]
    public class Scheherazade : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Scheherazade() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Scheherazade";
            Body = 0x191; // Human female body

            // Unique Arabian Storyteller Outfit
            AddItem(new FancyDress() { Name = "Scheherazade’s Robe of Tales", Hue = 1167 });
            AddItem(new BodySash() { Name = "Sash of Desert Moons", Hue = 2125 });
            AddItem(new Cloak() { Name = "Veil of Whispered Secrets", Hue = 2412 });
            AddItem(new Sandals() { Name = "Sandswept Slippers", Hue = 2707 });
            AddItem(new FeatheredHat() { Name = "Crown of One Thousand Nights", Hue = 1150 });
            AddItem(new FlowerGarland() { Name = "Garland of Jasmine", Hue = 2106 });

            // Mystical staff as accessory
            AddItem(new GnarledStaff() { Name = "Staff of Stories", Hue = 1160 });

            SpeechHue = 2123;
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
                Say("I am Scheherazade, whose stories shaped the dawn and soothed the sultan’s sleepless nights.");
            }
            else if (speech.Contains("job"))
            {
                Say("Storyteller, historian, dreamweaver. My tales span from Baghdad to forgotten ruins beneath the sands.");
            }
            else if (speech.Contains("health"))
            {
                Say("As long as there are listeners, my heart is strong and my voice endures.");
            }
            else if (speech.Contains("baghdad"))
            {
                Say("Baghdad, the City of Peace! Once a jewel of the caliphate, where knowledge and magic intertwined.");
            }
            else if (speech.Contains("caliphate"))
            {
                Say("Under the caliphs, scholars and poets thrived. Do you seek stories of treasure, or wisdom?");
            }
            else if (speech.Contains("sands"))
            {
                Say("The desert sands hold both peril and promise. Many seek the secrets buried beneath—have you heard of the djinn?");
            }
            else if (speech.Contains("djinn"))
            {
                Say("The djinn are spirits of wind and flame. Some bring fortune, others mischief. Legends speak of the lamp that commands them.");
            }
            else if (speech.Contains("lamp"))
            {
                Say("A humble lamp can hold mighty power—if you are clever, and kind. True treasure is often hidden in plain sight.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Ah, treasure! Not only gold, but emeralds, sapphires, and the wisdom of the ancients. Would you claim a chest of Arabia’s sands?");
            }
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every night, I spun stories to enchant the sultan—tales of adventure, of love and danger. Would you hear of Sinbad, or perhaps the city of Samarkand?");
			}
			else if (speech.Contains("sinbad"))
			{
				Say("Sinbad the Sailor braved storms and monsters upon endless seas. His voyages brought him face to face with the roc and the old man of the sea.");
			}
			else if (speech.Contains("roc"))
			{
				Say("The roc is a bird as large as a mountain, whose shadow can darken the sun. Only the bravest would seek its hidden eggs.");
			}
			else if (speech.Contains("old man of the sea"))
			{
				Say("A cunning creature, clinging to a traveler’s back, never letting go. Escape came only with cleverness and courage.");
			}
			else if (speech.Contains("samarkand"))
			{
				Say("Samarkand gleamed like a sapphire on the Silk Road—merchants and scholars mingled in its gardens. It is said that even the great Alexander visited.");
			}
			else if (speech.Contains("alexander"))
			{
				Say("Alexander, known as 'Iskander' to the east, sought the edge of the world. His journeys are the stuff of legend.");
			}
			else if (speech.Contains("legend") || speech.Contains("legends"))
			{
				Say("Legends grow with each telling. Some say the river of life flows through the hidden city of Iram, lost beneath the sands.");
			}
			else if (speech.Contains("iram"))
			{
				Say("Iram of the Pillars, city of wonder and pride, vanished in a single night. Some seek it still, hoping for riches or redemption.");
			}
			else if (speech.Contains("wish") || speech.Contains("wishes"))
			{
				Say("Three wishes can change a life, but beware: the greatest treasures are sometimes the heaviest burdens.");
			}
			else if (speech.Contains("sultan"))
			{
				Say("The sultan listened each night, hoping for a tale he had not heard. In stories, we find hope—and sometimes, freedom.");
			}
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is a story we must write for ourselves, even if we are trapped by fate or by fear.");
			}
			else if (speech.Contains("magic"))
			{
				Say("Magic lingers in words, in old lamps, and in the heart of every listener. Perhaps, with the right question, you will discover it too.");
			}			
            else if (speech.Contains("chest") || speech.Contains("reward"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("My treasures must rest before they are granted again. Return to me when the stars next align.");
                }
                else
                {
                    Say("For the seeker who follows the thread of tales, accept this: the TreasureChestOfArabiasSands. May your story be ever wondrous.");
                    from.AddToBackpack(new TreasureChestOfArabiasSands());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path be lit by the moon, and your dreams be filled with wonder.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.15)
                {
                    Say("Ask me of Baghdad, djinn, or the treasures of the desert. The right word opens a new tale.");
                }
            }

            base.OnSpeech(e);
        }

        public Scheherazade(Serial serial) : base(serial) { }

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
