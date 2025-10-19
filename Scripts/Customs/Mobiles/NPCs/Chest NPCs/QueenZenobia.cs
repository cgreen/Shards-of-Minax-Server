using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Zenobia")]
    public class QueenZenobia : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenZenobia() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Zenobia";
            Body = 0x191; // Human female

            // Unique Regal-Desert Outfit
            AddItem(new FancyDress() { Name = "Regal Robe of Palmyra", Hue = 2418 }); // Deep crimson
            AddItem(new BodySash() { Name = "Sash of the Caravan Queen", Hue = 1441 }); // Sand-gold
            AddItem(new Cloak() { Name = "Mantle of Exile", Hue = 1150 }); // Desert midnight
            AddItem(new Circlet() { Name = "Crown of the Nabatean Sun", Hue = 1357 }); // Gleaming bronze
            AddItem(new Sandals() { Name = "Sandwalker's Shoes", Hue = 2052 }); // Pale sand
            AddItem(new PlateArms() { Name = "Armlets of Ancient Petra", Hue = 1266 }); // Rosy stone

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Rod of Lost Sovereignty", Hue = 1171 });

            SpeechHue = 2305; // Royal purple

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
                Say("I am Zenobia, once Queen of Palmyra, wanderer of Petra, exiled by the will of Rome.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was crowned queen, trader of silks and spices, but the desert is now my only throne.");
            }
            else if (speech.Contains("health"))
            {
                Say("The desert tests the body, but shapes the spirit. I endure, as do the stones of Petra.");
            }
            else if (speech.Contains("palmyra"))
            {
                Say("Palmyra was my home, a city of splendor, now lost to the dust and ambition of empires.");
            }
            else if (speech.Contains("petra"))
            {
                Say("Petra is the city of red stone, veined with secrets. Here, the desert preserves memory.");
            }
            else if (speech.Contains("rome") || speech.Contains("roman"))
            {
                Say("Rome feared my ambition. They sent legions, but the spirit of the desert is unconquerable.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Trade is the river of life in the desert. Silk, gold, incense, and spice cross these sands.");
            }
            else if (speech.Contains("throne") || speech.Contains("crown"))
            {
                Say("My crown was forged from sunlight and hope. My throne now rests beneath the open sky.");
            }
            else if (speech.Contains("desert") || speech.Contains("sand"))
            {
                Say("The desert gives and the desert takes. Its silence hides both ruin and riches.");
            }
            else if (speech.Contains("caravan"))
            {
                Say("Caravans were my armies—merchants, camels, and secrets hidden in every crate.");
            }
            else if (speech.Contains("nabatean"))
            {
                Say("The Nabateans built Petra from living rock. Their wisdom runs deeper than any well.");
            }
            else if (speech.Contains("incense"))
            {
                Say("Incense was worth its weight in silver. Its smoke carried prayers from Petra to Rome.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Treasure is not always gold. Sometimes, it is knowledge—hidden in plain sight.");
            }
            else if (speech.Contains("silk"))
            {
                Say("Silk from the east passed through my hands. Its softness is a memory of lost luxuries.");
            }
            else if (speech.Contains("empire"))
            {
                Say("Empires rise, empires fall. The desert forgets none of their stories.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("I have stories older than the stones—of betrayal, of freedom, of hope amid ruin.");
            }
			else if (speech.Contains("queen"))
			{
				Say("A queen’s duty is both crown and burden. Even in exile, I carry both with dignity.");
			}
			else if (speech.Contains("exile"))
			{
				Say("Rome sent me to chains, but the desert set me free. Exile is only a new beginning.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("The wisest words are written in the stones of forgotten cities. Listen, and you may learn.");
			}
			else if (speech.Contains("stone") || speech.Contains("stones"))
			{
				Say("Every stone in Petra has witnessed a thousand stories—of triumph, betrayal, and hope.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Trust is a fragile coin among rulers. My fate was shaped by both loyalty and betrayal.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty endures even when kingdoms fall. My followers remain shadows in the sand, but their hearts are bright.");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("Shadows grow long in Petra at sunset, hiding secrets and perhaps, old friends.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A true friend is rarer than the desert rain, and twice as precious.");
			}
			else if (speech.Contains("rain"))
			{
				Say("When rain falls in Petra, it is cause for joy and song. It awakens hidden flowers and memories.");
			}
			else if (speech.Contains("flower") || speech.Contains("flowers"))
			{
				Say("The black iris blooms only after rain—symbol of Jordan, and of beauty born from hardship.");
			}
			else if (speech.Contains("iris") || speech.Contains("black iris"))
			{
				Say("The black iris grows wild in the hills. Once, I wore one in my hair, to remember that beauty survives sorrow.");
			}
			else if (speech.Contains("battle"))
			{
				Say("I have seen the dust of battle rise like thunder. Each scar is a medal, each defeat, a lesson.");
			}
			else if (speech.Contains("scar") || speech.Contains("scars"))
			{
				Say("Scars remind us of what we have survived—and what we have yet to overcome.");
			}
			else if (speech.Contains("lesson") || speech.Contains("lessons"))
			{
				Say("The greatest lesson? Empires fade, but those who love fiercely leave a lasting mark.");
			}
			else if (speech.Contains("love"))
			{
				Say("Love gives strength to the weary and hope to the lost. It was my shield in the darkest nights.");
			}
			else if (speech.Contains("night"))
			{
				Say("Desert nights are cold and clear. The stars tell stories older than any city.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Gaze at the stars, and you gaze at your ancestors. Their light endures, even after empires fall.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We walk in the footsteps of giants. My blood remembers warriors, poets, and dreamers.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are a kind of map—follow them bravely, and you may find your destiny.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny is a path shaped by choice and courage. Will you carve your own legend, traveler?");
			}
			else if (speech.Contains("camel") || speech.Contains("camels"))
			{
				Say("Camels are the true ships of the desert. Trust them, and you will never be truly lost.");
			}
			else if (speech.Contains("lost"))
			{
				Say("Lost? The desert teaches patience, and eventually all wanderers find their way—or a new one.");
			}			
            else if (speech.Contains("hope"))
            {
                Say("Hope is the oasis that quenches even the longest journey.");
            }
            else if (speech.Contains("lost"))
            {
                Say("What is lost can yet be found—if one follows the right trail.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("spice"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the most fragrant spice must rest between harvests. Return when the desert wind shifts.");
                }
                else
                {
                    Say("You know the true wealth of the caravan roads. Take this Treasure Chest of Jordan—may your fortune rival mine.");
                    from.AddToBackpack(new TreasureChestOfJordan());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with the wind and walk boldly into your legend, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Palmyra, Petra, the Nabateans, or the caravans that cross the red sands.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenZenobia(Serial serial) : base(serial) { }

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
