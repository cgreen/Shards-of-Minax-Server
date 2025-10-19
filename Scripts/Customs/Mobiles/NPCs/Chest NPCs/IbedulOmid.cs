using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ibedul Omid")]
    public class IbedulOmid : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public IbedulOmid() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ibedul Omid";
            Body = 0x190; // Human male

            // Unique Palauan Outfit
            AddItem(new FlowerGarland() { Name = "Garland of Rock Islands", Hue = 1165 });
            AddItem(new ElvenShirt() { Name = "Seashell-Woven Tunic", Hue = 2213 });
            AddItem(new FancyKilt() { Name = "Bai Council Skirt", Hue = 2955 });
            AddItem(new Cloak() { Name = "Mat of Legends", Hue = 2120 });
            AddItem(new Sandals() { Name = "Coral Path Sandals", Hue = 2507 });
            AddItem(new BodySash() { Name = "Chief’s Sash of Yap Stones", Hue = 1372 });

            // Weapon
            AddItem(new Scepter() { Name = "Scepter of Ebiil Channel", Hue = 2949 });

            SpeechHue = 2119;
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
                Say("I am Ibedul Omid, voice of the elders and guardian of Palau’s ancient stories.");
            }
            else if (speech.Contains("job"))
            {
                Say("I guide our people, keep peace among clans, and remember the tales hidden in the waves and stones.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body is old, yet my spirit is strong as the mangrove roots that bind our shores.");
            }
            else if (speech.Contains("palau"))
            {
                Say("Our islands rise from the blue, shaped by gods and ancestors. Each reef, each bai, remembers their footsteps.");
            }
            else if (speech.Contains("chief") || speech.Contains("ibedul"))
            {
                Say("The title of Ibedul is not merely given—it is earned through wisdom and sacrifice for all clans.");
            }
            else if (speech.Contains("bai"))
            {
                Say("A bai is our council house, carved with the stories of our people. Its beams echo with laughter and decisions that shape our fate.");
            }
            else if (speech.Contains("rock islands") || speech.Contains("islands"))
            {
                Say("The Rock Islands guard our secrets. Their caves once hid the treasures of chiefs and the memories of war.");
            }
            else if (speech.Contains("war"))
            {
                Say("Palau has seen the sails of strangers and the shadows of conflict, yet we survive—our spirit, like the turtle, endures.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every shell, every current, carries a story. Will you listen, or will you only search for what can be carried away?");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends speak of the great eel who shaped Ngerekebesang, and of stones that walk at night.");
            }
            else if (speech.Contains("stones"))
            {
                Say("Our stones are not mere rocks. Some, like the Yap stones, traveled great distances as gifts of respect.");
            }
            else if (speech.Contains("respect"))
            {
                Say("Respect binds us to each other and to the land. Even the smallest crab is honored in Palau.");
            }
            else if (speech.Contains("eel"))
            {
                Say("Ah, the eel! In old times, he was a boy who turned into the island’s shape. Listen for his name among the mangroves.");
            }
            else if (speech.Contains("mangrove") || speech.Contains("mangroves"))
            {
                Say("The mangroves are the nurseries of life, hiding secrets beneath their roots. Crabs, eels, and children all find refuge here.");
            }
            else if (speech.Contains("sea") || speech.Contains("ocean"))
            {
                Say("The sea is our mother and our test. Her moods are swift, her bounty, endless for those who respect her.");
            }
			else if (speech.Contains("canoe") || speech.Contains("canoes"))
			{
				Say("Our ancestors crossed wide seas in outrigger canoes, guided by stars, wind, and the memory of home. The journey shapes the voyager.");
			}
			else if (speech.Contains("stars") || speech.Contains("star"))
			{
				Say("The stars are maps written on the sky. The old navigators could find their way to any island by their dance.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire is the heart of every bai. Around it, we share food and words—both are needed for a strong village.");
			}
			else if (speech.Contains("village") || speech.Contains("villages"))
			{
				Say("Each village has its own song and customs. Respect them, for every place is home to someone’s spirit.");
			}
			else if (speech.Contains("customs"))
			{
				Say("Customs are like roots—hidden, but holding the people firm when storms arrive.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("To give a gift is to give a part of yourself. Even the smallest shell can carry great meaning.");
			}
			else if (speech.Contains("rain") || speech.Contains("storm"))
			{
				Say("Rain feeds the taro fields and fills the wells. Storms test our walls and our hearts, but both become stronger with each passing season.");
			}
			else if (speech.Contains("taro"))
			{
				Say("Taro is our staple, as important as breath. Each harvest is a promise to the next generation.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We walk where our ancestors once walked. Listen to the wind—sometimes, it carries their voices.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind brings stories from distant islands. Some come as warnings, some as blessings.");
			}
			else if (speech.Contains("fishing") || speech.Contains("fish"))
			{
				Say("Fishing is both art and survival. The cleverest fishers watch the moon, the tide, and the shadows beneath the water.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon shapes the tides and guides our fishing. Her changing face reminds us that nothing lasts forever.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the hope of our people. In their laughter, I hear the future whispering.");
			}
			else if (speech.Contains("whisper") || speech.Contains("whispers"))
			{
				Say("Whispers carry secrets and warnings. Not every secret is meant for every ear.");
			}
			else if (speech.Contains("yap"))
			{
				Say("The Yap stones traveled many miles to reach our shores. They are a symbol of trust between distant friends.");
			}
			else if (speech.Contains("trust"))
			{
				Say("Trust is built like a canoe—slowly, with care. One careless cut, and all may be lost.");
			}
			else if (speech.Contains("feast"))
			{
				Say("A feast is more than food. It is song, dance, and the joy of sharing what the land and sea provide.");
			}
			else if (speech.Contains("dance") || speech.Contains("song"))
			{
				Say("Dance and song carry history better than stone. Through them, the past walks beside us.");
			}
			else if (speech.Contains("past"))
			{
				Say("The past is never gone; it lives in the shadows of the bai, in the old paths beneath our feet.");
			}
			else if (speech.Contains("future"))
			{
				Say("We plant seeds today for shade we will never sit beneath. That is the duty of the wise.");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("The greatest treasures are not gold or pearls, but the knowledge that endures through storms.");
            }
            else if (speech.Contains("clan") || speech.Contains("clans"))
            {
                Say("Each clan has its totem, its color, its story. United, we are stronger than any typhoon.");
            }
            else if (speech.Contains("totem"))
            {
                Say("Totems bind us to ancestors. Mine is the turtle—old, wise, patient. Seek your own.");
            }
            else if (speech.Contains("turtle"))
            {
                Say("The turtle remembers every tide and returns always home. A lesson for wanderers and chiefs alike.");
            }
            else if (speech.Contains("home"))
            {
                Say("Home is where your name is remembered, and where stories begin and end.");
            }
            else if (speech.Contains("nursery"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Wisdom must rest between tellings. Return after the tide has turned.");
                }
                else
                {
                    Say("You see with the eyes of a true seeker. Take this Treasure Chest of Palauan History, and may its contents guide your journey.");
                    from.AddToBackpack(new TreasureChestOfPalauanHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the tides guide your way, and may your name be remembered.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of bai, mangroves, turtles, or the stones that journeyed from Yap.");
                }
            }

            base.OnSpeech(e);
        }

        public IbedulOmid(Serial serial) : base(serial) { }

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
