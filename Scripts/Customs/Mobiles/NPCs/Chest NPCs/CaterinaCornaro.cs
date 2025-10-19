using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Caterina Cornaro")]
    public class CaterinaCornaro : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public CaterinaCornaro() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Caterina Cornaro";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 65;
            Int = 105;
            Hits = 78;

            // Unique Appearance
            AddItem(new FancyDress() { Name = "Queen's Mourning Gown", Hue = 1153 });
            AddItem(new FormalShirt() { Name = "Silk Undergown of Venice", Hue = 1157 });
            AddItem(new Cloak() { Name = "Azure Mantle of Cyprus", Hue = 1170 });
            AddItem(new FeatheredHat() { Name = "Crown of the Lusignans", Hue = 1161 });
            AddItem(new Shoes() { Name = "Slippers of the Exiled Queen", Hue = 1160 });
            AddItem(new BodySash() { Name = "Sash of St. Helena", Hue = 1165 });

            AddItem(new Scepter() { Name = "Scepter of Bitter Oranges", Hue = 1164 });

            SpeechHue = 2211;

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
                Say("I am Caterina Cornaro, once Queen of Cyprus, born of Venetian blood and Cypriot destiny.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, my duty was to rule as queen and shield Cyprus from storms both foreign and within.");
            }
            else if (speech.Contains("health"))
            {
                Say("My heart aches for my lost kingdom, yet I stand with the strength of memory and grace.");
            }
            else if (speech.Contains("queen"))
            {
                Say("I wore the crown of Cyprus, though it grew heavy with sorrow and longing for peace.");
            }
            else if (speech.Contains("cyprus"))
            {
                Say("Cyprus is an island of many masters, a jewel in the sea where east and west entwine.");
            }
            else if (speech.Contains("venice"))
            {
                Say("Venice—my birthplace and my captor. From her I gained both splendor and sorrow.");
            }
            else if (speech.Contains("exile"))
            {
                Say("I lived as a queen in exile, my days filled with longing for the songs and sun of Cyprus.");
            }
            else if (speech.Contains("sorrow"))
            {
                Say("There is sorrow in every farewell, and Cyprus is a tale of many partings.");
            }
            else if (speech.Contains("history"))
            {
                Say("History remembers our triumphs and our tragedies. Mine is written in the waves and stones of Cyprus.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memories linger like the scent of bitter oranges, sweet and sorrowful together.");
            }
            else if (speech.Contains("bitter orange") || speech.Contains("bitter oranges") || speech.Contains("orange"))
            {
                Say("The bitter orange groves of Nicosia were dear to my heart. Their blossoms carried my dreams.");
            }
            else if (speech.Contains("nicosia"))
            {
                Say("Nicosia, the heart of Cyprus, has walls that echo with laughter and lament both.");
            }
            else if (speech.Contains("island"))
            {
                Say("This island is a crossroads of crusaders, traders, and dreamers. Each left a mark upon her sands.");
            }
            else if (speech.Contains("crusader") || speech.Contains("crusaders"))
            {
                Say("Crusaders once marched across Cyprus, leaving behind both glory and ruin.");
            }
            else if (speech.Contains("venetian"))
            {
                Say("Venetian blood runs through my veins, but Cyprus claimed my soul.");
            }
            else if (speech.Contains("kingdom"))
            {
                Say("My kingdom was not won by war, but given and taken by fate and diplomacy.");
            }
            else if (speech.Contains("fate"))
            {
                Say("Fate’s tide cannot be stemmed, even by the strongest will. It swept me from queen to exile.");
            }
            else if (speech.Contains("grace"))
            {
                Say("In adversity, I found grace. Perhaps that is the true crown of any ruler.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Cypriot songs speak of love, loss, and the endless blue of the sea.");
            }
            else if (speech.Contains("sea"))
            {
                Say("The sea around Cyprus is both cradle and prison, shimmering with secrets.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Cyprus hides many secrets, buried in ruins and whispered by olive groves.");
            }
            else if (speech.Contains("olive") || speech.Contains("olive groves"))
            {
                Say("The olive groves are as old as myth. In their shade, Cyprus remembers.");
            }
			else if (speech.Contains("diplomacy"))
			{
				Say("Diplomacy is both shield and snare. Many battles are won or lost with words rather than swords.");
			}
			else if (speech.Contains("intrigue"))
			{
				Say("Intrigue surrounded my court like mist over the sea—each ally a potential rival, each secret a blade.");
			}
			else if (speech.Contains("art"))
			{
				Say("In exile, I cherished art. Painters and poets came to my court, turning sorrow into beauty.");
			}
			else if (speech.Contains("painter") || speech.Contains("painters"))
			{
				Say("The Venetian masters gifted me portraits—some still hang in distant halls, their eyes remembering.");
			}
			else if (speech.Contains("poet") || speech.Contains("poetry"))
			{
				Say("Cyprus inspires poetry. Its olive trees, its tempests, and its silent ruins—each a verse in a larger song.");
			}
			else if (speech.Contains("wine"))
			{
				Say("Cyprus is famed for its sweet wines. Commandaria was poured at my table, a taste of sunlight in a goblet.");
			}
			else if (speech.Contains("commandaria"))
			{
				Say("Commandaria—the nectar of kings and queens. Legend claims it is the oldest named wine in the world.");
			}
			else if (speech.Contains("regret") || speech.Contains("regrets"))
			{
				Say("Regret is a silent companion to all rulers. I wonder what might have been, had Cyprus remained free.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is a stubborn flower, blooming even in rocky soil. I entrust it to every traveler of this isle.");
			}
			else if (speech.Contains("garden") || speech.Contains("gardens"))
			{
				Say("The gardens of my palace overflowed with jasmines and bitter oranges. I still dream of their fragrance.");
			}
			else if (speech.Contains("palace"))
			{
				Say("My palace in Famagusta was a haven of music and laughter, even as storm clouds gathered.");
			}
			else if (speech.Contains("famagusta"))
			{
				Say("Famagusta—once a city of splendor, now a memory shaped by sun and stone.");
			}
			else if (speech.Contains("music"))
			{
				Say("Musicians played the lute and oud in my halls, weaving solace from sorrow.");
			}
			else if (speech.Contains("lute") || speech.Contains("oud"))
			{
				Say("The lute’s strings recall Venetian ballads; the oud’s notes speak the language of Cyprus itself.");
			}
			else if (speech.Contains("blessing") || speech.Contains("blessings"))
			{
				Say("May you carry Cyprus’s blessing with you: courage in loss, and gentleness in strength.");
			}			
            else if (speech.Contains("myth") || speech.Contains("myths"))
            {
                Say("Aphrodite is said to have risen from these shores. Legends and queens both are born from Cyprus.");
            }
            else if (speech.Contains("aphrodite"))
            {
                Say("Aphrodite, goddess of love, blesses Cyprus with beauty, and perhaps a touch of heartbreak.");
            }
            else if (speech.Contains("legacy"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Legacies are not gifts to be claimed often. Return to me after time has turned.");
                }
                else
                {
                    Say("You seek legacy—and so I entrust you a treasure chest from Cyprus, where past and present entwine.");
                    from.AddToBackpack(new TreasureChestOfCyprus());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Farewell, traveler. May Cyprus’s story linger in your heart.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of exile, Cyprus, Venice, or the bitter oranges of Nicosia.");
                }
            }

            base.OnSpeech(e);
        }

        public CaterinaCornaro(Serial serial) : base(serial) { }

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
