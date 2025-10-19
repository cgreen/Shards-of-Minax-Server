using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Abylai Khan")]
    public class AbylaiKhan : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AbylaiKhan() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Abylai Khan";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 80;
            Int = 120;
            Hits = 100;

            // Unique Appearance: Kazakh Khan
            AddItem(new ElvenShirt() { Name = "Chapan of the Endless Steppe", Hue = 2125 });
            AddItem(new GuildedKilt() { Name = "Belt of the Three Juzes", Hue = 1751 });
            AddItem(new Cloak() { Name = "Cloak of the Blue Horde", Hue = 2305 });
            AddItem(new Kasa() { Name = "Golden Eagle Headdress", Hue = 1166 });
            AddItem(new FurBoots() { Name = "Boots of the Wild Horses", Hue = 1509 });
            AddItem(new BodySash() { Name = "Sash of Unity", Hue = 1357 });
            AddItem(new Scepter() { Name = "Scepter of the Steppe", Hue = 1173 });

            SpeechHue = 2211;

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
                Say("I am Abylai Khan, who led the Kazakh through storm and shadow across the endless steppe.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am khan, a shepherd of tribes, a rider between empires, keeper of the steppe’s ancient ways.");
            }
            else if (speech.Contains("health"))
            {
                Say("A true khan’s strength is in his people, not just his bones. I stand as strong as the wind on the grasslands.");
            }
            else if (speech.Contains("kazakh"))
            {
                Say("The Kazakh are sons and daughters of the steppe—swift as horses, fierce as eagles, wise as the old mountains.");
            }
            else if (speech.Contains("steppe"))
            {
                Say("The steppe is my cradle and battlefield. Its winds carry both news and memory. Have you seen how the grass whispers?");
            }
            else if (speech.Contains("juz") || speech.Contains("juzes"))
            {
                Say("The three Juzes—Great, Middle, and Little—are the lifeblood of our nation. United, we cannot fall.");
            }
            else if (speech.Contains("eagle") || speech.Contains("golden eagle"))
            {
                Say("The golden eagle is the spirit of our people—free, proud, and sharp-eyed. Watch its flight, and learn.");
            }
            else if (speech.Contains("russia") || speech.Contains("russian"))
            {
                Say("The Russians came with gifts in one hand, chains in the other. A khan must see both, and choose wisely.");
            }
            else if (speech.Contains("dzungar") || speech.Contains("dzungars"))
            {
                Say("The Dzungars threatened our land like thunderclouds. Only unity and cunning could turn them aside.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is the strongest bow—when all arrows fly together, no enemy can break us.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Our mountains hold stories of heroes and spirits. Ask the wind, and it will answer in song.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("A song can do what swords cannot—carry hope across distance and time. Listen for the dombra’s voice.");
            }
            else if (speech.Contains("dombra"))
            {
                Say("The dombra’s strings sing of victories and laments, teaching the young and honoring the old.");
            }
            else if (speech.Contains("horses") || speech.Contains("horse"))
            {
                Say("A Kazakh’s heart belongs to his horse. Together, they roam farther than any boundary.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Every campfire kindles a legend. Some say even the tulpar still rides the night sky...");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is like a river—always flowing, sometimes deep, sometimes swift. Never let yours run dry.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires rise like tents in the wind—and sometimes vanish just as quickly. The land endures.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("We walk in the hoofprints of ancestors. Their courage and mistakes are our inheritance.");
            }
            else if (speech.Contains("fate"))
            {
                Say("The steppe teaches patience. Fate comes to every yurt, whether invited or not.");
            }
            else if (speech.Contains("yurt"))
            {
                Say("A yurt is more than shelter—it is a circle of family and fire, where stories live and grow.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future rides on swift hooves. Those who do not look ahead are left behind in dust.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade brings silk, salt, and stories. A wise khan listens before he bargains.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of the steppe walk beside us: in eagle’s shadow, in wolf’s howl, in whispering grass.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fire warms, but also warns. Every council, every oath, every legend begins with a flame.");
            }
			else if (speech.Contains("nomad") || speech.Contains("nomads"))
			{
				Say("A nomad’s strength is freedom. We move with the seasons, always at home under the wide sky.");
			}
			else if (speech.Contains("sky"))
			{
				Say("The sky above the steppe is our only roof. It sees all, forgives much, forgets nothing.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind is an old friend—sometimes gentle, sometimes fierce. It carries stories across the grasslands.");
			}
			else if (speech.Contains("herd") || speech.Contains("herds") || speech.Contains("livestock"))
			{
				Say("Our wealth is measured in herds. Horses, sheep, and camels are not just property, but family and fortune.");
			}
			else if (speech.Contains("camel") || speech.Contains("camels"))
			{
				Say("Camels cross the desert like ships on a sea of sand, carrying burdens and secrets alike.");
			}
			else if (speech.Contains("wolf") || speech.Contains("wolves"))
			{
				Say("The wolf is both rival and teacher—fierce, clever, and loyal to its own.");
			}
			else if (speech.Contains("hospitality"))
			{
				Say("A guest brings blessings. Our yurt is always open to the weary traveler, and our fire always ready to warm cold hands.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is like still water: easy to disturb, but precious when found. Even among rivals, peace is worth seeking.");
			}
			else if (speech.Contains("diplomacy"))
			{
				Say("A sharp mind achieves what a sharp blade cannot. Words can shape destinies as surely as arrows.");
			}
			else if (speech.Contains("proverb") || speech.Contains("sayings"))
			{
				Say("Our people say, 'One does not look for fish in a tree, nor a bird in the sea.' Wisdom is knowing where to seek answers.");
			}
			else if (speech.Contains("ancestor"))
			{
				Say("We pour the first cup of kumis to honor our ancestors. They ride with us in memory and in dream.");
			}
			else if (speech.Contains("kumis"))
			{
				Say("Kumis, the milk of mares, gives strength to riders and song to the old. Drink, and taste the steppe itself.");
			}
			else if (speech.Contains("journey") || speech.Contains("travel"))
			{
				Say("A journey across the steppe begins with a single hoofbeat. Every rider must trust their mount—and their luck.");
			}
			else if (speech.Contains("luck"))
			{
				Say("Luck is like the grass: sometimes green, sometimes dry. Wise is the one who prepares for both.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("Treat your enemy with caution, but never with hate. Even an enemy may one day become a guest beneath your roof.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are our hope and our future. Teach them well, and the land will prosper for another hundred years.");
			}
			else if (speech.Contains("mother"))
			{
				Say("The mother is the heart of the yurt. Her wisdom, patience, and song keep the family strong.");
			}
			else if (speech.Contains("river"))
			{
				Say("Rivers carve the steppe as surely as history carves a people. Their waters remember every hoof and wheel.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("At night, the stars are our map and our memory. Each one a hero, a hope, or a warning.");
			}
			else if (speech.Contains("war"))
			{
				Say("War is bitter, but sometimes it is the only path. May we always seek peace first, and ride to war last.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A true friend is a rare treasure. Guard them as you would your honor, or your best horse.");
			}
			else if (speech.Contains("leader") || speech.Contains("leadership"))
			{
				Say("A khan leads by example and by ear. Listen to your people, and they will carry you farther than any steed.");
			}			
            else if (speech.Contains("cunning"))
            {
                Say("Cunning outlasts the sword. Even a lone wolf may bring down a stag with patience and wit.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                Say("Do not ask for rewards—seek knowledge, and perhaps the land will remember you.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("tulpar"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A true tulpar does not come when called twice in one day. Return when the sun is lower.");
                }
                else
                {
                    Say("You know the legend! Accept this Treasure Chest of Kazakhstan, and may your travels be swift as the tulpar.");
                    from.AddToBackpack(new TreasureChestOfKazakhstan());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path be clear, and your heart steadfast, like the riders of the steppe.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of the steppe, the Juzes, the golden eagle, or the legend of the tulpar.");
                }
            }

            base.OnSpeech(e);
        }

        public AbylaiKhan(Serial serial) : base(serial) { }

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
