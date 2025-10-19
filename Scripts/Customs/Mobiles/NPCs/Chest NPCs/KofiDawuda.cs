using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kofi Dawuda")]
    public class KofiDawuda : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KofiDawuda() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kofi Dawuda";
            Title = "Keeper of Ancient Ghana";
            Body = 0x190; // Human male

            // Stats
            Str = 75;
            Dex = 55;
            Int = 100;
            Hits = 70;

            // Unique Outfit
            AddItem(new Robe() { Name = "Kente Wisdom Robe", Hue = 2413 });
            AddItem(new BodySash() { Name = "Sash of Royal Lineage", Hue = 2125 });
            AddItem(new Sandals() { Name = "Traveler’s Sandals of the Savanna", Hue = 1901 });
            AddItem(new Circlet() { Name = "Golden Circlet of Elders", Hue = 1367 });
            AddItem(new GnarledStaff() { Name = "Adinkra Staff of Ancestors", Hue = 2207 });
            // For visual flavor: could also add necklace if desired

            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x203B, 0x203C); // Male hair styles
            HairHue = Utility.RandomHairHue();

            SpeechHue = 2123; // Warm golden speech hue

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
                Say("I am Kofi Dawuda, Keeper of the ancient wisdom and gold of Ghana.");
            else if (speech.Contains("job"))
                Say("My duty is to guard the stories of our ancestors and the treasures of the Sahel.");
            else if (speech.Contains("health"))
                Say("I am well, thanks to the river’s blessings and the strength of the land.");
            else if (speech.Contains("wisdom"))
                Say("Wisdom flows from the elders. Would you hear a tale of the great river?");
            else if (speech.Contains("gold"))
                Say("Ghana was called the Land of Gold. Our mines once dazzled the world.");
            else if (speech.Contains("ancestors"))
                Say("Our ancestors guide us still. Offer respect, and doors may open.");
            else if (speech.Contains("treasure"))
                Say("Not all treasures are gold. Some are hidden in the heart’s truth.");
            else if (speech.Contains("river"))
                Say("The Niger River gave life to our people and riches to our traders.");
            else if (speech.Contains("mines"))
                Say("Gold was drawn from deep earth, guarded by the spirit of Anansi.");
            else if (speech.Contains("anansi"))
                Say("Anansi is the wise spider, spinner of stories and secrets. Would you hear one?");
            else if (speech.Contains("story"))
                Say("Long ago, a clever trader won the favor of Anansi by trading fairly. Fairness brings fortune.");
            else if (speech.Contains("fortune"))
                Say("Many seek fortune, few find wisdom. Do you seek a reward or a lesson?");
            else if (speech.Contains("reward"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("I have no treasure for you now. Return when the sun is higher.");
                }
                else
                {
                    Say("You have shown respect for history and wisdom. Accept the TreasureChestOfAncientGhana.");
                    from.AddToBackpack(new TreasureChestOfAncientGhana());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("lesson"))
                Say("The lesson is this: Gold shines, but wisdom endures. Seek balance.");
            else if (speech.Contains("respect"))
                Say("Respect for the ancestors is the first step to understanding.");
            else if (speech.Contains("understanding"))
                Say("Understanding connects us to our past and guides our future.");
            else if (speech.Contains("balance"))
                Say("All things in harmony—gold, wisdom, river, and land. Remember this, traveler.");
            else if (speech.Contains("elders"))
                Say("The elders’ words carry the weight of centuries. Listen well, and you will prosper.");
            else if (speech.Contains("traders"))
                Say("Traders journeyed far, bringing goods and stories along the golden roads.");
            else if (speech.Contains("riches"))
                Say("Riches flow where trust and fairness walk hand in hand.");
            else if (speech.Contains("trade"))
                Say("Trade was the heartbeat of Ghana, echoing across desert and river alike.");
            else if (speech.Contains("doors"))
                Say("Every door in life is opened by respect and patience.");
            else if (speech.Contains("earth"))
                Say("From the deep earth comes both gold and the secrets of the ancestors.");
            else if (speech.Contains("secret"))
                Say("Every secret is a lesson waiting to be learned.");
            else if (speech.Contains("fair"))
                Say("Fairness is the foundation of true prosperity.");
            else if (speech.Contains("heart"))
                Say("The heart holds treasures beyond gold.");
			else if (speech.Contains("music"))
				Say("Music carries the soul of Ghana. Drums and flutes tell stories when words fall silent.");
			else if (speech.Contains("drum"))
				Say("The djembe drum echoes through the villages, calling people together for celebration and council.");
			else if (speech.Contains("flute"))
				Say("The flute’s song is gentle, weaving through the air like a cool river breeze.");
			else if (speech.Contains("council"))
				Say("In council, wise voices rise. It is here that leaders are shaped, and peace is forged.");
			else if (speech.Contains("leader"))
				Say("A true leader listens more than they speak. Their strength is found in unity.");
			else if (speech.Contains("unity"))
				Say("Unity is the pillar of our kingdom. When we stand together, nothing can break us.");
			else if (speech.Contains("king"))
				Say("Our kings were chosen for their wisdom, not just their strength. Many sought the golden stool.");
			else if (speech.Contains("stool"))
				Say("The golden stool holds the spirit of the people. It is a symbol of unity and destiny.");
			else if (speech.Contains("destiny"))
				Say("Each person’s destiny is a path woven by the ancestors, but shaped by our own courage.");
			else if (speech.Contains("courage"))
				Say("Courage is not the absence of fear, but the choice to face it. The lion knows this well.");
			else if (speech.Contains("lion"))
				Say("The lion roams the savanna with pride. He reminds us to walk boldly, but wisely.");
			else if (speech.Contains("family"))
				Say("Family is the root of every tree. Without roots, there is no growth.");
			else if (speech.Contains("roots"))
				Say("Roots connect us to our ancestors. Honor them, and you will find your strength.");
			else if (speech.Contains("griot"))
				Say("A griot remembers all—stories, battles, and names. They are living libraries of our people.");
			else if (speech.Contains("proverb"))
				Say("A wise proverb: 'Rain does not fall on one roof alone.' Trouble and fortune touch us all.");
			else if (speech.Contains("rain"))
				Say("Rain brings life to the crops and joy to the children. Even the gold gleams brighter after a storm.");
			else if (speech.Contains("storm"))
				Say("Storms test the strength of the baobab. Stand firm, and the sun will shine again.");
			else if (speech.Contains("baobab"))
				Say("The baobab is the tree of life. Its shade shelters the traveler, its fruit feeds the hungry.");
			else if (speech.Contains("shade"))
				Say("To sit in the shade is to enjoy the gifts of those who came before us.");
			else if (speech.Contains("journey"))
				Say("Every journey begins with a single step. Where is your path leading you, traveler?");				
            else if (speech.Contains("truth"))
                Say("Truth is the purest treasure one can possess.");

            base.OnSpeech(e);
        }

        public KofiDawuda(Serial serial) : base(serial) { }

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
