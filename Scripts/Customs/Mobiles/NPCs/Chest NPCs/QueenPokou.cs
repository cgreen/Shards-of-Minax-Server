using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Pokou")]
    public class QueenPokou : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenPokou() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Pokou";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 70;
            Int = 105;
            Hits = 80;

            // Unique Regal African Outfit
            AddItem(new FancyDress() { Name = "Baoulé Royal Gown", Hue = 2942 });
            AddItem(new BodySash() { Name = "Sash of Migration", Hue = 2125 });
            AddItem(new Cloak() { Name = "Mantle of the Golden Savannah", Hue = 2413 });
            AddItem(new FlowerGarland() { Name = "Crown of Akan Blossoms", Hue = 2129 });
            AddItem(new Sandals() { Name = "Sandals of the Comoe River", Hue = 1153 });

            // Staff symbolizing leadership and wisdom
            AddItem(new GnarledStaff() { Name = "Staff of Baoulé Legacy", Hue = 1172 });

            SpeechHue = 2123;

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
                Say("I am Pokou, queen and mother of the Baoulé people.");
            }
            else if (speech.Contains("job"))
            {
                Say("I led my people across rivers and hardship to seek a new home.");
            }
            else if (speech.Contains("health"))
            {
                Say("My heart holds the pain and pride of a thousand journeys, yet my spirit stands strong.");
            }
            else if (speech.Contains("baoulé") || speech.Contains("baoule"))
            {
                Say("The Baoulé are a proud people, born from courage and united by sacrifice.");
            }
            else if (speech.Contains("akan"))
            {
                Say("We were once Akan, but destiny carried us beyond our homeland.");
            }
            else if (speech.Contains("migration") || speech.Contains("journey"))
            {
                Say("Our migration was long and perilous, driven by the hope for peace and freedom.");
            }
            else if (speech.Contains("homeland"))
            {
                Say("The land of our ancestors lies far behind us, but their voices travel with the wind.");
            }
            else if (speech.Contains("river") || speech.Contains("comoe"))
            {
                Say("The Comoe River was both barrier and blessing. It tested our courage and shaped our destiny.");
            }
            else if (speech.Contains("destiny"))
            {
                Say("Destiny is shaped by choices and the strength to endure their cost.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is carried in stories, songs, and the hearts of our children.");
            }
            else if (speech.Contains("mother"))
            {
                Say("To be a mother is to guide, to guard, and when fate demands, to give all.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A true queen serves her people, not herself.");
            }
            else if (speech.Contains("savannah"))
            {
                Say("The golden savannah is home now—where elephants roam and spirits whisper at dusk.");
            }
            else if (speech.Contains("elephant") || speech.Contains("elephants"))
            {
                Say("The elephant is sacred to the Baoulé. Its wisdom and memory are our guiding light.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom grows from sorrow as much as from joy. Listen to both, and your path will be clear.");
            }
            else if (speech.Contains("sorrow"))
            {
                Say("Every path has sorrow, but from sorrow, we find strength.");
            }
            else if (speech.Contains("strength"))
            {
                Say("Strength is not in arms alone, but in the heart that endures for others.");
            }
            else if (speech.Contains("sacrifice"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True sacrifice is rare—return when the sun has moved, and perhaps I will honor your courage again.");
                }
                else
                {
                    Say("It was through sacrifice that the Baoulé found their home. Take this Treasure Chest of Côte d'Ivoire—may it remind you that true greatness asks for more than gold.");
                    from.AddToBackpack(new TreasureChestOfCoteDIvoire());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("children"))
            {
                Say("Our children are the seeds of tomorrow, watered by our hope and our tears.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the river that flows even in drought—never let it run dry.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("Our ancestors’ spirits guide us, dancing in the wind and singing in the night.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("All are welcome to listen. The story of Baoulé is written with courage and with love.");
            }
            else if (speech.Contains("love"))
            {
                Say("Love asks for patience and, sometimes, for unthinkable courage.");
            }
			else if (speech.Contains("ancestors"))
			{
				Say("Our ancestors light the path behind us, their wisdom whispering in every rustling leaf.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who honor the lessons of the past and have the courage to dream.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The drums speak across the savannah, calling all to gather in peace, in joy, or in mourning.");
			}
			else if (speech.Contains("night"))
			{
				Say("At night, the stars gather like council elders, and each tells the tale of a journey.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold may shimmer, but it cannot build a home nor heal a wounded heart.");
			}
			else if (speech.Contains("tribe"))
			{
				Say("Many tribes make up our land, each weaving its colors into the great cloth of life.");
			}
			else if (speech.Contains("cloth"))
			{
				Say("The kente cloth’s bright patterns are messages—stories only the wise can truly read.");
			}
			else if (speech.Contains("festival"))
			{
				Say("During festival, all wounds are mended with laughter and song, and we remember our unity.");
			}
			else if (speech.Contains("song") || speech.Contains("sing") || speech.Contains("music"))
			{
				Say("A single song can carry the memory of a hundred generations. Do you hear it?");
			}
			else if (speech.Contains("market"))
			{
				Say("In the market, voices rise like birds at dawn, bartering, laughing, sharing news from distant villages.");
			}
			else if (speech.Contains("friend"))
			{
				Say("Friendship is a river that never runs dry, if each brings water to share.");
			}
			else if (speech.Contains("rain"))
			{
				Say("The rain is a blessing, a gift from the sky that brings life to the earth.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("May your footsteps be light, and your burdens carried away by the wind’s blessing.");
			}
			else if (speech.Contains("oracle") || speech.Contains("diviner"))
			{
				Say("The oracle reads the future in water and flame, but always warns: fate listens to those who act.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the sweetest fruit, but it grows only where justice and respect are rooted.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Without justice, even the strongest kingdom will fall. Remember, every voice deserves to be heard.");
			}
			else if (speech.Contains("ivory"))
			{
				Say("Ivory once brought strangers to our land, but true wealth lies in the wisdom and unity of our people.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade has carried stories and treasures across our land for centuries—each item holds a history.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("The mountains watch in silence, ancient and patient, keeping the secrets of our forebears.");
			}			
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your journey be blessed, and may you find home wherever you walk.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Baoulé, elephant, migration, or the river that shapes all destinies.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenPokou(Serial serial) : base(serial) { }

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
