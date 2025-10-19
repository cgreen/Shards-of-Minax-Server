using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Cyrus the Great")]
    public class CyrusTheGreat : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public CyrusTheGreat() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Cyrus the Great";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 75;
            Int = 110;
            Hits = 90;

            // Unique Appearance: Persian King
            AddItem(new FancyShirt() { Name = "Royal Tunic of Pasargadae", Hue = 1161 });
            AddItem(new LongPants() { Name = "Saffron Silk Trousers of Persepolis", Hue = 2208 });
            AddItem(new Cloak() { Name = "Imperial Mantle of the Persians", Hue = 2105 });
            AddItem(new BodySash() { Name = "Azure Sash of Achaemenid Nobility", Hue = 1373 });
            AddItem(new Boots() { Name = "Boots of the Seven Generals", Hue = 1802 });
            AddItem(new Circlet() { Name = "Golden Diadem of Cyrus", Hue = 1175 });

            // Weapon: Scimitar
            AddItem(new Scimitar() { Name = "Persian Lionblade of Cyrus", Hue = 1109 });

            // Speech Hue
            SpeechHue = 2125;

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
                Say("I am called Cyrus, king of Anshan, founder of the Achaemenid Empire, and known as Cyrus the Great.");
            }
            else if (speech.Contains("job"))
            {
                Say("My purpose was to unite kingdoms, grant freedom, and govern with justice. I am a ruler and a liberator.");
            }
            else if (speech.Contains("health"))
            {
                Say("Strength remains, for the spirit of Persia endures through the ages.");
            }
            else if (speech.Contains("persia"))
            {
                Say("Persia—land of poets, warriors, and kings. From the Zagros mountains to the great cities of Persepolis and Pasargadae.");
            }
            else if (speech.Contains("empire"))
            {
                Say("My empire stretched from Lydia to Babylon, embracing many peoples and beliefs.");
            }
            else if (speech.Contains("achaemenid"))
            {
                Say("The Achaemenids are my dynasty, a line of kings who honored wisdom, courage, and unity.");
            }
            else if (speech.Contains("pasargadae"))
            {
                Say("Pasargadae was my capital—a city of gardens, palaces, and the tomb where I now rest.");
            }
            else if (speech.Contains("persepolis"))
            {
                Say("Persepolis, built by my descendants, became the crown jewel of Persia, filled with art and learning.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("I am remembered for freeing the people of Babylon, allowing all faiths to flourish in my lands.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice is the soul of an empire. My laws protected the weak and respected the customs of all peoples.");
            }
            else if (speech.Contains("king") || speech.Contains("ruler"))
            {
                Say("A true king serves his people. My legacy endures because I valued peace as much as conquest.");
            }
            else if (speech.Contains("tomb"))
            {
                Say("My tomb lies in Pasargadae, inscribed: 'O man, whoever you are, I am Cyrus, who founded the Persian Empire.'");
            }
            else if (speech.Contains("lion") || speech.Contains("lionblade"))
            {
                Say("The lion is the symbol of Persia—strength, courage, and majesty united.");
            }
            else if (speech.Contains("battle"))
            {
                Say("From the fields of Media to the gates of Babylon, every battle forged the future of Persia.");
            }
            else if (speech.Contains("babylon"))
            {
                Say("The gates of Babylon opened to me without bloodshed. There, I proclaimed freedom for all peoples.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the mightiest weapon—seek it in the tales of your elders and the silence of the desert.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is the highest victory. Empires endure not by fear, but by justice and respect.");
            }
            else if (speech.Contains("garden") || speech.Contains("gardens"))
            {
                Say("Persian gardens are a paradise on earth—places of beauty, reflection, and renewal.");
            }
            else if (speech.Contains("faith"))
            {
                Say("All faiths were welcomed in my empire. True strength comes from understanding and tolerance.");
            }
			else if (speech.Contains("anushan"))
			{
				Say("Before I was called the Great, I ruled as king of Anshan—a kingdom of proud heritage and ancient customs.");
			}
			else if (speech.Contains("media"))
			{
				Say("Media, land of the Medes, was both rival and kin. Through unity, our peoples forged a new era of strength.");
			}
			else if (speech.Contains("croesus") || speech.Contains("lydia"))
			{
				Say("Croesus of Lydia challenged my rule, but wisdom overcame gold. Lydia became a jewel of the Persian crown.");
			}
			else if (speech.Contains("conquest"))
			{
				Say("Conquest is not only by sword, but by heart and mind. The truest victories are those that bring unity.");
			}
			else if (speech.Contains("inscription"))
			{
				Say("Upon my tomb, an inscription calls out to every traveler: 'O man, whoever you are, I am Cyrus.' Even kings return to dust.");
			}
			else if (speech.Contains("dream"))
			{
				Say("A dream guided me: a vision of an empire where every faith could flourish and justice reigned.");
			}
			else if (speech.Contains("magus") || speech.Contains("magi"))
			{
				Say("The Magi were keepers of ancient wisdom and sacred fire. Their counsel shaped the fate of kings.");
			}
			else if (speech.Contains("cylinder"))
			{
				Say("The Cyrus Cylinder is my proclamation—a promise of liberty, dignity, and respect for all peoples.");
			}
			else if (speech.Contains("river"))
			{
				Say("The rivers of Persia—Tigris, Euphrates, and Oxus—brought life to empires and connected distant lands.");
			}
			else if (speech.Contains("zoroaster") || speech.Contains("zoroastrian"))
			{
				Say("Zoroaster brought the light of Ahura Mazda to Persia, teaching truth, good thoughts, and good deeds.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade routes crossed my lands, carrying spices, gems, and stories from east and west.");
			}
			else if (speech.Contains("spice") || speech.Contains("spices"))
			{
				Say("Persian dishes are rich with saffron, sumac, and the aromas of distant gardens.");
			}
			else if (speech.Contains("horse") || speech.Contains("horses"))
			{
				Say("Persian horses—swift, strong, and loyal—carried messages and warriors across my empire.");
			}
			else if (speech.Contains("satrap"))
			{
				Say("Satraps governed my provinces, ensuring justice, order, and prosperity in every corner of the empire.");
			}
			else if (speech.Contains("tribute"))
			{
				Say("Peoples of many lands brought tribute, but I valued peace and loyalty above all riches.");
			}
			else if (speech.Contains("festival") || speech.Contains("norooz"))
			{
				Say("Norooz, the Persian New Year, is a celebration of renewal, light, and hope for all peoples.");
			}
			else if (speech.Contains("queen") || speech.Contains("cassandane"))
			{
				Say("Cassandane was my beloved queen, wise and gentle. Her loss brought great sorrow to my heart.");
			}
			else if (speech.Contains("family"))
			{
				Say("My sons, Cambyses and Bardiya, and my line continued the flame of Achaemenid rule.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Every enemy teaches a lesson. Some become friends, others shape destiny with their opposition.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("The oracles whispered omens and advice; even the greatest king must heed the voice of fate.");
			}
			else if (speech.Contains("fate"))
			{
				Say("Fate is a river that cannot be held. Even kings must bow to its current.");
			}			
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not only in stone, but in every act of justice and every life set free.");
            }
            else if (speech.Contains("reward") || speech.Contains("treasure") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. Ancient treasures are not granted lightly. Return to me in due time.");
                }
                else
                {
                    Say("You have shown the curiosity and wisdom of a true seeker. Accept this Treasure Chest of Ancient Persia, a token of our empire’s greatness.");
                    from.AddToBackpack(new TreasureChestOfAncientPersia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the light of Persia guide your path.");
            }
            else
            {
                // Encourage further exploration
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of empire, justice, lionblade, or the gardens of Pasargadae.");
                }
            }

            base.OnSpeech(e);
        }

        public CyrusTheGreat(Serial serial) : base(serial) { }

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
