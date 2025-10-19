using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Gualbina")]
    public class QueenGualbina : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenGualbina() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Gualbina";
            Body = 0x191; // Human female body

            // Unique Appearance
            AddItem(new FancyDress() { Name = "Regal Dress of the Sao Dynasty", Hue = 1257 });
            AddItem(new Cloak() { Name = "Lion’s Mantle of Gualbina", Hue = 2213 });
            AddItem(new BodySash() { Name = "Azure Sash of the Great Lake", Hue = 1378 });
            AddItem(new Sandals() { Name = "Queen’s Sandals of River Clay", Hue = 2105 });
            AddItem(new FeatheredHat() { Name = "Crown of the Sunbird", Hue = 2008 });
            AddItem(new Scepter() { Name = "Scepter of the Sunlit Savannah", Hue = 1173 });

            // Stats
            Str = 80;
            Dex = 60;
            Int = 100;
            Hits = 80;

            SpeechHue = 2124;
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
                Say("I am Gualbina, Lion Queen of the Sao and ruler of the emerald shores of Lake Chad.");
            }
            else if (speech.Contains("job"))
            {
                Say("I guide my people through wisdom, tradition, and the strength of lions.");
            }
            else if (speech.Contains("health"))
            {
                Say("I stand tall as the baobab tree—rooted in the past, ever reaching for the sun.");
            }
            else if (speech.Contains("sao"))
            {
                Say("The Sao were ancient builders—masters of earth and river, keepers of secrets beneath the lake.");
            }
            else if (speech.Contains("lake"))
            {
                Say("Lake Chad—cradle of life, mirror of the sky. Its waters hold both history and prophecy.");
            }
            else if (speech.Contains("lion"))
            {
                Say("Lions are sacred in our land. To rule with courage is to walk with lions by your side.");
            }
            else if (speech.Contains("sunbird"))
            {
                Say("The sunbird is a symbol of hope and rebirth—its song greets the dawn of every Sao king and queen.");
            }
            else if (speech.Contains("queen"))
            {
                Say("To be queen is to be servant of the land. My people’s joy is my own reward.");
            }
            else if (speech.Contains("history"))
            {
                Say("History is written in the clay of our pots and the bones of our ancestors.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors whisper in the wind and guide our dreams beneath the stars.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom in rivers, in firelight, and in the counsel of those who have lived long.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is a shield—guarding our spirit through storm and drought.");
            }
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("The rivers feed our land, twisting like silver threads through the grasslands. Life and fortune follow where water flows.");
			}
			else if (speech.Contains("desert"))
			{
				Say("To the north, the desert’s breath is harsh, but we find beauty even in the silence of the sands.");
			}
			else if (speech.Contains("pottery"))
			{
				Say("Our pottery endures through centuries—each vessel tells the story of hands that shaped it and fires that tempered it.");
			}
			else if (speech.Contains("baobab"))
			{
				Say("The baobab tree is the soul of the savannah—its roots run as deep as the oldest memories.");
			}
			else if (speech.Contains("king"))
			{
				Say("Our kings once rode with lion pelts across their shoulders and wisdom in their hearts. Even queens must learn their lessons.");
			}
			else if (speech.Contains("fish") || speech.Contains("fishing"))
			{
				Say("Fisherfolk cast their nets at dawn, singing to the waters in hopes of a good catch. Lake Chad gives, but she must also rest.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The drums call us together for dance, for mourning, for celebration. Their thunder is the heartbeat of the Sao.");
			}
			else if (speech.Contains("dance"))
			{
				Say("Our dances celebrate the rain, the harvest, and the courage of hunters. Will you dance beneath the stars one night?");
			}
			else if (speech.Contains("courage"))
			{
				Say("True courage is not the absence of fear, but the choice to stand firm when the lion roars.");
			}
			else if (speech.Contains("storm"))
			{
				Say("The storms that sweep across the lake bring renewal and sometimes ruin. We honor both, for each is a lesson.");
			}
			else if (speech.Contains("mask") || speech.Contains("masks"))
			{
				Say("During festivals, we wear masks of wood and bone, taking on the spirits of ancestors and animals.");
			}
			else if (speech.Contains("festival"))
			{
				Say("At festival time, the air fills with laughter and flame-light. Even the old ones remember their youth when the drums sound.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("The oracle sits by the water’s edge, reading the ripples. Her words guide chieftains and wandering souls alike.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Caravans bring salt and copper from distant lands. In return, they carry the tales and crafts of the Sao far and wide.");
			}
			else if (speech.Contains("salt"))
			{
				Say("Salt is precious here, as valuable as gold. We trade it for cloth, beads, and sometimes even peace.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the greatest gift a ruler can offer her people. May your path be free from war.");
			}
			else if (speech.Contains("war"))
			{
				Say("We do not seek war, but we defend our land fiercely. The spirits of the Sao watch over their own.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits of land and water must be honored—ignore them, and even the bravest may lose their way.");
			}
			else if (speech.Contains("night"))
			{
				Say("At night, the lake glows with starlight. Many say dreams are strongest when the moon is high.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams are bridges to other worlds. Listen closely to what your heart reveals when you sleep by the water.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Stars guide travelers and tell the stories of those who came before us. Every Sao child learns the constellations.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Our children chase fireflies and build kingdoms from mud. One day, they will lead, as I do now.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire gives warmth, protection, and life to the night. But remember: it must be tended, or it will wander wild.");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("Not all treasure is gold—sometimes it is found in the stories we pass on.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Would you hear the story of the Sao, the lion, or the sunbird?");
            }
            else if (speech.Contains("legacy")) // This is the reward trigger!
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A legacy must be cherished, not squandered. Return when time has ripened your path.");
                }
                else
                {
                    Say("You have honored the legacy of the Sao. Accept this Treasure Chest of Chad—may it carry the spirit of our people.");
                    from.AddToBackpack(new TreasureChestOfChad());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with the blessing of the lake, traveler. May you carry our story forward.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Sao, lions, or the legacy that lives on.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenGualbina(Serial serial) : base(serial) { }

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
