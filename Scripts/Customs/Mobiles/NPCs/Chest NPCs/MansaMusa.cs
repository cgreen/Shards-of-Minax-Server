using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mansa Musa")]
    public class MansaMusa : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MansaMusa() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mansa Musa";
            Title = "Emperor of Mali";
            Body = 0x190; // Human male

            // Majestic West African Royal Outfit
            AddItem(new Robe() { Name = "Imperial Robe of Mali", Hue = 1281 }); // deep gold
            AddItem(new BodySash() { Name = "Sash of the Djenné Scholars", Hue = 2118 }); // rich indigo
            AddItem(new FancyShirt() { Name = "Kaftan of Timbuktu", Hue = 2125 }); // brilliant white
            AddItem(new Skirt() { Name = "Kente Skirt of Royalty", Hue = 2101 }); // colorful kente pattern
            AddItem(new Sandals() { Name = "Sandals of the Sahel", Hue = 2500 });
            AddItem(new Circlet() { Name = "Crown of the Niger", Hue = 1161 }); // gold crown

            // Iconic Weapon/Staff
            AddItem(new Scepter() { Name = "Scepter of Endless Wisdom", Hue = 1175 });

            SpeechHue = 2124; // royal purple

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
                Say("I am Mansa Musa, lion of Mali, lord of gold and learning.");
            }
            else if (speech.Contains("job"))
            {
                Say("I rule the Mali Empire, guiding my people with justice and wisdom.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body is strong, and my spirit journeys ever onward.");
            }
            else if (speech.Contains("mali"))
            {
                Say("Mali is a land of rivers and riches, where gold flows and knowledge is treasured.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold glitters in Mali's rivers and markets, yet true wealth is wisdom shared.");
            }
            else if (speech.Contains("niger"))
            {
                Say("The Niger River is the lifeblood of our land, winding through history and hope.");
            }
            else if (speech.Contains("timbuktu"))
            {
                Say("Timbuktu is the jewel of scholars, a beacon for those who seek learning.");
            }
            else if (speech.Contains("scholar") || speech.Contains("scholars") || speech.Contains("learning"))
            {
                Say("Scholars are honored in Mali. Knowledge builds empires stronger than stone.");
            }
            else if (speech.Contains("hajj") || speech.Contains("mecca"))
            {
                Say("My pilgrimage to Mecca changed the world—every step, a gift to those I met.");
            }
            else if (speech.Contains("camel") || speech.Contains("caravan"))
            {
                Say("Our caravans stretch across the Sahara, carrying salt, gold, and stories.");
            }
            else if (speech.Contains("salt"))
            {
                Say("Salt is worth its weight in gold to those who cross the endless sands.");
            }
            else if (speech.Contains("kente"))
            {
                Say("Kente cloth tells the story of kings and ancestors. Each color, a message.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the greatest treasure, more lasting than gold or empire.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires are measured by the dreams they inspire and the justice they bring.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice is the foundation of Mali. Every voice, from the fisherman to the scribe, must be heard.");
            }
            else if (speech.Contains("scribe") || speech.Contains("scribe"))
            {
                Say("The scribes of Timbuktu preserve our stories for generations yet unborn.");
            }
            else if (speech.Contains("lion"))
            {
                Say("The lion is our symbol—noble, watchful, and unbowed.");
            }
            else if (speech.Contains("crown"))
            {
                Say("My crown was forged from gold and hope, to remind all who see it that Mali endures.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to the wise, and to those who dare to dream.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade binds the desert to the river, and the world to Mali's gates.");
            }
            else if (speech.Contains("desert") || speech.Contains("sahara"))
            {
                Say("The Sahara stretches beyond sight, a test for the patient and the brave.");
            }
            else if (speech.Contains("djenné"))
            {
                Say("Djenné rises from the floodplain—a city of mud-brick and miracles.");
            }
            else if (speech.Contains("miracle") || speech.Contains("miracles"))
            {
                Say("Miracles bloom in Mali for those who believe and endure.");
            }
			else if (speech.Contains("music"))
			{
				Say("Music in Mali is more precious than gold. The kora and balafon carry our history from one generation to the next.");
			}
			else if (speech.Contains("griot") || speech.Contains("griots"))
			{
				Say("Griots are keepers of memory. Their voices hold the stories of kings, battles, and the laughter of children.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Our festivals are rivers of color—drums beat, dancers spin, and all of Mali celebrates the gifts of the earth.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the root and the shade. My ancestors guide me, as yours surely guide you.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("To forget one's ancestors is to lose one’s way in the desert. We honor them with every breath.");
			}
			else if (speech.Contains("wealth"))
			{
				Say("True wealth is found in friends, in wisdom, and in deeds remembered long after gold is spent.");
			}
			else if (speech.Contains("market") || speech.Contains("markets"))
			{
				Say("Our markets are alive with voices and color: salt from the desert, gold from the rivers, silks from distant lands.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the dream of every wise king. It is built on fairness and respect, stone by patient stone.");
			}
			else if (speech.Contains("river"))
			{
				Say("The river brings both life and challenge. Fishers cast their nets, and children laugh along its banks.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun watches over Mali from dawn to dusk, blessing the crops and warming the hearts of my people.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon brings rest and reflection. Under its light, poets and lovers find their voices.");
			}
			else if (speech.Contains("kings"))
			{
				Say("Many have worn the crown, but a king's greatest legacy is justice and generosity.");
			}
			else if (speech.Contains("forgiveness"))
			{
				Say("Even a king must learn forgiveness. The river of time washes away many wrongs.");
			}
			else if (speech.Contains("teacher") || speech.Contains("teachers"))
			{
				Say("A wise teacher plants the seeds of greatness. Mali’s future lies in the hands of its learners.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are Mali’s brightest jewels. Their laughter is the song of tomorrow.");
			}
			else if (speech.Contains("blessing") || speech.Contains("blessings"))
			{
				Say("May the blessings of Mali walk with you, as the baobab shades the weary traveler.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Each journey brings new wisdom. Walk with open eyes and an open heart.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Caravans from every corner of the earth find welcome here. Trade is the bridge between strangers.");
			}
			else if (speech.Contains("storyteller"))
			{
				Say("The storyteller's tongue is sharper than a sword, and softer than the wind. All are welcome to listen.");
			}
			else if (speech.Contains("desert"))
			{
				Say("The desert is both a barrier and a path. Those who cross it carry tales that become legends.");
			}
			else if (speech.Contains("baobab"))
			{
				Say("The baobab tree stands through drought and storm. Its roots remind us to hold fast to our purpose.");
			}			
            else if (speech.Contains("travel") || speech.Contains("journey") || speech.Contains("wander"))
            {
                Say("A single journey can shape the fate of empires. I have traveled farther than most can dream.");
            }
            else if (speech.Contains("pilgrimage"))
            {
                // SECRET REWARD KEYWORD!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You have already been blessed by my pilgrimage today. Patience is a virtue of kings.");
                }
                else
                {
                    Say("The true reward of any pilgrimage is transformation. Accept this Treasure Chest of the Mali Empire—may it enrich your own story.");
                    from.AddToBackpack(new TreasureChestOfMaliEmpire());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every grain of sand carries a story. What tale do you seek in Mali?");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go in peace, and may wisdom guide your steps.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of gold, pilgrimage, Timbuktu, or the mighty Niger river.");
                }
            }

            base.OnSpeech(e);
        }

        public MansaMusa(Serial serial) : base(serial) { }

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
