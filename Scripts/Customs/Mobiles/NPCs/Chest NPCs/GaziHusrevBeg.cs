using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Gazi Husrev-beg")]
    public class GaziHusrevBeg : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public GaziHusrevBeg() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Gazi Husrev-beg";
            Body = 0x190; // Human male body

            // Unique Bosnian Ottoman Appearance
            AddItem(new FancyShirt() { Name = "Kaftan of Sarajevo", Hue = 1282 });
            AddItem(new FancyKilt() { Name = "Beg's Sash of Ilidža", Hue = 2052 });
            AddItem(new Cloak() { Name = "Mantle of the Golden Lily", Hue = 1417 });
            AddItem(new Cap() { Name = "Crimson Fez of Gazi Husrev-beg", Hue = 1157 });
            AddItem(new Sandals() { Name = "Sandals of the River Miljacka", Hue = 1865 });
            AddItem(new BodySash() { Name = "Emerald Sash of the Waqf", Hue = 1423 });

            // Weapon
            AddItem(new Scimitar() { Name = "Sword of the Bosnian Beg", Hue = 1175 });

            // Speech Hue
            SpeechHue = 2123;

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
                Say("I am Gazi Husrev-beg, once governor of Bosnia and founder of Sarajevo's greatest waqf.");
            }
            else if (speech.Contains("job"))
            {
                Say("My life's work was to serve the people of Bosnia, to build, to defend, and to inspire unity.");
            }
            else if (speech.Contains("health"))
            {
                Say("By the grace of Allah, my spirit endures as long as Sarajevo's stones stand.");
            }
            else if (speech.Contains("sarajevo"))
            {
                Say("Sarajevo, the city of bridges, mosques, and markets—my beloved legacy upon the Miljacka River.");
            }
            else if (speech.Contains("bosnia"))
            {
                Say("Bosnia is a land of mountains, rivers, and many peoples—its heart beats with resilience.");
            }
            else if (speech.Contains("waqf") || speech.Contains("foundation"))
            {
                Say("Through my waqf, I built mosques, schools, water fountains, and libraries for generations to come.");
            }
            else if (speech.Contains("mosque"))
            {
                Say("The Gazi Husrev-beg Mosque still welcomes the faithful. Its dome touches the sky above Sarajevo.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A true legacy is not in riches, but in knowledge shared and peace fostered among people.");
            }
            else if (speech.Contains("bridge"))
            {
                Say("Bridges unite what rivers divide. In Bosnia, our bridges have seen both war and peace.");
            }
            else if (speech.Contains("education") || speech.Contains("school"))
            {
                Say("I founded the first library and school in Sarajevo, for knowledge is the light of the soul.");
            }
            else if (speech.Contains("river") || speech.Contains("miljacka"))
            {
                Say("The Miljacka River flows through Sarajevo—a witness to centuries of hope and sorrow.");
            }
            else if (speech.Contains("ottoman"))
            {
                Say("Under Ottoman rule, Bosnia prospered. My title, 'Beg', signified both honor and responsibility.");
            }
            else if (speech.Contains("honor"))
            {
                Say("Honor is found in serving the people and defending the weak, not in titles or gold.");
            }
            else if (speech.Contains("golden lily"))
            {
                Say("The Golden Lily is a symbol of Bosnia's beauty, courage, and hope.");
            }
            else if (speech.Contains("market"))
            {
                Say("Sarajevo's bazaar bustles with merchants, travelers, and stories from every land.");
            }
            else if (speech.Contains("fountain"))
            {
                Say("Clean water is a blessing. The fountains I built offer relief to traveler and citizen alike.");
            }
            else if (speech.Contains("sword") || speech.Contains("battle"))
            {
                Say("My sword served only to defend the innocent. The greatest victory is lasting peace.");
            }
			else if (speech.Contains("family"))
			{
				Say("Though my ancestors came from distant lands, my heart and legacy belong to Bosnia.");
			}
			else if (speech.Contains("library"))
			{
				Say("Within Sarajevo’s waqf, I founded a great library, a sanctuary for learning and scholars of every faith.");
			}
			else if (speech.Contains("scholar") || speech.Contains("scholars"))
			{
				Say("Scholars from many lands visited my court, sharing wisdom in Persian, Turkish, Arabic, and Slavic tongues.");
			}
			else if (speech.Contains("faith"))
			{
				Say("Faith is the light that guides both ruler and subject through trials and triumphs.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Our markets welcomed merchants from Venice, Istanbul, and beyond. Commerce brings prosperity and understanding.");
			}
			else if (speech.Contains("food"))
			{
				Say("Bosnian bread and coffee warm the soul. Even in the grandest halls, simple meals unite us.");
			}
			else if (speech.Contains("coffee"))
			{
				Say("Coffee arrived in Sarajevo in my day. Its aroma fills the bazaar, inviting all to rest and converse.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Every era has its enemies. My true victory was turning rivals into friends through wisdom and patience.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A friend’s counsel is more valuable than gold. The people of Sarajevo became my greatest allies.");
			}
			else if (speech.Contains("architecture") || speech.Contains("buildings"))
			{
				Say("From stone bridges to domed mosques, our architecture is a testament to both faith and skill.");
			}
			else if (speech.Contains("music"))
			{
				Say("Bosnian sevdah songs echo through Sarajevo’s lanes, carrying joy and sorrow alike.");
			}
			else if (speech.Contains("memory") || speech.Contains("memories"))
			{
				Say("Memories linger in the cobbled streets and gardens, where each stone tells a story.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the foundation of a lasting realm. I strove to be fair to all—no matter their faith or fortune.");
			}
			else if (speech.Contains("poetry") || speech.Contains("poet"))
			{
				Say("Poetry weaves together the tales of our land. In verse, even grief finds a gentle voice.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("The mountains watch over Bosnia. In their shadow, our people have endured both hardship and triumph.");
			}
			else if (speech.Contains("travel") || speech.Contains("traveler"))
			{
				Say("Many travelers passed through Sarajevo, leaving stories and wisdom behind. Where have your journeys taken you?");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who learn from the past and build with hope.");
			}
			else if (speech.Contains("unity"))
			{
				Say("Unity is strength. Bosnia’s greatest hope is the harmony of its many peoples.");
			}			
            else if (speech.Contains("peace"))
            {
                Say("Peace is the greatest foundation a leader can lay for his people.");
            }
            else if (speech.Contains("foundation"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Such treasures must be earned with patience. Return when your heart is steady once more.");
                }
                else
                {
                    Say("Because you seek knowledge and honor my foundation, accept this Treasure Chest of Bosnia—may it remind you that what you build lives on after you.");
                    from.AddToBackpack(new TreasureChestOfBosnia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with peace, and may the bridges you cross lead to wisdom and understanding.");
            }
            else
            {
                // Encourage discovery
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Sarajevo, my waqf, or the rivers of Bosnia.");
                }
            }

            base.OnSpeech(e);
        }

        public GaziHusrevBeg(Serial serial) : base(serial) { }

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
