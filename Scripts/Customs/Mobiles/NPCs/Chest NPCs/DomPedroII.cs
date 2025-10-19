using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Dom Pedro II")]
    public class DomPedroII : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public DomPedroII() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Dom Pedro II";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 70;
            Int = 110;
            Hits = 80;

            // Unique Appearance: Emperor of Brazil, 19th century
            AddItem(new FormalShirt() { Name = "Imperial Linen Shirt", Hue = 1150 });
            AddItem(new FancyKilt() { Name = "Sash of the Second Empire", Hue = 1154 });
            AddItem(new Robe() { Name = "Velvet Robe of Progress", Hue = 1345 });
            AddItem(new Epaulette() { Name = "Gold Epaulettes of Authority", Hue = 2213 });
            AddItem(new FeatheredHat() { Name = "Imperial Plumed Hat", Hue = 2105 });
            AddItem(new Boots() { Name = "Leather Boots of the Tropics", Hue = 1175 });
            AddItem(new BodySash() { Name = "Order of the Southern Cross Sash", Hue = 1260 });

            // Weapon: Scepter, symbolizing wisdom
            AddItem(new Scepter() { Name = "Scepter of Enlightenment", Hue = 2219 });

            // Speech Hue
            SpeechHue = 2120;

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
                Say("You address Dom Pedro II, Emperor of Brazil and servant to knowledge and progress.");
            }
            else if (speech.Contains("job"))
            {
                Say("I ruled Brazil with a steady hand, but my true passion was learning and guiding my nation towards progress.");
            }
            else if (speech.Contains("health"))
            {
                Say("An emperor's health is measured by the strength of his nation and the wisdom he gathers.");
            }
            else if (speech.Contains("brazil"))
            {
                Say("Brazil is a land of forests, rivers, and many peoples—a young nation destined for greatness.");
            }
            else if (speech.Contains("emperor"))
            {
                Say("An emperor must be more than a ruler. He must be a scholar, a patron of the arts, and a friend to his people.");
            }
            else if (speech.Contains("knowledge"))
            {
                Say("Knowledge is the true wealth of an empire. Ask me of science, poetry, or invention.");
            }
            else if (speech.Contains("science"))
            {
                Say("I welcomed scientists from all nations. The telegraph, the photograph, even the telephone found a home in Brazil.");
            }
            else if (speech.Contains("poetry"))
            {
                Say("Brazilian poets, like Castro Alves, gave voice to freedom and beauty. Poetry is the soul of our land.");
            }
            else if (speech.Contains("invention"))
            {
                Say("Invention is the child of curiosity. Steam engines, railways, and the first telephone in South America—all came to Brazil.");
            }
            else if (speech.Contains("curiosity"))
            {
                Say("Curiosity guided my reign. I collected books, invited explorers, and corresponded with minds such as Darwin and Pasteur.");
            }
            else if (speech.Contains("darwin"))
            {
                Say("Charles Darwin visited our shores; his ideas, though controversial, inspired many in Brazil to seek knowledge in nature.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the birthright of every soul. I fought to abolish slavery in Brazil, though the struggle was long and hard.");
            }
            else if (speech.Contains("slavery"))
            {
                Say("In 1888, Brazil at last ended slavery. The Golden Law brought liberty to thousands—one of my proudest moments.");
            }
            else if (speech.Contains("golden law"))
            {
                Say("The 'Lei Áurea', or Golden Law, was signed by my daughter Princess Isabel. Ask me of her if you wish.");
            }
            else if (speech.Contains("isabel") || speech.Contains("princess"))
            {
                Say("Princess Isabel was both kind and steadfast. Her signature ended centuries of injustice in Brazil.");
            }
            else if (speech.Contains("amazon"))
            {
                Say("The Amazon is a world unto itself: rivers wider than oceans, trees as old as time, and mysteries yet unknown.");
            }
            else if (speech.Contains("river"))
            {
                Say("Our rivers—Amazon, São Francisco, Paraná—bind our lands and nurture our people.");
            }
            else if (speech.Contains("coffee"))
            {
                Say("Coffee is the lifeblood of Brazil’s trade. Its aroma filled my court and powered the empire.");
            }
            else if (speech.Contains("court"))
            {
                Say("My court was open to artists, musicians, and inventors. I believed beauty uplifts the soul.");
            }
            else if (speech.Contains("art"))
            {
                Say("Art flourished in my Brazil. Painters like Pedro Américo captured our history on canvas.");
            }
            else if (speech.Contains("history"))
            {
                Say("History is a tapestry—ask of independence, or of Tiradentes, who gave his life for freedom.");
            }
            else if (speech.Contains("independence"))
            {
                Say("Brazil’s independence came in 1822, declared by my father, Dom Pedro I. I was but a child then.");
            }
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who value both tradition and innovation. I believe Brazil’s brightest days still lie ahead.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Tradition is a strong root—yet, even the mightiest tree must reach for the sun of progress.");
			}
			else if (speech.Contains("music"))
			{
				Say("Brazilian music is a wonder—lively and soulful. The sounds of choro and modinha graced my court, and the rhythms of the people bring joy to all.");
			}
			else if (speech.Contains("slaves") || speech.Contains("enslaved"))
			{
				Say("The suffering of the enslaved weighed heavily on my conscience. Freedom was a cause dear to my heart and soul.");
			}
			else if (speech.Contains("palace"))
			{
				Say("The Imperial Palace was a place of both work and learning. Its halls heard debates, laughter, and sometimes, sorrow.");
			}
			else if (speech.Contains("rainforest"))
			{
				Say("The rainforest shelters countless wonders—jaguars, orchids, and tribes who have lived in harmony with nature for centuries.");
			}
			else if (speech.Contains("tribe") || speech.Contains("tribes"))
			{
				Say("Brazil’s native peoples are wise and resilient. Their knowledge of the land is unmatched, and their stories are as old as the rivers.");
			}
			else if (speech.Contains("sorrow"))
			{
				Say("An emperor’s life is not without sorrow—exile, loss, the weight of choices. Yet, I always found comfort in books and in hope for the nation.");
			}
			else if (speech.Contains("book") || speech.Contains("books"))
			{
				Say("Books are treasures beyond gold. My personal library was vast—if only I could have brought it with me into exile.");
			}
			else if (speech.Contains("exile"))
			{
				Say("When the empire fell, I lived the rest of my days in distant lands. Yet, my heart always remained in Brazil.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("True friends are a rare gift. Among mine was Louis Pasteur, who taught me the wonders of science and healing.");
			}
			else if (speech.Contains("education"))
			{
				Say("Education is the foundation of a free society. I founded schools, supported teachers, and dreamed of a literate Brazil.");
			}
			else if (speech.Contains("monarchy"))
			{
				Say("A wise monarchy serves its people, not itself. My duty was always to Brazil, not to power.");
			}
			else if (speech.Contains("painting") || speech.Contains("painter"))
			{
				Say("Painters like Victor Meirelles captured both our triumphs and our struggles on canvas. Art tells the story of a nation.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals fill Brazil with color and laughter. From Carnival to Festa Junina, the spirit of celebration endures.");
			}
			else if (speech.Contains("carnival"))
			{
				Say("Carnival is a feast of music and joy—a time when the whole country dances as one.");
			}
			else if (speech.Contains("palm") || speech.Contains("palms"))
			{
				Say("The royal palms of Rio de Janeiro were planted in my honor. They reach for the sky, just as Brazil does.");
			}
			else if (speech.Contains("family"))
			{
				Say("My family was both my pride and my burden. Ask of my wife, Teresa Cristina, if you wish.");
			}
			else if (speech.Contains("teresa cristina"))
			{
				Say("Empress Teresa Cristina was a gentle spirit and a steadfast companion. She shared my love for music and art.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("Our rivers are lifeblood—carrying hope, trade, and stories from the mountains to the sea.");
			}
			else if (speech.Contains("sea"))
			{
				Say("The Atlantic’s waves shape our coasts and connect us to the wider world. I often gazed out and wondered what the future held.");
			}
			else if (speech.Contains("wonder"))
			{
				Say("To wonder is to be alive! I encourage all who cross my path to ask questions, to seek answers, and never to stop learning.");
			}			
            else if (speech.Contains("tiradentes"))
            {
                Say("Tiradentes is a hero, a martyr for liberty. His name inspires all who yearn for justice.");
            }
            else if (speech.Contains("progress"))
            {
                // This is the secret reward word!
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Progress must be pursued with patience. Return to me when the sun has turned again.");
                }
                else
                {
                    Say("Your quest for progress honors Brazil's legacy. Take this Treasure Chest of Brazil’s History—may it inspire you to dream, to learn, and to build.");
                    from.AddToBackpack(new TreasureChestOfBrazilsHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the future shine bright upon you, seeker of wisdom.");
            }
            else
            {
                // Chance to nudge them toward a clue
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Brazil, progress, the Golden Law, or the Amazon.");
                }
            }

            base.OnSpeech(e);
        }

        public DomPedroII(Serial serial) : base(serial) { }

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
