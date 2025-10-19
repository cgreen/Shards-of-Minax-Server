using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Njegoš")]
    public class Njegos : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Njegos() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Petar II Petrović-Njegoš";
            Title = "Poet-Prince of Montenegro";
            Body = 0x190; // Human male body

            // Unique Appearance
            AddItem(new FancyShirt() { Name = "Shirt of the Black Mountain", Hue = 1150 });
            AddItem(new Kilt() { Name = "Montenegrin Sash-Kilt", Hue = 2407 });
            AddItem(new Cloak() { Name = "Cloak of Lovćen Mists", Hue = 2101 });
            AddItem(new FeatheredHat() { Name = "Cap of Njegoš", Hue = 1175 });
            AddItem(new FurBoots() { Name = "Boots of Cetinje", Hue = 2105 });
            AddItem(new BodySash() { Name = "Crimson Order Sash", Hue = 1157 });

            // Weapon: Staff
            AddItem(new QuarterStaff() { Name = "Staff of Epic Verses", Hue = 2109 });

            // Speech Hue
            SpeechHue = 2117;

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
                Say("I am Petar II Petrović-Njegoš, ruler, poet, and keeper of Montenegro's soul.");
            }
            else if (speech.Contains("job"))
            {
                Say("I led Montenegro as Prince-Bishop and sang her struggles in verse and wisdom.");
            }
            else if (speech.Contains("health"))
            {
                Say("This mountain air preserves me, but burdened hearts age quickly in lands of stone.");
            }
            else if (speech.Contains("montenegro") || speech.Contains("black mountain"))
            {
                Say("Montenegro—Crna Gora—is a fortress of rock and spirit. Her people are as unyielding as her cliffs.");
            }
            else if (speech.Contains("lovcen"))
            {
                Say("Mount Lovćen watches over us all. It is said, from its heights, an eagle may see the heart of every Montenegrin.");
            }
            else if (speech.Contains("eagle"))
            {
                Say("The double-headed eagle is our symbol—wings outstretched to guard both past and future.");
            }
            else if (speech.Contains("prince") || speech.Contains("bishop"))
            {
                Say("As Vladika, I was both sword and shepherd—guiding with prayer, defending with courage.");
            }
            else if (speech.Contains("poet") || speech.Contains("verse"))
            {
                Say("Through poetry, I tried to immortalize the sorrow and glory of our people. Have you heard of 'The Mountain Wreath'?");
            }
            else if (speech.Contains("mountain wreath"))
            {
                Say("‘Gorski Vijenac’ tells of struggle and unity. Within its lines are secrets for those who listen.");
            }
            else if (speech.Contains("cetinje"))
            {
                Say("Cetinje is the heart of our nation, where prayers and councils shape destiny.");
            }
            else if (speech.Contains("ottoman") || speech.Contains("turk"))
            {
                Say("Many storms have battered these stones—Ottomans, Venetians—yet the Black Mountain endures.");
            }
            else if (speech.Contains("prayer"))
            {
                Say("A true prayer here is as strong as any sword. Both can shape the fate of a nation.");
            }
            else if (speech.Contains("sword"))
            {
                Say("Swords defend the land, but words—well chosen—defend the soul.");
            }
            else if (speech.Contains("soul"))
            {
                Say("The soul of Montenegro is fierce, free, and as deep as the forests at twilight.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is not found in silence, but in the sharing of stories, old and new.");
            }
            else if (speech.Contains("forest") || speech.Contains("twilight"))
            {
                Say("In twilight’s forest, spirits walk. Listen, and you may hear old guslars sing.");
            }
            else if (speech.Contains("guslar") || speech.Contains("song"))
            {
                Say("Guslars sing the tale of heroes, their voices echoing through canyons and centuries.");
            }
            else if (speech.Contains("hero") || speech.Contains("heroes"))
            {
                Say("Every Montenegrin is born with a hero’s heart—sometimes it slumbers until called.");
            }
            else if (speech.Contains("call") || speech.Contains("destiny"))
            {
                Say("Destiny is a steep path—one must climb with both courage and humility.");
            }
            else if (speech.Contains("humility"))
            {
                Say("Humility tempers strength. The proudest eagle bows to drink at the mountain spring.");
            }
            else if (speech.Contains("spring") || speech.Contains("water"))
            {
                Say("Our springs run pure and cold. Many have quenched their thirst on journeys through these hills.");
            }
            else if (speech.Contains("hill") || speech.Contains("stone") || speech.Contains("rock"))
            {
                Say("Stone remembers all footsteps—heroes, outlaws, and dreamers alike.");
            }
            else if (speech.Contains("dream") || speech.Contains("future"))
            {
                Say("Dreams build the future, as stones build a fortress. What dream brings you here, traveler?");
            }
            else if (speech.Contains("venetian") || speech.Contains("venice"))
            {
                Say("Venetian merchants once sought silver and glory here. Our mountains gave them only humility.");
            }
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is our oldest tradition. Even in the harshest winters, the mountain folk never bent their knee.");
			}
			else if (speech.Contains("flag"))
			{
				Say("Our flag carries the eagle and the mountain sun—symbols of pride and vigilance.");
			}
			else if (speech.Contains("church"))
			{
				Say("The monastery walls of Cetinje have seen both prayer and battle. Faith and steel often stood side by side.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor is our law, written not on paper but in the hearts of our people.");
			}
			else if (speech.Contains("duel") || speech.Contains("duels"))
			{
				Say("Duels settled disputes in old Montenegro, where words failed but pride remained.");
			}
			else if (speech.Contains("custom") || speech.Contains("customs"))
			{
				Say("Montenegrin customs are as old as the stones—hospitality, courage, and loyalty above all.");
			}
			else if (speech.Contains("hospitality"))
			{
				Say("A guest in Montenegro is sacred. Even enemies are offered bread and salt at our table.");
			}
			else if (speech.Contains("bread") || speech.Contains("salt"))
			{
				Say("Bread for the body, salt for the soul—no welcome is complete without both.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("An enemy today may be a friend tomorrow. Time and the mountains can soften even the hardest stone.");
			}
			else if (speech.Contains("mountain pass") || speech.Contains("pass"))
			{
				Say("The passes are perilous, but every road in Montenegro leads to new stories and old secrets.");
			}
			else if (speech.Contains("battle") || speech.Contains("war"))
			{
				Say("War forged our people, but peace shapes our future. Each has its own cost.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is as precious as spring rain on the high slopes—cherished, but not always certain.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is a fortress of its own, where the fire never dies and memories are passed from elder to child.");
			}
			else if (speech.Contains("elders") || speech.Contains("elder"))
			{
				Say("Our elders are the memory of Montenegro—listen well, and you will never lose your way.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children carry our hopes and songs into the next dawn. Teach them well.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("Songs fill the valleys at dusk. Even the wind knows our melodies by heart.");
			}
			else if (speech.Contains("melody") || speech.Contains("melodies"))
			{
				Say("A melody can heal where words or medicine fail. The gusle sings what cannot be spoken.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but standing firm as the thunder echoes over Lovćen.");
			}
			else if (speech.Contains("storm") || speech.Contains("thunder"))
			{
				Say("Storms teach patience and respect. When the clouds lift, the world feels new.");
			}
			else if (speech.Contains("new") || speech.Contains("beginning"))
			{
				Say("Every sunrise is a promise. In the mountains, each day is a new beginning.");
			}			
            else if (speech.Contains("silver"))
            {
                Say("Silver lies deep within these hills, but the true wealth of Montenegro is her spirit.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("Our spirit is unbroken, forged in battle, and renewed in song.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends grow like pines—tall and proud, roots tangled with truth and dream.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("roots"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Roots run deep, seeker. Even the oldest trees must rest between seasons of giving.");
                }
                else
                {
                    Say("You have traced our story to its roots. Accept this Treasure Chest of Montenegro, a gift for the truly curious.");
                    from.AddToBackpack(new TreasureChestOfMontenegro());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the eagles guard your path, and Lovćen’s shadow guide your dreams.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Lovćen, the eagle, the Mountain Wreath, or the roots of our people.");
                }
            }

            base.OnSpeech(e);
        }

        public Njegos(Serial serial) : base(serial) { }

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
