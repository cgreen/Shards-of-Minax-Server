using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Nzinga")]
    public class QueenNzingaMpongwe : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenNzingaMpongwe() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Nzinga of the Mpongwe";
            Body = 0x191; // Human female body

            // Stats
            Str = 85;
            Dex = 70;
            Int = 110;
            Hits = 90;

            // Unique Gabonese Queenly Regalia
            AddItem(new ElvenShirt() { Name = "Royal Shirt of Libreville", Hue = 2109 });
            AddItem(new FancyKilt() { Name = "Embroidered Kilt of the Ogooué", Hue = 2650 });
            AddItem(new Cloak() { Name = "Mistcloak of the Equator", Hue = 2501 });
            AddItem(new Circlet() { Name = "Ivory Circlet of Mpongwe", Hue = 2077 });
            AddItem(new FurBoots() { Name = "Boots of the Rainforest", Hue = 1378 });
            AddItem(new BodySash() { Name = "Sash of Gabonese Wisdom", Hue = 2009 });

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Ebony Scepter of Ancestral Spirits", Hue = 1172 });

            // Speech Hue
            SpeechHue = 2130;

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
                Say("I am Nzinga, crowned Queen of the Mpongwe and daughter of the Ogooué River.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a guardian of history and tradition. My duty is to guide my people and protect the spirit of Gabon.");
            }
            else if (speech.Contains("health"))
            {
                Say("My strength flows from the forest and the river. I am well, as long as my people remember.");
            }
            else if (speech.Contains("mpongwe"))
            {
                Say("The Mpongwe are traders, diplomats, and storytellers. We built our lives along the banks of the Ogooué.");
            }
            else if (speech.Contains("ogooué") || speech.Contains("river"))
            {
                Say("The Ogooué River is the heart of Gabon, carrying stories and secrets from the rainforest to the sea.");
            }
            else if (speech.Contains("rainforest") || speech.Contains("forest"))
            {
                Say("Our rainforest is a living tapestry—home to spirits, elephants, and wisdom as old as the land.");
            }
            else if (speech.Contains("libreville"))
            {
                Say("Libreville grew from Mpongwe villages and became a city of freedom and hope.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Our ancestors walk beside us. In times of need, the spirits guide and protect the worthy.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade brought distant worlds together. Ivory, ebony, and stories were our gifts to the ocean’s visitors.");
            }
            else if (speech.Contains("ivory"))
            {
                Say("Ivory is a treasure of Gabon, shaped by wise hands and carried with respect.");
            }
            else if (speech.Contains("ebony"))
            {
                Say("Ebony wood is prized for its strength and beauty, much like the hearts of my people.");
            }
            else if (speech.Contains("colonial") || speech.Contains("french"))
            {
                Say("Colonial winds brought both suffering and change. Yet our roots held strong in the red earth.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the river’s current—sometimes slow, sometimes wild, but never tamed.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Our true legacy is wisdom. Every tale, every song, carries our spirit forward.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs echo in the drum’s rhythm and the laughter of children by the riverbank.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("The ancestors whisper in dreams and omens. Heed their signs, for they know the mysteries of the land.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is a fire kept burning through patience and learning. Seek, and you may find it.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A true queen serves with humility and listens more than she commands.");
            }
            else if (speech.Contains("crown"))
            {
                Say("My crown is woven of duty, memory, and hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope grows wild here, like the forest after the rains.");
            }
            else if (speech.Contains("family"))
            {
                Say("Family binds us through love and story. It is our first and oldest home.");
            }
			else if (speech.Contains("culture"))
			{
				Say("Mpongwe culture is woven with respect for elders, love of music, and the sharing of meals under the stars.");
			}
			else if (speech.Contains("mask") || speech.Contains("masks"))
			{
				Say("Our wooden masks channel the wisdom of spirits. Dancers wear them in ceremonies to protect and guide our people.");
			}
			else if (speech.Contains("fang"))
			{
				Say("The Fang are our neighbors and kin in spirit. Their stories and rites echo our own, united by the river’s song.");
			}
			else if (speech.Contains("animal") || speech.Contains("animals"))
			{
				Say("The rainforest teems with life—leopards, gorillas, and the mighty forest elephants all walk these lands.");
			}
			else if (speech.Contains("gorilla"))
			{
				Say("The gorilla is a guardian of the forest. In their eyes, you may see the soul of the ancient woods.");
			}
			else if (speech.Contains("elephant"))
			{
				Say("Forest elephants are gentle giants. Their wisdom is remembered in proverbs and their paths shape our villages.");
			}
			else if (speech.Contains("leopard"))
			{
				Say("The leopard’s spirit is fierce and silent. Hunters pray to it for luck and protection.");
			}
			else if (speech.Contains("belief") || speech.Contains("beliefs") || speech.Contains("magic"))
			{
				Say("We believe in the living magic of the land. Healers and ngangas speak to spirits and cure with roots and songs.");
			}
			else if (speech.Contains("nganga") || speech.Contains("healer"))
			{
				Say("A nganga is a healer, counselor, and bridge to the spirit world. Their art is both science and mystery.");
			}
			else if (speech.Contains("drum") || speech.Contains("music"))
			{
				Say("Drums call the spirits and gather the people. Every celebration begins with music.");
			}
			else if (speech.Contains("dance"))
			{
				Say("Dance tells our history when words are not enough. Even the spirits are said to dance beneath the moon.");
			}
			else if (speech.Contains("food") || speech.Contains("feast"))
			{
				Say("Our feasts honor ancestors and celebrate harvests. Try nyembwe chicken or fresh cassava, if you hunger.");
			}
			else if (speech.Contains("nyembwe"))
			{
				Say("Nyembwe chicken, cooked in rich palm nut sauce, is a dish to remember. Every family has their secret spice.");
			}
			else if (speech.Contains("cassava"))
			{
				Say("Cassava gives strength for the day’s work. We grind, bake, and share it, so no one goes hungry.");
			}
			else if (speech.Contains("fishing") || speech.Contains("fish"))
			{
				Say("Fishing in the Ogooué is both livelihood and tradition. The river’s bounty sustains our villages.");
			}
			else if (speech.Contains("canoe"))
			{
				Say("Canoes carved from a single tree glide silently on the river, carrying travelers and secrets alike.");
			}
			else if (speech.Contains("market"))
			{
				Say("The market is where news, goods, and laughter flow freely. Come early to hear the latest stories!");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are the future and the hope of Gabon. They learn our stories and shape our destiny.");
			}
			else if (speech.Contains("omen") || speech.Contains("omens"))
			{
				Say("The wise watch for omens: a bird’s flight, a dream, a ripple in the river. Not all mysteries are for mortals to know.");
			}			
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Stories are the treasures of Gabon. Ask of the mysteries, and you may learn more.");
            }
            else if (speech.Contains("mysteries"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, seeker. The river does not reveal its secrets twice in one day.");
                }
                else
                {
                    Say("Your curiosity honors the ancestors. Take this Treasure Chest of Gabonese History—may it carry new wisdom to your journey.");
                    from.AddToBackpack(new TreasureChestOfGaboneseHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the river’s song and the forest’s wisdom travel with you, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Libreville, the Ogooué, spirits, or the mysteries of Gabon.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenNzingaMpongwe(Serial serial) : base(serial) { }

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
