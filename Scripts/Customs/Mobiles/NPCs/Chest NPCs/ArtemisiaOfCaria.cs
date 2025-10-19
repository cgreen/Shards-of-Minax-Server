using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Artemisia")]
    public class ArtemisiaOfCaria : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ArtemisiaOfCaria() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Artemisia of Caria";
            Body = 0x191; // Human female

            // Unique Appearance
            AddItem(new Robe() { Hue = 1319, Name = "Queen’s Silken Robe" });
            AddItem(new BodySash() { Hue = 2125, Name = "Sash of Carian Nobility" });
            AddItem(new Sandals() { Hue = 1266, Name = "Sea-Kissed Sandals" });
            AddItem(new Circlet() { Hue = 1150, Name = "Crown of Halicarnassus" });
            AddItem(new ElegantCollar() { Hue = 2052, Name = "Navarch’s Gorget" });
            AddItem(new GnarledStaff() { Hue = 2955, Name = "Commander's GnarledStaff" });

            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x203C, 0x203D);
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
            {
                Say("I am Artemisia, queen of Caria, once commander beneath the great Xerxes.");
            }
            else if (speech.Contains("job"))
            {
                Say("I ruled from Halicarnassus and led fleets in war upon the restless Aegean.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit endures, as wild as the Carian winds, though my days of conquest are gone.");
            }
            else if (speech.Contains("halicarnassus"))
            {
                Say("The jewel of Caria, famed for its grand Mausoleum and bustling harbor.");
            }
            else if (speech.Contains("mausoleum"))
            {
                Say("A wonder of the world, built for Mausolus, my beloved. It stands as a testament to love and legacy.");
            }
            else if (speech.Contains("mausolus"))
            {
                Say("He was my king and husband. Our union was both alliance and affection.");
            }
            else if (speech.Contains("alliance"))
            {
                Say("In Anatolia, alliances shaped empires and destinies. Even now, I value those who seek unity.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity was my strength in war, and so it shall be in peace. Prove yourself, and a treasure awaits.");
            }
            else if (speech.Contains("xerxes"))
            {
                Say("Xerxes, King of Kings, trusted my counsel and my command in battle.");
            }
            else if (speech.Contains("fleet"))
            {
                Say("My fleet sailed swift and true, carrying Caria’s banners across the sea.");
            }
            else if (speech.Contains("war"))
            {
                Say("War is the crucible of rulers. In the fire of battle, true leaders are forged.");
            }
			else if (speech.Contains("queen"))
			{
				Say("A queen must lead with wisdom and courage. My reign was marked by both alliance and defiance.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is learned from loss as well as victory. The sea has taught me many lessons.");
			}
			else if (speech.Contains("lessons"))
			{
				Say("In war and peace, lessons are everywhere. From trust in allies to the cost of betrayal.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Betrayal can sink a fleet faster than any storm. I have known both loyalty and treachery.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty is the anchor of every ruler. My people’s loyalty was my greatest strength.");
			}
			else if (speech.Contains("strength"))
			{
				Say("True strength lies not in muscle, but in resolve and the power of one’s will.");
			}
			else if (speech.Contains("resolve"))
			{
				Say("Resolve is tested in the face of adversity. When others faltered, I steered Caria’s course true.");
			}
			else if (speech.Contains("caria"))
			{
				Say("Caria, my homeland, thrived between mountain and sea. Its spirit lives on in those who cherish freedom.");
			}
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is dear to every Carian heart. We fought not just for land, but for the right to rule ourselves.");
			}
			else if (speech.Contains("right"))
			{
				Say("A ruler’s right is earned, not given. I earned mine through battle and the trust of my people.");
			}
			else if (speech.Contains("battle"))
			{
				Say("Each battle at sea was a storm—chaos, noise, and swift decisions. My fleet was my shield and sword.");
			}
			else if (speech.Contains("fleet"))
			{
				Say("My fleet was renowned across the Aegean. Each ship a story, each sailor a brother or sister in arms.");
			}
			else if (speech.Contains("aegean"))
			{
				Say("The Aegean Sea, full of peril and promise, was both battlefield and lifeblood for Caria.");
			}
			else if (speech.Contains("promise"))
			{
				Say("Every horizon holds promise, if one dares to seek it. My legacy is for those bold enough to chase their destiny.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny favors those who act. Caria’s fate was shaped by bold hearts and unyielding resolve.");
			}			
            else if (speech.Contains("sea"))
            {
                Say("The sea has ever been my ally—wild, free, and unconquerable.");
            }
            else if (speech.Contains("treasure"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(15); // adjust as desired
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. I have no more treasure for you—return when the tides have changed.");
                }
                else
                {
                    Say("You have shown wisdom worthy of Caria’s legacy. Take this, the Treasure of Anatolia, and honor our memory.");
                    from.AddToBackpack(new TreasureChestOfAnatolia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            base.OnSpeech(e);
        }

        public ArtemisiaOfCaria(Serial serial) : base(serial) { }

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
