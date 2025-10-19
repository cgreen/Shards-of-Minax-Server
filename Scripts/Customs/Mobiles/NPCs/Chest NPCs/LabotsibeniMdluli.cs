using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Labotsibeni")]
    public class LabotsibeniMdluli : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public LabotsibeniMdluli() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Labotsibeni Mdluli";
            Title = "the Indlovukati of Eswatini";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 70;
            Int = 120;
            Hits = 90;

            // Unique Royal Swazi Appearance
            AddItem(new ElvenShirt() { Name = "Indlovukati’s Silk Tunic", Hue = 2647 });
            AddItem(new FancyKilt() { Name = "Royal Skirt of the Reed Dance", Hue = 2118 });
            AddItem(new FlowerGarland() { Name = "Garland of Sibebe", Hue = 2519 });
            AddItem(new BodySash() { Name = "Sash of Queen Mothers", Hue = 1173 });
            AddItem(new FurBoots() { Name = "Boots of Ezulwini Valley", Hue = 2120 });
            AddItem(new Cloak() { Name = "Cloak of the Lioness Regent", Hue = 2843 });

            // Royal Scepter
            AddItem(new Scepter() { Name = "Staff of Eswatini’s Wisdom", Hue = 2987 });

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
                Say("I am Labotsibeni Mdluli, Indlovukati—Queen Mother—of Eswatini.");
            }
            else if (speech.Contains("job"))
            {
                Say("As Indlovukati, I guard the unity of my people and the heart of our kingdom.");
            }
            else if (speech.Contains("health"))
            {
                Say("Strength flows in the river of tradition, though the world brings storms, I endure.");
            }
            else if (speech.Contains("queen"))
            {
                Say("To be queen is not to rule alone, but to carry the burdens and dreams of all Swazi.");
            }
            else if (speech.Contains("indlovukati"))
            {
                Say("Indlovukati means Queen Mother. I was regent for three kings—my wisdom guided Eswatini through peril.");
            }
            else if (speech.Contains("swazi"))
            {
                Say("The Swazi are children of the shield, shaped by mountains, song, and the struggle to remain free.");
            }
            else if (speech.Contains("royal") || speech.Contains("royalty"))
            {
                Say("Our royal traditions are ancient. The reed dance, the Incwala, and the lion’s courage define us.");
            }
            else if (speech.Contains("reed") || speech.Contains("reed dance"))
            {
                Say("Umhlanga—the reed dance—celebrates purity, unity, and our bond with the land.");
            }
            else if (speech.Contains("lion") || speech.Contains("lioness"))
            {
                Say("A queen must have a lioness’s courage—soft for her children, fierce against her foes.");
            }
            else if (speech.Contains("regent"))
            {
                Say("Regency is the hardest path. I shielded the throne for kings too young to rule alone.");
            }
            else if (speech.Contains("king") || speech.Contains("kings"))
            {
                Say("I was regent for King Bhunu, King Sobhuza II, and guided the throne through shadow and light.");
            }
            else if (speech.Contains("bhunu"))
            {
                Say("King Bhunu was my son. His rule was brief, but he fathered a dynasty.");
            }
			else if (speech.Contains("shield"))
			{
				Say("The shield is our symbol—defender of peace, bearer of tradition. Every Swazi carries one in their heart.");
			}
			else if (speech.Contains("incwala"))
			{
				Say("Incwala is the festival of kingship. It renews the bond between the king, the land, and our people.");
			}
			else if (speech.Contains("sibebe"))
			{
				Say("Sibebe is our sacred mountain—a place of stories and strength.");
			}
			else if (speech.Contains("ezulwini"))
			{
				Say("Ezulwini means 'valley of heaven.' Here the royal kraal stands, and the spirits of our ancestors gather.");
			}
			else if (speech.Contains("mother"))
			{
				Say("A mother shapes not just her children, but the destiny of a nation. My love for my people was my greatest crown.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are our future—each one a promise that Eswatini endures.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a blessing. It waters our fields, renews our hope, and fills our songs with gratitude.");
			}
			else if (speech.Contains("songoma") || speech.Contains("healer"))
			{
				Say("The sangoma is a healer and a guide, keeper of the spirits, trusted by all who seek wisdom and comfort.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits of our ancestors linger in every wind, every tree, every flame. We are never alone.");
			}
			else if (speech.Contains("dance") || speech.Contains("dances"))
			{
				Say("Dance is language. Through movement, we speak to ancestors and to the hearts of all who watch.");
			}
			else if (speech.Contains("royal kraal") || speech.Contains("kraal"))
			{
				Say("The royal kraal is the heart of the nation—where wisdom is shared and decisions shape our future.");
			}
			else if (speech.Contains("war") || speech.Contains("conflict"))
			{
				Say("Conflict tests the soul, but peace is our truest victory. I fought with words as often as with warriors.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the quiet strength that grows when justice and respect guide our steps.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the root of unity. A land without fairness is a house built on sand.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("Rivers wind through our valleys, carrying life, memory, and the laughter of children.");
			}
			else if (speech.Contains("bravery") || speech.Contains("courage"))
			{
				Say("True bravery is not the absence of fear, but the will to act for others despite it.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Respect for elders, for tradition, for the land—this is the first lesson of a Swazi child.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("Legacy is not gold or glory, but lives touched, traditions kept, and a people made stronger.");
			}
			else if (speech.Contains("leadership"))
			{
				Say("A leader listens first. Only with the people's voice can a crown shine bright.");
			}
			else if (speech.Contains("crown"))
			{
				Say("A crown is heavy not from gold, but from the hopes and dreams entrusted to it.");
			}			
						else if (speech.Contains("sobhuza"))
            {
                Say("Sobhuza II was crowned as a child. He would become one of Africa’s longest-reigning kings.");
            }
            else if (speech.Contains("british") || speech.Contains("colonial") || speech.Contains("protectorate"))
            {
                Say("The British called Eswatini a protectorate, but our spirit was never conquered.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is a shield. Divided, we would have vanished. Together, we endured.");
            }
            else if (speech.Contains("resilience"))
            {
                Say("Resilience is a Swazi’s birthright—bend like the reed, but do not break.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("The ancestors watch with silent pride. We owe them our language, our land, and our honor.");
            }
            else if (speech.Contains("honor"))
            {
                Say("Honor is not pride, but duty—to family, to the land, to the future.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is our root and our light—songs sung, dances danced, and laws remembered.");
            }
            else if (speech.Contains("dance"))
            {
                Say("Our dances tell stories. Each step is a heartbeat of the nation.");
            }
            else if (speech.Contains("wisdom"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even wisdom must wait for its moment. Return to me when the sun is higher.");
                }
                else
                {
                    Say("You honor the spirit of Eswatini. Accept this Treasure Chest of Eswatini—a gift for those who seek wisdom.");
                    from.AddToBackpack(new TreasureChestOfEswatini());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("sacrifice"))
            {
                Say("Every crown is bought with sacrifice. Mine was paid in tears, not gold.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Songs bind us to memory—joyful in peace, fierce in struggle.");
            }
            else if (speech.Contains("mountains"))
            {
                Say("The mountains of Eswatini are guardians, standing watch over our fields and villages.");
            }
            else if (speech.Contains("village") || speech.Contains("villages"))
            {
                Say("Each village is a thread in the royal blanket—unique, but stronger together.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who remember the past, and shape it with courage.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with grace and unity. The shield of the ancestors protect you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Swazi tradition, the lioness, or the meaning of resilience.");
                }
            }

            base.OnSpeech(e);
        }

        public LabotsibeniMdluli(Serial serial) : base(serial) { }

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
