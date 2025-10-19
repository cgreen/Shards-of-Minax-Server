using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ahmad Shah Durrani")]
    public class AhmadShahDurrani : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AhmadShahDurrani() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ahmad Shah Durrani";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 70;
            Int = 95;
            Hits = 75;

            // Unique Appearance: Afghan King
            AddItem(new FancyShirt() { Name = "Royal Silk Tunic of Kandahar", Hue = 1154 });
            AddItem(new FancyKilt() { Name = "Sash of the Durrani Empire", Hue = 2401 });
            AddItem(new Cloak() { Name = "Mantle of the Afghan Kings", Hue = 2425 });
            AddItem(new WideBrimHat() { Name = "Durrani Turban", Hue = 2006 });
            AddItem(new Sandals() { Name = "Desert Nomad's Sandals", Hue = 2101 });
            AddItem(new BodySash() { Name = "Emerald Sash of Peshawar", Hue = 1412 });

            // Weapon: Curved Sword (Scimitar)
            AddItem(new Scimitar() { Name = "Khyber Sword of Ahmad Shah", Hue = 1175 });

            // Speech Hue
            SpeechHue = 2123;

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
                Say("You stand before Ahmad Shah Durrani, founder of the Durrani Empire and Father of Afghanistan.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a leader of men, I united Afghan tribes and forged a mighty empire from the ashes of war.");
            }
            else if (speech.Contains("health"))
            {
                Say("The spirit of kings endures, though the weight of crown and conflict is heavy.");
            }
            else if (speech.Contains("durrani"))
            {
                Say("The Durrani were noble Pashtun tribes. My empire stretched from Kandahar to Delhi and the Persian border.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empire is both glory and burden. I ruled from Kandahar, yet my heart longed for peace among my people.");
            }
            else if (speech.Contains("afghanistan"))
            {
                Say("Afghanistan is a land of mountains, warriors, and poets. Its history is written with courage and sacrifice.");
            }
            else if (speech.Contains("kandahar"))
            {
                Say("Kandahar was my capital, city of stone and silk, crossroads of caravan and conquest.");
            }
            else if (speech.Contains("tribes"))
            {
                Say("Only by uniting the tribes—Pashtun, Tajik, Uzbek—could Afghanistan know strength and purpose.");
            }
            else if (speech.Contains("king"))
            {
                Say("Kings are but caretakers. True legacy lies not in gold, but in the hearts of their people.");
            }
            else if (speech.Contains("battle"))
            {
                Say("I fought many battles: against Persians, Mughals, and Sikhs. Each shaped the destiny of our land.");
            }
            else if (speech.Contains("destiny"))
            {
                Say("Destiny is woven with the choices we make—some by courage, others by wisdom.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is won through hardship and the counsel of loyal friends.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is the fire that forges kings. Only by facing fear did I claim my crown.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Some say the Durrani treasury overflowed with gold and emeralds, hidden across the land.");
            }
            else if (speech.Contains("emerald"))
            {
                Say("Afghan emeralds are famed from Panshir to Persia. They are the tears of mountains.");
            }
			else if (speech.Contains("poet") || speech.Contains("poetry"))
			{
				Say("Ah, poetry is the soul of Afghanistan! Our poets turn grief into song and valor into verse.");
			}
			else if (speech.Contains("song"))
			{
				Say("The songs of our bards echo in the mountains and carry tales of ancient heroes.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("Our mountains are both shield and challenge, guardians of secrets and treasures.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A king’s friend is rarer than gold. My most trusted ally was Timur Shah, my beloved son.");
			}
			else if (speech.Contains("son") || speech.Contains("timur shah"))
			{
				Say("Timur Shah carried forward the Durrani name, ruling from Kabul and learning the lessons of empire.");
			}
			else if (speech.Contains("kabul"))
			{
				Say("Kabul, the city of gardens, became a throne for kings and a haven for dreamers.");
			}
			else if (speech.Contains("garden") || speech.Contains("gardens"))
			{
				Say("Our gardens are sanctuaries—places to reflect, to rest, and to plan for tomorrow.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade flowed through our land—silks from China, spices from India, and wisdom from Persia.");
			}
			else if (speech.Contains("spice") || speech.Contains("spices"))
			{
				Say("Spices give flavor to life, just as ambition gives flavor to destiny.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Seek wisdom not only in books, but in the stories of elders and the silence of the desert.");
			}
			else if (speech.Contains("elder") || speech.Contains("elders"))
			{
				Say("The elders hold the memory of the land. Their counsel is worth more than jewels.");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory is a river—sometimes gentle, sometimes fierce, always flowing through the soul of a nation.");
			}
			else if (speech.Contains("nation"))
			{
				Say("A nation is more than borders; it is the dreams, struggles, and unity of its people.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams give hope to the weary and vision to those who lead. Never stop dreaming, traveler.");
			}
			else if (speech.Contains("warrior") || speech.Contains("warriors"))
			{
				Say("Afghanistan has known many warriors—some gentle, some fierce. Their stories inspire new generations.");
			}
			else if (speech.Contains("horse") || speech.Contains("horses"))
			{
				Say("My favorite steed was as swift as the desert wind and as loyal as my own shadow.");
			}
			else if (speech.Contains("shadow"))
			{
				Say("Every king has a shadow—sometimes it is a rival, sometimes a memory, always a lesson.");
			}
			else if (speech.Contains("rival"))
			{
				Say("A rival keeps one vigilant and humble. My greatest rival was Nader Shah of Persia.");
			}
			else if (speech.Contains("persia"))
			{
				Say("Persia and Afghanistan—sometimes neighbors, sometimes foes, always bound by history and fate.");
			}			
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not in treasure, but in the unity of a people and the endurance of a nation.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The treasures of kings cannot be given so lightly. Return to me in due time.");
                }
                else
                {
                    Say("For your curiosity and respect, accept a Treasure Chest of Afghan Kings—may it remind you of unity, courage, and destiny.");
                    from.AddToBackpack(new TreasureChestOfAfghanKings());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the spirit of Afghanistan guide your path, traveler.");
            }
            else
            {
                // Optional: Encourage discovery if no keywords match
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of empire, treasure, Kandahar, or the Durrani legacy.");
                }
            }

            base.OnSpeech(e);
        }

        public AhmadShahDurrani(Serial serial) : base(serial) { }

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
