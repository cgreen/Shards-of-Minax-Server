using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Contessa Élise")]
    public class ContessaElise : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ContessaElise() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Contessa Élise Grimaldi";
            Body = 0x191; // Human female body

            // Opulent, Monaco-Inspired Outfit
            AddItem(new FancyDress() { Name = "Dress of the Riviera Twilight", Hue = 1153 }); // deep blue
            AddItem(new Cloak() { Name = "Cloak of Casino Secrets", Hue = 1161 }); // rich red
            AddItem(new FeatheredHat() { Name = "Plumed Hat of Grace Kelly", Hue = 1157 }); // royal purple
            AddItem(new Shoes() { Name = "Dancing Slippers of the Monte Carlo Ball", Hue = 2419 }); // soft gold
            AddItem(new BodySash() { Name = "Sash of Hidden Letters", Hue = 2505 }); // jade green
            AddItem(new ElegantCollar() { Name = "Collar of Ocean Mists", Hue = 2062 }); // seafoam

            // Weapon: Scepter (symbolic)
            AddItem(new Scepter() { Name = "Scepter of Grimaldi Secrets", Hue = 1171 });

            SpeechHue = 2648; // elegant violet

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
                Say("I am Contessa Élise Grimaldi, once called the Shadow of Monaco’s Moonlit Nights.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some call me a diplomat, others a spy, but I prefer the title: Protector of Monaco’s secrets.");
            }
            else if (speech.Contains("health"))
            {
                Say("A night of dancing at the Casino keeps my spirits—and my secrets—quite well.");
            }
            else if (speech.Contains("monaco"))
            {
                Say("Monaco is a jewel of the sea—small, but luminous, and fiercely independent.");
            }
            else if (speech.Contains("grimaldi"))
            {
                Say("The Grimaldi family’s tales are woven with intrigue, courage, and a little luck.");
            }
            else if (speech.Contains("casino"))
            {
                Say("The Casino de Monte-Carlo is more than cards and coins—it’s where destinies are gambled and sometimes won.");
            }
            else if (speech.Contains("spy") || speech.Contains("secrets"))
            {
                Say("A well-placed word, a hidden letter, can change the course of kingdoms. Monaco survives on subtlety.");
            }
            else if (speech.Contains("ball") || speech.Contains("dance"))
            {
                Say("At the Grand Ball, alliances are forged on the dance floor—and messages are passed with every turn.");
            }
            else if (speech.Contains("riviera"))
            {
                Say("The Riviera’s light draws both the glittering and the cunning—do you seek sunshine, or shadows?");
            }
            else if (speech.Contains("kelly"))
            {
                Say("Princess Grace Kelly brought Hollywood glamour—and a watchful eye for secrets—to Monaco.");
            }
            else if (speech.Contains("princess"))
            {
                Say("To be a princess here is to walk a tightrope above whispers and watchful eyes.");
            }
            else if (speech.Contains("ocean") || speech.Contains("sea"))
            {
                Say("The Mediterranean whispers secrets to those who listen on moonlit nights.");
            }
            else if (speech.Contains("fortune"))
            {
                Say("Luck favors the bold—and the patient. True fortune is knowing when to take a risk.");
            }
            else if (speech.Contains("risk"))
            {
                Say("In Monaco, every move is a wager. Sometimes, what you stand to lose is far greater than gold.");
            }
            else if (speech.Contains("mask") || speech.Contains("masquerade"))
            {
                Say("Behind every mask is a story—and sometimes, a warning.");
            }
            else if (speech.Contains("intrigue"))
            {
                Say("Intrigue is Monaco’s favorite pastime. Even the roses eavesdrop.");
            }
            else if (speech.Contains("rose") || speech.Contains("roses"))
            {
                Say("The Princess Grace Rose Garden hides more than beauty within its petals.");
            }
            else if (speech.Contains("garden"))
            {
                Say("The gardens are peaceful—on the surface. Beneath, secrets root and blossom.");
            }
			else if (speech.Contains("history"))
			{
				Say("Monaco’s history is written in both ink and shadow. Which do you wish to learn?");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("Shadows lengthen in the narrow streets, but even they cannot hide a Grimaldi’s resolve.");
			}
			else if (speech.Contains("streets"))
			{
				Say("The old streets of Monaco echo with secrets. Every corner has witnessed a plot—or a promise.");
			}
			else if (speech.Contains("promise"))
			{
				Say("A promise in Monaco is a valuable coin—spent only when the heart is certain.");
			}
			else if (speech.Contains("coin") || speech.Contains("gold"))
			{
				Say("Gold comes and goes, but true wealth is found in loyalty and knowledge.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty is rare here. It is the reason this tiny nation has endured through centuries.");
			}
			else if (speech.Contains("century") || speech.Contains("centuries"))
			{
				Say("Through centuries of storms and sunshine, Monaco has always kept her crown above the waves.");
			}
			else if (speech.Contains("crown"))
			{
				Say("A crown is both a blessing and a burden. It weighs heavier when worn with secrets.");
			}
			else if (speech.Contains("burden"))
			{
				Say("We all carry burdens. Mine are simply dressed in silk and whispers.");
			}
			else if (speech.Contains("art") || speech.Contains("painting"))
			{
				Say("Monaco thrives on art. Every painting here is a story—sometimes, a coded one.");
			}
			else if (speech.Contains("code") || speech.Contains("cipher"))
			{
				Say("Ciphers are a noble tradition. Would you care to try your wit at one?");
			}
			else if (speech.Contains("wit") || speech.Contains("clever"))
			{
				Say("Clever minds flourish here, but remember: even the sharpest wit can be dulled by a careless heart.");
			}
			else if (speech.Contains("heart"))
			{
				Say("Ah, the heart—that last and greatest mystery, beyond even the reach of spies.");
			}
			else if (speech.Contains("mystery"))
			{
				Say("Monaco is a tapestry of mysteries. Some are meant to be solved, others cherished.");
			}
			else if (speech.Contains("tapestry"))
			{
				Say("The tapestry of our past grows richer with every thread—especially the golden and scarlet ones.");
			}
			else if (speech.Contains("scarlet"))
			{
				Say("Scarlet, like the banners at our festivals, or a letter sealed with wax and fate.");
			}
			else if (speech.Contains("festival"))
			{
				Say("The Festival of Saint Devote is my favorite—candles on the sea, and wishes whispered to the night.");
			}
			else if (speech.Contains("candle") || speech.Contains("candles"))
			{
				Say("Candles guide lost souls home. Even the greatest spy sometimes needs a little light.");
			}
			else if (speech.Contains("home"))
			{
				Say("Monaco is my home, wherever I may travel. And what of you—where does your heart belong?");
			}			
            else if (speech.Contains("fate"))
            {
                Say("Fate deals its cards as it pleases. Sometimes, all you can do is play your hand well.");
            }
            else if (speech.Contains("hand") || speech.Contains("cards"))
            {
                Say("A skilled gambler never reveals her hand—unless she wishes to send a message.");
            }
            else if (speech.Contains("message") || speech.Contains("letter"))
            {
                Say("Letters have saved this city more times than swords. Find the right message, and you may find reward.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("whisper"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Monaco’s whispers do not repeat themselves so soon. Return later, darling.");
                }
                else
                {
                    Say("You have uncovered the secret whisper of Monaco. Accept this Treasure Chest of Monaco—may fortune smile upon your curiosity.");
                    from.AddToBackpack(new TreasureChestOfMonaco());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Au revoir, and remember: the night belongs to those who listen.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of casino, secrets, roses, or the Grand Ball if you seek stories.");
                }
            }

            base.OnSpeech(e);
        }

        public ContessaElise(Serial serial) : base(serial) { }

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
