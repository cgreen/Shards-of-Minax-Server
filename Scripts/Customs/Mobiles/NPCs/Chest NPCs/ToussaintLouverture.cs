using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Toussaint Louverture")]
    public class ToussaintLouverture : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ToussaintLouverture() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Toussaint Louverture";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 85;
            Int = 110;
            Hits = 90;

            // Unique Appearance: Haitian Revolutionary Commander
            AddItem(new FancyShirt() { Name = "Azure Coat of Saint-Domingue", Hue = 1357 });
            AddItem(new Surcoat() { Name = "Crimson Surcoat of Freedom", Hue = 2113 });
            AddItem(new BodySash() { Name = "Gold Sash of Leadership", Hue = 2212 });
            AddItem(new TallStrawHat() { Name = "Commander’s Bicorne", Hue = 1175 });
            AddItem(new Boots() { Name = "Marching Boots of Revolution", Hue = 1157 });
            AddItem(new LeatherGloves() { Name = "Gloves of Unity", Hue = 1173 });

            // Weapon: Saber
            AddItem(new Cutlass() { Name = "Liberty’s Edge", Hue = 1176 });

            // Speech Hue
            SpeechHue = 2070;

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
                Say("I am Toussaint Louverture, the Lion of Saint-Domingue, who led the people of Haiti to freedom.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a slave, I rose to lead the revolution—my duty is to guard the spirit of liberty.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body was once shackled, but my mind and spirit have always been free.");
            }
            else if (speech.Contains("haiti"))
            {
                Say("Haiti is a land born from fire and courage. Our mountains still whisper of the fight for liberty.");
            }
            else if (speech.Contains("revolution"))
            {
                Say("The revolution was our storm—men and women, united for dignity and independence.");
            }
            else if (speech.Contains("slave") || speech.Contains("slavery"))
            {
                Say("Chains may bind the body, but never the will. Our ancestors dreamed of freedom, and we answered.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a flame, fragile yet eternal. Guard it well, for many wish to see it snuffed out.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("We honor the ancestors who fought before us. Their strength flows in our veins, and their songs guide us.");
            }
            else if (speech.Contains("saint-domingue"))
            {
                Say("Saint-Domingue was the name the French gave this land. We call it Haiti—mountainous and proud.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains sheltered our people, hiding freedom fighters from those who would see us chained.");
            }
            else if (speech.Contains("french"))
            {
                Say("The French ruled with cruelty, but even their armies could not crush the heart of Haiti.");
            }
            else if (speech.Contains("flame") || speech.Contains("fire"))
            {
                Say("Fire cleanses, and from the ashes, new life begins. Our liberty was born from fire and faith.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith is our compass, and hope is our shield. Together, they carried us through the darkness.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope can turn the smallest spark into a blazing sun. Never let it die.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not in gold, but in the unbroken will of a free people.");
            }
            else if (speech.Contains("leader") || speech.Contains("leadership"))
            {
                Say("A true leader serves the people. The Revolution was greater than any one man.");
            }
            else if (speech.Contains("lion"))
            {
                Say("They called me the Lion of Saint-Domingue. But every lion stands on the strength of their pride.");
            }
            else if (speech.Contains("pride"))
            {
                Say("Pride in our people gave us the courage to stand when others bowed.");
            }
            else if (speech.Contains("liberty"))
            {
                Say("Liberty is a song sung by many voices. Each generation must learn the words anew.");
            }
            else if (speech.Contains("voice") || speech.Contains("voices"))
            {
                Say("The voices of the past echo in every act of courage today. Listen, and you will hear them.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity made our dream possible. Divided, we were weak—together, we were unstoppable.");
            }
            else if (speech.Contains("dream"))
            {
                Say("Dreams are seeds. In Haitian soil, they blossom into revolution.");
            }
            else if (speech.Contains("soil") || speech.Contains("earth"))
            {
                Say("The earth of Haiti is rich, watered with both sorrow and hope.");
            }
            else if (speech.Contains("battle") || speech.Contains("war"))
            {
                Say("Many battles were fought on this soil, but the greatest victory was freedom for all.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Victory is never certain, but those who persevere earn the right to sing of it.");
            }
            else if (speech.Contains("persevere") || speech.Contains("perseverance"))
            {
                Say("Perseverance is the foundation of every revolution. Will you carry that flame forward?");
            }
            else if (speech.Contains("flame"))
            {
                Say("Every true flame, once lit, can ignite a thousand hearts.");
            }
            else if (speech.Contains("shackles") || speech.Contains("chains"))
            {
                Say("Our broken chains became the symbols of our nation. Wear them with pride, not shame.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith gave us strength. Even in the darkest nights, we believed the dawn would come.");
            }
            else if (speech.Contains("dawn") || speech.Contains("sunrise"))
            {
                Say("Every sunrise reminds us that freedom must be renewed with every day.");
            }
            else if (speech.Contains("fortune"))
            {
                Say("Fortune is fickle, but the courage to fight for what is right is eternal.");
            }
            else if (speech.Contains("eternal"))
            {
                Say("What is eternal cannot be burned or buried. The spirit of liberty endures.");
            }
            else if (speech.Contains("phoenix"))
            {
                Say("From ashes, a phoenix rises. So too did Haiti, from the ruins of oppression.");
            }
            else if (speech.Contains("sacrifice"))
            {
                Say("Freedom was paid for in blood and sacrifice. Honor those who gave everything.");
            }
            else if (speech.Contains("honor"))
            {
                Say("Honor the past, defend the present, and dream of the future.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those brave enough to shape it. What legacy will you leave?");
            }
			else if (speech.Contains("dessalines"))
			{
				Say("Jean-Jacques Dessalines was a brother in arms—fierce and relentless, he carried our struggle to its final victory.");
			}
			else if (speech.Contains("brother") || speech.Contains("sister") || speech.Contains("comrade"))
			{
				Say("No one fought alone. Each comrade’s courage became a shield for all of us.");
			}
			else if (speech.Contains("vodou") || speech.Contains("voodoo"))
			{
				Say("Vodou is the soul of our people—songs, prayers, and spirits joined in the fires of revolution.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits walk beside us: Ghede laughs, Ogou fights, Erzulie weeps, and all remember.");
			}
			else if (speech.Contains("ogou"))
			{
				Say("Ogou, the warrior spirit, blessed our blades and guided us through the smoke of battle.");
			}
			else if (speech.Contains("independence"))
			{
				Say("Independence was the promise that burned brightest in our hearts, even when the world doubted us.");
			}
			else if (speech.Contains("promise"))
			{
				Say("We made a promise to the unborn, to build a nation where no child would know chains.");
			}
			else if (speech.Contains("chains"))
			{
				Say("The sound of broken chains is sweeter than any music. It is the anthem of the free.");
			}
			else if (speech.Contains("music"))
			{
				Say("Music was our comfort and our rallying cry, from the fields to the barracks.");
			}
			else if (speech.Contains("barracks"))
			{
				Say("In the barracks, hope was forged in laughter and loyalty. Brotherhood held firm against despair.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Betrayal is a shadow on every struggle. Still, we placed trust in the dream of a new dawn.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams led us beyond the horizon, where freedom could be more than just a word.");
			}
			else if (speech.Contains("bayonet") || speech.Contains("musket"))
			{
				Say("We wielded muskets and bayonets taken from our enemies. Every weapon turned against oppression.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("An enemy today can become an ally tomorrow—if they choose justice over cruelty.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the harvest of struggle, reaped by those who never cease to sow courage.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is found not in the absence of fear, but in the will to stand when all others fall.");
			}
			else if (speech.Contains("fall") || speech.Contains("fallen"))
			{
				Say("We mourn the fallen and promise to carry their names on the wind. Their sacrifice was not in vain.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The wind over Haiti carries the stories of the old and the hopes of the young.");
			}
			else if (speech.Contains("young") || speech.Contains("children"))
			{
				Say("Children are the dream of tomorrow. It is for them that we broke the chains.");
			}
			else if (speech.Contains("colonial") || speech.Contains("colony"))
			{
				Say("Colonial rule left scars, but it also forged our unity. From suffering came solidarity.");
			}
			else if (speech.Contains("solidarity"))
			{
				Say("Solidarity gave us the strength of a thousand hearts. United, we became unstoppable.");
			}
			else if (speech.Contains("unstoppable"))
			{
				Say("An unstoppable people cannot be conquered—only delayed.");
			}
			else if (speech.Contains("delay") || speech.Contains("delayed"))
			{
				Say("Delays test our resolve, but our cause outlasted every obstacle.");
			}			
            else if (speech.Contains("legacy"))
            {
                Say("True legacy is carried not in gold, but in the hearts of the free.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs remember joy and sorrow—sing them to keep our story alive.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every life is a story; every story can inspire change.");
            }
            else if (speech.Contains("change"))
            {
                Say("Change is never easy, but it is the breath of history.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("phoenix"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience. Even the phoenix must rest before it rises again.");
                }
                else
                {
                    Say("You have spoken the word of rebirth. Accept this Treasure Chest of Haiti’s Legacy—may it keep the spirit of freedom burning in your soul.");
                    from.AddToBackpack(new TreasureChestOfHaitisLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with courage, and may the flame of liberty guide you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of liberty, ancestors, the revolution, or the fire that shaped Haiti.");
                }
            }

            base.OnSpeech(e);
        }

        public ToussaintLouverture(Serial serial) : base(serial) { }

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
