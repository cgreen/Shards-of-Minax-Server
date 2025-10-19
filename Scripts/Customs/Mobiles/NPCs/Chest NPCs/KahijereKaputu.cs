using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kahijere Kaputu")]
    public class KahijereKaputu : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KahijereKaputu() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kahijere Kaputu";
            Body = 0x190; // Human male body

            // Stats
            Str = 85;
            Dex = 60;
            Int = 110;
            Hits = 80;

            // Unique Appearance: Desert Herero Elder
            AddItem(new ElvenShirt() { Name = "Dune-Woven Tunic", Hue = 2215 });
            AddItem(new GuildedKilt() { Name = "Herero Storyteller's Kilt", Hue = 2619 });
            AddItem(new Cloak() { Name = "Oryx-hide Cloak", Hue = 1801 });
            AddItem(new FeatheredHat() { Name = "Desert Moon Headdress", Hue = 1161 });
            AddItem(new FurBoots() { Name = "Sandwalker Boots", Hue = 1833 });
            AddItem(new BodySash() { Name = "Sash of Remembrance", Hue = 2700 });
            AddItem(new TribalMask() { Name = "Ancestor's Mask", Hue = 2107 });
            AddItem(new QuarterStaff() { Name = "Staff of Distant Thunder", Hue = 2328 });

            SpeechHue = 1869;

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
                Say("I am Kahijere Kaputu, keeper of stories, walker of dunes, child of the Herero people.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am an old storyteller and guide. My task is to remember, so that none are truly lost in the desert or in time.");
            }
            else if (speech.Contains("health"))
            {
                Say("The desert shapes the body and the spirit. I endure as the thorn bush endures, patient beneath the sun.");
            }
            else if (speech.Contains("herero"))
            {
                Say("The Herero are a people of cattle, desert, and storm. We have crossed many hardships and still walk with pride.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The Namib desert is older than memory. Its winds sing with both sorrow and hope. Ask me of its secrets or its dangers.");
            }
            else if (speech.Contains("namib"))
            {
                Say("Namib means 'vast place.' Here, time moves with the sand. Legends live in every shifting dune.");
            }
            else if (speech.Contains("secrets"))
            {
                Say("The desert keeps many secrets: buried rivers, vanished villages, bones of oryx, and silent mirages.");
            }
            else if (speech.Contains("dune") || speech.Contains("dunes"))
            {
                Say("Each dune is like a wave in an endless sea. They shift each night—never the same at sunrise.");
            }
            else if (speech.Contains("mirage"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A true mirage vanishes when chased, traveler. Return when the sun has crossed the sky.");
                }
                else
                {
                    Say("Few find treasure in a mirage, but you have wisdom enough to see the truth beneath illusions. Take this, with the blessings of my ancestors.");
                    from.AddToBackpack(new TreasureChestOfNamibia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("storm"))
            {
                Say("Desert storms are sudden and fierce. They can wipe away tracks—or reveal what was hidden for centuries.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors walk with us in shadow and in dream. Listen for their whispers when the wind is quiet.");
            }
            else if (speech.Contains("cattle"))
            {
                Say("Cattle are the heart of Herero life. In times of peace, their songs fill the air. In times of war, they are our hope.");
            }
            else if (speech.Contains("war"))
            {
                Say("There was a time of great sorrow, when our people faced the darkness of colonial war. Many were lost, but some endured.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is a stubborn plant. It grows even in dry sand, so long as the spirit tends to it.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("The spirit is a well deeper than any oasis. It is strength when water runs out and dreams when sleep will not come.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Each story is a seed. Some grow wild, some are carried by the wind. What story do you carry, traveler?");
            }
            else if (speech.Contains("sand"))
            {
                Say("Sand wears down even the hardest stone, and yet, every grain is part of the whole desert.");
            }
			else if (speech.Contains("okavango") || speech.Contains("delta"))
			{
				Say("The Okavango Delta is a miracle—a river that disappears into the sand. In its season, life blooms where there was only dust.");
			}
			else if (speech.Contains("oryx"))
			{
				Say("The oryx stands proud on the plain, horns high. It is a symbol of grace and survival in harsh places.");
			}
			else if (speech.Contains("lion"))
			{
				Say("Lions once ruled these lands, teaching courage and the wisdom of patience. They hunt by night and rest by the cool stones.");
			}
			else if (speech.Contains("tracks"))
			{
				Say("Tracks in the sand tell silent stories. Even the smallest beetle leaves a path, if you have eyes to see.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun is both friend and trial in the Namib. It teaches humility and respect. Never challenge it without water.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("At night, the stars gather like a council of ancestors. We learned the old roads by their shining paths.");
			}
			else if (speech.Contains("fire"))
			{
				Say("A small fire is a treasure in the cold desert night. Around it, stories grow and worries shrink.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is slow to arrive, like rain in the desert. When it comes, celebrate and share it freely.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A friend found on a long journey is worth more than gold. In the desert, a friend may save your life.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The desert wind erases footprints, but not memories. It carries old songs, if you listen closely.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("Herero songs rise at sunrise and sunset. Some are for joy, some for sorrow, all are for remembering.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Every journey changes you. To walk the dunes is to learn about yourself, and those who came before.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the first shelter against any storm. Their names are as precious as water to a thirsty traveler.");
			}
			else if (speech.Contains("healer"))
			{
				Say("Our healers know many plants—some bitter, some sweet. In their hands, the desert offers medicine as well as danger.");
			}
			else if (speech.Contains("plant") || speech.Contains("plants"))
			{
				Say("Desert plants are wise—they hide water and protect their roots. They survive where others fail.");
			}
			else if (speech.Contains("shadow"))
			{
				Say("In the heat of day, even a small shadow feels like a blessing. Never underestimate small comforts.");
			}
			else if (speech.Contains("comfort"))
			{
				Say("Comfort is found in simple things: shade, water, a friend’s voice. Seek these, and the desert will be kind.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Fear can be a guide or a chain. The wise listen to their fear, but do not let it rule their steps.");
			}
			else if (speech.Contains("strength"))
			{
				Say("Strength is not only in the body, but in the will to rise after falling.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is not only a place, but a memory you carry. Even wandering, the heart remembers its true home.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future grows from the seeds of today. Walk with care, and leave good tracks for those who follow.");
			}			
            else if (speech.Contains("water"))
            {
                Say("To find water in the Namib is to find life. Look to the roots of the nara melon or the paths of the desert elephant.");
            }
            else if (speech.Contains("melon"))
            {
                Say("The nara melon is a gift of the desert. Its roots run deep, and its fruit brings both food and water.");
            }
            else if (speech.Contains("elephant"))
            {
                Say("Desert elephants walk great distances for survival. They teach patience and the memory of hidden paths.");
            }
            else if (speech.Contains("patience"))
            {
                Say("In the desert, patience is a sharper blade than any spear. Time rewards those who do not hurry.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                // Do not hint at the reward; keep it subtle
                Say("Some things are not found by asking, but by journeying.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the cool shadow of the acacia shelter you, traveler. Farewell.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Namib, dunes, ancestors, or the mirage that walks at midday.");
                }
            }

            base.OnSpeech(e);
        }

        public KahijereKaputu(Serial serial) : base(serial) { }

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
