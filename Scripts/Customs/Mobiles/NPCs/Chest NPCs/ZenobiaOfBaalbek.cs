using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Zenobia")]
    public class ZenobiaOfBaalbek : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ZenobiaOfBaalbek() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zenobia of Baalbek";
            Body = 0x191; // Human female body

            // Unique Appearance: Queen of Ancient Baalbek
            AddItem(new FancyDress() { Name = "Robes of Phoenician Majesty", Hue = 2118 });
            AddItem(new Cloak() { Name = "Cedar-Embroidered Cloak", Hue = 2002 });
            AddItem(new BodySash() { Name = "Sash of Baalbek's Sun", Hue = 1167 });
            AddItem(new FlowerGarland() { Name = "Crown of Laurel and Cedar", Hue = 1260 });
            AddItem(new Sandals() { Name = "Sands of the Temple Steps", Hue = 2419 });
            AddItem(new GildedDress() { Name = "Dress of Palmyrene Royalty", Hue = 2125 });

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Scepter of Lebanon's Dawn", Hue = 1169 });

            // Speech hue (warm gold)
            SpeechHue = 2129;

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
                Say("I am Zenobia, Queen of Palmyra, echo of Baalbek, and daughter of Lebanon's ancient stones.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once I ruled empires and led armies, now I am a guardian of stories and memories.");
            }
            else if (speech.Contains("health"))
            {
                Say("Time wears the body, but not the will. My spirit endures where the cedars grow.");
            }
            else if (speech.Contains("baalbek"))
            {
                Say("Baalbek is the City of the Sun, crowned with temples and carved by the hands of giants.");
            }
            else if (speech.Contains("palmyra"))
            {
                Say("Palmyra was my throne—a city of silk and stone, where caravans brought the world to our gates.");
            }
            else if (speech.Contains("queen"))
            {
                Say("Queen, warrior, mother—my crown was not gold alone, but hope for all free peoples.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires are clay in the hands of fate. Rome, Palmyra, Phoenicia—only the earth endures.");
            }
            else if (speech.Contains("lebanon"))
            {
                Say("Lebanon is a land of mountains and mystery, where every stone remembers a thousand years.");
            }
            else if (speech.Contains("temple"))
            {
                Say("The temples of Baalbek rise toward the sky. Ask me of Helios or the hidden stones.");
            }
            else if (speech.Contains("helios") || speech.Contains("sun"))
            {
                Say("Helios, the Sun, was worshipped in Baalbek. His light touches all who seek wisdom.");
            }
            else if (speech.Contains("cedar"))
            {
                Say("The cedar is Lebanon’s heart. Its scent drifts through centuries, a promise of endurance.");
            }
            else if (speech.Contains("giant") || speech.Contains("giants"))
            {
                Say("Legends say giants built Baalbek’s great stones. In every myth, there is a seed of truth.");
            }
            else if (speech.Contains("myth") || speech.Contains("myths"))
            {
                Say("Myths are memories dressed as dreams. Lebanon's hills are thick with stories.");
            }
            else if (speech.Contains("stone") || speech.Contains("stones"))
            {
                Say("The Trilithon stones are the greatest ever moved by mortal hands. Some say they hide secrets beneath.");
            }
            else if (speech.Contains("trilithon"))
            {
                Say("The Trilithon are three colossal stones in Baalbek, their purpose lost to time and shadow.");
            }
            else if (speech.Contains("shadow") || speech.Contains("shadows"))
            {
                Say("Shadows stretch long at sunset in Baalbek, hiding things old and rare.");
            }
            else if (speech.Contains("roman") || speech.Contains("rome"))
            {
                Say("The Romans came with iron and law, but could not erase the spirit of these lands.");
            }
            else if (speech.Contains("phoenicia") || speech.Contains("phoenician"))
            {
                Say("Phoenicia, land of mariners and merchants—her children spread letters and purple cloth to the world.");
            }
            else if (speech.Contains("sea"))
            {
                Say("The sea is both boundary and bridge. The Phoenicians called it home.");
            }
            else if (speech.Contains("warrior"))
            {
                Say("A true warrior defends not only land, but memory. Even legends must fight for survival.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends live when they are retold. Whisper my name beneath the cedars, and I will answer.");
            }
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is gathered like olives—slowly, patiently, beneath the watchful sun.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("In the temples, oracles spoke in riddles. Truth is rarely simple, traveler.");
			}
			else if (speech.Contains("olive"))
			{
				Say("The olive tree binds generations, its fruit a symbol of peace and memory.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("Lebanon’s mountains guard the land as old friends, veiled in mist and legend.");
			}
			else if (speech.Contains("mist"))
			{
				Say("In the morning, the mists of Lebanon weave dreams between cedar and stone.");
			}
			else if (speech.Contains("wine"))
			{
				Say("Our vineyards are as ancient as any temple. A cup of wine, a tale retold.");
			}
			else if (speech.Contains("garden"))
			{
				Say("Gardens bloom even among ruins. To tend them is to hope for tomorrow.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("The voices of ancestors echo in the valleys. Listen for their song in the wind.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Lebanon’s ports were gateways for silk, glass, and purple dye—treasures for every distant king.");
			}
			else if (speech.Contains("purple"))
			{
				Say("Phoenician purple—Tyrian dye—was more prized than gold, fit for the robes of emperors.");
			}
			else if (speech.Contains("caravan") || speech.Contains("caravans"))
			{
				Say("Caravans crossed sand and mountain to bring goods and news. Every journey was a risk and a promise.");
			}
			else if (speech.Contains("river") || speech.Contains("litani"))
			{
				Say("The Litani River nourishes Lebanon as a mother feeds her child. Its waters remember every secret.");
			}
			else if (speech.Contains("poetry") || speech.Contains("poet"))
			{
				Say("Poetry gives shape to longing. From Byblos to Baalbek, our poets wove words as deftly as weavers.");
			}
			else if (speech.Contains("byblos"))
			{
				Say("Byblos, ancient city of letters, where writing first bloomed. Ask me of scrolls or secrets.");
			}
			else if (speech.Contains("scroll") || speech.Contains("scrolls"))
			{
				Say("Scrolls are silent witnesses, guarding memories the world would forget.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals fill the air with music and spice. Joy is the oldest tradition of all.");
			}
			else if (speech.Contains("music"))
			{
				Say("Music stirs the soul and honors the gods. The oud and drum echo through mountain and market alike.");
			}
			else if (speech.Contains("oud"))
			{
				Say("The oud’s voice is deep as the earth, gentle as dusk. In its notes, sorrow and hope entwine.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("The harvest season is sacred. We give thanks to earth, sun, and those who came before.");
			}
			else if (speech.Contains("thanks") || speech.Contains("gratitude"))
			{
				Say("Gratitude opens the heart to wonder. Even queens must bow to what is given.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Stars watched over every city and every wanderer. Their names are written in languages older than Rome.");
			}
			else if (speech.Contains("language") || speech.Contains("alphabet"))
			{
				Say("The alphabet was Lebanon’s gift to the world—a code of lines and dreams.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are messages wrapped in mystery. What did you dream, traveler?");
			}
			else if (speech.Contains("future"))
			{
				Say("The future is built on the memory of stones, the promise of seeds, and the courage to begin anew.");
			}			
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every traveler brings a story. In Baalbek, even the stones are storytellers.");
            }
            else if (speech.Contains("traveler") || speech.Contains("travellers"))
            {
                Say("Travelers find wisdom in ancient roads. Ask, and you may uncover hidden paths.");
            }
            else if (speech.Contains("hidden") || speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Some secrets are etched in stone, others in silence. Listen well to the whispers of the Trilithon.");
            }
            // *** SECRET REWARD KEYWORD ***
            else if (speech.Contains("trilithon"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Great stones must not be moved too quickly. Return after the sun has crossed the sky.");
                }
                else
                {
                    Say("You have uncovered the secret of the Trilithon. Accept this Treasure Chest of Lebanon, in memory of all that endures.");
                    from.AddToBackpack(new TreasureChestOfLebanon());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the blessings of the cedars travel with you, wanderer.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Baalbek, cedar, or the stones that whisper secrets in the night.");
                }
            }

            base.OnSpeech(e);
        }

        public ZenobiaOfBaalbek(Serial serial) : base(serial) { }

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
