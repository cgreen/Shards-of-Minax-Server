using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kgosi Khama III")]
    public class KgosiKhamaIII : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KgosiKhamaIII() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kgosi Khama III";
            Body = 0x190; // Human male body

            // Stats
            Str = 95;
            Dex = 65;
            Int = 100;
            Hits = 80;

            // Unique Appearance: Botswana Royalty
            AddItem(new FancyShirt() { Name = "Silk Shirt of Serowe", Hue = 1287 });
            AddItem(new GuildedKilt() { Name = "Royal Leopard-Skin Kilt", Hue = 2013 });
            AddItem(new Cloak() { Name = "Cape of the Batswana Chiefs", Hue = 1109 });
            AddItem(new BearMask() { Name = "Headdress of the Bamangwato", Hue = 2212 });
            AddItem(new Sandals() { Name = "Sandals of the Kalahari", Hue = 1840 });
            AddItem(new BodySash() { Name = "Unity Sash of Bechuanaland", Hue = 1415 });

            // Weapon: Scepter of Leadership
            AddItem(new Scepter() { Name = "Staff of the Peacemaker", Hue = 2988 });

            // Speech Hue
            SpeechHue = 2105;

            // Initialize the lastRewardTime to a past time
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
                Say("I am Khama the Good, once Kgosi of the Bamangwato, servant of my people and friend of peace.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty was to lead the Batswana, to seek wisdom and justice, and to defend our land.");
            }
            else if (speech.Contains("health"))
            {
                Say("My strength endures through the unity and hope of my people.");
            }
            else if (speech.Contains("bamangwato"))
            {
                Say("The Bamangwato are my people—brave and wise, guardians of the Kalahari's edge.");
            }
            else if (speech.Contains("kalahari"))
            {
                Say("The Kalahari is harsh but beautiful. Only the strong and united thrive beneath its sun.");
            }
            else if (speech.Contains("serowe"))
            {
                Say("Serowe, my birthplace and stronghold, grew from a village to a heart of Batswana unity.");
            }
            else if (speech.Contains("botswana"))
            {
                Say("Botswana is a land of diamonds, wild herds, and strong spirits. Its story is still being written.");
            }
            else if (speech.Contains("british") || speech.Contains("london"))
            {
                Say("I journeyed to London to speak for my people, to protect our lands from those who would divide us.");
            }
            else if (speech.Contains("unity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The legacy of unity is precious—return in due time to seek its blessing again.");
                }
                else
                {
                    Say("For your curiosity and respect, I entrust you with a Treasure Chest of Botswana Legacy. Carry it with the spirit of unity.");
                    from.AddToBackpack(new TreasureChestOfBotswanaLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a true crown for any leader. I sought to end blood feuds and guide my people to harmony.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A leader's true legacy is not in stone or gold, but in the justice and unity left behind.");
            }
            else if (speech.Contains("chief") || speech.Contains("kgosi"))
            {
                Say("A Kgosi leads not with fear, but with wisdom and the trust of the people.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the patient river that shapes the future. Listen well to elders and the lessons of hardship.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith gave me strength to guide my people, even when the world seemed against us.");
            }
			else if (speech.Contains("music"))
			{
				Say("The drum and the song unite us at celebrations. Our voices carry the stories of our ancestors.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We honor our ancestors by living justly. Their wisdom whispers in the wind and roots us in the land.");
			}
			else if (speech.Contains("feast"))
			{
				Say("A feast brings all together—rich and poor, young and old. Unity is tasted as much as spoken.");
			}
			else if (speech.Contains("baobab"))
			{
				Say("The baobab tree is called the tree of life. Its fruit and shade are gifts to the people and animals.");
			}
			else if (speech.Contains("cattle") || speech.Contains("herd"))
			{
				Say("Cattle are wealth to the Batswana, a source of pride and responsibility.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Respect for elders and for all creation guides the hand and heart of the wise.");
			}
			else if (speech.Contains("desmond") || speech.Contains("visitors"))
			{
				Say("We welcome visitors as friends, for a stranger today may be an ally tomorrow.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("The wise seek counsel before war and speak gently in peace.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is a blessing in our land, turning dust to green and hope to song.");
			}
			else if (speech.Contains("okavango"))
			{
				Say("The Okavango Delta is a miracle—a river that becomes a sea in the desert, home to elephants and herons.");
			}
			else if (speech.Contains("lion") || speech.Contains("elephant") || speech.Contains("zebra"))
			{
				Say("The lion is the symbol of courage, the elephant of memory, and the zebra of unity in diversity.");
			}
			else if (speech.Contains("marriage"))
			{
				Say("Marriage binds not only two hearts, but two families and, sometimes, two tribes.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Our children are the sunrise of Botswana. In them, every hope is reborn.");
			}
			else if (speech.Contains("missionary") || speech.Contains("london mission"))
			{
				Say("The London Missionary Society brought the gospel and new ways of learning to our land.");
			}
			else if (speech.Contains("learning") || speech.Contains("school"))
			{
				Say("Education is the path from darkness to understanding. I encouraged every child to seek it.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the shield of the weak and the guide of kings. Without it, unity falters.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Tradition is the wisdom of those who came before—strong, but never unbending.");
			}
			else if (speech.Contains("famine") || speech.Contains("drought"))
			{
				Say("We have known famine and drought. In hardship, we share and endure together.");
			}
			else if (speech.Contains("alcohol") || speech.Contains("beer"))
			{
				Say("I forbade strong drink among my people, for it brought quarrels and sorrow to too many homes.");
			}			
            else if (speech.Contains("family"))
            {
                Say("My father Sekgoma inspired me, and my son Tshekedi carried our hopes into the new century.");
            }
            else if (speech.Contains("diamond") || speech.Contains("diamonds"))
            {
                Say("Diamonds may glitter, but unity and peace are the greatest treasures of Botswana.");
            }
            else if (speech.Contains("colonial") || speech.Contains("colonialism"))
            {
                Say("Colonial threats endangered our land. Only by standing together did we remain free.");
            }
            else if (speech.Contains("tribe") || speech.Contains("tribes"))
            {
                Say("Many tribes dwell in Botswana: Bamangwato, Bakwena, Batawana, and more. Unity is our shield.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert shapes the soul—endurance, patience, and the wisdom to find water where others see only sand.");
            }
            else if (speech.Contains("protectorate"))
            {
                Say("By seeking protectorate status, we kept Botswana from being carved by foreign hands.");
            }
            else if (speech.Contains("blessing"))
            {
                Say("Blessings flow from unity and kindness; let them guide you, traveler.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go in peace, and let unity be your guide.");
            }
            else
            {
                // Encourage more discovery if nothing matches
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Botswana, unity, Serowe, or the legacy of a true chief.");
                }
            }

            base.OnSpeech(e);
        }

        public KgosiKhamaIII(Serial serial) : base(serial) { }

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
