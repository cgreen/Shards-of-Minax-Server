using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Nei Teweta Tabuki")]
    public class NeiTewetaTabuki : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public NeiTewetaTabuki() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nei Teweta Tabuki";
            Body = 0x191; // Human female body

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Tabuki's Ocean-Woven Shirt", Hue = 1153 });
            AddItem(new Skirt() { Name = "Lattice Skirt of Pandanus Leaves", Hue = 2201 });
            AddItem(new FlowerGarland() { Name = "Fragrant Lei of Kiribati", Hue = 1366 });
            AddItem(new Cloak() { Name = "Mat of the Star Path", Hue = 2117 });
            AddItem(new Sandals() { Name = "Sand-Worn Reefwalkers", Hue = 1877 });
            AddItem(new BodySash() { Name = "Sash of the Equator", Hue = 2536 });
            AddItem(new QuarterStaff() { Name = "Navigator’s Paddle-Staff", Hue = 2109 });

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
                Say("I am Nei Teweta Tabuki, wayfinder and teller of stories upon Tarawa’s sands.");
            }
            else if (speech.Contains("job"))
            {
                Say("My work is to remember, to guide, and to share tales of the sea and the sky.");
            }
            else if (speech.Contains("health"))
            {
                Say("Like the rising tide, I endure. My spirit flows strong, though the world is changing.");
            }
            else if (speech.Contains("kiribati"))
            {
                Say("Kiribati is a necklace of islands, scattered like stars across the deep Pacific.");
            }
            else if (speech.Contains("tarawa"))
            {
                Say("Tarawa is the heart of our islands, where the stories gather and old songs are sung.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every shell and every wave has a story. Listen, and you may learn the path between islands.");
            }
            else if (speech.Contains("sea"))
            {
                Say("The sea is both friend and test. It gives life, but asks courage in return.");
            }
            else if (speech.Contains("sky"))
            {
                Say("In the old days, our people read the sky—stars, birds, and winds—to find their way.");
            }
            else if (speech.Contains("star") || speech.Contains("stars"))
            {
                Say("The stars are our ancient compass. Each one leads to a memory, a home, or a hope.");
            }
            else if (speech.Contains("island") || speech.Contains("islands"))
            {
                Say("Our islands rise from the ocean like dreams, tied together by waves and voyagers.");
            }
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms test both canoe and courage. We watch the clouds and listen to the wind’s warning.");
			}
			else if (speech.Contains("fish") || speech.Contains("fishing"))
			{
				Say("Fishing is our lifeblood. The lagoon’s bounty sustains us—mullet, milkfish, and the silvery bonefish.");
			}
			else if (speech.Contains("dance") || speech.Contains("dancing"))
			{
				Say("Our feet beat the sand in old rhythms. Each dance recalls the stories of gods, ancestors, and the sea.");
			}
			else if (speech.Contains("language") || speech.Contains("speak") || speech.Contains("words"))
			{
				Say("Our language is the thread of our people. A word spoken can bind hearts, heal wounds, or carry blessings.");
			}
			else if (speech.Contains("blessing") || speech.Contains("blessings"))
			{
				Say("May the rain be gentle and the palm trees tall. These are the blessings our elders offer each dawn.");
			}
			else if (speech.Contains("elders") || speech.Contains("old"))
			{
				Say("The elders are our living libraries. Their wisdom is deep as the ocean trenches.");
			}
			else if (speech.Contains("children") || speech.Contains("child"))
			{
				Say("Children are the promise of tomorrow. We teach them stories, songs, and how to listen to the sea.");
			}
			else if (speech.Contains("palm") || speech.Contains("coconut"))
			{
				Say("The coconut palm is the tree of life. It gives us food, water, shelter, and rope for our voyages.");
			}
			else if (speech.Contains("sunrise") || speech.Contains("sunset"))
			{
				Say("At sunrise, we greet the new day with hope. At sunset, we thank the spirits for safe return.");
			}
			else if (speech.Contains("food") || speech.Contains("feast"))
			{
				Say("Feasts bring us together. We share taro, breadfruit, fish, and laughter under the moonlight.");
			}
			else if (speech.Contains("canoesong"))
			{
				Say("There is a song we sing only when launching a canoe—so the spirits will grant a safe journey.");
			}
			else if (speech.Contains("legend"))
			{
				Say("Legends speak of giant clams, flying fish, and heroes who turned islands into stars.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits dwell in the wind, the sea, and the ancient stones. Treat them with respect, and they will guide you.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is where your heart knows the shape of the waves and the scent of the rain.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a gift and a lesson. It teaches us patience, and fills our wells with sweet water.");
			}
			else if (speech.Contains("well") || speech.Contains("water"))
			{
				Say("Water is precious. On our islands, a deep well is a greater treasure than a chest of pearls.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A friend is like a sturdy canoe: trustworthy, carrying you safely across troubled waters.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("The greatest gift is knowledge freely shared—like a song, a story, or the secret of a safe passage.");
			}			
            else if (speech.Contains("war"))
            {
                Say("There was war here once. The world’s armies clashed upon our reefs, but the island remembers peace.");
            }
            else if (speech.Contains("peace"))
            {
                Say("True peace is a calm lagoon, protected by strong hearts and wise minds.");
            }
            else if (speech.Contains("voyage") || speech.Contains("voyager"))
            {
                Say("Our ancestors crossed great waters in tiny canoes, trusting to skill and to stars.");
            }
            else if (speech.Contains("canoe"))
            {
                Say("The outrigger canoe is our wings across the water, shaped by hands and tradition.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is the rope that binds us—old words, old dances, old ways of finding home.");
            }
            else if (speech.Contains("climate"))
            {
                Say("The sea is rising, they say. But our spirit rises, too, finding new ways to survive.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Ancestors watch from beyond the reef. Their courage guides us when the way grows dark.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("We sing for rain, for safe journeys, for love and for memory. Every song is a blessing.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is the lantern in a storm. It shows us the way when all seems lost.");
            }
            else if (speech.Contains("reef"))
            {
                Say("The reef is both shield and snare—protecting us, yet sometimes trapping the unwary.");
            }
            else if (speech.Contains("pandanus"))
            {
                Say("Pandanus leaves make our mats and sails. Their pattern is the pattern of our lives.");
            }
            else if (speech.Contains("bonfire") || speech.Contains("fire"))
            {
                Say("By bonfire light, stories grow longer and shadows grow friendlier.");
            }
            else if (speech.Contains("equator"))
            {
                Say("We live upon the Equator’s line—endless sun above, endless ocean below.");
            }
            else if (speech.Contains("navigation"))
            {
                // SECRET REWARD LOGIC
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You have already found your way for now, traveler. The tides must turn before I guide you again.");
                }
                else
                {
                    Say("You honor the old art of navigation! Take this Treasure Chest of Kiribati and let its gifts remind you: no journey is ever truly lost.");
                    from.AddToBackpack(new TreasureChestOfKiribati());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Te raoi ao te tabomoa—may peace and plenty travel with you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the sea, the sky, or the ancient ways of navigation, if you wish to hear more.");
                }
            }

            base.OnSpeech(e);
        }

        public NeiTewetaTabuki(Serial serial) : base(serial) { }

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
