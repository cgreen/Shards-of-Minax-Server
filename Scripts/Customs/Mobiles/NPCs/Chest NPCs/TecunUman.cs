using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the spirit of Tecún Umán")]
    public class TecunUman : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TecunUman() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tecún Umán";
            Body = 0x190; // Human male body

            // Stats
            Str = 95;
            Dex = 80;
            Int = 95;
            Hits = 90;

            // Unique Appearance: Maya Royal Warrior
            AddItem(new ElvenShirt() { Name = "Jade-Woven Tunic", Hue = 1165 });
            AddItem(new GuildedKilt() { Name = "Kilt of the Kʼicheʼ", Hue = 2052 });
            AddItem(new Cloak() { Name = "Cloak of the Quetzal Feathers", Hue = 1367 });
            AddItem(new FeatheredHat() { Name = "Royal Plumed Headdress", Hue = 1372 });
            AddItem(new FurBoots() { Name = "Boots of the Sierra Madre", Hue = 2213 });
            AddItem(new BodySash() { Name = "Sash of Ancestral Valor", Hue = 2065 });

            // Weapon: Lance
            AddItem(new Lance() { Name = "Obsidian Lance of the Highlands", Hue = 1176 });

            // Speech Hue
            SpeechHue = 1171;

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
                Say("I am Tecún Umán, last prince of the Kʼicheʼ Maya, spirit of the highlands.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was a warrior and guardian, chosen to defend my people and the sacred earth of Guatemala.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body fell in battle, but my spirit endures wherever mountains touch the sky.");
            }
            else if (speech.Contains("maya"))
            {
                Say("The Maya are children of the maize and the sun, our stories etched in jade and stone.");
            }
            else if (speech.Contains("kʼiche") || speech.Contains("quiche"))
            {
                Say("The Kʼicheʼ were once rulers of the highlands, proud and unbroken until the shadow of conquest.");
            }
            else if (speech.Contains("highlands"))
            {
                Say("The highlands cradle our villages and memories. Mist and legend are woven through every valley.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends are the seeds from which new hope grows. Ask of the quetzal, or of the battles past.");
            }
            else if (speech.Contains("quetzal"))
            {
                Say("The quetzal is the soul of freedom. Its feathers once crowned the kings of our land.");
            }
            else if (speech.Contains("feather") || speech.Contains("feathers"))
            {
                Say("Each quetzal feather is a prayer, a hope for liberty soaring above the world.");
            }
            else if (speech.Contains("guatemala"))
            {
                Say("Guatemala is a tapestry of volcanoes, rivers, and dreams. Its heart beats with ancient drums.");
            }
            else if (speech.Contains("drums"))
            {
                Say("The drums of the Maya echo through the ages, calling us to remember who we are.");
            }
            else if (speech.Contains("jade"))
            {
                Say("Jade is the stone of kings and ancestors, its green depths holding stories of eternity.");
            }
            else if (speech.Contains("obsidian"))
            {
                Say("Obsidian is the midnight glass, sharp as memory, forged in the fire of the earth.");
            }
            else if (speech.Contains("spanish"))
            {
                Say("The Spanish came with steel and fire. Many fell, but our spirit was not conquered.");
            }
            else if (speech.Contains("conquest") || speech.Contains("conquer"))
            {
                Say("Conquest is a wound that scars the land, but even wounds can heal with time and remembrance.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains are our guardians, their peaks watching over every dawn.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Rivers carve paths through the jungle, bearing secrets from ages past.");
            }
            else if (speech.Contains("jungle"))
            {
                Say("The jungle is alive, whispering secrets to those who listen with patience.");
            }
            else if (speech.Contains("battle"))
            {
                Say("Battle found me at El Pinar. There, destiny and steel crossed beneath the gaze of the volcano.");
            }
            else if (speech.Contains("el pinar"))
            {
                Say("At El Pinar, I faced Pedro de Alvarado. Our clash echoes still in the cries of the quetzal.");
            }
            else if (speech.Contains("alvarado") || speech.Contains("pedro"))
            {
                Say("Pedro de Alvarado brought conquest, but could not steal the spirit of the land.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of the Maya walk beside us, their wisdom in the wind and rain.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a quetzal’s flight—glorious, yet fragile. Guard it well.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors watch from the stars, guiding each new generation.");
            }
            else if (speech.Contains("maize") || speech.Contains("corn"))
            {
                Say("Maize is life—our flesh, our breath, our future. Respect the gifts of the earth.");
            }
            else if (speech.Contains("earth") || speech.Contains("land"))
            {
                Say("We belong to the earth, and she belongs to none but herself.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who remember and honor the old songs.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Songs are bridges between worlds—between sorrow and hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the light that endures through darkness. It is never truly lost.");
            }
			else if (speech.Contains("ceiba"))
			{
				Say("The ceiba tree stands at the center of our world, its roots reaching both the underworld and the sky. It is sacred to my people.");
			}
			else if (speech.Contains("eagle") || speech.Contains("jaguar"))
			{
				Say("The eagle and the jaguar are mighty spirits—one rules the skies, the other stalks the jungle. Both are guardians of our people.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("The ancient priests read the stars and the sacred calendar, seeking signs of what is to come. Prophecy is a mirror held up to our hopes and fears.");
			}
			else if (speech.Contains("calendar"))
			{
				Say("Our calendar is the voice of time itself, marking the cycles of maize and moon. Each day is a story, woven into the fabric of the universe.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("At night, the stars remember every story and every ancestor. The Maya charted their paths and found meaning in their dance.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun is both giver and taker—life, warmth, and sometimes drought. Our priests honored its journey across the sky.");
			}
			else if (speech.Contains("volcano") || speech.Contains("volcanoes"))
			{
				Say("Volcanoes shape the land and remind us of the earth’s power. Some say they are the homes of ancient gods.");
			}
			else if (speech.Contains("god") || speech.Contains("gods"))
			{
				Say("The gods are many—of sun, maize, rain, and death. Each demands respect, and each gives their own gifts.");
			}
			else if (speech.Contains("rain"))
			{
				Say("Rain is the blessing of Chaac, the storm god. Without it, the maize withers and the rivers sleep.");
			}
			else if (speech.Contains("jade mask") || speech.Contains("mask"))
			{
				Say("Jade masks were worn by the greatest lords in life and death. To wear one is to walk between the worlds.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("The harvest is our joy and our survival. Each ear of maize is a promise kept by the earth.");
			}
			else if (speech.Contains("sacred"))
			{
				Say("Many things are sacred—the ceiba, the quetzal, the fire, and the words of the elders. Treat them all with care.");
			}
			else if (speech.Contains("elders"))
			{
				Say("Our elders carry the memory of the people. Their words are roots anchoring us to the land.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children are the new dawn. In their laughter and questions, the spirit of our people endures.");
			}
			else if (speech.Contains("pain"))
			{
				Say("Pain teaches as much as joy. The scars of conquest are deep, but from pain, new strength is born.");
			}
			else if (speech.Contains("forgive") || speech.Contains("forgiveness"))
			{
				Say("Forgiveness is a difficult path. To forgive is not to forget, but to walk forward with wisdom.");
			}
			else if (speech.Contains("warrior"))
			{
				Say("A true warrior defends not only with blade, but with heart and honor. The strongest weapon is the will to protect.");
			}
			else if (speech.Contains("prince"))
			{
				Say("I was called prince, but in truth I was a servant to my people. Leadership is a burden, carried for the good of all.");
			}
			else if (speech.Contains("friend"))
			{
				Say("Friendship weaves invisible bonds. A friend’s hand can lift even the heaviest spirit.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("The enemy teaches us vigilance. But even an enemy, once understood, can become a teacher.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is a rare and precious gift, more difficult to win than any battle. We must cherish and protect it.");
			}			
            else if (speech.Contains("sacrifice"))
            {
                Say("Sacrifice binds us to the land. My death was not an end, but a beginning for new dreams.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams are the maps of the soul. Even the stars once dreamed of being born.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("quetzal"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The quetzal does not return to the same branch twice in a day, friend.");
                }
                else
                {
                    Say("You have honored the quetzal’s spirit. Accept this Treasure Chest of Guatemala—may it keep the fire of hope alive within you.");
                    from.AddToBackpack(new TreasureChestOfGuatemala());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk gently, and let the quetzal guide your path beneath the ceiba tree.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of quetzal, El Pinar, jade, or obsidian—my story awaits those who seek.");
                }
            }

            base.OnSpeech(e);
        }

        public TecunUman(Serial serial) : base(serial) { }

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
