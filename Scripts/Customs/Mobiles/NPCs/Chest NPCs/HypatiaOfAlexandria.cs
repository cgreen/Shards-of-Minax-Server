using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hypatia")]
    public class HypatiaOfAlexandria : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HypatiaOfAlexandria() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hypatia of Alexandria";
            Body = 0x191; // Human female body

            // Unique Appearance: Hellenistic Philosopher
            AddItem(new FancyDress() { Name = "Philosopher's Himation", Hue = 1153 }); // Deep blue
            AddItem(new BodySash() { Name = "Sash of Wisdom", Hue = 1150 }); // Silver
            AddItem(new Sandals() { Name = "Sandals of the Serapeum", Hue = 1109 }); // Soft tan
            AddItem(new HoodedShroudOfShadows() { Name = "Scholar’s Veil", Hue = 1175 }); // Pale gold
            AddItem(new GnarledStaff() { Name = "Mathematician’s Staff", Hue = 1266 }); // Olive wood

            SpeechHue = 1154;
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
                Say("I am Hypatia of Alexandria, philosopher and seeker of truth.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a teacher of mathematics and philosophy, guiding all who thirst for knowledge.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body walks in Alexandria, but my spirit dwells where reason and curiosity flourish.");
            }
            else if (speech.Contains("alexandria"))
            {
                Say("Alexandria is a city of wonders: its lighthouse pierces the mist, and its library once held the wisdom of the world.");
            }
            else if (speech.Contains("library"))
            {
                Say("The Great Library was the heart of learning. Its loss is a wound that bleeds through time.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is not a destination but a journey. Each question is a torch in the darkness.");
            }
            else if (speech.Contains("philosophy"))
            {
                Say("Philosophy is the art of asking—never fearing that truth may overturn your certainties.");
            }
            else if (speech.Contains("mathematics") || speech.Contains("math"))
            {
                Say("In mathematics, the universe reveals its hidden harmonies. Do you seek knowledge of numbers?");
            }
            else if (speech.Contains("science"))
            {
                Say("Science is a lantern to banish superstition. With it, we measure the stars and the soul alike.");
            }
            else if (speech.Contains("stars") || speech.Contains("astronomy"))
            {
                Say("The stars are ancient texts, written in light. Their secrets await the patient observer.");
            }
            else if (speech.Contains("curiosity"))
            {
                Say("Curiosity is sacred; it is the child of wonder and the mother of invention.");
            }
            else if (speech.Contains("serapeum"))
            {
                Say("The Serapeum was a temple of learning, filled with scrolls and seekers. Its silence is now a lesson in impermanence.");
            }
            else if (speech.Contains("scrolls"))
            {
                Say("Each scroll is a whisper from the past, a voice carried across the centuries.");
            }
            else if (speech.Contains("truth"))
            {
                Say("Truth is not afraid of the light. Seek it with courage, and your mind will be unchained.");
            }
            else if (speech.Contains("students") || speech.Contains("student"))
            {
                Say("A good student asks questions. A great one learns how to question themselves.");
            }
            else if (speech.Contains("teacher"))
            {
                Say("A teacher plants seeds in the minds of others, knowing that some may grow only long after they are gone.");
            }
            else if (speech.Contains("logic"))
            {
                Say("Logic is the scaffolding of reason. Without it, the mind stumbles in the dark.");
            }
            else if (speech.Contains("reason"))
            {
                Say("Reason is the ship that sails the seas of ignorance, guided by the stars of wisdom.");
            }
            else if (speech.Contains("ignorance"))
            {
                Say("Ignorance is not a failing, but a beginning. Only the arrogant believe they have nothing to learn.");
            }
            else if (speech.Contains("harmony"))
            {
                Say("The universe is built on harmony—numbers, music, and the dance of planets.");
            }
			else if (speech.Contains("geometry"))
			{
				Say("Geometry is the poetry of the intellect. With compass and straightedge, we reveal the secret shapes of nature.");
			}
			else if (speech.Contains("pi"))
			{
				Say("Ah, pi! An eternal mystery—its digits stretch into infinity, just as human curiosity knows no bounds.");
			}
			else if (speech.Contains("mentor"))
			{
				Say("My father, Theon, was my first mentor. He taught me to question, to doubt, and to wonder.");
			}
			else if (speech.Contains("father") || speech.Contains("theon"))
			{
				Say("Theon of Alexandria nurtured both my mind and my courage. To him, I owe my devotion to learning.");
			}
			else if (speech.Contains("logic"))
			{
				Say("Logic is the straight road through the tangled forest of thought. Follow it, and you will seldom be lost.");
			}
			else if (speech.Contains("hypatia"))
			{
				Say("Yes, I am Hypatia. Some call me a heretic, others a sage. History will decide, but I serve only the truth.");
			}
			else if (speech.Contains("fate"))
			{
				Say("Fate is a word for what we do not yet understand. Knowledge is the torch that shrinks the realm of fate.");
			}
			else if (speech.Contains("invention"))
			{
				Say("Invention springs from the union of need and curiosity. Even the simplest tool can change a world.");
			}
			else if (speech.Contains("astronomy"))
			{
				Say("The heavens are a great book. In the turning of the spheres, we glimpse the order of all things.");
			}
			else if (speech.Contains("pagan"))
			{
				Say("I am called pagan, for I study the old gods and the world as it is. To me, all knowledge is sacred.");
			}
			else if (speech.Contains("scholar"))
			{
				Say("A scholar’s work is never done. To seek understanding is a task without end, but with many joys.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("A true legacy is not written in stone, but in the minds awakened by your teaching.");
			}
			else if (speech.Contains("library of alexandria"))
			{
				Say("The Library was a beacon for all nations. Here, scrolls and souls from every corner of the world met in search of understanding.");
			}
			else if (speech.Contains("christian") || speech.Contains("religion"))
			{
				Say("My city is divided by faiths, but I believe that wisdom and kindness can bridge any gulf.");
			}
			else if (speech.Contains("death"))
			{
				Say("Death is but a veil—truth and ideas, once sown, can never be unmade.");
			}
			else if (speech.Contains("woman") || speech.Contains("women"))
			{
				Say("Women can shape the world as surely as any man. Let neither tradition nor prejudice bind the mind.");
			}
			else if (speech.Contains("teacher"))
			{
				Say("A teacher is a lantern in the fog, lighting the way not for themselves, but for others.");
			}
			else if (speech.Contains("alchemy"))
			{
				Say("Alchemy is the mother of science—a blend of dreams, discipline, and the longing to transform both matter and mind.");
			}
			else if (speech.Contains("student"))
			{
				Say("Every true student is also a teacher. What you learn, share freely; what you know, question boldly.");
			}
			else if (speech.Contains("patience"))
			{
				Say("Patience is the key to understanding all things—stars, numbers, and people.");
			}
			else if (speech.Contains("light"))
			{
				Say("Light reveals both beauty and imperfection. Embrace both in yourself and others.");
			}
			else if (speech.Contains("books") || speech.Contains("book"))
			{
				Say("A book is a silent friend, a teacher that waits patiently to reveal its secrets.");
			}
			else if (speech.Contains("ancient"))
			{
				Say("The ancient world speaks to us still, if only we know how to listen.");
			}
			else if (speech.Contains("questions"))
			{
				Say("Never be ashamed of a question. Each is a key to a new chamber of knowledge.");
			}
			else if (speech.Contains("learning"))
			{
				Say("Learning is a lifelong voyage—its only shores are ignorance and arrogance, which we must always strive to avoid.");
			}			
            else if (speech.Contains("music"))
            {
                Say("Music and mathematics are sisters, both born from the search for order and beauty.");
            }
            else if (speech.Contains("order"))
            {
                Say("Order arises from understanding; chaos from neglect. To study is to bring order to your mind.");
            }
            else if (speech.Contains("chaos"))
            {
                Say("Even in chaos, patterns await discovery. Do not fear the unknown.");
            }
            else if (speech.Contains("fear"))
            {
                Say("Fear is the enemy of learning. A brave mind is the gateway to enlightenment.");
            }
            else if (speech.Contains("enlightenment"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True enlightenment cannot be rushed. Reflect, and return when you are ready to learn anew.");
                }
                else
                {
                    Say("You have followed the light of curiosity well. Accept this Treasure Chest of Greek History—may it inspire new questions and greater wisdom.");
                    from.AddToBackpack(new TreasureChestOfGreekHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your mind remain ever questioning, and your path lit by reason.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Alexandria, wisdom, philosophy, or the lost library of old.");
                }
            }

            base.OnSpeech(e);
        }

        public HypatiaOfAlexandria(Serial serial) : base(serial) { }

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
