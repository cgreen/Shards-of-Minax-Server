using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Pablo Presbere")]
    public class PabloPresbere : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public PabloPresbere() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Pablo Presbere";
            Body = 0x190; // Human male body

            // Unique Appearance: King of Talamanca
            AddItem(new ElvenShirt() { Name = "Tunica de la Selva Bribri", Hue = 1760 });
            AddItem(new GuildedKilt() { Name = "Kilt of the Talamancan Uprising", Hue = 2120 });
            AddItem(new FeatheredHat() { Name = "Crown of Macaw Feathers", Hue = 1358 });
            AddItem(new Cloak() { Name = "Cloak of the Rainforest Spirits", Hue = 1376 });
            AddItem(new FurBoots() { Name = "Boots of the Mountain Paths", Hue = 2057 });
            AddItem(new BodySash() { Name = "Sash of Ancestral Wisdom", Hue = 1254 });
            AddItem(new TribalMask() { Name = "Mask of the Jaguar", Hue = 1109 });

            // Weapon: Spear (Staff)
            AddItem(new GnarledStaff() { Name = "Staff of the Talamanca Elders", Hue = 1835 });

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
                Say("I am Pablo Presbere, called El Rey de Talamanca by some, but always Bribri by heart.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was a leader, chosen to protect my people, the Bribri, and our home among the rivers and mountains.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body was scarred by war, but my spirit is bound to these forests and rivers. In their songs, I live on.");
            }
            else if (speech.Contains("bribri"))
            {
                Say("We Bribri have lived in Talamanca since before memory. Our language is the echo of the rivers, our hearts are the drums of the earth.");
            }
            else if (speech.Contains("talamanca"))
            {
                Say("Talamanca is a realm of mist and mystery, where mountains meet rainforest and the jaguar hunts in silence.");
            }
            else if (speech.Contains("rebellion") || speech.Contains("uprising"))
            {
                Say("The rebellion was our answer to chains and crosses forced upon us. Freedom was our right—freedom and memory.");
            }
            else if (speech.Contains("rainforest") || speech.Contains("forest"))
            {
                Say("The rainforest is our shelter and our teacher. Each tree and river carries a story, if you know how to listen.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Spirits of ancestors walk with us. In every bird’s song and every drop of rain, they offer guidance.");
            }
            else if (speech.Contains("leader"))
            {
                Say("A true leader does not command, but listens—to elders, to dreams, and to the cries of the oppressed.");
            }
            else if (speech.Contains("jaguar"))
            {
                Say("The jaguar is our protector. It moves between worlds—seen and unseen—just as we do.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Mountains guard Talamanca like ancient sentinels. Their peaks touch the sky, their roots touch memory.");
            }
            else if (speech.Contains("macaw") || speech.Contains("feather"))
            {
                Say("Macaw feathers crown the bravest among us, bright as sunrise and swift as the river.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Our lives flow with the rivers—Telire, Coen, and Sixaola. They carry stories and sometimes secrets.");
            }
            else if (speech.Contains("ancestral"))
            {
                Say("Ancestral wisdom is in every stone and seed. We are only caretakers, not owners, of this land.");
            }
            else if (speech.Contains("conquistador") || speech.Contains("spanish") || speech.Contains("cross"))
            {
                Say("The conquistadors brought iron and fire, but our roots ran deeper than their swords. Faith cannot be forced.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the right to remember your ancestors and teach your children their true names.");
            }
            else if (speech.Contains("memory") || speech.Contains("memories"))
            {
                Say("Memory is our shield against forgetting. Even in darkness, we carried the songs of our fathers.");
            }
            else if (speech.Contains("songs") || speech.Contains("song"))
            {
                Say("Our songs are woven from wind, water, and dreams. Would you listen, wanderer?");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are paths through the mist, sometimes leading to answers, sometimes to new questions.");
            }
            else if (speech.Contains("mist"))
            {
                Say("Mist covers the valleys in the morning. To see through it, you must have patience—and trust your heart.");
            }
            else if (speech.Contains("heart"))
            {
                Say("A brave heart beats louder than any drum. It is what kept my people standing.");
            }
            else if (speech.Contains("standing"))
            {
                Say("To stand is to resist. Even after defeat, as long as you rise again, you are never truly conquered.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is learned from silence, and from the old stories told beside the fire.");
            }
            else if (speech.Contains("fire"))
            {
                Say("The fire is both warmth and warning. Treat it with respect, and it will guide you through the dark.");
            }
            else if (speech.Contains("dark") || speech.Contains("darkness"))
            {
                Say("Darkness cannot swallow those who remember the way home.");
            }
			else if (speech.Contains("food") || speech.Contains("maize") || speech.Contains("plantain") || speech.Contains("fruit"))
			{
				Say("Maize is the gift of the earth, and plantains fill our children’s laughter with strength. In every meal, we thank both sky and soil.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Tradition is not just memory—it is living breath. Our dances, our songs, our crafts, all keep the circle unbroken.");
			}
			else if (speech.Contains("community") || speech.Contains("family"))
			{
				Say("A village is built with more than huts. It is made strong by the sharing of work, song, and sorrow.");
			}
			else if (speech.Contains("rain") || speech.Contains("rainfall"))
			{
				Say("The rains wash away the old and awaken the green. Listen—the spirits speak softly on the falling water.");
			}
			else if (speech.Contains("medicine") || speech.Contains("healing"))
			{
				Say("Healers learn from the plants and the rivers. The jungle’s wisdom can cure, if you treat her with care and respect.");
			}
			else if (speech.Contains("prophecy") || speech.Contains("dreamseer"))
			{
				Say("Some say the dreamseers saw my coming, and my fall. But every day, each of us writes a new page in the prophecy of our people.");
			}
			else if (speech.Contains("exile") || speech.Contains("prison"))
			{
				Say("Exile is not only distance from home. It is the ache of being forgotten. Yet memory brings even the lost ones home.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is not the absence of struggle, but the return of balance. Like the river after the storm.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom grows slowly, like the ceiba tree. Sit with the elders, watch the sunrise, and let patience be your guide.");
			}
			else if (speech.Contains("ceiba") || speech.Contains("tree"))
			{
				Say("The ceiba stands at the center of all worlds—roots deep in the earth, branches high in the clouds. All stories meet beneath her shade.");
			}
			else if (speech.Contains("shade") || speech.Contains("shelter"))
			{
				Say("In the hottest sun, a friend’s shelter is worth more than gold. Remember to offer shade when others need it.");
			}			
            else if (speech.Contains("costa rica"))
            {
                Say("This land has many names, but only those who honor its roots truly know it.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A legacy is not gold or power, but the memory of a people unbroken.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the wind that cannot be caged.");
            }
            else if (speech.Contains("roots"))
            {
                Say("Roots connect us to ancestors and to earth. Without them, we are lost.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Every river hides a secret, and every path in the forest leads somewhere unexpected.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("telire"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The river waits before it gives again. Come back when the sun is higher.");
                }
                else
                {
                    Say("You honor the river Telire, lifeblood of my people. Accept this Treasure Chest of Costa Rican History. May it guide you as the river guided us.");
                    from.AddToBackpack(new TreasureChestOfCostaRicanHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the spirits of Talamanca travel with you, guardian of stories.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Bribri, Talamanca, jaguars, or the rivers that bind this land.");
                }
            }

            base.OnSpeech(e);
        }

        public PabloPresbere(Serial serial) : base(serial) { }

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
