using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Amilcar Cabral")]
    public class AmilcarCabral : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AmilcarCabral() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Amílcar Cabral";
            Body = 0x190; // Human male body

            // Stats
            Str = 80;
            Dex = 75;
            Int = 110;
            Hits = 90;

            // Unique Appearance: West African Revolutionary
            AddItem(new FancyShirt() { Name = "Guinea-Bissau Liberation Tunic", Hue = 1153 });
            AddItem(new GuildedKilt() { Name = "Kinti Kente Kilt", Hue = 2533 });
            AddItem(new Cloak() { Name = "Cloak of Unity", Hue = 1175 });
            AddItem(new Bandana() { Name = "Bandana of the Revolution", Hue = 2128 });
            AddItem(new Sandals() { Name = "Sandals of the Land", Hue = 2207 });
            AddItem(new BodySash() { Name = "Sash of Agronomy", Hue = 2119 });
            
            // Weapon: Staff as symbol of leadership and wisdom
            AddItem(new QuarterStaff() { Name = "Staff of the People", Hue = 2022 });

            // Speech Hue
            SpeechHue = 2101;

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
                Say("I am Amílcar Cabral, son of Guinea and voice of liberation for all her peoples.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was an agronomist, a poet, and a leader of the struggle for independence in Guinea-Bissau.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body fell to betrayal, but my vision for justice and dignity endures in these lands.");
            }
            else if (speech.Contains("guinea"))
            {
                Say("Guinea-Bissau is a land of rivers and mangroves, of courage and song.");
            }
            else if (speech.Contains("bissau"))
            {
                Say("Bissau is the heart of our nation, once ruled from afar, now a beacon for our people.");
            }
            else if (speech.Contains("agronomist") || speech.Contains("agriculture") || speech.Contains("land"))
            {
                Say("To know the land is to know freedom. We sowed hope as well as rice and millet.");
            }
            else if (speech.Contains("revolution") || speech.Contains("struggle"))
            {
                Say("Revolution means reclaiming dignity. Our struggle was for land, bread, and the right to decide our own future.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who build it—each seed you plant may become a forest.");
            }
            else if (speech.Contains("poet") || speech.Contains("poetry"))
            {
                Say("Words can be weapons or seeds. In poetry, I found hope when the world gave us none.");
            }
            else if (speech.Contains("freedom") || speech.Contains("independence"))
            {
                Say("Freedom is built with patience and courage, stone by stone, day by day.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity was our shield. Cape Verde and Guinea-Bissau stood together against oppression.");
            }
            else if (speech.Contains("cape verde") || speech.Contains("capeverde"))
            {
                Say("Cape Verde is our sister—our destinies braided together by history and hope.");
            }
            else if (speech.Contains("portuguese") || speech.Contains("colonial"))
            {
                Say("Colonial rule brought hardship, but could not erase the dreams of a free Guinea-Bissau.");
            }
            else if (speech.Contains("dream") || speech.Contains("vision"))
            {
                Say("Dreams are the blueprints of tomorrow. What is your vision for these lands?");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is a river—it carries us forward even when the road is hard.");
            }
            else if (speech.Contains("betrayal"))
            {
                Say("Betrayal took my life, but the struggle did not end. Ideas cannot be assassinated.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("The rivers of Guinea-Bissau feed the land and the people. They are veins of life.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice means more than punishment—it means every child can eat, every farmer can plant.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs kept the spirit alive when the nights were longest. Will you carry a song of your own?");
            }
            else if (speech.Contains("farm") || speech.Contains("farming") || speech.Contains("rice"))
            {
                Say("Rice fields and orchards were our battlegrounds and our hope. The land remembers those who care for it.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is the harvest of justice, sown in the fields of respect.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A true legacy is not left in stone, but in the hearts of a free people.");
            }
            else if (speech.Contains("dignity"))
            {
                Say("Dignity is priceless, and the first thing every people must reclaim from their oppressors.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors walk beside us, guiding each step we take toward freedom.");
            }
            else if (speech.Contains("people"))
            {
                Say("Without the people, there can be no revolution. Every victory is won together.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is born from listening—to the land, to the elders, to the dreams of the young.");
            }
            else if (speech.Contains("betrayal"))
            {
                Say("Betrayal is a shadow that falls on every struggle, but truth and justice will outlast it.");
            }
            else if (speech.Contains("roots"))
            {
                Say("A tree without roots cannot weather the storm. Our roots run deep in African soil.");
            }
            else if (speech.Contains("soil"))
            {
                Say("Soil is memory—each handful holds a thousand stories of work and hope.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is our strength. It binds us through hardship and hope.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom comes from hardship as well as peace. Both teach us to cherish what we build.");
            }
            else if (speech.Contains("orchard") || speech.Contains("fruit"))
            {
                Say("In every orchard, there is patience, work, and the promise of plenty.");
            }
            else if (speech.Contains("education"))
            {
                Say("With education, our people grew strong. Knowledge is the foundation of freedom.");
            }
			else if (speech.Contains("forest"))
			{
				Say("Forests teach us resilience; after every fire, green returns. There is always hope beneath the ashes.");
			}
			else if (speech.Contains("ashes"))
			{
				Say("From the ashes of defeat, we rebuilt. Despair is only a season, not a fate.");
			}
			else if (speech.Contains("season"))
			{
				Say("Every season has its lesson. Listen to the rains and the dry winds—they each have something to teach.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is not owned, but borrowed from our elders and passed to the young.");
			}
			else if (speech.Contains("elders"))
			{
				Say("Our elders held the memory of the land in their stories. Respect their words; they hold roots for our future.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Stories shape nations as much as battles. Will you carry our stories forward?");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Each child is a promise. Their laughter is worth fighting for, their hunger worth ending.");
			}
			else if (speech.Contains("hunger"))
			{
				Say("No people are truly free while hunger remains. That is why land, not just words, was at the heart of our struggle.");
			}
			else if (speech.Contains("bread"))
			{
				Say("Bread is more than food; it is a symbol of dignity and justice for every table.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the decision that something else is more important.");
			}
			else if (speech.Contains("decision"))
			{
				Say("Every decision carries weight. Even a small choice can change the future of a people.");
			}
			else if (speech.Contains("night"))
			{
				Say("Nights in the forest taught us patience and the power of silent determination.");
			}
			else if (speech.Contains("determination"))
			{
				Say("With determination, a single voice can echo across generations.");
			}
			else if (speech.Contains("echo"))
			{
				Say("The echo of freedom cannot be silenced. It returns in every generation, stronger than before.");
			}
			else if (speech.Contains("freedom fighter"))
			{
				Say("A freedom fighter is first a servant of their people. Service is the highest form of leadership.");
			}
			else if (speech.Contains("service"))
			{
				Say("Service means listening, learning, and lifting others up before yourself.");
			}
			else if (speech.Contains("learning"))
			{
				Say("Learning is a lifelong harvest; it never ends, and it feeds every other part of life.");
			}
			else if (speech.Contains("unity"))
			{
				Say("Remember, unity is not sameness, but shared purpose. We are strong together, even when different.");
			}
			else if (speech.Contains("different"))
			{
				Say("Difference is richness. Like many seeds in a field, together we create a harvest.");
			}
			else if (speech.Contains("field") || speech.Contains("fields"))
			{
				Say("In the fields, the future grows. Each grain is a victory against hunger and fear.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Fear is a wall, but hope is a bridge. Which will you build?");
			}
			else if (speech.Contains("bridge"))
			{
				Say("Bridges connect islands and people. Let us always build more bridges than walls.");
			}
			else if (speech.Contains("island") || speech.Contains("islands"))
			{
				Say("Cape Verde and Guinea-Bissau are islands of hope in a vast ocean of challenge.");
			}			
            else if (speech.Contains("martyr") || speech.Contains("martyrs"))
            {
                Say("Martyrs are not only those who die, but those who never surrender their vision.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("orchid"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Like the orchid, patience must bloom before it gives its flower again. Return later, friend.");
                }
                else
                {
                    Say("Your curiosity has found fertile ground. Accept this Treasure Chest of Guinea-Bissau—may its seeds grow strong in your hands.");
                    from.AddToBackpack(new TreasureChestOfGuineaBissau());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk well, friend. May the rivers guide your journey.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of agriculture, unity, justice, or the rivers of Guinea-Bissau.");
                }
            }

            base.OnSpeech(e);
        }

        public AmilcarCabral(Serial serial) : base(serial) { }

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
