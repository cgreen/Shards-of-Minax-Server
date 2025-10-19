using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Chief Tegwa")]
    public class ChiefTegwa : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ChiefTegwa() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Chief Tegwa the Storm Watcher";
            Title = "Kalinago Elder of Kairi";
            Body = 0x190; // Human male

            // Unique Appearance: Kalinago Chief of Dominica
            AddItem(new ElvenShirt() { Name = "Woven Shirt of the Kairi", Hue = 1801 });
            AddItem(new FancyKilt() { Name = "Ocean-Dyed Kilt of the Kalinago", Hue = 1374 });
            AddItem(new FlowerGarland() { Name = "Garland of Rainforest Spirits", Hue = 1207 });
            AddItem(new FurSarong() { Name = "Sarong of the Emerald Isle", Hue = 2008 });
            AddItem(new WoodlandBelt() { Name = "Belt of the Tamarin", Hue = 2522 });
            AddItem(new WoodlandGloves() { Name = "Gloves of Bark and River Clay", Hue = 1511 });
            AddItem(new FurBoots() { Name = "Boots of the Sisserou Parrot", Hue = 1172 });

            // Weapon: Unique Staff
            AddItem(new QuarterStaff() { Name = "Stormwatcher’s Staff", Hue = 2066 });

            // Speech Hue
            SpeechHue = 2215;

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
                Say("I am Tegwa, called Storm Watcher—elder of the Kalinago, child of Kairi’s emerald heart.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I watched the storms and guarded the secrets of river and reef. Now, I share stories with those who listen.");
            }
            else if (speech.Contains("health"))
            {
                Say("These bones are old, but the river’s song keeps my spirit strong.");
            }
            else if (speech.Contains("kalinago"))
            {
                Say("The Kalinago are the people of Kairi, the first guardians of the land you call Dominica.");
            }
            else if (speech.Contains("kairi") || speech.Contains("dominica"))
            {
                Say("Kairi—‘island of many rivers’—is our home. Dominica, she is named now, but her spirit is unchanged.");
            }
            else if (speech.Contains("storm"))
            {
                Say("Storms are both danger and blessing. They shape the land and whisper secrets to those who listen.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Our spirits dwell in river, mountain, and tree. Listen, and they may guide you to hidden paths.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Rivers are the veins of Kairi. Each has a name, each a story—Roseau, Layou, and the boiling valley’s stream.");
            }
            else if (speech.Contains("boiling") || speech.Contains("valley"))
            {
                Say("The Valley of Desolation and the Boiling Lake are places of power, where earth and spirit meet.");
            }
            else if (speech.Contains("lake"))
            {
                Say("The Boiling Lake hides many mysteries. Some say it is the breath of an ancient sleeping god.");
            }
            else if (speech.Contains("parrot") || speech.Contains("sisserou"))
            {
                Say("The Sisserou Parrot soars above the forest, a guardian of our dreams. Its feathers are said to bring wisdom.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is earned with patience, as rivers carve valleys through stone. Seek, and you may find it.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Many secrets slumber in the rainforest and the ruins of stone circles. Only the persistent uncover them.");
            }
            else if (speech.Contains("circle") || speech.Contains("circles") || speech.Contains("ruin"))
            {
                Say("Stone circles mark old meeting places, where stories were traded for song and silence.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs recall storms and sunrise, heroes and heartbreak. The wind carries them still.");
            }
            else if (speech.Contains("wind"))
            {
                Say("The wind remembers all things, if you have the patience to listen.");
            }
            else if (speech.Contains("colonial") || speech.Contains("french") || speech.Contains("english"))
            {
                Say("Many came to claim Kairi—French, English, all seeking riches. But the land’s true treasures are hidden.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("The greatest treasure is the spirit of Kairi herself—her resilience, her rivers, her unbroken will.");
            }
            else if (speech.Contains("resilience"))
            {
                Say("Resilience is the root that clings even as the storm tears at the earth. It is our legacy.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My people’s legacy lives in the names of rivers, the colors of parrots, the stories whispered by waterfalls.");
            }
            else if (speech.Contains("waterfall") || speech.Contains("falls"))
            {
                Say("From Trafalgar to Emerald Pool, waterfalls are the laughter of the island. They cleanse the old and renew the new.");
            }
            else if (speech.Contains("renewal") || speech.Contains("renew"))
            {
                Say("Renewal comes to all things—after storm, calm; after loss, hope. This is Kairi’s gift.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is a seed carried by every wind and planted by every hand.");
            }
			else if (speech.Contains("canoe"))
			{
				Say("A Kalinago canoe is shaped by hand and spirit, gliding silently along the coast. We learned the sea’s moods by heart.");
			}
			else if (speech.Contains("sea") || speech.Contains("ocean"))
			{
				Say("The sea is both shield and highway—she brings storms and fish, traders and trouble alike.");
			}
			else if (speech.Contains("fisher") || speech.Contains("fish"))
			{
				Say("Fish sustain us; river and reef are generous to those who respect their bounty.");
			}
			else if (speech.Contains("bounty"))
			{
				Say("True bounty lies in sharing—the land provides, but hoarding brings misfortune.");
			}
			else if (speech.Contains("misfortune"))
			{
				Say("When misfortune comes, we gather beneath the breadfruit trees and share stories until the shadows pass.");
			}
			else if (speech.Contains("breadfruit"))
			{
				Say("Breadfruit was a gift from distant islands, a symbol of peace and plenty among our people.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is the dream between storms. Sometimes, the hardest battles are fought within the heart.");
			}
			else if (speech.Contains("battle") || speech.Contains("war"))
			{
				Say("The Kalinago fought bravely to protect Kairi. Our spears and courage held back invaders for generations.");
			}
			else if (speech.Contains("spear") || speech.Contains("weapon"))
			{
				Say("A spear is more than wood and stone—it carries the hopes of a people. Use weapons with honor, never cruelty.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor walks beside us like a shadow. It is lost quickly, and regained only through great deeds.");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("Shadows lengthen at dusk, reminding us that every day ends but every story endures.");
			}
			else if (speech.Contains("dusk") || speech.Contains("night"))
			{
				Say("Night brings rest and dreams. In dreams, we may visit those who walked before us.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("Our ancestors guide us in quiet ways—through dreams, signs, and the shape of the wind.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are the spirit’s way of traveling. Some say the Boiling Lake is the doorway between worlds.");
			}
			else if (speech.Contains("herb") || speech.Contains("medicine"))
			{
				Say("Rainforest herbs cure body and mind. Knowledge of medicine is a treasure guarded by our elders.");
			}
			else if (speech.Contains("elder") || speech.Contains("elders"))
			{
				Say("Elders remember the world before roads and fences. Their stories hold the map to hidden wisdom.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom listens more than it speaks. Listen to the rivers, and they will teach you.");
			}
			else if (speech.Contains("map"))
			{
				Say("Not all maps are made of parchment. Some are etched in memory and marked by stones along the old paths.");
			}
			else if (speech.Contains("path") || speech.Contains("paths"))
			{
				Say("The jungle is a maze to strangers, but every root and stone remembers those who came before.");
			}
			else if (speech.Contains("stranger") || speech.Contains("strangers"))
			{
				Say("We welcome strangers with caution. Some bring friendship, others seek only gold and glory.");
			}
			else if (speech.Contains("gold") || speech.Contains("glory"))
			{
				Say("Gold glitters, but it cannot buy respect from the land. Seek glory in kindness and courage instead.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the will to stand firm when storms threaten.");
			}
			else if (speech.Contains("storm"))
			{
				Say("To the Kalinago, each storm is a lesson—bend like the bamboo, but do not break.");
			}			
            else if (speech.Contains("hand") || speech.Contains("hands"))
            {
                Say("With wise hands, even a single shell can become a story—or a key.");
            }
            else if (speech.Contains("key"))
            {
                Say("Many seek a key, but forget the lock. The mind is both, for those who would open the way.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("persistence"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The river flows in its own time, friend. Return when the waters run anew.");
                }
                else
                {
                    Say("Persistence honors both ancestor and land. Accept this Treasure Chest of Dominica—may you use it with wisdom.");
                    from.AddToBackpack(new TreasureChestOfDominica());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go in peace. Let the rivers guide your steps and the wind carry your stories.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Boiling Lake, the Sisserou Parrot, or the stone circles of Kairi.");
                }
            }

            base.OnSpeech(e);
        }

        public ChiefTegwa(Serial serial) : base(serial) { }

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
