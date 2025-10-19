using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Farabundo Marti")]
    public class FarabundoMarti : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public FarabundoMarti() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Farabundo Martí";
            Body = 0x190; // Human male body

            // Unique Appearance: Salvadoran Revolutionary
            AddItem(new FormalShirt() { Name = "Shirt of the People's Voice", Hue = 2101 });
            AddItem(new GuildedKilt() { Name = "Kilt of Resistance", Hue = 2107 });
            AddItem(new BodySash() { Name = "Red Sash of Martyrs", Hue = 1157 });
            AddItem(new Cloak() { Name = "Cloak of El Bálsamo", Hue = 1165 });
            AddItem(new Sandals() { Name = "Sandals of the Journey", Hue = 1118 });
            AddItem(new FeatheredHat() { Name = "Hat of Hope", Hue = 2103 });
            AddItem(new ShortSpear() { Name = "Staff of Justice", Hue = 1172 });

            // Speech Hue
            SpeechHue = 2110;

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
                Say("I am Farabundo Martí, a son of El Salvador and servant of her people.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some called me a revolutionary. I call myself a defender of the campesino.");
            }
            else if (speech.Contains("health"))
            {
                Say("My life was taken by violence, but my hope still burns in the hearts of the people.");
            }
            else if (speech.Contains("el salvador") || speech.Contains("salvador"))
            {
                Say("El Salvador is a land of volcanoes, rivers, and struggle—her story is written in both pain and hope.");
            }
            else if (speech.Contains("people"))
            {
                Say("The people are the heart of our land. Their labor, their songs, their dreams—they are why I fought.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice is born in the fields and streets. Too often, it is drowned by oppression.");
            }
            else if (speech.Contains("rebellion"))
            {
                Say("We rose in rebellion against injustice, but the path was marked by blood and sacrifice.");
            }
            else if (speech.Contains("coffee"))
            {
                Say("Coffee brought wealth to the few and misery to the many. The campesinos toiled so others might profit.");
            }
            else if (speech.Contains("struggle"))
            {
                Say("Struggle is the story of El Salvador—each generation, a new battle for dignity.");
            }
            else if (speech.Contains("campesino") || speech.Contains("campesinos"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The campesino knows patience. Return when the sun is higher in the sky, compañero.");
                }
                else
                {
                    Say("The campesino is the root of our nation. Accept this Treasure Chest of El Salvador's History—let the memory of our struggle live on.");
                    from.AddToBackpack(new TreasureChestOfElSalvadorHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("oppression"))
            {
                Say("Oppression is a heavy shadow. Only by standing together can we break its hold.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is not silence; it is justice and dignity for all.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope grows wild, even on broken ground. The people water it with dreams.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is the seed of the future. Do not let our story be forgotten.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Rivers like the Lempa nourish our fields—and sometimes carry away our tears.");
            }
            else if (speech.Contains("volcano") || speech.Contains("volcanoes"))
            {
                Say("Volcanoes watch over El Salvador, silent and strong. Like the people, they endure and sometimes erupt.");
            }
            else if (speech.Contains("dreams") || speech.Contains("dream"))
            {
                Say("Dreams are the banners we raise when the world grows dark. Never lower yours.");
            }
            else if (speech.Contains("martyrs") || speech.Contains("martyr"))
            {
                Say("Martyrs do not die—they become the roots of the next harvest of freedom.");
            }
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is born not from words, but from sacrifice and unity. Every step toward justice is a victory.");
			}
			else if (speech.Contains("unity"))
			{
				Say("Unity among the humble is feared by those in power. When we stand together, mountains move.");
			}
			else if (speech.Contains("songs") || speech.Contains("song"))
			{
				Say("Our songs carry the sorrow and joy of the people. Even in darkness, we sing of dawn.");
			}
			else if (speech.Contains("dawn"))
			{
				Say("Dawn is never far, no matter how long the night. The struggle makes its arrival sweeter.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("Harvest should bring abundance, but too often, it brings hunger for the poor and gold for the few.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold cannot buy justice, nor heal the wounds of the earth. True wealth is the laughter of children and the courage to dream.");
			}
			else if (speech.Contains("children") || speech.Contains("child"))
			{
				Say("Children carry the promise of a future without chains. Teach them hope, not fear.");
			}
			else if (speech.Contains("teach") || speech.Contains("teaching"))
			{
				Say("Teaching is the seed of change. Ignite minds, and tyrants will tremble.");
			}
			else if (speech.Contains("tyrant") || speech.Contains("tyrants"))
			{
				Say("Tyrants rise where silence reigns. Raise your voice—be the storm that sweeps away injustice.");
			}
			else if (speech.Contains("storm"))
			{
				Say("Storms test our roots. When the wind dies, the strongest trees remain.");
			}
			else if (speech.Contains("roots"))
			{
				Say("Roots bind us to the land and to each other. Forget them, and we wither.");
			}
			else if (speech.Contains("tradition") || speech.Contains("traditions"))
			{
				Say("Traditions are the stories of our ancestors, woven into every field and village.");
			}
			else if (speech.Contains("village"))
			{
				Say("Every village in El Salvador is a lantern in the night—each with its own tales, its own heroes.");
			}
			else if (speech.Contains("hero") || speech.Contains("heroes"))
			{
				Say("Heroes are not born—they are made by the courage to rise when hope is frail.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the will to act despite it.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Fear is a weapon used by those in power. Face it, and you take back your freedom.");
			}
			else if (speech.Contains("power"))
			{
				Say("Power belongs with the people. Never surrender it to those who forget your pain.");
			}			
            else if (speech.Contains("land") || speech.Contains("earth"))
            {
                Say("The land is sacred. To love her is to defend her children.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who never surrender their dreams.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Carry the story of El Salvador with you, wherever you travel.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of justice, coffee, rebellion, or the campesinos of El Salvador.");
                }
            }

            base.OnSpeech(e);
        }

        public FarabundoMarti(Serial serial) : base(serial) { }

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
