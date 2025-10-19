using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Yambaitok")]
    public class QueenYambaitok : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenYambaitok() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Yambaitok";
            Title = "Guardian of the Sepik";
            Body = 0x191; // Human female body

            // Stats
            Str = 85;
            Dex = 70;
            Int = 105;
            Hits = 90;

            // Unique, themed appearance
            AddItem(new FlowerGarland() { Name = "Garland of River Blossoms", Hue = 1440 });
            AddItem(new FancyDress() { Name = "Sepik Tribal Robe", Hue = 2107 });
            AddItem(new FurSarong() { Name = "Sarong of Crocodile Spirits", Hue = 2053 });
            AddItem(new BodySash() { Name = "Sash of Painted Skins", Hue = 2119 });
            AddItem(new Sandals() { Name = "Mudwalker Sandals", Hue = 1196 });

            // Weapon: Mystic Staff
            AddItem(new WildStaff() { Name = "Staff of the Ancestral Voices", Hue = 1441 });

            // Speech color (a natural, river-like blue-green)
            SpeechHue = 2043;

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
                Say("I am Yambaitok, Queen of the Sepik and guardian of its ancient stories.");
            }
            else if (speech.Contains("job"))
            {
                Say("I keep the wisdom of the river people and listen to the spirits that dwell in water and wood.");
            }
            else if (speech.Contains("health"))
            {
                Say("My strength is drawn from the Sepik. As long as it flows, so do I.");
            }
            else if (speech.Contains("sepik"))
            {
                Say("The Sepik River is a serpent of life. Its banks hold secrets and ceremonies older than memory.");
            }
            else if (speech.Contains("river"))
            {
                Say("Without the river, there are no people, no stories, no song. The Sepik is our ancestor.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Spirits swim in every pool and whisper from carved masks. Some are kind, others hungry.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Stories are our greatest treasure. Some are painted on bark, others are carried by wind and water.");
            }
            else if (speech.Contains("crocodile"))
            {
                Say("Crocodiles are our brothers. They teach strength, patience, and the art of survival.");
            }
            else if (speech.Contains("mask") || speech.Contains("masks"))
            {
                Say("Every mask is a memory. The old carvers shape wood and bone to house the spirit within.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("We walk in the shadow of our ancestors. Their dreams guide my hand and voice.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen is but a servant of the stories, chosen to protect the spirit-house of the people.");
            }
            else if (speech.Contains("ceremony") || speech.Contains("ceremonies"))
            {
                Say("Ceremonies bind our world and the spirit world. Dance, drum, and song awaken the river’s power.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is not given—it is gathered like pearls from muddy water.");
            }
            else if (speech.Contains("pearl") || speech.Contains("pearls"))
            {
                Say("The river gives many pearls, but only the patient find the rarest.");
            }
            else if (speech.Contains("bark"))
            {
                Say("On painted bark, our stories flow—heroes, spirits, and warnings for those who listen.");
            }
            else if (speech.Contains("warning") || speech.Contains("warnings"))
            {
                Say("Respect the river, or it will take what you love. Many who forget, are lost to the deep.");
            }
            else if (speech.Contains("deep"))
            {
                Say("The deep hides monsters and memories. Only the brave seek its hidden wisdom.");
            }
            else if (speech.Contains("hidden"))
            {
                Say("Not all treasure is gold. What is hidden can sometimes change a life.");
            }
            else if (speech.Contains("life"))
            {
                Say("Life is a dance of rain, mud, laughter, and tears. All are sacred in the eyes of the spirits.");
            }
            else if (speech.Contains("dance"))
            {
                Say("When drums call, even the oldest spirits come to watch. Dance is a prayer made with feet.");
            }
			else if (speech.Contains("canoe"))
			{
				Say("Canoes are more than wood—they are our lifelines, shaped by hand and guided by the spirits of water.");
			}
			else if (speech.Contains("painting") || speech.Contains("paintings"))
			{
				Say("Every painting is a memory—ochre and charcoal tell stories long after voices fade.");
			}
			else if (speech.Contains("yam") || speech.Contains("yams"))
			{
				Say("Yams are the pride of our gardens. A great yam feast is a sign of strength and respect.");
			}
			else if (speech.Contains("feast") || speech.Contains("feasts"))
			{
				Say("At a feast, all are welcome. Laughter and song mix with the aroma of roasted yams and fresh river fish.");
			}
			else if (speech.Contains("fish"))
			{
				Say("The river’s fish feed us and our stories. The elders say that to fish with patience is to catch wisdom.");
			}
			else if (speech.Contains("elder") || speech.Contains("elders"))
			{
				Say("Elders carry the oldest tales, their faces painted with the river’s journey. Listen, and you may learn much.");
			}
			else if (speech.Contains("garden") || speech.Contains("gardens"))
			{
				Say("A tended garden is a song to the spirits. Every seed remembers the hand that planted it.");
			}
			else if (speech.Contains("tattoo") || speech.Contains("tattoos"))
			{
				Say("Our tattoos mark the journeys of our lives. Each line is a promise, each pattern a story.");
			}
			else if (speech.Contains("promise"))
			{
				Say("Promises made on the river are sacred. Break one, and even the crocodile will not forgive.");
			}
			else if (speech.Contains("moon"))
			{
				Say("When the moon is high, the spirits gather at the water’s edge, and the drums speak softly in the night.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night on the Sepik is full of voices—some friendly, some best left undisturbed.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend is one who stands with you at both feast and funeral.");
			}
			else if (speech.Contains("funeral"))
			{
				Say("At funerals, we send our dead with songs and stories, so their spirits will find the river’s path.");
			}
			else if (speech.Contains("path"))
			{
				Say("Every path leads to new stories. Walk gently, for you may step on an ancestor’s dream.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are the voices of our ancestors. Sometimes they come as a breeze, sometimes as thunder.");
			}
			else if (speech.Contains("breeze"))
			{
				Say("The river breeze carries news and rumors—listen, and you will never be alone.");
			}
			else if (speech.Contains("thunder"))
			{
				Say("Thunder is the voice of the sky spirits. It reminds us to respect all that we do not control.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Respect is the root of every strong tree, and every strong heart.");
			}
			else if (speech.Contains("tree") || speech.Contains("trees"))
			{
				Say("The trees watch over us. Their shade is a blessing, their roots are history.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("Every new dawn is a blessing. Greet it with gratitude, and the river will smile upon you.");
			}			
            else if (speech.Contains("drum") || speech.Contains("drums"))
            {
                Say("Drums speak for us when words fall silent. Their beat stirs blood and water alike.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("The greatest treasure? That is not for outsiders to claim—unless they prove their heart.");
            }
            // Secret reward keyword: "heart"
            else if (speech.Contains("heart"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Only one with a patient heart may receive the Sepik’s blessing again. Return later, wanderer.");
                }
                else
                {
                    Say("You have listened well, and your heart is open. Accept this Treasure Chest of Papua New Guinea—may the stories inside inspire you.");
                    from.AddToBackpack(new TreasureChestOfPapuaNewGuinea());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with the river’s blessing, and let no spirit trouble your sleep.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Sepik, crocodiles, ceremonies, or the wisdom of the ancestors.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenYambaitok(Serial serial) : base(serial) { }

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
