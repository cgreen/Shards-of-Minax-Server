using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Nzinga")]
    public class QueenNzingaOfGuinea : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenNzingaOfGuinea() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Nzinga";
            Body = 0x191; // Human female body

            // Stats
            Str = 85;
            Dex = 70;
            Int = 110;
            Hits = 80;

            // Unique Appearance: West African Queen
            AddItem(new GildedDress() { Name = "Robes of the Mandinka Queen", Hue = 2125 });
            AddItem(new FlowerGarland() { Name = "Crown of the Niger River", Hue = 1153 });
            AddItem(new BodySash() { Name = "Sash of Resilience", Hue = 1161 });
            AddItem(new FurBoots() { Name = "Boots of the Saharan Caravan", Hue = 2410 });
            AddItem(new FancyShirt() { Name = "Ivory Tunic of Wisdom", Hue = 2515 });
            AddItem(new Scepter() { Name = "Scepter of Sankara", Hue = 1326 });

            // Speech Hue
            SpeechHue = 2121;

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
                Say("I am Queen Nzinga, sovereign of Guinea and guardian of its ancient gold.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a queen and protector, sworn to the people and treasures of Guinea.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though storms have battered my kingdom, my spirit and my resolve shine brighter than gold.");
            }
            else if (speech.Contains("guinea"))
            {
                Say("Guinea is a land of gold and stories, from the rivers of the Niger to the echoes of the old kingdoms.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold has shaped destinies here—empires rose and fell for its gleam. Will you ask me of rivers, kings, or journeys?");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("The Niger River is the heart of Guinea. Along its banks, cities blossomed and caravans carried secrets.");
            }
            else if (speech.Contains("niger"))
            {
                Say("Niger is the river of life, connecting lands, people, and fortunes.");
            }
            else if (speech.Contains("journey") || speech.Contains("journeys"))
            {
                Say("Every journey across Guinea tests courage. Only those who brave the desert learn the paths of old.");
            }
            else if (speech.Contains("mandinka"))
            {
                Say("The Mandinka are warriors, griots, and kings. Their stories shape the soul of Guinea.");
            }
            else if (speech.Contains("griot") || speech.Contains("griots"))
            {
                Say("A griot preserves memory in song and story. Our history endures in every melody.");
            }
            else if (speech.Contains("king") || speech.Contains("kings"))
            {
                Say("Many kings have walked these lands, yet it is the wise who are remembered. Mansa Musa’s generosity still echoes through time.");
            }
            else if (speech.Contains("mansa") || speech.Contains("musa"))
            {
                Say("Mansa Musa, richest of kings, once scattered gold like rain from the heavens. Ask me of empires or the journey of caravans.");
            }
            else if (speech.Contains("empire") || speech.Contains("empires"))
            {
                Say("Empires like Mali and Songhai rose along the gold roads, but the true wealth of Guinea is in its people.");
            }
            else if (speech.Contains("songhai"))
            {
                Say("Songhai's wisdom endures in the libraries of Timbuktu and the silence of the desert.");
            }
            else if (speech.Contains("timbuktu"))
            {
                Say("Timbuktu is a city of scholars and secrets, where every grain of sand hides a legend.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert is both barrier and bridge. Its sands remember every caravan that braved its winds.");
            }
            else if (speech.Contains("caravan") || speech.Contains("caravans"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The sands demand patience. No caravan brings its riches twice in a single day.");
                }
                else
                {
                    Say("Your curiosity travels farther than any caravan. Accept this Treasure Chest of Guinea—may it inspire your next journey.");
                    from.AddToBackpack(new TreasureChestOfGuinea());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("resilience"))
            {
                Say("Resilience is forged in hardship and tested by time. Wear it as you would a crown.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is gold that cannot be stolen. Listen well, and it will guide you through every storm.");
            }
            else if (speech.Contains("treasure") || speech.Contains("riches"))
            {
                Say("True treasure is not what you carry, but what you remember and pass on.");
            }
			else if (speech.Contains("legend"))
			{
				Say("There are many legends in Guinea: some tell of spirits in the forests, others of hidden gold beneath the river sands.");
			}
			else if (speech.Contains("forest") || speech.Contains("forests"))
			{
				Say("Our forests are sacred. The baobab tree remembers more than any library, and its shade brings wisdom.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("I speak with respect for my ancestors. They guide my hand and lend strength to every queen and king of our land.");
			}
			else if (speech.Contains("music") || speech.Contains("song"))
			{
				Say("Music is the heartbeat of Guinea. When the djembe drums, every child remembers the stories of old.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums") || speech.Contains("djembe"))
			{
				Say("The djembe drum calls to the soul. It is heard in celebration, in mourning, and in the preparation for journeys.");
			}
			else if (speech.Contains("festival") || speech.Contains("festivals"))
			{
				Say("Our festivals burst with color, laughter, and dance. They remind us that even after hardship, joy returns.");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar"))
			{
				Say("The market is a river of voices and spices. There, news flows faster than the Niger and bargains shape friendships.");
			}
			else if (speech.Contains("spice") || speech.Contains("spices"))
			{
				Say("Spices from Guinea travel far—pepper, kola nut, and ginger are as prized as gold by distant merchants.");
			}
			else if (speech.Contains("trade") || speech.Contains("merchant") || speech.Contains("merchants"))
			{
				Say("Trade is the breath of empires. Salt, gold, ivory—all have passed through Guinea on the backs of caravans.");
			}
			else if (speech.Contains("ivory"))
			{
				Say("Ivory, carved with patience, once graced the palaces of kings. Now, we treasure its memory more than its form.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("The wise listen more than they speak, for silence can hold more than a thousand words.");
			}
			else if (speech.Contains("friendship"))
			{
				Say("In Guinea, a guest is family. True friendship is a treasure greater than all the gold in the world.");
			}
			else if (speech.Contains("queen"))
			{
				Say("A queen serves her people with strength and patience. I lead not with fear, but with the promise of a brighter dawn.");
			}
			else if (speech.Contains("warrior") || speech.Contains("warriors"))
			{
				Say("Our warriors carry more than swords—they carry stories and the hope of their families.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is the candle that no wind can extinguish. It is the flame that guides the lost home.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun rises first on Guinea’s mountains and sets gently over her forests. It is our oldest companion.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is both a blessing and a challenge. It awakens the land, but only patience yields a good harvest.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("During harvest, every hand is needed and every voice is heard in the song of gratitude.");
			}			
            else if (speech.Contains("scholar"))
            {
                Say("Scholars are the silent architects of empires. Their words outlast even stone.");
            }
            else if (speech.Contains("greetings") || speech.Contains("hello"))
            {
                Say("May the sun bless your path, traveler. What wisdom do you seek?");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your journey be guided by stars and stories, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of gold, rivers, or the great kings of Guinea. A wise traveler asks and listens.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenNzingaOfGuinea(Serial serial) : base(serial) { }

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
