using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kurmanjan Datka")]
    public class KurmanjanDatka : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KurmanjanDatka() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kurmanjan Datka";
            Body = 0x191; // Human female body

            // Stats
            Str = 90;
            Dex = 80;
            Int = 120;
            Hits = 70;

            // Unique Appearance: Kyrgyz Queen
            AddItem(new FancyShirt() { Name = "Silk Tunic of Alai", Hue = 1378 });
            AddItem(new LongPants() { Name = "Royal Braid Pants of Osh", Hue = 2410 });
            AddItem(new Cloak() { Name = "Shyrdak Cloak of the Steppes", Hue = 2986 });
            AddItem(new FeatheredHat() { Name = "Golden Kalpak of Datka", Hue = 2209 });
            AddItem(new Sandals() { Name = "Mountain Traveler’s Footwraps", Hue = 2125 });
            AddItem(new BodySash() { Name = "Belt of Wisdom", Hue = 1359 });

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Staff of the Alai Queen", Hue = 1194 });

            // Speech Hue
            SpeechHue = 2212;

            // Initialize reward timer
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
                Say("I am Kurmanjan Datka, the Queen of the South, protector of the Kyrgyz people.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a humble shepherdess, I rose to lead and unite the tribes of Alai, guiding them through dark times.");
            }
            else if (speech.Contains("health"))
            {
                Say("The wind of the steppes keeps me strong, though sorrow sometimes weighs upon me.");
            }
            else if (speech.Contains("datka"))
            {
                Say("To be 'Datka' is to serve the people. The title was given to me for my wisdom and resolve.");
            }
            else if (speech.Contains("alai"))
            {
                Say("The Alai Valley is my home, where the mountains touch the sky and the eagle soars free.");
            }
            else if (speech.Contains("queen") || speech.Contains("south"))
            {
                Say("They called me 'Queen of the South,' but I am first a daughter of Kyrgyzstan.");
            }
            else if (speech.Contains("tribe") || speech.Contains("tribes"))
            {
                Say("Only by uniting the tribes—Kyrgyz, Uzbek, and Tajik—did we survive the storms of history.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Our mountains are ancient guardians, holding secrets and stories of our ancestors.");
            }
            else if (speech.Contains("russia") || speech.Contains("russian"))
            {
                Say("The Russian Empire brought change and hardship, but also demanded strength and wisdom from its rivals.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is listening to the wind, learning from elders, and holding fast to your people’s heart.");
            }
            else if (speech.Contains("family"))
            {
                Say("Family is both joy and grief. I lost much, but the spirit of my children lives in my people.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the soul of the steppe. Never let it slip quietly away.");
            }
            else if (speech.Contains("steppe") || speech.Contains("steppes"))
            {
                Say("The steppe is a place of both hardship and beauty, endless as the sky.");
            }
            else if (speech.Contains("kalpak"))
            {
                Say("The kalpak crowns the heads of the wise. Wear it with honor, for it is a symbol of our heritage.");
            }
            else if (speech.Contains("heritage"))
            {
                Say("Heritage is a gift from the ancestors; it must be guarded as one guards a flame from the wind.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends are born in struggle. Ask me of courage, and I will tell you tales of old.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is not the absence of fear, but the resolve to act for the good of others.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The treasures of Kyrgyzstan reveal themselves only to the patient. Return in time.");
                }
                else
                {
                    Say("For your wisdom and curiosity, accept a Treasure Chest of Ancient Kyrgyzstan—may it inspire your journey.");
                    from.AddToBackpack(new TreasureChestOfAncientKyrgyzstan());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the wind of the Alai guide your path, traveler.");
            }
			else if (speech.Contains("yurt"))
			{
				Say("The yurt is more than a home—it is a circle of family, warmth, and tradition. Its felt walls have sheltered generations.");
			}
			else if (speech.Contains("silk"))
			{
				Say("Silk once traveled the ancient Silk Road through our lands, bringing stories and treasures from east and west.");
			}
			else if (speech.Contains("silk road"))
			{
				Say("The Silk Road wound through Osh and beyond. Caravans brought not only goods, but wisdom from far places.");
			}
			else if (speech.Contains("osh"))
			{
				Say("Osh, the city of my youth, stands at the crossroads of mountains and memory. Its bazaar still hums with life.");
			}
			else if (speech.Contains("bazaar"))
			{
				Say("The bazaar is where the heart of the city beats—traders, storytellers, and travelers mingle under the open sky.");
			}
			else if (speech.Contains("eagle"))
			{
				Say("The eagle is the spirit of the Kyrgyz—free, watchful, and proud. Its shadow flies over the white peaks.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Traditions keep our spirit alive, like the patterns woven into our shyrdaks and the stories told by the fire.");
			}
			else if (speech.Contains("shyrdak"))
			{
				Say("A shyrdak is a felt carpet, bright with color and meaning. Each pattern is a message from mother to daughter.");
			}
			else if (speech.Contains("daughter"))
			{
				Say("Daughters are the pride of our people—strong, wise, and as enduring as the mountains.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("Kyrgyz songs carry our joys and sorrows. Listen for the komuz—its notes echo across the steppe.");
			}
			else if (speech.Contains("komuz"))
			{
				Say("The komuz, carved from apricot wood, tells the tales of ancient warriors and lost loves.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("Our ancestors whisper in the wind and guide us. To forget them is to lose yourself.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor is the greatest treasure a Kyrgyz can hold. Defend it, and you defend your people.");
			}
			else if (speech.Contains("horse") || speech.Contains("horses"))
			{
				Say("A good horse is a friend, a companion, and sometimes, a hero. Our tales are full of their loyalty and speed.");
			}
			else if (speech.Contains("market"))
			{
				Say("Markets are where stories begin—new faces, new goods, and sometimes, new destinies.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is precious and rare, like an eagle’s feather found on a mountain pass.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every traveler carries a story. Share yours, and you honor the old ways.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who remember the past and act with courage today.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is not found in harshness, but in fairness. Even a queen must answer to her people.");
			}			
            else
            {
                // Optional: Encourage discovery
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Alai, courage, kalpak, or the legends of the steppes.");
                }
            }

            base.OnSpeech(e);
        }

        public KurmanjanDatka(Serial serial) : base(serial) { }

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
