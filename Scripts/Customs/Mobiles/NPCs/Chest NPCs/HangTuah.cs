using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hang Tuah")]
    public class HangTuah : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HangTuah() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hang Tuah";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 85;
            Int = 110;
            Hits = 90;

            // Unique Appearance: Legendary Malay Warrior
            AddItem(new FancyShirt() { Name = "Baju Perwira Melaka", Hue = 1153 });
            AddItem(new FancyKilt() { Name = "Kain Songket Pahlawan", Hue = 2209 });
            AddItem(new Cloak() { Name = "Cloak of Loyalty", Hue = 1177 });
            AddItem(new Circlet() { Name = "Tanjak of Malacca", Hue = 2207 });
            AddItem(new Boots() { Name = "Boots of the Nusantara", Hue = 2006 });
            AddItem(new BodySash() { Name = "Sash of the Sultan", Hue = 2967 });

            // Weapon: Keris
            AddItem(new Kryss() { Name = "Keris Taming Sari", Hue = 1172 });

            // Speech Hue
            SpeechHue = 2120;

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
                Say("I am Hang Tuah, sworn blade and loyal heart of Melaka's golden age.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once I served as Laksamana, admiral of the Melakan fleet, protector of the sultan's realm.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body may be weary, but my spirit endures—like the river that shapes the land.");
            }
            else if (speech.Contains("melaka") || speech.Contains("malacca"))
            {
                Say("Melaka was a jewel of trade, culture, and courage upon the straits. Many sought its riches—few understood its soul.");
            }
            else if (speech.Contains("sultan"))
            {
                Say("The sultans of Melaka ruled with wisdom and strength, though their courts were full of both honor and intrigue.");
            }
            else if (speech.Contains("fleet") || speech.Contains("admiral"))
            {
                Say("As admiral, I led our ships across the Straits of Melaka, guarding merchants and battling pirates.");
            }
            else if (speech.Contains("loyalty"))
            {
                Say("Loyalty is a river—sometimes tested by storms, always flowing toward its purpose.");
            }
            else if (speech.Contains("keris") || speech.Contains("kris") || speech.Contains("weapon"))
            {
                Say("My blade is the Keris Taming Sari—said to be enchanted, it grants victory to the worthy and wisdom to the humble.");
            }
            else if (speech.Contains("taming sari"))
            {
                Say("The Taming Sari is more than steel; it is a symbol of justice and the will of the people.");
            }
            else if (speech.Contains("justice"))
            {
                Say("True justice demands both strength and compassion. Even the sharpest blade must rest in a gentle hand.");
            }
            else if (speech.Contains("friend"))
            {
                Say("I once shared brotherhood with Hang Jebat. Our friendship was tested by the tides of fate and the demands of loyalty.");
            }
            else if (speech.Contains("jebat"))
            {
                Say("Hang Jebat was both my closest brother and bitterest rival—a tale woven with love, loyalty, and sorrow.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is like the bamboo—bending with the wind, never breaking in the storm.");
            }
            else if (speech.Contains("myth") || speech.Contains("legend"))
            {
                Say("Some say I never died, but vanished into the forest. Legends live where truth leaves off.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The forest hides many secrets. Sometimes, the bravest must become the most silent to survive.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("A secret shared with honor is a gift; one spoken in haste is a curse.");
            }
            else if (speech.Contains("honor") || speech.Contains("honour"))
            {
                Say("Honor is the cloth from which a warrior’s soul is cut.");
            }
            else if (speech.Contains("traitor") || speech.Contains("betrayal"))
            {
                Say("To call a friend traitor is the sharpest pain. Loyalty is not always clear in the heart’s storm.");
            }
            else if (speech.Contains("river"))
            {
                Say("The Melaka River carried dreams, merchants, and warriors alike. Each journey shapes its waters.");
            }
            else if (speech.Contains("journey") || speech.Contains("travel"))
            {
                Say("Every journey begins with a single step—and sometimes, a single promise.");
            }
            else if (speech.Contains("promise"))
            {
                Say("A promise is a pearl: small, precious, and easily lost if not guarded.");
            }
            else if (speech.Contains("pearl") || speech.Contains("treasure"))
            {
                Say("True treasure is not always gold—sometimes, it is knowledge, or even a single word.");
            }
            else if (speech.Contains("knowledge"))
            {
                Say("The wisest learn as much from defeat as from victory. Listen to all, even your enemy.");
            }
            else if (speech.Contains("enemy") || speech.Contains("battle"))
            {
                Say("Each battle teaches us. The greatest victory is peace, yet a warrior must be ready for war.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is the reward of those who master themselves.");
            }
            else if (speech.Contains("stranger"))
            {
                Say("To greet a stranger is to open a new chapter. What story do you bring to Melaka?");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Stories endure long after swords are sheathed. Listen well, and your tale may become a legend.");
            }
            else if (speech.Contains("legendary") || speech.Contains("legacy"))
            {
                Say("A true legacy is not left in stone, but in the hearts of those who remember you.");
            }
            else if (speech.Contains("remembrance") || speech.Contains("remember"))
            {
                Say("To be remembered is to live twice—once in life, once in story.");
            }
			else if (speech.Contains("malay") || speech.Contains("people"))
			{
				Say("The Malay people are bound by adat—customs that shape every greeting, every farewell, every feast.");
			}
			else if (speech.Contains("adat"))
			{
				Say("Adat is the thread that weaves community together. Honor it, and you honor the ancestors.");
			}
			else if (speech.Contains("ancestors") || speech.Contains("heritage"))
			{
				Say("Our ancestors watch from the unseen world, blessing those who walk the path of truth.");
			}
			else if (speech.Contains("trade") || speech.Contains("merchants"))
			{
				Say("Merchants from China, India, and Arabia all met in Melaka’s harbor. Each brought wisdom and wonders.");
			}
			else if (speech.Contains("harbor") || speech.Contains("port"))
			{
				Say("The harbor was a marketplace of voices, spices, and dreams. To stand there was to meet the world.");
			}
			else if (speech.Contains("spice") || speech.Contains("spices"))
			{
				Say("Spices were treasures greater than gold. Their scent carried news of distant lands.");
			}
			else if (speech.Contains("china") || speech.Contains("zheng he"))
			{
				Say("Admiral Zheng He brought mighty ships to Melaka. Our friendship with China brought both wealth and new ideas.");
			}
			else if (speech.Contains("treaty"))
			{
				Say("Treaties are like silk: strong if cared for, easily torn by pride.");
			}
			else if (speech.Contains("songket"))
			{
				Say("Songket cloth shimmers with golden thread, each pattern telling a story of our land.");
			}
			else if (speech.Contains("marriage"))
			{
				Say("A marriage is a bridge between families—celebrated with dance, music, and fragrant jasmine.");
			}
			else if (speech.Contains("dance"))
			{
				Say("The silat dance is both art and combat, a language written by the body.");
			}
			else if (speech.Contains("silat"))
			{
				Say("Silat is the dance of warriors—fluid, graceful, deadly. Even in peace, its lessons guide us.");
			}
			else if (speech.Contains("boat") || speech.Contains("ship"))
			{
				Say("To master a boat is to know patience. The wind and tide respect only the wise.");
			}
			else if (speech.Contains("wind"))
			{
				Say("A wise leader listens to the wind before speaking to the crowd.");
			}
			else if (speech.Contains("crowd"))
			{
				Say("A crowd can become a storm—or a shield. The heart of the people is power greater than steel.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold glitters but cannot buy respect. Seek respect, and riches may follow.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Give respect to receive it. Even the lowliest leaf may shade a king.");
			}
			else if (speech.Contains("king"))
			{
				Say("A king rules many, but he is judged by how he rules himself.");
			}
			else if (speech.Contains("fisherman") || speech.Contains("fish"))
			{
				Say("A fisherman rises before the sun and trusts his net. Luck favors the prepared.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun is a promise renewed each morning. What will you do with your day?");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon watches over secret meetings and silent promises.");
			}
			else if (speech.Contains("promise"))
			{
				Say("Some promises are light as feather, others as heavy as the sea.");
			}
			else if (speech.Contains("sea"))
			{
				Say("The sea both gives and takes. Only a fool ignores its moods.");
			}
			else if (speech.Contains("storyteller"))
			{
				Say("A storyteller wields more power than a sword, for stories shape the world.");
			}			
            else if (speech.Contains("song"))
            {
                Say("Songs are rivers of memory, flowing through the ages.");
            }
            else if (speech.Contains("ages"))
            {
                Say("The ages pass, but the lessons remain. What will you learn from me?");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("bamboo"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience is the strength of bamboo—come again when the sun is higher.");
                }
                else
                {
                    Say("You have found the wisdom within the bamboo. Take this Treasure Chest of Malaysian History—may it guide your next journey.");
                    from.AddToBackpack(new TreasureChestOfMalaysianHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("The wind guides the traveler—may your path be honorable and your heart steadfast.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Melaka, loyalty, the keris Taming Sari, or the lessons of bamboo.");
                }
            }

            base.OnSpeech(e);
        }

        public HangTuah(Serial serial) : base(serial) { }

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
