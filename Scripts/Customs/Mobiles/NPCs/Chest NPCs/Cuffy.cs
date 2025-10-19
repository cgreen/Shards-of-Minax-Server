using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Cuffy")]
    public class Cuffy : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Cuffy() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Cuffy";
            Body = 0x190; // Human male

            // Unique Appearance: Guyanese Freedom Hero
            AddItem(new ElvenShirt() { Name = "Freedom-Fighter's Tunic", Hue = 2075 });
            AddItem(new GuildedKilt() { Name = "Berbice Rebel Sash", Hue = 2653 });
            AddItem(new Cloak() { Name = "Cloak of the Rainforest", Hue = 1428 });
            AddItem(new FeatheredHat() { Name = "Hat of the Maroon Chiefs", Hue = 2413 });
            AddItem(new FurBoots() { Name = "Boots of the Demerara Plains", Hue = 1813 });
            AddItem(new BodySash() { Name = "Golden Sash of Guyana", Hue = 2122 });
            AddItem(new TribalMask() { Name = "Mask of Kofi", Hue = 1109 });

            // Weapon: Spear (symbol of leadership)
            AddItem(new ShortSpear() { Name = "Spear of Berbice", Hue = 1271 });

            SpeechHue = 2120;

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
                Say("I am Cuffy, son of Africa, spirit of Berbice, and voice for the enslaved.");
            }
            else if (speech.Contains("job"))
            {
                Say("I once led a rebellion against those who chained my people. Freedom is my only cause.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though my body knew the scars of battle, my soul remains unbroken as the rivers of Guyana.");
            }
            else if (speech.Contains("guyana"))
            {
                Say("Guyana is a land of rivers, rainforest, and many peoples—each with a story to tell.");
            }
            else if (speech.Contains("berbice"))
            {
                Say("Berbice was where our fight for liberty began. The sugar plantations were soaked in both hope and sorrow.");
            }
            else if (speech.Contains("africa"))
            {
                Say("I was born in Africa, stolen from my homeland, yet the rhythm of the drums beats within me still.");
            }
            else if (speech.Contains("rebellion") || speech.Contains("revolt"))
            {
                Say("The Berbice Rebellion was a cry for justice. We dreamed of a nation where no one would wear chains.");
            }
            else if (speech.Contains("chains"))
            {
                Say("Chains can bind the body, but not the mind or the will. We broke them with courage and unity.");
            }
            else if (speech.Contains("plantation"))
            {
                Say("The plantations of Berbice were fields of pain and endurance. But from that earth, hope grew strong.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the seed that grows in every heart. Even in darkness, it finds a way to rise.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is priceless. For it, we faced guns and fire with bare hands and boundless hearts.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("The rivers of Guyana—Demerara, Berbice, Essequibo—carried both tears and dreams toward the sea.");
            }
            else if (speech.Contains("rainforest") || speech.Contains("jungle"))
            {
                Say("The rainforest was both shield and sanctuary, hiding us from the eyes of our oppressors.");
            }
            else if (speech.Contains("oppressors") || speech.Contains("dutch") || speech.Contains("colonial"))
            {
                Say("The Dutch built their fortunes on our backs. But every empire built on injustice must one day fall.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("The spirit of my people is a flame that endures every storm.");
            }
            else if (speech.Contains("flame"))
            {
                Say("A single flame can ignite a thousand torches. Our rebellion lit the path to the future.");
            }
			else if (speech.Contains("maroon"))
			{
				Say("The Maroons—escaped slaves—carved new lives in the wild. Their courage made them legends in the jungle.");
			}
			else if (speech.Contains("legend") || speech.Contains("legends"))
			{
				Say("Every river, every forest, holds its legends. Some tell of lost cities; others of spirits that watch over us.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits of ancestors walk with us. They live in the rain, the wind, the distant thunder.");
			}
			else if (speech.Contains("ancestors"))
			{
				Say("We honor the ancestors—those who endured the crossing and those who dreamed of freedom.");
			}
			else if (speech.Contains("crossing"))
			{
				Say("The crossing from Africa to these shores was a sea of sorrow. Yet we survived, and from that pain grew hope.");
			}
			else if (speech.Contains("pain"))
			{
				Say("Pain can make the heart bitter, or it can forge steel within the soul. We chose the path of strength.");
			}
			else if (speech.Contains("strength"))
			{
				Say("Strength is more than muscle or blade. It is standing for what is right, even when you stand alone.");
			}
			else if (speech.Contains("rain"))
			{
				Say("The rain falls without favor. It feeds the cane and washes the blood from the fields.");
			}
			else if (speech.Contains("cane") || speech.Contains("sugar"))
			{
				Say("Sugar built empires, but at great cost. For every sweetness, remember the labor that made it so.");
			}
			else if (speech.Contains("food") || speech.Contains("cassava") || speech.Contains("pepperpot"))
			{
				Say("Cassava, pepperpot, and rice—these foods remind us of home and the blend of cultures that shape Guyana.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is not always where you were born, but where your people rise together.");
			}
			else if (speech.Contains("rise") || speech.Contains("rising"))
			{
				Say("We rose together, as one, like the sun after a long night.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night brings fear, but also stars. In the darkest hours, we found new hope.");
			}
			else if (speech.Contains("stars"))
			{
				Say("The stars watched over our camps. Sometimes, we sang songs to remember those far away.");
			}
			else if (speech.Contains("songs") || speech.Contains("song"))
			{
				Say("Our songs tell stories—of sorrow, joy, and longing for a day without chains.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Each story is a torch in the darkness. Tell yours, and the world may change.");
			}
			else if (speech.Contains("change"))
			{
				Say("Change comes slowly, like the tide. But with patience and unity, even rivers shape mountains.");
			}
			else if (speech.Contains("tide"))
			{
				Say("The tide brings new ships, new peoples, new hope—and sometimes, new chains.");
			}
			else if (speech.Contains("peoples") || speech.Contains("culture"))
			{
				Say("Many peoples built Guyana: African, Amerindian, East Indian, Chinese, Portuguese. Together, we make something new.");
			}
			else if (speech.Contains("amerindian"))
			{
				Say("The Amerindians walked these lands long before ships crossed the sea. Their wisdom still guides us.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is earned with pain and time. Listen more than you speak, and you may learn the river’s secrets.");
			}
			else if (speech.Contains("river’s secret") || speech.Contains("river secret"))
			{
				Say("Not all secrets are spoken. Sometimes, you must walk the banks and let the water teach you.");
			}
			else if (speech.Contains("teach") || speech.Contains("teaching"))
			{
				Say("Each generation teaches the next, so that our struggles are not forgotten.");
			}
			else if (speech.Contains("forgotten") || speech.Contains("memory"))
			{
				Say("Memory is a treasure greater than gold. Keep it alive, and you keep the people alive.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold shines bright, but unity and justice shine brighter still.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the fruit of unity. Alone, we are voices in the wind. Together, we are thunder.");
			}			
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who fight for it, who dare to dream beyond the horizon.");
            }
            else if (speech.Contains("unity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True unity takes patience. Return when the rivers run anew.");
                }
                else
                {
                    Say("Unity is our greatest treasure. Accept this Treasure Chest of Guyana—may its spirit guide you.");
                    from.AddToBackpack(new TreasureChestOfGuyana());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("kofi") || speech.Contains("coffy"))
            {
                Say("Some know me as Kofi. Names change, but the fire for justice endures.");
            }
            else if (speech.Contains("leader") || speech.Contains("chief"))
            {
                Say("Leadership is not given, but earned in the eyes of those you serve.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are the wings of freedom. Even in chains, we dreamed of a dawn without masters.");
            }
            else if (speech.Contains("family"))
            {
                Say("Family is the anchor of the spirit. I fought not for myself, but for all our children yet to come.");
            }
            else if (speech.Contains("drums"))
            {
                Say("The drums spoke when words were forbidden, carrying messages through the night.");
            }
            else if (speech.Contains("message") || speech.Contains("messages"))
            {
                Say("Messages hidden in songs and drums united the people for our cause.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is not the absence of fear, but the will to act despite it.");
            }
            else if (speech.Contains("liberty"))
            {
                Say("Liberty is won not by the sword alone, but by the joining of many hearts.");
            }
            else if (speech.Contains("hearts"))
            {
                Say("Hearts joined in purpose can break even the strongest chains.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Our true treasure was freedom itself. The rest is only a reflection of our spirit.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the rivers carry you to a brighter day, friend.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Berbice, rebellion, chains, or unity—our stories are written in the rivers.");
                }
            }

            base.OnSpeech(e);
        }

        public Cuffy(Serial serial) : base(serial) { }

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
