using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Augusto Sandino")]
    public class AugustoSandino : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AugustoSandino() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Augusto César Sandino";
            Body = 0x190; // Human male body

            // Unique Appearance: General of the Segovian Mountains
            AddItem(new ElvenShirt() { Name = "Sandino's Hemp Tunic", Hue = 2125 });
            AddItem(new Hakama() { Name = "Trousers of the Segovias", Hue = 2509 });
            AddItem(new BodySash() { Name = "Sash of Defiance", Hue = 2413 });
            AddItem(new FeatheredHat() { Name = "Iconic Broad-Brim Hat", Hue = 1194 });
            AddItem(new FurBoots() { Name = "Boots of the Guerrilla", Hue = 1109 });
            AddItem(new Cloak() { Name = "Cloak of the Free Mountains", Hue = 2118 });

            // Weapon
            AddItem(new ElvenMachete() { Name = "Machete of Libertad", Hue = 1176 });

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
                Say("I am Augusto César Sandino, General of Free Men and defender of Nicaraguan dignity.");
            }
            else if (speech.Contains("job"))
            {
                Say("My job was never easy: I led a guerrilla army from the pine forests of Segovia, fighting for my country's liberty.");
            }
            else if (speech.Contains("health"))
            {
                Say("Battle leaves its scars, but my spirit stands unbroken among the hills of Nicaragua.");
            }
            else if (speech.Contains("sandino"))
            {
                Say("Sandino is the name the world remembers, but I am only a voice of those who refuse to kneel.");
            }
            else if (speech.Contains("nicaragua"))
            {
                Say("Nicaragua is a land of volcanoes, rivers, and poets—our story is carved into the stones and sung by the wind.");
            }
            else if (speech.Contains("guerrilla"))
            {
                Say("A guerrilla fights with more than bullets—with hope, with heart, with dreams of freedom.");
            }
            else if (speech.Contains("segovia"))
            {
                Say("The pine-clad mountains of Segovia sheltered our cause. There, under the stars, I learned what freedom truly meant.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Mountains hide secrets and cradle dreams. Our struggle grew roots among their ancient pines.");
            }
            else if (speech.Contains("pine"))
            {
                Say("The scent of pine meant safety to my weary men. It still carries memories of resistance, if you listen close...");
            }
            else if (speech.Contains("occupation") || speech.Contains("foreign"))
            {
                Say("Foreign boots once trampled our soil. But the soul of Nicaragua could never be conquered.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is not given. It is earned, protected, and sometimes paid for with your life.");
            }
            else if (speech.Contains("machete"))
            {
                Say("The machete is a farmer's tool—and a symbol of resistance. With it, we harvested both corn and hope.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not measured in gold, but in dignity, and the dreams that outlive us.");
            }
            else if (speech.Contains("dignity"))
            {
                Say("To live with dignity is to stand tall, even in the shadow of empires.");
            }
            else if (speech.Contains("spirit"))
            {
                Say("Our spirit is like the river—sometimes calm, sometimes wild, always flowing forward.");
            }
            else if (speech.Contains("river"))
            {
                Say("The rivers of Nicaragua run deep, carrying the tears and laughter of centuries.");
            }
            else if (speech.Contains("managua"))
            {
                Say("Managua, heart of my homeland, knows sorrow and hope in equal measure.");
            }
            else if (speech.Contains("hat"))
            {
                Say("My hat became a symbol for those who long for freedom. Even now, its shadow covers the land.");
            }
            else if (speech.Contains("symbol"))
            {
                Say("Symbols can unite a people. A hat, a machete, a song—they all have power if carried with honor.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the gunpowder of the oppressed. It can ignite a fire greater than armies.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace was my dream, but justice was the price I would not bargain away.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Remember us, not for how we died, but for why we stood. That is the memory worth keeping.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every rebel has a story, and every story adds a thread to our nation's tapestry.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those with the courage to imagine it. What vision do you hold?");
            }
            else if (speech.Contains("heart"))
            {
                Say("The heart of Nicaragua beats strongest among those who love her, in good times and bad.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("My ancestors whisper on the wind. They remind me: never kneel, never surrender.");
            }
            else if (speech.Contains("struggle"))
            {
                Say("Struggle tempers the soul, forging heroes from common clay.");
            }
            else if (speech.Contains("prophecy"))
            {
                Say("There was a prophecy among my men: 'Someday, the pine forests will echo only with the songs of the free.'");
            }
            else if (speech.Contains("dream"))
            {
                Say("Dreams survive every bullet. Even in the darkest times, they are stars to guide us.");
            }
			else if (speech.Contains("poet") || speech.Contains("poetry"))
			{
				Say("A poet can win more hearts than a general. Nicaragua’s soul is written in verses, carved in sorrow and hope alike.");
			}
			else if (speech.Contains("revolution"))
			{
				Say("A true revolution does not begin with guns, but in the longing of the people for dignity and bread.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the seed we plant for our children, though sometimes it must be watered with sacrifice.");
			}
			else if (speech.Contains("bread"))
			{
				Say("Bread and freedom, compañero—these are what my people truly hunger for.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Under the Segovia stars, we dreamed of a dawn where no child would live in fear.");
			}
			else if (speech.Contains("dawn"))
			{
				Say("Each dawn is a promise, written in light on the faces of those who refuse to yield.");
			}
			else if (speech.Contains("camp"))
			{
				Say("In our hidden camps, laughter and song rose with the smoke. Even rebels must remember joy.");
			}
			else if (speech.Contains("joy"))
			{
				Say("Joy is an act of rebellion. When we dance, we tell the world it cannot break us.");
			}
			else if (speech.Contains("song") || speech.Contains("sing"))
			{
				Say("We sang corridos to remember the fallen and give courage to the living. Music is our shield.");
			}
			else if (speech.Contains("corridos"))
			{
				Say("Corridos keep our memory alive. Ask any old guerrillero, and you will hear the real history of Nicaragua.");
			}
			else if (speech.Contains("friend") || speech.Contains("comrade") || speech.Contains("compañero"))
			{
				Say("A true compañero stands beside you in darkness and dawn. Many of mine sleep now in the earth, but their voices linger.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain on the tin roof meant a night without marching. For a moment, we could rest—and remember home.");
			}
			else if (speech.Contains("mother"))
			{
				Say("A mother’s prayer is the strongest armor. Mine wept for me, but she never begged me to abandon the cause.");
			}
			else if (speech.Contains("cause"))
			{
				Say("The cause is not a man, but a nation’s longing. It survives even the darkest betrayal.");
			}
			else if (speech.Contains("betrayal") || speech.Contains("traitor"))
			{
				Say("Betrayal is a knife from the shadows, but the people’s love is a shield nothing can pierce.");
			}
			else if (speech.Contains("vulture"))
			{
				Say("The vulture circles the battlefield, but it cannot touch the soul. Only those who fear death forget to live.");
			}
			else if (speech.Contains("youth"))
			{
				Say("The youth carry tomorrow on their shoulders. Teach them truth, and let them walk tall.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is the first victim of occupation—and the last victory of a free people.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the purest hope of Nicaragua. For them, we fought—so they might inherit peace.");
			}
			else if (speech.Contains("volcano") || speech.Contains("volcanoes"))
			{
				Say("Our volcanoes remind us that fire sleeps in every Nicaraguan heart.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Some fires destroy, others warm and guide. Choose carefully what you ignite.");
			}
			else if (speech.Contains("wind"))
			{
				Say("Listen to the wind in the pines—it brings stories from before the first conquerors came.");
			}
			else if (speech.Contains("spanish") || speech.Contains("conquistador"))
			{
				Say("The Spanish took gold and lives, but our spirit outlasted them. Every invader finds the land harder to conquer than its people.");
			}			
            else if (speech.Contains("somoza"))
            {
                Say("An enemy can steal your sleep, but never your convictions. Somoza learned that too late.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold bought many traitors, but it could not buy the hearts of the mountains.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("pine"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the tallest pine must wait for the dawn. Patience, compañero.");
                }
                else
                {
                    Say("You know the secret of the pine forests. Take this Treasure Chest of Nicaragua's Legacy—may you carry its story forward.");
                    from.AddToBackpack(new TreasureChestOfNicaraguasLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell") || speech.Contains("adios"))
            {
                Say("Carry our struggle with you, and may the pine wind always fill your sails.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Segovia, freedom, the machete, or the meaning of legacy.");
                }
            }

            base.OnSpeech(e);
        }

        public AugustoSandino(Serial serial) : base(serial) { }

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
