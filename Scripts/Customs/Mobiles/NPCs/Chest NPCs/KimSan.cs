using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kim San")]
    public class KimSan : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KimSan() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kim San";
            Body = 0x190; // Human male

            // Unique Outfit
            AddItem(new Shirt() { Name = "Silk Scholar’s Hanbok", Hue = 2107 });
            AddItem(new Robe() { Name = "Cloak of the Morning Calm", Hue = 2411 });
            AddItem(new WideBrimHat() { Name = "Hat of the Free Thinker", Hue = 2420 });
            AddItem(new Boots() { Name = "Boots of Mountain Shadows", Hue = 2109 });
            AddItem(new BodySash() { Name = "Sash of Quiet Resolve", Hue = 2503 });

            // Weapon
            AddItem(new QuarterStaff() { Name = "Bamboo Staff of Memory", Hue = 2106 });

            // Speech
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
                Say("I am Kim San, a wanderer of memory and mountains. My name is not written in stone, but in the hearts of those who remember.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a keeper of stories, a teacher, and once, a resistance leader beneath the shadowed pines.");
            }
            else if (speech.Contains("health"))
            {
                Say("The body weathers many storms, but the spirit endures as long as the river flows.");
            }
            else if (speech.Contains("korea"))
            {
                Say("Korea is the Land of the Morning Calm, cradled by mountains, rivers, and a history both proud and sorrowful.");
            }
            else if (speech.Contains("resistance"))
            {
                Say("Resistance lives in every quiet act—each poem, each pine tree, each hand reaching for the dawn.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains shield our secrets. Under their watchful gaze, hope was forged in silence.");
            }
            else if (speech.Contains("hanbok"))
            {
                Say("The hanbok is more than clothing; it is a memory stitched into silk, worn by those who cherish the past.");
            }
            else if (speech.Contains("history"))
            {
                Say("History is a river, sometimes swift, sometimes slow, yet always carrying the songs of the people.");
            }
            else if (speech.Contains("pine"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The pine bows in the wind, but gives its gift only once each day. Return when the sun has climbed higher.");
                }
                else
                {
                    Say("You honor the spirit of the pine—steadfast and quiet. Take this Treasure Chest of North Korea, and carry forward its silent strength.");
                    from.AddToBackpack(new TreasureChestOfNorthKorea());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs rise like mist over the fields, carrying longing and hope to every corner of the land.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("Our ancestors walk with us, their voices a whisper in the wind. To remember them is to walk boldly into the future.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the lamp in the window on a long night, the promise that dawn will come.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is a bridge—cross it with care, for each step echoes with old footsteps.");
            }
            else if (speech.Contains("river"))
            {
                Say("The river never questions its path, yet it shapes the world in its quiet persistence.");
            }
            else if (speech.Contains("night"))
            {
                Say("Night holds many secrets, but always gives way to the light of a new morning.");
            }
			else if (speech.Contains("chollima"))
			{
				Say("The Chollima is a horse that could travel a thousand li in a day—a symbol of perseverance and unstoppable progress in our legends.");
			}
			else if (speech.Contains("tiger") || speech.Contains("mountain tiger"))
			{
				Say("Once, mountain tigers roamed our land—guardians of the forest, fierce and free. Some say their spirit still watches over us.");
			}
			else if (speech.Contains("poetry") || speech.Contains("poem"))
			{
				Say("A poem can outlast a sword. In hidden verses, our ancestors wrote of love, longing, and freedom.");
			}
			else if (speech.Contains("kimchi"))
			{
				Say("Kimchi—spicy, patient, and alive—reminds us that what is preserved with care nourishes future generations.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is both root and branch—those who came before, those who walk beside us, and those yet to be born.");
			}
			else if (speech.Contains("drum"))
			{
				Say("The sound of the drum calls us together. Its rhythm is the heartbeat of the village and the march of hope.");
			}
			else if (speech.Contains("lantern"))
			{
				Say("A lantern’s gentle glow can light a path through even the darkest forest. Sometimes, we must become our own lanterns.");
			}
			else if (speech.Contains("festival"))
			{
				Say("During the festival, laughter rings from every doorway and lanterns rise into the sky, carrying wishes and memories.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is a quiet field after harvest, a child’s laughter, the silence at sunrise before the world wakes.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind knows every secret of the land, carrying tales from one mountain to the next.");
			}
			else if (speech.Contains("tea"))
			{
				Say("A shared cup of tea brings strangers together and reminds us that life is best savored slowly.");
			}
			else if (speech.Contains("calligraphy"))
			{
				Say("Calligraphy is painting with words. Each brushstroke is a meditation, each character a wish for harmony.");
			}
			else if (speech.Contains("friendship"))
			{
				Say("Friendship is the bridge between distant shores. True friends meet in the quiet moments, as well as in the storm.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Every journey shapes us, whether it leads to a distant mountain or the quiet depths of our own heart.");
			}
			else if (speech.Contains("ancestor"))
			{
				Say("An ancestor’s story is a lantern in the night—follow its light, and you may find your own path forward.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is water—it takes the shape of its vessel and always finds its way, no matter how many stones are in its path.");
			}
			else if (speech.Contains("crane"))
			{
				Say("The crane is a symbol of long life and good fortune. Watch one in flight, and you will know grace.");
			}
			else if (speech.Contains("rice"))
			{
				Say("Rice sustains us; each grain is the fruit of a thousand hands, a thousand hopes.");
			}
			else if (speech.Contains("fog"))
			{
				Say("In the morning fog, even familiar paths seem new. Sometimes, we must trust our heart to guide us.");
			}
			else if (speech.Contains("promise"))
			{
				Say("A promise, once made, is like a seed beneath the snow. It may sleep long, but in time, it will bloom.");
			}
			else if (speech.Contains("gate") || speech.Contains("torii"))
			{
				Say("Passing through a gate marks a new beginning—a step from the known into the unknown, a journey of spirit as much as of foot.");
			}			
            else if (speech.Contains("shadow") || speech.Contains("shadows"))
            {
                Say("Even in the deepest shadow, a pine tree finds the courage to grow tall.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Every secret waits for the right question. What do you seek beneath the pines?");
            }
            else if (speech.Contains("moon"))
            {
                Say("The moon over Korea has witnessed countless dreams and sorrows—she is a silent companion to all who wander.");
            }
            else if (speech.Contains("sunrise"))
            {
                Say("With each sunrise, we are given another chance to shape the world’s story.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Travel well, and may the mountains keep your secrets safe.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the hanbok, the mountain, or the silent pines of Korea.");
                }
            }

            base.OnSpeech(e);
        }

        public KimSan(Serial serial) : base(serial) { }

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
