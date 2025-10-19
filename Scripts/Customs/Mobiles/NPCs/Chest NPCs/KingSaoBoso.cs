using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of King Sao Boso")]
    public class KingSaoBoso : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KingSaoBoso() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "King Sao Boso";
            Body = 0x190; // Human male body

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Bassa Woven Tunic", Hue = 2659 });
            AddItem(new FancyKilt() { Name = "Kilt of the St. John River", Hue = 2206 });
            AddItem(new Cloak() { Name = "Unity Cloak of the Kola Tree", Hue = 2173 });
            AddItem(new TribalMask() { Name = "Bassa Chieftain Mask", Hue = 2780 });
            AddItem(new FurBoots() { Name = "Riverbank Treading Boots", Hue = 2555 });
            AddItem(new BodySash() { Name = "Sash of Peaceful Accord", Hue = 2401 });

            // Weapon: Scepter as a symbol of peace and negotiation
            AddItem(new Scepter() { Name = "Sao Boso's Scepter of Diplomacy", Hue = 2119 });

            SpeechHue = 2129;

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
                Say("I am Sao Boso, King of the Bassa, friend to settlers and guardian of river and land.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to guide my people and keep peace between the Bassa and newcomers from afar.");
            }
            else if (speech.Contains("health"))
            {
                Say("The river’s breath keeps me strong, though old wounds sometimes ache like distant thunder.");
            }
            else if (speech.Contains("bassa"))
            {
                Say("We Bassa dwell where rivers sing, tending kola trees and ancient ways.");
            }
            else if (speech.Contains("settlers") || speech.Contains("newcomers"))
            {
                Say("Strangers arrived from across the sea, seeking freedom. I chose words over war when they came.");
            }
            else if (speech.Contains("river"))
            {
                Say("The St. John River is our lifeblood. It teaches patience, nourishes the kola, and connects our villages.");
            }
            else if (speech.Contains("kola"))
            {
                Say("The kola nut binds friendship, heals the weary, and marks sacred bargains.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a slow harvest, grown by trust. Only those with patient hearts can taste its fruit.");
            }
            else if (speech.Contains("land"))
            {
                Say("This land remembers every footstep—Bassa, Vai, settlers, all who cherish her bounty.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity is woven like cloth: each thread needed, none alone strong enough.");
            }
            else if (speech.Contains("history"))
            {
                Say("Liberia’s history is a river of many streams—ask me of kings, freedom, or the voices of the forest.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a word carried on Atlantic winds, its price paid in sorrow and hope.");
            }
            else if (speech.Contains("atlantic"))
            {
                Say("The Atlantic brought ships with iron and longing—some seeking new life, some returning to old dreams.");
            }
            else if (speech.Contains("kings"))
            {
                Say("Many have called themselves king. True kings serve their people and the land that feeds them.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The forest guards our secrets. Listen well, and you might hear the wisdom of old spirits.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is the whisper beneath the loud drums—seek the quiet, and you will find it.");
            }
            else if (speech.Contains("drum") || speech.Contains("drums"))
            {
                Say("Our drums tell stories: warning, welcome, remembrance. Even now, their echoes travel beyond the trees.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("To hear our stories, ask of the pepperbird. He is the keeper of tales along the riverbanks.");
            }
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("Our ancestors watch from the high cotton trees, their whispers carried by evening winds. We honor them in every harvest.");
			}
			else if (speech.Contains("language"))
			{
				Say("The Bassa language is shaped by river currents and the rhythm of the drum. Each word is a story in itself.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("When night falls, our people sing of journeys, loss, and the promise of the dawn. A song can heal what words alone cannot.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire brings warmth and warning. Around its light, the truth is spoken—sometimes, even kings must listen.");
			}
			else if (speech.Contains("palava") || speech.Contains("palaver"))
			{
				Say("A palava is a meeting beneath the palaver hut, where chiefs and elders share wisdom and settle disputes in peace.");
			}
			else if (speech.Contains("hut"))
			{
				Say("The palaver hut’s roof is broad so that many voices may gather in its shade. Unity begins with listening.");
			}
			else if (speech.Contains("flag"))
			{
				Say("The flag of Liberia carries one lone star, shining for freedom in a field of blue. Every stripe is a path of struggle and hope.");
			}
			else if (speech.Contains("star"))
			{
				Say("The star guides lost sailors home and reminds us that every nation must find its own light.");
			}
			else if (speech.Contains("monrovia"))
			{
				Say("Monrovia, city by the sea, was founded with hope and guarded by struggle. Its streets still remember every footstep.");
			}
			else if (speech.Contains("struggle"))
			{
				Say("Struggle makes the harvest sweet. We rise, we fall, but always we stand again—like the rice in rainy season.");
			}
			else if (speech.Contains("rice"))
			{
				Say("Rice is the heart of our table and the sweat of many hands. In lean times, we share what we have so no one goes hungry.");
			}
			else if (speech.Contains("sharing"))
			{
				Say("To share is to be strong. A king with an empty bowl feeds only pride, not people.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams travel farther than any canoe. Hold tight to yours, for rivers and dreams both lead to new places.");
			}
			else if (speech.Contains("canoe"))
			{
				Say("A canoe carved from a single tree can carry many hopes. Trust in the river, and it will bring you home.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is more than a hut or field—it is where our names are remembered, and our stories are safe.");
			}			
            else if (speech.Contains("pepperbird"))
            {
                Say("The pepperbird’s call means luck is near, or sometimes a secret is ready to be shared...");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Every river has a hidden channel, every king a secret sorrow. What is it you truly seek?");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("channel"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The river will not yield its treasures twice in one day, friend.");
                }
                else
                {
                    Say("You have found the hidden channel. Accept this Treasure Chest of Liberian History—and may it deepen your wisdom.");
                    from.AddToBackpack(new TreasureChestOfLiberianHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your path run smooth as the St. John after rain. Carry peace with you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of kola, freedom, unity, or the pepperbird if you wish to know Liberia’s soul.");
                }
            }

            base.OnSpeech(e);
        }

        public KingSaoBoso(Serial serial) : base(serial) { }

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
