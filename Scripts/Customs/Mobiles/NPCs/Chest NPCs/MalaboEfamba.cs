using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Malabo Efamba")]
    public class MalaboEfamba : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MalaboEfamba() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Malabo Efamba";
            Body = 0x190; // Human male body

            // Unique outfit
            var hat = new WideBrimHat() { Name = "Crown of Bioko", Hue = 2645 };
            var shirt = new FancyShirt() { Name = "Bubi Elder's Tunic", Hue = 2968 };
            var pants = new ElvenPants() { Name = "Jungle Explorer's Trousers", Hue = 1372 };
            var sandals = new Sandals() { Name = "Pathfinder’s Sandals", Hue = 2301 };
            var sash = new BodySash() { Name = "Storyteller’s Sash", Hue = 1172 };
            var cloak = new Cloak() { Name = "Veil of Forgotten Rains", Hue = 2216 };
            var staff = new GnarledStaff() { Name = "Staff of Ancestral Memory", Hue = 1109 };

            AddItem(hat);
            AddItem(shirt);
            AddItem(pants);
            AddItem(sandals);
            AddItem(sash);
            AddItem(cloak);
            AddItem(staff);

            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x203B, 0x203C); // Various hair styles
            HairHue = Utility.RandomHairHue();
            SpeechHue = 33; // Unique speech color

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
                Say("I am Malabo Efamba, once a leader among the Bubi people of Bioko Island. My name lives on in the capital of this land.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to keep the memories of the Bubi alive, to share stories before they are lost to time and tide.");
            }
            else if (speech.Contains("health"))
            {
                Say("My health, like the roots of the ceiba tree, is strong, but age weathers us all.");
            }
            else if (speech.Contains("bubi"))
            {
                Say("The Bubi are the island’s oldest children. We cherished our forests, our ancestors, and our freedom. Would you hear more of our island?");
            }
            else if (speech.Contains("island"))
            {
                Say("Bioko, the jewel in the sea, has known peace and storm. We knew its rivers before the world’s maps named them. But then came the colonial ships.");
            }
            else if (speech.Contains("colonial"))
            {
                Say("Colonial rule brought hardship and change. Yet, we hid stories within our songs, and wisdom in memory. Will you help remember?");
            }
			else if (speech.Contains("capital"))
			{
				Say("The city now called Malabo was once known as Port Clarence, a place of new beginnings and sorrowful memories. My name lives on in its streets, though few recall its meaning.");
			}
			else if (speech.Contains("ceiba"))
			{
				Say("The ceiba tree is sacred to my people—roots deep, branches high. We gathered under its shade for council and celebration. Do you know the legend of the spirit in the tree?");
			}
			else if (speech.Contains("legend"))
			{
				Say("It is said that the spirit of our ancestors dwells within the ceiba. On quiet nights, you can hear the songs of the past rustling through its leaves. Stories are our true treasures.");
			}
			else if (speech.Contains("songs"))
			{
				Say("Our songs carry memories the tongue may not speak. Each melody teaches, each rhythm reminds. Even now, sometimes I hum an old tune—perhaps you will hear it, if you listen.");
			}
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is the air the Bubi once breathed, as wild and unbound as the island wind. Even in times of hardship, we dreamed of freedom’s return.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Tradition is the chain linking past to present. Our dances, masks, and riddles hold secrets for those who are patient. Some say a riddle’s answer can open more than a chest...");
			}
			else if (speech.Contains("riddle"))
			{
				Say("Would you hear a riddle of the island? Very well: 'I am not alive, but I grow. I have no mouth, but water kills me. What am I?'");
			}
			else if (speech.Contains("fire"))
			{
				Say("Correct! Fire is both friend and foe—our hearth and our warning. You are clever. Remember: wisdom is its own reward.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend listens as much as they speak. In this land, friends are rare and precious. You may always return here, traveler.");
			}
			else if (speech.Contains("mask"))
			{
				Say("Masks are worn at festivals to honor spirits or confuse evil. Each is carved with meaning—a symbol, a memory, a wish. Do you seek a mask’s secret?");
			}
			else if (speech.Contains("secret"))
			{
				Say("Some secrets must be earned, not given. But a curious heart often finds its own answers in time.");
			}
			else if (speech.Contains("spirit"))
			{
				Say("The spirit world is never far on Bioko. Ancestors guide, warn, and bless us. If you listen to the wind, you may hear their voices, gentle and wise.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("May your path be straight, your heart be strong, and your spirit light. Take these words as a blessing, from my people to you.");
			}			
            else if (speech.Contains("memory"))
            {
                Say("Memory is precious, fragile as morning mist. The staff I hold is carved with tales of long ago, each knot a lesson. But true power is in ancestry.");
            }
            else if (speech.Contains("ancestry"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Our ancestors whisper: patience. I have no gift for you right now—return when the sun is higher.");
                }
                else
                {
                    Say("You honor the stories of the Bubi. Take this Lost Chest of Equatorial Guinea—may it inspire your journey as the past inspires ours.");
                    from.AddToBackpack(new LostChestOfEquatorialGuinea());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else
            {
                // Give a gentle hint if someone is lost
                Say("Speak of my name, my job, or ask of the Bubi, and you shall learn.");
            }

            base.OnSpeech(e);
        }

        public MalaboEfamba(Serial serial) : base(serial) { }

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
