using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Makeda")]
    public class QueenMakeda : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenMakeda() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Makeda, Queen of Sheba";
            Body = 0x191; // Human female

            // Stats
            Str = 100;
            Dex = 70;
            Int = 120;
            Hits = 100;

            // Unique Outfit
            var robe = new Robe() { Hue = 2213, Name = "Makeda's Gilded Robe of Wisdom" };
            AddItem(robe);

            var circlet = new Circlet() { Hue = 1282, Name = "Jewel of Sheba Circlet" };
            AddItem(circlet);

            var sash = new BodySash() { Hue = 1161, Name = "Royal Sash of the Highlands" };
            AddItem(sash);

            var sandals = new Sandals() { Hue = 2101, Name = "Sandals of Ancient Rivers" };
            AddItem(sandals);

            var scepter = new Scepter() { Hue = 2117, Name = "Scepter of the Sun Lion" };
            AddItem(scepter);

            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x203C, 0x203B); // Various hair styles
            HairHue = Utility.RandomHairHue();

            SpeechHue = 0;

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
                Say("Makeda, the Queen of Sheba. My name is known in the scrolls of history and legend.");
            else if (speech.Contains("job"))
                Say("I am Makeda, Queen of Sheba. My reign is ancient, but my wisdom is ever new.");
            else if (speech.Contains("health"))
                Say("My spirit endures as the rivers that flow from the Highlands.");
            else if (speech.Contains("sheba"))
                Say("The Kingdom of Sheba was a land of great wealth and mystery, hidden in the mists of time.");
            else if (speech.Contains("ethiopia"))
                Say("Ethiopia is my homeland, blessed by the Blue Nile and protected by ancient spirits.");
            else if (speech.Contains("treasure"))
                Say("The treasures of Sheba are more than gold; they are wisdom, courage, and the blessings of the ancients.");
            else if (speech.Contains("wisdom"))
                Say("Wisdom is a river: those who seek it must be patient, for its current runs deep.");
            else if (speech.Contains("solomon"))
                Say("King Solomon and I shared riddles and secrets. Our story echoes across the sands of time.");
            else if (speech.Contains("riddle"))
                Say("A riddle tests the mind, but it is the heart that uncovers truth.");
            else if (speech.Contains("lion"))
                Say("The Lion of Judah roars in the blood of my descendants.");
			else if (speech.Contains("highlands"))
				Say("The Ethiopian Highlands rise above the clouds, crowned with mist and mystery. Many legends dwell in their shadows.");
			else if (speech.Contains("blue nile"))
				Say("The Blue Nile flows with the hopes of my people. It nourishes the land, as wisdom nourishes the soul.");
			else if (speech.Contains("gold"))
				Say("Gold glitters in the sun, but it is virtue and honor that truly enrich a kingdom.");
			else if (speech.Contains("legacy"))
				Say("A true legacy endures beyond stone and gold. It is carried in the hearts and deeds of those who remember.");
			else if (speech.Contains("faith"))
				Say("Faith guides my people through hardship. It is a flame that never wavers, even in the darkest night.");
			else if (speech.Contains("saint"))
				Say("Ethiopia reveres many saints and holy ones. Their blessings protect the land from harm.");
			else if (speech.Contains("ark"))
				Say("The Ark of the Covenant is shrouded in legend. Some say it rests within our borders, guarded and unseen.");
			else if (speech.Contains("covenant"))
				Say("A covenant binds not only people, but also the spirits that watch over this ancient realm.");
			else if (speech.Contains("oracle"))
				Say("Oracles speak for the spirits and foresee what may come. But the future is always shifting, like the sands.");
			else if (speech.Contains("spirit"))
				Say("Spirits walk the old paths. They are both guardians and teachers, if one listens with respect.");
			else if (speech.Contains("teacher"))
				Say("The best teacher is experience, but wisdom can also be found in the stories of the elders.");
			else if (speech.Contains("elders"))
				Say("Our elders are the living libraries of Ethiopia. To honor them is to honor all that came before.");
			else if (speech.Contains("library"))
				Say("Within the ancient libraries are scrolls that tell of lost kingdoms, forgotten heroes, and powerful magic.");
			else if (speech.Contains("scroll"))
				Say("A single scroll can hold the fate of empires. Guard knowledge as you would a jewel.");
			else if (speech.Contains("hero"))
				Say("Ethiopia’s heroes are many—some sung in songs, others remembered only in whispers.");
			else if (speech.Contains("song"))
				Say("Songs carry the memory of my people. Through music, we remember our triumphs and trials.");
			else if (speech.Contains("music"))
				Say("The krar and the masenqo echo through palace halls and highland valleys alike.");
			else if (speech.Contains("krar"))
				Say("The krar is a lyre, beloved in Ethiopia. Its notes can lift the spirit or bring a tear.");
			else if (speech.Contains("masenqo"))
				Say("The masenqo is a single-stringed instrument, simple in form, yet rich in soul.");
			else if (speech.Contains("wisdom"))
				Say("True wisdom lies in humility. The wise seek understanding, not praise.");
			else if (speech.Contains("humility"))
				Say("The mountain bows to the wind, and so too must rulers bow to the truth.");
			else if (speech.Contains("truth"))
				Say("Truth is the foundation upon which all great kingdoms are built. Lies are but sand.");
			else if (speech.Contains("sand"))
    Say("Sand may shift and scatter, but the mountains stand eternal. Seek what endures.");				
            else if (speech.Contains("ancient"))
                Say("The ancient ones watch over Ethiopia still. Their secrets are not easily given.");
            else if (speech.Contains("blessing"))
                Say("A blessing can be found by those with patience and respect.");
            else if (speech.Contains("patience"))
                Say("Patience is rewarded, as the mighty baobab grows slowly, but stands for centuries.");
            else if (speech.Contains("reward"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(15);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You must wait before receiving another blessing. Return when the sun has moved farther across the sky.");
                }
                else
                {
                    Say("You have shown wisdom and patience. Take this Treasure Chest of Ancient Ethiopia as a blessing from the Queen of Sheba.");
                    from.AddToBackpack(new TreasureChestOfAncientEthiopia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }

            base.OnSpeech(e);
        }

        public QueenMakeda(Serial serial) : base(serial) { }

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
