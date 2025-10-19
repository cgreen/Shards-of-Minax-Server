using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Amina")]
    public class QueenAmina : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenAmina() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Amina of Zazzau";
            Body = 0x191; // Human female body

            // Unique, themed outfit
            AddItem(new FancyShirt() { Name = "Royal Tunic of Zaria", Hue = 1165 });
            AddItem(new GuildedKilt() { Name = "Kilt of Conquest", Hue = 2118 });
            AddItem(new Cloak() { Name = "Cloak of the Hausa Plains", Hue = 2413 });
            AddItem(new Circlet() { Name = "Crown of Zazzau", Hue = 1367 });
            AddItem(new FurBoots() { Name = "Saharan Riding Boots", Hue = 2412 });
            AddItem(new BodySash() { Name = "Sash of Sovereignty", Hue = 2730 });
            AddItem(new PlateArms() { Name = "Armguards of the Kwararafa Wars", Hue = 1107 });
            
            // Weapon
            AddItem(new Scimitar() { Name = "Sword of Amina", Hue = 1177 });

            // Speech Hue (golden for royalty)
            SpeechHue = 2125;

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
                Say("I am Amina, Queen of Zazzau, daughter of Bakwa Turunku, ruler of the Hausa lands.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am both ruler and warrior, expanding the reach of Zaria’s walls and guiding my people.");
            }
            else if (speech.Contains("health"))
            {
                Say("The spirits of my ancestors keep me strong, as unyielding as the walls of Zaria.");
            }
            else if (speech.Contains("zazzau") || speech.Contains("zaria"))
            {
                Say("Zazzau, now called Zaria, is the heart of Hausa power. Our walls guard the secrets of the savannah.");
            }
            else if (speech.Contains("warrior"))
            {
                Say("I led armies across the savannah, riding at dawn with sword and spear, earning respect and fear.");
            }
            else if (speech.Contains("hausa"))
            {
                Say("The Hausa people are traders, builders, and storytellers, children of the vast northern plains.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen’s duty is to her people—whether in peace or war. My rule brought prosperity and legend.");
            }
            else if (speech.Contains("sword"))
            {
                Say("My sword was forged by the blacksmiths of Zaria, tempered with the promise of freedom.");
            }
            else if (speech.Contains("walls") || speech.Contains("wall"))
            {
                Say("I commanded the building of Zaria’s great walls, strong enough to turn away any foe.");
            }
            else if (speech.Contains("savannah"))
            {
                Say("The savannah is golden and wide, filled with the thunder of horses and the songs of griots.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Ancestors guide us. My mother, Bakwa Turunku, taught me to lead with both strength and wisdom.");
            }
            else if (speech.Contains("mother") || speech.Contains("bakwa"))
            {
                Say("Bakwa Turunku, my mother, founded Zazzau’s dynasty. Her legacy flows in every river and whisper.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy lives on in the tales of the Hausa, and in every stone of the city I loved.");
            }
            else if (speech.Contains("horse") || speech.Contains("horses"))
            {
                Say("Horses were my companions in war and peace. The swiftest steeds carried me to distant lands.");
            }
            else if (speech.Contains("conquest"))
            {
                Say("Through conquest, I expanded the borders of Zazzau, making it the envy of all Hausa kingdoms.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade brought riches to Zaria. Camels carried salt, cloth, and stories to our gates.");
            }
            else if (speech.Contains("camels"))
            {
                Say("Camels cross the deserts in endless caravans, bearing treasures from Kano to Timbuktu.");
            }
            else if (speech.Contains("caravan"))
            {
                Say("Caravans are lifeblood, linking our people to distant lands and ancient wisdom.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("True wisdom is knowing when to yield and when to stand firm, as the river does.");
            }
            else if (speech.Contains("river"))
            {
                Say("The Kaduna River nourishes our fields and whispers secrets to those who listen.");
            }
            else if (speech.Contains("secrets"))
            {
                Say("Every stone in Zaria holds a secret. The patient listener may uncover greatness—or danger.");
            }
            else if (speech.Contains("story") || speech.Contains("stories") || speech.Contains("legend"))
            {
                Say("Legends are woven into our blood. Ask the griots for stories of queens and warriors.");
            }
            else if (speech.Contains("griot") || speech.Contains("griots"))
            {
                Say("Griots are keepers of history. Their songs ensure that the memory of Zazzau never fades.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Songs celebrate harvest, mourn the fallen, and remind us that every ending births a new beginning.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold flows through the markets of Zaria, traded for wisdom and tales from the south.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is the fire in every warrior’s heart. It is tested not by victory, but by endurance.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Every victory comes at a cost. Remember the sacrifices of those who built these walls.");
            }
            else if (speech.Contains("destiny"))
            {
                Say("Destiny is not written in stone, but forged in action and faith.");
            }
			else if (speech.Contains("childhood") || speech.Contains("youth"))
			{
				Say("As a child, I listened to stories beneath the baobab trees and learned the ways of the horse and sword before I could write my own name.");
			}
			else if (speech.Contains("baobab"))
			{
				Say("The baobab tree stands as witness to many secrets and stories. Under its shade, history and future meet.");
			}
			else if (speech.Contains("father"))
			{
				Say("My father was a king of Zazzau, his wisdom matched only by my mother’s strength. From both, I learned what it means to rule.");
			}
			else if (speech.Contains("battle"))
			{
				Say("Battle is a dance of mind and spirit as much as blade. The courage of my warriors turned the tide in many campaigns.");
			}
			else if (speech.Contains("campaign") || speech.Contains("campaigns"))
			{
				Say("My campaigns reached as far as Kano and Katsina, bringing new lands and new stories to Zazzau.");
			}
			else if (speech.Contains("kano") || speech.Contains("katsina"))
			{
				Say("Kano and Katsina are powerful cities, rich with trade and culture. Their alliance—or rivalry—shapes the fate of the savannah.");
			}
			else if (speech.Contains("trade route") || speech.Contains("route"))
			{
				Say("The trade routes are rivers of gold and knowledge, stretching from the desert’s edge to the heart of the forest.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night on the savannah brings stars brighter than any torch. Listen closely, and you may hear ancestors in the wind.");
			}
			else if (speech.Contains("stars"))
			{
				Say("We navigated by the stars, each constellation a memory of those who came before us.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain brings life to the land, filling the rivers and blessing our crops. Without it, even the strongest city would wither.");
			}
			else if (speech.Contains("festival") || speech.Contains("festivals"))
			{
				Say("Festivals light the darkness, with music, dance, and stories passed from mouth to eager ear.");
			}
			else if (speech.Contains("music") || speech.Contains("dance"))
			{
				Say("Music and dance are the heartbeats of our people. They celebrate both harvest and victory.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("A good harvest feeds more than bellies—it feeds hope and the promise of another year.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who honor the past and dare to dream. What legacy will you leave, traveler?");
			}
			else if (speech.Contains("dream"))
			{
				Say("Every queen, every warrior, begins as a dreamer. The greatest journeys start with a single dream.");
			}
			else if (speech.Contains("wisdom") && !speech.Contains("river")) // avoid repeat
			{
				Say("Let your ears be your shield and your silence your sword. In listening, we find wisdom.");
			}
			else if (speech.Contains("shadow"))
			{
				Say("Even the greatest queen walks with her shadow. Do not fear yours; learn from it.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("My enemies taught me as much as my friends. Respect both, and you will not be surprised.");
			}
			else if (speech.Contains("courage") && !speech.Contains("fire")) // avoid repeat
			{
				Say("Courage means rising after each defeat, and standing alone if you must.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("True friends are rare as desert rain. Honor them, for they will share both your battles and your victories.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty cannot be bought. It is earned in the heat of battle and the quiet of trust.");
			}			
            else if (speech.Contains("freedom"))
            {
                Say("Freedom must be earned, defended, and cherished, for it is more precious than gold.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert teaches patience, for even the harshest land yields to rain and hope.");
            }
            else if (speech.Contains("market") || speech.Contains("markets"))
            {
                Say("Zaria’s markets brim with voices, laughter, and goods from a hundred lands.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("gates"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The gates of Zaria do not open for the impatient. Return when the sun has climbed higher.");
                }
                else
                {
                    Say("You have shown the curiosity of a true explorer. Accept this Treasure Chest of Nigerian History, may it inspire your own saga.");
                    from.AddToBackpack(new TreasureChestOfNigerianHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the ancestors guide your steps, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Zazzau, conquest, ancestors, or the secrets of Zaria’s gates.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenAmina(Serial serial) : base(serial) { }

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
