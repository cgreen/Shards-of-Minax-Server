using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hawo the Salt Road Queen")]
    public class HawoSaltRoadQueen : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HawoSaltRoadQueen() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hawo the Salt Road Queen";
            Body = 0x191; // Human female body

            // Unique Appearance: Djiboutian Salt Caravan Queen
            AddItem(new FormalShirt() { Name = "Indigo Caravan Tunic", Hue = 1319 });
            AddItem(new FancyKilt() { Name = "Sandswept Kilt of Tadjoura", Hue = 2417 });
            AddItem(new BodySash() { Name = "Sash of the Seven Routes", Hue = 2106 });
            AddItem(new Cloak() { Name = "Red Sea Nomad's Cloak", Hue = 2525 });
            AddItem(new Sandals() { Name = "Sand-Softened Sandals", Hue = 2042 });
            AddItem(new FlowerGarland() { Name = "Fragrant Acacia Garland", Hue = 2519 });

            // Weapon: Spear (symbolizing caravan defense)
            AddItem(new Spear() { Name = "Salt Road Spear", Hue = 2115 });

            // Speech Hue
            SpeechHue = 1161;

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
                Say("I am Hawo, once called the Salt Road Queen, guardian of Tadjoura’s caravans and keeper of stories.");
            }
            else if (speech.Contains("job"))
            {
                Say("I led salt caravans across the white desert, trading between the Red Sea and the highlands.");
            }
            else if (speech.Contains("health"))
            {
                Say("The wind stings, the sun bites, but I am as steady as the camels I once commanded.");
            }
            else if (speech.Contains("tadjoura"))
            {
                Say("Tadjoura is a city of white houses, called the 'city of the seven mosques.' Salt and stories flow through its gates.");
            }
            else if (speech.Contains("caravan"))
            {
                Say("The caravans are rivers of camels and dreams, threading the desert with hope and hardship.");
            }
            else if (speech.Contains("salt"))
            {
                Say("Salt—white gold, torn from Lake Assal. It feeds empires and brings strangers to our fire.");
            }
            else if (speech.Contains("lake assal") || speech.Contains("assal"))
            {
                Say("Lake Assal lies below sea and sky—saltiest of all waters. Its crystals blind in the sun.");
            }
            else if (speech.Contains("red sea"))
            {
                Say("The Red Sea sparkles with ships from Arabia, India, and distant lands. Djibouti listens to many tongues.");
            }
            else if (speech.Contains("djibouti"))
            {
                Say("Djibouti is crossroads and compass. Here, Africa greets Arabia, and the world pauses to trade.");
            }
            else if (speech.Contains("queen"))
            {
                Say("They called me queen, but I was only the boldest among many. The desert crowns those who endure.");
            }
            else if (speech.Contains("camels") || speech.Contains("camel"))
            {
                Say("Camels are ships of the salt sea—graceful and stubborn, never lost in the sandstorms.");
            }
            else if (speech.Contains("sand") || speech.Contains("desert"))
            {
                Say("The desert is a silent councilor, teaching patience, and hiding both danger and beauty.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade weaves peace and rivalry, trust and betrayal. Every bargain is a story with two sides.");
            }
            else if (speech.Contains("stories") || speech.Contains("story"))
            {
                Say("Stories are salt for the soul. Without them, journeys would be empty as dried wells.");
            }
            else if (speech.Contains("highlands"))
            {
                Say("The highlands are green after rain. Our salt met their coffee, and tales grew between sips.");
            }
            else if (speech.Contains("coffee"))
            {
                Say("Coffee warms the hands of strangers. In Tadjoura, a deal is not sealed until the cup is shared.");
            }
            else if (speech.Contains("nomad") || speech.Contains("nomads"))
            {
                Say("Nomads know the secret paths and the hidden wells. Their wisdom is measured in miles, not gold.");
            }
            else if (speech.Contains("mosques") || speech.Contains("mosque"))
            {
                Say("The seven mosques watch Tadjoura, their prayers rising like mist at dawn.");
            }
            else if (speech.Contains("rival") || speech.Contains("rivalry"))
            {
                Say("Rival caravans sharpened wits, not swords. Words were our weapons—most days.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a bargain renewed each sunrise. Even enemies must share water at the oasis.");
            }
            else if (speech.Contains("oasis"))
            {
                Say("An oasis is more precious than gold. Rest, and listen to what the palms whisper.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold is heavy. Salt is precious. Stories last longest of all.");
            }
			else if (speech.Contains("journey") || speech.Contains("travel"))
			{
				Say("Every journey begins with a blessing and ends with a story, whether the road is kind or cruel.");
			}
			else if (speech.Contains("blessing") || speech.Contains("pray") || speech.Contains("prayer"))
			{
				Say("Before we set out, we share prayers for cool winds and kind strangers. Faith is the salt that preserves the soul.");
			}
			else if (speech.Contains("weather") || speech.Contains("wind") || speech.Contains("storm"))
			{
				Say("Desert storms come without warning—one moment sun, the next, the world lost in swirling sand. Trust your camel more than your eyes.");
			}
			else if (speech.Contains("music") || speech.Contains("song") || speech.Contains("sing"))
			{
				Say("At night, we sing by the fireside—songs of longing and laughter, so the hyenas know we are not afraid.");
			}
			else if (speech.Contains("family") || speech.Contains("mother") || speech.Contains("father"))
			{
				Say("Family binds a caravan tighter than any rope. My mother taught me to barter, my father to listen.");
			}
			else if (speech.Contains("food") || speech.Contains("feast") || speech.Contains("bread"))
			{
				Say("We break flatbread and share goat’s milk with strangers. Hospitality is a shield against misfortune.");
			}
			else if (speech.Contains("thirst") || speech.Contains("water"))
			{
				Say("Water is the final judge of every traveler. When wells run dry, only friendship can lead you onward.");
			}
			else if (speech.Contains("enemy") || speech.Contains("bandit"))
			{
				Say("Bandits lurk beyond the dunes. Sometimes, today’s enemy sits at tomorrow’s fire—desert grudges do not last forever.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children play among the camels, learning the ways of trade and the weight of salt before their first words are grown.");
			}
			else if (speech.Contains("memory") || speech.Contains("past"))
			{
				Say("The desert remembers all footsteps, but it does not hold grudges. Yesterday’s hardships are tomorrow’s tales.");
			}
			else if (speech.Contains("destiny") || speech.Contains("future"))
			{
				Say("Destiny is shaped like a dune—always shifting. Wise travelers do not fight the sand, but shape their steps to it.");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar"))
			{
				Say("Tadjoura’s market is a garden of noise—spices, silks, and bargains hidden among a thousand tongues.");
			}
			else if (speech.Contains("smile") || speech.Contains("laughter") || speech.Contains("laugh"))
			{
				Say("A smile travels further than a caravan. Laughter is the language everyone learns first.");
			}			
            else if (speech.Contains("secret"))
            {
                Say("There is always a secret hidden in the desert, if you dare to listen.");
            }
            // *** SECRET REWARD KEYWORD ***
            else if (speech.Contains("acacia"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Acacia trees bloom in their own time, and so must patience blossom in your heart.");
                }
                else
                {
                    Say("You honor the road and its stories. Take this Treasure Chest of Djibouti—may it lighten your next journey.");
                    from.AddToBackpack(new TreasureChestOfDjibouti());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path find shade, and your caravan never thirst.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Tadjoura, salt, Lake Assal, or the acacia trees of the caravan route.");
                }
            }

            base.OnSpeech(e);
        }

        public HawoSaltRoadQueen(Serial serial) : base(serial) { }

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
