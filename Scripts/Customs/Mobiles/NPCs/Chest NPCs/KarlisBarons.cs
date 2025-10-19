using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kārlis Barons")]
    public class KarlisBarons : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KarlisBarons() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kārlis Barons";
            Body = 0x190; // Human male body

            // Outfit: unique named and hued clothing
            AddItem(new FancyShirt() { Name = "Embroidered Dainas Shirt", Hue = 2654 });
            AddItem(new LongPants() { Name = "Scholar’s Woolen Trousers", Hue = 1152 });
            AddItem(new Cloak() { Name = "Cloak of Forest Shadows", Hue = 2981 });
            AddItem(new WideBrimHat() { Name = "Folk Singer’s Straw Hat", Hue = 2265 });
            AddItem(new Boots() { Name = "Traveler’s Pine Boots", Hue = 1801 });
            AddItem(new BodySash() { Name = "Sash of the Sun’s Song", Hue = 1171 });
            AddItem(new Scepter() { Name = "Dainu Staff of Barons", Hue = 1173 });

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
                Say("I am Kārlis Barons, known as the father of dainas, the folk songs of Latvia.");
            else if (speech.Contains("job"))
                Say("My life’s work was to gather the ancient songs of our people, preserving their wisdom for the future.");
            else if (speech.Contains("health"))
                Say("Old bones, but a lively spirit! A song a day keeps sorrow away, don’t you think?");
            else if (speech.Contains("latvia"))
                Say("Latvia is a land woven with forests, songs, and memories as old as the sun.");
            else if (speech.Contains("folk") || speech.Contains("folklore"))
                Say("Folklore is the soul of a nation. Within every tale, a piece of us lives on.");
            else if (speech.Contains("song") || speech.Contains("songs"))
                Say("We Latvians have sung our stories for centuries. Ask me about dainas, and you’ll unlock a secret.");
            else if (speech.Contains("memory"))
                Say("Memory is our most precious legacy. The dainas remember even when we forget.");
            else if (speech.Contains("forest"))
                Say("The forests whisper tales older than any city. Many dainas begin under the shelter of a pine tree.");
            else if (speech.Contains("sun"))
                Say("The sun is a favorite in Latvian song, a symbol of hope, life, and renewal.");
            else if (speech.Contains("tradition"))
                Say("Tradition binds us across time. A single verse can light a thousand fires of belonging.");
            else if (speech.Contains("wisdom"))
                Say("Wisdom is passed from lips to ear, from song to heart. Will you add your verse?");
            else if (speech.Contains("riga"))
                Say("Riga’s towers echo with music and memory. Many songs are born there, by the river Daugava.");
            else if (speech.Contains("freedom"))
                Say("Latvians have always sung for freedom. Even when chains rattled, our voices did not break.");
            else if (speech.Contains("bear"))
                Say("The bear is a guardian spirit in our songs, strong and patient. Respect the forest, and he may guide you.");
			else if (speech.Contains("river") || speech.Contains("daugava"))
				Say("The Daugava River is the great mother of Latvia. Her waters carry the stories of our ancestors to the sea.");
			else if (speech.Contains("cabin") || speech.Contains("cabinet"))
				Say("My famous Dainu Cabinet holds not riches, but the very soul of our people—hundreds of thousands of songs.");
			else if (speech.Contains("children") || speech.Contains("child"))
				Say("Latvian children learn their first dainas before they can read. Through song, even the youngest help carry our traditions.");
			else if (speech.Contains("fire"))
				Say("A song sung by the fire binds friends together, and keeps away the cold and the shadows.");
			else if (speech.Contains("weaver") || speech.Contains("weaving"))
				Say("Weaving and song are much alike—each thread or note becomes part of a greater pattern. So is Latvia made.");
			else if (speech.Contains("bread"))
				Say("Bread is sacred in our land. Every harvest, we thank the earth with song and with a careful breaking of bread.");
			else if (speech.Contains("owl"))
				Say("The owl in our dainas is both a wise guide and a silent watcher. Listen for her in the night—she may carry a message.");
			else if (speech.Contains("moon"))
				Say("The moon drifts above our forests, listening to the dreams of poets and the laughter of children.");
			else if (speech.Contains("friend"))
				Say("A true friend is like a well-loved song—always welcome, and always near, even when far away.");
			else if (speech.Contains("harvest"))
				Say("Harvest is a time of gratitude. Our songs thank the fields, the rain, and each pair of hardworking hands.");
			else if (speech.Contains("winter"))
				Say("In the long Latvian winter, we gather close and sing. Even in the snow, our hearts are warm.");
			else if (speech.Contains("oak"))
				Say("The oak is the strongest of trees, and the symbol of endurance in our dainas. Many a hero is compared to the mighty oak.");
			else if (speech.Contains("wolf"))
				Say("Wolves are clever and loyal in our songs. They remind us to respect nature and trust our instincts.");
			else if (speech.Contains("dance") || speech.Contains("dancing"))
				Say("Dancing and singing go hand in hand at every Latvian celebration. Shall we step a circle together?");
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
				Say("Our ancestors’ voices echo in every verse. When we sing, they listen and sometimes join in.");
			else if (speech.Contains("market"))
				Say("The market square was once filled with traders, gossip, and—of course—singing! Commerce and song are old friends.");
			else if (speech.Contains("promise"))
				Say("To make a promise in song is to give your word to the wind and the sun. Such vows are not easily broken.");
			else if (speech.Contains("journey") || speech.Contains("travel"))
				Say("Every journey is a new song, every path a new verse. May yours be filled with friendly faces and gentle stars.");
			else if (speech.Contains("gift"))
				Say("A gift given with song brings twice as much joy. May your hands always find something worth giving.");
			else if (speech.Contains("blessing") || speech.Contains("bless"))
				Say("Our dainas are filled with blessings for birth, marriage, harvest, and parting. May fortune always find you in song.");				
            else if (speech.Contains("midsummer") || speech.Contains("jāņi"))
                Say("Midsummer, or Jāņi, is our brightest festival. Flowers, fire, and song until the sun rises again!");
            else if (speech.Contains("amber"))
                Say("Amber, the tears of the sea, glows in many dainas. Each piece is a drop of Baltic history.");
            else if (speech.Contains("poetry") || speech.Contains("poet"))
                Say("Every Latvian is a poet at heart. The world is woven in rhyme, rhythm, and wonder.");
            else if (speech.Contains("book") || speech.Contains("books"))
                Say("My cabinet of dainas holds over 200,000 songs. Words are treasures, and I am but their keeper.");
            else if (speech.Contains("spirit"))
                Say("The Latvian spirit is like a songbird: small, brave, and full of song even in winter.");
            else if (speech.Contains("language"))
                Say("Our language is ancient, rich in metaphor and music. Listen carefully, and the world will sing to you.");
            else if (speech.Contains("legacy"))
                Say("True legacy is not gold or power, but memory cherished and passed on.");
            else if (speech.Contains("story") || speech.Contains("stories"))
                Say("Would you like to hear a story or sing a song? Ask about dainas, and you’ll learn much.");
            else if (speech.Contains("stars"))
                Say("Stars above Latvia are old friends. Many dainas thank the stars for guiding lost wanderers home.");
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("dainas"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the wisest must wait. The treasures of song are not sung twice in a day.");
                }
                else
                {
                    Say("You honor the dainas, as all true Latvians do. Take this Treasure Chest of Latvian Legacy and carry our stories onward.");
                    from.AddToBackpack(new TreasureChestOfLatvianLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the stars and the songs watch over your path. Farewell, wanderer!");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                    Say("Ask me of dainas, Midsummer, amber, or the old forests of Latvia.");
            }

            base.OnSpeech(e);
        }

        public KarlisBarons(Serial serial) : base(serial) { }

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
