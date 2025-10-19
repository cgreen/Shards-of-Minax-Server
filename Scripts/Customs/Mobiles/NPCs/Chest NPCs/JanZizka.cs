using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Jan Zizka")]
    public class JanZizka : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public JanZizka() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Jan Žižka";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 80;
            Int = 90;
            Hits = 95;

            // Unique Appearance: Hussite General
            AddItem(new HeavyPlateJingasa() { Name = "Žižka’s Iron War Hat", Hue = 2105 });
            AddItem(new FurSarong() { Name = "Mantle of Tábor", Hue = 2402 });
            AddItem(new LeatherGloves() { Name = "Peasant’s Gauntlets", Hue = 1172 });
            AddItem(new ElvenShirt() { Name = "Bohemian Linen Undershirt", Hue = 1157 });
            AddItem(new GuildedKilt() { Name = "Banner of the Hussites", Hue = 2220 });
            AddItem(new FurBoots() { Name = "Boots of Blaník", Hue = 2515 });
            AddItem(new BodySash() { Name = "Sash of Victory at Vítkov Hill", Hue = 1209 });

            // Weapon: War Mace (Flail)
            AddItem(new WarMace() { Name = "Flail of the One-Eyed General", Hue = 2118 });

            // Speech Hue
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
                Say("I am Jan Žižka of Trocnov, general of the Hussites and defender of Bohemia.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was a commander, a peasant, and a protector of my people in times of faith and fire.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body bore many wounds, but I fought until my last breath—and even after I lost my sight, I led my armies.");
            }
            else if (speech.Contains("hussite"))
            {
                Say("The Hussites fought for freedom of faith and the rights of common folk, raising banners of chalice and hope.");
            }
            else if (speech.Contains("bohemia") || speech.Contains("czech"))
            {
                Say("Bohemia is my homeland, land of rivers and castles, where courage outlives kings.");
            }
            else if (speech.Contains("battle") || speech.Contains("war"))
            {
                Say("I never lost a battle. Our secret? Clever tactics, loyal hearts, and the strength of peasants united.");
            }
            else if (speech.Contains("trocnov"))
            {
                Say("Trocnov was my birthplace, a humble village that forged my resolve.");
            }
            else if (speech.Contains("eye") || speech.Contains("one-eyed"))
            {
                Say("I lost one eye in battle, and later both. Yet I saw more clearly than most.");
            }
            else if (speech.Contains("faith") || speech.Contains("chalice"))
            {
                Say("The chalice was our symbol—the promise that faith belongs to all, not just the mighty.");
            }
            else if (speech.Contains("tabor"))
            {
                Say("Tábor was our stronghold, a city of hope raised from nothing but faith and will.");
            }
            else if (speech.Contains("vitkov") || speech.Contains("hill"))
            {
                Say("At Vítkov Hill, we repelled the armies of Sigismund. Courage and wagon forts won the day.");
            }
            else if (speech.Contains("sigismund"))
            {
                Say("Sigismund, the would-be emperor, could not conquer the spirit of Bohemia.");
            }
            else if (speech.Contains("fort") || speech.Contains("wagon") || speech.Contains("tactics"))
            {
                Say("We built our wagon forts strong as stone. Ask me of wagenburg, and I shall tell you more.");
            }
            else if (speech.Contains("wagenburg"))
            {
                Say("The wagenburg—our moving fortress—was key to every victory. Curiosity and ingenuity always win in the end.");
            }
            else if (speech.Contains("flail") || speech.Contains("weapon"))
            {
                Say("A flail in the hands of a peasant can strike fear in knights. Every tool, every hand, has its place.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not castles or crowns, but the courage to fight for freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is not given. It must be won anew by every generation.");
            }
            else if (speech.Contains("castle") || speech.Contains("fortress"))
            {
                Say("Castles may fall, but a united people cannot be broken.");
            }
            else if (speech.Contains("death"))
            {
                Say("When death comes, let it find me standing with my people, never kneeling.");
            }
			else if (speech.Contains("legend"))
			{
				Say("In time, every truth becomes a legend, and every legend hides a kernel of truth. My tale is written in both blood and hope.");
			}
			else if (speech.Contains("blind") || speech.Contains("blindness"))
			{
				Say("Blindness was no barrier. I saw through the eyes of my soldiers, and they saw through mine.");
			}
			else if (speech.Contains("soldiers") || speech.Contains("army"))
			{
				Say("My army was made of bakers and blacksmiths, farmers and sons—united by purpose, not by birth.");
			}
			else if (speech.Contains("strategy"))
			{
				Say("Strategy is the art of using what you have, not what you wish for. A plough can be mightier than a sword, in the right hands.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is not the absence of fear, but the mastery of it. Stand firm, and you will inspire others to do the same.");
			}
			else if (speech.Contains("river") || speech.Contains("vltava"))
			{
				Say("The Vltava River carries the memory of Bohemia through every village and city. Listen to its current, and you will hear songs of resistance.");
			}
			else if (speech.Contains("city") || speech.Contains("prague"))
			{
				Say("Prague is a jewel upon the Vltava, a city of towers and dreams—guarded by the lion of Bohemia.");
			}
			else if (speech.Contains("lion"))
			{
				Say("The white lion stands for courage and sovereignty. In Bohemia, even our heraldry roars with pride.");
			}
			else if (speech.Contains("kingdom") || speech.Contains("crown"))
			{
				Say("A true crown is forged by the will of the people, not merely set upon a brow.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Never underestimate your enemies. Treat them with respect, for each is a lesson in vigilance.");
			}
			else if (speech.Contains("friend") || speech.Contains("companions"))
			{
				Say("My friends were my greatest strength. Trust and loyalty are shields no weapon can break.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace, like freedom, must be defended. May you know both in your journey.");
			}
			else if (speech.Contains("winter"))
			{
				Say("Bohemian winters are harsh, but unity is a fire that warms the coldest nights.");
			}
			else if (speech.Contains("wheel"))
			{
				Say("The wheel is both tool and weapon, symbol of the Hussite’s ingenuity.");
			}
			else if (speech.Contains("food") || speech.Contains("bread"))
			{
				Say("Bread and faith sustained us through many sieges. Even the mightiest warrior must break bread.");
			}
			else if (speech.Contains("siege"))
			{
				Say("In siege, patience is as powerful as any blade. The land itself can become your ally.");
			}
			else if (speech.Contains("armor"))
			{
				Say("My armor was simple, yet sturdy. Protection comes more from vigilance than from steel.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to those who fight for justice, with wisdom as well as strength.");
			}
			else if (speech.Contains("blanik"))
			{
				Say("The knights of Blaník are said to sleep beneath the mountain, awaiting Bohemia’s hour of greatest need.");
			}			
            else if (speech.Contains("music") || speech.Contains("song"))
            {
                Say("The songs of Bohemia still echo in our hearts—listen, and you may hear their wisdom.");
            }
            else if (speech.Contains("peasants") || speech.Contains("common"))
            {
                Say("The strength of peasants is the strength of the land. Never underestimate the humble.");
            }
            else if (speech.Contains("flag") || speech.Contains("banner"))
            {
                Say("Our banner bore the chalice, symbol of faith for every soul.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("curiosity") || speech.Contains("curious"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. Even in victory, rewards come only to those who wait.");
                }
                else
                {
                    Say("You have the heart of a true Hussite—accept this Treasure Chest of Czech History, and honor the stories within.");
                    from.AddToBackpack(new TreasureChestOfCzechHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the roads of Bohemia guide your steps, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the wagenburg, Tábor, Vítkov Hill, or the Hussite chalice.");
                }
            }

            base.OnSpeech(e);
        }

        public JanZizka(Serial serial) : base(serial) { }

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
