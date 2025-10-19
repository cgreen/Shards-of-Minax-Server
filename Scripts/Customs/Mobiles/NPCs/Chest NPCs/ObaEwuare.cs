using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Oba Ewuare")]
    public class ObaEwuare : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ObaEwuare() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Oba Ewuare";
            Title = "the Great, King of Benin";
            Body = 0x190;

            // Outfit - regal and unique
            AddItem(new FancyShirt() { Name = "Coral Beaded Robe of the Oba", Hue = 2117 });
            AddItem(new GuildedKilt() { Name = "Royal Wrappings of the Leopard Throne", Hue = 1359 });
            AddItem(new BodySash() { Name = "Ivory Sash of Ancestor Spirits", Hue = 1150 });
            AddItem(new Cloak() { Name = "Ewuare's Ceremonial Mantle", Hue = 2973 });
            AddItem(new FeatheredHat() { Name = "Coral Crown of Benin", Hue = 1919 });
            AddItem(new Sandals() { Name = "Traveler’s Sandals of Edo", Hue = 2534 });
            AddItem(new Scepter() { Name = "Bronze Scepter of Oba’s Might", Hue = 2447 });

            SpeechHue = 2122;

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
                Say("I am Oba Ewuare the Great, crowned ruler of Benin’s golden age.");
            }
            else if (speech.Contains("job"))
            {
                Say("I guide my people, keep the spirits of our ancestors close, and judge fairly from my Leopard Throne.");
            }
            else if (speech.Contains("health"))
            {
                Say("I am strong, as the mighty walls of Benin, though time tempers even a king’s stride.");
            }
            else if (speech.Contains("benin"))
            {
                Say("Benin is a kingdom of artists, warriors, and traders. Our bronzes shine across the world.");
            }
            else if (speech.Contains("kingdom"))
            {
                Say("A kingdom stands on its stories and the unity of its people. Ours is as old as the forest.");
            }
            else if (speech.Contains("leopard"))
            {
                Say("The leopard is the symbol of my power—swift, wise, and feared.");
            }
            else if (speech.Contains("bronze"))
            {
                Say("Benin’s bronze casters create wonders. Statues and plaques tell the stories of kings and battles.");
            }
            else if (speech.Contains("ancestor"))
            {
                Say("We honor our ancestors. Their wisdom guides us in dreams and ritual.");
            }
            else if (speech.Contains("art"))
            {
                Say("Artists in Benin are beloved. Their hands shape history in bronze, ivory, and wood.");
            }
            else if (speech.Contains("wall") || speech.Contains("walls"))
            {
                Say("The city walls of Benin are marvels—protecting all who dwell within.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The sacred forest is home to spirits and secrets. Only the brave or foolish enter at night.");
            }
            else if (speech.Contains("trade"))
            {
                Say("From Benin, goods and wisdom travel far: pepper, ivory, and stories cross the wide Niger.");
            }
            else if (speech.Contains("pepper"))
            {
                Say("Our red pepper is famed and fiery, seasoning both food and fortune.");
            }
            else if (speech.Contains("ivory"))
            {
                Say("Ivory is sacred; carved for the Oba, it holds the memory of kings.");
            }
			else if (speech.Contains("magic"))
			{
				Say("Magic weaves through Benin, hidden in words, carved in ivory, and sung in secret rites.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Our griots tell stories by firelight—heroes, monsters, and Obas who shaped our world.");
			}
			else if (speech.Contains("griot") || speech.Contains("bard"))
			{
				Say("Griots are keepers of memory. Their tales keep the spirits of our ancestors close.");
			}
			else if (speech.Contains("river"))
			{
				Say("The Niger River brings life to our lands. On its waters, merchants and stories travel far.");
			}
			else if (speech.Contains("queen") || speech.Contains("iyoba"))
			{
				Say("The Iyoba, mother of the Oba, holds power and wisdom. Her advice is sharper than a leopard’s claw.");
			}
			else if (speech.Contains("market"))
			{
				Say("Benin’s markets overflow with bronze, coral, pepper, and laughter. Here, fortunes change hands.");
			}
			else if (speech.Contains("coral"))
			{
				Say("Coral beads are gifts of the sea. Only the Oba and nobles may wear the brightest coral.");
			}
			else if (speech.Contains("war") || speech.Contains("battle"))
			{
				Say("In times of war, my warriors march beneath banners of the leopard. Our blades are swift, our hearts steady.");
			}
			else if (speech.Contains("warrior") || speech.Contains("warriors"))
			{
				Say("Benin’s warriors are famed across the world. They defend our walls and honor the ancestors.");
			}
			else if (speech.Contains("bronzes") || speech.Contains("plaque"))
			{
				Say("The Benin Bronzes and plaques record history for all to see. They are the pride of our craftsmen.");
			}
			else if (speech.Contains("craft") || speech.Contains("craftsmen") || speech.Contains("carver"))
			{
				Say("Our craftsmen carve stories in wood and cast legends in bronze. Each piece carries a blessing.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals light up Benin! Drums thunder, dancers whirl, and the ancestors smile upon our joy.");
			}
			else if (speech.Contains("drum") || speech.Contains("music"))
			{
				Say("The drum speaks when words cannot. Music calls the spirits and stirs the soul.");
			}
			else if (speech.Contains("mask") || speech.Contains("masks"))
			{
				Say("Masks of ivory and bronze protect the wearer and frighten away unfriendly spirits.");
			}
			else if (speech.Contains("forest"))
			{
				Say("Within the sacred forest, spirits whisper to those who listen. Respect their silence.");
			}
			else if (speech.Contains("throne"))
			{
				Say("The Leopard Throne is my seat of power and judgement. It is a symbol of both strength and mercy.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the heart of a kingdom. I listen to all who seek it, from farmer to noble.");
			}
			else if (speech.Contains("noble") || speech.Contains("nobles"))
			{
				Say("Nobles serve the Oba and the people. Their loyalty is the foundation of our peace.");
			}
			else if (speech.Contains("blessing") || speech.Contains("bless"))
			{
				Say("May the ancestors bless your journey, and may fortune walk beside you.");
			}
			else if (speech.Contains("curse") || speech.Contains("cursed"))
			{
				Say("Curses are rare, but never to be taken lightly. Only the wise may break what the spirits have bound.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is the light that guides a ruler through the darkness. It is learned, not given.");
			}			
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits walk among us—some to help, some to test the heart of a ruler.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Royal treasures must rest—return in a little while, and fortune may favor you.");
                }
                else
                {
                    Say("Take this Treasure Chest of Benin Kingdom. May you walk in wisdom and plenty!");
                    from.AddToBackpack(new TreasureChestOfBeninKingdom());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the spirits of Benin guide your steps, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of bronzes, leopards, ancestors, or the city walls if you seek knowledge!");
                }
            }

            base.OnSpeech(e);
        }

        public ObaEwuare(Serial serial) : base(serial) { }

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
