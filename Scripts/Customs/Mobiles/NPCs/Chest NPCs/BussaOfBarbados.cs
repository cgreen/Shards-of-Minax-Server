using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the spirit of Bussa")]
    public class BussaOfBarbados : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public BussaOfBarbados() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bussa";
            Body = 0x190; // Human male body

            // Unique Appearance
            AddItem(new FancyShirt() { Name = "Freedom's White Linen Shirt", Hue = 1150 });
            AddItem(new ShortPants() { Name = "Planter’s Indigo Breeches", Hue = 1319 });
            AddItem(new BodySash() { Name = "Crimson Sash of the Uprising", Hue = 1157 });
            AddItem(new Sandals() { Name = "Barefoot of Liberty", Hue = 2412 });
            AddItem(new Cloak() { Name = "Emerald Cloak of Cane Fields", Hue = 1437 });
            AddItem(new Bandana() { Name = "Rebel’s Sun-Cloth Bandana", Hue = 2118 });

            // Weapon
            AddItem(new Cutlass() { Name = "Bussa's Cane-Cutter", Hue = 1160 });

            // Speech Hue
            SpeechHue = 2114;

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
                Say("I am Bussa, once an enslaved man, now a symbol of rebellion and freedom in Barbados.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, my hands cut sugarcane under the burning sun, but my true calling was to fight for freedom.");
            }
            else if (speech.Contains("health"))
            {
                Say("Freedom keeps my spirit strong. Oppression tried to break me, but hope never dies.");
            }
            else if (speech.Contains("barbados"))
            {
                Say("Barbados—land of sugar, sea, and song. Our struggle shaped its soul.");
            }
            else if (speech.Contains("sugar"))
            {
                Say("Sugar was both blessing and curse. It brought wealth, but chained thousands to the fields.");
            }
            else if (speech.Contains("field") || speech.Contains("fields"))
            {
                Say("In the cane fields, whispers of freedom grew louder with each sunrise.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is sweeter than the finest rum. It was won by courage, unity, and sacrifice.");
            }
            else if (speech.Contains("rebellion") || speech.Contains("revolt"))
            {
                Say("The Bussa Rebellion rose like a storm in 1816, echoing the cry for justice.");
            }
            else if (speech.Contains("cane"))
            {
                Say("The cane-cutter was my tool and my weapon—a symbol of both toil and uprising.");
            }
            else if (speech.Contains("slave") || speech.Contains("slavery"))
            {
                Say("Slavery scarred Barbados, but resistance burned in every heart. We broke the chains together.");
            }
            else if (speech.Contains("rum"))
            {
                Say("Barbadian rum is famous, distilled from the sweat of the fields and the fire of our spirit.");
            }
            else if (speech.Contains("song") || speech.Contains("music"))
            {
                Say("Music was our comfort in darkness. The rhythms of Africa echoed through the sugar mills.");
            }
            else if (speech.Contains("africa"))
            {
                Say("Africa is mother to us all. Her memory lived on in stories, drumming, and hope.");
            }
            else if (speech.Contains("colonial") || speech.Contains("british"))
            {
                Say("The British ruled with an iron fist, but could not silence the dream of freedom.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the lantern in the night—without it, even the strongest fall.");
            }
			else if (speech.Contains("ancestors"))
			{
				Say("The voices of our ancestors gave us strength in the darkest nights. Their courage runs in our veins.");
			}
			else if (speech.Contains("chains"))
			{
				Say("Chains can bind the body, but never the spirit. Each link was broken with unity and hope.");
			}
			else if (speech.Contains("liberty"))
			{
				Say("Liberty is a flame that no tyrant can extinguish. Barbados burns bright with it still.");
			}
			else if (speech.Contains("plantation"))
			{
				Say("Life on the plantation was toil and hardship. But even there, songs and laughter could sometimes be heard.");
			}
			else if (speech.Contains("night"))
			{
				Say("At night, we whispered dreams of freedom beneath the stars, trusting that dawn would bring change.");
			}
			else if (speech.Contains("fire"))
			{
				Say("The fire of rebellion is not just anger, but the will to shape a better tomorrow.");
			}
			else if (speech.Contains("river"))
			{
				Say("The rivers of Barbados carried news, hopes, and sometimes the footprints of those who fled.");
			}
			else if (speech.Contains("church"))
			{
				Say("Church bells once called us to prayer—and sometimes, to secret meetings of the brave.");
			}
			else if (speech.Contains("drum") || speech.Contains("drumming"))
			{
				Say("The drum speaks of Africa and of freedom. Its rhythms stirred courage in our hearts.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun saw our labor and our longing. Under its gaze, both crops and courage grew.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("Harvest time brought both relief and exhaustion. We sang as we worked, dreaming of liberty.");
			}
			else if (speech.Contains("statue"))
			{
				Say("My statue stands in Bridgetown—a tribute not to me alone, but to all who fought for freedom.");
			}
			else if (speech.Contains("bridgetown"))
			{
				Say("Bridgetown, the heart of Barbados, has seen centuries of sorrow and celebration.");
			}
			else if (speech.Contains("storm"))
			{
				Say("Storms shape our island, just as hardship shapes our souls. After the rain, the land blooms anew.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every Barbadian has a story—of pain, of hope, of rising up. Listen well, and you may find your own strength.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who remember the past, and strive for justice.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("We dreamed of a day when Barbados’ children would be born free. That day came, and must never be forgotten.");
			}
			else if (speech.Contains("british") && speech.Contains("law"))
			{
				Say("British laws once weighed heavy, but justice will always find its voice among the oppressed.");
			}
			else if (speech.Contains("independence"))
			{
				Say("Barbados claimed its independence in 1966, but the fight for dignity began long before.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the triumph over it.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is a seed. It may take long to grow, but one day, it bears fruit for all.");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory keeps our history alive. To forget the past is to risk losing our way.");
			}			
            else if (speech.Contains("unity") || speech.Contains("together"))
            {
                Say("Only together could we rise. Rebellion needs unity, not just anger.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True treasure comes with patience. Return to me when enough time has passed.");
                }
                else
                {
                    Say("Take this Treasure Chest of Barbados. May it remind you of our island's courage and resilience.");
                    from.AddToBackpack(new TreasureChestOfBarbados());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with courage, and let freedom’s light guide your journey.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of freedom, sugar, rebellion, or the cane fields.");
                }
            }

            base.OnSpeech(e);
        }

        public BussaOfBarbados(Serial serial) : base(serial) { }

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
