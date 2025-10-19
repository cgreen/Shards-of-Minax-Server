using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Grace O'Malley")]
    public class GraceOMalley : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public GraceOMalley() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Grace O'Malley";
            Body = 0x191; // Human female body

            // Unique Pirate Queen Outfit
            AddItem(new FancyShirt() { Name = "Sea-Queen's Linen Blouse", Hue = 1153 });
            AddItem(new GuildedKilt() { Name = "Emerald Isles Sash-Kilt", Hue = 1372 });
            AddItem(new Cloak() { Name = "Cloak of the Wild Atlantic", Hue = 1366 });
            AddItem(new Bandana() { Name = "Connemara Tide Bandana", Hue = 1370 });
            AddItem(new FurBoots() { Name = "Storm-walker Boots", Hue = 2101 });
            AddItem(new BodySash() { Name = "Banner of the O'Malley", Hue = 1266 });

            // Weapon: Cutlass
            AddItem(new Cutlass() { Name = "Pirate Queen's Cutlass", Hue = 1172 });

            // Speech Hue (deep green)
            SpeechHue = 1370;

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
                Say("They call me Grace O'Malley, or Gráinne Mhaol, the Sea Queen of Connacht.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some say pirate, some say chieftain. I say I am mistress of the waves and guardian of my clan.");
            }
            else if (speech.Contains("health"))
            {
                Say("I’ve weathered many storms, lost battles and won legends—my spirit is unbroken.");
            }
            else if (speech.Contains("pirate"))
            {
                Say("Aye, I sailed these coasts long before the English dared call me pirate.");
            }
            else if (speech.Contains("queen"))
            {
                Say("Not crowned by gold, but by salt and courage. The people of Clew Bay know their queen.");
            }
            else if (speech.Contains("connacht"))
            {
                Say("Connacht is wild land, west of the world—its isles are scattered like emeralds on the sea.");
            }
            else if (speech.Contains("sea") || speech.Contains("ocean"))
            {
                Say("The sea is my true home. Its tides carried my fortune and its storms tested my mettle.");
            }
            else if (speech.Contains("england") || speech.Contains("english"))
            {
                Say("Queen Elizabeth herself once called me to parley. I did not bow to her, nor to any English lord.");
            }
            else if (speech.Contains("elizabeth"))
            {
                Say("We met as queens, one of the sea and one of the throne. She feared what she could not conquer.");
            }
            else if (speech.Contains("parley"))
            {
                Say("Parley is sacred at sea. No man or woman dares break their word while salt is in the air.");
            }
            else if (speech.Contains("clan"))
            {
                Say("The O'Malleys ruled the waves from Clare Island, my birthright and my fortress.");
            }
            else if (speech.Contains("island") || speech.Contains("clare"))
            {
                Say("Clare Island is where my heart lies—high cliffs, wild winds, and secrets of the old gods.");
            }
            else if (speech.Contains("castle"))
            {
                Say("Rockfleet Castle, on the shore of Clew Bay, watched over my family and my fleet.");
            }
            else if (speech.Contains("fleet"))
            {
                Say("My ships were swift as seabirds, painted with the colors of the west wind.");
            }
            else if (speech.Contains("west wind") || speech.Contains("westwind"))
            {
                Say("The west wind carries voices and secrets across the Atlantic. Listen well and you may earn a treasure of true Irish history.");
            }
            else if (speech.Contains("ireland"))
            {
                Say("Ireland is a land of stories and sorrow, music and memory. Every stone holds a legend.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("My story is writ upon the waves. Ask of the pirate code or the ancient stones if you seek adventure.");
            }
            else if (speech.Contains("adventure"))
            {
                Say("Fortune favors the bold. There’s treasure for those with courage to follow the old ways.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Treasure is not always gold. Sometimes, it is freedom, or the knowledge of your name remembered.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("I would rather drown at sea than live chained on land. Freedom is my legacy.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A true legacy outlasts lifetimes. Will yours?");
            }
            else if (speech.Contains("ship") || speech.Contains("ships"))
            {
                Say("Each ship in my fleet had its own soul. The saltwater keeps their secrets.");
            }
            else if (speech.Contains("salt") || speech.Contains("saltwater"))
            {
                Say("Salt stings and heals. It preserves stories for those willing to taste the wind.");
            }
            else if (speech.Contains("wind"))
            {
                Say("The wind changes, but the west wind always brings me home.");
            }
            else if (speech.Contains("home"))
            {
                Say("My home is wherever the horizon touches the sea and the gulls call my name.");
            }
            else if (speech.Contains("gull") || speech.Contains("gulls"))
            {
                Say("Gulls are messengers—if you hear them cry, a storm or fortune may follow.");
            }
            else if (speech.Contains("storm"))
            {
                Say("Storms are teachers; you learn to sail or you learn to swim.");
            }
            else if (speech.Contains("swim"))
            {
                Say("The cold Atlantic sharpens the senses. Only fools and heroes dive in willingly.");
            }
            else if (speech.Contains("atlantic"))
            {
                Say("Beyond the Atlantic lies new worlds and old dreams.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are sails that carry us beyond the horizon. What do you seek?");
            }
            else if (speech.Contains("code") || speech.Contains("pirate code"))
            {
                Say("The pirate code is honor among thieves. Trust, once broken, is never mended.");
            }
            else if (speech.Contains("honor"))
            {
                Say("Honor is not given, but earned with blade and word.");
            }
			else if (speech.Contains("family"))
			{
				Say("Family is anchor and sail. My father taught me the tides, my sons learned to fight for their name.");
			}
			else if (speech.Contains("father"))
			{
				Say("Dubhdara O'Malley, a chief of the sea—he left me a fleet and a fierce spirit.");
			}
			else if (speech.Contains("son") || speech.Contains("sons"))
			{
				Say("My sons, Tibbot and Owen, sailed with me. The blood of O'Malley runs wild as the Atlantic.");
			}
			else if (speech.Contains("music") || speech.Contains("song") || speech.Contains("harp"))
			{
				Say("There’s always a tune in the wind. The harp sings for Ireland’s joy and sorrow alike.");
			}
			else if (speech.Contains("legend"))
			{
				Say("Legends are truths polished by time. Mine began on Clare Island, but who knows where it will end?");
			}
			else if (speech.Contains("whiskey"))
			{
				Say("A drop of Irish whiskey warms the soul after a cold crossing, but too much and you’ll forget your own name.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Trust is as fragile as a ship’s mast. Betrayal stings worse than any blade.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("The sea breeds many enemies—some wear armor, others a smile.");
			}
			else if (speech.Contains("ally") || speech.Contains("allies"))
			{
				Say("Allies are precious. Even the fiercest pirate needs a friend in the fog.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is setting sail when all the signs point to storm. I’ve never lacked for it.");
			}
			else if (speech.Contains("rebellion"))
			{
				Say("The English called us rebels. We called ourselves free. There’s the difference.");
			}
			else if (speech.Contains("fishing"))
			{
				Say("A pirate’s breakfast: salt herring and the hope of gold at noon.");
			}
			else if (speech.Contains("herring"))
			{
				Say("Silver as the moon, quick as luck. My people fished these waters before the world kept count of kings.");
			}
			else if (speech.Contains("banquet") || speech.Contains("feast"))
			{
				Say("A proper feast: fresh fish, hard bread, and stories told louder than the storm outside.");
			}
			else if (speech.Contains("gaelic") || speech.Contains("language"))
			{
				Say("Our tongue is old as the hills and tricky as a fox. The English never learned its secrets.");
			}
			else if (speech.Contains("fox"))
			{
				Say("Clever and bold, the fox survives where brutes fall. Sometimes I wish I had a fox’s nine lives.");
			}
			else if (speech.Contains("jail") || speech.Contains("prison"))
			{
				Say("I’ve escaped more jails than storms. Stone walls don’t like the taste of O’Malley blood.");
			}
			else if (speech.Contains("escape"))
			{
				Say("A good escape is half-planned, half-blessed. And always involves a boat.");
			}
			else if (speech.Contains("boat"))
			{
				Say("From curraghs to galleys, if it floats, I’ve captained it. My favorite was always the fastest.");
			}
			else if (speech.Contains("fortune"))
			{
				Say("Fortune favors the daring, but keeps a sharp eye for fools.");
			}
			else if (speech.Contains("poetry"))
			{
				Say("Some fight with swords, others with poems. The Irish have sharp tongues and sharper memories.");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory is the last refuge for the old and the fuel for the young.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("Here’s a blessing: May the wind be always at your back, and your enemies always behind you.");
			}			
            else if (speech.Contains("blade"))
            {
                Say("My cutlass has solved many a riddle the tongue could not.");
            }
            else if (speech.Contains("riddle"))
            {
                Say("Every legend hides a riddle, and every riddle has its reward for the clever.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("west wind") || speech.Contains("westwind"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, sailor. Even the west wind must rest before it returns.");
                }
                else
                {
                    Say("You have listened to the west wind and found its gift. Take this Treasure Chest of Irish History—may your story join the legends of Erin.");
                    from.AddToBackpack(new TreasureChestOfIrishHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the tides favor your journeys, and may you never lack for song or sea.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Connacht, pirates, the west wind, or the story of a queen who would not kneel.");
                }
            }

            base.OnSpeech(e);
        }

        public GraceOMalley(Serial serial) : base(serial) { }

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
