using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Simón Bolívar")]
    public class SimonBolivar : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public SimonBolivar() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Simón Bolívar";
            Body = 0x190; // Human male

            // Unique Colombian Liberator Outfit
            AddItem(new FancyShirt() { Name = "Bolívar's Liberation Tunic", Hue = 1150 });
            AddItem(new FancyKilt() { Name = "Sash of Gran Colombia", Hue = 1357 });
            AddItem(new Cloak() { Name = "Mantle of the Andes", Hue = 2502 });
            AddItem(new Boots() { Name = "Rider's Boots of the Llanos", Hue = 2105 });
            AddItem(new BodySash() { Name = "Banner of Freedom", Hue = 1375 });
            AddItem(new TricorneHat() { Name = "Libertador's Hat", Hue = 2217 });

            // Weapon: Saber
            AddItem(new Katana() { Name = "Sword of the Liberator", Hue = 1164 });

            SpeechHue = 2115;

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
                Say("I am Simón Bolívar, El Libertador. My name echoes across mountains and valleys of Colombia.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a soldier, always a dreamer. My job was to fight for freedom, to unite, and to inspire.");
            }
            else if (speech.Contains("health"))
            {
                Say("Battles and journeys have left their mark, but my spirit burns with the fire of liberty.");
            }
            else if (speech.Contains("colombia"))
            {
                Say("Colombia is a land of emerald mountains, coffee fields, and hearts hungry for freedom.");
            }
            else if (speech.Contains("liberator") || speech.Contains("libertador"))
            {
                Say("They called me El Libertador. I dreamed of one nation, strong and free from tyranny.");
            }
            else if (speech.Contains("gran colombia"))
            {
                Say("Gran Colombia was my vision—a great republic, united from the Caribbean to the Andes.");
            }
            else if (speech.Contains("freedom") || speech.Contains("liberty"))
            {
                Say("Freedom is the birthright of every soul. Only together can we defend it.");
            }
            else if (speech.Contains("spanish") || speech.Contains("spain"))
            {
                Say("Spain ruled these lands with iron chains. Our revolution broke those bonds.");
            }
            else if (speech.Contains("battle"))
            {
                Say("I led many battles—Boyacá, Carabobo, Junín. Each victory was paid for with courage and sacrifice.");
            }
            else if (speech.Contains("boyaca"))
            {
                Say("The Battle of Boyacá opened the gates of Bogotá. There, the dream of Colombia became real.");
            }
            else if (speech.Contains("andes"))
            {
                Say("We crossed the Andes, braving snow and storm, so that Colombia could be free.");
            }
            else if (speech.Contains("dream"))
            {
                Say("I dreamed of unity and peace—a nation where all voices sing together.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is the strength of a people. Divided, we are weak. United, we are unstoppable.");
            }
            else if (speech.Contains("enemy"))
            {
                Say("The enemy was not only Spain, but ignorance, fear, and division.");
            }
            else if (speech.Contains("coffee"))
            {
                Say("Colombian coffee is a symbol of our land—strong, rich, and cherished around the world.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The Andes protected and challenged us. Their peaks are the guardians of Colombia.");
            }
			else if (speech.Contains("revolution"))
			{
				Say("The revolution was born not in palaces, but in the streets and fields—among the people who hungered for change.");
			}
			else if (speech.Contains("change"))
			{
				Say("Change is a storm. It uproots the old, sometimes painfully, to plant the seeds of a better future.");
			}
			else if (speech.Contains("caribbean"))
			{
				Say("The Caribbean coast is Colombia's window to the world, where music and commerce sail on every tide.");
			}
			else if (speech.Contains("music"))
			{
				Say("Colombian music is the heartbeat of our people—listen for the cumbia and vallenato at every gathering.");
			}
			else if (speech.Contains("cumbia"))
			{
				Say("Cumbia was born by the Magdalena River, where drums and flutes weave the story of Colombia's soul.");
			}
			else if (speech.Contains("magdalena"))
			{
				Say("The Magdalena River is the lifeblood of Colombia, carrying trade, tales, and hope from the Andes to the sea.");
			}
			else if (speech.Contains("sea"))
			{
				Say("Our sea is rich and wild, a frontier for explorers and a home for fishermen and dreamers alike.");
			}
			else if (speech.Contains("dreamers"))
			{
				Say("Dreamers built this nation—never fear to dream boldly, for all great deeds begin with hope.");
			}
			else if (speech.Contains("liberators"))
			{
				Say("I was not alone—many Liberators fought for Colombia. Look to Sucre, Miranda, and the brave people of every village.");
			}
			else if (speech.Contains("sucre"))
			{
				Say("Antonio José de Sucre, the Marshal of Ayacucho, was both my student and my friend—a hero in his own right.");
			}
			else if (speech.Contains("miranda"))
			{
				Say("Francisco de Miranda carried the torch of freedom before me. His vision inspired revolutions across continents.");
			}
			else if (speech.Contains("continent"))
			{
				Say("South America is vast and diverse, but our hearts are united in the yearning for liberty.");
			}
			else if (speech.Contains("diverse") || speech.Contains("diversity"))
			{
				Say("Colombia's diversity is its strength—indigenous, African, and Spanish roots blend to create something beautiful.");
			}
			else if (speech.Contains("indigenous"))
			{
				Say("The indigenous peoples are the original guardians of this land. Their wisdom and courage deserve honor.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom comes not only with age, but with listening. Listen to the wind, to elders, and to your own heart.");
			}
			else if (speech.Contains("elders"))
			{
				Say("The elders of Colombia remember wars, droughts, and fiestas. Their stories are the history of us all.");
			}
			else if (speech.Contains("history"))
			{
				Say("To know our history is to understand our future. Ask, listen, and carry the flame forward.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future is unwritten, traveler. With courage and unity, you will help shape it.");
			}
			else if (speech.Contains("writer") || speech.Contains("writers"))
			{
				Say("Colombia is the land of writers—Gabriel García Márquez turned our myths into magic for the world to read.");
			}
			else if (speech.Contains("magic"))
			{
				Say("There is magic in our land, in our rivers and mountains, and in the spirit of our people.");
			}
			else if (speech.Contains("river"))
			{
				Say("Every river in Colombia is a road, a border, and a legend. Respect them, and they will guide you.");
			}
			else if (speech.Contains("legend") || speech.Contains("legends"))
			{
				Say("Some say El Dorado lies hidden in Colombia’s jungles. The real legend is the courage of its people.");
			}
			else if (speech.Contains("jungle") || speech.Contains("jungles"))
			{
				Say("Our jungles are emerald labyrinths, full of life and mystery. Many stories are whispered beneath their leaves.");
			}
			else if (speech.Contains("mystery"))
			{
				Say("Colombia holds many mysteries—some are gold and jewels, others are stories and dreams.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace was my greatest dream for Colombia. Remember: it is harder to keep peace than to win war.");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("Colombia's true treasure is its people—resilient, passionate, and proud.");
            }
            else if (speech.Contains("flag"))
            {
                Say("The Colombian flag bears yellow for gold, blue for ocean, and red for blood shed for freedom.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Our land is rich in gold, but greater riches are found in justice and honor.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice must serve all, not only the powerful. Only then can liberty survive.");
            }
            else if (speech.Contains("friend"))
            {
                Say("My closest friend was Francisco de Paula Santander, the man of laws to my sword.");
            }
            else if (speech.Contains("santander"))
            {
                Say("Santander was the architect of Colombia's laws, a mind as sharp as any blade.");
            }
            else if (speech.Contains("bogota"))
            {
                Say("Bogotá—city of learning and hope—became the heart of our new nation.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends are not born, they are forged in the fire of revolution and hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the lantern that guides us through the darkness of tyranny.");
            }
            else if (speech.Contains("llanos"))
            {
                Say("The Llanos gave us brave llaneros—cavalry who rode like the wind and fought for Colombia.");
            }
            else if (speech.Contains("llanero") || speech.Contains("llaneros"))
            {
                Say("The llaneros are the soul of the plains, as fierce as their stallions.");
            }
            else if (speech.Contains("emerald"))
            {
                Say("Colombia's emeralds shine as brightly as our dreams for the future.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who dare to dream and fight for justice.");
            }
            else if (speech.Contains("libertad"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Libertad is not given; it is earned through patience. Return to me when the time is right.");
                }
                else
                {
                    Say("For your search for Libertad, accept this Treasure Chest of Colombia. May it inspire courage and unity in your journey.");
                    from.AddToBackpack(new TreasureChestOfColombia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Vaya con libertad, viajero. May your path always be guided by hope and unity.");
            }
            else
            {
                // Small chance to encourage further clues
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Boyacá, the Andes, Gran Colombia, or the true treasure of our land.");
                }
            }

            base.OnSpeech(e);
        }

        public SimonBolivar(Serial serial) : base(serial) { }

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
