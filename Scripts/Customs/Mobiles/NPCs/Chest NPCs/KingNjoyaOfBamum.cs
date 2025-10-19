using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of King Njoya")]
    public class KingNjoyaOfBamum : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KingNjoyaOfBamum() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "King Njoya";
            Title = "Sultan of Bamum";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 60;
            Int = 120;
            Hits = 80;

            // Unique Royal Outfit: Blending Bamum tradition and invention
            AddItem(new FormalShirt() { Name = "Royal Tunic of Foumban", Hue = 1359 });
            AddItem(new FancyKilt() { Name = "Bamum Beaded Kilt", Hue = 2120 });
            AddItem(new Cloak() { Name = "Cloak of the Grassfields", Hue = 2503 });
            AddItem(new WideBrimHat() { Name = "Beaded Bamum Crown", Hue = 2109 });
            AddItem(new Sandals() { Name = "Sultan's Sandals", Hue = 1205 });
            AddItem(new BodySash() { Name = "Sash of Njoya's Legacy", Hue = 1421 });

            // Unique Weapon: Bamum Ceremonial Staff
            AddItem(new BladedStaff() { Name = "Staff of Shümom", Hue = 1173 });

            SpeechHue = 2126;

            // Initialize lastRewardTime to past
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
                Say("I am King Njoya, Sultan of the Bamum, keeper of Foumban and creator of the Shümom script.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a king, a builder of palaces, and an inventor. My heart lies with my people and the wisdom of our ancestors.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though my days are many, my spirit is strong. In wisdom, the soul finds health.");
            }
            else if (speech.Contains("bamum"))
            {
                Say("The Bamum are proud people of Cameroon, known for art, courage, and our city of Foumban.");
            }
            else if (speech.Contains("foumban"))
            {
                Say("Foumban, my royal city, is where tradition meets invention. Its palace walls hold a thousand stories.");
            }
            else if (speech.Contains("palace"))
            {
                Say("My palace is a marvel—built from clay and vision. Within its halls, the spirits of Bamum kings dwell.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition guides the Bamum. Yet, I sought to blend old wisdom with new ideas.");
            }
            else if (speech.Contains("script") || speech.Contains("writing") || speech.Contains("shumom"))
            {
                Say("Shümom is the writing I invented. It records our language and preserves our history for generations.");
            }
            else if (speech.Contains("language"))
            {
                Say("Our Bamum language is now written in Shümom. With it, stories and secrets endure.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every story is a thread in the royal tapestry. Would you like to hear of wisdom, invention, or legacy?");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the greatest treasure. I learned from elders, from travelers, and from listening to dreams.");
            }
            else if (speech.Contains("dream"))
            {
                Say("Many inventions came to me in dreams—like the writing of Shümom and new ways to build.");
            }
            else if (speech.Contains("invention") || speech.Contains("invent"))
            {
                Say("Invention is a seed. My script and new machines made Bamum stronger and wiser.");
            }
            else if (speech.Contains("machine") || speech.Contains("machines"))
            {
                Say("I built grinding mills and water machines to help my people. Ask me of progress or knowledge.");
            }
            else if (speech.Contains("progress"))
            {
                Say("Progress is a river—changing its course, but always moving forward.");
            }
            else if (speech.Contains("knowledge"))
            {
                Say("Knowledge is a garden—tend it, and you will feed generations.");
            }
            else if (speech.Contains("garden"))
            {
                Say("The royal gardens in Foumban bloom with the hope of Bamum. Nature and people grow together.");
            }
			else if (speech.Contains("food") || speech.Contains("feast"))
			{
				Say("Bamum feasts are a celebration of life! We share ndolé, fufu, roasted meats, and honeyed cakes during festivals.");
			}
			else if (speech.Contains("ndole") || speech.Contains("fufu"))
			{
				Say("Ndolé, our bitterleaf stew, gives strength to warriors and comfort to elders. Fufu binds the family at the table.");
			}
			else if (speech.Contains("festival") || speech.Contains("festivals"))
			{
				Say("Our festivals fill the palace with song and dance! Drums echo, and masks bring ancestors to life.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The talking drums speak across the grassfields. They call the people to gather or warn of danger.");
			}
			else if (speech.Contains("mask") || speech.Contains("masks"))
			{
				Say("Masks of bronze and wood guard our rituals. Each mask has its own spirit and story.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the root of Bamum life. My father, King Nsangou, taught me wisdom; my mother, Mfon, gave me courage.");
			}
			else if (speech.Contains("mother") || speech.Contains("mfon"))
			{
				Say("My mother, called Mfon, was honored among the Bamum women. She advised kings and kept the peace in the palace.");
			}
			else if (speech.Contains("father") || speech.Contains("nsangou"))
			{
				Say("King Nsangou, my father, ruled with a firm hand and a wise heart. I learned much from his reign.");
			}
			else if (speech.Contains("queen") || speech.Contains("wives"))
			{
				Say("The queens of Bamum are respected advisors and keepers of tradition. Their voices shape the destiny of our people.");
			}
			else if (speech.Contains("advisor") || speech.Contains("advisors"))
			{
				Say("A wise king surrounds himself with advisors—elders, warriors, and artisans alike.");
			}
			else if (speech.Contains("peace") || speech.Contains("diplomacy"))
			{
				Say("Peace is built with patience and strong words. I welcomed foreign envoys, for every new friend brings new ideas.");
			}
			else if (speech.Contains("envoy") || speech.Contains("envoys") || speech.Contains("visitor"))
			{
				Say("Envoys from distant lands brought gifts—silk, horses, and news of the world beyond Cameroon.");
			}
			else if (speech.Contains("palace secret") || speech.Contains("secret") || speech.Contains("secrets"))
			{
				Say("Every palace has its secrets! Hidden passages wind beneath the floors, and treasures are tucked in plain sight.");
			}
			else if (speech.Contains("passage") || speech.Contains("passages"))
			{
				Say("Some passages were built for safety; others for mystery. A clever explorer may find them still...");
			}
			else if (speech.Contains("treasure"))
			{
				Say("The true treasure of Bamum is not gold, but the wisdom of ancestors and unity of our people.");
			}
			else if (speech.Contains("wisdom saying") || speech.Contains("proverb"))
			{
				Say("Here is a Bamum proverb: 'Rain does not fall on one roof alone.' We share joy and hardship together.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("The ancestors watch over Foumban. We honor them in song, mask, and ritual.");
			}			
            else if (speech.Contains("art"))
            {
                Say("Bamum art is famed for bronze and beadwork. Our artisans make beauty from earth and fire.");
            }
            else if (speech.Contains("bronze") || speech.Contains("bead") || speech.Contains("beads"))
            {
                Say("Bronze masks and beaded crowns tell the story of kings. The crown is the soul of Bamum royalty.");
            }
            else if (speech.Contains("crown"))
            {
                Say("The crown is heavy with duty. It is passed from king to king, holding dreams and responsibilities.");
            }
            else if (speech.Contains("legacy"))
            {
                // This is the REWARD keyword!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A true legacy is not shared too swiftly. Return to me after time has passed, wise one.");
                }
                else
                {
                    Say("You honor the Bamum and the memory of Foumban. Accept this Treasure Chest of Cameroon Legacy—may it inspire you to seek wisdom and invention in your journey.");
                    from.AddToBackpack(new TreasureChestOfCameroonLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("elders"))
            {
                Say("The elders of Bamum hold the stories of centuries. Listen well to their counsel.");
            }
            else if (speech.Contains("king"))
            {
                Say("A king is nothing without his people. My duty is to guide, to protect, and to dream for Bamum.");
            }
            else if (speech.Contains("people"))
            {
                Say("My people are the source of my strength and the reason for my invention.");
            }
            else if (speech.Contains("cameroon"))
            {
                Say("Cameroon is a land of mountains, forests, and a hundred tongues. Bamum is only one jewel in its crown.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The Cameroon mountains watch over us, ancient and wise. Their silence is a lesson.");
            }
            else if (speech.Contains("forest") || speech.Contains("forests"))
            {
                Say("The forests of Cameroon shelter rare beasts and the drums of old Bamum rituals.");
            }
            else if (speech.Contains("ritual"))
            {
                Say("Rituals connect us to ancestors. Through them, we honor the past and ask blessings for the future.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who respect both tradition and change. What will you create?");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the spirit of Bamum and the wisdom of Cameroon light your path, traveler.");
            }
            else
            {
                // Encourage exploration
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Bamum, invention, Foumban, or my legacy.");
                }
            }

            base.OnSpeech(e);
        }

        public KingNjoyaOfBamum(Serial serial) : base(serial) { }

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
