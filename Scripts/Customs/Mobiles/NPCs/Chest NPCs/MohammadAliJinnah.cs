using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mohammad Ali Jinnah")]
    public class MohammadAliJinnah : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MohammadAliJinnah() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mohammad Ali Jinnah";
            Body = 0x190; // Human male body

            // Stats
            Str = 70;
            Dex = 60;
            Int = 120;
            Hits = 80;

            // Unique Appearance: Founder of Pakistan
            AddItem(new FormalShirt() { Name = "Sherwani of Destiny", Hue = 2100 });
            AddItem(new LongPants() { Name = "Midnight Assembly Trousers", Hue = 1150 });
            AddItem(new Cloak() { Name = "Cloak of Crescent Resolve", Hue = 2113 });
            AddItem(new Kasa() { Name = "Jinnah's Karakul Cap", Hue = 1109 });
            AddItem(new Shoes() { Name = "Stride of Freedom", Hue = 2401 });
            AddItem(new BodySash() { Name = "Sash of Unity", Hue = 1167 });

            // Weapon: Walking Cane (stylish, statesmanly)
            AddItem(new BlackStaff() { Name = "Cane of Constitutional Wisdom", Hue = 1175 });

            // Speech Hue (distinguished)
            SpeechHue = 2066;

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
                Say("I am Mohammad Ali Jinnah, known as the Quaid-e-Azam, the founder of Pakistan.");
            }
            else if (speech.Contains("job"))
            {
                Say("I served as a lawyer, a statesman, and the tireless architect of a new nation.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though my body tired in my final years, my resolve for unity and justice never wavered.");
            }
            else if (speech.Contains("pakistan"))
            {
                Say("Pakistan is the land of the pure, envisioned as a home for those seeking freedom, dignity, and hope.");
            }
            else if (speech.Contains("quaid") || speech.Contains("azim"))
            {
                Say("Quaid-e-Azam means 'Great Leader.' It is a name given to me by those who believed in our cause.");
            }
            else if (speech.Contains("freedom") || speech.Contains("independence"))
            {
                Say("Freedom was hard-won, forged through patience and the will of millions united in purpose.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity, faith, and discipline are the pillars on which a nation stands strong.");
            }
            else if (speech.Contains("lawyer") || speech.Contains("barrister"))
            {
                Say("As a barrister in London and Bombay, I learned that words can be sharper than swords.");
            }
            else if (speech.Contains("muslim") || speech.Contains("league"))
            {
                Say("The All-India Muslim League was our instrument of negotiation and resistance.");
            }
            else if (speech.Contains("british") || speech.Contains("raj"))
            {
                Say("The British Raj shaped destinies, but it could not break the spirit of those who dreamed of self-rule.");
            }
            else if (speech.Contains("karachi"))
            {
                Say("Karachi, the city of my birth and rest, is the beating heart of progress.");
            }
            else if (speech.Contains("vision"))
            {
                Say("My vision was of a nation where justice, tolerance, and compassion would flourish.");
            }
            else if (speech.Contains("struggle"))
            {
                Say("The struggle for independence demanded intellect, diplomacy, and at times, great sacrifice.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith is not mere belief, but the courage to act when hope is faint.");
            }
            else if (speech.Contains("discipline"))
            {
                Say("Discipline transforms dreams into reality. It binds the scattered into the unbreakable.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the flame that guided us through shadowed times.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future of a nation depends upon the character of its youth and the wisdom of its elders.");
            }
            else if (speech.Contains("language"))
            {
                Say("Language is the soul of a people. Urdu and many tongues form the melody of Pakistan.");
            }
            else if (speech.Contains("flag"))
            {
                Say("The green and white flag stands for faith, unity, and the hopes of countless generations.");
            }
            else if (speech.Contains("karakul") || speech.Contains("cap"))
            {
                Say("The Karakul cap is a symbol of dignity and resolve—may you wear yours with honor.");
            }
            else if (speech.Contains("leader"))
            {
                Say("A true leader serves the people, not power.");
            }
            else if (speech.Contains("principles"))
            {
                Say("Principles are the stars by which we navigate storms. Without them, even victory is hollow.");
            }
            else if (speech.Contains("partition"))
            {
                Say("Partition was a moment of both triumph and sorrow. We gained a home, but hearts were divided.");
            }
            else if (speech.Contains("law"))
            {
                Say("Law is the safeguard of liberty, the shield of the weak.");
            }
            else if (speech.Contains("shield"))
            {
                Say("Shields may crack, but the resolve of the righteous endures.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice must be blind to power, but open to truth.");
            }
            else if (speech.Contains("truth"))
            {
                Say("Truth is sometimes bitter, but it alone frees us from the shackles of fear.");
            }
            else if (speech.Contains("shackles"))
            {
                Say("We broke the shackles of colonialism through unity and purpose.");
            }
            else if (speech.Contains("purpose"))
            {
                Say("Purpose is the lodestar of the restless. It lifts ordinary people to greatness.");
            }
            else if (speech.Contains("greatness"))
            {
                Say("Greatness is measured not by power, but by service to others.");
            }
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the triumph over it. It carried us through storms and uncertainty.");
			}
			else if (speech.Contains("sacrifice"))
			{
				Say("Every great journey demands sacrifice—of comfort, sometimes even of hope. But sacrifice gives meaning to freedom.");
			}
			else if (speech.Contains("youth"))
			{
				Say("The youth are the architects of tomorrow. I place my trust in their energy and ideals.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams are the seeds of reality. A nation is born first in the mind and heart.");
			}
			else if (speech.Contains("urdu"))
			{
				Say("Urdu is a language of poetry and passion, binding many together with its melody.");
			}
			else if (speech.Contains("poetry"))
			{
				Say("Poetry gives voice to the soul of a people. Listen to Iqbal’s verses and you’ll hear the heartbeat of Pakistan.");
			}
			else if (speech.Contains("iqbal"))
			{
				Say("Allama Iqbal envisioned a land where the spirit was free and the mind was sharp. His philosophy inspired millions.");
			}
			else if (speech.Contains("women") || speech.Contains("female"))
			{
				Say("The women of Pakistan stood shoulder to shoulder in our struggle. Fatima Jinnah was a beacon of resilience.");
			}
			else if (speech.Contains("fatima"))
			{
				Say("My sister, Fatima Jinnah, was my confidant and advisor—a woman of wisdom, courage, and unyielding will.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("From the peaks of Karakoram to the hills of Margalla, the mountains are silent witnesses to our story.");
			}
			else if (speech.Contains("river") || speech.Contains("indus"))
			{
				Say("The Indus River is the lifeblood of our land, a symbol of the ancient and the eternal.");
			}
			else if (speech.Contains("flag"))
			{
				Say("The flag’s green is for faith, the white for minorities, together waving the promise of unity.");
			}
			else if (speech.Contains("culture"))
			{
				Say("Our culture is a tapestry woven with the threads of many peoples—Punjabi, Sindhi, Pashtun, Baloch, and more.");
			}
			else if (speech.Contains("punjab") || speech.Contains("sindh") || speech.Contains("baloch") || speech.Contains("khyber"))
			{
				Say("Each province brings its own color and character to Pakistan. Diversity is our strength.");
			}
			else if (speech.Contains("partition"))
			{
				Say("Partition was a line across a map, but its effects ran through hearts and homes. We must heal and look ahead.");
			}
			else if (speech.Contains("advice"))
			{
				Say("Build your character with honesty and discipline. Serve the nation, not just yourself.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family shapes one’s earliest values. My family’s support was the quiet strength behind my public resolve.");
			}
			else if (speech.Contains("challenge") || speech.Contains("adversity"))
			{
				Say("Adversity reveals true character. We faced many, and withstood them with unity and hope.");
			}
			else if (speech.Contains("islam"))
			{
				Say("Islam teaches justice, tolerance, and compassion—principles vital to any thriving society.");
			}
			else if (speech.Contains("compassion"))
			{
				Say("A nation’s greatness is measured by its compassion for the weak and vulnerable.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("Legacy is not of monuments, but of principles and service left to guide those who come after.");
			}
			else if (speech.Contains("education"))
			{
				Say("Education lights the path from ignorance to enlightenment. Seek knowledge—it is your greatest asset.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the highest aspiration of any nation. We must strive for it within and beyond our borders.");
			}
			else if (speech.Contains("border") || speech.Contains("neighbor"))
			{
				Say("Neighbors must learn to live together in peace. True strength lies not in conflict, but in understanding.");
			}
			else if (speech.Contains("city"))
			{
				Say("Our cities, from Lahore to Peshawar, pulse with history and possibility.");
			}
			else if (speech.Contains("inspiration"))
			{
				Say("Find inspiration in every struggle, every victory, every defeat. Each holds a lesson.");
			}
			else if (speech.Contains("lesson"))
			{
				Say("History teaches, if only we listen. Let the past guide your steps, not weigh them down.");
			}			
            else if (speech.Contains("constitution"))
            {
                Say("A nation's constitution is its promise to the future. Guard it well.");
            }
            else if (speech.Contains("promise"))
            {
                Say("A promise made to a nation is a bond unbroken by death.");
            }
            else if (speech.Contains("death"))
            {
                Say("Death is certain, but the ideals we nurture live beyond us.");
            }
            else if (speech.Contains("resolve"))
            {
                Say("Resolve is born in the heart, tested in the world, and remembered by history.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("melody"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Melodies, like nations, are not repeated so quickly. Return later to receive your due.");
                }
                else
                {
                    Say("To hear the melody of Pakistan is to hear hope itself. Take this Treasure Chest of Pakistan, and may your own song inspire generations.");
                    from.AddToBackpack(new TreasureChestOfPakistan());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go forth with unity, faith, and discipline as your companions.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of vision, unity, law, or the green and white flag.");
                }
            }

            base.OnSpeech(e);
        }

        public MohammadAliJinnah(Serial serial) : base(serial) { }

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
