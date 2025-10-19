using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Anne Bonny")]
    public class AnneBonny : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AnneBonny() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Anne Bonny";
            Body = 0x191; // Human female body

            // Stats
            Str = 90;
            Dex = 80;
            Int = 95;
            Hits = 75;

            // Unique Pirate/Island Appearance
            AddItem(new FancyShirt() { Name = "Emerald Sea Silk Blouse", Hue = 1372 });
            AddItem(new GuildedKilt() { Name = "Nassau Buccaneer Sash", Hue = 1153 });
            AddItem(new Cloak() { Name = "Hurricane Winds Cloak", Hue = 1177 });
            AddItem(new FeatheredHat() { Name = "Queen of Nassau Plumed Tricorn", Hue = 2116 });
            AddItem(new Boots() { Name = "Rum Runner’s Boots", Hue = 1109 });
            AddItem(new BodySash() { Name = "Lucayan Island Sash", Hue = 1279 });
            AddItem(new Cutlass() { Name = "Reef Edge Cutlass", Hue = 1166 });

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
                Say("They call me Anne Bonny, Pirate Queen of Nassau and scourge of the Spanish Main.");
            }
            else if (speech.Contains("job"))
            {
                Say("Me job? Sailing the turquoise Bahamian seas, seeking adventure, gold, and a fair bit o’ rum.");
            }
            else if (speech.Contains("health"))
            {
                Say("The sea breeze keeps me well, though I’ve faced storm and cannonball alike.");
            }
            else if (speech.Contains("pirate"))
            {
                Say("Aye, I sailed with Calico Jack and Mary Read, legends of the Caribbean, free as the ocean wind.");
            }
            else if (speech.Contains("nassau"))
            {
                Say("Nassau is a haven for those who live by their own rules. Pirates, smugglers, and dreamers alike.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Treasure isn’t always gold—sometimes it’s freedom, or the secrets hidden in the coral reefs.");
            }
            else if (speech.Contains("legend"))
            {
                Say("The Bahamian islands hold tales of ghost ships, lost cities, and riches beneath the waves.");
            }
            else if (speech.Contains("sea"))
            {
                Say("The sea is a fickle friend. She gives and she takes, but she never forgets.");
            }
            else if (speech.Contains("ship"))
            {
                Say("My ship was the *Revenge*, swift and sturdy. She danced with the hurricanes and outran the navy!");
            }
            else if (speech.Contains("bahama") || speech.Contains("bahamas"))
            {
                Say("Bahamas: more than paradise—each island a story, each reef a legend.");
            }
            else if (speech.Contains("rum"))
            {
                Say("Rum fuels a pirate’s courage and keeps tales lively at the tavern. Fancy a drink?");
            }
            else if (speech.Contains("hurricane"))
            {
                Say("The hurricanes shape these islands. Only the bold survive their wrath—and some treasure washes up after!");
            }
            else if (speech.Contains("lucayan"))
            {
                Say("The Lucayan were the first islanders here—wise, peaceful, gone with the wind but not forgotten.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the greatest treasure. That’s what brought me to Nassau, and what kept me on the sea.");
            }
            else if (speech.Contains("gold"))
            {
                Say("They say Spanish galleons still rest on the sea floor, heavy with gold. If you have the map, the gold is yours!");
            }
            else if (speech.Contains("map"))
            {
                Say("Maps lead to many things—fortune, danger, or sometimes, a greater adventure than you expect.");
            }
            else if (speech.Contains("secret"))
            {
                Say("Every island has its secrets. The cleverest pirates keep them well—and share them only for a price.");
            }
            else if (speech.Contains("coral"))
            {
                Say("The coral reefs hide not only fish and turtles, but sometimes chests lost to storms and pirates alike.");
            }
			else if (speech.Contains("jack rackham") || speech.Contains("calico jack"))
			{
				Say("Calico Jack Rackham—now there was a pirate with style! He fancied his colors and his freedom, and I fancied a bit of both.");
			}
			else if (speech.Contains("mary read") || speech.Contains("mary"))
			{
				Say("Mary Read sailed at my side, fierce as any man and twice as clever. Together, we made history the navy won’t forget!");
			}
			else if (speech.Contains("governor") || speech.Contains("woodes rogers"))
			{
				Say("Governor Woodes Rogers tried to bring law to Nassau. He nearly ended the Pirate Republic, but some of us slipped away.");
			}
			else if (speech.Contains("blackbeard") || speech.Contains("teach"))
			{
				Say("Blackbeard—Edward Teach—was both a terror and a legend. His shadow still lingers in these waters, or so they say.");
			}
			else if (speech.Contains("port royal"))
			{
				Say("Port Royal, once the wickedest city in the West Indies, sank into the sea. Some say its treasure is still waiting below.");
			}
			else if (speech.Contains("parrot"))
			{
				Say("A pirate’s best mate is a parrot with a sharp beak and a sharper tongue. Mine could outcurse most captains!");
			}
			else if (speech.Contains("sunken") || speech.Contains("wreck") || speech.Contains("shipwreck"))
			{
				Say("The Bahamian shallows are littered with shipwrecks—Spanish galleons, pirate sloops, even a navy man-o’-war or two.");
			}
			else if (speech.Contains("compass"))
			{
				Say("A trusty compass can guide you home—or to fortune, if you know how to read the winds and stars.");
			}
			else if (speech.Contains("island") || speech.Contains("islands"))
			{
				Say("Each island in the Bahamas has its own secrets. Blue holes, caves, wild pigs, and ghosts from the old days.");
			}
			else if (speech.Contains("ghost") || speech.Contains("ghosts"))
			{
				Say("Some nights, when the moon is high, you’ll hear the ghosts of old pirates singing across the water.");
			}
			else if (speech.Contains("music") || speech.Contains("song") || speech.Contains("drum"))
			{
				Say("Music is the heart of the islands! Drumbeats and old pirate shanties can turn any night into a celebration.");
			}
			else if (speech.Contains("festival"))
			{
				Say("During Junkanoo, all of Nassau dances! Bright colors, wild costumes, and the rhythm of the islands.");
			}
			else if (speech.Contains("blue hole"))
			{
				Say("The blue holes are bottomless mysteries—some say they’re gateways to other worlds, or hiding places for pirate gold.");
			}
			else if (speech.Contains("turtle") || speech.Contains("turtles"))
			{
				Say("Sea turtles nest on Bahamian beaches. They’ve seen more adventures than any pirate, and keep more secrets, too!");
			}
			else if (speech.Contains("shark") || speech.Contains("sharks"))
			{
				Say("Sharks? Aye, you’ll find them in these waters. Best keep your toes out if you’re not a good swimmer!");
			}
			else if (speech.Contains("fishing") || speech.Contains("fish"))
			{
				Say("Fishing in the Bahamas—now that’s the life! Grouper, snapper, and a tale for every catch.");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar"))
			{
				Say("The Nassau market bustles with spices, shells, and secrets—if you’ve coin or cleverness, you’ll find a bargain.");
			}
			else if (speech.Contains("sloop") || speech.Contains("brigantine"))
			{
				Say("My favorite ship was a sloop—fast, agile, and perfect for slipping past blockades.");
			}
			else if (speech.Contains("storm") || speech.Contains("lightning"))
			{
				Say("A true pirate learns to read the skies. Storms can bring ruin—or wash up something valuable if you survive!");
			}
			else if (speech.Contains("sun") || speech.Contains("sand"))
			{
				Say("Golden sun and warm sand—sometimes I think those are worth more than all the gold in the Spanish treasury.");
			}
			else if (speech.Contains("flag") || speech.Contains("jolly roger"))
			{
				Say("Our flag was the Jolly Roger—skull and crossbones. Fly it proud and watch the merchantmen tremble!");
			}
			else if (speech.Contains("outlaw"))
			{
				Say("To be an outlaw here is to be free! Nassau was the Pirate Republic—our own law, our own code.");
			}
			else if (speech.Contains("bay") || speech.Contains("harbor"))
			{
				Say("The harbor at Nassau is deep and well-hidden—a pirate’s dream! Ships come and go, and the law can’t follow.");
			}
			else if (speech.Contains("pearl") || speech.Contains("conch"))
			{
				Say("Bahamians love their conch—fried, stewed, or in a salad. And pearls? They’re the sea’s secret jewels.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("I have a hundred stories and only so much rum. Ask, and I’ll share one you’ll not soon forget.");
			}			
            else if (speech.Contains("adventure"))
            {
                Say("Adventure calls to the bold! If ye follow the clues, you’ll find a legend of your own.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest") || speech.Contains("legend"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("I’ve shared my legend for now, friend. Come back in a while—there’s always more treasure for the patient.");
                }
                else
                {
                    Say("You’ve unraveled the legend! Take this Treasure Chest of Bahamian Legends—may the wind always fill your sails!");
                    from.AddToBackpack(new TreasureChestOfBahamianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Fair winds and full sails, mate! May fortune find you on these Bahamian shores.");
            }
            else
            {
                // Optional hint for discovery
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of Nassau, treasure, pirate legends, or the hurricanes that shape these islands.");
                }
            }

            base.OnSpeech(e);
        }

        public AnneBonny(Serial serial) : base(serial) { }

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
