using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mekatilili wa Menza")]
    public class MekatililiWaMenza : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MekatililiWaMenza() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mekatilili wa Menza";
            Body = 0x191; // Human female body

            // Outfit
            AddItem(new FancyDress() { Name = "Giriama Elder's Robe", Hue = 2932 });
            AddItem(new FlowerGarland() { Name = "Frangipani Crown", Hue = 1161 });
            AddItem(new BodySash() { Name = "Sash of the Mijikenda", Hue = 1366 });
            AddItem(new Sandals() { Name = "Sands of Kilifi", Hue = 2055 });
            AddItem(new WoodlandBelt() { Name = "Belt of the Sacred Kaya", Hue = 1786 });

            // Weapon/Staff
            AddItem(new QuarterStaff() { Name = "Mkongo Staff of Spirits", Hue = 2758 });

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
                Say("I am Mekatilili wa Menza, mother to the Giriama and thorn to the British.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a protector of tradition, a voice for the Giriama, and a leader of rebellion.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body has weathered storms and chains, but my spirit dances strong as ever.");
            }
            else if (speech.Contains("giriama"))
            {
                Say("The Giriama are a proud people, keepers of the kaya forests and the secrets of our ancestors.");
            }
            else if (speech.Contains("british") || speech.Contains("colonial"))
            {
                Say("The British tried to shackle our land and spirit, but the kaya shields us and tradition binds us together.");
            }
            else if (speech.Contains("kaya"))
            {
                Say("The kaya are our sacred forests—places of meeting, worship, and memory. Each kaya is the heart of our people.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of our ancestors guide my steps. Their whispers are louder than any chain.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is our shield. Through ritual and dance, we remember who we are—even when conquerors forget.");
            }
            else if (speech.Contains("dance"))
            {
                Say("With every clap and drumbeat, we summon courage. The Kifudu dance unites us in hope and resistance.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is standing tall when all wish you to kneel. Even as exile and chains threatened me, I did not bow.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("Our ancestors watch from the shadows of the kaya. They reward those who honor the old ways.");
            }
            else if (speech.Contains("chains") || speech.Contains("exile"))
            {
                Say("I was taken in chains across great distances, but no prison can hold a soul bound to the land.");
            }
            else if (speech.Contains("kilifi"))
            {
                Say("Kilifi is where my heart beats loudest. Among the baobab trees, the Giriama draw strength for each new dawn.");
            }
			else if (speech.Contains("family"))
			{
				Say("Family is the first fortress. My son, Mwarandu, stood at my side when the British came, and my mother taught me the power of words.");
			}
			else if (speech.Contains("mother"))
			{
				Say("A mother's wisdom is deeper than the kaya roots. She taught me the stories that kept our people strong.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Stories are our true inheritance. Each night by the fire, elders recount tales of leopards, baobab trees, and clever children.");
			}
			else if (speech.Contains("baobab"))
			{
				Say("The baobab tree is the pillar of our land—provider of shade, fruit, and memory. Some say the ancestors dwell within their hollow trunks.");
			}
			else if (speech.Contains("market") || speech.Contains("trade"))
			{
				Say("Our markets bustle with laughter and news. We trade cassava, millet, and shells—every deal sealed with a blessing.");
			}
			else if (speech.Contains("blessing") || speech.Contains("blessings"))
			{
				Say("May the rains be gentle and the harvest plentiful. My blessing goes with you, wherever you wander.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is life. When the clouds gather and drums beat, all know the ancestors are smiling.");
			}
			else if (speech.Contains("food"))
			{
				Say("We feast on coconut rice and cassava. Food shared is food blessed—no one leaves a Giriama hearth hungry.");
			}
			else if (speech.Contains("women") || speech.Contains("leader"))
			{
				Say("A woman leads with heart and wisdom. Do not mistake gentleness for weakness, nor patience for surrender.");
			}
			else if (speech.Contains("enemy") || speech.Contains("danger"))
			{
				Say("Every people face danger—lions, drought, invaders. We greet each with courage, song, and the wisdom of the old ways.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are paths to the ancestors. Sometimes, their voices visit in sleep, warning or guiding those who listen.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The drum is the heart of our people. Its rhythm calls us to dance, to war, and to remembrance.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun is witness to all vows. Its rise brings hope, its fall brings peace.");
			}
			else if (speech.Contains("sea") || speech.Contains("ocean"))
			{
				Say("The great sea touches our coast, bringing stories from distant lands and storms that test our roots.");
			}
			else if (speech.Contains("shell") || speech.Contains("shells"))
			{
				Say("Cowrie shells are symbols of wealth and mystery. We wear them in our hair and trade them in our markets.");
			}
			else if (speech.Contains("magic") || speech.Contains("mystery"))
			{
				Say("There is magic in every seed, every song, every story whispered to the night wind.");
			}
			else if (speech.Contains("brave") || speech.Contains("bravery"))
			{
				Say("Bravery is not the absence of fear, but dancing when the storm is fiercest.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is a river—sometimes hidden, sometimes swift, always nourishing those who seek it.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is hard-won, like a field cleared for planting. We must tend it with patience and vigilance.");
			}
			else if (speech.Contains("planting") || speech.Contains("harvest"))
			{
				Say("The harvest is our song of survival. With each planting, we honor those who taught us to work and to wait.");
			}
			else if (speech.Contains("wait") || speech.Contains("patience"))
			{
				Say("Patience grows deep roots. Even the mightiest baobab began as a tiny seed awaiting the rains.");
			}			
            else if (speech.Contains("rebellion") || speech.Contains("resist"))
            {
                Say("Resistance is the song in our veins. Even when hope seems lost, the land remembers each act of defiance.");
            }
            else if (speech.Contains("song") || speech.Contains("music"))
            {
                Say("Song is how we carry memory. The elders still sing of the day the British trembled before our unity.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is a fire. Divided we are lost; together we are a storm. In unity we swore an oath—would you hear more?");
            }
            else if (speech.Contains("oath"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The ancestors say patience is a virtue. Return when the sun is higher, seeker.");
                }
                else
                {
                    Say("By the sacred kaya and the oath of the Giriama, accept this Treasure Chest of Kenyan Legends. May its contents inspire your own tale of courage.");
                    from.AddToBackpack(new TreasureChestOfKenyanLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with courage, child of the savannah. The spirits travel beside you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of the kaya, Giriama, tradition, or the oath sworn in the sacred forest.");
                }
            }

            base.OnSpeech(e);
        }

        public MekatililiWaMenza(Serial serial) : base(serial) { }

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
