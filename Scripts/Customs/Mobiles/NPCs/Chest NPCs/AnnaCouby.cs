using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Anna Couby")]
    public class AnnaCouby : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public AnnaCouby() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Anna Couby";
            Title = "Keeper of the Dodo's Memory";
            Body = 0x191; // Human female

            // Appearance: unique Creole-Mauritian look
            AddItem(new FloweredDress() { Name = "Creole Dress of Ebony Island", Hue = 2509 });
            AddItem(new WideBrimHat() { Name = "Sunshade of Chamarel", Hue = 2470 });
            AddItem(new Sandals() { Name = "Sandalwood Slippers", Hue = 2627 });
            AddItem(new BodySash() { Name = "Sash of the Sugarcane Fields", Hue = 2006 });
            AddItem(new Cloak() { Name = "Mist-Cloak of Le Morne", Hue = 1153 });
            AddItem(new FeatheredHat() { Name = "Dodo Feather Fan", Hue = 2055 }); // As a fan, carried, optional prop
            AddItem(new GnarledStaff() { Name = "Ebony Walking Stick", Hue = 1172 });

            SpeechHue = 2220;

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
                Say("I am Anna Couby, once a healer and now a weaver of island memories.");
            }
            else if (speech.Contains("job"))
            {
                Say("I keep stories and secrets of Mauritius, from dodo days to spice ships.");
            }
            else if (speech.Contains("health"))
            {
                Say("My bones are old, but the sea breeze keeps me spry. A sip of tamarind helps too!");
            }
            else if (speech.Contains("mauritius"))
            {
                Say("Mauritius is my home—a jewel in the Indian Ocean, where many worlds meet.");
            }
            else if (speech.Contains("dodo"))
            {
                Say("Ah, the poor dodo! Gone before her time, yet she lives in every tale I tell.");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every breeze carries a story here. Ask me of Le Morne, pirates, or vanished things.");
            }
            else if (speech.Contains("vanished"))
            {
                Say("Vanished are the dodos, the runaway slaves, and even some pirate gold, lost to time.");
            }
            else if (speech.Contains("pirate") || speech.Contains("pirates"))
            {
                Say("Once, pirates hid treasure beneath our palms, and sang with the waves. Some say their ghosts wander at night.");
            }
            else if (speech.Contains("le morne"))
            {
                Say("Le Morne mountain shelters the memory of freedom—maroons who dared escape and live wild.");
            }
            else if (speech.Contains("maroon") || speech.Contains("maroons"))
            {
                Say("The maroons were runaways, fighting for freedom in the forests. Their courage shaped our island soul.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Nutmeg, vanilla, and cloves—spices once worth more than gold. Their scent clings to my stories.");
            }
            else if (speech.Contains("sugar") || speech.Contains("sugarcane"))
            {
                Say("Fields of sugarcane ripple like green oceans, feeding island and empire alike.");
            }
            else if (speech.Contains("french") || speech.Contains("creole"))
            {
                Say("French words, Creole songs—our tongue is a tapestry, stitched with many roots.");
            }
            else if (speech.Contains("island"))
            {
                Say("Islands remember more than we do. Listen close and you'll hear the whispers of old ships and lost birds.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is salt on the wind, tasted by those brave enough to seize it.");
            }
            else if (speech.Contains("memory") || speech.Contains("memories"))
            {
                Say("Memory is my lantern in the dusk. What do you wish to remember?");
            }
            else if (speech.Contains("bird"))
            {
                Say("Birds flock to Mauritius, but none like the dodo—so round and trusting, now only a feather in legend.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends grow like banyan trees—roots and branches tangled, truth and fable together.");
            }
            else if (speech.Contains("herb") || speech.Contains("herbs") || speech.Contains("healer"))
            {
                Say("I know the leaves and roots of healing. Even now, I sip my tea of lemongrass and hope.");
            }
            else if (speech.Contains("runaway"))
            {
                Say("Runaways sought safety in the forests, living on wild fruit and hope.");
            }
            else if (speech.Contains("ship") || speech.Contains("ships"))
            {
                Say("So many ships—Dutch, French, English—brought trouble and treasure to these shores.");
            }
			else if (speech.Contains("tea") || speech.Contains("chai"))
			{
				Say("Ah, a good cup of black tea with a splash of milk—no Mauritian morning starts without it!");
			}
			else if (speech.Contains("market") || speech.Contains("bazaar"))
			{
				Say("In Port Louis market, colors and scents swirl—lychees, vanilla, and gossip, all in one breath.");
			}
			else if (speech.Contains("port louis"))
			{
				Say("Port Louis is the heart of Mauritius—lively, noisy, and always hungry for a new story.");
			}
			else if (speech.Contains("cane fire") || speech.Contains("fire"))
			{
				Say("When cane fields burn, ash dances like black butterflies. It means harvest—and sometimes danger.");
			}
			else if (speech.Contains("rain") || speech.Contains("rainbow"))
			{
				Say("Here, rain comes and goes, and rainbows bend over the sugar fields, promising a sweet tomorrow.");
			}
			else if (speech.Contains("music") || speech.Contains("sega"))
			{
				Say("Sega is our island’s heartbeat—bare feet on sand, drums by the fire, singing the stories of our ancestors.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("My ancestors whisper in the wind and rustle the cane. Their lessons shape my every step.");
			}
			else if (speech.Contains("fishing") || speech.Contains("fisher"))
			{
				Say("At dawn, the fishers pull nets from turquoise waters—hoping for a feast, and finding tales instead.");
			}
			else if (speech.Contains("shipwreck") || speech.Contains("wreck"))
			{
				Say("Many ships met their end on these coral reefs. Sometimes, the sea still gives up a coin or a bottle.");
			}
			else if (speech.Contains("coin") || speech.Contains("coins"))
			{
				Say("An old coin carries many hands—pirate, planter, or king. Every one tells a tale.");
			}
			else if (speech.Contains("slave") || speech.Contains("slavery"))
			{
				Say("Slavery scarred this island, but the spirit of freedom outgrew the chains.");
			}
			else if (speech.Contains("rum"))
			{
				Say("A sip of Mauritian rum can warm the soul or loosen a tongue. Careful not to drink too much, or you’ll be dancing sega all night!");
			}
			else if (speech.Contains("vanilla"))
			{
				Say("Vanilla grows like gold in the forests. Its sweet scent lingers long after the flowers fade.");
			}
			else if (speech.Contains("volcano") || speech.Contains("volcanic"))
			{
				Say("The island’s heart is an old volcano—its fire sleeps now, but its spirit shapes every stone and hill.");
			}
			else if (speech.Contains("market"))
			{
				Say("The market is full of laughter, shouting, and the clink of spices. If you want news, that’s where you go.");
			}
			else if (speech.Contains("bay"))
			{
				Say("Grand Baie is where the sea is bluest and the boats bob like painted eggs.");
			}
			else if (speech.Contains("coral") || speech.Contains("reef"))
			{
				Say("Our reefs are alive with color—fish, coral, secrets, and the bones of careless sailors.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend is rarer than dodo’s egg, and twice as precious.");
			}
			else if (speech.Contains("night") || speech.Contains("moon"))
			{
				Say("When the moon is bright, I sit by the water and listen for old songs in the waves.");
			}			
            else if (speech.Contains("treasure"))
            {
                Say("True treasure is not gold, but a shared story or a simple treat, like a fresh gateau piment.");
            }
            else if (speech.Contains("gateau piment") || speech.Contains("gâteau piment") || speech.Contains("chili cake"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Slow down, ti-zanfan! Even a gateau piment is best enjoyed with patience.");
                }
                else
                {
                    Say("You know the island’s secret! Take this Treasure Chest of Mauritius, as spicy and surprising as our little cakes.");
                    from.AddToBackpack(new TreasureChestOfMauritius());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the breeze of the Indian Ocean guide your steps, wherever you wander.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.13)
                    Say("Ask me of dodo, Le Morne, pirates, or perhaps a spicy treat...");
            }

            base.OnSpeech(e);
        }

        public AnnaCouby(Serial serial) : base(serial) { }

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
