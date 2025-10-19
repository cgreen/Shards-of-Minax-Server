using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hanan Ashrawi")]
    public class HananAshrawi : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HananAshrawi() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hanan Ashrawi";
            Body = 0x191; // Human female body

            // Unique Palestinian-themed appearance
            AddItem(new FancyDress() { Name = "Tatreez Robe of Heritage", Hue = 2119 });
            AddItem(new BodySash() { Name = "Sash of Olive Branches", Hue = 1437 });
            AddItem(new Cloak() { Name = "Cloak of Jerusalem Dawn", Hue = 1153 });
            AddItem(new Sandals() { Name = "Bethlehem Sandals", Hue = 1808 });
            AddItem(new FlowerGarland() { Name = "Wreath of Almond Blossoms", Hue = 1150 });

            // Symbolic staff
            AddItem(new QuarterStaff() { Name = "Staff of Dialogue", Hue = 1501 });

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
                Say("I am Hanan Ashrawi, voice of Palestine and advocate for justice and peace.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a diplomat, educator, and a writer. I serve the cause of my people on the world stage.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though weary from the struggle, my resolve and hope endure.");
            }
            else if (speech.Contains("palestine"))
            {
                Say("Palestine is my homeland, ancient and enduring, blessed with olive trees and poetry.");
            }
            else if (speech.Contains("olive") || speech.Contains("tree"))
            {
                Say("The olive tree is our symbol of endurance and peace. Its roots run deep in Palestinian soil.");
            }
            else if (speech.Contains("heritage"))
            {
                Say("Our heritage is woven with courage, poetry, and the yearning for freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is not given, it is claimed through persistence and truth.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice is the foundation of peace. Without it, there can be no true reconciliation.");
            }
            else if (speech.Contains("diplomat") || speech.Contains("diplomacy"))
            {
                Say("Diplomacy is the art of words, turning pain into purpose and conflict into conversation.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a bridge built stone by stone, with patience and courage.");
            }
            else if (speech.Contains("voice"))
            {
                Say("Our voices are our most powerful tools. Stories can shape the destiny of nations.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every family, every stone, every olive tree carries a story waiting to be heard.");
            }
            else if (speech.Contains("poetry"))
            {
                Say("Palestinian poetry weaves sorrow and hope into lines that outlast empires.");
            }
            else if (speech.Contains("education"))
            {
                Say("Education is our lantern in the darkness. Knowledge cannot be taken from us.");
            }
            else if (speech.Contains("lantern"))
            {
                Say("A single lantern can light a thousand paths, even in troubled times.");
            }
            else if (speech.Contains("path") || speech.Contains("paths"))
            {
                Say("The paths to peace are winding and steep, but each step forward is a victory.");
            }
            else if (speech.Contains("bethlehem"))
            {
                Say("Bethlehem is a city of faith and history, its stars watching over generations.");
            }
            else if (speech.Contains("jerusalem"))
            {
                Say("Jerusalem, heart of longing, sacred to many, forever at the crossroads of hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is not a luxury—it is our right and our burden. It keeps us moving forward.");
            }
            else if (speech.Contains("blossom") || speech.Contains("blossoms"))
            {
                Say("Even in hardship, the almond blossoms return each spring—a promise of renewal.");
            }
            else if (speech.Contains("promise"))
            {
                Say("We live on promise and memory, weaving a future from the strength of our past.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is a garden; what we tend survives, what we neglect is lost.");
            }
            else if (speech.Contains("refugee"))
            {
                Say("Refugees carry Palestine in their hearts, from camp to camp, from one generation to the next.");
            }
            else if (speech.Contains("return"))
            {
                Say("The dream of return is planted deep within every exile, watered by memory and longing.");
            }
            else if (speech.Contains("longing"))
            {
                Say("Longing gives us strength, not weakness. It is the thread that binds our people together.");
            }
            else if (speech.Contains("rights"))
            {
                Say("Rights denied to one are rights denied to all. We strive for dignity, equality, and freedom.");
            }
            else if (speech.Contains("dignity"))
            {
                Say("Dignity is not a gift—it is the birthright of every person.");
            }
			else if (speech.Contains("faith"))
			{
				Say("Faith is not only a matter of religion, but of believing in justice and a future for our children.");
			}
			else if (speech.Contains("children") || speech.Contains("future"))
			{
				Say("Every child carries the promise of a new day. Our struggles today plant seeds for their tomorrow.");
			}
			else if (speech.Contains("ancestors"))
			{
				Say("Our ancestors walked these lands, planting olive trees and building villages of memory. We are their voice.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Palestinian music tells of love, longing, and laughter—each note another thread in our tapestry.");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar") || speech.Contains("souq"))
			{
				Say("The markets of Palestine bustle with life—spices, laughter, and tales traded under colorful awnings.");
			}
			else if (speech.Contains("spices"))
			{
				Say("Za'atar, sumac, and cardamom—these scents tie us to home, no matter where we roam.");
			}
			else if (speech.Contains("food") || speech.Contains("bread"))
			{
				Say("Bread is sacred to us. Each loaf is a symbol of hospitality and survival.");
			}
			else if (speech.Contains("hospitality"))
			{
				Say("To share bread is to share peace. Our doors are always open to those who come in friendship.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("In times of hardship, a true friend is a shelter from the storm.");
			}
			else if (speech.Contains("storm") || speech.Contains("trouble"))
			{
				Say("No storm lasts forever, though it may test the strength of our roots.");
			}
			else if (speech.Contains("roots"))
			{
				Say("A tree stands tall only if its roots are deep and strong. We are rooted in our land and our love.");
			}
			else if (speech.Contains("flag"))
			{
				Say("Our flag carries the colors of hope, sacrifice, and unity. It is a banner for all who dream of freedom.");
			}
			else if (speech.Contains("sacrifice"))
			{
				Say("Every generation has known sacrifice. From struggle, we draw both pain and pride.");
			}
			else if (speech.Contains("pride"))
			{
				Say("Pride does not blind us; it gives us strength to stand tall, even in the darkest hour.");
			}
			else if (speech.Contains("hour") || speech.Contains("time"))
			{
				Say("Time tests us, but also teaches us. The land remembers every moment.");
			}
			else if (speech.Contains("land"))
			{
				Say("This land is more than soil and stone—it is story, memory, and home.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is not just a place, but the people and dreams we carry within us.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is born of experience—joy and sorrow together. Listen, and you may hear its quiet voice.");
			}
			else if (speech.Contains("listen"))
			{
				Say("Listening is the beginning of understanding. In every silence, a story awaits.");
			}
			else if (speech.Contains("understanding"))
			{
				Say("True understanding bridges distances that words alone cannot cross.");
			}
			else if (speech.Contains("crossroads"))
			{
				Say("Palestine is a crossroads—of trade, faith, and story. Many paths meet here, and all are changed by the journey.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Our journey is long and often hard, but every step is guided by hope.");
			}
			else if (speech.Contains("guide"))
			{
				Say("Guidance comes from many places—a wise elder, a story, or the quiet strength of the land.");
			}
			else if (speech.Contains("elder"))
			{
				Say("Our elders are libraries of living memory. Respect them, and learn from their years.");
			}			
            else if (speech.Contains("heritage"))
            {
                Say("Our heritage is our shield and our map—it shows us who we are, and who we may become.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Palestine’s secrets lie in ancient stones and whispered songs. Seek the word 'sumud' to understand our strength.");
            }
            // SECRET REWARD KEYWORD: sumud (Palestinian Arabic for "steadfastness")
            else if (speech.Contains("sumud"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Steadfastness is a journey, not a moment. You must wait before claiming this gift again.");
                }
                else
                {
                    Say("Your steadfast heart honors Palestine. Accept this Treasure Chest of Palestine as a symbol of resilience.");
                    from.AddToBackpack(new TreasureChestOfPalestine());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May hope and courage walk with you always, friend.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of olive trees, Jerusalem, justice, or the meaning of sumud.");
                }
            }

            base.OnSpeech(e);
        }

        public HananAshrawi(Serial serial) : base(serial) { }

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
