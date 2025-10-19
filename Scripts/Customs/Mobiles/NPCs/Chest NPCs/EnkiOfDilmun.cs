using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the presence of Enki")]
    public class EnkiOfDilmun : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public EnkiOfDilmun() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Enki, Keeper of Dilmun's Waters";
            Body = 0x190; // Human male
            Hue = 1153;   // Subtle blue skin tint for the god of water

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Azure Tunic of the Sweet Waters", Hue = 1268 }); // shimmering blue
            AddItem(new FancyKilt() { Name = "Siltweave Kilt of Ancient Rivers", Hue = 1360 }); // deep river green
            AddItem(new Cloak() { Name = "Cloak of Mists", Hue = 1150 }); // pale mist
            AddItem(new FlowerGarland() { Name = "Palm Blossom Garland", Hue = 1357 }); // Dilmun’s sacred palm
            AddItem(new FurBoots() { Name = "Boots of the Crystal Springs", Hue = 1170 }); // watery turquoise
            AddItem(new BodySash() { Name = "Sash of the Underworld Channel", Hue = 1173 }); // dark blue
            AddItem(new MagicWand() { Name = "Reed Wand of Abzu", Hue = 1260 }); // sacred reed

            SpeechHue = 2076;
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
                Say("I am Enki, the Keeper of Waters and Guardian of Dilmun’s purity.");
            }
            else if (speech.Contains("job"))
            {
                Say("I tend the sacred springs of Dilmun, where sorrow is unknown and rivers bring life eternal.");
            }
            else if (speech.Contains("health"))
            {
                Say("Here in Dilmun, pain is forgotten, and even the wind brings only joy.");
            }
            else if (speech.Contains("dilmun"))
            {
                Say("Dilmun is the ancient paradise—a land between rivers, blessed by the gods and kissed by the sea.");
            }
            else if (speech.Contains("waters") || speech.Contains("water"))
            {
                Say("The sweet waters of Dilmun flow from the deep Abzu, gifting life and purity to all who dwell here.");
            }
            else if (speech.Contains("abzu"))
            {
                Say("Abzu is the subterranean sea—source of wisdom, hidden beneath earth and temple alike.");
            }
            else if (speech.Contains("paradise"))
            {
                Say("Many have sought Dilmun, the paradise without sickness, age, or weeping. Only the pure may glimpse its shores.");
            }
            else if (speech.Contains("pure") || speech.Contains("purity"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Only once in a cycle may a soul be blessed with Dilmun’s secret—return when the sun is higher.");
                }
                else
                {
                    Say("You are wise to seek the path of purity. Accept this Treasure Chest of Dilmun, and may its mysteries reveal forgotten joy.");
                    from.AddToBackpack(new TreasureChestOfDilmun());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("sorrow") || speech.Contains("pain"))
            {
                Say("In Dilmun, there is no sorrow, no pain, no old age. Only the laughter of the living waters.");
            }
            else if (speech.Contains("trade"))
            {
                Say("Caravans cross the shining sands, bringing pearls and copper to the temples of the gods.");
            }
            else if (speech.Contains("gods") || speech.Contains("god"))
            {
                Say("The gods walk unseen in Dilmun: Inanna, Shamash, and others share this land of beginnings.");
            }
            else if (speech.Contains("palm") || speech.Contains("palms"))
            {
                Say("The palm is sacred here—its fruit sweetens the tongue and nourishes the spirit.");
            }
            else if (speech.Contains("island") || speech.Contains("sea"))
            {
                Say("The shining sea encircles Dilmun, reflecting the stars and carrying ships from every known world.");
            }
            else if (speech.Contains("eternal") || speech.Contains("immortal"))
            {
                Say("Some say those who rest in Dilmun live forever, so long as water and memory endure.");
            }
            else if (speech.Contains("reed"))
            {
                Say("Reeds line the pure canals, whispering the secrets of creation and healing.");
            }
            else if (speech.Contains("healing"))
            {
                Say("All who come to Dilmun are restored. The waters heal, and the spirit finds peace.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("True secrets are veiled by water and time. Seek purity, and you may discover what others miss.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Each traveler brings a new story. Tell me: what do you seek in these ancient lands?");
            }
            else if (speech.Contains("bahrain"))
            {
                Say("The island of Bahrain rises from the heart of Dilmun—old as legend, rich in memory and pearl.");
            }
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom flows as water does—quietly, persistently, shaping even the hardest stone. Those who listen may learn much by the riverbank.");
			}
			else if (speech.Contains("inanna"))
			{
				Say("Inanna, Lady of Heaven, has walked the palm groves of Dilmun. Her laughter blessed the date harvest, and her tears brought rain.");
			}
			else if (speech.Contains("sun") || speech.Contains("shamash"))
			{
				Say("Shamash, the shining sun, rises over Dilmun each morning. His light purifies, and his gaze sees all secrets.");
			}
			else if (speech.Contains("pearls"))
			{
				Say("The pearls of Dilmun gleam with the memory of the moon. Divers risk much to bring these treasures to the surface.");
			}
			else if (speech.Contains("sand") || speech.Contains("desert"))
			{
				Say("Beyond Dilmun’s springs, golden sands stretch to the horizon. Only those with water and hope cross the desert safely.");
			}
			else if (speech.Contains("birth") || speech.Contains("life"))
			{
				Say("Dilmun is the place where life first awoke, and where mothers find comfort in the cool shade of palm and spring.");
			}
			else if (speech.Contains("death"))
			{
				Say("In Dilmun, death is but a rumor—here, the old grow young and the weary are refreshed.");
			}
			else if (speech.Contains("temple"))
			{
				Say("Temples rise above the sweet waters. Their stones remember every prayer whispered by moonlight.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("Oracles once drank from sacred springs, glimpsing futures in ripples and reflections. Water remembers what mortals forget.");
			}
			else if (speech.Contains("memory"))
			{
				Say("The memory of Dilmun endures wherever there is longing for a world without sorrow. What memories do you bring, traveler?");
			}
			else if (speech.Contains("trade"))
			{
				Say("Long ago, merchant ships carried copper, incense, and lapis from Dilmun to distant lands. Even now, the old trade winds remember their routes.");
			}
			else if (speech.Contains("lapis"))
			{
				Say("Lapis lazuli, blue as deep water, is a gem fit for gods and queens. It was treasured here, shaped into seals and gifts.");
			}
			else if (speech.Contains("legend") || speech.Contains("myth"))
			{
				Say("Legends are seeds—planted in the past, growing in the hearts of all who listen. Dilmun’s myths are woven into the world itself.");
			}
			else if (speech.Contains("copper"))
			{
				Say("Copper from Dilmun built temples in far-off lands. Its red shine is the color of dawn upon the sea.");
			}
			else if (speech.Contains("stars"))
			{
				Say("On clear nights, the stars over Dilmun shine so bright, sailors say they can find their way home by their reflection in the water.");
			}			
            else if (speech.Contains("farewell") || speech.Contains("goodbye"))
            {
                Say("May sweet waters guide you on your journey, friend of Dilmun.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Abzu, palm, paradise, or the healing waters of Dilmun.");
                }
            }

            base.OnSpeech(e);
        }

        public EnkiOfDilmun(Serial serial) : base(serial) { }

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
