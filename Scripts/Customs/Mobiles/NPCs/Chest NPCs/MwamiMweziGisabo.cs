using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mwami Mwezi Gisabo")]
    public class MwamiMweziGisabo : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MwamiMweziGisabo() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mwami Mwezi Gisabo";
            Body = 0x190; // Human male body

            // Stats
            Str = 85;
            Dex = 65;
            Int = 100;
            Hits = 70;

            // Unique Appearance: Royalty of Burundi
            AddItem(new FancyShirt() { Name = "Royal Imvutano Tunic", Hue = 2125 });
            AddItem(new HakamaShita() { Name = "Kitenge Ceremonial Wrap", Hue = 2303 });
            AddItem(new Cloak() { Name = "Cloak of the Kirundi Kings", Hue = 1166 });
            AddItem(new WideBrimHat() { Name = "Mwami's Headdress", Hue = 1171 });
            AddItem(new Sandals() { Name = "Lake Tanganyika Sandals", Hue = 2108 });
            AddItem(new BodySash() { Name = "Umukonde Sash", Hue = 1157 });
            AddItem(new GnarledStaff() { Name = "Royal Drumstick of Gisabo", Hue = 1109 });

            // Speech Hue
            SpeechHue = 2112;

            // Initialize reward timer
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
                Say("I am Mwami Mwezi Gisabo, last sovereign of independent Burundi, keeper of royal secrets.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was Mwami, a king—guardian of traditions, and voice of the Kirundi people.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit endures, though my body has traveled beyond the hills of Burundi.");
            }
            else if (speech.Contains("burundi"))
            {
                Say("Burundi is a land of emerald hills and mighty lakes, where cattle graze and drums thunder.");
            }
            else if (speech.Contains("king"))
            {
                Say("Our Mwami ruled by wisdom, guided by the council of elders and the sacred drum.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is our bond—songs, dances, and rituals echo through the royal court.");
            }
            else if (speech.Contains("hill") || speech.Contains("hills"))
            {
                Say("The rolling hills of Burundi are our pride, hiding many tales beneath their green waves.");
            }
            else if (speech.Contains("lake") || speech.Contains("lakes"))
            {
                Say("Lake Tanganyika—deep and ancient—shapes our land and nourishes our people.");
            }
            else if (speech.Contains("cattle"))
            {
                Say("Cattle are the heart of our wealth, their horns a symbol of strength and honor.");
            }
            else if (speech.Contains("drum") || speech.Contains("drums"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Royal drums cannot bestow blessings twice in one sun's journey. Return later, seeker.");
                }
                else
                {
                    Say("The sacred drum is the heart of Burundi. Accept this Treasure Chest of Burundi—a gift worthy of one who listens to its echo.");
                    from.AddToBackpack(new TreasureChestOfBurundi());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("royal"))
            {
                Say("The royal court shimmered with wisdom, music, and ceremony. Ask of the 'drum' to learn more.");
            }
            else if (speech.Contains("music") || speech.Contains("song"))
            {
                Say("Our songs praise ancestors and the earth. Drums summon rain and celebrate victory.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Ancestors watch over Burundi, blessing those who honor them in word and drumbeat.");
            }
            else if (speech.Contains("colonial") || speech.Contains("germany") || speech.Contains("belgium"))
            {
                Say("Foreigners came seeking power, but the soul of Burundi remained with its hills, cattle, and drums.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom in stories, in the patterns of the drums, and in the quiet of Lake Tanganyika.");
            }
            else if (speech.Contains("council") || speech.Contains("elders"))
            {
                Say("The council of elders preserves our stories. Their word weighs more than gold.");
            }
			else if (speech.Contains("palace"))
			{
				Say("The palace stood upon a hill, surrounded by banana groves and echoes of laughter. Every dawn, the royal drum called the people to gather.");
			}
			else if (speech.Contains("banana"))
			{
				Say("Bananas are a gift from the land. We craft wine from their fruit and shade from their leaves.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Every Mwami faces rivals—from within and beyond. Yet, unity has always been our shield.");
			}
			else if (speech.Contains("unity"))
			{
				Say("A kingdom divided is a drum without rhythm. Unity brings peace and prosperity.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is woven like a basket—strongest when every reed is in place.");
			}
			else if (speech.Contains("proverb") || speech.Contains("proverbs"))
			{
				Say("We Burundians cherish our proverbs. 'The drum does not sound alone.' Wisdom is shared, never hoarded.");
			}
			else if (speech.Contains("craft"))
			{
				Say("Our craftsmen weave baskets and carve spears. Their hands preserve the soul of Burundi.");
			}
			else if (speech.Contains("basket") || speech.Contains("baskets"))
			{
				Say("Baskets carry both harvest and hope. Each design tells the story of a family.");
			}
			else if (speech.Contains("spear") || speech.Contains("spears"))
			{
				Say("A spear defends, but only a wise hand brings peace. The royal guards were swift and loyal.");
			}
			else if (speech.Contains("guard") || speech.Contains("guards"))
			{
				Say("The royal guards watched the hills by day and the fires by night. Their spears glinted with loyalty.");
			}
			else if (speech.Contains("feast") || speech.Contains("feasts"))
			{
				Say("A royal feast brought the people together: milk, beans, plantains, and the laughter of children.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the kingdom’s tomorrow. Their games echo across the hills and lakes.");
			}
			else if (speech.Contains("alliance") || speech.Contains("alliances"))
			{
				Say("Alliances with neighboring clans kept our kingdom strong. Even rivals could become friends by the fireside.");
			}
			else if (speech.Contains("fire") || speech.Contains("fireside") || speech.Contains("fireplace"))
			{
				Say("Stories and secrets travel farther by fireside. The flames dance like the rhythms of our drum.");
			}
			else if (speech.Contains("milk"))
			{
				Say("Cattle’s milk nourishes and unites. On sacred days, we shared milk in sign of peace.");
			}
			else if (speech.Contains("ancestor"))
			{
				Say("To forget the ancestors is to lose your place among the living. Their wisdom is carried in every song.");
			}
			else if (speech.Contains("song"))
			{
				Say("A song lingers longer than a memory. Sing, and the spirits may listen.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("Spirits dwell in the hills and waters. Treat them with respect, and your path will be blessed.");
			}			
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Our greatest stories are told with the beat of the drum. Every tale is a lesson.");
            }
            else if (speech.Contains("farewell") || speech.Contains("goodbye"))
            {
                Say("May the hills of Burundi shelter your journey. Go in peace, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of cattle, the royal drum, or Lake Tanganyika—each holds a piece of our story.");
                }
            }

            base.OnSpeech(e);
        }

        public MwamiMweziGisabo(Serial serial) : base(serial) { }

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
