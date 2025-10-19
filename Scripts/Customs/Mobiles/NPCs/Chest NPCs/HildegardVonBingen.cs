using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Hildegard von Bingen")]
    public class HildegardVonBingen : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HildegardVonBingen() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hildegard von Bingen";
            Body = 0x191; // Human female body

            // Stats
            Str = 80;
            Dex = 70;
            Int = 120;
            Hits = 90;

            // Unique Appearance: Medieval German Visionary Abbess
            AddItem(new FancyDress() { Name = "Robe of the Rhineland Visionary", Hue = 2945 });
            AddItem(new HoodedShroudOfShadows() { Name = "Veil of the Benedectine Abbey", Hue = 1150 });
            AddItem(new Sandals() { Name = "Pilgrim's Sandals", Hue = 2107 });
            AddItem(new BodySash() { Name = "Sash of Illuminated Wisdom", Hue = 1152 });
            AddItem(new Spellbook() { Name = "Liber Divinorum Operum", Hue = 2213 }); // Custom prop
            AddItem(new GargishSash() { Name = "Herbalist's Cord", Hue = 1445 });

            // Speech Hue
            SpeechHue = 2219;

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
                Say("I am Hildegard von Bingen, abbess, composer, and seeker of divine mysteries.");
            }
            else if (speech.Contains("job"))
            {
                Say("I serve as abbess of Rupertsberg, tending both the soul and the body through music, herbs, and prayer.");
            }
            else if (speech.Contains("health"))
            {
                Say("I know many cures for ailments of the flesh and spirit. The healing arts are as much a gift as my visions.");
            }
            else if (speech.Contains("abbey") || speech.Contains("rupertsberg"))
            {
                Say("The Abbey of Rupertsberg is my home, where we sing, heal, and illuminate the mysteries of faith.");
            }
            else if (speech.Contains("music") || speech.Contains("chant"))
            {
                Say("Music elevates the soul. I have composed many chants, which the sisters and I sing in praise.");
            }
            else if (speech.Contains("herbs") || speech.Contains("healing"))
            {
                Say("In every leaf and root, God has placed a cure. Sage, fennel, and lavender are but a few allies in healing.");
            }
            else if (speech.Contains("visions") || speech.Contains("vision"))
            {
                Say("Since childhood, I have received luminous visions. They guide my hand in song and word alike.");
            }
            else if (speech.Contains("books") || speech.Contains("manuscript"))
            {
                Say("I have written many manuscripts—on nature, on medicine, and on the divine. My Liber Scivias is illuminated with insight.");
            }
            else if (speech.Contains("scivias"))
            {
                Say("Scivias—'Know the Ways'—is a record of my visions. Each page glows with sacred light.");
            }
            else if (speech.Contains("rhineland") || speech.Contains("germany"))
            {
                Say("The Rhineland flows with rivers of history. Here, mystics, poets, and emperors walk together.");
            }
            else if (speech.Contains("composer") || speech.Contains("song") || speech.Contains("chant"))
            {
                Say("My chants celebrate the living light within all things. Listen, and your heart may sing with them.");
            }
            else if (speech.Contains("light") || speech.Contains("luminous"))
            {
                Say("The living light shines even in darkness. In my visions, I see the world illuminated with meaning.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom dwells in silence, but sings through music and glows in painted illuminations.");
            }
            else if (speech.Contains("sister") || speech.Contains("nuns"))
            {
                Say("My sisters walk beside me, tending the sick, singing praises, and copying sacred books.");
            }
            else if (speech.Contains("emperor") || speech.Contains("frederick"))
            {
                Say("Emperor Frederick sought counsel from many, but few listened to the voice of women in those days.");
            }
            else if (speech.Contains("faith") || speech.Contains("divine"))
            {
                Say("The divine dwells in all living things. To see it, one must open both the mind and the heart.");
            }
            else if (speech.Contains("nature"))
            {
                Say("Nature is God's second book. The rivers, plants, and birds each have a story to share.");
            }
			else if (speech.Contains("medicine"))
			{
				Say("Medicine is both science and art. I have catalogued many herbs in my Physica, a book of natural healing.");
			}
			else if (speech.Contains("physica"))
			{
				Say("Physica is my treatise on the powers of stones, plants, and animals. Each entry is a doorway to creation's wisdom.");
			}
			else if (speech.Contains("viriditas"))
			{
				Say("Viriditas is the greening power, the force of life and growth that flows through all living things.");
			}
			else if (speech.Contains("prophecy"))
			{
				Say("My visions sometimes carry warnings, sometimes blessings. Prophecy is a river—sometimes clear, sometimes shrouded in mist.");
			}
			else if (speech.Contains("abbess"))
			{
				Say("As abbess, I guide my sisters in prayer, song, and stewardship of the land.");
			}
			else if (speech.Contains("rhine") || speech.Contains("river"))
			{
				Say("The Rhine River is the lifeblood of our land, flowing past vineyards and cloisters, bringing news and travelers from afar.");
			}
			else if (speech.Contains("wine"))
			{
				Say("Wine is both medicine and symbol. In moderation, it warms the body and lifts the spirit.");
			}
			else if (speech.Contains("alchemy"))
			{
				Say("Alchemy seeks to transform and perfect. True transformation comes not just to metals, but to hearts.");
			}
			else if (speech.Contains("garden") || speech.Contains("gardens"))
			{
				Say("Our abbey’s gardens are filled with healing herbs and blooming flowers—each a testament to creation’s bounty.");
			}
			else if (speech.Contains("angel") || speech.Contains("angels"))
			{
				Say("In my visions, angels are messengers of light and song, radiant beyond all earthly beauty.");
			}
			else if (speech.Contains("color") || speech.Contains("colors"))
			{
				Say("Colors have meaning: green for growth, gold for divinity, blue for contemplation. Each hue speaks in its own way.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are the soul’s secret language. Sometimes, they reveal truths hidden from waking eyes.");
			}
			else if (speech.Contains("storm") || speech.Contains("weather"))
			{
				Say("Storms can destroy or renew. The weather shapes both land and spirit—listen, and you will hear its lessons.");
			}
			else if (speech.Contains("empress") || speech.Contains("matilda"))
			{
				Say("Empress Matilda, strong and wise, once walked these lands. Her struggles remind us of the power of perseverance.");
			}
			else if (speech.Contains("heaven"))
			{
				Say("Heaven’s music is echoed faintly in our songs. Every good deed is a note in its endless hymn.");
			}
			else if (speech.Contains("herbal"))
			{
				Say("Herbal remedies are woven from observation and faith. Sometimes, the humblest weed holds the greatest cure.");
			}
			else if (speech.Contains("sickness") || speech.Contains("illness"))
			{
				Say("Sickness tests our strength and compassion. Healing requires both knowledge and patience.");
			}
			else if (speech.Contains("pilgrimage") || speech.Contains("pilgrim"))
			{
				Say("Pilgrimage is a journey of body and soul. Each step can bring you closer to understanding.");
			}
			else if (speech.Contains("scribe") || speech.Contains("scriptorium"))
			{
				Say("In the scriptorium, our scribes labor by candlelight, copying wisdom for generations yet to come.");
			}
			else if (speech.Contains("flower") || speech.Contains("flowers"))
			{
				Say("Every flower is a silent hymn of beauty. The meadow is an open book, written by the hand of the Creator.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is a lamp that grows brighter as you share it with others.");
			}			
            else if (speech.Contains("bird") || speech.Contains("raven") || speech.Contains("falcon"))
            {
                Say("Birds fly between earth and sky, messengers of hope and warning alike.");
            }
            else if (speech.Contains("miracle") || speech.Contains("mystery"))
            {
                Say("Miracles are everywhere, if only you learn to see. The greatest mysteries are hidden in plain sight.");
            }
            else if (speech.Contains("illuminate") || speech.Contains("illuminated"))
            {
                Say("The scriptorium is ever busy, illuminating each manuscript with golden light and patient hands.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("illumination"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, seeker. Even the brightest light must rest before shining again.");
                }
                else
                {
                    Say("You have uncovered the illumination at the heart of wisdom. Accept this Treasure Chest of German History—may it kindle your own journey.");
                    from.AddToBackpack(new TreasureChestOfGermanHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Farewell, friend. May your path be filled with light and discovery.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of visions, herbs, music, or the manuscripts that hold our stories.");
                }
            }

            base.OnSpeech(e);
        }

        public HildegardVonBingen(Serial serial) : base(serial) { }

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
