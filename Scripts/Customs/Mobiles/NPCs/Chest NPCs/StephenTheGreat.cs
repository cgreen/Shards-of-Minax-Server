using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Stephen the Great")]
    public class StephenTheGreat : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public StephenTheGreat() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Stephen the Great";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 80;
            Int = 95;
            Hits = 120;

            // Unique Regal Moldovan Appearance
            AddItem(new FormalShirt() { Name = "Royal Tunic of Suceava", Hue = 1170 });
            AddItem(new GuildedKilt() { Name = "Embroidered Kilt of Moldovan Nobility", Hue = 1364 });
            AddItem(new Cloak() { Name = "Cloak of the Prut River", Hue = 2977 });
            AddItem(new Circlet() { Name = "Crown of the Voivode", Hue = 2100 });
            AddItem(new FurBoots() { Name = "Boots of the Monastery Road", Hue = 1109 });
            AddItem(new BodySash() { Name = "Sash of the Order of Saint George", Hue = 1151 });

            // Weapon: Sword
            AddItem(new Longsword() { Name = "The Voivode's Blade", Hue = 2405 });

            // Armor: A touch of ceremonial
            AddItem(new PlateGorget() { Name = "Gorget of Chivalric Oath", Hue = 1317 });

            // Speech Hue
            SpeechHue = 2120;

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
                Say("I am Stephen the Great, Voivode of Moldavia, servant of my people and defender of the land.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to guard Moldavia from invaders and keep faith with my ancestors.");
            }
            else if (speech.Contains("health"))
            {
                Say("Many wounds have I endured, yet the spirit of Moldavia keeps me standing.");
            }
            else if (speech.Contains("moldavia"))
            {
                Say("Moldavia is a land of forests and rivers, born between the Carpathians and the Dniester.");
            }
            else if (speech.Contains("voivode") || speech.Contains("ruler"))
            {
                Say("A voivode must lead in battle and in prayer, for both sword and soul shape a nation.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith guides our hand in darkness. After each victory, I raised churches in thanks.");
            }
            else if (speech.Contains("battle") || speech.Contains("war"))
            {
                Say("I faced the Ottomans, Hungarians, and Poles. The price of peace is ever paid in blood and steel.");
            }
            else if (speech.Contains("church") || speech.Contains("monastery"))
            {
                Say("I built many churches and monasteries—stone prayers that stand long after the sword is sheathed.");
            }
            else if (speech.Contains("victory"))
            {
                Say("After every victory, a church would rise—reminder that all triumph is but a gift.");
            }
            else if (speech.Contains("ottoman") || speech.Contains("turk"))
            {
                Say("The Ottoman sultan sent many armies. We answered with courage and cunning in the forests of Vaslui.");
            }
            else if (speech.Contains("vaslui"))
            {
                Say("At Vaslui, the winter mist hid our army. Against all odds, we drove the invaders back to their empire.");
            }
            else if (speech.Contains("empire") || speech.Contains("sultan"))
            {
                Say("No empire endures forever. It is the will of the people that shapes history.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not gold nor glory, but the freedom and faith of Moldavia’s people.");
            }
            else if (speech.Contains("river") || speech.Contains("prut") || speech.Contains("dniester"))
            {
                Say("The rivers Prut and Dniester are the veins of our land. They witness both war and peace.");
            }
            else if (speech.Contains("carpathian") || speech.Contains("mountain"))
            {
                Say("The Carpathians shield us, their forests sheltering both wolves and warriors.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("We walk the paths our ancestors forged—each generation adding stones to the road ahead.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom as you would a well in the dry season—it will quench your thirst in times of need.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the right of every soul, earned anew with each dawn.");
            }
            else if (speech.Contains("churches") || speech.Contains("pilgrim"))
            {
                Say("Many come as pilgrims to the churches we raised, seeking solace or forgiveness.");
            }
            else if (speech.Contains("solace") || speech.Contains("forgiveness"))
            {
                Say("In the shadows of ancient walls, both solace and forgiveness can be found.");
            }
            else if (speech.Contains("history"))
            {
                Say("Moldova's history is written in courage and sacrifice. Will you add your chapter?");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is the truest victory—though it must often be guarded by the sword.");
            }
            else if (speech.Contains("shield"))
            {
                Say("A shield is more than steel—it is resolve, held firm against the storm.");
            }
			else if (speech.Contains("fortress") || speech.Contains("fortresses"))
			{
				Say("Our fortresses stand as sentinels across Moldavia—Hotin, Suceava, Soroca. Their stones remember every siege.");
			}
			else if (speech.Contains("hotin"))
			{
				Say("Hotin Fortress withstood many assaults. Its towers watch over the river, unyielding as the will of our people.");
			}
			else if (speech.Contains("soroca"))
			{
				Say("Soroca guards the north, where steppe meets forest. From its walls, you can see the Dniester shimmer.");
			}
			else if (speech.Contains("siege"))
			{
				Say("A siege tests not only strength, but patience. Hunger and hope are both powerful weapons.");
			}
			else if (speech.Contains("alliance") || speech.Contains("allies"))
			{
				Say("I forged alliances with Wallachia, Poland, and Hungary, each as changeable as the wind.");
			}
			else if (speech.Contains("betrayal") || speech.Contains("traitor"))
			{
				Say("Trust, once broken, is slow to mend. Betrayal can wound deeper than any blade.");
			}
			else if (speech.Contains("family"))
			{
				Say("My family is my anchor. My mother, Oltea, was my first teacher in both courage and faith.");
			}
			else if (speech.Contains("mother") || speech.Contains("oltea"))
			{
				Say("Oltea, my mother, taught me to pray with humility and to lead with honor.");
			}
			else if (speech.Contains("flag") || speech.Contains("banner"))
			{
				Say("Our banner—blue, red, and yellow—waves in the winds of both peace and war.");
			}
			else if (speech.Contains("legend") || speech.Contains("stories"))
			{
				Say("Stories are as vital as bread. Have you heard the legend of the aurochs’ head?");
			}
			else if (speech.Contains("aurochs") || speech.Contains("head"))
			{
				Say("The aurochs’ head is our symbol—strength and vigilance. It reminds us that even the wildest beast can be tamed by courage.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("In times of uncertainty, seek counsel from both the old and the young. Wisdom hides in unexpected places.");
			}
			else if (speech.Contains("enemy") || speech.Contains("foe"))
			{
				Say("Respect your enemies, for they teach you the measure of your own resolve.");
			}
			else if (speech.Contains("banquet"))
			{
				Say("Victory is sweet, but a simple meal shared with loyal friends brings the truest joy.");
			}
			else if (speech.Contains("wine"))
			{
				Say("The vineyards of Cotnari yield wines as golden as a sunrise over the fields of Moldova.");
			}
			else if (speech.Contains("cotnari"))
			{
				Say("Cotnari is famous for its vineyards. A cup of its wine brings warmth even on the coldest night.");
			}
			else if (speech.Contains("justice"))
			{
				Say("A ruler must be just above all else. Justice for the poor binds a land together.");
			}
			else if (speech.Contains("judgement"))
			{
				Say("Judgement is a burden. To weigh the fate of others is to carry their sorrows upon your shoulders.");
			}
			else if (speech.Contains("blessing") || speech.Contains("blessings"))
			{
				Say("Each day is a blessing. Never forget to give thanks—for life, for loved ones, and for the land beneath your feet.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("To know your enemies is to know yourself. Even the fiercest foe can teach wisdom, if you listen.");
			}			
            else if (speech.Contains("destiny"))
            {
                Say("Destiny is a road paved with both triumph and trial. Walk it with honor.");
            }
            else if (speech.Contains("great"))
            {
                Say("Greatness lies not in title, but in steadfastness through hardship.");
            }
            else if (speech.Contains("romania") || speech.Contains("romanian"))
            {
                Say("Our fate is bound with Wallachia and Transylvania—three petals of the same rose.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("pilgrimage"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True reward comes only to the patient. The journey must not be hurried.");
                }
                else
                {
                    Say("Your pilgrimage of curiosity is honored. Take this Treasure Chest of Moldovan History, and may it guide your path.");
                    from.AddToBackpack(new TreasureChestOfMoldovanHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go forth with courage and wisdom. Moldova remembers her friends.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of battle, pilgrimage, Vaslui, or the churches of Moldavia.");
                }
            }

            base.OnSpeech(e);
        }

        public StephenTheGreat(Serial serial) : base(serial) { }

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
