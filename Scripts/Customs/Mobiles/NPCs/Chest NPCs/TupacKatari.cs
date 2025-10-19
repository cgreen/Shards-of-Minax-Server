using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Tupac Katari")]
    public class TupacKatari : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TupacKatari() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Túpac Katari";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 75;
            Int = 100;
            Hits = 85;

            // Unique Appearance: Andean Warrior Leader
            AddItem(new ElvenShirt() { Name = "Woven Tunic of the Andes", Hue = 2585 });
            AddItem(new GuildedKilt() { Name = "Kilt of the Aymara Revolution", Hue = 2400 });
            AddItem(new Cloak() { Name = "Condor Feathered Cloak", Hue = 2426 });
            AddItem(new FeatheredHat() { Name = "Chullu of the Altiplano", Hue = 2408 });
            AddItem(new FurBoots() { Name = "Boots of the Sacred Lake", Hue = 2506 });
            AddItem(new BodySash() { Name = "Sash of Rebellion", Hue = 1177 });

            // Weapon: Spear
            AddItem(new ShortSpear() { Name = "Spear of Tiahuanaco", Hue = 1176 });

            // Speech Hue
            SpeechHue = 2117;

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
                Say("I am Túpac Katari, voice of the Andes and leader of the Aymara people.");
            }
            else if (speech.Contains("job"))
            {
                Say("I once led my people in rebellion, seeking freedom for all who dwell near the Sacred Lake.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though my flesh was broken by conquerors, my spirit endures wherever hope for freedom is alive.");
            }
            else if (speech.Contains("aymara"))
            {
                Say("The Aymara are children of the sun and earth, born on the high plains above the Sacred Lake.");
            }
            else if (speech.Contains("rebellion"))
            {
                Say("We besieged the colonial city of La Paz, fighting for dignity, justice, and the memory of our ancestors.");
            }
            else if (speech.Contains("andes"))
            {
                Say("The Andes are mountains of memory and stone, holding secrets of empires long vanished.");
            }
            else if (speech.Contains("lake") || speech.Contains("sacred lake"))
            {
                Say("The Sacred Lake, Titicaca, mirrors the sky and holds stories of gods and forgotten kings.");
            }
            else if (speech.Contains("titicaca"))
            {
                Say("Lake Titicaca is the heart of our world. Legends say it was birthplace of the first Inca.");
            }
            else if (speech.Contains("condor"))
            {
                Say("The condor soars above the Andes, watching over rebels and dreamers alike.");
            }
            else if (speech.Contains("spanish") || speech.Contains("colonial"))
            {
                Say("The Spanish took much from us—land, language, and life. Yet the spirit of the Andes is unbroken.");
            }
            else if (speech.Contains("la paz"))
            {
                Say("La Paz, the city in the clouds, was the stage for our greatest hope and sacrifice.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the flame that outlives defeat. It passes from one generation to the next.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the breath of the mountains—hard to capture, but eternal when won.");
            }
            else if (speech.Contains("sun"))
            {
                Say("The sun watches us all, from Inca emperors to rebel children.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is our weapon and our shield. It preserves our names when conquerors forget them.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("True legacy is not gold, but the courage to rise after each fall.");
            }
            else if (speech.Contains("tiahuanaco") || speech.Contains("tiwanaku"))
            {
                Say("Tiahuanaco is an ancient city, older than the Incas. Its stones hold secrets, some still hidden.");
            }
            else if (speech.Contains("stone") || speech.Contains("stones"))
            {
                Say("Stones of Tiahuanaco remember the empires before us. Listen closely and you may hear their stories.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires rise and fall, but the soul of a people outlasts every king.");
            }
            else if (speech.Contains("king"))
            {
                Say("Many called themselves kings, but the land belongs to all who cherish it.");
            }
            else if (speech.Contains("sacrifice"))
            {
                Say("Sacrifice is the price of freedom. My body was broken, but my voice became a thunder in the mountains.");
            }
            else if (speech.Contains("voice"))
            {
                Say("My voice echoed across the Andes, calling my people to stand together.");
            }
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits of our ancestors walk with us. They live in the wind, the rivers, and the snow upon the mountains.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("There was a prophecy among my people: 'I shall return, and I will be millions.' It speaks to the undying hope of the Andes.");
			}
			else if (speech.Contains("return"))
			{
				Say("One cannot truly return, for the land remembers all things. Yet every generation brings forth new voices of resistance.");
			}
			else if (speech.Contains("resistance"))
			{
				Say("Resistance is born from injustice. Every sunrise is a call to endure, to remember, and to dream of freedom.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are sacred journeys. Sometimes, the mountains themselves whisper to us as we sleep.");
			}
			else if (speech.Contains("mountains"))
			{
				Say("The mountains shape our hearts and shield our secrets. Only the patient traveler learns their true names.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the root of strength. My wife, Bartolina Sisa, was as brave as any warrior—her name, too, should be remembered.");
			}
			else if (speech.Contains("bartolina") || speech.Contains("sisa"))
			{
				Say("Bartolina Sisa fought by my side. Even when darkness fell, her courage was a torch to our people.");
			}
			else if (speech.Contains("torch"))
			{
				Say("A single torch can drive away great shadows. Never doubt the power of even the smallest flame.");
			}
			else if (speech.Contains("shadows"))
			{
				Say("The shadows of conquest linger, but so do the shadows of hope and memory. All are part of our story.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Each person is a story woven into the tapestry of the land. Listen closely, and you will hear songs older than stone.");
			}
			else if (speech.Contains("songs") || speech.Contains("song"))
			{
				Say("Our songs speak of corn, sun, and rain—the blessings and sorrows of everyday life.");
			}
			else if (speech.Contains("corn"))
			{
				Say("Corn is life. In every kernel is a memory of the sun and a promise to the future.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future is written by those who refuse to surrender. What story will you add to these lands?");
			}
			else if (speech.Contains("fate"))
			{
				Say("Fate is a river—sometimes gentle, sometimes wild. Wise travelers learn to listen to its current.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("Rivers are the veins of the earth, carrying both life and legend across the land.");
			}
			else if (speech.Contains("earth") || speech.Contains("land"))
			{
				Say("We belong to the earth, not the other way around. Treat her with respect, and she will provide.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Respect is the highest gift one can offer to both ancestors and strangers alike.");
			}			
            else if (speech.Contains("hidden"))
            {
                Say("Many treasures remain hidden, scattered among the ruins and mountains of Bolivia.");
            }
            else if (speech.Contains("ruins"))
            {
                Say("Ruins are the bones of empires. They whisper to those who listen—and sometimes, they reward the curious.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("curious"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, seeker. The Andes do not reveal their secrets twice in one day.");
                }
                else
                {
                    Say("Curiosity honors the ancestors. Accept this Treasure Chest of Bolivia's Lost Empires—may its contents inspire your own story.");
                    from.AddToBackpack(new TreasureChestOfBoliviasLostEmpires());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the spirit of the mountains travel with you, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Titicaca, rebellion, Tiahuanaco, or the lost stones of the Andes.");
                }
            }

            base.OnSpeech(e);
        }

        public TupacKatari(Serial serial) : base(serial) { }

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
