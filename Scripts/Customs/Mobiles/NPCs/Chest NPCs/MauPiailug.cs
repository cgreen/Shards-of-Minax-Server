using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mau Piailug")]
    public class MauPiailug : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MauPiailug() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mau Piailug";
            Body = 0x190; // Human male body

            // Unique Appearance: Micronesian Master Navigator
            AddItem(new FormalShirt() { Name = "Star-Map Tunic of Satawal", Hue = 1175 });
            AddItem(new Kilt() { Name = "Voyager's Woven Skirt", Hue = 1364 });
            AddItem(new Cloak() { Name = "Ocean Current Cloak", Hue = 1367 });
            AddItem(new Bandana() { Name = "Headband of the Navigators", Hue = 1166 });
            AddItem(new Sandals() { Name = "Coral Sandals", Hue = 2017 });
            AddItem(new BodySash() { Name = "Sash of the Rising Sun", Hue = 1159 });

            // Weapon: Quarterstaff (styled as a navigation staff)
            AddItem(new QuarterStaff() { Name = "Celestial Wayfinder’s Staff", Hue = 1170 });

            // Speech Hue
            SpeechHue = 2065;

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
                Say("I am Mau Piailug, last of the palu—master navigators from Satawal.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a wayfinder. I cross the ocean by stars, winds, and memory, guiding my people from isle to isle.");
            }
            else if (speech.Contains("health"))
            {
                Say("Salt air and sunrise keep me strong, though old age weathers even the sturdiest canoe.");
            }
            else if (speech.Contains("satawal"))
            {
                Say("Satawal is a tiny atoll in the vast Pacific, home to a proud lineage of navigators.");
            }
            else if (speech.Contains("navigator") || speech.Contains("palu"))
            {
                Say("The palu are keepers of secrets: how to read waves, stars, birds, and the spirit of the ocean itself.");
            }
            else if (speech.Contains("ocean"))
            {
                Say("The ocean is a living map. Its swells and currents tell stories that no scroll ever could.");
            }
            else if (speech.Contains("canoe"))
            {
                Say("A single outrigger canoe, carved by hand and prayer, can ride the ocean for a thousand miles.");
            }
            else if (speech.Contains("star") || speech.Contains("stars"))
            {
                Say("Each star is a friend to the navigator. We know them as you know the roads of your homeland.");
            }
            else if (speech.Contains("voyage"))
            {
                Say("To voyage is to trust the ancestors, the stars, and the rhythm of the sea. Every journey is a lesson.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("The ancestors whisper in the wind and guide the canoe with invisible hands.");
            }
            else if (speech.Contains("stick chart") || speech.Contains("chart"))
            {
                Say("Our stick charts record the secrets of waves and currents—knowledge passed from teacher to apprentice.");
            }
            else if (speech.Contains("micronesia"))
            {
                Say("Micronesia is a necklace of islands scattered like stars across the sea, each with its own story.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition binds our people together, from the youngest paddler to the oldest palu.");
            }
            else if (speech.Contains("teaching") || speech.Contains("teach"))
            {
                Say("I taught navigation to those who had forgotten, so the ancient way would not die with me.");
            }
            else if (speech.Contains("hawaii") || speech.Contains("hokulea"))
            {
                Say("I guided the Hōkūle‘a to Hawaii, proving that the old ways still hold power and truth.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A navigator’s legacy is not gold, but the knowledge passed to the next generation.");
            }
            else if (speech.Contains("canoe"))
            {
                Say("Each canoe is a promise: to find land beyond the horizon, and to return home again.");
            }
            else if (speech.Contains("wave") || speech.Contains("waves"))
            {
                Say("Waves travel far. Their shape and song can lead a canoe to land, if you listen well.");
            }
            else if (speech.Contains("current") || speech.Contains("currents"))
            {
                Say("Currents are the veins of the sea. They carry more than water—they carry stories.");
            }
            else if (speech.Contains("bird") || speech.Contains("birds"))
            {
                Say("Seabirds are the navigators’ scouts. When they fly in the morning, follow: land is near.");
            }
            else if (speech.Contains("cloud") || speech.Contains("clouds"))
            {
                Say("Clouds linger over islands, even when land is too small to see. Look up when you are lost.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("Spirit is what carries a canoe when wind and paddle fail. The sea tests both body and soul.");
            }
            else if (speech.Contains("home"))
            {
                Say("Home is the island where your name is sung. I have seen many, but Satawal is mine.");
            }
			else if (speech.Contains("paddler") || speech.Contains("paddle"))
			{
				Say("A good paddler moves with the water, not against it. Even the smallest child can become a master with patience.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms teach humility and respect. No navigator boasts when thunder speaks; we listen, and we survive.");
			}
			else if (speech.Contains("doubt"))
			{
				Say("Even the greatest wayfinder has known doubt. But courage is a star you keep burning in your heart.");
			}
			else if (speech.Contains("learning") || speech.Contains("apprentice"))
			{
				Say("Learning never ends for a navigator. Each voyage teaches what the last could not.");
			}
			else if (speech.Contains("fish") || speech.Contains("fishing"))
			{
				Say("Fish gather near reefs and shallow waters. Watch their patterns, and they will show you hidden islands.");
			}
			else if (speech.Contains("reef") || speech.Contains("reefs"))
			{
				Say("Reefs guard the islands, sometimes gentle, sometimes treacherous. They are both home and warning.");
			}
			else if (speech.Contains("shell") || speech.Contains("shells"))
			{
				Say("Every shell has traveled far—some are gifts from islands I have never seen, brought by the endless tide.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the anchor that holds the canoe steady, no matter how wild the sea.");
			}
			else if (speech.Contains("youth") || speech.Contains("young"))
			{
				Say("It is the youth who must carry our traditions forward, so the stars do not forget our names.");
			}
			else if (speech.Contains("sunrise"))
			{
				Say("Sunrise brings hope and clarity. Navigators watch the horizon at dawn, when secrets are easiest to see.");
			}
			else if (speech.Contains("sunset"))
			{
				Say("At sunset, we sing to the ancestors and thank the sea for its gifts and lessons.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Fear is natural. But listen to your fear, as you listen to the wind—it can warn you of hidden dangers.");
			}
			else if (speech.Contains("island") || speech.Contains("islands"))
			{
				Say("Each island is a story, and every voyager adds a new chapter. No two islands are ever truly the same.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("A true gift is knowledge shared. The sea rewards those who are generous, not greedy.");
			}
			else if (speech.Contains("master"))
			{
				Say("A master navigator is only as strong as those who learn from him. Legacy is shared, never owned.");
			}
			else if (speech.Contains("wind"))
			{
				Say("Winds shape every journey. Learn to read their touch, and you can reach any shore.");
			}
			else if (speech.Contains("water"))
			{
				Say("Water connects all things. It remembers every paddle stroke and every promise.");
			}
			else if (speech.Contains("festival") || speech.Contains("celebration"))
			{
				Say("During festivals, we tell tales of great journeys and honor those who risked everything for discovery.");
			}
			else if (speech.Contains("peace"))
			{
				Say("A calm sea teaches peace, but true peace is found in the heart, no matter the waves.");
			}			
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Songs preserve our knowledge. A chant can hold the map of the stars or the memory of a storm.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is a compass. Forget the old ways, and the canoe drifts with no guide.");
            }
            else if (speech.Contains("map") || speech.Contains("maps"))
            {
                Say("Our maps are made of sticks and shells, but the greatest map is in the mind of a true palu.");
            }
            else if (speech.Contains("secrets"))
            {
                Say("The ocean reveals her secrets slowly, to those who watch and wait.");
            }
            else if (speech.Contains("wayfinder") || speech.Contains("wayfinding") || speech.Contains("navigation"))
            {
                // REWARD KEYWORD - not obvious, but hinted at in deeper conversation!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Knowledge must be cherished, not hoarded. Return when the tides change.");
                }
                else
                {
                    Say("You have found the heart of my craft. Take this Treasure Chest of Micronesian Legends, and let its wisdom guide your path.");
                    from.AddToBackpack(new TreasureChestOfMicronesianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the stars light your way, and may you always find your island home.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of navigation, Satawal, stick charts, or the songs of the wayfinders.");
                }
            }

            base.OnSpeech(e);
        }

        public MauPiailug(Serial serial) : base(serial) { }

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
