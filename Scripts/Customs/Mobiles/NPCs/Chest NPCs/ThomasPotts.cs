using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Thomas Potts")]
    public class ThomasPotts : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ThomasPotts() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Thomas Potts";
            Body = 0x190; // Human male

            // Unique Outfit
            AddItem(new WideBrimHat() { Name = "Potts’ Weathered Hat", Hue = 2107 });
            AddItem(new FancyShirt() { Name = "Bayman’s Salt-Stained Tunic", Hue = 2515 });
            AddItem(new BodySash() { Name = "St. George’s Red Sash", Hue = 2071 });
            AddItem(new ShortPants() { Name = "Logwood Cutter’s Breeches", Hue = 2025 });
            AddItem(new Boots() { Name = "Riverbank Boots", Hue = 1109 });
            AddItem(new Cloak() { Name = "Sea Breeze Cloak", Hue = 1141 });
            AddItem(new Cutlass() { Name = "Belizean Defender’s Cutlass", Hue = 1175 });

            SpeechHue = 2101;

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
                Say("Aye, I’m Thomas Potts—old Bayman and teller of Belizean tales. Pull up a barrel and listen!");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a logwood cutter, then a defender at St. George’s Caye. Now? I keep stories alive for curious travelers.");
            }
            else if (speech.Contains("health"))
            {
                Say("Fit as a mangrove crab, though the rum helps with the aches.");
            }
            else if (speech.Contains("bayman") || speech.Contains("baymen"))
            {
                Say("We Baymen braved the wilds—logwood, rivers, and storms. Made a home where others saw only jungle.");
            }
            else if (speech.Contains("logwood"))
            {
                Say("Logwood brought fortune and trouble! Its dye made the English rich, and pirates greedy.");
            }
            else if (speech.Contains("st. george") || speech.Contains("caye"))
            {
                Say("The Battle of St. George’s Caye in 1798—now that was a day! We stood strong, Baymen and slaves alike, and sent the Spanish packing.");
            }
            else if (speech.Contains("battle"))
            {
                Say("With cutlass in hand and hope in heart, we faced the Spanish fleet. The odds? Grim as a river at night!");
            }
            else if (speech.Contains("spanish"))
            {
                Say("The Spanish tried to claim Belize, but they met stubborn Baymen and fierce allies.");
            }
            else if (speech.Contains("slave") || speech.Contains("slaves"))
            {
                Say("Don’t forget the slaves! Without their courage and labor, the Baymen’d have been lost.");
            }
            else if (speech.Contains("ally") || speech.Contains("allies"))
            {
                Say("My greatest allies? The free men, the Garifuna, the Maya, and anyone with fire in their heart for Belize.");
            }
            else if (speech.Contains("garifuna"))
            {
                Say("Garifuna people brought drumming and dreams to these shores—hear their drums, and you’ll know Belize is alive!");
            }
            else if (speech.Contains("maya"))
            {
                Say("The Maya are the oldest storytellers of this land—builders of temples, keepers of time and stars.");
            }
            else if (speech.Contains("temple") || speech.Contains("temples"))
            {
                Say("Venture inland and you’ll find Maya temples rising from the jungle, guarding ancient secrets.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("Secrets, eh? Some say the jungle hides more than gold—lost cities, ancient magic, and the spirit of the land itself.");
            }
            else if (speech.Contains("jungle"))
            {
                Say("The jungle is wild—home to jaguar, howler monkey, and the mysteries of Belize.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Belizean legends are many—like Tata Duende, the one-footed forest spirit who loves a good prank!");
            }
            else if (speech.Contains("tata duende") || speech.Contains("duende"))
            {
                Say("Beware Tata Duende! No thumbs, a tall hat, and a laugh that’ll haunt your dreams.");
            }
            else if (speech.Contains("ghost") || speech.Contains("spirit"))
            {
                Say("Spirits drift through these lands—some kind, some not. Give them respect and a bit of rum.");
            }
            else if (speech.Contains("rum"))
            {
                Say("Belizean rum warms the soul! Care for a sip? Just don’t ask where it’s brewed.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("I know tales of pirates, jaguars, and lost gold. Which one tickles your fancy?");
            }
			else if (speech.Contains("british"))
			{
				Say("Aye, the British claimed these shores, but the jungle had other ideas. We learned to live with rain, bugs, and each other.");
			}
			else if (speech.Contains("mosquito") || speech.Contains("mosquitos"))
			{
				Say("The real rulers of Belize? Mosquitos! We’d slap them away by day, and curse them by night.");
			}
			else if (speech.Contains("mahogany"))
			{
				Say("Mahogany’s the king of trees—built ships, homes, and dreams. Many a Bayman risked life and limb to haul it out the bush.");
			}
			else if (speech.Contains("bush"))
			{
				Say("The bush is thick and tricky—one wrong turn, and you’re monkey food! Best travel with a friend who knows the trails.");
			}
			else if (speech.Contains("monkey") || speech.Contains("howler"))
			{
				Say("Ever heard a howler monkey at dawn? Loud enough to wake the dead and startle the Spanish!");
			}
			else if (speech.Contains("jaguar"))
			{
				Say("The jaguar’s the silent king of the jungle. If you see one—don’t run. Just hope he’s already had breakfast.");
			}
			else if (speech.Contains("coast"))
			{
				Say("The coast’s where the breeze is cool and the fish are plenty. Nothing like a sunrise over the Caribbean.");
			}
			else if (speech.Contains("fish") || speech.Contains("fishing"))
			{
				Say("Fish, crab, lobster—Belize waters are generous if you’re patient. The trick is knowing where the tarpon hide.");
			}
			else if (speech.Contains("lobster"))
			{
				Say("Lobster fest is a feast like no other! Best boiled, with pepper sauce and a cold drink.");
			}
			else if (speech.Contains("pepper"))
			{
				Say("Belizean pepper sauce’ll wake up your tongue! Some like it, some fear it, all respect it.");
			}
			else if (speech.Contains("food") || speech.Contains("cooking"))
			{
				Say("Food? Try stew chicken, rice and beans, or a hot fry jack—simple and hearty, just how Baymen like it.");
			}
			else if (speech.Contains("fry jack") || speech.Contains("fryjacks"))
			{
				Say("Fry jacks—now you’re talking! Hot dough, crisp and soft, perfect for soaking up stew.");
			}
			else if (speech.Contains("rum punch"))
			{
				Say("Rum punch’ll set your feet dancing and your heart singing. Just watch your step after a few rounds!");
			}
			else if (speech.Contains("weather"))
			{
				Say("In Belize, weather changes quick—sunshine, then rain, then back again. Always carry a hat and a joke.");
			}
			else if (speech.Contains("hurricane"))
			{
				Say("Hurricanes? We respect ‘em and we fear ‘em. When the wind howls, you tie everything down—including yourself!");
			}
			else if (speech.Contains("music"))
			{
				Say("From Garifuna drums to Creole brukdown, Belizean music makes your feet move, even if you don’t want them to.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("A Garifuna drumbeat can call the rain, chase away worries, or start a party that lasts ‘til sunrise.");
			}
			else if (speech.Contains("creole"))
			{
				Say("Creole’s the language of the Baymen—quick wit, sharp tongue, and a way of turning trouble into laughter.");
			}
			else if (speech.Contains("laugh") || speech.Contains("laughter"))
			{
				Say("A Bayman’s best weapon is laughter—if you can’t laugh at the troubles, they’ll eat you alive!");
			}			
            else if (speech.Contains("pirate") || speech.Contains("pirates"))
            {
                Say("Pirates plundered these waters—some turned Bayman, others left their bones on the reef.");
            }
            else if (speech.Contains("reef"))
            {
                Say("The Barrier Reef? Jewel of Belize! Bright as a parrot and twice as lively.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest") || speech.Contains("treasure"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Easy there! Legends take time to find. Come back after a bit for another tale.");
                }
                else
                {
                    Say("For your curiosity and courage, I offer a Treasure Chest of Belizean Legends—may it inspire your own adventures!");
                    from.AddToBackpack(new TreasureChestOfBelizeanLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Safe travels! May the winds favor you, and the stories never run dry.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Baymen, logwood, legends, or the Battle of St. George’s Caye.");
                }
            }

            base.OnSpeech(e);
        }

        public ThomasPotts(Serial serial) : base(serial) { }

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
