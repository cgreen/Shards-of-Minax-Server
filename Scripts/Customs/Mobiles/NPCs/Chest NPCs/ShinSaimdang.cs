using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the gentle spirit of Shin Saimdang")]
    public class ShinSaimdang : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ShinSaimdang() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Shin Saimdang";
            Body = 0x191; // Human female body

            // Unique Appearance: Korean Scholar-Artist
            AddItem(new FemaleKimono() { Name = "Silken Hanbok of the Willow", Hue = 2118 });
            AddItem(new ElvenShirt() { Name = "Scholar’s Undershirt of Tranquility", Hue = 1175 });
            AddItem(new FancyKilt() { Name = "Blue Skirt of the Han River", Hue = 1057 });
            AddItem(new FlowerGarland() { Name = "Lotus Crown of Saimdang", Hue = 1161 });
            AddItem(new Sandals() { Name = "Steps of the Scholar’s Path", Hue = 2515 });
            AddItem(new BodySash() { Name = "Sash of Brushstrokes", Hue = 2425 });
            AddItem(new ScribeSword() { Name = "Inkbrush Blade of Inspiration", Hue = 2001 });

            SpeechHue = 1153;

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
                Say("I am Shin Saimdang, painter of nature, poet of wisdom, and humble mother.");
            }
            else if (speech.Contains("job"))
            {
                Say("My calling is to bring beauty into the world through art and the written word. Many know me as an artist and scholar.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit remains calm as still water, for the mind’s peace is the greatest health.");
            }
            else if (speech.Contains("artist"))
            {
                Say("Brush and ink are my companions. Through painting and poetry, I seek to reflect the harmony of nature.");
            }
            else if (speech.Contains("mother"))
            {
                Say("A mother’s guidance shapes destinies. My son Yulgok carried forward the light of learning.");
            }
            else if (speech.Contains("scholar"))
            {
                Say("To be a scholar is to pursue truth and virtue. Confucian teachings guide my heart.");
            }
            else if (speech.Contains("calligraphy"))
            {
                Say("With a single stroke, calligraphy captures a lifetime of learning. True inspiration flows from within.");
            }
            else if (speech.Contains("poetry") || speech.Contains("poet"))
            {
                Say("Through poetry, the heart may speak what words cannot. Listen to the whispers of the wind and you may hear verses old as the mountains.");
            }
            else if (speech.Contains("nature"))
            {
                Say("Flowers, willows, and rivers—each is a teacher in its own way. I often paint the lotus, symbol of purity.");
            }
            else if (speech.Contains("lotus"))
            {
                Say("The lotus rises pure from the mud, untouched by its surroundings. In it, I find inspiration for both art and life.");
            }
            else if (speech.Contains("yulgok"))
            {
                Say("Yulgok, my beloved son, became a beacon of wisdom for our nation. His legacy is one of intellect and service.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("True legacy is not gold or title, but the wisdom and kindness we pass on. Our heritage is a living treasure.");
            }
            else if (speech.Contains("heritage"))
            {
                Say("Korean heritage is a tapestry of honor, diligence, and beauty—woven through centuries by those who came before.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is found in gentle words and patient hearts. Harmony with oneself and others is the highest art.");
            }
            else if (speech.Contains("harmony"))
            {
                Say("To live in harmony is to be like the willow—strong, yet yielding to the wind.");
            }
            else if (speech.Contains("willow"))
            {
                Say("The willow bends gracefully, never breaking in the storm. In adversity, there is beauty.");
            }
			else if (speech.Contains("paint") || speech.Contains("painting"))
			{
				Say("Each painting is a silent poem. With ink and color, I share the beauty I see in the world.");
			}
			else if (speech.Contains("ink"))
			{
				Say("Ink flows like a river—steady, patient. A careless hand may spoil the page, but a mindful heart brings harmony.");
			}
			else if (speech.Contains("hanbok"))
			{
				Say("The hanbok’s flowing lines speak of grace and tradition. Its colors hold the memory of festivals long past.");
			}
			else if (speech.Contains("festival") || speech.Contains("festivals"))
			{
				Say("Chuseok and Seollal bring families together. On these days, our hearts are reminded of ancestors and gratitude.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We honor our ancestors through memory and ritual. Their guidance is a quiet voice in every wise decision.");
			}
			else if (speech.Contains("garden"))
			{
				Say("In my garden, even the smallest stone or flower has its place. Nature’s harmony is a lesson for all.");
			}
			else if (speech.Contains("river"))
			{
				Say("The river moves ever forward, unhurried yet unstoppable. Patience and perseverance are its gifts.");
			}
			else if (speech.Contains("teaching") || speech.Contains("teacher"))
			{
				Say("A true teacher inspires curiosity, not fear. Learning is a lifelong journey, best walked with humility.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the seeds of the future. Nurture them with kindness and they will blossom in unexpected ways.");
			}
			else if (speech.Contains("beauty"))
			{
				Say("Beauty is found in simple things—a dew-kissed leaf, a soft word, the smile of a friend.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Music soothes the weary heart. I often hum melodies as I paint, letting inspiration dance with the tune.");
			}
			else if (speech.Contains("brush"))
			{
				Say("A brush is a bridge between thought and paper. Treat it gently, and it will reveal your truest self.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the strength to act with compassion in its presence.");
			}
			else if (speech.Contains("history"))
			{
				Say("History is a tapestry of many hands. Even small acts, when remembered, become threads of greatness.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon above reminds us that beauty can shine even in darkness. Its calm light inspires poets and painters alike.");
			}
			else if (speech.Contains("respect"))
			{
				Say("To offer respect is to see the heart of another. In respect, we find the roots of peace.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Seek peace within yourself first; only then can you bring harmony to the world around you.");
			}			
            else if (speech.Contains("confucian") || speech.Contains("confucianism"))
            {
                Say("Confucian teachings urge us to cultivate virtue and serve family and nation. Let your deeds be a reflection of your heart.");
            }
            else if (speech.Contains("flower") || speech.Contains("flowers"))
            {
                Say("A single flower can brighten a whole room. Even the smallest act of kindness spreads beauty.");
            }
            else if (speech.Contains("inspiration"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True inspiration cannot be forced—return after some time, and let your heart remain open.");
                }
                else
                {
                    Say("Let inspiration guide your hand and heart. Accept this Treasure Chest of Korean Heritage—may its wonders deepen your journey.");
                    from.AddToBackpack(new TreasureChestOfKoreanHeritage());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path be lit by wisdom and your heart soothed by beauty. Farewell, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of lotus, wisdom, calligraphy, or the legacy of Yulgok.");
                }
            }

            base.OnSpeech(e);
        }

        public ShinSaimdang(Serial serial) : base(serial) { }

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
