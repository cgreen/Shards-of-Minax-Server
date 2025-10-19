using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Sultan Bolkiah")]
    public class SultanBolkiah : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public SultanBolkiah() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sultan Bolkiah";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 80;
            Int = 105;
            Hits = 80;

            // Unique Appearance: Bruneian Sultan
            AddItem(new FormalShirt() { Name = "Gilded Tunic of the Maritime Sultan", Hue = 1354 });
            AddItem(new FancyKilt() { Name = "Ceremonial Kain of Bandar Seri Begawan", Hue = 2125 });
            AddItem(new Cloak() { Name = "Golden Cloak of the Eastern Isles", Hue = 2217 });
            AddItem(new BodySash() { Name = "Sash of the Seven Seas", Hue = 1761 });
            AddItem(new Sandals() { Name = "Pearl-Inlaid Royal Sandals", Hue = 1153 });
            AddItem(new TricorneHat() { Name = "Admiral’s Headdress of Brunei", Hue = 2003 });

            // Weapon: Kris (use Dagger)
            AddItem(new Dagger() { Name = "Wavesplitter Kris of Bolkiah", Hue = 1289 });

            SpeechHue = 1154;
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
                Say("I am Sultan Bolkiah, the Sailor King of Brunei’s Golden Age.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty was to rule wisely, to sail far, and to bring prosperity to my people.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though the waves of time have passed, my spirit endures like the river Kinabatangan.");
            }
            else if (speech.Contains("brunei"))
            {
                Say("Brunei is a realm of golden domes and shining rivers, known across the seas for its wealth.");
            }
            else if (speech.Contains("sultan"))
            {
                Say("The sultans of Brunei ruled with wisdom and guided ships to fortune.");
            }
            else if (speech.Contains("sea") || speech.Contains("seas"))
            {
                Say("The sea is a highway for dreams and riches. Our fleets sailed to Manila, Borneo, and beyond.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade brought spices, gold, and pearls to our shores. Ask me of fleet or spices.");
            }
            else if (speech.Contains("fleet"))
            {
                Say("My fleet was the envy of the isles. Each voyage carried hope, and sometimes, secret treasures.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Cloves, nutmeg, and pepper made Brunei’s name famous in every port.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold filled our treasuries, but true wealth is in harmony and wisdom.");
            }
            else if (speech.Contains("kinabatangan") || speech.Contains("river"))
            {
                Say("The Kinabatangan River winds through emerald forests, carrying legends and riches alike.");
            }
            else if (speech.Contains("pearl") || speech.Contains("pearls"))
            {
                Say("Pearls gleam beneath our waters, prized by queens and emperors.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends sail on the wind: of sultans, treasures, and distant isles.");
            }
            else if (speech.Contains("voyage"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The secrets of the sea are not given lightly. Return to me when the sun stands higher.");
                }
                else
                {
                    Say("Your spirit for adventure honors Brunei’s Golden Age. Take this Treasure Chest of Brunei’s Golden Age, and may your own voyage be prosperous!");
                    from.AddToBackpack(new TreasureChestOfBruneisGoldenAge());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom as you would seek a safe harbor—patiently and with respect.");
            }
            else if (speech.Contains("heritage"))
            {
                Say("Our heritage is in every song, every gold thread, and every tale shared at dusk.");
            }
            else if (speech.Contains("majesty"))
            {
                Say("Majesty is not found in crowns, but in service and compassion.");
            }
            else if (speech.Contains("isles"))
            {
                Say("From the Spratly Isles to the Celebes Sea, all mariners spoke of Brunei’s might.");
            }
            else if (speech.Contains("harmony"))
            {
                Say("Harmony made our courts strong and our people content.");
            }
            else if (speech.Contains("bandar"))
            {
                Say("Bandar Seri Begawan, my city, shone with lanterns and laughter along the water’s edge.");
            }
            else if (speech.Contains("borneo"))
            {
                Say("Borneo is a land of emerald rainforests, mighty rivers, and ancient peoples.");
            }
            else if (speech.Contains("manila"))
            {
                Say("Manila’s ports once rang with the greetings of Bruneian sailors and merchants.");
            }
			else if (speech.Contains("family"))
			{
				Say("My dynasty shaped Brunei’s destiny. The house of Bolkiah brought unity and prosperity to these shores.");
			}
			else if (speech.Contains("palace"))
			{
				Say("My palace stood at the river’s bend, its domes gleaming in the sunlight and echoing with laughter and council.");
			}
			else if (speech.Contains("council") || speech.Contains("advisor") || speech.Contains("advice"))
			{
				Say("A wise sultan listens. My council included seasoned mariners, clever traders, and faithful elders.");
			}
			else if (speech.Contains("river"))
			{
				Say("Rivers are the veins of my land, carrying life, stories, and dreams to every corner of Brunei.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals in Brunei were splendid affairs—drums, lanterns, and feasts upon woven mats by the water.");
			}
			else if (speech.Contains("food") || speech.Contains("feast"))
			{
				Say("Our tables overflowed with fish, fragrant rice, and fruits from jungle and orchard alike.");
			}
			else if (speech.Contains("music") || speech.Contains("song"))
			{
				Say("The sounds of the sape and gong filled our nights, and songs of voyages inspired every heart.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend is a lantern in a storm. My greatest allies sailed at my side across wild seas.");
			}
			else if (speech.Contains("enemy") || speech.Contains("rival"))
			{
				Say("Rivals kept our blades sharp—pirates, foreign kings, even storms themselves sought to test Brunei’s will.");
			}
			else if (speech.Contains("pirate") || speech.Contains("pirates"))
			{
				Say("Pirates roamed these waters, but our navy was swift and our kris sharper still.");
			}
			else if (speech.Contains("navy"))
			{
				Say("Our navy, commanded by bold captains, safeguarded every ship that flew Brunei’s colors.");
			}
			else if (speech.Contains("queen") || speech.Contains("princess"))
			{
				Say("Queens and princesses brought wisdom and grace to our court, weaving peace among noble families.");
			}
			else if (speech.Contains("court"))
			{
				Say("My court was alive with storytellers, merchants, and emissaries from distant lands.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Stories are treasure for the soul. I remember the tale of the moon pearl, lost and found by a humble fisher.");
			}
			else if (speech.Contains("moon") && speech.Contains("pearl"))
			{
				Say("The moon pearl was said to shine with the dreams of the sultanate, a symbol of hope in darkest waters.");
			}
			else if (speech.Contains("forest") || speech.Contains("jungle"))
			{
				Say("Our jungles are alive with songbirds, orchids, and secrets waiting for those bold enough to enter.");
			}
			else if (speech.Contains("orchid") || speech.Contains("flower"))
			{
				Say("The rare golden orchid blooms in the deepest shade—beauty found only by the patient and wise.");
			}
			else if (speech.Contains("lantern"))
			{
				Say("Lanterns floated downriver on festival nights, carrying prayers and wishes toward the open sea.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who honor their roots yet dare to chart new waters.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A sultan’s legacy is not in riches, but in the peace and pride of his people.");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("Treasure can be found by the bold, but beware: not all that glitters brings joy.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May calm seas and golden fortune guide your journey, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Brunei, fleet, gold, or the rivers of my homeland.");
                }
            }

            base.OnSpeech(e);
        }

        public SultanBolkiah(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
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
