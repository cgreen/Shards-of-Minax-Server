using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Bety the Pirate Queen")]
    public class BetyOfBetsimisaraka : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public BetyOfBetsimisaraka() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bety of Betsimisaraka";
            Title = "Pirate Queen of Madagascar";
            Body = 0x191; // Human female body

            // Unique Pirate Queen Appearance
            AddItem(new FancyShirt() { Name = "Crimson Pirate's Blouse", Hue = 2124 });
            AddItem(new GuildedKilt() { Name = "Royal Betsimisaraka Sash", Hue = 2413 });
            AddItem(new FeatheredHat() { Name = "Queen's Plumed Tricorn", Hue = 1159 });
            AddItem(new Cloak() { Name = "Seafoam Cloak of Libertalia", Hue = 1269 });
            AddItem(new Sandals() { Name = "Island Wanderer's Sandals", Hue = 2106 });
            AddItem(new BodySash() { Name = "Betsimisaraka Arm Sash", Hue = 2057 });

            // Pirate Weapon
            AddItem(new Cutlass() { Name = "Cutlass of the Scented Isles", Hue = 1260 });

            // Speech color
            SpeechHue = 2115;

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
                Say("I am Bety of Betsimisaraka, once feared as the Pirate Queen of Madagascar.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some called me queen, some pirate. I ruled these wild coasts where spices meet storm and steel.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body aches for the days of salt and sun, but the spirit of the island keeps me strong.");
            }
            else if (speech.Contains("betsimisaraka"))
            {
                Say("We are a proud people—coastal clans united by blood, sea, and stories older than the forest.");
            }
            else if (speech.Contains("pirate") || speech.Contains("piracy"))
            {
                Say("Pirates found haven here, from every shore—runaways, rebels, dreamers. Even now, some say Libertalia's torch flickers on.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen needs no crown when she commands the waves and hearts of her people.");
            }
            else if (speech.Contains("libertalia"))
            {
                Say("Libertalia was a pirate's dream: a free city of all nations, built on red earth and broken chains.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Cloves, vanilla, pepper—scent of riches and danger. Merchants crossed oceans for our spices, but the bravest sought what gold could not buy.");
            }
            else if (speech.Contains("vanilla"))
            {
                Say("Vanilla vines climb the ancient trees. Sweetness hides thorns, just as trust hides betrayal.");
            }
            else if (speech.Contains("betrayal"))
            {
                Say("Trust is a rare coin in pirate hands. Betrayal has sharp teeth, but the island remembers every promise.");
            }
            else if (speech.Contains("promise"))
            {
                Say("A promise on this island is sealed by earth and sea. Break it, and even the lemurs will whisper your name to the night.");
            }
            else if (speech.Contains("lemur") || speech.Contains("lemurs"))
            {
                Say("Lemurs leap from branch to branch, free as any pirate. The forest is alive with old secrets.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The rainforests of Madagascar hide wonders—orchids, chameleons, and spirits of ancestors watching over us.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("We honor the ancestors with song and fire. Their wisdom guides those who listen to the wind.");
            }
            else if (speech.Contains("wind"))
            {
                Say("The wind carries tales from every shipwreck and every whispered deal beneath the palm trees.");
            }
            else if (speech.Contains("shipwreck") || speech.Contains("ship"))
            {
                Say("So many ships dashed upon our reefs. Some brought gold, others ghosts. All left stories in the sand.");
            }
            else if (speech.Contains("reef") || speech.Contains("reefs"))
            {
                Say("Our coral reefs shine with every color. Sailors fear them, but the island children swim among them fearless.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold buys you a night’s feast, but respect and freedom—those last forever.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the birthright of the island, paid for with storm, song, and steel.");
            }
            else if (speech.Contains("steel"))
            {
                Say("Steel served me well, but wit and willpower won me more victories than any cutlass.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Victory is never just survival—it’s leaving a legend for those who come after.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Myths bloom faster than orchids here. Perhaps you, too, will become a legend on this island.");
            }
            else if (speech.Contains("orchid") || speech.Contains("orchids"))
            {
                Say("The black orchid is rarest of all—said to bloom only where pirate gold is buried beneath the roots.");
            }
            else if (speech.Contains("buried") || speech.Contains("treasure"))
            {
                Say("Many seek buried treasure, but only the truly curious will find the heart of the island.");
            }
			else if (speech.Contains("madagascar"))
			{
				Say("Madagascar is the red island—its earth rich with iron and stories, its shores kissed by wild seas.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms shaped our fate. Only the boldest ships and bravest hearts endure when the sky turns black.");
			}
			else if (speech.Contains("red earth") || speech.Contains("red soil"))
			{
				Say("Red soil stains your boots and your soul. It grows everything from rice to legends.");
			}
			else if (speech.Contains("rice"))
			{
				Say("Rice is our lifeblood—fields ripple like green seas beneath the mountains, feeding villages and rebels alike.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("The central highlands hold their own mysteries—caves of ancestors, hidden lakes, and forgotten kings.");
			}
			else if (speech.Contains("king") || speech.Contains("kings"))
			{
				Say("Many called themselves king here, but only those who serve their people are truly remembered.");
			}
			else if (speech.Contains("chameleon") || speech.Contains("chameleons"))
			{
				Say("Chameleons change their colors as the world changes. Adapt or vanish—that is the way of the island.");
			}
			else if (speech.Contains("fady"))
			{
				Say("Fady are our taboos—old rules whispered by elders. Break them, and bad luck may follow, as sure as shadow.");
			}
			else if (speech.Contains("rum"))
			{
				Say("We drink rum in the moonlight, laughing at the past and daring the future to do its worst.");
			}
			else if (speech.Contains("moonlight") || speech.Contains("moon"))
			{
				Say("The moon sees all—pirate councils, midnight dances, and the silent gaze of the ancestors.");
			}
			else if (speech.Contains("dance") || speech.Contains("dances"))
			{
				Say("We dance to drum and flute, bare feet stomping the earth, shaking off sorrow and summoning joy.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("Drums carry messages faster than words—call to feast, call to arms, call to freedom.");
			}
			else if (speech.Contains("flute") || speech.Contains("flutes"))
			{
				Say("A pirate's flute once lured a French captain into the mangroves. He never found his way out—or so the story goes.");
			}
			else if (speech.Contains("french"))
			{
				Say("The French chased us across these shores, hungry for empire. But this island bows to no master for long.");
			}
			else if (speech.Contains("empire"))
			{
				Say("Empires come and go. The island remains—watching, waiting, whispering.");
			}
			else if (speech.Contains("market") || speech.Contains("markets"))
			{
				Say("Our markets brim with spices, trinkets, tales, and sometimes a clever thief or two.");
			}
			else if (speech.Contains("trinket") || speech.Contains("trinkets"))
			{
				Say("Trinkets tell stories—a shell from a lost bay, a coin from a distant land, a tooth from something best left unnamed.");
			}
			else if (speech.Contains("bay") || speech.Contains("harbor"))
			{
				Say("Many a pirate fleet vanished into our bays, shielded by mist and mangroves.");
			}
			else if (speech.Contains("mist"))
			{
				Say("The island’s morning mist hides friends and foes alike. Trust your instincts—or the lemurs.");
			}
			else if (speech.Contains("instinct") || speech.Contains("instincts"))
			{
				Say("A good pirate trusts her gut. Gold and glory follow those who heed their inner voice.");
			}
			else if (speech.Contains("glory"))
			{
				Say("Glory fades, but a well-told story keeps a name alive forever.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("We sing of love, loss, and larceny. If you listen closely, the wind might carry a tune only pirates know.");
			}
			else if (speech.Contains("larceny"))
			{
				Say("Larceny? A harsh word for a necessary act. Sometimes, taking is surviving.");
			}			
            else if (speech.Contains("curious") || speech.Contains("curiosity"))
            {
                Say("Curiosity is a compass—follow it, and the island may share her secrets with you.");
            }
            // *** SECRET REWARD KEYWORD ***
            else if (speech.Contains("island"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The tides have not yet shifted—patience, sailor. The island does not reveal herself twice in one day.");
                }
                else
                {
                    Say("You have truly listened. Take this Treasure Chest of Madagascar—let it remind you of the island’s wild heart.");
                    from.AddToBackpack(new TreasureChestOfMadagascar());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the winds carry you safely, and the stars guide your journey.");
            }
            else
            {
                // Hint system
                if (Utility.RandomDouble() < 0.15)
                {
                    Say("Ask me of spices, Libertalia, lemurs, or the buried legends of this island.");
                }
            }

            base.OnSpeech(e);
        }

        public BetyOfBetsimisaraka(Serial serial) : base(serial) { }

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
