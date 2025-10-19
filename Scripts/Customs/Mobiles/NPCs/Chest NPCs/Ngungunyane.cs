using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ngungunyane")]
    public class Ngungunyane : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Ngungunyane() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ngungunyane";
            Title = "Lion of Gaza";
            Body = 0x190; // Human male

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Rafiki Shirt of the Zambezi", Hue = 2709 });
            AddItem(new GuildedKilt() { Name = "Imperial Kilt of Gaza", Hue = 2120 });
            AddItem(new Cloak() { Name = "Cape of the Limpopo", Hue = 2101 });
            AddItem(new HornedTribalMask() { Name = "Lion Mask of Ngungunyane", Hue = 2119 });
            AddItem(new FurBoots() { Name = "Boots of Maputo Sands", Hue = 2736 });
            AddItem(new BodySash() { Name = "Sash of the Shangana", Hue = 1161 });

            // Weapon: Scepter as symbol of rule
            AddItem(new Scepter() { Name = "Scepter of the Zulu Dawn", Hue = 2001 });

            // Speech Hue
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
                Say("I am Ngungunyane, Lion of Gaza, son of the river and the empire's last flame.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I was emperor of the Gaza people, ruler from the Limpopo to the Indian Ocean.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body may be old, but the blood of lions and ancestors still runs strong within me.");
            }
            else if (speech.Contains("gaza"))
            {
                Say("The Gaza Empire was my home and my burden. Its drums still echo in the valleys and dreams of my people.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires rise and fall, but memory is a river—always flowing, never dying.");
            }
            else if (speech.Contains("river"))
            {
                Say("The Limpopo nourished us, carried our secrets, and sometimes our sorrow.");
            }
            else if (speech.Contains("lion"))
            {
                Say("The lion is my spirit—fierce, proud, untamed. Speak of the lion, and you speak of Gaza's courage.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("The ancestors whisper in the wind, guiding the wise and warning the foolish.");
            }
            else if (speech.Contains("resistance"))
            {
                Say("We fought the foreign invaders, refusing to kneel. Even in defeat, our spirit was not broken.");
            }
            else if (speech.Contains("defeat"))
            {
                Say("A lion may be caged, but his roar will haunt the dreams of conquerors.");
            }
            else if (speech.Contains("maputo"))
            {
                Say("Maputo, once called Lourenço Marques, was the mouth of my empire—where the rivers meet the sea.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are more than sleep—they are the path to the ancestors and the drumbeat of tomorrow.");
            }
            else if (speech.Contains("drums") || speech.Contains("drum"))
            {
                Say("The drums of Gaza told our stories—of war, of harvest, of hope. Even now, can you not hear them?");
            }
            else if (speech.Contains("zambezi"))
            {
                Say("The Zambezi is mighty and restless, like my people. It feeds life, but demands respect.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not gold, but the memory of a people who would not bow.");
            }
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is as precious as the first rain—worth fighting for, even in the face of storms.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms teach us humility and strength. A wise ruler learns when to bend and when to stand firm.");
			}
			else if (speech.Contains("family"))
			{
				Say("My family was my shield and my weakness. A leader stands tallest when his roots run deep.");
			}
			else if (speech.Contains("mother"))
			{
				Say("My mother, Nwamanungu, taught me patience and the power of a quiet word.");
			}
			else if (speech.Contains("father"))
			{
				Say("My father, Mzila, ruled before me. His footsteps marked the path I was destined to follow.");
			}
			else if (speech.Contains("music"))
			{
				Say("Music in Gaza was more than celebration—it was memory, prophecy, and sometimes, defiance.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("It was said: 'When the lion’s mane is silvered by dust, the land will thirst for a new dawn.' Some still wait for that day.");
			}
			else if (speech.Contains("trade"))
			{
				Say("We traded ivory, gold, and cloth across the riverways—our markets alive with voices from distant lands.");
			}
			else if (speech.Contains("market") || speech.Contains("markets"))
			{
				Say("The markets of Gaza were rivers of color and song—gifts from the earth, laughter from the people.");
			}
			else if (speech.Contains("elephant") || speech.Contains("elephants"))
			{
				Say("Elephants walked the forests like ancient kings. To honor them was to honor the strength of the land.");
			}
			else if (speech.Contains("forest") || speech.Contains("forests"))
			{
				Say("The forests whispered secrets to those who listened. Hunters, healers, and dreamers all found wisdom beneath the trees.");
			}
			else if (speech.Contains("healer") || speech.Contains("healers"))
			{
				Say("Our healers—mambas—knew the language of roots and spirits. Their hands mended wounds no blade could reach.");
			}
			else if (speech.Contains("roots"))
			{
				Say("Roots bind the tree to earth, just as stories bind people to memory. Dig deep, and you will find your own strength.");
			}
			else if (speech.Contains("spirit world") || speech.Contains("ancient"))
			{
				Say("The ancient ones walk beside us, unseen. Every shadow, every breeze, carries a story from the spirit world.");
			}
			else if (speech.Contains("sunrise"))
			{
				Say("With every sunrise, hope is reborn. What will you build with the light you are given?");
			}
			else if (speech.Contains("sorrow"))
			{
				Say("Sorrow is a heavy cloak, but it can teach us gentleness, if we do not let it blind us.");
			}
			else if (speech.Contains("wisdom tooth"))
			{
				Say("Haha! In my day, we said: 'A chief with a sore wisdom tooth listens better than one with a sharp spear.'");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory is the drumbeat that calls us home. Forget your story, and you are lost to the wind.");
			}			
            else if (speech.Contains("spirit"))
            {
                Say("Spirit endures beyond chains. The spirit of Gaza travels with every Shangana child.");
            }
            else if (speech.Contains("shangana"))
            {
                Say("The Shangana people are the heart of Gaza, and their stories are carved in the earth itself.");
            }
            else if (speech.Contains("portuguese") || speech.Contains("invader") || speech.Contains("colonial"))
            {
                Say("The Portuguese came with iron and fire, but found that the heart of Gaza could not be burned away.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is the sun—rising every day, even behind clouds. Tell me, what do you seek: gold, glory, or wisdom?");
            }
            else if (speech.Contains("wisdom"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even wisdom comes with patience, child of the river. Return when the sun has crossed the sky.");
                }
                else
                {
                    Say("You have listened well. Accept this Treasure Chest of Mozambique’s History, and may its contents teach you the stories of the land.");
                    from.AddToBackpack(new TreasureChestOfMozambiqueHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the lions watch over you and the river guide your steps. Farewell.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Gaza Empire, the river Limpopo, or the lion’s courage.");
                }
            }

            base.OnSpeech(e);
        }

        public Ngungunyane(Serial serial) : base(serial) { }

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
