using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Nyatsimba Mutota")]
    public class NyatsimbaMutota : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public NyatsimbaMutota() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nyatsimba Mutota";
            Body = 0x190; // Human male body

            // Stats
            Str = 95;
            Dex = 70;
            Int = 105;
            Hits = 100;

            // Unique Appearance: King of Great Zimbabwe
            AddItem(new FormalShirt() { Name = "Royal Tunic of Great Zimbabwe", Hue = 2971 });
            AddItem(new FancyKilt() { Name = "King's Gold-Edged Kilt", Hue = 2212 });
            AddItem(new Cloak() { Name = "Mantle of the Spirit Birds", Hue = 2118 });
            AddItem(new Circlet() { Name = "Diadem of the Soapstone Oracle", Hue = 2630 });
            AddItem(new Sandals() { Name = "Sandals of the Lost Trade Roads", Hue = 2431 });
            AddItem(new BodySash() { Name = "Sash of the Mwenemutapa", Hue = 1375 });
            AddItem(new Scepter() { Name = "Scepter of Stone Wisdom", Hue = 2052 });

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
                Say("I am Nyatsimba Mutota, first of the Mutapa and son of Great Zimbabwe’s ancient kings.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I was king and oracle—builder of stone cities, seeker of destiny, shaper of nations.");
            }
            else if (speech.Contains("health"))
            {
                Say("Time wearies the flesh, but the spirit is as enduring as the walls I raised.");
            }
            else if (speech.Contains("zimbabwe"))
            {
                Say("Great Zimbabwe, heart of empire—its towers of stone and fields of gold still whisper to the wind.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Our empire stretched far, its riches flowing like rivers: gold, ivory, the wisdom of elders.");
            }
            else if (speech.Contains("kingdom"))
            {
                Say("My kingdom was built not only of stone, but of loyalty, trade, and the dreams of my people.");
            }
            else if (speech.Contains("stone"))
            {
                Say("Stone is our memory. The walls of Zimbabwe stand when all else crumbles.");
            }
            else if (speech.Contains("walls") || speech.Contains("ruins"))
            {
                Say("The ruins are bones of the land—home to spirits, to secrets, to legends unending.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Spirits walk the stones and the forests, guiding the worthy and confounding the greedy.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("We honor our ancestors in all things. Their wisdom and strength shaped the world you walk.");
            }
            else if (speech.Contains("bird") || speech.Contains("birds"))
            {
                Say("The soapstone birds are our guardians, silent and watchful atop the ancient towers.");
            }
            else if (speech.Contains("oracle"))
            {
                Say("Oracles interpret the will of the spirits, reading omens in bird, rain, and stone.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade brought wealth to Zimbabwe—gold for cloth, ivory for beads, knowledge for peace.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold gleamed in our rivers and made us rich. But wisdom is a rarer treasure.");
            }
            else if (speech.Contains("ivory"))
            {
                Say("Ivory, carved with patient hands, found its way to distant shores through the trade roads.");
            }
            else if (speech.Contains("road") || speech.Contains("roads"))
            {
                Say("The trade roads stretched farther than the eye could see—connecting people, stories, and fortunes.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("The greatest wisdom is patience. Listen to the stones, and they will teach you all you need.");
            }
            else if (speech.Contains("spirit bird") || speech.Contains("spirit birds"))
            {
                Say("Spirit birds appear in dreams and on the towers—messengers of ancestors and guardians of destiny.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Many secrets hide in the ruins. Some are waiting for the curious and respectful.");
            }
            else if (speech.Contains("mwenemutapa") || speech.Contains("mutapa"))
            {
                Say("Mwenemutapa means 'lord of the plundered lands'. My line ruled with the favor of ancestors and spirits.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends outlive even the greatest stones. Will you be part of one?");
            }
            else if (speech.Contains("tower") || speech.Contains("towers"))
            {
                Say("The towers rise above the plains, built without mortar—each stone placed with care and vision.");
            }
            else if (speech.Contains("care") || speech.Contains("vision"))
            {
                Say("Care and vision built Zimbabwe’s towers, as it builds all lasting things.");
            }
			else if (speech.Contains("family"))
			{
				Say("Family is a wellspring. My father taught me the patience of stone, my mother the wisdom of rivers.");
			}
			else if (speech.Contains("father"))
			{
				Say("My father was a king among kings. His hands shaped the first towers, his voice calmed storms.");
			}
			else if (speech.Contains("mother"))
			{
				Say("My mother sang to the rain and guided the healers. Her kindness endures in every blade of grass.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a blessing and a trial. When it falls, the spirits rejoice and the land remembers its youth.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("The rivers carry more than water—they bear stories, gold, and the dreams of wandering traders.");
			}
			else if (speech.Contains("cattle"))
			{
				Say("Cattle are wealth and kin. Their lowing echoes through the hills, their horns rise like the towers.");
			}
			else if (speech.Contains("horn") || speech.Contains("horns"))
			{
				Say("Horns crown the mightiest cattle, just as diadems crown kings. Each tells a story of struggle and pride.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the hope of our nation. To teach them is to shape the future itself.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future is stone unwritten. What you carve into it becomes legend for those who follow.");
			}
			else if (speech.Contains("past"))
			{
				Say("The past is a teacher with many lessons. Do not ignore the warnings of fallen walls.");
			}
			else if (speech.Contains("shona"))
			{
				Say("The Shona are builders, farmers, poets. Their hands shaped the land and their words shaped our songs.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("Songs echo in the stones. They speak of birth, triumph, loss, and the return of rain.");
			}
			else if (speech.Contains("healer") || speech.Contains("healers"))
			{
				Say("Healers know the language of plants and bones. They listen to the earth and answer with care.");
			}
			else if (speech.Contains("spirit world"))
			{
				Say("The spirit world lies just beyond the firelight. The wise know when to listen, and when to fear.");
			}
			else if (speech.Contains("time"))
			{
				Say("Time is a river with many bends. Only the most patient see where it truly leads.");
			}
			else if (speech.Contains("mystery") || speech.Contains("mysteries"))
			{
				Say("Mysteries keep the mind sharp. Only the foolish claim to know all that the stones conceal.");
			}
			else if (speech.Contains("bird statue") || speech.Contains("bird statues"))
			{
				Say("The bird statues are guardians, not idols. Each faces a direction of the wind, each remembers a king.");
			}
			else if (speech.Contains("guardian") || speech.Contains("guardians"))
			{
				Say("Guardians take many forms: a stone bird, a loyal friend, a mother’s gaze, a secret oath.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("Some say a new king will rise when the stone birds take flight. Until then, we watch, we wait.");
			}
			else if (speech.Contains("watch"))
			{
				Say("To watch is to learn. The stones have eyes, and the birds see much from their silent perch.");
			}			
            else if (speech.Contains("destiny"))
            {
                Say("Destiny is written in the earth and sky, and read by those who dare to listen.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("soapstone"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, seeker. The stone birds do not sing twice for the same visitor in a single day.");
                }
                else
                {
                    Say("The spirits smile upon your curiosity. Accept this Treasure Chest of Great Zimbabwe—may it bring you wisdom as well as gold.");
                    from.AddToBackpack(new TreasureChestOfGreatZimbabwe());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the ancestors guide your steps and the spirit birds watch your journey.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of stone, empire, spirit birds, or the secrets hidden in the ruins of Zimbabwe.");
                }
            }

            base.OnSpeech(e);
        }

        public NyatsimbaMutota(Serial serial) : base(serial) { }

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
