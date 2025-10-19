using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Francysk Skaryna")]
    public class FrancyskSkaryna : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public FrancyskSkaryna() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Francysk Skaryna";
            Body = 0x190; // Human male body

            // Unique Appearance: Belarusian Renaissance Scholar
            AddItem(new FormalShirt() { Name = "Skaryna's Embroidered Scholar's Tunic", Hue = 2120 });
            AddItem(new LongPants() { Name = "Printer’s Midnight Trousers", Hue = 2000 });
            AddItem(new Cloak() { Name = "Dniapro Cloak of Knowledge", Hue = 1367 });
            AddItem(new WideBrimHat() { Name = "Polatsk Renaissance Hat", Hue = 1178 });
            AddItem(new Boots() { Name = "Bookbinder’s Soft Boots", Hue = 2106 });
            AddItem(new BodySash() { Name = "Wisdom Sash of the Slavs", Hue = 1207 });

            // Unique Weapon/Tool
            AddItem(new MagicWand() { Name = "Quill of Enlightenment", Hue = 1437 });

            SpeechHue = 2109;
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
                Say("I am Francysk Skaryna of Polatsk, a humble servant of wisdom and print.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a printer, physician, and seeker of knowledge. Ask me of print, book, or wisdom.");
            }
            else if (speech.Contains("health"))
            {
                Say("My mind is ever restless, but my body weathers the ink and paper of long nights.");
            }
            else if (speech.Contains("print"))
            {
                Say("Printing brings light to the darkness of ignorance. In Prague, I printed the Bible for my people.");
            }
            else if (speech.Contains("book"))
            {
                Say("A book is a lantern for the soul. My printed books travel from Vilnius to Moscow.");
            }
            else if (speech.Contains("bible"))
            {
                Say("I printed the Bible in our own tongue so all might read and understand.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is greater than gold. Seek it in books, and you will find your true path.");
            }
            else if (speech.Contains("invention"))
            {
                Say("The printing press is the greatest invention of our age. It brings words to life.");
            }
            else if (speech.Contains("polatsk"))
            {
                Say("Polatsk is my birthplace, a city of learning upon the Dniapro river.");
            }
            else if (speech.Contains("belarus"))
            {
                Say("Belarus is a land of forests, rivers, and resilient people. Our spirit endures.");
            }
            else if (speech.Contains("language"))
            {
                Say("I love the Belarusian language. I wished for all to read in the tongue of our mothers.");
            }
            else if (speech.Contains("prague"))
            {
                Say("Prague was where I first set ink to paper, spreading knowledge far beyond borders.");
            }
            else if (speech.Contains("vilnius"))
            {
                Say("Vilnius welcomed my works, a city where cultures and faiths meet.");
            }
            else if (speech.Contains("moscow"))
            {
                Say("Even in Moscow, my books brought enlightenment and sometimes suspicion.");
            }
			else if (speech.Contains("university"))
			{
				Say("In Padua, I studied the secrets of medicine and the wonders of the human body. The university was a beacon of learning.");
			}
			else if (speech.Contains("padua"))
			{
				Say("Padua lies in Italy, famed for its scholars and its healing arts. There, I became both doctor and dreamer.");
			}
			else if (speech.Contains("doctor") || speech.Contains("medicine"))
			{
				Say("To heal is to serve. My knowledge of medicine has aided both noble and peasant alike.");
			}
			else if (speech.Contains("family"))
			{
				Say("I was born to a merchant family in Polatsk, where commerce brought stories from every corner of the world.");
			}
			else if (speech.Contains("renaissance"))
			{
				Say("The Renaissance brings new light to Europe—art, science, and free thought. Even in Belarus, the spark is felt.");
			}
			else if (speech.Contains("press") || speech.Contains("printing press"))
			{
				Say("The printing press is an instrument of change. With it, I scattered seeds of knowledge across lands and centuries.");
			}
			else if (speech.Contains("faith") || speech.Contains("religion"))
			{
				Say("Faith guides many paths. My wish was for every soul to find wisdom, regardless of creed or custom.");
			}
			else if (speech.Contains("travel") || speech.Contains("journey"))
			{
				Say("My journeys led me from Polatsk to Kraków, from Prague to Vienna, always seeking, always learning.");
			}
			else if (speech.Contains("krakow"))
			{
				Say("In Kraków, I learned much of science and the world’s order. Its streets are alive with students and ideas.");
			}
			else if (speech.Contains("vienna"))
			{
				Say("Vienna’s libraries are grand. There, I found books from distant lands, written in many tongues.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A true legacy is not gold, but the minds we inspire. What will your legacy be, traveler?");
			}
			else if (speech.Contains("freedom"))
			{
				Say("Freedom of thought is the birthright of all. A book unlocks the chains of ignorance.");
			}
			else if (speech.Contains("forest") || speech.Contains("forests"))
			{
				Say("Belarus is a land of endless forests—whispering birches and sturdy oaks—guardians of old secrets.");
			}
			else if (speech.Contains("river") || speech.Contains("dniapro"))
			{
				Say("The Dniapro river flows through my homeland, bringing life and carrying tales from ancient times.");
			}
			else if (speech.Contains("merchant"))
			{
				Say("My father was a merchant, and through his travels I learned the value of words as well as wares.");
			}
			else if (speech.Contains("tongue") || speech.Contains("tongues"))
			{
				Say("Every tongue is a treasure. I dreamed that my books would be read in the language of every hearth.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("The songs of Belarus are woven with sorrow and hope. Listen, and you may hear the voices of your ancestors.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We walk in the footsteps of those who came before. To remember is to honor their dreams.");
			}
			else if (speech.Contains("childhood"))
			{
				Say("In my childhood, the streets of Polatsk were filled with laughter, merchants, and scholars’ debates.");
			}
			else if (speech.Contains("debate") || speech.Contains("debates"))
			{
				Say("Debate sharpens the mind. Only through honest argument do we approach the truth.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is sometimes hidden beneath layers of silence. Seek it with courage and patience.");
			}			
            else if (speech.Contains("physician"))
            {
                Say("As a physician, I learned that healing the body is noble—but healing the mind is greater still.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("I must conserve my treasures for seekers of true knowledge. Return to me in due time.");
                }
                else
                {
                    Say("For your curiosity and pursuit of wisdom, take this Treasure Chest of Belarus—may it inspire you to seek knowledge always.");
                    from.AddToBackpack(new TreasureChestOfBelarus());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your mind remain ever bright and your path ever curious, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of book, printing, Polatsk, or the language of our people.");
                }
            }

            base.OnSpeech(e);
        }

        public FrancyskSkaryna(Serial serial) : base(serial) { }

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
