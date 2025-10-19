using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Rajendra Laxmi")]
    public class RajendraLaxmi : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public RajendraLaxmi() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Rajendra Laxmi";
            Title = "Queen Regent of Gorkha";
            Female = true;
            Body = 0x191; // Human female body

            // Stats
            Str = 75;
            Dex = 80;
            Int = 120;
            Hits = 95;

            // Unique Appearance: Queenly attire with Nepali flair
            AddItem(new FancyDress() { Name = "Regal Sari of the Himalayas", Hue = 1153 });           // Soft blue
            AddItem(new FlowerGarland() { Name = "Marigold Garland of Kathmandu", Hue = 1272 });     // Orange-gold
            AddItem(new Cloak() { Name = "Royal Crimson Cloak", Hue = 2117 });                       // Royal red
            AddItem(new BodySash() { Name = "Sash of the Gorkha Court", Hue = 1342 });               // Deep purple
            AddItem(new Sandals() { Name = "Lotus Sandals", Hue = 2418 });                           // Light pink
            AddItem(new Circlet() { Name = "Jeweled Diadem of Unity", Hue = 2405 });                 // Gold

            // Weapon: Kukri
            AddItem(new Dagger() { Name = "Kukri of the Gorkha Guard", Hue = 1171 });                // Steel blue

            SpeechHue = 1150; // Distinctive speech color

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
                Say("I am Rajendra Laxmi, Regent of Gorkha and guardian of Nepal’s destiny.");
            }
            else if (speech.Contains("job"))
            {
                Say("I serve as queen regent, guiding Nepal through peril and promise alike.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body wearies, but my resolve is unbroken. The mountains teach us endurance.");
            }
            else if (speech.Contains("gorkha"))
            {
                Say("Gorkha is the cradle of unification—where dreams of a united Nepal were born.");
            }
            else if (speech.Contains("queen") || speech.Contains("regent"))
            {
                Say("My regency was earned through sacrifice and strength, in service of my people.");
            }
            else if (speech.Contains("nepal"))
            {
                Say("Nepal is a tapestry woven from many kingdoms—each with stories sung by the wind.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains") || speech.Contains("himalaya"))
            {
                Say("The Himalayas guard secrets older than memory. Their heights humble even the proudest rulers.");
            }
            else if (speech.Contains("history"))
            {
                Say("Our history is written not just by kings, but by those who endured in silence.");
            }
            else if (speech.Contains("kathmandu"))
            {
                Say("Kathmandu, the city of temples, has watched kingdoms rise and fall for a thousand years.");
            }
            else if (speech.Contains("temple") || speech.Contains("temples"))
            {
                Say("The temples of Nepal sing to gods of peace, war, and wisdom.");
            }
            else if (speech.Contains("gods") || speech.Contains("god"))
            {
                Say("Our gods dwell in stone, river, and forest. Offer respect, and perhaps they will guide you.");
            }
            else if (speech.Contains("unite") || speech.Contains("unification"))
            {
                Say("Unification brought strength, but required the courage to set aside old rivalries.");
            }
            else if (speech.Contains("king") || speech.Contains("prithvi"))
            {
                Say("King Prithvi Narayan Shah dreamed of a united land; I defended that dream.");
            }
            else if (speech.Contains("dream"))
            {
                Say("A dream alone is fragile. Only unity can shape a lasting future.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who walk together—like mountain climbers roped as one.");
            }
            else if (speech.Contains("river"))
            {
                Say("Rivers flow from the heights, binding valleys and villages, carrying whispers of the past.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("True legacy is found in the unity of people, not just the glory of rulers.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the jewel of queens and the blade of generals.");
            }
            else if (speech.Contains("kukri"))
            {
                Say("The kukri is the blade of Gorkha—symbol of both war and protection.");
            }
            else if (speech.Contains("strength"))
            {
                Say("Strength is measured not only in battle, but in patience and resolve.");
            }
            else if (speech.Contains("resolve"))
            {
                Say("Resolve turns storms into stepping stones.");
            }
            else if (speech.Contains("flower") || speech.Contains("garland") || speech.Contains("marigold"))
            {
                Say("Marigolds crown our festivals, bright as the dawn over Kathmandu.");
            }
            else if (speech.Contains("festival") || speech.Contains("festivals"))
            {
                Say("In festival, even rivals become family, bound by joy and ancient songs.");
            }
            else if (speech.Contains("song") || speech.Contains("music"))
            {
                Say("Songs carry our history across generations—sing, and you join a river that never dries.");
            }
			else if (speech.Contains("palace") || speech.Contains("court"))
			{
				Say("The palace is a place of splendor and of whispers—loyalty and betrayal both find shadows there.");
			}
			else if (speech.Contains("advice"))
			{
				Say("Listen twice as much as you speak, and keep your counsel as tightly as a mountain keeps its gold.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Enemies can become allies, if the thread of unity is woven with patience and wisdom.");
			}
			else if (speech.Contains("trust"))
			{
				Say("Trust is built like a stupa: stone by stone, over many seasons.");
			}
			else if (speech.Contains("secret") || speech.Contains("secrets"))
			{
				Say("Nepal holds secrets in her forests and peaks. The bravest seek them, but the wisest know when to wait.");
			}
			else if (speech.Contains("forest") || speech.Contains("jungles"))
			{
				Say("Our forests are ancient and alive—each tree a witness to history untold.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the choice to stand even when afraid.");
			}
			else if (speech.Contains("trade") || speech.Contains("merchant"))
			{
				Say("Caravans from Tibet to India bring silk, salt, and stories. Every market is a crossroads of worlds.");
			}
			else if (speech.Contains("tea"))
			{
				Say("Tea warms the spirit and soothes the mind. Share a cup, and you share peace.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is more difficult to win than war, yet its harvest feeds generations.");
			}
			else if (speech.Contains("storm") || speech.Contains("monsoon"))
			{
				Say("The monsoon brings both destruction and renewal—like change in the kingdom.");
			}
			else if (speech.Contains("prayer") || speech.Contains("prayers") || speech.Contains("stupa"))
			{
				Say("Prayer wheels spin, sending hopes to the heavens; stupas mark our devotion in stone.");
			}
			else if (speech.Contains("duty"))
			{
				Say("Duty is a chain of gold: beautiful, but heavy.");
			}
			else if (speech.Contains("beauty"))
			{
				Say("Beauty in Nepal lies in both the mountain’s majesty and the smallest flower at your feet.");
			}
			else if (speech.Contains("yeti"))
			{
				Say("Some say the yeti walks the hidden snows. True or not, every legend has roots in wonder.");
			}
			else if (speech.Contains("festival") || speech.Contains("dashain") || speech.Contains("tihar"))
			{
				Say("Dashain and Tihar fill our homes with light, music, and laughter. In unity, all festivals shine brighter.");
			}
			else if (speech.Contains("border") || speech.Contains("neighbor"))
			{
				Say("A wise kingdom respects its neighbors, for peace at the border is peace at home.");
			}
			else if (speech.Contains("memory") || speech.Contains("remembrance"))
			{
				Say("Remembrance binds the past to the present. Never forget the sacrifices of those who came before.");
			}
			else if (speech.Contains("journey") || speech.Contains("travel"))
			{
				Say("Every journey in Nepal, whether to valley or peak, is both an adventure and a lesson.");
			}
			else if (speech.Contains("legend") || speech.Contains("myth"))
			{
				Say("Legends grow in the shadow of every hill and within every family’s tales. Listen, and you may find your own.");
			}
			else if (speech.Contains("victory"))
			{
				Say("Victory won alone is easily lost. The greatest triumphs are those shared by many.");
			}
			else if (speech.Contains("poverty") || speech.Contains("wealth"))
			{
				Say("Wealth is not only gold, but kindness, wisdom, and the harmony of a united people.");
			}			
            else if (speech.Contains("family"))
            {
                Say("Family is the first kingdom; its strength outlasts stone.");
            }
            else if (speech.Contains("diadem") || speech.Contains("crown"))
            {
                Say("A crown is only as strong as the unity beneath it.");
            }
            // Secret reward keyword
            else if (speech.Contains("unity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True unity cannot be forced or repeated—return when time has healed the land.");
                }
                else
                {
                    Say("You understand: unity is our greatest treasure. Accept this chest, and carry Nepal’s hope with you.");
                    from.AddToBackpack(new TreasureChestOfNepal());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the mountains shelter your journey. Farewell.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Gorkha, unification, or the secrets hidden by the mountains.");
                }
            }

            base.OnSpeech(e);
        }

        public RajendraLaxmi(Serial serial) : base(serial) { }

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
