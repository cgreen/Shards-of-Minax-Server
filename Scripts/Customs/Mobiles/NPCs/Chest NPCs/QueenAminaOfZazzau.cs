using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Amina")]
    public class QueenAminaOfZazzau : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenAminaOfZazzau() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Amina of Zazzau";
            Title = "the Warrior Queen";
            Body = 0x191; // Human female body

            // Stats
            Str = 85;
            Dex = 90;
            Int = 120;
            Hits = 80;

            // Unique Appearance: Regal and Battle-Ready Hausa Queen
            AddItem(new FancyShirt() { Name = "Royal Tunic of Zazzau", Hue = 1358 });
            AddItem(new GuildedKilt() { Name = "Battle Kilt of the Hausa", Hue = 2220 });
            AddItem(new ElvenBoots() { Name = "Sandwalker's Boots", Hue = 2415 });
            AddItem(new FeatheredHat() { Name = "Crown of the Sahel", Hue = 2727 });
            AddItem(new BodySash() { Name = "Sash of Conquest", Hue = 2122 });
            AddItem(new Cloak() { Name = "Cloak of Kano Markets", Hue = 1172 });

            // Weapon: Scimitar
            AddItem(new Scimitar() { Name = "Blade of Zaria", Hue = 1157 });

            // Speech Hue
            SpeechHue = 2114;

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
                Say("I am Amina, daughter of Bakwa Turunku—queen, warrior, and shaper of empires.");
            }
            else if (speech.Contains("job"))
            {
                Say("I ruled the city-state of Zazzau and led armies beyond the Niger River, bringing unity and strength.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body was forged in battle, my spirit endures in every whisper of the Sahel wind.");
            }
            else if (speech.Contains("zazzau") || speech.Contains("zaria"))
            {
                Say("Zazzau, known as Zaria, is my home—a city of traders, warriors, and storytellers in the Hausa lands.");
            }
            else if (speech.Contains("queen"))
            {
                Say("To be queen is to bear the hopes of your people and defend their future, sword in hand.");
            }
            else if (speech.Contains("hausa"))
            {
                Say("The Hausa are traders and thinkers, builders of cities and spreaders of stories across the Sahara.");
            }
            else if (speech.Contains("sahara"))
            {
                Say("The Sahara is not empty—it is a river of sand connecting empires, traders, and warriors alike.");
            }
            else if (speech.Contains("river"))
            {
                Say("The Niger River carries life and commerce, its waters binding distant lands together.");
            }
            else if (speech.Contains("conquest"))
            {
                Say("My armies rode across the plains, building walls and forging new alliances wherever we journeyed.");
            }
            else if (speech.Contains("trader") || speech.Contains("trade") || speech.Contains("markets"))
            {
                Say("From Kano to Timbuktu, trade flowed like water. Gold, salt, and wisdom were the coins of our realm.");
            }
            else if (speech.Contains("walls") || speech.Contains("city walls"))
            {
                Say("Walls rose where my horse passed—protection for my people, and symbols of strength.");
            }
            else if (speech.Contains("horse"))
            {
                Say("My horse, swift as the desert wind, carried me from Zazzau to the edge of distant empires.");
            }
            else if (speech.Contains("battle") || speech.Contains("warrior"))
            {
                Say("The path of a warrior is discipline and courage. Victory belongs to those who seize opportunity.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not in gold, but in the unity and pride of my people. The Hausa kingdoms remember.");
            }
            else if (speech.Contains("niger"))
            {
                Say("The Niger is a lifeline, blessing kingdoms on its long journey to the sea.");
            }
            else if (speech.Contains("empire") || speech.Contains("empires"))
            {
                Say("Empires rise where vision meets action. Zazzau's story is carved in both sand and stone.");
            }
            else if (speech.Contains("sand"))
            {
                Say("Each grain of sand is a memory—together, they build the dunes of history.");
            }
            else if (speech.Contains("timbuktu"))
            {
                Say("Timbuktu is a city of knowledge—merchants, poets, and scholars gather there from afar.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who act boldly, for hesitation is the enemy of greatness.");
            }
            else if (speech.Contains("stories") || speech.Contains("story"))
            {
                Say("Stories are the lifeblood of a people. Ask, and I will tell you more.");
            }
            else if (speech.Contains("sword") || speech.Contains("blade"))
            {
                Say("My blade knew no equal on the field. Steel and wisdom conquer together.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("True wisdom lies in learning from both friend and foe, victory and defeat.");
            }
            else if (speech.Contains("bakwa") || speech.Contains("turunku") || speech.Contains("mother"))
            {
                Say("My mother, Bakwa Turunku, taught me that strength and mercy are not opposites, but allies.");
            }
            else if (speech.Contains("allies"))
            {
                Say("An empire is only as strong as its alliances. Respect builds bridges wider than any river.");
            }
            else if (speech.Contains("respect"))
            {
                Say("Respect earned on the battlefield lasts longer than fear imposed by the sword.");
            }
			else if (speech.Contains("leadership"))
			{
				Say("Leadership is the art of seeing what is possible and inspiring others to believe it too.");
			}
			else if (speech.Contains("childhood") || speech.Contains("youth"))
			{
				Say("As a child, I watched warriors train and learned from councilors. Destiny, I think, has a habit of whispering early.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the resolve to act even when the sand trembles beneath your feet.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night in Zazzau is cool and filled with music—drums, stories, and the laughter of children under the moon.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon has many faces: a guide for travelers, a companion for lovers, a guardian for those who watch the walls.");
			}
			else if (speech.Contains("family"))
			{
				Say("My family was my first kingdom—a tapestry of elders, siblings, and the wisdom of generations.");
			}
			else if (speech.Contains("enemies") || speech.Contains("foes"))
			{
				Say("Respect your enemies, for they teach you vigilance and sharpen your resolve.");
			}
			else if (speech.Contains("training") || speech.Contains("practice"))
			{
				Say("Every dawn, I trained with the sword and the bow. Skill grows where sweat falls.");
			}
			else if (speech.Contains("food") || speech.Contains("feast"))
			{
				Say("On festival days, the city feasts on yam, millet, and roasted goat, spiced with the laughter of friends.");
			}
			else if (speech.Contains("festival") || speech.Contains("celebration"))
			{
				Say("Celebrations unite a city. Drums, dance, and stories turn victories and harvests into memories.");
			}
			else if (speech.Contains("regret"))
			{
				Say("Every queen knows regret, but regret must not become chains. Learn, forgive, and ride onward.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain brings life to the Sahel, blessing farmers and singing softly on the palace roof.");
			}
			else if (speech.Contains("wisdom") || speech.Contains("proverb"))
			{
				Say("The wise say: 'A river does not forget its source.' Remember where you began, even as you cross new lands.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny favors the bold, but it is shaped by every choice, large or small.");
			}
			else if (speech.Contains("travel"))
			{
				Say("Travel broadens the mind and deepens the spirit. I have seen sunsets on distant plains, and each one taught me something new.");
			}
			else if (speech.Contains("council"))
			{
				Say("A wise leader listens more than she speaks. The council of elders helped me weigh the burdens of power.");
			}
			else if (speech.Contains("mercy"))
			{
				Say("Mercy tempers justice. Sometimes, one act of kindness grows into a thousand loyal hearts.");
			}
			else if (speech.Contains("power"))
			{
				Say("Power is a river: dangerous if uncontrolled, but life-giving when guided wisely.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Tradition is the root of our tree. It holds us upright, even as our branches reach for new horizons.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future is not set in stone; each action ripples outward, shaping what is yet to come.");
			}
			else if (speech.Contains("mystery") || speech.Contains("mysteries"))
			{
				Say("There are mysteries hidden beneath every dune and behind every legend. Seek them, and the world grows richer.");
			}			
            else if (speech.Contains("drum") || speech.Contains("music"))
            {
                Say("Drums carry messages across the savanna—joy, warning, and the beat of our stories.");
            }
            else if (speech.Contains("savanna"))
            {
                Say("The savanna stretches wide and golden, home to both lions and those who tame them.");
            }
            else if (speech.Contains("lion") || speech.Contains("lions"))
            {
                Say("The lion is a symbol of courage, ruling its domain with quiet strength.");
            }
            else if (speech.Contains("expansion"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The gates of Zazzau do not open so often. Return when the sun has crossed the sky.");
                }
                else
                {
                    Say("Your curiosity and ambition mirror my own. Accept this Treasure Chest of Niger Empires—may it inspire bold deeds.");
                    from.AddToBackpack(new TreasureChestOfNigerEmpires());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your journey be crowned with wisdom and victory.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Zazzau, battle, trade, or the sands that shape empires.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenAminaOfZazzau(Serial serial) : base(serial) { }

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
