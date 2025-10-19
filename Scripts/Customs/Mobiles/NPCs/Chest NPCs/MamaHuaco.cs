using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Mama Huaco")]
    public class MamaHuaco : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public MamaHuaco() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mama Huaco";
            Body = 0x191; // Human female body

            // Unique Outfit: Mystical Andean Sage
            AddItem(new FloweredDress() { Name = "Dress of the Cloud Forest", Hue = 1379 });
            AddItem(new WoodlandBelt() { Name = "Belt of Ancestral Herbs", Hue = 2731 });
            AddItem(new Cloak() { Name = "Mist-Cloak of the Andes", Hue = 1153 });
            AddItem(new BearMask() { Name = "Mask of the Mother Bear", Hue = 1175 });
            AddItem(new FurBoots() { Name = "Boots of the Wild Path", Hue = 2107 });
            AddItem(new BodySash() { Name = "Sash of Rain and Memory", Hue = 2206 });

            // Weapon
            AddItem(new Leafblade() { Name = "Leafblade of Pumapungo", Hue = 1368 });

            // Speech Hue
            SpeechHue = 2212;

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
                Say("They call me Mama Huaco, first mother of warriors, guardian of rivers and lore.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to keep the stories of the Andes alive, and to teach wisdom to those who wander the mists.");
            }
            else if (speech.Contains("health"))
            {
                Say("The cloud forest heals all who respect her. My spirit is strong as the stone roots beneath us.");
            }
            else if (speech.Contains("inca"))
            {
                Say("The Inca called me mother and teacher. Many tribes across these lands remember my deeds.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Rivers sing the memory of the mountains. Here, the mighty Pastaza and Napo shape our world.");
            }
            else if (speech.Contains("mountain") || speech.Contains("andes"))
            {
                Say("The Andes are a spine of power. Their peaks watch over secret valleys and hidden cities.");
            }
            else if (speech.Contains("warrior"))
            {
                Say("I taught sons and daughters the ways of sling, spear, and spirit. A true warrior listens before fighting.");
            }
            else if (speech.Contains("sage") || speech.Contains("wisdom"))
            {
                Say("Wisdom grows like moss—quiet and slow, but enduring. Ask of the forest, the ancestors, or the old stones.");
            }
            else if (speech.Contains("cloud") || speech.Contains("mist"))
            {
                Say("Clouds conceal and reveal. The cloud forest protects its secrets with gentle hands.");
            }
            else if (speech.Contains("bear"))
            {
                Say("The bear is mother and protector in these lands. Her spirit teaches strength and patience.");
            }
            else if (speech.Contains("pumapungo"))
            {
                Say("Pumapungo is an ancient city, its stones shaped by sun priests and shadowed by puma spirits.");
            }
            else if (speech.Contains("forest"))
            {
                Say("The forest is alive—every root, every bird, every breeze carries a message. Listen, and you may learn.");
            }
            else if (speech.Contains("herb") || speech.Contains("herbs"))
            {
                Say("Herbs of the highlands heal both body and heart. Some say I can speak to plants themselves.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("Spirits walk beside us. Ancestors, animals, and rivers all have their own voice, if you know how to listen.");
            }
            else if (speech.Contains("ancestors") || speech.Contains("ancestor"))
            {
                Say("The ancestors whisper in dreams and shadows. Their stories make us who we are.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every stone and stream tells a story. In Ecuador, legends are as common as rain.");
            }
            else if (speech.Contains("rain"))
            {
                Say("Rain brings both life and mystery. In every droplet, an old memory is born anew.");
            }
            else if (speech.Contains("city"))
            {
                Say("Many cities rose and fell: Pumapungo, Tomebamba, and others hidden by jungle and time.");
            }
            else if (speech.Contains("jungle"))
            {
                Say("The jungle is a maze of green secrets. Only the respectful traveler finds safe passage.");
            }
            else if (speech.Contains("mother"))
            {
                Say("A mother’s strength is in her patience and her memory. My children are the brave and the wise.");
            }
            else if (speech.Contains("sling") || speech.Contains("weapon"))
            {
                Say("I was famed for my golden sling, and for teaching cunning more valuable than any blade.");
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold is the blood of the mountains. The greedy find only sorrow in their search.");
            }
            else if (speech.Contains("hidden"))
            {
                Say("Many wonders remain hidden—only those with true curiosity find what others miss.");
            }
            else if (speech.Contains("curiosity") || speech.Contains("curious"))
            {
                Say("Curiosity leads you forward, but wisdom tells you when to pause and listen.");
            }
			else if (speech.Contains("sun"))
			{
				Say("The sun is father to the Incas, its path shapes the harvests and guides our rituals.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon weaves dreams and tides, a gentle guide for those who walk the forest at night.");
			}
			else if (speech.Contains("volcano") || speech.Contains("volcanoes"))
			{
				Say("The great volcanoes, Chimborazo and Cotopaxi, are both fierce guardians and ancient storytellers of these lands.");
			}
			else if (speech.Contains("quetzal") || speech.Contains("bird"))
			{
				Say("The quetzal bird is a messenger of the gods, its feathers bright as sunrise. To see one is a rare blessing.");
			}
			else if (speech.Contains("festival"))
			{
				Say("During Inti Raymi, we dance and give thanks to the sun and the spirits for another year of life.");
			}
			else if (speech.Contains("shadow"))
			{
				Say("Every light casts a shadow. The wise learn to walk with both, for the shadow teaches caution and truth.");
			}
			else if (speech.Contains("wisps"))
			{
				Say("In the mist, glowing wisps sometimes appear. Some say they are the laughter of forest spirits.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Long before conquest, we traded salt, spondylus shells, and stories along the spine of the Andes.");
			}
			else if (speech.Contains("jaguar"))
			{
				Say("The jaguar is both hunter and guardian, stalking through legend and memory. Respect its power.");
			}
			else if (speech.Contains("shaman"))
			{
				Say("Shamans see beyond the veil of ordinary sight. They read omens in wind, smoke, and leaf.");
			}
			else if (speech.Contains("magic"))
			{
				Say("True magic is not in tricks, but in understanding—the wind, the river, the way a story moves a heart.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Songs bind the living to the ancestors. Each note is a step in the dance of memory.");
			}
			else if (speech.Contains("fruit"))
			{
				Say("The guayusa leaf wakes the mind, and the golden naranjilla brings sweetness after rain.");
			}
			else if (speech.Contains("bridge"))
			{
				Say("Woven bridges cross deep gorges—each fiber a promise of community and trust.");
			}
			else if (speech.Contains("serpent"))
			{
				Say("The serpent is both river and wisdom—silent, winding, and eternal. It connects worlds above and below.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are the seeds of tomorrow. Teach them with stories, courage, and kindness.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("On clear nights, the stars tell stories the old ones remember. Every soul has a star in the sky.");
			}
			else if (speech.Contains("market"))
			{
				Say("Markets bustle with color, sound, and the laughter of many tongues. Here, all paths cross.");
			}
			else if (speech.Contains("salt"))
			{
				Say("Salt is a treasure of life. The best journeys begin with a pinch of salt and a story shared.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is a mountain—easy to see, hard to climb. Be patient in seeking it.");
			}			
            else if (speech.Contains("memory") || speech.Contains("memories"))
            {
                Say("Memories shape the soul. Remember your ancestors, and you will never be lost.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends")) // *** SECRET REWARD KEYWORD ***
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True legends are patient—return when the sun is higher in the sky.");
                }
                else
                {
                    Say("You seek the legends of Ecuador. Accept this Treasure Chest of Ecuadorian Legends—may its contents guide your own path.");
                    from.AddToBackpack(new TreasureChestOfEcuadorianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell") || speech.Contains("adios"))
            {
                Say("May the cloud forest guard your steps, and legends light your nights.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.12)
                {
                    Say("Ask me of warriors, rivers, cloud forests, or the ancient city of Pumapungo.");
                }
            }

            base.OnSpeech(e);
        }

        public MamaHuaco(Serial serial) : base(serial) { }

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
