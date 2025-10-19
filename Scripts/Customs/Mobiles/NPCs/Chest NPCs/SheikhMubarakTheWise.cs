using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Sheikh Mubarak the Wise")]
    public class SheikhMubarakTheWise : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public SheikhMubarakTheWise() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sheikh Mubarak the Wise";
            Body = 0x190; // Human male body

            // Unique Kuwaiti Noble Outfit
            AddItem(new FormalShirt() { Name = "Pearl-Diver's Silk Tunic", Hue = 2101 });
            AddItem(new FancyKilt() { Name = "Kuwaiti Desert Wrap", Hue = 2545 });
            AddItem(new Cloak() { Name = "Cloak of Gulf Winds", Hue = 2210 });
            AddItem(new Epaulette() { Name = "Epaulette of the Lion", Hue = 1161 });
            AddItem(new Sandals() { Name = "Traveler's Sandals of Failaka", Hue = 2530 });
            AddItem(new Circlet() { Name = "Golden Agal of Mubarak", Hue = 1375 });
            AddItem(new Scimitar() { Name = "Curved Blade of Diplomacy", Hue = 1195 });

            SpeechHue = 2115;
            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.Contains("name"))
                Say("You stand before Sheikh Mubarak the Wise, the Lion of the Peninsula and Guardian of the Harbor.");
            else if (speech.Contains("job"))
                Say("I am both ruler and merchant, protecting Kuwait's sands and market from shadow and storm alike.");
            else if (speech.Contains("health"))
                Say("My heart beats with the rhythm of desert drums and the call of the pearl divers.");
            else if (speech.Contains("kuwait"))
                Say("Kuwait is a pearl by the sea, born of caravan trails and the courage of its people.");
            else if (speech.Contains("harbor"))
                Say("Our harbor is a gift and a responsibility. Ships from all lands find shelter and trade here.");
            else if (speech.Contains("merchant"))
                Say("Merchants shape destinies. Gold passes hands, but true wealth is trust and wisdom.");
            else if (speech.Contains("pearl"))
                Say("The sea’s pearls are our pride. Ask any diver—each one carries a story.");
            else if (speech.Contains("desert"))
                Say("The desert teaches patience and respect. Even the smallest oasis is a treasure.");
            else if (speech.Contains("lion"))
                Say("Some call me the Lion of the Peninsula, but even lions know the value of peace over claws.");
            else if (speech.Contains("market"))
                Say("In the Grand Market, every voice has a tale and every coin has a journey.");
            else if (speech.Contains("failaka"))
                Say("Failaka Island is ancient—older than Kuwait itself. Its sands whisper secrets at night.");
            else if (speech.Contains("wisdom"))
                Say("Wisdom is a lantern in the night. Care to test yours with a riddle?");
            else if (speech.Contains("tribe"))
                Say("My tribe stands as one, though each member carries the desert’s strength in their own way.");
            else if (speech.Contains("alliance"))
                Say("Strong alliances shape the fate of nations. A wise friend is greater than a thousand spears.");
            else if (speech.Contains("history"))
                Say("Kuwait’s history is written in the footsteps of caravans and the laughter of children by the sea.");
            else if (speech.Contains("diplomacy"))
                Say("Diplomacy is a blade—curved and keen, able to turn foes to friends.");
            else if (speech.Contains("caravan"))
                Say("Caravans bring news and hope from distant lands. Their stories fill our nights.");
            else if (speech.Contains("sand"))
                Say("Sand shapes the land, shifting as fortunes do. Learn to walk with it, not against it.");
            else if (speech.Contains("dhow"))
                Say("The dhow is the soul of our sailors—a sturdy vessel against both wave and wind.");
            else if (speech.Contains("sun"))
                Say("The sun is relentless here, but so is the spirit of Kuwait’s people.");
            else if (speech.Contains("oasis"))
                Say("Every oasis is a promise: that patience will be rewarded in time.");
            else if (speech.Contains("falcon"))
                Say("The falcon is our symbol of vision and swiftness. I often watch them soar at dawn.");
            else if (speech.Contains("secret"))
                Say("Ah, you seek secrets? Sometimes a secret hides inside a riddle.");
			else if (speech.Contains("boat") || speech.Contains("boats"))
			{
				Say("Our boats, especially the dhow, have sailed the Gulf’s waters for centuries, carrying spices and stories alike.");
			}
			else if (speech.Contains("spice") || speech.Contains("spices"))
			{
				Say("Spices are the perfume of trade. From distant India to our market, they fill the air with promise and profit.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is the first pearl a person finds. Protect yours as you would your own honor.");
			}
			else if (speech.Contains("hospitality"))
			{
				Say("In Kuwait, even the poorest tent offers tea and shelter to a traveler. Hospitality is our oldest law.");
			}
			else if (speech.Contains("tea"))
			{
				Say("A pot of tea, a pinch of saffron, and good company—this is the recipe for peace.");
			}
			else if (speech.Contains("date") || speech.Contains("dates"))
			{
				Say("Dates are the desert’s gift. Sweetness and strength, wrapped in golden skin.");
			}
			else if (speech.Contains("music"))
			{
				Say("Listen closely: the oud sings of old times, and the rebab weeps for lost loves.");
			}
			else if (speech.Contains("oud"))
			{
				Say("The oud’s melodies linger long after the last note. Some say it remembers every hand that ever played it.");
			}
			else if (speech.Contains("bazaar"))
			{
				Say("The bazaar is a maze of voices. Wander with open eyes and you may find more than you seek.");
			}
			else if (speech.Contains("lantern") || speech.Contains("lanterns"))
			{
				Say("A single lantern chases away a thousand shadows. In the market at dusk, their lights dance like fireflies.");
			}
			else if (speech.Contains("tradition") || speech.Contains("custom"))
			{
				Say("Tradition is a thread binding us to our ancestors. Break it, and the tapestry unravels.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("Our ancestors crossed burning sands and restless seas. Their courage is our inheritance.");
			}
			else if (speech.Contains("friendship"))
			{
				Say("A friend gained at sea is worth more than ten found on land. Storms forge true bonds.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Even the fiercest storm must end, leaving behind a sky clearer than before.");
			}
			else if (speech.Contains("fortune"))
			{
				Say("Fortune is fickle as the desert wind. Prepare for both feast and famine.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night in the desert is a blanket of stars. Listen—the silence carries its own wisdom.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("The stars are our oldest guides. Each one a story, each constellation a lesson.");
			}
			else if (speech.Contains("lesson"))
			{
				Say("Every lesson is a stone in the path to greatness. Step carefully and remember where you have walked.");
			}
			else if (speech.Contains("journey"))
			{
				Say("A journey changes a person, whether they cross an ocean or a single threshold.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("True legacy is not gold, but the good you leave in others’ hearts.");
			}				
            else if (speech.Contains("riddle"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The best riddles cannot be solved twice in one day, my friend. Return when the sands have shifted.");
                }
                else
                {
                    Say("Impressive! Few have the courage to seek the riddle's reward. Accept this Treasure Chest of Kuwait with my blessing—may it bring you both wisdom and fortune.");
                    from.AddToBackpack(new TreasureChestOfKuwait());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the winds guide your steps, and the stars light your path home.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                    Say("Ask me of pearls, markets, lions, Failaka, or perhaps... a riddle.");
            }

            base.OnSpeech(e);
        }

        public SheikhMubarakTheWise(Serial serial) : base(serial) { }

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
