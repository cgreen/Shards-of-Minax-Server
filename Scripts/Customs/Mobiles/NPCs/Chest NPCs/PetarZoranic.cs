using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Petar Zoranić")]
    public class PetarZoranic : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public PetarZoranic() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Petar Zoranić";
            Body = 0x190; // Human male body

            // Unique Appearance: Dalmatian Renaissance Writer & Traveler
            AddItem(new FancyShirt() { Name = "Poet's Silk Tunic", Hue = 1152 });
            AddItem(new GuildedKilt() { Name = "Dalmatian Scribe's Kilt", Hue = 2502 });
            AddItem(new Cloak() { Name = "Cloak of Adriatic Breezes", Hue = 1359 });
            AddItem(new FeatheredHat() { Name = "Plumed Cap of Zadar", Hue = 1137 });
            AddItem(new FurBoots() { Name = "Traveler's Boots of Makarska", Hue = 2111 });
            AddItem(new BodySash() { Name = "Sash of Olive Branches", Hue = 1412 });

            // Weapon: Quarterstaff
            AddItem(new QuarterStaff() { Name = "Walking Staff of Planine", Hue = 0 });

            SpeechHue = 1171;

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
                Say("I am Petar Zoranić, wanderer of Dalmatia and humble writer of tales.");
            }
            else if (speech.Contains("job"))
            {
                Say("By day I traverse wild lands; by night I craft stories to honor Dalmatia. Ask me of my 'novel'.");
            }
            else if (speech.Contains("health"))
            {
                Say("The sea air and mountain herbs keep me well. The heart grows strong amidst olive trees and salt winds.");
            }
            else if (speech.Contains("dalmatia"))
            {
                Say("Dalmatia is my home—rocky shores, emerald olives, and the song of the Adriatic. Its 'mountains' hide many legends.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains") || speech.Contains("planine"))
            {
                Say("The 'Planine' are not just stones but the backbone of our land. My journey through them shaped my soul.");
            }
            else if (speech.Contains("journey"))
            {
                Say("In my novel, the journey is both a search for beauty and a trial of the spirit. Along the path, I learned much of 'herbs' and healing.");
            }
            else if (speech.Contains("herb") || speech.Contains("herbs"))
            {
                Say("Rosemary, sage, and lavender—herbs of Dalmatia heal wounds and flavor our days. But some say they also guard 'secrets'.");
            }
            else if (speech.Contains("olive") || speech.Contains("olives"))
            {
                Say("Olives are Dalmatia’s treasure—each branch tells a story of patience and peace.");
            }
            else if (speech.Contains("novel") || speech.Contains("book") || speech.Contains("planine"))
            {
                Say("I wrote 'Planine,' the first Croatian novel. In it, you will find nature’s wisdom and the dreams of our people.");
            }
			else if (speech.Contains("homeland"))
			{
				Say("My heart beats for Dalmatia—her rocky fields, her stony villages, and the voices of her people.");
			}
			else if (speech.Contains("folk") || speech.Contains("customs"))
			{
				Say("Our folk customs run deep: songs sung to the moon, dances in the village square, and riddles passed by the fire. Ask me of 'klapa' or 'kolo'.");
			}
			else if (speech.Contains("klapa"))
			{
				Say("Klapa is our harmony—voices joined without instruments, echoing across stone streets and over waves.");
			}
			else if (speech.Contains("kolo"))
			{
				Say("The kolo is our circle dance—spinning, weaving, celebrating life and unity.");
			}
			else if (speech.Contains("language") || speech.Contains("croatian"))
			{
				Say("Our Croatian tongue is soft as sea wind, yet strong enough to weather centuries. In words, our freedom is preserved.");
			}
			else if (speech.Contains("myth") || speech.Contains("legend") || speech.Contains("myths") || speech.Contains("legends"))
			{
				Say("Dalmatian legends speak of hidden treasures, haunted islands, and wise women who talk to the wind. Ask me of 'vila' or 'Morlach'.");
			}
			else if (speech.Contains("vila") || speech.Contains("fairy") || speech.Contains("fairies"))
			{
				Say("The vila—our mountain fairies—guard streams and forests. Some say they help the lost or punish the cruel.");
			}
			else if (speech.Contains("morlach") || speech.Contains("morlachs"))
			{
				Say("The Morlachs, shepherds of the hinterland, are fierce and proud. Their songs are as wild as the land itself.");
			}
			else if (speech.Contains("island") || speech.Contains("islands"))
			{
				Say("Dalmatia’s islands are scattered pearls: Brač, Hvar, Vis, Korčula, and many more—each with its own secret and song.");
			}
			else if (speech.Contains("stone") || speech.Contains("stones"))
			{
				Say("Stones are the bones of Dalmatia. Our houses, roads, and fences are all built from patient hands and ancient rock.");
			}
			else if (speech.Contains("sunset"))
			{
				Say("A Dalmatian sunset paints the sky in gold and violet, promising rest and the hope of tomorrow.");
			}
			else if (speech.Contains("philosophy"))
			{
				Say("I believe one must travel both outward and inward. Only then can a man truly know his place among the stones and stars.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams lead us over mountains we could not climb in waking. Follow them, and you may find your own Planine.");
			}
			else if (speech.Contains("church") || speech.Contains("saint"))
			{
				Say("Our churches are humble, their walls thick and cool. Many bear the names of saints who once walked these hills.");
			}
			else if (speech.Contains("wine"))
			{
				Say("Dalmatian wine is sunlight in a cup—taste it, and you taste the land itself.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is our anchor in every storm. In Dalmatia, blood and memory tie us to place and to one another.");
			}			
            else if (speech.Contains("poet") || speech.Contains("writer"))
            {
                Say("A poet’s duty is to remember what others forget. I try to capture the soul of Dalmatia in words.");
            }
            else if (speech.Contains("zadar"))
            {
                Say("Zadar, city of my birth, sits like a pearl on the Adriatic. Its stones remember both joy and hardship.");
            }
            else if (speech.Contains("adriatic") || speech.Contains("sea") || speech.Contains("coast"))
            {
                Say("The Adriatic is a restless friend—her moods shape our lives and dreams. Many legends are carried on her waves.");
            }
            else if (speech.Contains("venetian") || speech.Contains("invader"))
            {
                Say("Venetians and others have long sought Dalmatia, but the people resist with song, story, and steel. Ask me of 'resistance'.");
            }
            else if (speech.Contains("resistance"))
            {
                Say("Resistance is the salt of Dalmatian blood. We defend our land not only with arms, but with memory.");
            }
            else if (speech.Contains("nature"))
            {
                Say("Nature whispers to those who listen. In her quiet moments, she reveals her 'secrets' to the worthy.");
            }
            // *** SECRET REWARD KEYWORD ***
            else if (speech.Contains("secrets"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Every secret must rest before it’s shared again. Return to me after wandering a while.");
                }
                else
                {
                    Say("You have listened well. Accept this Treasure Chest of Dalmatian Kings—may it inspire new adventures and stories.");
                    from.AddToBackpack(new TreasureChestOfDalmatianKings());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the olive trees shelter your rest, and the Adriatic guide your steps.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Dalmatia, Planine, nature, or the stories hidden in herbs and olives.");
                }
            }

            base.OnSpeech(e);
        }

        public PetarZoranic(Serial serial) : base(serial) { }

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
