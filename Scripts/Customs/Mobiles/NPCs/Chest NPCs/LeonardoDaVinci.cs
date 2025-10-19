using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Leonardo da Vinci")]
    public class LeonardoDaVinci : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public LeonardoDaVinci() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Leonardo da Vinci";
            Body = 0x190; // Human male body

            // Stats
            Str = 85;
            Dex = 70;
            Int = 120;
            Hits = 80;

            // Unique Renaissance Outfit
            AddItem(new FancyShirt() { Name = "Shirt of the Renaissance Master", Hue = 1150 });
            AddItem(new GuildedKilt() { Name = "Florentine Artisan's Tunic", Hue = 2213 });
            AddItem(new BodySash() { Name = "Sash of Invention", Hue = 1109 });
            AddItem(new Cloak() { Name = "Cloak of Ingenious Curiosity", Hue = 1161 });
            AddItem(new FeatheredHat() { Name = "Polymath's Cap", Hue = 1135 });
            AddItem(new Boots() { Name = "Traveler's Boots of Tuscany", Hue = 1141 });

            // Accessory: Painter's Palette (weapon slot)
            AddItem(new ScribeSword() { Name = "Painter's Palette Blade", Hue = 1153 });

            // Speech Hue
            SpeechHue = 1160;

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
                Say("I am Leonardo da Vinci—painter, engineer, dreamer, and humble observer of the world's secrets.");
            }
            else if (speech.Contains("job"))
            {
                Say("I pursue knowledge in all things: art, invention, anatomy, even the secrets of flight.");
            }
            else if (speech.Contains("health"))
            {
                Say("My hand may tremble, but my mind soars. Curiosity keeps my spirit young.");
            }
            else if (speech.Contains("florence"))
            {
                Say("Florence was my cradle, the city where genius and art flourished side by side.");
            }
            else if (speech.Contains("invention") || speech.Contains("inventor"))
            {
                Say("I have dreamed of flying machines, war engines, and devices to measure the stars. The world is a workshop for those who imagine.");
            }
            else if (speech.Contains("art") || speech.Contains("artist"))
            {
                Say("Art is a science, and science is an art. Both seek to capture the wonders of nature.");
            }
            else if (speech.Contains("painting") || speech.Contains("paint"))
            {
                Say("Painting is the silent poetry of the soul. My most famous is the Mona Lisa, yet I cherish each brushstroke.");
            }
            else if (speech.Contains("mona lisa"))
            {
                Say("The Mona Lisa's smile hides many mysteries. To truly see, one must look with both eyes and mind.");
            }
            else if (speech.Contains("science"))
            {
                Say("Science is born of curiosity. Dissect the world, and its beauty reveals itself.");
            }
            else if (speech.Contains("flight") || speech.Contains("fly"))
            {
                Say("Ah, to soar like a bird! My notebooks are filled with sketches of wings and flying machines.");
            }
            else if (speech.Contains("notebook") || speech.Contains("notebooks"))
            {
                Say("My notebooks hold countless designs and ideas. Their pages are windows to the future.");
            }
            else if (speech.Contains("patron") || speech.Contains("patrons"))
            {
                Say("I served patrons from Florence to Milan, including Lorenzo de' Medici and the Duke of Milan.");
            }
            else if (speech.Contains("milan"))
            {
                Say("In Milan, I crafted the great horse and painted The Last Supper. Every city is a new canvas.");
            }
            else if (speech.Contains("last supper"))
            {
                Say("The Last Supper captures a moment of revelation and betrayal. Each disciple tells a story with a glance.");
            }
            else if (speech.Contains("anatomy"))
            {
                Say("Through study of anatomy, I sought to understand the engine of life itself.");
            }
            else if (speech.Contains("genius"))
            {
                Say("Genius is perseverance married to curiosity. Every day brings new puzzles to solve.");
            }
            else if (speech.Contains("mirror") || speech.Contains("mirrors"))
            {
                Say("I wrote my notes in mirror script—sometimes the greatest discoveries must be protected from idle eyes.");
            }
			else if (speech.Contains("vitruvian"))
			{
				Say("The Vitruvian Man seeks to show the harmony of the human body—a mirror to the universe itself.");
			}
			else if (speech.Contains("mechanics") || speech.Contains("machine"))
			{
				Say("I have sketched clocks, gears, and even a design for a mechanical knight. All the world is in motion!");
			}
			else if (speech.Contains("nature"))
			{
				Say("From the flight of birds to the ripple of water, nature’s patterns inspire both my art and invention.");
			}
			else if (speech.Contains("bird") || speech.Contains("birds"))
			{
				Say("Birds are the true masters of flight. To understand them is to unlock the secrets of the sky.");
			}
			else if (speech.Contains("water"))
			{
				Say("Water is life’s driving force. I have studied its flow and dreamed of mighty canals for all of Italy.");
			}
			else if (speech.Contains("canal") || speech.Contains("canals"))
			{
				Say("In Milan, I designed canals to move goods and people—a river of progress through stone streets.");
			}
			else if (speech.Contains("anatomy") || speech.Contains("dissect"))
			{
				Say("Through careful study of anatomy, I discovered the beauty and complexity within us all.");
			}
			else if (speech.Contains("mirror"))
			{
				Say("I write many notes in mirror script. Sometimes, to protect ideas, one must see the world differently.");
			}
			else if (speech.Contains("code") || speech.Contains("cipher"))
			{
				Say("A good code keeps secrets safe. Even genius benefits from a little mystery.");
			}
			else if (speech.Contains("medici") || speech.Contains("lorenzo"))
			{
				Say("Lorenzo de' Medici was a true patron of the arts. Florence owes much of its beauty to his vision.");
			}
			else if (speech.Contains("horse"))
			{
				Say("My colossal horse for the Duke of Milan would have towered above all—a monument to human ambition.");
			}
			else if (speech.Contains("apprentice") || speech.Contains("student"))
			{
				Say("I have taught many eager minds. The greatest lesson? Question everything.");
			}
			else if (speech.Contains("quest"))
			{
				Say("Life itself is a quest—endless puzzles, endless marvels.");
			}
			else if (speech.Contains("enemy") || speech.Contains("rival"))
			{
				Say("Genius is often met with rivalry. Yet competition sharpens the mind.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is the daughter of experience. Mistakes, too, are teachers.");
			}
			else if (speech.Contains("paris"))
			{
				Say("In my final years, I found refuge in France. The king himself welcomed me and my machines.");
			}
			else if (speech.Contains("king"))
			{
				Say("Kings seek glory and lasting memory. An artist’s gift is to shape what endures.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A true legacy is not stone or gold, but the questions one leaves behind.");
			}
			else if (speech.Contains("light") || speech.Contains("shadow"))
			{
				Say("To paint is to chase the play of light and shadow. Both reveal hidden truths.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who dare to imagine. What will your future hold?");
			}
			else if (speech.Contains("tools"))
			{
				Say("A wise artisan cherishes his tools—be they brush, quill, or mind.");
			}
			else if (speech.Contains("inspire") || speech.Contains("inspiration"))
			{
				Say("Inspiration visits those who work. Do not wait for the muse; invite her with effort.");
			}
			else if (speech.Contains("question"))
			{
				Say("A good question is worth more than a quick answer. Never be afraid to ask.");
			}			
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("The world is full of secrets, waiting for those bold enough to seek them.");
            }
            else if (speech.Contains("horse"))
            {
                Say("My greatest unfinished work was a statue of a rearing horse—ambition sometimes outpaces opportunity.");
            }
            else if (speech.Contains("nature"))
            {
                Say("Nature is the greatest teacher. Observe, question, and you will see wonders everywhere.");
            }
            else if (speech.Contains("philosophy"))
            {
                Say("Philosophy and art are siblings—each asks: what is beauty, what is truth?");
            }
            else if (speech.Contains("beauty"))
            {
                Say("Beauty is found in proportion, harmony, and a spark of mystery.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who nurture curiosity and never stop learning.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("curiosity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the most curious must wait for inspiration to return. Return when your questions are fresh.");
                }
                else
                {
                    Say("Your curiosity honors the spirit of the Renaissance! Accept this Treasure Chest of Italian History as a token of discovery.");
                    from.AddToBackpack(new TreasureChestOfItalianHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go, and let curiosity be your guide in all things.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of invention, art, Milan, the Mona Lisa, or the nature of genius.");
                }
            }

            base.OnSpeech(e);
        }

        public LeonardoDaVinci(Serial serial) : base(serial) { }

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
