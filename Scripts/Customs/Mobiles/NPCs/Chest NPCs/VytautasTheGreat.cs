using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the corpse of Vytautas the Great")]
    public class VytautasTheGreat : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public VytautasTheGreat() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Vytautas the Great";
            Body = 0x190; // Human male

            // Stats
            Str = 100;
            Dex = 70;
            Int = 80;
            Hits = 80;

            // Appearance & Outfit (unique, named items)
            AddItem(new Surcoat { Name = "Vytautas' Crimson Surcoat", Hue = 2125 });         // deep red
            AddItem(new Tunic { Name = "Vytautas' Gold-Trimmed Tunic", Hue = 2413 });        // gold/yellow
            AddItem(new ThighBoots { Name = "Lithuanian King's Boots", Hue = 2305 });        // rich leather brown
            AddItem(new Cloak { Name = "Order of the White Eagle Cloak", Hue = 1153 });      // white
            AddItem(new Bascinet { Name = "Helm of the Grand Duke", Hue = 2406 });           // silver
            AddItem(new Broadsword { Name = "Sword of Grunwald", Hue = 2065 });              // steel blue

            // Optionally: facial hair, etc.
            FacialHairItemID = 0x204B; // neatly trimmed beard
            FacialHairHue = Utility.RandomHairHue();
            HairItemID = 0x203C; // short hair
            HairHue = Utility.RandomHairHue();

            SpeechHue = 1150; // Noble/heroic speech

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
                Say("I am Vytautas the Great, Grand Duke of Lithuania, uniter of lands and defender of our people.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to protect Lithuania, unite her lands, and lead our knights to victory.");
            }
            else if (speech.Contains("lithuania"))
            {
                Say("Lithuania is my homeland—vast, proud, and fiercely independent. We have stood strong against many foes.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity has been my guiding principle. Only together, as one people, could we withstand the tides of war.");
            }
            else if (speech.Contains("battle"))
            {
                Say("Battle forged our destiny. None was greater than the clash at Grunwald.");
            }
            else if (speech.Contains("grunwald"))
            {
                Say("At Grunwald, we shattered the Teutonic Order. Our victory secured freedom for Lithuania and her allies.");
            }
            else if (speech.Contains("legacy"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You have already received my gift recently. Return when more time has passed, brave one.");
                }
                else
                {
                    Say("Take this, the Grand Chest of Lithuanian Legacy—a symbol of our enduring strength and unity.");
                    from.AddToBackpack(new GrandChestOfLithuanianLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("homeland"))
            {
                Say("Our homeland has known hardship and glory. Tell me—do you seek to learn of Lithuania's unity?");
            }
            else if (speech.Contains("knight"))
            {
                Say("Knights are the shield of our realm. Loyal, valiant, sworn to defend our people and honor.");
            }
            else if (speech.Contains("duke"))
            {
                Say("As Grand Duke, I am entrusted with the fate of Lithuania. Leadership demands wisdom and courage.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the heart of Lithuania. We cherish it above all, for it is hard won and easily lost.");
            }
			else if (speech.Contains("alliance"))
			{
				Say("Alliances were the cornerstone of our survival. Our pact with Poland brought strength against mighty foes.");
			}
			else if (speech.Contains("poland"))
			{
				Say("With King Jogaila of Poland, we stood side by side at Grunwald, forging a brotherhood sealed in battle.");
			}
			else if (speech.Contains("jogaila"))
			{
				Say("Jogaila, once my cousin and rival, became King of Poland and my ally. Together, we changed the fate of our nations.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("The Teutonic Order was our greatest enemy—ruthless knights seeking to claim our lands and erase our faith.");
			}
			else if (speech.Contains("teutonic"))
			{
				Say("The Teutonic Order, armored in black and white, were formidable. But at Grunwald, we broke their might forever.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family bound me to my people and to destiny. My father Kęstutis taught me the ways of rule and war.");
			}
			else if (speech.Contains("kestutis"))
			{
				Say("Kęstutis was a noble duke, fierce in battle and wise in council. His legacy guided my every action.");
			}
			else if (speech.Contains("religion"))
			{
				Say("Lithuania was the last pagan nation in Europe, holding to our ancient gods until the dawn of new faith.");
			}
			else if (speech.Contains("gods"))
			{
				Say("Our people once honored Perkūnas, Dievas, and the spirits of the forest. Even as times changed, the old ways endure.");
			}
			else if (speech.Contains("christianity"))
			{
				Say("Christianity came to Lithuania in my lifetime. It brought peace with neighbors, but many hearts remain true to the old ways.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future of Lithuania rests with those who cherish her freedom, unity, and honor. Will you carry that torch, traveler?");
			}			
            else
            {
                // Helpful clue for players who are lost
                Say("Ask me of my {0}, {1}, or {2}. Seek my {3}, and you may find a legacy.",
                    "name", "job", "Lithuania", "legacy");
            }

            base.OnSpeech(e);
        }

        public VytautasTheGreat(Serial serial) : base(serial) { }

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
