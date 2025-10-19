using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Tin Hinan")]
    public class TinHinan : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TinHinan() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Tin Hinan";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 70;
            Int = 110;
            Hits = 70;

            // Unique Appearance: Berber Queen
            AddItem(new FlowerGarland() { Name = "Crown of the Sahara", Hue = 2966 });
            AddItem(new Robe() { Name = "Veil of Tassili Dunes", Hue = 2407 });
            AddItem(new BodySash() { Name = "Berber Wisdom Sash", Hue = 1358 });
            AddItem(new FancyKilt() { Name = "Skirt of Tamanrasset", Hue = 1196 });
            AddItem(new Sandals() { Name = "Nomad’s Windwalkers", Hue = 2105 });
            AddItem(new Cloak() { Name = "Cloak of the Desert Moon", Hue = 2213 });

            // Weapon: Scepter
            AddItem(new BladedStaff() { Name = "Scepter of Tin Hinan", Hue = 1150 });

            // Speech Hue
            SpeechHue = 2071;

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
                Say("I am Tin Hinan, the Queen of the Hoggar, mother to the Tuareg, spirit of the desert sands.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a matriarch, a storyteller, and a guide to my people—keeper of Berber tradition.");
            }
            else if (speech.Contains("health"))
            {
                Say("The desert grants me strength. Though the wind may wear the stone, my spirit endures.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen’s crown is light as a feather, but her responsibilities weigh more than the Sahara itself.");
            }
            else if (speech.Contains("berber"))
            {
                Say("Berbers are the people of the wind and the stars. Our history is written in stone and sung by the fire.");
            }
            else if (speech.Contains("tuareg"))
            {
                Say("The Tuareg, my children, are blue-clad nomads—guardians of the desert and keepers of ancient wisdom.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The Sahara is both cradle and crucible. Its beauty hides secrets older than kings.");
            }
            else if (speech.Contains("hoggar"))
            {
                Say("The Hoggar mountains are my home, a place of hidden oases, ancient tombs, and starlit silence.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is a journey, not a destination. It is found in listening to the desert and to each other.");
            }
            else if (speech.Contains("scepter"))
            {
                Say("This scepter is carved from acacia wood and set with desert amber—a symbol of guidance and rule.");
            }
            else if (speech.Contains("tomb"))
            {
                Say("My tomb lies among the sands, filled with gifts: jewelry, writing, and vessels of gold.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Many have searched for the Treasure of Ancient Libya—its true worth is the knowledge it holds.");
            }
            else if (speech.Contains("libya"))
            {
                Say("Libya’s lands stretch from desert dunes to Mediterranean shores, home to empires and tribes alike.");
            }
            else if (speech.Contains("story"))
            {
                Say("Every story is a desert journey: hardships, oases, and the promise of discovery.");
            }
            else if (speech.Contains("journey"))
            {
                Say("My own journey began in Tafilalt, far across the sands, ending as a queen of the Tuareg.");
            }
            else if (speech.Contains("tafilalt"))
            {
                Say("Tafilalt is a lush valley—my birthplace, before the winds of fate led me to the Hoggar.");
            }
            else if (speech.Contains("blue"))
            {
                Say("We Tuareg are called the 'Blue People' for our indigo robes, stained by the desert sun.");
            }
            else if (speech.Contains("indigo"))
            {
                Say("Indigo is the color of the night sky and the symbol of Tuareg freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the greatest treasure of the desert: to wander, to dream, to choose one’s path.");
            }
            else if (speech.Contains("oasis"))
            {
                Say("An oasis is life in the desert—shelter, water, and rest for weary travelers.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy lives on in my daughters, my stories, and in every desert traveler who seeks wisdom.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, child of the sands. True treasure cannot be claimed so often—return when the sun has moved.");
                }
                else
                {
                    Say("You have followed the winds of story to their end. Take this Treasure Chest of Ancient Libya, and remember the lessons of the desert.");
                    from.AddToBackpack(new TreasureChestOfAncientLibya());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path be cool and your waters clear, wanderer.");
            }
			else if (speech.Contains("stars"))
			{
				Say("The stars are our guides. Under their gaze, every dune is a path and every night a new beginning.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon is the lamp of the desert. Its silver light reveals secrets and soothes the restless soul.");
			}
			else if (speech.Contains("caravan"))
			{
				Say("Caravans cross the Sahara like beads on a string, carrying salt, gold, and stories between far kingdoms.");
			}
			else if (speech.Contains("salt"))
			{
				Say("Salt is as precious as gold among nomads. We trade it across the sands, and it keeps our bodies strong.");
			}
			else if (speech.Contains("sandstorm"))
			{
				Say("A sandstorm is a test of patience and faith. To survive, one must trust the desert and know when to seek shelter.");
			}
			else if (speech.Contains("music"))
			{
				Say("Desert music is played on the imzad—a single-stringed instrument whose song carries hope and memory.");
			}
			else if (speech.Contains("imzad"))
			{
				Say("The imzad is sacred to Tuareg women. Its music heals the weary heart and blesses our ceremonies.");
			}
			else if (speech.Contains("marriage"))
			{
				Say("Marriage among the Tuareg is a union of families, celebrated with feasts, poetry, and indigo-dyed veils.");
			}
			else if (speech.Contains("veil"))
			{
				Say("The veil is our symbol—protection from sun and wind, but also a sign of respect and tradition.");
			}
			else if (speech.Contains("camel"))
			{
				Say("Camels are ships of the desert. Without them, no journey would be possible, and no trade could flourish.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend is worth more than a chest of jewels. In the desert, friendship is survival.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("Enemies teach us caution and wisdom. Even the harshest rival may one day become an ally.");
			}
			else if (speech.Contains("water"))
			{
				Say("Water is life. Its scarcity teaches us gratitude and sharing, for the well belongs to all.");
			}
			else if (speech.Contains("legend"))
			{
				Say("Legends grow like desert flowers—rare, beautiful, and born from hardship and hope.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is the green sprout that survives the driest season. It gives meaning to every journey.");
			}
			else if (speech.Contains("jewel") || speech.Contains("jewelry"))
			{
				Say("Jewelry is more than adornment; each piece tells a story, passed from mother to daughter.");
			}
			else if (speech.Contains("daughter") || speech.Contains("daughters"))
			{
				Say("My daughters and their daughters still carry my wisdom in the blue veils and their unbroken spirit.");
			}			
            else
            {
                // Encourage further exploration if no keywords match
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Tuareg, tomb, treasure, or the blue people of the Sahara.");
                }
            }

            base.OnSpeech(e);
        }

        public TinHinan(Serial serial) : base(serial) { }

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
