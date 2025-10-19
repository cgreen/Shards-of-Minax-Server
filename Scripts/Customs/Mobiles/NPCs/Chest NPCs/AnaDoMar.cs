using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ana do Mar")]
    public class AnaDoMar : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AnaDoMar() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ana do Mar";
            Title = "the Cabo Verdean Navigator";
            Female = true;
            Body = 0x191;

            // Unique Appearance
            AddItem(new FloweredDress() { Name = "Ocean-Bloom Dress of Mindelo", Hue = 1373 });
            AddItem(new BodySash() { Name = "Navigator's Azure Sash", Hue = 1150 });
            AddItem(new Cloak() { Name = "Cape of the Harmattan Winds", Hue = 2217 });
            AddItem(new Sandals() { Name = "Island Walker's Sandals", Hue = 1825 });
            AddItem(new FeatheredHat() { Name = "Seafarer's Feathered Cap", Hue = 2008 });
            AddItem(new GargishSash() { Name = "Sash of the Salt Isles", Hue = 1148 });
            AddItem(new Scythe() { Name = "Whispering Wind Scythe", Hue = 2065 });

            SpeechHue = 2123;

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
                Say("I am Ana do Mar, once called the Wind's Daughter and navigator of Cabo Verde.");
            }
            else if (speech.Contains("job"))
            {
                Say("I charted hidden currents and mapped the archipelago’s secret routes. My compass is the music of the wind.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit is as restless as the Atlantic, ever searching, never anchored.");
            }
            else if (speech.Contains("cabo verde"))
            {
                Say("Cabo Verde, a crown of isles in the blue Atlantic, forged by wind, salt, and music.");
            }
            else if (speech.Contains("isle") || speech.Contains("island") || speech.Contains("archipelago"))
            {
                Say("Each island holds its own story. São Vicente’s music, Santiago’s history, Fogo’s fire—ask me of Mindelo.");
            }
            else if (speech.Contains("mindelo"))
            {
                Say("Mindelo is my heart’s harbor—city of sailors, song, and saudade. Here, music weaves into the salt air.");
            }
            else if (speech.Contains("music"))
            {
                Say("The morna drifts on the breeze, sorrow and hope entwined. Our people sing of longing, of the distant horizon.");
            }
            else if (speech.Contains("morna"))
            {
                Say("Morna is the soul of Cabo Verde. Cesária Évora, the barefoot diva, carried its voice across oceans.");
            }
            else if (speech.Contains("cesaria") || speech.Contains("evora"))
            {
                Say("Ah, Cesária Évora! Her voice could calm storms. Yet even she longed for home and the open sea.");
            }
            else if (speech.Contains("sea") || speech.Contains("ocean"))
            {
                Say("The Atlantic is a living map—its winds and tides reveal secrets to those who listen. Seek the Harmattan.");
            }
            else if (speech.Contains("harmattan"))
            {
                Say("The Harmattan is a dry wind from the Sahara, whispering across our isles and guiding old sailors. Yet not all winds are so kind—some speak of the fog.");
            }
            else if (speech.Contains("fog"))
            {
                Say("The fog hides dangers and treasures alike. Once, a hidden cove revealed itself through the song of a seabird—ask me of treasure if you dare, but know that real rewards go to those who discover the secret word: 'seabird'.");
            }
			else if (speech.Contains("sailor") || speech.Contains("navigator"))
			{
				Say("A navigator is part sailor, part dreamer. We trust in stars, tides, and the patience to read the ever-changing sky.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("The southern stars guided my journeys. I charted paths by the Cross and the ever-faithful Dog Star.");
			}
			else if (speech.Contains("cross"))
			{
				Say("The Southern Cross marks the way home on moonless nights, shining over Cabo Verde’s waters like a promise.");
			}
			else if (speech.Contains("wind"))
			{
				Say("Winds are both friend and foe. The trade winds carried explorers westward, but storms remind us to respect the sea.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Every sailor fears the tempests. But storms teach humility and grant stories worth retelling in the taverns of Mindelo.");
			}
			else if (speech.Contains("fogo"))
			{
				Say("Fogo is an island of fire and ash, with vineyards growing in old lava. The volcano’s spirit lives in its people.");
			}
			else if (speech.Contains("santiago"))
			{
				Say("Santiago is the mother island—its history shaped by sailors, merchants, and the pulse of distant continents.");
			}
			else if (speech.Contains("salt") || speech.Contains("sal"))
			{
				Say("Salt is the gift of the sea. In Sal and Maio, salt pans glisten like mirrors beneath the sun.");
			}
			else if (speech.Contains("ship") || speech.Contains("ships"))
			{
				Say("Many ships passed these isles—traders, explorers, and sometimes pirates. The ocean remembers them all.");
			}
			else if (speech.Contains("pirate") || speech.Contains("pirates"))
			{
				Say("There were pirates, aye! They came for riches, but the islands taught them respect for the winds and hidden shoals.");
			}
			else if (speech.Contains("shoal") || speech.Contains("shoals"))
			{
				Say("Shoals are the ocean’s secrets—treacherous, but sometimes sheltering rare shells and treasures lost from old ships.");
			}
			else if (speech.Contains("shell") || speech.Contains("shells"))
			{
				Say("Island children collect cowrie shells for luck. Each one is a story carried from distant shores.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Stories drift on the tide—tales of lost love, old battles, and the laughter of fishermen after a long night.");
			}
			else if (speech.Contains("night"))
			{
				Say("Nights on the islands are alive with music and the smell of roasting fish. Some say the spirits of ancestors dance with us until dawn.");
			}
			else if (speech.Contains("fish") || speech.Contains("fisherman") || speech.Contains("fishermen"))
			{
				Say("The fishermen of Cabo Verde are fearless. They read the ocean like a book and return at sunrise with the catch of the day.");
			}
			else if (speech.Contains("sunrise"))
			{
				Say("Sunrise turns the sea to gold. That first light is a blessing—a promise that every journey begins anew.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("Every voyage starts with a blessing, a prayer to the spirits of wind and water for safe return.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("Some spirits protect us, others test us. It is wise to leave an offering on the shore before a long journey.");
			}
			else if (speech.Contains("offering") || speech.Contains("offerings"))
			{
				Say("A shell, a coin, or a whispered promise—any small gift may bring luck from the sea’s guardians.");
			}
			else if (speech.Contains("promise"))
			{
				Say("To the ocean, every promise matters. Break your word, and the winds will remember.");
			}
			else if (speech.Contains("dance"))
			{
				Say("We dance to forget hardship and to celebrate life. The funaná and coladeira are as lively as a sailor’s step.");
			}
			else if (speech.Contains("funana") || speech.Contains("coladeira"))
			{
				Say("Funana is the heartbeat of Santiago—fast and joyful. Coladeira is playful, swirling like the eddies near Brava.");
			}
			else if (speech.Contains("brava"))
			{
				Say("Brava is the flower island, shrouded in mist and legend. Its sailors are said to dream of distant lands.");
			}
			else if (speech.Contains("legend") || speech.Contains("legends"))
			{
				Say("Legends are born from longing and bravery. Ask the old men at the harbor, and you’ll hear stories of mermaids and lost cities.");
			}
			else if (speech.Contains("mermaid") || speech.Contains("mermaids"))
			{
				Say("Some claim to have seen mermaids near the shoals, singing to the moon. Who am I to doubt them?");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("Every sailor searches for treasure, but only those who notice the signs of nature will find the true bounty.");
            }
            else if (speech.Contains("seabird"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, traveler. The seabirds rest before they fly again. Return when the tides have shifted.");
                }
                else
                {
                    Say("You have listened well and followed the seabird's call. Accept this Treasure Chest of Cabo Verde—may it guide you to distant horizons.");
                    from.AddToBackpack(new TreasureChestOfCaboVerde());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Fair winds and following seas, friend of the islands.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Mindelo, morna, the Harmattan, or perhaps... the seabirds.");
                }
            }

            base.OnSpeech(e);
        }

        public AnaDoMar(Serial serial) : base(serial) { }

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
