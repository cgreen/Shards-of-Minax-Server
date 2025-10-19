using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Jean de Valette")]
    public class JeanDeValette : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public JeanDeValette() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Jean Parisot de Valette";
            Body = 0x190; // Human male body

            // Unique Appearance
            AddItem(new FormalShirt() { Name = "Order's Crimson Tunic", Hue = 1157 });
            AddItem(new GuildedKilt() { Name = "Knight's Sash of Valletta", Hue = 2504 });
            AddItem(new Cloak() { Name = "Mantle of the Eight-Pointed Cross", Hue = 1150 });
            AddItem(new PlateGloves() { Name = "Gauntlets of Vigilance", Hue = 1175 });
            AddItem(new Boots() { Name = "Boots of Fort St. Elmo", Hue = 2410 });
            AddItem(new Circlet() { Name = "Laurel of Victory", Hue = 2002 });
            AddItem(new Broadsword() { Name = "Sword of the Grandmaster", Hue = 2105 });
            AddItem(new Bascinet() { Name = "Helm of the Hospitaller", Hue = 2418 });
            AddItem(new BodySash() { Name = "Sash of the Sovereign Order", Hue = 1173 });

            SpeechHue = 1154;
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
                Say("I am Jean Parisot de Valette, Grandmaster of the Knights Hospitaller.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to defend Malta and the Order, and to safeguard our sacred heritage.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though time weighs upon my shoulders, my resolve has never faltered.");
            }
            else if (speech.Contains("malta"))
            {
                Say("Malta is a fortress island, cradled by the sea and tempered by centuries of strife.");
            }
            else if (speech.Contains("knight"))
            {
                Say("We are the Knights of the Order of St. John, sworn to protect and to serve.");
            }
            else if (speech.Contains("order"))
            {
                Say("The Order stands for faith, valor, and brotherhood—its symbol is the eight-pointed cross.");
            }
            else if (speech.Contains("siege"))
            {
                Say("In 1565, Malta endured the Great Siege. Our walls stood strong against the Ottoman tide.");
            }
            else if (speech.Contains("ottoman"))
            {
                Say("The Ottoman armada was vast, but their ambitions foundered on our courage and these stones.");
            }
            else if (speech.Contains("cross"))
            {
                Say("The eight-pointed cross is a sign of our vows—each point, a virtue to uphold.");
            }
            else if (speech.Contains("harbor"))
            {
                Say("The Grand Harbor has witnessed both invasion and deliverance. Its waters run deep with history.");
            }
            else if (speech.Contains("fortress"))
            {
                Say("Fortresses like St. Elmo and St. Angelo are the shields of Malta—each stone a tale of sacrifice.");
            }
            else if (speech.Contains("valletta"))
            {
                Say("Valletta, the city that bears my name, was built from the ashes of siege and hope.");
            }
            else if (speech.Contains("temple"))
            {
                Say("Malta's ancient temples stand as silent witnesses, older than memory, guardians of forgotten rites.");
            }
            else if (speech.Contains("secret"))
            {
                Say("Malta holds many secrets—some hidden in stone, others in the hearts of those who defend her.");
            }
            else if (speech.Contains("tunnel") || speech.Contains("tunnels"))
            {
                Say("Beneath our feet, a labyrinth of tunnels winds through the bedrock—used by defenders and spies alike.");
            }
            else if (speech.Contains("sea"))
            {
                Say("The sea is both shield and snare. It brings both friend and foe to our shores.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is not the absence of fear, but mastery of it—our greatest weapon in the darkest hour.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope endures, even when the horizon is dark. It is the light that guides all true defenders.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Let none forget the sacrifices of the past—memory binds us to those who came before.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Victory was hard-won, purchased with blood and fire. The story of Malta is written in valor.");
            }
            else if (speech.Contains("loss"))
            {
                Say("Loss is the shadow cast by duty. We mourn, but we do not falter.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future of Malta depends on those who remember her story and defend her peace.");
            }
            else if (speech.Contains("island"))
            {
                Say("This island is a crossroads of the world, coveted by many, home to the steadfast.");
            }
			else if (speech.Contains("hospital"))
			{
				Say("Our Order began as humble caretakers, tending to the sick and poor in the Holy Land before we took up arms in their defense.");
			}
			else if (speech.Contains("sacred"))
			{
				Say("There is much that is sacred on this island: the altars of our chapels, the stones of our fortresses, and the oaths sworn by every knight.");
			}
			else if (speech.Contains("feast") || speech.Contains("banquet"))
			{
				Say("Our feasts are occasions for both celebration and reflection. Even in victory, we remember the fallen with solemn toasts.");
			}
			else if (speech.Contains("code"))
			{
				Say("The knight’s code is strict: defend the weak, serve the faith, speak truth, and act with courage—even when none bear witness.");
			}
			else if (speech.Contains("oath") || speech.Contains("oaths"))
			{
				Say("Each knight swears to uphold the honor of the Order and the island. Betrayal of such an oath is exile worse than death.");
			}
			else if (speech.Contains("flag") || speech.Contains("banner"))
			{
				Say("Our banner—the eight-pointed cross on crimson—flies above every bastion and is the symbol of hope to our people.");
			}
			else if (speech.Contains("cannon") || speech.Contains("cannons"))
			{
				Say("During the siege, our cannons roared day and night, casting iron and fire at the invaders’ ships and towers.");
			}
			else if (speech.Contains("turret") || speech.Contains("turrets"))
			{
				Say("The watchful turrets of St. Angelo and St. Elmo remain ever vigilant, eyes open to both horizon and harbor.");
			}
			else if (speech.Contains("ships") || speech.Contains("galley") || speech.Contains("galleys"))
			{
				Say("Our galleys sailed swift and silent, striking at pirates and corsairs who threatened Christian shores.");
			}
			else if (speech.Contains("corsair") || speech.Contains("pirate"))
			{
				Say("Corsairs prowled the waters, hungry for plunder and slaves. We met them with sword and cannon alike.");
			}
			else if (speech.Contains("legend"))
			{
				Say("Some say Malta’s stones are inscribed with secret signs, visible only to the truly devoted.");
			}
			else if (speech.Contains("ritual"))
			{
				Say("Our rituals blend prayer, song, and solemn vows. In the candlelit chapels, every voice joins the ancient chorus.");
			}
			else if (speech.Contains("torch"))
			{
				Say("A single torch carried through the night can rally the weary and guide the lost back to safety.");
			}
			else if (speech.Contains("patience"))
			{
				Say("Patience is as much a virtue in siege as in peace. The sea itself taught Malta to wait, watch, and endure.");
			}
			else if (speech.Contains("stone") || speech.Contains("stones"))
			{
				Say("Every stone in Valletta and Birgu was laid by hand—each carries the sweat and memory of our Order.");
			}
			else if (speech.Contains("birgu"))
			{
				Say("Birgu, also known as Vittoriosa, stood as our stronghold before Valletta rose from the ashes.");
			}
			else if (speech.Contains("ash") || speech.Contains("ashes"))
			{
				Say("From the ashes of siege and sorrow, Malta has always found a way to rise anew, stronger than before.");
			}
			else if (speech.Contains("guardian") || speech.Contains("guardians"))
			{
				Say("Every knight is a guardian, not only of stone walls but of the spirit and hope of this land.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("A blessing from our chaplain before battle is as valued as steel—both shield the soul from darkness.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Look to the stars, for guidance and solace. Many a prayer has been whispered beneath Malta’s night sky.");
			}			
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors built in stone and faith. Their legacy endures in every rampart and altar.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith steels the heart and guides the sword. It is the foundation of the Order.");
            }
            else if (speech.Contains("falcon"))
            {
                Say("Long ago, a falcon was sent each year to the King of Spain as tribute for our sovereignty.");
            }
            // Secret reward keyword!
            else if (speech.Contains("labyrinth"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("All secrets must rest a while before being found again. Return when the stones have cooled.");
                }
                else
                {
                    Say("You have the heart of a true seeker. Accept this Treasure Chest of Malta—may it remind you that the greatest riches are hidden beneath the surface.");
                    from.AddToBackpack(new TreasureChestOfMalta());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with honor. Malta remembers those who serve her well.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the siege, the eight-pointed cross, ancient tunnels, or the secrets of Malta.");
                }
            }

            base.OnSpeech(e);
        }

        public JeanDeValette(Serial serial) : base(serial) { }

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
