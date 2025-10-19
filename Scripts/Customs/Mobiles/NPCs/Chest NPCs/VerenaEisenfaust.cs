using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Verena Eisenfaust")]
    public class VerenaEisenfaust : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public VerenaEisenfaust() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Verena Eisenfaust";
            Title = "the Shieldmaiden of Helvetia";
            Body = 0x191; // Human female
            SpeechHue = 0;

            // Stats
            Str = 90;
            Dex = 65;
            Int = 80;
            Hits = 80;

            // Unique Outfit
            var helm = new CloseHelm { Name = "Gilded Mountain Helm", Hue = 2101 };
            AddItem(helm);

            var sash = new BodySash { Name = "Shieldmaiden's Sash", Hue = 2106 };
            AddItem(sash);

            var chest = new FemalePlateChest { Name = "Ironfist Plate Chest", Hue = 2424 };
            AddItem(chest);

            var boots = new ThighBoots { Name = "Alpine Thighboots", Hue = 2309 };
            AddItem(boots);

            var surcoat = new Surcoat { Name = "Crimson Surcoat of Courage", Hue = 2117 };
            AddItem(surcoat);

            var axe = new WarAxe { Name = "WarAxe of the Helvetian Shieldmaiden", Hue = 2507 };
            AddItem(axe);

            // Appearance
            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x203B, 0x2044); // Varied female hairstyles
            HairHue = Utility.RandomHairHue();

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
                Say("I am Verena Eisenfaust, the Shieldmaiden of Helvetia.");
            else if (speech.Contains("health"))
                Say("My health is steadfast as the mountain stone.");
            else if (speech.Contains("job"))
                Say("My job is to guard Helvetian secrets and teach courage to those who seek it.");
            else if (speech.Contains("shieldmaiden"))
                Say("A shieldmaiden stands with courage at the vanguard, defending her kin and homeland.");
            else if (speech.Contains("helvetia"))
                Say("Helvetia is a land of peaks, lakes, and proud warriors. Our history is carved in stone and song.");
            else if (speech.Contains("courage"))
                Say("Courage is not the absence of fear, but the will to stand fast despite it. Will you prove your courage?");
            else if (speech.Contains("prove"))
                Say("Many have tried. To prove your courage, you must answer this: What is the greatest treasure of Helvetia?");
			else if (speech.Contains("history"))
				Say("Helvetia’s history is written in struggle and triumph, from lake to summit. Our ancestors forged peace and freedom with courage and wit.");
			else if (speech.Contains("ancestors"))
				Say("Our ancestors braved the harshest winters, standing together against all odds. Their wisdom guides us still.");
			else if (speech.Contains("summit"))
				Say("On the highest summits, one can feel the spirit of Helvetia. Each peak remembers every oath and every victory.");
			else if (speech.Contains("valley"))
				Say("The valleys cradle our villages, green with hope and hard work. Every meadow holds stories of kinship and endurance.");
			else if (speech.Contains("song"))
				Say("Songs keep our legends alive. When the wind howls through the pines, it carries the ballads of Helvetian heroes.");
			else if (speech.Contains("honor"))
				Say("Honor is earned, not given. A true Helvetian stands by their word, even when the path is hardest.");
			else if (speech.Contains("word"))
				Say("A shieldmaiden’s word is her bond. Oaths once sworn echo louder than any horn.");
			else if (speech.Contains("enemy"))
				Say("Many sought to claim our lands, but none could break Helvetian resolve. Even the fiercest enemy respects our unity.");
			else if (speech.Contains("resolve"))
				Say("Resolve is steel in the soul. It turns fear into bravery and hesitation into action.");
			else if (speech.Contains("axe"))
				Say("This axe has cleaved many a shield and felled many foes, but it is also a tool for building—wood, homes, and hope.");
			else if (speech.Contains("shield"))
				Say("A shield defends more than the bearer; it shelters kin, friends, and all you hold dear.");
			else if (speech.Contains("winter"))
				Say("Winter tests our mettle. In the snows, we learn endurance and the warmth of community.");
			else if (speech.Contains("community"))
				Say("A village alone may fall, but together, we thrive. Share your fire and your bread, and Helvetia’s strength will never fade.");
			else if (speech.Contains("wisdom"))
				Say("Wisdom comes from listening to elders, the land, and your own heart.");
			else if (speech.Contains("elders"))
				Say("Our elders hold the stories of generations. Honor them, and their blessings will follow you.");
			else if (speech.Contains("blessing"))
				Say("I give you this blessing: May your path be steady as the stone and your courage bright as dawn.");
			else if (speech.Contains("stone"))
				Say("Stone endures. Let your resolve be unbreakable, and you too will weather every storm.");
			else if (speech.Contains("dawn"))
				Say("Every dawn brings a new chance to prove your worth. Seize it, for Helvetia watches.");				
            else if (speech.Contains("treasure"))
                Say("The greatest treasure is the unity of our people and the freedom of our lands. But perhaps you seek a different prize?");
            else if (speech.Contains("prize"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You have claimed my prize too recently. Return when Helvetian winds have shifted.");
                }
                else
                {
                    Say("You have shown Helvetian spirit. Take this Helvetian Treasure Chest as a token of courage and unity!");
                    from.AddToBackpack(new HelvetianTreasureChest());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("unity"))
                Say("Unity is the strength that binds Helvetia. Divided we fall, united we endure.");
            else if (speech.Contains("freedom"))
                Say("Freedom is the birthright of every Helvetian. We defend it with shield and axe.");
            else if (speech.Contains("mountain"))
                Say("The mountains guard us, and we guard the mountains. Their strength lives in our hearts.");
            else if (speech.Contains("legend"))
                Say("Legends keep our history alive. Every Helvetian writes a line in the saga.");
            // Add more keywords as you wish for more depth!

            base.OnSpeech(e);
        }

        public VerenaEisenfaust(Serial serial) : base(serial) { }

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
