using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Jeanne d'Arc")]
    public class JeanneDArc : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public JeanneDArc() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Jeanne d'Arc";
            Body = 0x191; // Human female body

            // Unique Appearance: A mix of peasant and knight
            AddItem(new FancyShirt() { Name = "Blouse of Domrémy", Hue = 1150 });
            AddItem(new LeatherGorget() { Name = "Martyr's Gorget", Hue = 1107 });
            AddItem(new StuddedChest() { Name = "Armor of Inspiration", Hue = 2420 });
            AddItem(new FancyKilt() { Name = "Kirtle of Liberation", Hue = 2601 });
            AddItem(new Cloak() { Name = "Saintly Banner Cloak", Hue = 1153 });
            AddItem(new Sandals() { Name = "Humble Pilgrim’s Sandals", Hue = 2506 });
            AddItem(new FeatheredHat() { Name = "Laurel of Courage", Hue = 1161 });

            // Weapon: Longsword and Banner
            AddItem(new Longsword() { Name = "Blade of Orleans", Hue = 1177 });
            AddItem(new BodySash() { Name = "Banner of the Maid", Hue = 2063 });

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
                Say("I am Jeanne d'Arc, called the Maid of Orléans. My name lives in both hope and flame.");
            }
            else if (speech.Contains("job"))
            {
                Say("My purpose was revealed to me: to drive the invader from France and crown the true king in Reims.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body bears many scars, but faith and duty give me strength.");
            }
            else if (speech.Contains("maid"))
            {
                Say("They call me the Maid of Orléans, for I led France's sons and daughters in their hour of need.");
            }
            else if (speech.Contains("orleans"))
            {
                Say("At Orléans, France was reborn. The English siege was broken by courage, faith, and the will of a united people.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith is my armor; it shields the heart in darkest night. Ask of my visions if you wish to know more.");
            }
            else if (speech.Contains("vision") || speech.Contains("visions"))
            {
                Say("Since I was but a child, I heard the voices of saints: Michael, Catherine, and Margaret. Their message was clear—France must be free.");
            }
            else if (speech.Contains("saint") || speech.Contains("saints"))
            {
                Say("Saint Michael, Saint Catherine, Saint Margaret—they guided my hand and steeled my resolve.");
            }
            else if (speech.Contains("france"))
            {
                Say("France is my heart, wounded yet unbroken. Its soil holds stories of kings, peasants, and martyrs.");
            }
            else if (speech.Contains("king"))
            {
                Say("Charles, the dauphin, was crowned king at Reims with my banner beside him. It was a day of prophecy fulfilled.");
            }
            else if (speech.Contains("banner"))
            {
                Say("My banner showed Christ in judgment and two angels. It gave courage to all who followed it.");
            }
            else if (speech.Contains("enemy") || speech.Contains("english"))
            {
                Say("The English believed France would bend. They did not know the power of faith, or the fury of the downtrodden.");
            }
            else if (speech.Contains("battle"))
            {
                Say("Each battle tests both steel and spirit. True victory is found in courage, not just in conquest.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is to act when the soul trembles and hope is dim. Even the smallest light defies the night.");
            }
            else if (speech.Contains("domremy"))
            {
                Say("I was born in Domrémy, a humble village. From quiet beginnings, even destiny may rise.");
            }
            else if (speech.Contains("destiny"))
            {
                Say("Destiny calls us all, though few dare answer. The voices shaped mine—ask of my voices if you wish.");
            }
            else if (speech.Contains("voices"))
            {
                Say("Heavenly voices guided me to the king and to Orléans. Some call it madness, others a miracle.");
            }
			else if (speech.Contains("hope"))
			{
				Say("Hope is the dawn after the longest night. Even in despair, a single voice can call forth the light.");
			}
			else if (speech.Contains("women") || speech.Contains("woman"))
			{
				Say("Some doubted a woman could lead armies or inspire kings. Yet the heart of a nation knows no such bounds.");
			}
			else if (speech.Contains("doubt") || speech.Contains("doubted"))
			{
				Say("Doubt followed me like a shadow, but the voices were brighter. Courage is to act while doubting.");
			}
			else if (speech.Contains("forgive") || speech.Contains("forgiveness"))
			{
				Say("Forgiveness is the highest grace. Even those who condemned me cannot silence my prayer for peace.");
			}
			else if (speech.Contains("church"))
			{
				Say("The church judged me harshly, but true faith dwells in the soul, not in earthly courts.");
			}
			else if (speech.Contains("sword"))
			{
				Say("My sword was found behind the altar at Sainte-Catherine-de-Fierbois. Some say it was destiny’s blade.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("Prophecies foretold of a Maid who would save France. I listened not for greatness, but for truth.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("Legacy is the seed we plant in the hearts of others. May mine bloom in courage, not bitterness.");
			}			
            else if (speech.Contains("madness"))
            {
                Say("Madness or miracle—history will choose its name. But I know what I have seen.");
            }
            else if (speech.Contains("fire") || speech.Contains("flame"))
            {
                Say("The fire meant for destruction became a beacon. My end was not silence, but the spark of legend.");
            }
            else if (speech.Contains("trial"))
            {
                Say("My trial was cruel and unjust. Yet I spoke my truth, and the world listened.");
            }
            else if (speech.Contains("martyr"))
            {
                Say("A martyr’s fate awaited me in Rouen. My body perished, but my cause did not.");
            }
            else if (speech.Contains("rouen"))
            {
                Say("Rouen was the place of my final hours. Yet my memory rides every wind across France.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is immortal. Even when flesh fails, the story endures.");
            }
            else if (speech.Contains("miracle"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A true miracle is never repeated for the impatient. Return when your heart is ready.");
                }
                else
                {
                    Say("You have followed faith and courage to the end. Accept this Treasure Chest of French History, and let it remind you that every age has its heroes.");
                    from.AddToBackpack(new TreasureChestOfFrenchHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with faith. The voices of the past walk beside you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Orléans, faith, banners, or miracles. My story is yours to discover.");
                }
            }

            base.OnSpeech(e);
        }

        public JeanneDArc(Serial serial) : base(serial) { }

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
