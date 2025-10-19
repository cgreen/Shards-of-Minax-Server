using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Linda")]
    public class LindaOfEstonia : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public LindaOfEstonia() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Linda, Mother of Stones";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 65;
            Int = 120;
            Hits = 95;

            // Unique Mythic Estonian Outfit
            AddItem(new FlowerGarland() { Name = "Garland of Summer Blossoms", Hue = 1266 }); // Pale blue
            AddItem(new FancyDress() { Name = "Dress of the Singing Forest", Hue = 2118 }); // Forest green
            AddItem(new Cloak() { Name = "Cloak of Baltic Mists", Hue = 1150 }); // Misty grey
            AddItem(new FurSarong() { Name = "Bearskin of Northern Legends", Hue = 2106 }); // Bear-brown
            AddItem(new ElvenBoots() { Name = "Boots of the Primeval Swamp", Hue = 2101 }); // Deep green
            AddItem(new BodySash() { Name = "Sash of the River Emajõgi", Hue = 1267 }); // River blue

            // Weapon: Staff as a symbol of wisdom
            AddItem(new WildStaff() { Name = "Staff of Singing Stones", Hue = 2109 });

            // Speech Hue
            SpeechHue = 2123;

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
                Say("I am Linda, mother of Kalevipoeg and the land’s quiet guardian.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I wept stones across these lands—each teardrop became a hill or island. I carry the memory of old Estonia.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit is strong, though I have grieved for my son and my people for many lifetimes.");
            }
            else if (speech.Contains("kalevipoeg") || speech.Contains("son"))
            {
                Say("Kalevipoeg was my child, born of hope and sorrow. His strength carved rivers and roads through Estonia.");
            }
            else if (speech.Contains("stone") || speech.Contains("stones"))
            {
                Say("These stones hold stories. Some say the great boulders of the north fell from my apron as I walked the land in mourning.");
            }
            else if (speech.Contains("mourning") || speech.Contains("grief"))
            {
                Say("My sorrow gave shape to this country. Each teardrop became a sacred place for those who remember.");
            }
            else if (speech.Contains("estonia"))
            {
                Say("Estonia is a land of forests, lakes, and unbroken spirit—where freedom is sung from generation to generation.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is precious here. Even when darkness falls, our hearts kindle songs of light.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our people sing through suffering and celebration. Listen for the old tunes in the whisper of pines.");
            }
            else if (speech.Contains("forest") || speech.Contains("forests"))
            {
                Say("The forests of Estonia are ancient and wise. Spirits linger beneath the oaks, and every root holds a secret.");
            }
            else if (speech.Contains("lake") || speech.Contains("lakes"))
            {
                Say("Vast lakes, like Peipus and Võrtsjärv, reflect the sky and the tears of generations past.");
            }
            else if (speech.Contains("baltic") || speech.Contains("sea"))
            {
                Say("The Baltic Sea cradles our coast. It has carried both hope and hardship to these shores.");
            }
            else if (speech.Contains("island") || speech.Contains("islands"))
            {
                Say("Islands, like Saaremaa and Hiiumaa, are ancient strongholds. Legends sleep among the stones and wind there.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Estonia’s legends are old as the moss on the stones. Would you hear of the Singing Revolution or the Stone Mother’s sorrow?");
            }
            else if (speech.Contains("revolution") || speech.Contains("singing revolution"))
            {
                Say("The Singing Revolution freed my children from chains. When all else was lost, they sang the nation back to life.");
            }
            else if (speech.Contains("chain") || speech.Contains("chains"))
            {
                Say("Chains may bind the body, but they cannot silence the soul’s melody.");
            }
            else if (speech.Contains("folk") || speech.Contains("folklore"))
            {
                Say("Our folklore is rich with spirits, wolves, witches, and heroes. My favorite tales are whispered by the campfire’s light.");
            }
            else if (speech.Contains("witch") || speech.Contains("witches"))
            {
                Say("Witches, both feared and wise, live in the wild. Some bring healing, others curse—respect the old ways, and you may pass unharmed.");
            }
            else if (speech.Contains("wolf") || speech.Contains("wolves"))
            {
                Say("Wolves are our silent brothers, moving through snow and forest. To see one is a sign to tread carefully.");
            }
            else if (speech.Contains("song") || speech.Contains("sing"))
            {
                Say("Sing with your whole heart; in Estonia, song can move mountains and free a nation.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains") || speech.Contains("hill") || speech.Contains("hills"))
            {
                Say("Our hills were shaped by sorrow. Each rises where a stone or teardrop fell from my hands.");
            }
            else if (speech.Contains("apron"))
            {
                Say("It’s said the boulders and islets of Lake Ülemiste spilled from my apron as I searched for peace.");
            }
            else if (speech.Contains("lake ülemiste") || speech.Contains("ülemiste"))
            {
                Say("Lake Ülemiste hides many secrets. Drink too deeply, and you may dream the city of Tallinn into the waters.");
            }
            else if (speech.Contains("tallinn"))
            {
                Say("Tallinn’s towers watch the sea, built on stones both old and new—some, perhaps, from my tears.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of the forest and sea are never far. Offer them respect, and you’ll walk in peace.");
            }
			else if (speech.Contains("bog") || speech.Contains("bogs") || speech.Contains("swamp") || speech.Contains("swamps"))
			{
				Say("Our bogs are ancient—filled with the bones of ancestors and secrets kept by the mists. Step lightly, and you may glimpse the will-o’-wisps dancing.");
			}
			else if (speech.Contains("will-o'-wisp") || speech.Contains("will-o-wisp") || speech.Contains("wisp") || speech.Contains("wisps"))
			{
				Say("The will-o’-wisps flicker at twilight, leading the unwary deeper into the bog. Some say they are the laughter of spirits who remember old wrongs.");
			}
			else if (speech.Contains("wind"))
			{
				Say("Estonian wind carries voices from across the ages—heroes’ oaths, children’s laughter, and mothers’ sighs.");
			}
			else if (speech.Contains("oak") || speech.Contains("oaks"))
			{
				Say("Oaks are sacred trees, home to thunder and wisdom. The oldest stand watch over our people, silent and strong.");
			}
			else if (speech.Contains("bear"))
			{
				Say("Bears are respected as kings of the forest. If you meet one, bow your head and whisper a greeting for luck.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire is both danger and comfort. On midsummer nights, we leap over flames to burn away sorrow and invite good fortune.");
			}
			else if (speech.Contains("midsummer") || speech.Contains("johannese") || speech.Contains("jaanipaev") || speech.Contains("jaanipäev"))
			{
				Say("Jaanipäev, midsummer’s eve, is when magic runs wild. Songs and bonfires light up the longest night.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("The ancestors walk unseen beside us. Remember them at every meal, and your path will never be lonely.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Stars guide both sailor and shepherd. On clear nights, I count my hopes among them.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is the last ember after the fire dies. Guard it, for it will rekindle when you least expect.");
			}
			else if (speech.Contains("pain"))
			{
				Say("Pain shapes us, like the rivers shape the land. Each scar, seen or unseen, has a story to tell.");
			}
			else if (speech.Contains("gift") || speech.Contains("gifts"))
			{
				Say("Every true gift carries a part of the giver’s soul. Take what is offered in kindness, and give in return.");
			}
			else if (speech.Contains("memory") || speech.Contains("memories"))
			{
				Say("Memories are stones in the river. The water flows on, but the stones remain, shaping the current.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("Rivers wind through Estonia like silver threads. Their music soothes the weary and teaches patience.");
			}
			else if (speech.Contains("mist"))
			{
				Say("Mist shrouds secrets and softens sorrow. Trust your heart, even when the path is hidden.");
			}
			else if (speech.Contains("promise") || speech.Contains("promises"))
			{
				Say("A promise is sacred, stronger than chains or stone. I keep my promises, no matter how many winters pass.");
			}
			else if (speech.Contains("time"))
			{
				Say("Time moves as quietly as snowfall. Cherish each moment, for even legends grow old.");
			}
			else if (speech.Contains("farewell") || speech.Contains("parting"))
			{
				Say("Farewell is never forever, only until the next dawn. The land remembers every footstep.");
			}			
            else if (speech.Contains("mother"))
            {
                Say("To be a mother is to bear both love and grief. I mothered a hero and a nation.");
            }
            else if (speech.Contains("teardrop") || speech.Contains("teardrops"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The stones wait patiently for true sorrow and curiosity. Return to me after the mists have lifted.");
                }
                else
                {
                    Say("You have found the path through sorrow. Take this Treasure Chest of Estonian Legends, and may its contents sing to your spirit.");
                    from.AddToBackpack(new TreasureChestOfEstonianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the wild woods and silent stones keep you safe, always.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Kalevipoeg, the Singing Revolution, or the stones that fell from a mother's apron.");
                }
            }

            base.OnSpeech(e);
        }

        public LindaOfEstonia(Serial serial) : base(serial) { }

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
