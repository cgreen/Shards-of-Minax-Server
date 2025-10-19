using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Nanny of the Maroons")]
    public class NannyOfTheMaroons : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public NannyOfTheMaroons() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nanny of the Maroons";
            Body = 0x191; // Human female body

            // Unique Appearance: Jamaican Maroon Leader
            AddItem(new ElvenShirt() { Name = "Freedom Weaver's Tunic", Hue = 1436 });
            AddItem(new GuildedKilt() { Name = "Windward Maroon Wrap", Hue = 1428 });
            AddItem(new Cloak() { Name = "Cloak of the Blue Mountains", Hue = 1365 });
            AddItem(new FeatheredHat() { Name = "Obeah Priestess Headwrap", Hue = 2209 });
            AddItem(new FurBoots() { Name = "Jungle Pathfinder Boots", Hue = 1147 });
            AddItem(new BodySash() { Name = "Obeah Sash of Freedom", Hue = 1435 });

            // Weapon: Staff
            AddItem(new QuarterStaff() { Name = "Staff of Ancestral Spirits", Hue = 1177 });

            // Speech Hue
            SpeechHue = 2123;

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
                Say("I am Nanny of the Maroons, guardian of the Blue Mountains and mother to freedom seekers.");
            }
            else if (speech.Contains("job"))
            {
                Say("My calling is to guide the Maroons and shield the runaways who flee the whip and chain.");
            }
            else if (speech.Contains("health"))
            {
                Say("My bones may be weary, but the mountain wind gives me strength each dawn.");
            }
            else if (speech.Contains("maroon") || speech.Contains("maroons"))
            {
                Say("The Maroons are the hidden ones—escaped from slavery, living free in the mountains of Jamaica.");
            }
            else if (speech.Contains("jamaica"))
            {
                Say("Jamaica is an island of fire and storm, where the drumbeat of freedom never stops.");
            }
            else if (speech.Contains("runaway") || speech.Contains("runaways"))
            {
                Say("Runaways find shelter in the forest. Here, the trees whisper secrets and cover their tracks.");
            }
            else if (speech.Contains("british") || speech.Contains("colonial"))
            {
                Say("The British sought to chain us, but the jungle and our courage held them at bay.");
            }
            else if (speech.Contains("blue mountain") || speech.Contains("blue mountains"))
            {
                Say("The Blue Mountains are my home—shrouded in mist and legend, sacred to the Maroons.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of the ancestors guide my hand and guard our village with Obeah magic.");
            }
            else if (speech.Contains("obeah"))
            {
                Say("Obeah is the old power—herbs, wisdom, and the will to resist. Few outsiders understand its secrets.");
            }
            else if (speech.Contains("herb") || speech.Contains("herbs"))
            {
                Say("Herbs heal wounds and sharpen senses. Even the fiercest warrior respects the wisdom of the bush.");
            }
            else if (speech.Contains("village"))
            {
                Say("In our mountain villages, we live by the drum, the dance, and the word of freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a flame; though they tried to stamp it out, it burns brighter in the darkness.");
            }
            else if (speech.Contains("drum") || speech.Contains("drums"))
            {
                Say("The drum calls the Maroons to gather. Its voice travels farther than any shout.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors walk beside us in the night wind, reminding us never to kneel.");
            }
            else if (speech.Contains("magic"))
            {
                Say("Magic lives in the earth, the river, and the heart. Use it to heal and to shield.");
            }
            else if (speech.Contains("shield"))
            {
                Say("My shield is faith, and the courage of those who stand with me.");
            }
            else if (speech.Contains("legend"))
            {
                Say("They say I catch bullets in my hands, but true power is in the spirit that cannot be broken.");
            }
            else if (speech.Contains("mountain"))
            {
                Say("Every mountain holds a hundred secrets. Climb with respect, and they may reveal a treasure.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Many secrets lie in the mists—hidden paths, sacred springs, and tales whispered on the wind.");
            }
            else if (speech.Contains("british") || speech.Contains("soldier") || speech.Contains("soldiers"))
            {
                Say("British soldiers feared our forests more than our spears, for the land itself fought beside us.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is a drumbeat in the heart—steady, strong, unyielding. It is the key to all victory.");
            }
            else if (speech.Contains("victory"))
            {
                Say("We won our freedom by knowing the land, trusting the spirits, and never surrendering.");
            }
            else if (speech.Contains("key"))
            {
                Say("Sometimes, the key to survival is to vanish like smoke, then strike like thunder.");
            }
            else if (speech.Contains("smoke"))
            {
                Say("Smoke hides us from enemies and signals friends—never fear a little mystery.");
            }
			else if (speech.Contains("food") || speech.Contains("yam") || speech.Contains("cassava"))
			{
				Say("Yam and cassava give strength to the Maroon. Food from the earth, cooked over a free fire, tastes sweetest of all.");
			}
			else if (speech.Contains("music") || speech.Contains("song") || speech.Contains("sing"))
			{
				Say("We sing to remember, and to call the spirits. A song on the wind can lift even the heaviest heart.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Each story is a thread in the tapestry of our people. Sit by the fire and you will hear the old tales of tricksters and heroes.");
			}
			else if (speech.Contains("medicine") || speech.Contains("healing"))
			{
				Say("I know the leaves and roots for every wound. Healing hands are as mighty as spears in the fight for freedom.");
			}
			else if (speech.Contains("river") || speech.Contains("spring") || speech.Contains("water"))
			{
				Say("The river is our lifeline. Hidden springs run cold and sweet in the Blue Mountains—guarded, like our freedom.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("The children are the hope of tomorrow. We teach them to walk softly, and never forget the drumbeat of the ancestors.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire gives light and keeps away wild beasts, but it can also signal danger. In the mountains, fire is a friend—and a warning.");
			}
			else if (speech.Contains("animal") || speech.Contains("dog") || speech.Contains("parrot"))
			{
				Say("Dogs guard our camps, and parrots cry alarms from the treetops. Even the wild creatures stand with the Maroons.");
			}
			else if (speech.Contains("night"))
			{
				Say("The night belongs to the brave. Shadows may hide foes, but also friends and spirits ready to help.");
			}
			else if (speech.Contains("rain") || speech.Contains("storm"))
			{
				Say("Rain brings life to the hills and tests the patience of our enemies. We dance when the thunder rolls.");
			}
			else if (speech.Contains("slave") || speech.Contains("slavery"))
			{
				Say("We were born in chains, but in the hills we broke them. No person is meant to be owned. Freedom is for all.");
			}
			else if (speech.Contains("duppy") || speech.Contains("ghost"))
			{
				Say("Some say duppies wander these woods—restless spirits, sometimes helpful, sometimes full of mischief.");
			}
			else if (speech.Contains("sugar") || speech.Contains("plantation"))
			{
				Say("The sugar plantations brought pain and sorrow. But out of that darkness, the Maroon spirit grew unbreakable.");
			}
			else if (speech.Contains("friend") || speech.Contains("ally"))
			{
				Say("A true friend stands beside you in the darkest night. The Maroon knows who to trust—and who to watch.");
			}
			else if (speech.Contains("betrayal") || speech.Contains("traitor"))
			{
				Say("Betrayal is poison. Trust is the strongest bond among those who fight for freedom.");
			}
			else if (speech.Contains("peace") || speech.Contains("treaty"))
			{
				Say("After many battles, we won our peace. The British signed the treaty, and the hills echoed with new hope.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to the bold. With each sunrise, a new story waits to be written on the wind.");
			}
			else if (speech.Contains("queen"))
			{
				Say("They called me Queen of the Maroons, but my true crown is the spirit of my people.");
			}
			else if (speech.Contains("maroon town"))
			{
				Say("Maroon Town stands hidden by the hills. Only those who know the paths can find its heart.");
			}			
            else if (speech.Contains("enemy") || speech.Contains("enemies"))
            {
                Say("Enemies may come in red coats, but the mountain shows them no mercy.");
            }
            else if (speech.Contains("mercy"))
            {
                Say("Mercy is given to those who seek it with open hands, not swords.");
            }
            else if (speech.Contains("mother"))
            {
                Say("They call me 'Mother Nanny'—not just for the Maroons, but for all who yearn for freedom.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("drumbeat")) // SECRET KEYWORD
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The mountains wait, but not so soon. Return when your spirit is patient.");
                }
                else
                {
                    Say("Your heart knows the drumbeat of freedom. Take this Treasure Chest of Jamaica, and carry our story onward.");
                    from.AddToBackpack(new TreasureChestOfJamaica());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk in the shade of the Blue Mountains. The ancestors watch over you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Maroons, Obeah, the Blue Mountains, or legends of freedom.");
                }
            }

            base.OnSpeech(e);
        }

        public NannyOfTheMaroons(Serial serial) : base(serial) { }

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
