using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Said Ali")]
    public class SultanSaidAli : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public SultanSaidAli() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Said Ali bin Said Omar";
            Body = 0x190; // Human male body

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Sultan's Embroidered Tunic", Hue = 1153 });
            AddItem(new FancyKilt() { Name = "Grande Comore Sarong", Hue = 2064 });
            AddItem(new Cloak() { Name = "Mantle of Indian Ocean Winds", Hue = 2953 });
            AddItem(new WideBrimHat() { Name = "Comorian Coral Turban", Hue = 2949 });
            AddItem(new FurBoots() { Name = "Sandals of Ngazidja Shores", Hue = 2220 });
            AddItem(new BodySash() { Name = "Sash of Spices", Hue = 1161 });

            AddItem(new Scimitar() { Name = "Blade of the Crescent Isles", Hue = 2101 });

            SpeechHue = 2125;

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
                Say("I am Said Ali bin Said Omar, last sultan of Grande Comore and voice of my island’s heritage.");
            }
            else if (speech.Contains("job"))
            {
                Say("I once ruled as sultan, guardian of my people and the coral isles.");
            }
            else if (speech.Contains("health"))
            {
                Say("The body weakens as the tides change, but my spirit is as strong as the monsoon winds.");
            }
            else if (speech.Contains("comoros"))
            {
                Say("Comoros is a necklace of islands, kissed by the Indian Ocean and crowned by the moon.");
            }
            else if (speech.Contains("island") || speech.Contains("isles"))
            {
                Say("These islands—Ngazidja, Nzwani, Mwali—are pearls in the great ocean, each with their own secrets.");
            }
            else if (speech.Contains("sultan"))
            {
                Say("To be sultan was to serve, to balance tradition and the ever-changing tides of the world.");
            }
            else if (speech.Contains("ocean"))
            {
                Say("The Indian Ocean brings traders and travelers, stories and storms. Listen to its wisdom.");
            }
            else if (speech.Contains("spices"))
            {
                Say("Cloves and ylang-ylang perfume the air; our spices are prized from Zanzibar to distant lands.");
            }
            else if (speech.Contains("coral"))
            {
                Say("Coral reefs protect our shores and provide for our people. Their colors are the pride of Comoros.");
            }
            else if (speech.Contains("moon"))
            {
                Say("We are the children of the moon—the symbol that shines on our flag and guides our destiny.");
            }
            else if (speech.Contains("struggle") || speech.Contains("freedom"))
            {
                Say("Many sought to take these islands, but our hearts beat with the song of freedom.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade shaped our islands—gold, ivory, spices, and stories passing from ship to shore.");
            }
            else if (speech.Contains("zanzibar"))
            {
                Say("Zanzibar was once our partner and rival, a city of traders and sultans across the waves.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("Our ancestors cross the sea in spirit, their wisdom woven into every tradition.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A sultan's true legacy is his people's hope. What will your legacy be, traveler?");
            }
			else if (speech.Contains("ngazidja"))
			{
				Say("Ngazidja, called Grande Comore, is the largest of our isles—a land of volcanic stone and brave hearts.");
			}
			else if (speech.Contains("volcano") || speech.Contains("karthala"))
			{
				Say("Mount Karthala is the island’s giant, its breath shaping the land. When she rumbles, we listen.");
			}
			else if (speech.Contains("fishermen") || speech.Contains("fishing"))
			{
				Say("Our fishermen read the stars and the tides. From the sea comes both our feast and our fortune.");
			}
			else if (speech.Contains("music"))
			{
				Say("Listen for the twang of the gabusi and the beat of the m’godro drum—our music dances with the waves.");
			}
			else if (speech.Contains("perfume") || speech.Contains("ylang"))
			{
				Say("Ylang-ylang blossoms perfume our air. It is the golden scent carried from Comoros to distant kingdoms.");
			}
			else if (speech.Contains("story") || speech.Contains("legend"))
			{
				Say("Comoros is woven from legend—djinns in the moonlight, pirates beneath the cliffs, lovers who swam between the isles.");
			}
			else if (speech.Contains("djinn") || speech.Contains("jinn"))
			{
				Say("The djinn whisper in the groves and caves. Respect their ways, for mischief and wisdom often share a face.");
			}
			else if (speech.Contains("pirate") || speech.Contains("pirates"))
			{
				Say("Many flags have sailed these waters. Some brought trade, others plunder. Every reef has a pirate tale.");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar"))
			{
				Say("At the market, all the colors of Comoros gather—silks, spices, pearls, and the laughter of our people.");
			}
			else if (speech.Contains("peace"))
			{
				Say("True peace is a precious shell—easily cracked, yet its beauty lasts in memory.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family ties are strong as braided rope. We honor our elders and cherish our children.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children play by the shore, learning stories from the sand and the sea.");
			}
			else if (speech.Contains("rain"))
			{
				Say("The warm rains feed our crops and fill our wells. We welcome the rain, and we fear its storms.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("The stars are our compass, guiding sailors and dreamers alike across the waters.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are the songs of the heart. Some say the moon plants them in our sleep.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A friend in Comoros is a treasure greater than pearls or gold.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("We keep our traditions in music, in food, and in the way we greet each dawn together.");
			}
			else if (speech.Contains("welcome"))
			{
				Say("You are welcome on these isles. May your feet find rest and your heart find a story.");
			}			
            else if (speech.Contains("wisdom"))
            {
                Say("True wisdom is like a pearl—hidden, precious, and shaped by patience.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is our shield. Divided, we are but islands; together, we are a nation.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the lamp that endures even when storms rage across the ocean.");
            }
            else if (speech.Contains("flower"))
            {
                Say("Many rare flowers grow here, but the moonflower opens only when the moon is high and the air is still.");
            }
            else if (speech.Contains("moonflower"))
            {
                // Secret reward keyword!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The moonflower blooms only once each night. Return when the moon has crossed the sky.");
                }
                else
                {
                    Say("Your curiosity blossoms like the moonflower. Accept this Treasure Chest of Comoros—may it bring you fortune and the fragrance of the isles.");
                    from.AddToBackpack(new TreasureChestOfComoros());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the moonlight guide you, wherever you roam.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the ocean, spices, coral, or the legends of the moon.");
                }
            }

            base.OnSpeech(e);
        }

        public SultanSaidAli(Serial serial) : base(serial) { }

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
