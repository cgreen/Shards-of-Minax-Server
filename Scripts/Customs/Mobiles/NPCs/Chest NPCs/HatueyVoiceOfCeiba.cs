using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hatuey")]
    public class HatueyVoiceOfCeiba : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HatueyVoiceOfCeiba() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hatuey, Voice of the Ceiba";
            Body = 0x190; // Human male

            // Distinctive Outfit
            AddItem(new ElvenShirt() { Name = "Woven Tunic of the Yucayeque", Hue = 2301 });
            AddItem(new FurSarong() { Name = "Ciboney Hunter's Sarong", Hue = 2118 });
            AddItem(new BodySash() { Name = "Sash of Sacred Tobacco", Hue = 1802 });
            AddItem(new FeatheredHat() { Name = "Macaw Plume Crown", Hue = 2125 });
            AddItem(new Sandals() { Name = "Sandal of the Red Earth", Hue = 1169 });
            AddItem(new TribalMask() { Name = "Mask of the Areito", Hue = 2220 });

            // Weapon
            AddItem(new WarMace() { Name = "Cohoba Staff", Hue = 2107 });

            SpeechHue = 2122;

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
                Say("They called me Hatuey. I am the spirit who walks beneath the Ceiba, where roots hold memory.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was Cacique among my people, leader of the Yucayeque. I speak now for those whose voices were silenced.");
            }
            else if (speech.Contains("health"))
            {
                Say("I carry wounds older than memory, but the song of the forest still stirs within me.");
            }
            else if (speech.Contains("cuba"))
            {
                Say("Cuba, the Pearl of the Antilles, where palm and ceiba sway and stories grow from red earth.");
            }
            else if (speech.Contains("ceiba"))
            {
                Say("The ceiba tree is sacred, a bridge between worlds. Spirits linger beneath its shade.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Spirits drift in the breeze and river. Listen: their stories ripple in the hush of dawn.");
            }
            else if (speech.Contains("yucayeque"))
            {
                Say("The yucayeque was our village, a circle of kin, laughter, and firelight before shadows came from the sea.");
            }
            else if (speech.Contains("cacique"))
            {
                Say("A Cacique is more than a chief; he remembers, protects, and, when needed, resists.");
            }
            else if (speech.Contains("tobacco"))
            {
                Say("Tobacco smoke carries prayers. The Spanish feared its power, but we knew its secrets.");
            }
            else if (speech.Contains("spanish"))
            {
                Say("The Spanish arrived on floating mountains, hungry for gold, blind to beauty.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold is the sun’s tear, buried in rivers and hearts. I traded it for freedom, but freedom was dearer.");
            }
            else if (speech.Contains("resist") || speech.Contains("resistance"))
            {
                Say("We resisted not for glory, but so our children might remember how to dream.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fire cleanses and fire destroys. I chose flames rather than kneel.");
            }
            else if (speech.Contains("memory") || speech.Contains("memories"))
            {
                Say("Memory lives in every leaf, every river stone. Ask, and the land remembers.");
            }
            else if (speech.Contains("land") || speech.Contains("earth"))
            {
                Say("The land is a mother—generous, patient, but never truly conquered.");
            }
            else if (speech.Contains("mother"))
            {
                Say("My mother’s stories still echo beneath the moon. All mothers are the first teachers.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("We sang the areito: our history, our hopes, our warnings. Each song is a map for the soul.");
            }
            else if (speech.Contains("areito"))
            {
                Say("Areito is a sacred dance and song. In its circle, time bends and ancestors join in.");
            }
            else if (speech.Contains("circle"))
            {
                Say("The circle is unbroken. Even when the world ends, we gather round the fire.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("Our ancestors are with us—whispering in the rain, laughing in the thunder.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future grows from seeds planted by those who remember and resist.");
            }
            else if (speech.Contains("river"))
            {
                Say("Rivers are veins of the island, carrying secrets and blessings to all who listen.");
            }
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is not a gift; it is a fire in the heart. When you fight for it, even the wind will sing your name.");
			}
			else if (speech.Contains("fire"))
			{
				Say("They tried to silence me with fire, but the flame spread to every corner of the island. Every ember is a promise.");
			}
			else if (speech.Contains("island"))
			{
				Say("The island is a mother’s embrace—salt on the breeze, stories in the soil. To know her, walk barefoot on her earth.");
			}
			else if (speech.Contains("breeze"))
			{
				Say("The breeze carries laughter from distant shores. Listen closely, and you may hear the ancestors calling.");
			}
			else if (speech.Contains("moon"))
			{
				Say("Under the moon’s silver gaze, secrets become clear and old wounds begin to heal.");
			}
			else if (speech.Contains("healing") || speech.Contains("heal"))
			{
				Say("Healing is not forgetting. The land remembers, and so must we—so we may grow stronger.");
			}
			else if (speech.Contains("growth") || speech.Contains("grow"))
			{
				Say("Growth begins where old roots break stone. Even in hardship, the seed finds a way.");
			}
			else if (speech.Contains("seed") || speech.Contains("seeds"))
			{
				Say("Every seed is a dream, waiting for sun and rain. Plant well, and generations will thank you.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are journeys the spirit takes while the body rests. Sometimes, they are warnings. Sometimes, gifts.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("True gifts cannot be bought or stolen—only given with an open hand and a brave heart.");
			}
			else if (speech.Contains("brave") || speech.Contains("bravery"))
			{
				Say("Bravery is a quiet drumbeat inside the chest. Even the smallest voice can awaken a mountain.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("Our mountains hold secrets in their stones, and from their heights you can see the path of every river and every dream.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain falls for all—rich and poor, stranger and friend. Each drop is a blessing, or sometimes, a warning.");
			}
			else if (speech.Contains("warning"))
			{
				Say("Warnings are gifts from the wise. Heed them, and your path will be safer, though never certain.");
			}
			else if (speech.Contains("wise") || speech.Contains("wisdom"))
			{
				Say("Wisdom grows with patience, and patience is watered by hardship. To be wise, listen to those who walked before you.");
			}
			else if (speech.Contains("patience"))
			{
				Say("The ceiba’s roots grow for centuries. Be patient—what is meant for you will find you.");
			}
			else if (speech.Contains("destiny") || speech.Contains("fate"))
			{
				Say("Destiny is the story we write with every choice, every breath. Yours is yet unfolding.");
			}
			else if (speech.Contains("choice") || speech.Contains("choices"))
			{
				Say("Every choice shapes the world. Choose with respect, for even a whisper may echo through generations.");
			}
			else if (speech.Contains("echo"))
			{
				Say("Echoes of the past teach us the future. When you speak, remember that the island listens.");
			}			
            else if (speech.Contains("blessing") || speech.Contains("blessings"))
            {
                Say("A blessing is given, not taken. May you carry mine beneath the shade of the ceiba.");
            }
            else if (speech.Contains("shade"))
            {
                Say("Shade is a comfort, but in its coolness, some treasures are hidden from impatient eyes.");
            }
            else if (speech.Contains("hidden"))
            {
                Say("The best treasures are hidden in plain sight—like the truth in a song, or a gift beneath the roots.");
            }
            // Secret reward keyword is "roots"
            else if (speech.Contains("roots"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The ceiba’s roots share only with the patient. Return when the sun has moved again.");
                }
                else
                {
                    Say("You have found what lies beneath. Accept this Treasure Chest of Cuba—may its contents remember you.");
                    from.AddToBackpack(new TreasureChestOfCuba());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with courage. The roots remember your steps, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of the ceiba, tobacco, areito, or the roots of the land.");
                }
            }

            base.OnSpeech(e);
        }

        public HatueyVoiceOfCeiba(Serial serial) : base(serial) { }

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
