using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Väinämöinen")]
    public class Vainamoinen : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Vainamoinen() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Väinämöinen";
            Body = 0x190; // Human male body

            // Stats
            Str = 85;
            Dex = 60;
            Int = 120;
            Hits = 80;

            // Unique, magical bardic appearance: ancient sage of the north
            AddItem(new ElvenShirt() { Name = "Songweaver's Tunic", Hue = 1109 });
            AddItem(new GuildedKilt() { Name = "Kalevala Kilt", Hue = 1150 });
            AddItem(new Cloak() { Name = "Northern Lights Cloak", Hue = 1266 });
            AddItem(new WizardsHat() { Name = "Hat of the Wise Singer", Hue = 1289 });
            AddItem(new FurBoots() { Name = "Boots of Endless Journey", Hue = 2501 });
            AddItem(new BodySash() { Name = "Sash of Runes", Hue = 1178 });

            // Weapon: Magical Harp (Staff)
            AddItem(new GnarledStaff() { Name = "Kantele of Creation", Hue = 2075 });

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
                Say("I am Väinämöinen, old and steadfast singer of the Kalevala.");
            }
            else if (speech.Contains("job"))
            {
                Say("My song is my craft. I weave words and shape the world with my voice.");
            }
            else if (speech.Contains("health"))
            {
                Say("My bones are ancient, yet my spirit is strong as a northern pine.");
            }
            else if (speech.Contains("kalevala"))
            {
                Say("The Kalevala is the epic of my people. In its verses, heroes and gods battle, love, and dream.");
            }
            else if (speech.Contains("song") || speech.Contains("sing") || speech.Contains("music"))
            {
                Say("Song is the breath of the land and the soul of the people. With my kantele, I have stilled storms and woken the dawn.");
            }
            else if (speech.Contains("kantele"))
            {
                Say("The kantele is my harp, carved from birch and strung with hair of a maiden. Its sound can charm beasts and spirits alike.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of forest and water dwell in Finland’s wild places, whispering secrets to those who listen.");
            }
            else if (speech.Contains("runic") || speech.Contains("rune"))
            {
                Say("Runes hold great power. With a single rune, mountains tremble and rivers turn their course.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The forest is a living maze of secrets, guarded by haltija and ancient bear spirits.");
            }
            else if (speech.Contains("haltija"))
            {
                Say("Haltija are the guardians of nature: invisible, wise, and sometimes mischievous. Treat the land well, and they may aid you.");
            }
            else if (speech.Contains("bear"))
            {
                Say("The bear is king of the forest. To harm a bear is to invite the wrath of the old gods.");
            }
            else if (speech.Contains("lake") || speech.Contains("water"))
            {
                Say("Finland is the land of a thousand lakes, their surfaces mirror the sky and hide old magic beneath.");
            }
            else if (speech.Contains("magic"))
            {
                Say("Magic flows through every stone and root, waiting for those who can sing its name.");
            }
            else if (speech.Contains("creation"))
            {
                Say("With a song, I raised the land from the sea and shaped the valleys and hills.");
            }
            else if (speech.Contains("north") || speech.Contains("northern") || speech.Contains("nordic"))
            {
                Say("The north is harsh, but beautiful. In winter’s silence, the stars sing their own songs.");
            }
            else if (speech.Contains("winter"))
            {
                Say("Winter’s cloak is heavy, but its nights are bright with dreams and tales.");
            }
            else if (speech.Contains("light") || speech.Contains("northern lights"))
            {
                Say("The northern lights dance in the sky, painting stories in color above the snow.");
            }
            else if (speech.Contains("wisdom") || speech.Contains("wise"))
            {
                Say("Wisdom is not given; it must be earned, word by word and step by step.");
            }
            else if (speech.Contains("hero") || speech.Contains("heroes"))
            {
                Say("Many heroes walk the lands: Lemminkäinen the wild, Ilmarinen the smith, and Kullervo the doomed.");
            }
            else if (speech.Contains("ilmarinen"))
            {
                Say("Ilmarinen the eternal smith forged wonders and the Sampo itself. His hands are never idle.");
            }
            else if (speech.Contains("lemminkäinen"))
            {
                Say("Lemminkäinen was quick with word and sword, yet his fate was as wild as the rivers he crossed.");
            }
            else if (speech.Contains("kullervo"))
            {
                Say("Kullervo’s story is one of sorrow and rage. Even in tragedy, his name is remembered.");
            }
            else if (speech.Contains("adventure"))
            {
                Say("To seek adventure is to seek knowledge. Every journey teaches, every trial forges a stronger soul.");
            }
            else if (speech.Contains("destiny") || speech.Contains("fate"))
            {
                Say("Destiny weaves its threads through all lives, but a strong will can shape its pattern.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future is a story unwritten, awaiting those bold enough to add their own verse.");
            }
            else if (speech.Contains("legend") || speech.Contains("tale") || speech.Contains("story"))
            {
                Say("Every person is a legend in the making. Tell your tale with courage and heart.");
            }
            else if (speech.Contains("finland"))
            {
                Say("Finland, land of silent forests, bright lakes, and quiet courage. She is my mother, and I am her voice.");
            }
            else if (speech.Contains("mother"))
            {
                Say("A mother’s love is the first song we learn, and the last we forget.");
            }
			else if (speech.Contains("giant") || speech.Contains("giants"))
			{
				Say("Giants roamed these lands long before memory. Some say they shaped the fells and hurled boulders into the lakes.");
			}
			else if (speech.Contains("fox") || speech.Contains("firefox"))
			{
				Say("The firefox races across the snow, its tail casting sparks that become the northern lights.");
			}
			else if (speech.Contains("tapio"))
			{
				Say("Tapio is lord of the forest, beard green with moss, antlers crowned with leaves. Hunters whisper his name for luck.");
			}
			else if (speech.Contains("ahti"))
			{
				Say("Ahti rules the lakes and rivers, bringing both bounty and storms. Fisherfolk make small offerings for calm waters.");
			}
			else if (speech.Contains("luonnotar"))
			{
				Say("Luonnotar, the spirit of nature, gave birth to the world when the wind swept over the waters.");
			}
			else if (speech.Contains("owl"))
			{
				Say("The owl is a messenger of the night. Listen well, for its call may be a warning or a riddle.");
			}
			else if (speech.Contains("magic words") || speech.Contains("spell"))
			{
				Say("Magic words are doors: open them carefully, for you never know what might answer.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Many have opposed me—Louhi of the north, the jealous and the proud—but wisdom is a shield stronger than iron.");
			}
			else if (speech.Contains("louhi"))
			{
				Say("Louhi, Mistress of Pohjola, is cunning and mighty. Many a hero has tried—and failed—to best her.");
			}
			else if (speech.Contains("pohjola"))
			{
				Say("Pohjola is the land of the north wind, where winter lingers and strange magic thrives.");
			}
			else if (speech.Contains("shaman") || speech.Contains("noita"))
			{
				Say("Shamans walk between worlds, guided by spirits and runes. Respect their wisdom and beware their anger.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind sings ever-changing songs; some carry warnings, others, secrets from far-off lands.");
			}
			else if (speech.Contains("ice"))
			{
				Say("Ice preserves memories and buries mistakes. Sometimes, ancient things awaken beneath the thaw.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams are the bridges between this world and the next. The wisest walk them with open eyes.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is where your heart sings and your story is known. For me, it is wherever the kantele's music echoes.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor is not found in riches or victory, but in the truth you carry and the friends you cherish.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A true friend is rarer than gold and more enduring than stone. Seek them, and value them dearly.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("Enemies test our resolve and teach us the value of peace.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny is a song half-written; each of us adds our own verse.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire warms the hearth, brightens the night, and inspires tales—but beware its hunger.");
			}			
            else if (speech.Contains("ancient"))
            {
                Say("Ancient wisdom slumbers in stone circles and mossy groves—seek, and you may awaken it.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Many seek treasure, but few understand the true wealth of wisdom and wonder.");
            }
            else if (speech.Contains("sampo"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The Sampo will not be gifted twice in a single day. Return when the sun has moved.");
                }
                else
                {
                    Say("Your questing heart has found the word! Accept this Treasure Chest of Finland, forged in song and story.");
                    from.AddToBackpack(new TreasureChestOfFinland());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the wind carry your song far, and may your footsteps leave stories in their wake.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Kalevala, kantele, Ilmarinen, or the fabled Sampo.");
                }
            }

            base.OnSpeech(e);
        }

        public Vainamoinen(Serial serial) : base(serial) { }

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
