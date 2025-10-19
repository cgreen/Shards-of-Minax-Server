using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Princess Elisabeth")]
    public class PrincessElisabeth : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public PrincessElisabeth() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Princess Elisabeth von Guttenberg";
            Body = 0x191; // Human female body

            // Unique Appearance: Liechtensteiner Noblewoman
            AddItem(new FancyDress() { Name = "Dress of Alpine Sovereignty", Hue = 2650 });
            AddItem(new Cloak() { Name = "Mantle of the Rhine Mists", Hue = 2001 });
            AddItem(new BodySash() { Name = "Sash of the Vaduz Nobility", Hue = 2220 });
            AddItem(new FeatheredHat() { Name = "Courtier’s Plumed Hat of Schellenberg", Hue = 2505 });
            AddItem(new FurBoots() { Name = "Boots of the Winter Wacht", Hue = 1170 });
            AddItem(new MeditationFans() { Name = "Hand-Fan of Peaceful Accord", Hue = 1153 });

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
                Say("I am Princess Elisabeth von Guttenberg of Liechtenstein, at your service.");
            }
            else if (speech.Contains("job"))
            {
                Say("I serve as a steward of peace and culture for our people, guardian of our tiny but proud land.");
            }
            else if (speech.Contains("health"))
            {
                Say("My health is as strong as the mountain air of the Rätikon—invigorating and ever fresh!");
            }
            else if (speech.Contains("liechtenstein"))
            {
                Say("Liechtenstein is a principality nestled between the Rhine and the mountains. Small in size, but rich in spirit.");
            }
            else if (speech.Contains("prince") || speech.Contains("princess"))
            {
                Say("Our princes and princesses have always cherished wisdom and harmony over war and conquest.");
            }
            else if (speech.Contains("vaduz"))
            {
                Say("Vaduz, our capital, is home to both the princely castle and the fabled rose garden. Have you ever visited?");
            }
            else if (speech.Contains("castle"))
            {
                Say("Vaduz Castle sits high above the valley, watching over the land as a symbol of our independence.");
            }
            else if (speech.Contains("garden") || speech.Contains("rose"))
            {
                Say("The rose garden is our hidden sanctuary. Within its walls, secrets of peace and hope have quietly bloomed.");
            }
            else if (speech.Contains("rhine"))
            {
                Say("The Rhine River defines our border and nourishes our fields. It is our silent ally.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Our mountains protect us and shape our character—steadfast and resilient.");
            }
            else if (speech.Contains("freedom") || speech.Contains("independence"))
            {
                Say("Independence is precious. Many sought to claim our land, but we endured through wit and diplomacy.");
            }
            else if (speech.Contains("diplomacy") || speech.Contains("peace"))
            {
                Say("Diplomacy has always been our shield. Peace, our greatest aspiration.");
            }
            else if (speech.Contains("arts"))
            {
                Say("The arts flourish here, from delicate sculpture to lively festivals. Creation is our legacy.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("True legacy is not measured in gold, but in the hearts you touch and the beauty you inspire.");
            }
            else if (speech.Contains("festival") || speech.Contains("festivals"))
            {
                Say("Festivals bring our valleys alive—music, dance, and laughter under the summer sky.");
            }
            else if (speech.Contains("secret"))
            {
                Say("Liechtenstein holds many secrets, tucked away in castles, mountains, and blooming roses.");
            }
			else if (speech.Contains("guttenberg"))
			{
				Say("My family, the Guttenbergs, has served Liechtenstein for generations, weaving our fate with that of this land.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the root from which our dreams and duties grow. Mine has always valued learning and loyalty.");
			}
			else if (speech.Contains("history"))
			{
				Say("History is our teacher. Liechtenstein was once just two lordships—Vaduz and Schellenberg—united in perseverance.");
			}
			else if (speech.Contains("schellenberg"))
			{
				Say("Schellenberg is a gentle land of rolling hills. Its fields and traditions are dear to our hearts.");
			}
			else if (speech.Contains("united"))
			{
				Say("When Vaduz and Schellenberg united, it marked the true birth of our principality. Together, we are stronger.");
			}
			else if (speech.Contains("title"))
			{
				Say("The title of 'Prince of Liechtenstein' came not from war, but from wisdom and the Emperor's favor.");
			}
			else if (speech.Contains("emperor"))
			{
				Say("The Holy Roman Emperor granted us recognition, securing our independence in a time of shifting powers.");
			}
			else if (speech.Contains("alliance"))
			{
				Say("Wise alliances have protected Liechtenstein through storms that toppled many kingdoms.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms pass over our mountains, but our resolve remains, as steady as the stones of Vaduz Castle.");
			}
			else if (speech.Contains("castle"))
			{
				Say("Within Vaduz Castle, tales of courage and cleverness echo through the centuries.");
			}
			else if (speech.Contains("treasure"))
			{
				Say("Treasure takes many forms—friendship, wisdom, and sometimes, the laughter of children at festival.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are the future of Liechtenstein. Their joy is the song that keeps our valleys bright.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Music brings us together—at harvest, festival, and even beneath the rose-laden arches of our garden.");
			}
			else if (speech.Contains("arche"))
			{
				Say("The rose garden’s arched trellis is a place of quiet reflection. Many secrets have passed beneath its blossoms.");
			}
			else if (speech.Contains("reflection"))
			{
				Say("Reflection brings wisdom, just as the Rhine reflects the sky and mountains in its flowing waters.");
			}
			else if (speech.Contains("sky"))
			{
				Say("On a clear day, our sky stretches endlessly, promising freedom and gentle hope.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is Liechtenstein’s greatest inheritance. It endures, quietly blooming, like the roses in our garden.");
			}
			else if (speech.Contains("festival"))
			{
				Say("At festival time, you will find color and song in every village—join us, and be welcomed as family.");
			}			
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is found by listening—to people, to the land, and sometimes, to the roses.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("rose"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("All good things in Liechtenstein bloom only for the patient. Return later, dear guest.");
                }
                else
                {
                    Say("You have found the heart of Liechtenstein—a secret blooming quietly among the roses. Accept this Treasure Chest of Liechtenstein, and may fortune flower in your path.");
                    from.AddToBackpack(new TreasureChestOfLiechtenstein());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your journey be gentle, and your days bright as the valley in spring.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Rhine, the rose garden, Vaduz Castle, or the mountain festivals of our land.");
                }
            }

            base.OnSpeech(e);
        }

        public PrincessElisabeth(Serial serial) : base(serial) { }

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
