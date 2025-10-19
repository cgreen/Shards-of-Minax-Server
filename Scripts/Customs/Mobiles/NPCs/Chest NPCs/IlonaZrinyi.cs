using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ilona Zrínyi")]
    public class IlonaZrinyi : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public IlonaZrinyi() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ilona Zrínyi";
            Body = 0x191; // Human female body

            // Stats
            Str = 85;
            Dex = 70;
            Int = 105;
            Hits = 95;

            // Unique Noble Warrior Appearance
            AddItem(new FancyShirt() { Name = "Satin Shirt of the Danube", Hue = 2105 });
            AddItem(new FancyKilt() { Name = "Royal Kilt of Zrínyi", Hue = 1342 });
            AddItem(new Cloak() { Name = "Defender's Cloak of Munkács", Hue = 2425 });
            AddItem(new FeatheredHat() { Name = "Plumed Hat of Hungarian Nobility", Hue = 1167 });
            AddItem(new FurBoots() { Name = "Boots of the Carpathians", Hue = 1109 });
            AddItem(new BodySash() { Name = "Sash of Rebellion", Hue = 2527 });
            AddItem(new PlateGloves() { Name = "Gauntlets of Resolve", Hue = 1818 });

            // Weapon: Rapier (using Longsword for in-game model)
            AddItem(new Longsword() { Name = "Rapier of Munkács", Hue = 2403 });

            // Speech Hue
            SpeechHue = 2001;

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
                Say("I am Ilona Zrínyi, Countess of Hungary and the steadfast defender of Munkács Castle.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to defend my people and my homeland from those who would see them fall.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit remains unbroken, though the sieges were harsh and hunger often our only companion.");
            }
            else if (speech.Contains("munkacs") || speech.Contains("castle"))
            {
                Say("Munkács Castle stands atop the hills of the Carpathians, a beacon of hope in dark times.");
            }
            else if (speech.Contains("siege"))
            {
                Say("For three years, I held the fortress against overwhelming odds. The enemy's cannons could not shake our walls nor our resolve.");
            }
            else if (speech.Contains("hungary") || speech.Contains("hungarian"))
            {
                Say("Hungary is a land of rivers and legends, forged by battles and bound by courage.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Our legends are stories of bravery and sacrifice. Will yours join their ranks?");
            }
            else if (speech.Contains("danube"))
            {
                Say("The Danube carries tales of heroes and dreamers from the mountains to the sea.");
            }
            else if (speech.Contains("carpathians") || speech.Contains("mountain"))
            {
                Say("The Carpathians are our shield, sheltering us from those who would conquer our lands.");
            }
            else if (speech.Contains("noble") || speech.Contains("nobility"))
            {
                Say("Nobility is not in title alone, but in the strength to endure and the wisdom to lead.");
            }
            else if (speech.Contains("resolve"))
            {
                Say("Resolve is forged in hardship, tempered by sacrifice. It is our true armor.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the light we hold aloft, even when surrounded by darkness.");
            }
            else if (speech.Contains("turk") || speech.Contains("ottoman"))
            {
                Say("The Ottoman armies sought to break us, but found instead a fortress and a people unyielding.");
            }
            else if (speech.Contains("family"))
            {
                Say("My family’s fate is bound to Hungary. My son, Ferenc Rákóczi, too, is a name history will remember.");
            }
            else if (speech.Contains("rakoczi") || speech.Contains("ferenc"))
            {
                Say("Ferenc Rákóczi, my son, would one day lead another fight for our freedom and dignity.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is our final bastion, the flame that burns within the coldest walls.");
            }
            else if (speech.Contains("wall") || speech.Contains("walls"))
            {
                Say("The walls of Munkács protected not just bodies, but the dreams of a people.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("Dreams give us strength when all else fails. My dreams were always of peace, not war.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is earned by those willing to defend it, time and again.");
            }
            else if (speech.Contains("flame"))
            {
                Say("A single flame of courage can set hearts ablaze, defying any darkness.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is not the absence of fear, but the will to stand firm in spite of it.");
            }
            else if (speech.Contains("will"))
            {
                Say("Willpower is my shield; as long as I draw breath, Hungary shall not fall.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Victory does not always belong to the strongest, but to those who endure the longest.");
            }
            else if (speech.Contains("endure") || speech.Contains("endurance"))
            {
                Say("Endurance is the true test of the soul. It shapes leaders and legends alike.");
            }
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty binds a people together in their darkest hour, when even hope seems lost.");
			}
			else if (speech.Contains("castle kitchen") || speech.Contains("kitchen"))
			{
				Say("The castle kitchen fed both warriors and children. Bread and stories were shared, even in times of siege.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Betrayal is the wound that never heals, yet from scars we learn to trust wisely.");
			}
			else if (speech.Contains("rain") || speech.Contains("weather"))
			{
				Say("Storms battered our banners, yet we stood firm atop the rain-soaked stones.");
			}
			else if (speech.Contains("banner") || speech.Contains("flag"))
			{
				Say("The Hungarian banner flew above Munkács, a red and white defiance against the encroaching dusk.");
			}
			else if (speech.Contains("women") || speech.Contains("woman"))
			{
				Say("Women held the walls as bravely as any man. Their hands carried swords, hope, and the wounded alike.");
			}
			else if (speech.Contains("folk") || speech.Contains("people"))
			{
				Say("The folk of Hungary are resilient. They sing old songs by firelight and remember the names of the lost.");
			}
			else if (speech.Contains("song") || speech.Contains("sing"))
			{
				Say("Songs kept our spirits alive. Even when arrows fell, we sang of home, hearth, and the river Tisza.");
			}
			else if (speech.Contains("tisza"))
			{
				Say("The Tisza river glimmers under the moon, flowing past fields of sunflowers and old legends.");
			}
			else if (speech.Contains("sunflower") || speech.Contains("fields"))
			{
				Say("Fields of sunflowers nod to the morning sun—symbols of hope, even in the shadow of war.");
			}
			else if (speech.Contains("stories") || speech.Contains("story"))
			{
				Say("Every scar tells a story, every survivor is a chapter. Ask, and I shall share what I remember.");
			}
			else if (speech.Contains("childhood"))
			{
				Say("My childhood was filled with tales of valor and loss, preparing me for the storms to come.");
			}
			else if (speech.Contains("armor"))
			{
				Say("Armor may shield the body, but true strength is worn within the heart.");
			}
			else if (speech.Contains("victor"))
			{
				Say("History remembers the victors, but legends remember the steadfast and the just.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the blade that cuts both ways. I have seen tyrants fall by their own hand.");
			}
			else if (speech.Contains("oath") || speech.Contains("promise"))
			{
				Say("An oath sworn beneath these battlements is a promise kept for a lifetime.");
			}
			else if (speech.Contains("wine"))
			{
				Say("Hungarian wine warmed many cold nights—each sip, a reminder of the joys worth fighting for.");
			}
			else if (speech.Contains("fare"))
			{
				Say("We made do with humble fare: black bread, onions, and hope. Even the simplest meal is a feast among comrades.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("Every dawn is a blessing, each friend a treasure. Cherish both.");
			}			
            else if (speech.Contains("bastion"))
            {
                Say("Every fortress is a bastion, but the heart is the strongest stronghold.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("There are secrets hidden in every stone of Munkács, and in the courage of those who defend her.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("fortitude"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("True fortitude is patient. Return when the hour is right.");
                }
                else
                {
                    Say("You show the fortitude of a true defender. Accept this Treasure Chest of Hungarian Legends, and let your story join ours.");
                    from.AddToBackpack(new TreasureChestOfHungarianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May your spirit be steadfast, and your courage unbroken.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Munkács, resolve, or the Carpathians—our walls held more than stone.");
                }
            }

            base.OnSpeech(e);
        }

        public IlonaZrinyi(Serial serial) : base(serial) { }

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
