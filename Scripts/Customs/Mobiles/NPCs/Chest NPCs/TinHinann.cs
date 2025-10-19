using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the bones of Tin Hinan")]
    public class TinHinann : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TinHinann() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tin Hinan";
            Body = 0x191; // Human female body

            // Outfit
            AddItem(new ElvenShirt() { Name = "Sandwoven Robe of the Ahaggar", Hue = 2949 });
            AddItem(new FancyKilt() { Name = "Dune-Kissed Indigo Wrappings", Hue = 2075 });
            AddItem(new Cloak() { Name = "Veil of Saharan Twilight", Hue = 2000 });
            AddItem(new FlowerGarland() { Name = "Crown of Desert Blooms", Hue = 1165 });
            AddItem(new ElvenBoots() { Name = "Traveller's Dustfoot Boots", Hue = 2201 });
            AddItem(new BodySash() { Name = "Sash of the Lost Caravan", Hue = 1275 });
            AddItem(new Leafblade() { Name = "Leafblade of Ténéré's Whisper", Hue = 2121 });

            SpeechHue = 1153;
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
                Say("I am Tin Hinan, Matriarch of the Blue People, mother to the desert’s wandering heart.");
            }
            else if (speech.Contains("job"))
            {
                Say("Long ago, I led my caravan across burning sands, forging kinship among the dunes and oases.");
            }
            else if (speech.Contains("health"))
            {
                Say("The desert’s breath keeps me ageless, though time’s wind whispers through my bones.");
            }
            else if (speech.Contains("tuareg"))
            {
                Say("The Tuareg are children of the wind and keepers of ancient routes. Our veils are dyed blue as the twilight.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert is a sea of memory. Each grain of sand holds the song of those who passed before.");
            }
            else if (speech.Contains("caravan"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Only patient wanderers deserve the desert’s secret twice. Return when the sun has turned again.");
                }
                else
                {
                    Say("You have traveled far in story and spirit. Accept this Treasure Chest of Mauritania—a memory of golden caravans and lost oases.");
                    from.AddToBackpack(new TreasureChestOfMauritania());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("queen"))
            {
                Say("Queen is but a word. In the desert, a leader is one who shares water and listens to the wind.");
            }
            else if (speech.Contains("hoggar"))
            {
                Say("The Hoggar mountains cradle my tomb, but my legend roams with the caravans through Mauritania and beyond.");
            }
            else if (speech.Contains("matriarch") || speech.Contains("mother"))
            {
                Say("A matriarch weaves together generations, like palm fibers in a nomad’s tent.");
            }
            else if (speech.Contains("blue"))
            {
                Say("Our indigo veils stain our skin, a mark of honor and mystery under the Saharan sun.");
            }
            else if (speech.Contains("sand"))
            {
                Say("Sand buries kingdoms and reveals secrets. Listen closely and you may hear ancient footsteps.");
            }
            else if (speech.Contains("oasis"))
            {
                Say("Oases are miracles born from patience and hope—drink deeply, for the desert is ever thirsty.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Legends drift like desert smoke, shaping truth and myth alike.");
            }
            else if (speech.Contains("salt"))
            {
                Say("Salt once bought empires, and caravans carried it across the dunes to distant shores.");
            }
			else if (speech.Contains("mirage"))
			{
				Say("Mirages tempt the thirsty with dreams of water and shade. Not all that glimmers is meant to be found.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade is the river that nourishes the desert. Gold, salt, and stories have all crossed these dunes.");
			}
			else if (speech.Contains("veil") || speech.Contains("face"))
			{
				Say("The veil shields us from sand and stranger alike. Beneath it, all carry their own secrets.");
			}
			else if (speech.Contains("stars"))
			{
				Say("The stars are the old guides of the desert. Even when the path vanishes, they remain.");
			}
			else if (speech.Contains("wind"))
			{
				Say("The desert wind erases footsteps but not memories. It is both a lullaby and a warning.");
			}
			else if (speech.Contains("date") || speech.Contains("palm"))
			{
				Say("The date palm is a gift of life, roots deep in the earth, reaching for the sky. Its fruit sweetens every journey.");
			}
			else if (speech.Contains("camel") || speech.Contains("dromedary"))
			{
				Say("Camels are the ships of the Sahara—loyal, patient, and wise. Trust your camel, and you will never be lost.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("An oracle once told me: 'The sand remembers all promises, and the desert keeps them until the end.'");
			}
			else if (speech.Contains("silence"))
			{
				Say("Silence in the desert is not emptiness—it is a language spoken by earth, sky, and spirit.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire is a comfort beneath cold desert stars. It brings song and shadow to every camp.");
			}
			else if (speech.Contains("tribe") || speech.Contains("people"))
			{
				Say("The tribe is a family greater than blood. In hardship and joy, all are woven into the same cloth.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every traveler brings a story. Will yours be one of courage, or caution?");
			}
			else if (speech.Contains("color") || speech.Contains("indigo"))
			{
				Say("Indigo is the color of dusk, of mystery, and of freedom. It marks the hands and hearts of my people.");
			}
			else if (speech.Contains("footsteps"))
			{
				Say("Footsteps vanish quickly in shifting sand, yet their memory lingers for those who listen.");
			}
			else if (speech.Contains("memory"))
			{
				Say("Memory is the oasis of the mind—return often, and draw from it the strength to journey onward.");
			}			
            else if (speech.Contains("journey") || speech.Contains("travel"))
            {
                Say("Every journey changes both traveler and land. What tracks will you leave behind?");
            }
            else if (speech.Contains("spirits"))
            {
                Say("The spirits of the desert move in the night wind. They watch over lost wanderers and secret keepers.");
            }
            else if (speech.Contains("poetry") || speech.Contains("song") || speech.Contains("music"))
            {
                Say("Poetry is the water of the soul. Our songs carry love, loss, and longing across the endless sands.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors guide us, unseen. Their wisdom rides in every caravan and whisper.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the stars guide your path, and your footsteps find gentle sand.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Tuareg, desert, oases, or the caravan’s forgotten riches.");
                }
            }

            base.OnSpeech(e);
        }

        public TinHinann(Serial serial) : base(serial) { }

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
