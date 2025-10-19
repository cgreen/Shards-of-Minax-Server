using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Lempira")]
    public class Lempira : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Lempira() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Lempira";
            Body = 0x190; // Human male body

            // Unique Appearance: Lenca Warrior Chief
            AddItem(new ElvenShirt() { Name = "Tunic of the Lenca", Hue = 1752 });
            AddItem(new FancyKilt() { Name = "Kilt of the Intibucá Highlands", Hue = 1796 });
            AddItem(new WoodlandBelt() { Name = "Belt of the Pine Forests", Hue = 2105 });
            AddItem(new TribalMask() { Name = "Mask of the Storm Jaguar", Hue = 1942 });
            AddItem(new FurBoots() { Name = "Boots of the Copán Trails", Hue = 2116 });
            AddItem(new BodySash() { Name = "Sash of Endurance", Hue = 1175 });

            // Weapon: Spear and Shield
            AddItem(new ShortSpear() { Name = "Spear of the Cloud Warriors", Hue = 1109 });
            AddItem(new BashingShield() { Name = "Shield of the Lenca Sun", Hue = 2123 });

            // Speech Hue
            SpeechHue = 2124;

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
                Say("They call me Lempira, shield of the Lenca, spirit of the western highlands.");
            }
            else if (speech.Contains("job"))
            {
                Say("I led the Lenca people against invaders, defending our valleys, rivers, and sacred peaks.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though I fell long ago, my strength flows in the rivers and echoes in the mountains.");
            }
            else if (speech.Contains("lenca"))
            {
                Say("We are the children of mist and pine, keepers of the ancient ways. The Lenca spirit endures.");
            }
            else if (speech.Contains("spanish") || speech.Contains("invader"))
            {
                Say("The invaders came with steel and fire. But no blade is sharper than the will to be free.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains watch over Honduras. Their silence is the strength of our ancestors.");
            }
            else if (speech.Contains("honduras"))
            {
                Say("These lands, from Copán to the sea, carry stories older than any crown.");
            }
            else if (speech.Contains("copan"))
            {
                Say("Copán is a city of carved stones, where gods walked and time is written in glyphs.");
            }
            else if (speech.Contains("glyph") || speech.Contains("glyphs"))
            {
                Say("Glyphs tell the tales of those who built, who dreamed, and who fought for this land.");
            }
            else if (speech.Contains("warrior"))
            {
                Say("A true warrior fights not for conquest, but for the hope of their people.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope grows wild like the ceiba tree, reaching higher each season.");
            }
            else if (speech.Contains("ceiba"))
            {
                Say("The ceiba tree bridges the world of men and spirits. Its roots remember everything.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("Spirit is stronger than stone. Ours lingers in the wind and rain of Honduras.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not gold, but the memory of courage passed from parent to child.");
            }
            else if (speech.Contains("highland") || speech.Contains("highlands"))
            {
                Say("The highlands cradle the villages of my people, shrouded in mist each morning.");
            }
            else if (speech.Contains("mist"))
            {
                Say("Mist hides our trails from the eyes of conquerors. It is a friend to those who listen.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the birthright of all who cherish these hills and rivers.");
            }
            else if (speech.Contains("resist") || speech.Contains("resistance"))
            {
                Say("Resistance is a song sung at every dawn. The Lenca never yield.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs weave together memory and dream, echoing across the valleys.");
            }
            else if (speech.Contains("sun"))
            {
                Say("The sun blesses those who walk with honor. Its light is a promise renewed each day.");
            }
            else if (speech.Contains("jaguar"))
            {
                Say("The jaguar is both guardian and guide, fierce yet wise. It prowls the edge of legend.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends are born in hardship and remembered in triumph. Will you write your own?");
            }
            else if (speech.Contains("triumph"))
            {
                Say("Triumph is not a single victory, but the courage to rise after every fall.");
            }
            else if (speech.Contains("shield"))
            {
                Say("A shield bears the marks of battle, but also the stories of those it protects.");
            }
            else if (speech.Contains("pines") || speech.Contains("forest"))
            {
                Say("The pine forests breathe life into the land. Walk gently among their shadows.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Rivers carve valleys and destinies. Follow their current to wisdom—or to secrets.");
            }
			else if (speech.Contains("ancestors"))
			{
				Say("Our ancestors whisper through the leaves and shape the clouds. Their wisdom lives in every stone and stream.");
			}
			else if (speech.Contains("village") || speech.Contains("villages"))
			{
				Say("The villages nestle in the valleys, each with its own guardian spirit and ancient songs.");
			}
			else if (speech.Contains("spirit"))
			{
				Say("The spirit of a people is their greatest shield. Even when the body falters, the spirit endures.");
			}
			else if (speech.Contains("trail") || speech.Contains("trails"))
			{
				Say("The trails of Intibucá wind through mists and memories. Each bend remembers a hero’s footstep.");
			}
			else if (speech.Contains("rain"))
			{
				Say("The rain brings renewal and hope. Even in the hardest times, it sings us awake.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Enemies come and go, but our roots remain. They cannot pull us from the earth.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The drums called us to gather, to dance, to remember. Each beat was a message to the mountains.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire warms our nights and lights our courage. Around its glow, stories grow into legends.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the seeds of tomorrow. Teach them well, and the forest will always flourish.");
			}
			else if (speech.Contains("market"))
			{
				Say("Markets bloom like gardens, full of color and laughter. There you will hear a hundred stories before noon.");
			}
			else if (speech.Contains("food"))
			{
				Say("Maize, beans, and cacao have nourished us for generations. The land gives what you respect.");
			}
			else if (speech.Contains("maize") || speech.Contains("corn"))
			{
				Say("Maize is the heart of the earth. Each kernel carries the hope of a new harvest.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is a quiet thing, stronger than steel. It grows when we stand together.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night covers the hills with dreams and shadows. Listen, and you may hear the stories of the jaguar.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind carries the voices of the past. Sometimes, if you listen, you’ll hear a message meant for you.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A friend’s loyalty is worth more than silver or jade. Treasure them, as I treasured my companions.");
			}
			else if (speech.Contains("betrayal") || speech.Contains("betrayed"))
			{
				Say("Betrayal cuts deeper than any blade, yet forgiveness is the balm that lets us heal.");
			}
			else if (speech.Contains("memory") || speech.Contains("memories"))
			{
				Say("Memories are living things. Honor them, and they will guide you through any darkness.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("The greatest gifts are not always gold or silver, but lessons, friendship, and the trust of your people.");
			}
			else if (speech.Contains("path"))
			{
				Say("Every path has its stones and roots. Step with care, and your journey will be long and meaningful.");
			}			
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Many secrets sleep beneath the soil and stone of Honduras, waiting for the curious.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("resilience"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the strongest oak must rest before it grows again. Return in time, friend.");
                }
                else
                {
                    Say("Your resilience honors the Lenca spirit. Take this Treasure Chest of Honduran Legends—may it inspire your own journey.");
                    from.AddToBackpack(new TreasureChestOfHonduranLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with strength and honor. The ancestors are never far behind.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Copán, resistance, the Lenca, or the misty highlands of Honduras.");
                }
            }

            base.OnSpeech(e);
        }

        public Lempira(Serial serial) : base(serial) { }

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
