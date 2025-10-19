using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Moshoeshoe I")]
    public class Moshoeshoe : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Moshoeshoe() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Moshoeshoe I";
            Body = 0x190; // Human male

            // Unique Appearance: Basotho King
            AddItem(new ElvenShirt() { Name = "Royal Basotho Shirt", Hue = 1159 }); // deep blue
            AddItem(new GuildedKilt() { Name = "Kilt of Unity", Hue = 1175 }); // rich gold
            AddItem(new Cloak() { Name = "Lesotho Sky Cloak", Hue = 1118 }); // sky blue
            AddItem(new TribalMask() { Name = "Mokorotlo Headdress", Hue = 2101 }); // straw yellow
            AddItem(new FurBoots() { Name = "Boots of the Maloti", Hue = 2055 }); // earthy brown
            AddItem(new BodySash() { Name = "Sash of Peace", Hue = 1272 }); // pure white

            // Weapon: Staff as symbol of leadership
            AddItem(new QuarterStaff() { Name = "Staff of the Great Chief", Hue = 1157 });

            SpeechHue = 2125; // unique speech color

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
                Say("I am Moshoeshoe, first King of the Basotho, guardian of the mountain kingdom.");
            }
            else if (speech.Contains("job"))
            {
                Say("I unite the Basotho people, defend our land, and strive for peace among nations.");
            }
            else if (speech.Contains("health"))
            {
                Say("My heart is steady as the mountains, though years of hardship have left their mark.");
            }
            else if (speech.Contains("basotho"))
            {
                Say("The Basotho are my people, bound by unity, courage, and our love for the mountains.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains") || speech.Contains("maloti"))
            {
                Say("The Maloti Mountains shelter us. They are our fortress, our home, and the source of our strength.");
            }
            else if (speech.Contains("kingdom"))
            {
                Say("Our kingdom was built upon unity, wisdom, and respect for all who seek peace.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is a river—those who drink from it must also listen to its quiet flow.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is hard-won and easily lost. We must guard it as one guards a precious cattle herd.");
            }
            else if (speech.Contains("cattle"))
            {
                Say("Cattle are the wealth of the Basotho, but true wealth is the harmony of our people.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is our shield. Alone we are vulnerable; together, as a people, we endure.");
            }
            else if (speech.Contains("history"))
            {
                Say("Our story is one of survival, of gathering scattered clans into a single family.");
            }
            else if (speech.Contains("clans"))
            {
                Say("Many clans once fought over small things. Together, we are strong enough to withstand any storm.");
            }
            else if (speech.Contains("storm") || speech.Contains("storms"))
            {
                Say("Storms come and go, but the mountains remain. Like them, we must endure.");
            }
            else if (speech.Contains("land"))
            {
                Say("This land is sacred. Each stone, each blade of grass remembers the footsteps of our ancestors.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("We honor our ancestors with every wise choice and every act of kindness.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("A wise ruler listens before speaking and learns before leading.");
            }
            else if (speech.Contains("diplomacy"))
            {
                Say("With diplomacy, I persuaded enemies to become neighbors, and strangers to become family.");
            }
            else if (speech.Contains("enemy") || speech.Contains("enemies"))
            {
                Say("A true enemy is one who refuses peace, but sometimes even enemies can be taught the language of unity.");
            }
            else if (speech.Contains("british") || speech.Contains("colony"))
            {
                Say("To survive, I sought protection from the British—better to choose a distant king than face ruin at home.");
            }
            else if (speech.Contains("zulu") || speech.Contains("mfecane"))
            {
                Say("The Mfecane brought chaos and fear, but also taught us the importance of standing together.");
            }
            else if (speech.Contains("mokorotlo"))
            {
                Say("The Mokorotlo, our conical hat, is a symbol of Basotho identity and pride.");
            }
            else if (speech.Contains("blanket"))
            {
                Say("The Basotho blanket is more than warmth—it is a symbol of our heritage, worn with honor.");
            }
            else if (speech.Contains("heritage"))
            {
                Say("Our heritage is our shield and our song. Never forget where you come from.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs tell of cattle, mountains, and the long road of the Basotho people.");
            }
            else if (speech.Contains("founder") || speech.Contains("found"))
            {
                Say("I gathered the lost, the scattered, and the fearful, forging a new people from many.");
            }
            else if (speech.Contains("wisdom") || speech.Contains("wise"))
            {
                Say("Wisdom is my weapon, patience my shield.");
            }
            else if (speech.Contains("maloti"))
            {
                Say("The Maloti are more than mountains—they are the spine of Lesotho, and the heart of our story.");
            }
            else if (speech.Contains("horse") || speech.Contains("horses"))
            {
                Say("Our horses are swift and sure-footed, carrying news and hope across mountain paths.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who honor the past and welcome each sunrise with courage.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is facing the storm with open eyes and a steady heart.");
            }
            else if (speech.Contains("strength"))
            {
                Say("Strength comes from unity, from kindness, and from enduring the long winter.");
            }
			else if (speech.Contains("friend"))
			{
				Say("A friend is a shelter from the wind. Welcome among the Basotho, traveler.");
			}
			else if (speech.Contains("wisdom tooth"))
			{
				Say("Even a wisdom tooth can cause pain—so it is with knowledge untempered by kindness.");
			}
			else if (speech.Contains("blanket") || speech.Contains("blankets"))
			{
				Say("Basotho blankets are woven with meaning. Each pattern tells a story—of rain, cattle, or kinship.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a blessing and a trial. Our songs greet the storm as both friend and test.");
			}
			else if (speech.Contains("hut") || speech.Contains("huts") || speech.Contains("house"))
			{
				Say("A house of reeds may shelter a king if the walls are strong with love.");
			}
			else if (speech.Contains("river"))
			{
				Say("Rivers carve valleys and shape destinies. Listen to the water, and it will guide your way.");
			}
			else if (speech.Contains("market"))
			{
				Say("At the market, all voices mingle: news from far, laughter, and sometimes even secrets worth keeping.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals light the dark months. There, you may see dancers leap as high as the peaks, and taste the gifts of our land.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are our tomorrow. Teach them respect for the mountain and wisdom in the heart.");
			}
			else if (speech.Contains("chief"))
			{
				Say("A chief does not stand above his people, but walks among them, listening to their needs.");
			}
			else if (speech.Contains("courageous"))
			{
				Say("The most courageous is not always the strongest, but the one who rises after every fall.");
			}
			else if (speech.Contains("spear"))
			{
				Say("I prefer words to the spear, but even words must sometimes be guarded with steel.");
			}
			else if (speech.Contains("wound") || speech.Contains("wounds"))
			{
				Say("A wound on the land can heal, if hands are gentle and hearts sincere.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("On clear nights, the stars remind us of our ancestors, watching and guiding from afar.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("I have learned much from enemies; sometimes, they teach more than friends.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is not just blood, but all those who share your hopes and stand with you in trouble.");
			}
			else if (speech.Contains("past"))
			{
				Say("The past is a wise teacher—its lessons are written in stone, and in the stories of old ones.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is a seed. If you tend it, it will take root even in stony ground.");
			}
			else if (speech.Contains("bread"))
			{
				Say("To share bread is to share peace. Sit, eat, and let your worries rest a while.");
			}
			else if (speech.Contains("feast"))
			{
				Say("A feast for the body is good, but a feast for the soul is better—kindness, laughter, and song.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Enemies test our resolve, and sometimes force us to discover hidden strengths.");
			}
			else if (speech.Contains("ancestor"))
			{
				Say("Our ancestors watch, waiting to see if we honor the path they laid for us.");
			}
			else if (speech.Contains("famine"))
			{
				Say("In famine, the strong help the weak. This is the Basotho way.");
			}
			else if (speech.Contains("rock") || speech.Contains("rocks"))
			{
				Say("Every rock in these mountains has seen the rise and fall of chiefs. Listen to them; they remember.");
			}
			else if (speech.Contains("pride"))
			{
				Say("Take pride in your deeds, but leave space for humility. The mountain is tall, but the sky is taller.");
			}
			else if (speech.Contains("missionary") || speech.Contains("missionaries"))
			{
				Say("The missionaries brought new words and ways. Some seeds took root, others were carried away by the wind.");
			}
			else if (speech.Contains("medicine"))
			{
				Say("Our medicine comes from roots and leaves, but also from a healer’s listening heart.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire brings warmth and danger alike. Guard your hearth, and share your flame with those in need.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Every journey begins with a single step, and the wise traveler listens to every guide.");
			}
			else if (speech.Contains("gift"))
			{
				Say("The greatest gift is a kind word. The second is a helping hand.");
			}			
            else if (speech.Contains("lesotho"))
            {
                Say("Lesotho is the mountain kingdom—a land of sky, stone, and stories.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May you climb high and see far, friend of the Basotho.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("mokhotlong"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. The treasures of the mountains come only to those who respect their silence.");
                }
                else
                {
                    Say("You know well the hidden valleys. Take this Treasure Chest of Lesotho—may it remind you of the heights and hopes of our people.");
                    from.AddToBackpack(new TreasureChestOfLesotho());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Maloti, the Basotho blanket, unity, or the storms of our history.");
                }
            }

            base.OnSpeech(e);
        }

        public Moshoeshoe(Serial serial) : base(serial) { }

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
