using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the royal spirit of Queen Tamar")]
    public class QueenTamarTheGreat : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenTamarTheGreat() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Tamar the Great";
            Body = 0x191; // Human female
            Title = "Royal Spirit of Georgia";

            // Stats
            Str = 100;
            Dex = 65;
            Int = 120;
            Hits = 80;

            // Unique Outfit
            AddItem(new Robe() { Hue = 2110, Name = "Royal Robe of Tamar" });
            AddItem(new BodySash() { Hue = 2425, Name = "Sash of the Golden Age" });
            AddItem(new Circlet() { Hue = 2301, Name = "Crown of Kartli" });
            AddItem(new Shoes() { Hue = 2017, Name = "Embroidered Silk Shoes" });
            AddItem(new Scepter() { Hue = 2500, Name = "Scepter of Light" });

            Hue = Utility.RandomSkinHue();
            HairItemID = 0x203B; // Long hair
            HairHue = 1150; // Rich dark brown

            SpeechHue = 1154; // Royal blue

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
                Say("I am Queen Tamar, once ruler of Georgia, now a spirit wandering the realms of memory.");
            }
            else if (speech.Contains("health"))
            {
                Say("The years of my reign were strong, and my spirit remains ever bright.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I was queen. Now, I am a keeper of ancient wisdom and guardian of my people’s stories.");
            }
            else if (speech.Contains("queen"))
            {
                Say("As queen, I sought justice, peace, and unity for all of Georgia.");
            }
            else if (speech.Contains("georgia"))
            {
                Say("Georgia is my beloved homeland—a land of mountains, poets, and warriors.");
            }
            else if (speech.Contains("golden age"))
            {
                Say("During my reign, Georgia flourished. It was an age of poetry, victory, and enlightenment.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the true treasure of a ruler. Through learning and patience, great deeds are accomplished.");
            }
            else if (speech.Contains("deeds"))
            {
                Say("Many deeds define an era, but kindness and courage are the greatest.");
            }
            else if (speech.Contains("kindness"))
            {
                Say("Kindness builds nations, as surely as stone and sword.");
            }
			else if (speech.Contains("faith"))
			{
				Say("Faith was the heart of my people, binding us through storm and sunlight alike. Do you seek the light of faith, or the lessons of hardship?");
			}
			else if (speech.Contains("hardship"))
			{
				Say("In hardship, we found unity. The mountains of Georgia taught us resilience and the strength to rise after every fall.");
			}
			else if (speech.Contains("mountains"))
			{
				Say("The Caucasus mountains are both fortress and home—guardians of our history, witnesses to both peace and battle.");
			}
			else if (speech.Contains("battle"))
			{
				Say("Many battles tested Georgia, but I believed that wisdom must temper the sword. Victory without honor is emptiness.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor endures when riches fade. It is a ruler's legacy and a nation's pride.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A true legacy is not of gold or stone, but of the spirit—memories carried in the hearts of generations.");
			}
			else if (speech.Contains("arts"))
			{
				Say("The arts flourished in my court. Poets, painters, and musicians brought glory to Georgia’s soul.");
			}
			else if (speech.Contains("poets"))
			{
				Say("Shota Rustaveli was our greatest poet. His words, like rivers, flow through the ages. Have you read his epic, The Knight in the Panther’s Skin?");
			}
			else if (speech.Contains("knight in the panther's skin"))
			{
				Say("It is a tale of love, friendship, and loyalty—a mirror of Georgia’s ideals. Such stories are our true treasures.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty bound my court together. Through loyalty, even the smallest voice is heard and valued.");
			}
			else if (speech.Contains("court"))
			{
				Say("My court was a place of learning and justice. Many traveled from distant lands to witness its splendor.");
			}
			else if (speech.Contains("distant lands"))
			{
				Say("From Byzantium to Persia, visitors brought gifts and news, enriching Georgia’s tapestry.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice was my guiding star. Without justice, a ruler is but a shadow on the throne.");
			}
			else if (speech.Contains("star"))
			{
				Say("Each night, I gazed at the stars and pondered the fate of my people. The constellations remind us: even in darkness, there is light.");
			}			
            else if (speech.Contains("victory"))
            {
                Say("Our victories brought peace and unity to Georgia’s many tribes and cities.");
            }
            else if (speech.Contains("peace"))
            {
                Say("True peace comes not from conquest, but from understanding and respect.");
            }
            else if (speech.Contains("reward"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("I sense you have recently received my gift. Return to me after you have reflected on Georgia’s wisdom.");
                }
                else
                {
                    Say("You have walked the path of wisdom and learned of Georgia’s Golden Age. Accept this Treasure Chest of Ancient Georgia as a token of my gratitude.");
                    from.AddToBackpack(new TreasureChestOfAncientGeorgia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("stories"))
            {
                Say("Georgia’s stories are filled with courage, love, and faith—may you carry them forward.");
            }
            else if (speech.Contains("enlightenment"))
            {
                Say("Enlightenment comes to those who seek both knowledge and compassion.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage was my shield and the hope of my people.");
            }
            else
            {
                // Optional: Give a hint if the player is lost
                if (Utility.RandomDouble() < 0.2)
                    Say("Speak to me of my job, my homeland, or my Golden Age, and perhaps you will learn more...");
            }

            base.OnSpeech(e);
        }

        public QueenTamarTheGreat(Serial serial) : base(serial) { }

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
