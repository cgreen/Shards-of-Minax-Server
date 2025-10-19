using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Gajah Mada")]
    public class GajahMada : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public GajahMada() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Gajah Mada";
            Body = 0x190; // Human male body

            // Appearance: Majapahit Vizier
            AddItem(new ElvenShirt() { Name = "Majapahit Silken Shirt", Hue = 2412 });
            AddItem(new GuildedKilt() { Name = "Kain Songket of Trowulan", Hue = 2707 });
            AddItem(new Cloak() { Name = "Royal Batik Cloak", Hue = 1327 });
            AddItem(new FlowerGarland() { Name = "Frangipani Crown", Hue = 0 });
            AddItem(new FurBoots() { Name = "Boots of the Spice Islands", Hue = 2120 });
            AddItem(new BodySash() { Name = "Sash of the Palapa Oath", Hue = 1165 });

            // Weapon: Keris (Dagger)
            AddItem(new Dagger() { Name = "Keris of Unity", Hue = 2400 });

            // Speech Hue
            SpeechHue = 2001;

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
                Say("I am Gajah Mada, Mahapatih of Majapahit, sworn guardian of the Nusantara.");
            }
            else if (speech.Contains("job"))
            {
                Say("I served as the Grand Vizier, leading Majapahit toward unity and glory.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body fades with time, but my oath binds me beyond the ages.");
            }
            else if (speech.Contains("majapahit"))
            {
                Say("Majapahit was the great empire of the archipelago, where spices, wisdom, and ambition converged.");
            }
            else if (speech.Contains("nusantara"))
            {
                Say("The Nusantara is a garland of emerald islands, each with its own tale—united, they form our true strength.");
            }
            else if (speech.Contains("vizier") || speech.Contains("mahapatih"))
            {
                Say("As Mahapatih, I held the trust of kings, bearing the burden of unity.");
            }
            else if (speech.Contains("palapa") || speech.Contains("oath"))
            {
                Say("My Sumpah Palapa—my sacred vow—was to taste no spice until the islands stood as one.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Clove, nutmeg, cinnamon—spices drew kings and conquerors alike to these shores.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is forged in courage, discipline, and the will to dream beyond horizons.");
            }
            else if (speech.Contains("island") || speech.Contains("islands"))
            {
                Say("Each island is a jewel. Together, we become a necklace fit for the gods.");
            }
            else if (speech.Contains("gods"))
            {
                Say("The gods walk the mountains, rivers, and jungles of Nusantara—honor them, and they may favor you.");
            }
            else if (speech.Contains("trowulan"))
            {
                Say("Trowulan was the beating heart of Majapahit, its palaces veiled in mystery and song.");
            }
            else if (speech.Contains("keris"))
            {
                Say("The keris is both blade and talisman—its wavy edge remembers all who strive for unity.");
            }
            else if (speech.Contains("batik"))
            {
                Say("Batik patterns hold secret stories—heroes, spirits, and the rise and fall of kings.");
            }
            else if (speech.Contains("songket"))
            {
                Say("Songket is cloth woven with gold and dreams—each thread a promise to ancestors.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are sails upon the wind—those who dare set them free may touch every shore.");
            }
            else if (speech.Contains("shore") || speech.Contains("shores"))
            {
                Say("The shores of Nusantara have welcomed many: traders, poets, and those seeking their fate.");
            }
            else if (speech.Contains("frangipani"))
            {
                Say("The frangipani flower is a sign of peace, and a gift to the spirits in every offering.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Our spirits dwell in jungle shadows and rice fields, in each whispered legend.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends shape the archipelago—listen closely, and you may uncover a forgotten secret.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Seek the hidden, honor the old, and perhaps the archipelago will reward you.");
            }
			else if (speech.Contains("java"))
			{
				Say("Java is the pulse of Majapahit—where volcanoes breathe and rice fields shimmer like emerald seas.");
			}
			else if (speech.Contains("trowulan"))
			{
				Say("Trowulan's stones remember laughter, sorrow, and the promise that united kings beneath one banner.");
			}
			else if (speech.Contains("banner"))
			{
				Say("Under a single banner, even the wildest waves bow to the will of the Majapahit.");
			}
			else if (speech.Contains("volcano") || speech.Contains("volcanoes"))
			{
				Say("Our volcanoes are both danger and blessing—reminders that power often slumbers beneath calm exteriors.");
			}
			else if (speech.Contains("market") || speech.Contains("markets"))
			{
				Say("Majapahit markets once brimmed with traders from far shores, their ships heavy with silk and stories.");
			}
			else if (speech.Contains("trade") || speech.Contains("traders"))
			{
				Say("Trade shaped our islands. Spices sailed east and gold sailed west—each voyage a thread in Nusantara’s tapestry.");
			}
			else if (speech.Contains("tapestry"))
			{
				Say("Every life, every tale, every conquest is woven into Nusantara’s tapestry—its beauty is in its endless variety.");
			}
			else if (speech.Contains("boat") || speech.Contains("ship") || speech.Contains("boats") || speech.Contains("ships"))
			{
				Say("Our boats are swift and sturdy, their prows pointed toward dawn and destiny.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny favors those who honor the past and dare to imagine the impossible.");
			}
			else if (speech.Contains("past"))
			{
				Say("The past is a lantern: it may light the way forward or blind those who refuse to let go.");
			}
			else if (speech.Contains("queen") || speech.Contains("queens"))
			{
				Say("Majapahit’s queens wielded wisdom and grace—some say their words were as sharp as any keris.");
			}
			else if (speech.Contains("jungle") || speech.Contains("jungles"))
			{
				Say("The jungles of the archipelago hide both danger and delight—listen for the gamelan of hidden spirits.");
			}
			else if (speech.Contains("gamelan"))
			{
				Say("Gamelan is the music of bronze and bamboo, echoing through palace halls and rice fields alike.");
			}
			else if (speech.Contains("rice"))
			{
				Say("Rice is the gift of Dewi Sri. Where rice grows, so too does peace and prosperity.");
			}
			else if (speech.Contains("dew") || speech.Contains("dewi sri"))
			{
				Say("Dewi Sri is the mother of rice and all who tend the earth—her blessings are found in every harvest.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("A bountiful harvest begins with patience, is nurtured by sweat, and ends with a feast to honor the ancestors.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("The ancestors watch us from the banyan shade; their lessons endure if we are wise enough to listen.");
			}
			else if (speech.Contains("shade"))
			{
				Say("Banyan shade is shelter for travelers, storytellers, and the dreams of kings long gone.");
			}
			else if (speech.Contains("traveler") || speech.Contains("travelers"))
			{
				Say("A wise traveler walks with both eyes open—one for the road, one for the lessons hidden along it.");
			}
			else if (speech.Contains("lesson") || speech.Contains("lessons"))
			{
				Say("Some lessons come with a whisper, others with thunder. All are precious to those who seek understanding.");
			}
			else if (speech.Contains("understanding"))
			{
				Say("True understanding comes not from answers, but from the questions we dare to ask.");
			}
			else if (speech.Contains("ask"))
			{
				Say("Ask, and the archipelago may answer in winds, waves, or the silence between stars.");
			}			
            else if (speech.Contains("reward"))
            {
                Say("Majapahit did not grow strong by seeking treasure alone—wisdom is the greater prize.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is born of patience, courage, and curiosity.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("curiosity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, young seeker. Even the ocean reveals its pearls only in time.");
                }
                else
                {
                    Say("You honor the spirit of Nusantara. Accept this Treasure Chest of Nusantara Kings—may its treasures illuminate your journey.");
                    from.AddToBackpack(new TreasureChestOfNusantaraKings());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Sail with courage. The winds of Majapahit guide you, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Majapahit, Palapa, or the secrets of the keris.");
                }
            }

            base.OnSpeech(e);
        }

        public GajahMada(Serial serial) : base(serial) { }

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
