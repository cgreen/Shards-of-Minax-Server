using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Sorghaghtani Beki")]
    public class SorghaghtaniBeki : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public SorghaghtaniBeki() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sorghaghtani Beki";
            Body = 0x191; // Human female body

            // Unique Appearance: Matriarch of the Steppe
            AddItem(new FancyShirt() { Name = "Silken Deel of the Eternal Blue Sky", Hue = 1362 });
            AddItem(new Skirt() { Name = "Horsehair Skirt of the Orkhon Valley", Hue = 2213 });
            AddItem(new Cloak() { Name = "Wolf-Fur Cloak of Winter Winds", Hue = 2407 });
            AddItem(new BearMask() { Name = "Eagle-Feathered Headdress", Hue = 2114 });
            AddItem(new FurBoots() { Name = "Boots of the Endless Steppe", Hue = 2505 });
            AddItem(new BodySash() { Name = "Sash of Royal Blood", Hue = 1178 });

            // Weapon: GnarledStaff (staff of command)
            AddItem(new GnarledStaff() { Name = "Staff of Four Khans", Hue = 1109 });

            // Speech Hue
            SpeechHue = 2210;

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
                Say("I am Sorghaghtani Beki, matriarch of empires and mother to khans.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to guide, to teach, and to ensure the wisdom of my sons lights the world.");
            }
            else if (speech.Contains("health"))
            {
                Say("I am strong as the wild horse, and calm as the steppe at sunrise.");
            }
            else if (speech.Contains("mongol") || speech.Contains("mongolia"))
            {
                Say("We are children of the eternal blue sky, born to ride where the land meets the heavens.");
            }
            else if (speech.Contains("steppe"))
            {
                Say("The steppe is both cradle and tomb. Its grasses remember the hooves of conquerors.");
            }
            else if (speech.Contains("khans") || speech.Contains("khan"))
            {
                Say("My sons became great khans—Möngke, Kublai, Hulagu, and Ariq Böke. Each shaped the world.");
            }
            else if (speech.Contains("sons"))
            {
                Say("A mother’s heart rides with her sons. Mine carried empires on their backs.");
            }
            else if (speech.Contains("empire"))
            {
                Say("The empire was born in the dust and thunder of horsemen, united by vision and fate.");
            }
            else if (speech.Contains("vision"))
            {
                Say("Vision is the wind: unseen, yet it shapes every dune and destiny.");
            }
            else if (speech.Contains("kublai"))
            {
                Say("Kublai was destined to rule the Middle Kingdom. His wisdom matched his courage.");
            }
            else if (speech.Contains("möngke") || speech.Contains("mongke"))
            {
                Say("Möngke was a just khan, seeking order in the vast chaos of empire.");
            }
            else if (speech.Contains("hulagu"))
            {
                Say("Hulagu carried fire to distant lands, founding dynasties on foreign soil.");
            }
            else if (speech.Contains("ariq"))
            {
                Say("Ariq Böke fought bravely, though his fate was a hard lesson for the steppes.");
            }
            else if (speech.Contains("genghis"))
            {
                Say("Genghis Khan was my husband’s uncle, founder of our house and breaker of kingdoms.");
            }
            else if (speech.Contains("husband") || speech.Contains("tolui"))
            {
                Say("My husband, Tolui, was the youngest son of Genghis. His legacy endures through our children.");
            }
            else if (speech.Contains("mother"))
            {
                Say("The strength of mothers builds the spine of nations. Without us, even the bravest falter.");
            }
            else if (speech.Contains("wisdom"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even wisdom must wait its time. Return to me when the sun has crossed the sky once more.");
                }
                else
                {
                    Say("True wisdom is rarer than gold or conquest. Accept this Treasure Chest of Mongolia with my blessing.");
                    from.AddToBackpack(new TreasureChestOfMongolia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("sky"))
            {
                Say("The Eternal Blue Sky sees all. Under its gaze, all oaths are made and broken.");
            }
            else if (speech.Contains("horse") || speech.Contains("horses"))
            {
                Say("A Mongol’s heart beats with the hooves of horses. They are our wings and our freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the greatest prize of the steppe. It cannot be bought, only honored.");
            }
            else if (speech.Contains("conquest"))
            {
                Say("Conquest brings glory, but also burdens. The wise learn to balance both.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fire warms and destroys. Choose what you burn wisely.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("Our ancestors ride the wind. They watch, advise, and sometimes, warn.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Steppe legends are as endless as the grass. Will you add your own tale to them?");
            }
            else if (speech.Contains("grass"))
            {
                Say("Each blade of grass remembers a story, a song, or a sorrow.");
            }
			else if (speech.Contains("trade"))
			{
				Say("Trade ties the steppe to distant lands. Silk from China, jewels from Persia, knowledge from every corner—all pass through Mongol hands.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is harder to hold than any fortress. Only the wise and patient can build true peace across the vastness.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the tentpole of empire. Without it, even the greatest house collapses in dust.");
			}
			else if (speech.Contains("family"))
			{
				Say("A family’s strength is not in blood alone, but in loyalty, patience, and the willingness to forgive.");
			}
			else if (speech.Contains("friends"))
			{
				Say("A friend is a rare treasure. In the shifting winds of politics, trust is precious and must be guarded.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Treat your enemies with respect—they teach you caution, patience, and the value of peace.");
			}
			else if (speech.Contains("faith"))
			{
				Say("Faith is a fire that warms the soul, whatever god or spirit you name. Among my people, all beliefs found a home.");
			}
			else if (speech.Contains("yurt"))
			{
				Say("A yurt is more than a shelter. It is a circle of safety, a place for stories and songs to grow strong.");
			}
			else if (speech.Contains("food"))
			{
				Say("We feast on the bounty of the land—mare’s milk, mutton, cheese, and flat bread. Hospitality is sacred on the steppe.");
			}
			else if (speech.Contains("milk") || speech.Contains("airag"))
			{
				Say("Airag, the fermented milk of mares, is the taste of celebration. Share a cup with a stranger, and you have a friend for life.");
			}
			else if (speech.Contains("war"))
			{
				Say("War is a river: it carves new lands but leaves scars behind. Never forget what peace can offer.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Stories cross mountains and deserts. Tell yours with honesty, and it will endure long after you are gone.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are the hope of every tribe. Teach them well, and the world itself may change.");
			}
			else if (speech.Contains("learning") || speech.Contains("study"))
			{
				Say("To learn is to grow. Knowledge rides faster than any horse, and its treasures last far longer.");
			}
			else if (speech.Contains("travel"))
			{
				Say("To travel is to open your heart to wonder. The world is vast, and every horizon hides a lesson.");
			}
			else if (speech.Contains("winter"))
			{
				Say("Winter on the steppe is a stern teacher. Prepare well, or you may become one of its silent tales.");
			}
			else if (speech.Contains("ancient"))
			{
				Say("The ancient ways still shape us. Look to the past with respect, but do not be bound by its shadows.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("May the wind be your ally, and the stars your guide. Carry the steppe’s blessing wherever you roam.");
			}			
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Mongol songs speak of longing, victory, and the hush of distant horizons.");
            }
            else if (speech.Contains("queen") || speech.Contains("matriarch"))
            {
                Say("A queen must be strong as stone, gentle as dawn, and clever as the river.");
            }
            else if (speech.Contains("river") || speech.Contains("orkhon"))
            {
                Say("The Orkhon River nourished our ancestors and saw khans crowned beneath its banks.");
            }
            else if (speech.Contains("blessing"))
            {
                Say("A true blessing is not in words, but in actions—lead with courage, and you will be blessed.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future gallops toward us on the backs of wild horses. Be ready.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the Eternal Blue Sky shelter you on every road.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of khans, the steppe, vision, or the wisdom of the blue sky.");
                }
            }

            base.OnSpeech(e);
        }

        public SorghaghtaniBeki(Serial serial) : base(serial) { }

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
