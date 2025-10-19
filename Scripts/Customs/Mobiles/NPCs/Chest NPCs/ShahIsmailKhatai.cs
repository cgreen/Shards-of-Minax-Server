using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Shah Ismail Khatai")]
    public class ShahIsmailKhatai : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ShahIsmailKhatai() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Shah Ismail Khatai";
            Body = 0x190; // Human male

            // Unique Outfit
            AddItem(new FancyShirt() { Name = "Khatai’s Silken Undershirt", Hue = 1354 });
            AddItem(new ElvenPants() { Name = "Poet-King’s Trousers of Tabriz", Hue = 1807 });
            AddItem(new BodySash() { Name = "The Sash of Shirvan", Hue = 2212 });
            AddItem(new Cloak() { Name = "Royal Cloak of the Safavid Court", Hue = 2952 });
            AddItem(new Kasa() { Name = "Red Kizilbash Headdress", Hue = 2076 });
            AddItem(new Sandals() { Name = "Desert-Walker’s Slippers", Hue = 2129 });
            AddItem(new Scimitar() { Name = "Khatai’s Scimitar of Unity", Hue = 1179 });

            SpeechHue = 2632; // Azure blue for poetry

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
                Say("I am Khatai, once called Shah Ismail, poet and founder of the Safavid dynasty of Azerbaijan.");
            }
            else if (speech.Contains("job"))
            {
                Say("A king, yes, but also a humble poet. Through word and sword I united my people.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit is as the mountain winds—restless, but enduring through centuries.");
            }
            else if (speech.Contains("khatai"))
            {
                Say("‘Khatai’ is my pen name, under which my verses travel the world. Poetry endures where swords fail.");
            }
            else if (speech.Contains("poet") || speech.Contains("poetry"))
            {
                Say("Poetry weaves truth and longing together. Would you hear a verse of longing or of victory?");
            }
            else if (speech.Contains("longing"))
            {
                Say("\"The stars of longing shine bright in my night, guiding me through the storms of time.\"");
            }
            else if (speech.Contains("victory"))
            {
                Say("\"Victory is a fleeting guest; wisdom, the eternal companion of the soul.\"");
            }
            else if (speech.Contains("king") || speech.Contains("dynasty"))
            {
                Say("I founded the Safavid dynasty, forging a realm from the fires of strife and the dreams of poets.");
            }
            else if (speech.Contains("azerbaijan"))
            {
                Say("Azerbaijan is the jewel of the Caucasus—land of fire, poets, and warriors.");
            }
            else if (speech.Contains("qizilbash") || speech.Contains("red") || speech.Contains("followers"))
            {
                Say("The Qizilbash, my loyal red-capped warriors, followed me through battle and storm.");
            }
            else if (speech.Contains("battle") || speech.Contains("sword"))
            {
                Say("Victory is earned with both pen and blade. My scimitar knew no fear on the field of Chaldiran.");
            }
            else if (speech.Contains("tabriz"))
            {
                Say("Tabriz was my first capital, city of artisans and traders, where dreams became reality.");
            }
            else if (speech.Contains("shia") || speech.Contains("faith"))
            {
                Say("My faith is Shia, my heart open to all who seek justice and unity.");
            }
			else if (speech.Contains("childhood"))
			{
				Say("My childhood was spent in Ardebil, listening to the songs of dervishes and learning the stories of ancient kings.");
			}
			else if (speech.Contains("ardebil"))
			{
				Say("Ardebil, the sacred city, was home to my ancestors and the seat of the Sufi order that shaped my destiny.");
			}
			else if (speech.Contains("sufi") || speech.Contains("dervish"))
			{
				Say("The wisdom of the Sufis taught me patience and compassion, even when war loomed on the horizon.");
			}
			else if (speech.Contains("compassion"))
			{
				Say("A king rules best when his heart is soft to his people but steadfast to his enemies.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("I faced many enemies—Ottomans, Uzbeks, and those who doubted the power of unity.");
			}
			else if (speech.Contains("ottoman") || speech.Contains("turkey"))
			{
				Say("The Ottoman sultans challenged my faith and my land. We clashed at Chaldiran, where fate chose the victor.");
			}
			else if (speech.Contains("chaldiran"))
			{
				Say("The battle of Chaldiran was fierce and fateful. Though wounded, my resolve never wavered.");
			}
			else if (speech.Contains("wound") || speech.Contains("wounded"))
			{
				Say("Every scar is a story. The wounds I bore made me both humble and strong.");
			}
			else if (speech.Contains("strong") || speech.Contains("strength"))
			{
				Say("Strength lies not just in the sword, but in the unity of purpose and the resilience of spirit.");
			}
			else if (speech.Contains("spirit"))
			{
				Say("Let your spirit burn bright, for the flame within cannot be quenched by shadow.");
			}
			else if (speech.Contains("shadow"))
			{
				Say("In every king’s shadow walks regret, but also hope—for what is lost may yet inspire new dreams.");
			}
			else if (speech.Contains("dreams") || speech.Contains("dream"))
			{
				Say("My dreams were filled with the hope of a united people, bound by justice and wisdom.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the balance of mercy and truth. A nation built on justice will endure beyond the ages.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth shines brighter than any gem, and in its light, all are revealed—friend and foe alike.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("My dearest friend was my mother, Martha, who taught me to listen more than to speak.");
			}
			else if (speech.Contains("mother") || speech.Contains("martha"))
			{
				Say("Martha, wise and patient, gave me the strength to rise from loss and the courage to lead.");
			}
			else if (speech.Contains("loss"))
			{
				Say("Loss shapes us. It tempers ambition, reminding kings that every crown is forged in both grief and hope.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is the fire that survives every winter. Carry it with you, always.");
			}
			else if (speech.Contains("winter"))
			{
				Say("The winters of Azerbaijan are harsh, but our hearths burn bright with song and story.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("The ashughs sing of love and loss. Their music is the soul of our land.");
			}
			else if (speech.Contains("ashugh") || speech.Contains("bard"))
			{
				Say("The ashugh bards carry stories across valleys and centuries, keeping our memory alive.");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory is both blessing and burden. Through memory, our ancestors walk beside us.");
			}						
            else if (speech.Contains("unity"))
            {
                Say("Only united could our tribes withstand empires. Unity, above all, is my legacy.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A king’s true legacy is not stone or gold, but the unity and inspiration left in the hearts of the people.");
            }
            else if (speech.Contains("fire"))
            {
                Say("From the eternal flames of Ateshgah to the fire in our hearts, Azerbaijan endures.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest") || speech.Contains("treasure"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True treasure is patience. Return to me when the stars align once more.");
                }
                else
                {
                    Say("You have unraveled my tale, seeker. Take this Treasure Chest of Azerbaijan—a symbol of poetry, unity, and fire!");
                    from.AddToBackpack(new TreasureChestOfAzerbaijan());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the flame of wisdom guide your journey, traveler.");
            }
            else
            {
                // Optional: Encourage discovery if no keywords match
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Azerbaijan, poetry, Qizilbash, or the fires of unity.");
                }
            }

            base.OnSpeech(e);
        }

        public ShahIsmailKhatai(Serial serial) : base(serial) { }

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
