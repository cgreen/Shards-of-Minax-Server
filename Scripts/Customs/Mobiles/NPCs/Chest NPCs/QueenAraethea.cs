using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Araethea")]
    public class QueenAraethea : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenAraethea() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Araethea";
            Body = 0x191; // Human female

            // Unique Appearance
            AddItem(new Bonnet() { Name = "Golden Veil of Memory", Hue = 2207 });
            AddItem(new Robe() { Name = "Robes of the Sunken Kingdom", Hue = 2422 });
            AddItem(new BodySash() { Name = "Sash of Lost Coronations", Hue = 1174 });
            AddItem(new ThighBoots() { Name = "ThighBoots of Forgotten Roads", Hue = 1365 });
            AddItem(new StuddedArms() { Name = "Gilded Armlets of the Ancients", Hue = 2155 });
            AddItem(new FancyShirt() { Name = "Ring of Whispered Oaths", Hue = 1154 });
            AddItem(new Cloak() { Name = "Cloak of Mirage Dusk", Hue = 1160 });
            AddItem(new Scepter() { Name = "Scepter of the Final Dawn", Hue = 1281 });

            SpeechHue = 2118;

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
                Say("I am Araethea, last crowned of Naurus, Queen where memory treads softly in sand.");
            else if (speech.Contains("job"))
                Say("I keep the silence of ruins. My task is remembrance, though the world forgets.");
            else if (speech.Contains("health"))
                Say("The flesh is long gone, but my spirit weaves between sun and shadow, unbroken.");
            else if (speech.Contains("naurus"))
                Say("Naurus was an oasis where gold flowed and secrets flourished, now lost beneath drifting dunes.");
            else if (speech.Contains("queen"))
                Say("A crown weighs heavy in the wind. I wore mine with hope, and lost both crown and home.");
            else if (speech.Contains("ruins"))
                Say("Every stone here is a word in the language of endings. Some listen, some merely pass by.");
            else if (speech.Contains("gold"))
                Say("Gold gleamed in our halls, but memory outlasts any treasure—will you listen to our tales?");
            else if (speech.Contains("spirit"))
                Say("My spirit lingers as guardian and guide. Some say I am a curse, others, a blessing.");
            else if (speech.Contains("blessing"))
                Say("Blessings bloom where grief has watered the soil. Look for lilies by the hidden fountain.");
            else if (speech.Contains("dunes"))
                Say("Dunes shift but sometimes reveal what the world has hidden. Curiosity brings fortune.");
            else if (speech.Contains("home"))
                Say("Home is a promise kept in sand and song. Even now, you stand atop our dreams.");
            else if (speech.Contains("song"))
                Say("We sang to the moon each night. If you listen, perhaps you’ll hear echoes at twilight.");
            else if (speech.Contains("treasure"))
                Say("Not all treasures are metal and gems. Wisdom, too, waits beneath the sands.");
            else if (speech.Contains("tales"))
                Say("Ask, and I may share the secret tale of Naurus’s last festival. Only for the truly curious.");
			else if (speech.Contains("king") || speech.Contains("kings"))
			{
				Say("The kings of Naurus are shadows in sand—brave, flawed, and now only stories whispered by the wind.");
			}
			else if (speech.Contains("crown"))
			{
				Say("My crown was forged of gold and hope, but neither could withstand the tides of time.");
			}
			else if (speech.Contains("memory") || speech.Contains("memories"))
			{
				Say("Memories are lanterns in darkness. I am keeper of both the bright and the bitter flames.");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("Shadows gather quickly in forgotten halls. Sometimes, I find solace among them.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon watched Naurus with gentle eyes, guarding secrets that the sun could never touch.");
			}
			else if (speech.Contains("lost"))
			{
				Say("We are all a little lost, some to time, others to longing. Yet, here I remain.");
			}
			else if (speech.Contains("sand") || speech.Contains("sands"))
			{
				Say("The sands are both tomb and tapestry, covering what must be hidden, revealing what must be learned.");
			}
			else if (speech.Contains("fountain"))
			{
				Say("Once, the Fountain of Echoes sang in our courts. Its waters now lie silent beneath the drifting earth.");
			}
			else if (speech.Contains("silver"))
			{
				Say("Silver gleamed brightest at our final festival, catching the tears of those who knew what was to come.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is a stubborn seed, taking root even when the world seems barren.");
			}
			else if (speech.Contains("curse"))
			{
				Say("Some call Naurus cursed; I say it is blessed with memory. Even sorrow is proof we lived and loved.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("To remember is both a blessing and a burden. I carry both, as all queens must.");
			}
			else if (speech.Contains("guardian"))
			{
				Say("I am not the only guardian here. Listen closely, and you may sense others still watching, still waiting.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("In dreams, I walk the golden corridors once more, and the laughter of my people echoes through the halls.");
			}
			else if (speech.Contains("lantern") || speech.Contains("lanterns"))
			{
				Say("Lanterns once lined our streets on festival nights, their glow chasing away both darkness and sorrow.");
			}
			else if (speech.Contains("echo") || speech.Contains("echoes"))
			{
				Say("Echoes linger long after voices fade. Listen, and perhaps you will hear the true story of Naurus.");
			}
			else if (speech.Contains("oath") || speech.Contains("oaths"))
			{
				Say("Every ruler of Naurus swore an oath to protect her people. I still honor mine, in my own way.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Our last festival was a dance of joy and sorrow—every step, a farewell, every song, a promise.");
			}
			else if (speech.Contains("dance"))
			{
				Say("We danced beneath a sky of lanterns, defying the end with every twirl and every heartbeat.");
			}
			else if (speech.Contains("promise") || speech.Contains("promises"))
			{
				Say("Promises are stars on a cloudy night—seen by the faithful, lost to the faithless.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is the last treasure of every fallen kingdom. Seek it, and you may find what gold cannot buy.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every stone here is a story. Some are tragedies, some are dreams—but all are Naurus.");
			}				
            else if (speech.Contains("festival"))
                Say("The last festival glimmered with lanterns and hope. I remember a mask of silver and a dance.");
            else if (speech.Contains("curious"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                    Say("All gifts must rest before being found anew. The sands of time have not yet shifted again.");
                else
                {
                    Say("Curiosity unearths what is hidden. Accept this Treasure Chest of Naurus’s Forgotten Kings—may your own tale be worthy.");
                    from.AddToBackpack(new TreasureChestOfNaurusForgottenKings());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
                Say("May you walk safely among the shifting sands, friend of memory.");
            else
            {
                if (Utility.RandomDouble() < 0.10)
                    Say("Ask me of Naurus, ruins, or the last festival under silver lanterns.");
            }

            base.OnSpeech(e);
        }

        public QueenAraethea(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
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
