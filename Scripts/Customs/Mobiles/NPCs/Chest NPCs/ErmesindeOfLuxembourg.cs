using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Countess Ermesinde")]
    public class ErmesindeOfLuxembourg : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ErmesindeOfLuxembourg() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Countess Ermesinde";
            Title = "of Luxembourg";
            Body = 0x191; // Human female

            // Unique, themed outfit:
            AddItem(new FancyDress() { Name = "Gown of the Alzette Valley", Hue = 2750 });
            AddItem(new Cloak() { Name = "Mantle of the Three Towers", Hue = 2433 });
            AddItem(new BodySash() { Name = "Sash of the Red Lion", Hue = 2112 });
            AddItem(new FlowerGarland() { Name = "Garland of Spring", Hue = 1175 });
            AddItem(new Sandals() { Name = "Sandals of the Quiet River", Hue = 1151 });

            // Iconic weapon for a ruler, symbolic:
            AddItem(new Scepter() { Name = "Scepter of Unity", Hue = 1289 });

            SpeechHue = 2122;

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
                Say("I am Ermesinde, Countess of Luxembourg, guardian of my people and their dreams.");
            }
            else if (speech.Contains("job"))
            {
                Say("I guide my county through peril and peace, weaving unity where there is discord.");
            }
            else if (speech.Contains("health"))
            {
                Say("I am strong, for Luxembourg needs a steady hand. But my heart aches for those lost in strife.");
            }
            else if (speech.Contains("luxembourg"))
            {
                Say("Luxembourg is a small but proud land, nestled between great realms, rich in spirit and song.");
            }
            else if (speech.Contains("history"))
            {
                Say("Our history is one of endurance—castles, rivers, and a people who will not yield.");
            }
            else if (speech.Contains("castle"))
            {
                Say("Luxembourg Castle rises above the Alzette valley, a beacon and a shield for our people.");
            }
            else if (speech.Contains("alzette"))
            {
                Say("The Alzette River winds through our valleys, carrying secrets and shaping destinies.");
            }
            else if (speech.Contains("valley"))
            {
                Say("The valley cradles our home. Its mists hold whispers of both joy and sorrow.");
            }
            else if (speech.Contains("lion"))
            {
                Say("The red lion is our banner, fierce and unbroken, a symbol for all Luxembourgers.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity was hard-won. I gathered many lands under one crown, not by war, but by resolve.");
            }
            else if (speech.Contains("resolve"))
            {
                Say("Resolve is forged in quiet moments and hard decisions. It’s what holds a realm together.");
            }
            else if (speech.Contains("ruler") || speech.Contains("countess"))
            {
                Say("A ruler is nothing without her people. I rule not for power, but for the future of Luxembourg.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future is a tapestry. Each of us adds a thread—what will yours be?");
            }
            else if (speech.Contains("people"))
            {
                Say("My people are farmers, masons, scholars—together, we are stronger than any single blade.");
            }
            else if (speech.Contains("tower") || speech.Contains("towers"))
            {
                Say("The three towers guard our city—echoes of vigilance, strength, and hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is a candle in the dark. Even when threatened, we did not let it be snuffed out.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Luxembourg’s songs tell of courage and kindness, carried on the evening breeze.");
            }
            else if (speech.Contains("inheritance"))
            {
                Say("I inherited a divided land, yet I strove to leave a realm united in peace.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a garden—fragile, beautiful, and worth tending every day.");
            }
            else if (speech.Contains("garden"))
            {
                Say("Our gardens bloom with tulips and violets, a sign that spring always returns.");
            }
            else if (speech.Contains("spring"))
            {
                Say("Spring brings renewal, washing away old wounds. So too must we forgive and begin anew.");
            }
            else if (speech.Contains("forgive") || speech.Contains("forgiveness"))
            {
                Say("Forgiveness is not forgetting, but choosing hope over anger. It is the seed of unity.");
            }
            else if (speech.Contains("strife"))
            {
                Say("Strife has shadowed my reign, yet I never lost faith in my people.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith means trusting in light beyond the next hill, even if you cannot yet see it.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not stone or gold, but a future for Luxembourg’s children.");
            }
            else if (speech.Contains("children"))
            {
                Say("Children are the truest treasure of any land. Their laughter is a promise.");
            }
            else if (speech.Contains("promise"))
            {
                Say("A promise, once given, is sacred. I swore to protect my people, and so I have.");
            }
            else if (speech.Contains("sacred"))
            {
                Say("Our land is sacred to us—rivers, hills, even the smallest cobblestone is part of our story.");
            }
			else if (speech.Contains("ancestry") || speech.Contains("lineage"))
			{
				Say("I am of the house of Namur and Dagsburg. My bloodline carries the hopes and burdens of many lands.");
			}
			else if (speech.Contains("namur"))
			{
				Say("Namur lies to the west, across forest and river. It was my mother’s homeland, and source of many lessons.");
			}
			else if (speech.Contains("mother"))
			{
				Say("My mother, Agnes of Guelders, was a woman of strength and wisdom. Her counsel was as steady as the old oaks.");
			}
			else if (speech.Contains("oath"))
			{
				Say("Upon my father’s passing, I took an oath to defend Luxembourg and keep her united. An oath I have never broken.");
			}
			else if (speech.Contains("war"))
			{
				Say("War often shadowed our borders. But diplomacy and patience earned victories the sword could not.");
			}
			else if (speech.Contains("peace treaty") || speech.Contains("treaty"))
			{
				Say("The Treaty of Dinant brought longed-for peace to our lands. A single quill can sometimes outweigh a hundred blades.");
			}
			else if (speech.Contains("nobility") || speech.Contains("court"))
			{
				Say("The court is a place of whispers and waltzes, ambition and alliance. Trust is our rarest coin.");
			}
			else if (speech.Contains("festival") || speech.Contains("festivals"))
			{
				Say("In summer, our festivals fill the streets with color and laughter. The Schueberfouer is a joy to behold.");
			}
			else if (speech.Contains("schueberfouer"))
			{
				Say("The Schueberfouer is our great fair, begun in 1340. It celebrates our spirit—come, and taste our pastries and cider!");
			}
			else if (speech.Contains("cider"))
			{
				Say("Luxembourg’s cider is sweet as a May morning. The apple orchards along the Moselle are famed throughout the realm.");
			}
			else if (speech.Contains("moselle"))
			{
				Say("The Moselle River flows east, bringing trade, travelers, and the promise of new beginnings.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade sustains our people. Cloth from Flanders, wines from the Moselle, and wisdom from every land.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is gathered like herbs—patiently, and from many fields. Never be afraid to ask, or to learn.");
			}
			else if (speech.Contains("herbs") || speech.Contains("garden"))
			{
				Say("In my gardens, I grow sage, thyme, and lavender. Their scents are a balm after long days.");
			}
			else if (speech.Contains("lavender"))
			{
				Say("Lavender grows well in our valleys. It calms the mind and soothes troubled dreams.");
			}
			else if (speech.Contains("dreams") || speech.Contains("night"))
			{
				Say("In the quiet of night, I dream of a Luxembourg at peace, where every child can sleep safely.");
			}
			else if (speech.Contains("childhood"))
			{
				Say("As a child, I wandered the castle halls and climbed the old sycamore. The world seemed both vast and safe.");
			}
			else if (speech.Contains("castle halls") || speech.Contains("sycamore"))
			{
				Say("The ancient sycamore still stands in the courtyard. Its roots hold memories deeper than stone.");
			}
			else if (speech.Contains("stone"))
			{
				Say("Every stone of Luxembourg was set by hands long gone. To forget them would be to lose ourselves.");
			}
			else if (speech.Contains("memory") || speech.Contains("memories"))
			{
				Say("Memories are lanterns on a dark road—guiding, warning, and sometimes bringing comfort.");
			}
			else if (speech.Contains("comfort"))
			{
				Say("A kind word or warm hearth can be a greater comfort than gold, especially in times of sorrow.");
			}
			else if (speech.Contains("sorrow") || speech.Contains("loss"))
			{
				Say("All rulers know sorrow. But we carry on—for ourselves, and for those who depend on us.");
			}			
            else if (speech.Contains("story"))
            {
                Say("Stories keep our past alive. Ask, and I will share one from the valley’s heart.");
            }
            else if (speech.Contains("mist") || speech.Contains("mists"))
            {
                Say("The valley mists cloak old secrets. Only the curious ever find what lies hidden within.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("curious"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. The valley’s secrets are not given twice in one day.");
                }
                else
                {
                    Say("Your curiosity is worthy. Accept this Treasure Chest of Luxembourg—may it bring you fortune and knowledge.");
                    from.AddToBackpack(new TreasureChestOfLuxembourg());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Farewell, traveler. May the mists part for you, wherever you go.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of castles, the red lion, or the mists of the Alzette valley.");
                }
            }

            base.OnSpeech(e);
        }

        public ErmesindeOfLuxembourg(Serial serial) : base(serial) { }

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
