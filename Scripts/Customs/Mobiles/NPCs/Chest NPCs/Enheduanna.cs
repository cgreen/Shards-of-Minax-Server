using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Enheduanna")]
    public class Enheduanna : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Enheduanna() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Enheduanna";
            Title = "High Priestess of the Moon";
            Female = true;
            Body = 0x191; // Human female

            // Stats
            Str = 80;
            Dex = 60;
            Int = 110;
            Hits = 80;

            // Unique Mesopotamian-Inspired Outfit
            AddItem(new Robe() { Name = "Ceremonial Robe of Ur", Hue = 1154 }); // Deep blue
            AddItem(new BodySash() { Name = "Sash of Nanna's Embrace", Hue = 2053 }); // Silver
            AddItem(new Circlet() { Name = "Moonstone Circlet", Hue = 1150 }); // Pale gray
            AddItem(new Sandals() { Name = "Sandals of Sacred Ziggurat", Hue = 1193 }); // Sandstone
            AddItem(new Cloak() { Name = "Veil of the Stars", Hue = 2403 }); // Midnight blue

            // Weapon: Scribe's Scepter
            AddItem(new Scepter() { Name = "Scepter of Inanna", Hue = 2213 });

            SpeechHue = 2636;

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
                Say("I am Enheduanna, daughter of Sargon and High Priestess of Nanna, the Moon God.");
            }
            else if (speech.Contains("job"))
            {
                Say("I serve as High Priestess at the great ziggurat of Ur, weaving hymns and guiding rituals beneath the lunar glow.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit is strong, though the sands of time wear upon us all.");
            }
            else if (speech.Contains("sumer") || speech.Contains("sumeria"))
            {
                Say("Sumer is the cradle of civilization, where the rivers meet and stories are born.");
            }
            else if (speech.Contains("ur"))
            {
                Say("Ur is my home—a city of splendor, with its ziggurat rising to touch the heavens.");
            }
            else if (speech.Contains("ziggurat"))
            {
                Say("The ziggurat is our ladder to the sky, built to honor the gods and reach for wisdom.");
            }
            else if (speech.Contains("nanna") || speech.Contains("moon"))
            {
                Say("Nanna, the Moon God, is guardian of night and bringer of dreams. His silver light blesses us.");
            }
            else if (speech.Contains("inanna"))
            {
                Say("Inanna, Queen of Heaven, rules over love and war. Her stories are as old as the stars.");
            }
            else if (speech.Contains("sargon"))
            {
                Say("Sargon the Great, my father, forged the first empire. His ambition built cities from dust.");
            }
            else if (speech.Contains("hymn") || speech.Contains("hymns"))
            {
                Say("I compose hymns for the gods. Words are as powerful as any blade or scepter.");
            }
            else if (speech.Contains("civilization"))
            {
                Say("From our reeds and clay, we shaped writing, cities, and the memory of all peoples.");
            }
            else if (speech.Contains("writing") || speech.Contains("cuneiform"))
            {
                Say("Cuneiform script preserves our history on clay tablets, so no memory is truly lost.");
            }
            else if (speech.Contains("tablet") || speech.Contains("tablets"))
            {
                Say("Tablets of clay hold secrets and stories—each stroke a whisper across the ages.");
            }
            else if (speech.Contains("legend") || speech.Contains("myth"))
            {
                Say("Our myths speak of gods who walked among mortals, shaping fate with their whims.");
            }
            else if (speech.Contains("gods") || speech.Contains("god"))
            {
                Say("Many gods dwell in Mesopotamia—each with their own domain, story, and sacred symbol.");
            }
            else if (speech.Contains("symbol"))
            {
                Say("The crescent moon, star, and reed—all carry the meaning of the gods, if you know how to read them.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers") || speech.Contains("euphrates") || speech.Contains("tigris"))
            {
                Say("The Tigris and Euphrates are the lifeblood of our land. All prosperity flows from their embrace.");
            }
            else if (speech.Contains("star") || speech.Contains("stars"))
            {
                Say("Stars guide our destinies. Astronomers of Ur track their dance across the night.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires rise and fall, but stories endure, sung by the daughters of Enheduanna.");
            }
            else if (speech.Contains("history"))
            {
                Say("History is a tapestry woven by many hands—kings, priests, farmers, and scribes.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are messages sent by the gods, drifting down with the moonlight.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom in humble places—a whisper, a shadow, or an old story may hold the key.");
            }
            else if (speech.Contains("shadow") || speech.Contains("shadows"))
            {
                Say("In every shadow, a mystery waits. The wise walk carefully between night and dawn.");
            }
			else if (speech.Contains("priestess") || speech.Contains("priest"))
			{
				Say("To be priestess is to walk between worlds—interpreting dreams, guiding rituals, and singing the names of gods beneath the stars.");
			}
			else if (speech.Contains("ritual") || speech.Contains("rituals"))
			{
				Say("Our rituals honor Nanna with incense, song, and offerings at each new moon. Even the simplest gesture can open the heavens.");
			}
			else if (speech.Contains("offering") || speech.Contains("offerings"))
			{
				Say("Offerings of bread, honey, and fragrant oil please the gods, but a sincere heart is the rarest gift of all.");
			}
			else if (speech.Contains("moonlight"))
			{
				Say("Moonlight dances across the ziggurat's stones, bathing Ur in silver and washing away the shadows of the day.");
			}
			else if (speech.Contains("harp") || speech.Contains("music"))
			{
				Say("The sound of the harp drifts through temple halls—each note a prayer, each chord a link to the divine.");
			}
			else if (speech.Contains("clay"))
			{
				Say("We shape clay into tablets, bricks, and idols. It is both our memory and our shelter.");
			}
			else if (speech.Contains("temple"))
			{
				Say("The temple is heart of the city, its spires reaching skyward, its walls echoing with ancient hymns.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals fill the streets with laughter and song—when the moon is fullest, even the river seems to dance.");
			}
			else if (speech.Contains("queen"))
			{
				Say("Inanna is Queen of Heaven and Earth, but mortal queens too rule with wisdom, courage, and sometimes, sorrow.");
			}
			else if (speech.Contains("dreamer") || speech.Contains("dreamers"))
			{
				Say("Dreamers shape the world. Without their visions, Ur would be but dust swept by the desert wind.");
			}
			else if (speech.Contains("desert"))
			{
				Say("The desert is harsh, but beautiful. Its silence teaches patience and its storms teach resilience.");
			}
			else if (speech.Contains("lion"))
			{
				Say("The lion is sacred to Inanna—a symbol of courage and the wild spirit that dwells in us all.");
			}
			else if (speech.Contains("garden") || speech.Contains("gardens"))
			{
				Say("Our gardens flourish beside the rivers, green and sweet—a promise that even in dry lands, life finds a way.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("The stars speak in riddles, and sometimes the wind carries a prophecy. Listen with an open heart.");
			}
			else if (speech.Contains("scribe") || speech.Contains("scribes"))
			{
				Say("Scribes are keepers of memory. Their reed pens carry stories that outlive empires.");
			}
			else if (speech.Contains("ancestors"))
			{
				Say("Our ancestors whisper in the night, their wisdom guiding us as surely as the moon's gentle hand.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a blessing in these lands. Each drop carries hope and the promise of tomorrow's harvest.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("The harvest is a time of gratitude—when the bounty of the land feeds not just our bodies, but our spirits.");
			}			
            else if (speech.Contains("mystery") || speech.Contains("secrets"))
            {
                Say("Some secrets are revealed only to the truly attentive. Listen for the song that guides the curious.");
            }
            else if (speech.Contains("song"))
            {
                Say("My songs honor Inanna and Nanna. Through music, the veil between worlds grows thin.");
            }
            else if (speech.Contains("veil"))
            {
                Say("The veil of night conceals as much as it reveals. Trust in patience and you may glimpse the truth.");
            }
            // *** SECRET REWARD KEYWORD ***
            else if (speech.Contains("crescent"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The moon waxes and wanes, but its gifts are not bestowed twice in one night.");
                }
                else
                {
                    Say("You have gazed upon the crescent, the symbol of ancient wisdom. Accept this Treasure Chest of Mesopotamian Legends, and carry its tales onward.");
                    from.AddToBackpack(new TreasureChestOfMesopotamianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the moon watch over your journeys. Farewell, seeker.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Ur, the moon, ziggurats, cuneiform, or the river's gift.");
                }
            }

            base.OnSpeech(e);
        }

        public Enheduanna(Serial serial) : base(serial) { }

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
