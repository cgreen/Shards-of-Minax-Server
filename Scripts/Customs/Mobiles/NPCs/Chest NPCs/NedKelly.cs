using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ned Kelly")]
    public class NedKelly : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public NedKelly() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ned Kelly";
            Body = 0x190; // Human male

            // Stats
            Str = 90;
            Dex = 80;
            Int = 60;
            Hits = 85;

            // Unique Appearance: Iconic Bushranger
            AddItem(new FancyShirt() { Name = "Bushranger's Linen Shirt", Hue = 1109 });
            AddItem(new LeatherNinjaJacket() { Name = "Kelly Gang Duster Coat", Hue = 2106 });
            AddItem(new LeatherLegs() { Name = "Outlaw's Ironclad Trousers", Hue = 2309 });
            AddItem(new Boots() { Name = "Woolshed Black Boots", Hue = 2405 });
            AddItem(new BodySash() { Name = "Jerilderie Red Sash", Hue = 1354 });

            // Iconic Helmet: Custom Plate Helm
            AddItem(new PlateHelm() { Name = "Homemade Iron Helmet", Hue = 1150 });

            // Weapon: Bushranger’s Carbine
            AddItem(new RepeatingCrossbow() { Name = "Bushranger's Carbine", Hue = 1175 });

            // Speech Hue
            SpeechHue = 2122;

            // Initialize the lastRewardTime to a past time
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
                Say("The name's Ned Kelly—bushranger, outlaw, and some say a hero to the common folk.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once I was a farmhand and horse-breaker, but fate led me down the road of the bushranger.");
            }
            else if (speech.Contains("health"))
            {
                Say("A bullet or two won’t keep a Kelly down—though the scars do tell stories.");
            }
            else if (speech.Contains("bushranger"))
            {
                Say("A bushranger lives wild, fighting the law and surviving off the land.");
            }
            else if (speech.Contains("outlaw"))
            {
                Say("Outlaw? Maybe. But sometimes, you’ve got to break the rules to stand up for what’s right.");
            }
            else if (speech.Contains("kelly gang") || speech.Contains("gang"))
            {
                Say("The Kelly Gang—me, Dan Kelly, Steve Hart, and Joe Byrne. Brothers in arms, fighting for our lives.");
            }
            else if (speech.Contains("dan") || speech.Contains("steve") || speech.Contains("joe"))
            {
                Say("Dan was my blood, Steve my mate, and Joe my cleverest friend. Together, we made history.");
            }
            else if (speech.Contains("armor") || speech.Contains("iron") || speech.Contains("helmet"))
            {
                Say("We built iron armor from ploughshares—enough to turn bullets at Glenrowan. My helmet? Homemade, and heavy as a mountain.");
            }
            else if (speech.Contains("glenrowan"))
            {
                Say("Glenrowan was our last stand. Surrounded by troopers, we wore our iron suits and fought to the end.");
            }
            else if (speech.Contains("jerilderie"))
            {
                Say("At Jerilderie, I wrote a letter—my side of the story. Folks still read it today.");
            }
            else if (speech.Contains("letter"))
            {
                Say("The Jerilderie Letter tells of injustice and the lives of those pushed too far.");
            }
            else if (speech.Contains("police") || speech.Contains("trooper"))
            {
                Say("The police were no friends of the Kellys. We were hunted from the bush to the border.");
            }
            else if (speech.Contains("mother"))
            {
                Say("My mother, Ellen Kelly, was strong as iron. She taught me to stand tall, even when the world pressed down.");
            }
            else if (speech.Contains("australia"))
            {
                Say("Australia’s a land for the bold—bush, gold, and a bit of wild spirit in every heart.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A true bushranger waits for the right moment. Try me again after some time has passed.");
                }
                else
                {
                    Say("You’ve got the grit of a Kelly. Take this Treasure Chest of Australia—may it serve you well on your journey.");
                    from.AddToBackpack(new TreasureChestOfAustralia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("gold"))
            {
                Say("Gold fever swept the land. Some found riches, others found trouble.");
            }
            else if (speech.Contains("bush") || speech.Contains("land"))
            {
                Say("The bush hides many secrets—and gives shelter to those who know it.");
            }
			else if (speech.Contains("mate") || speech.Contains("mateship"))
			{
				Say("Mateship is everything in the bush. You look after your mate, and your mate looks after you. That’s how you survive.");
			}
			else if (speech.Contains("law") || speech.Contains("justice"))
			{
				Say("The law’s supposed to serve the people, but sometimes it just serves itself. That’s when you’ve got to stand up, even if it means trouble.");
			}
			else if (speech.Contains("youth") || speech.Contains("childhood"))
			{
				Say("Grew up tough—drought, hard work, and not much kindness from the law. But the bush taught me to be quick on my feet.");
			}
			else if (speech.Contains("billy") || speech.Contains("tea"))
			{
				Say("Nothing better than a hot billy of tea under the stars, with a good yarn and your mates close by.");
			}
			else if (speech.Contains("horse"))
			{
				Say("A good horse’ll get you out of more strife than any pistol. My old mare could outrun half the troopers in Victoria.");
			}
			else if (speech.Contains("gaol") || speech.Contains("jail") || speech.Contains("prison"))
			{
				Say("I saw the inside of more gaols than I care to count. Bars keep the body in, but the mind still runs wild.");
			}
			else if (speech.Contains("legend") || speech.Contains("myth"))
			{
				Say("People say I’m a legend. Maybe I am, or maybe I’m just a bloke who didn’t want to bow down.");
			}
			else if (speech.Contains("luck"))
			{
				Say("Luck’s a fickle thing in the bush. Sometimes you find a coin, sometimes a snake. Keep your wits about you!");
			}
			else if (speech.Contains("trooper") || speech.Contains("copper"))
			{
				Say("Those troopers chased me from Benalla to Beechworth. Never met one who could ride better than a Kelly, though.");
			}
			else if (speech.Contains("pistol") || speech.Contains("gun"))
			{
				Say("A pistol’s only as good as the hand that holds it. But a quick mind’ll get you out of more trouble than a quick draw.");
			}
			else if (speech.Contains("goldfields") || speech.Contains("diggers"))
			{
				Say("The goldfields were wild places—full of hope, dust, and more than a few fools with dreams of fortune.");
			}
			else if (speech.Contains("drought"))
			{
				Say("A drought will break the back of any farmer. Makes an outlaw of honest men when the creeks run dry.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Everyone’s got their own truth. The real trick is knowing which side of it you stand on.");
			}
			else if (speech.Contains("famous"))
			{
				Say("Didn’t set out to be famous. All I wanted was a fair go for my family. The rest is history, for better or worse.");
			}
			else if (speech.Contains("bush"))
			{
				Say("The bush is home. It hides you, feeds you, and—if you’re not careful—swallows you whole.");
			}
			else if (speech.Contains("last words") || speech.Contains("final words"))
			{
				Say("Such is life.");
			}
			else if (speech.Contains("sheep") || speech.Contains("cattle"))
			{
				Say("Drove sheep and cattle for a living, before the badge-wearers made out we were all crooks.");
			}
			else if (speech.Contains("fortune"))
			{
				Say("Some say I left a hidden fortune in the bush. Truth is, my fortune was freedom, and that’s hard to bury.");
			}
			else if (speech.Contains("waltzing matilda"))
			{
				Say("Heard the tune on many a cold night. A song for swaggies and wild hearts everywhere.");
			}
			else if (speech.Contains("swagman") || speech.Contains("swagmen"))
			{
				Say("Swagmen wander for work or adventure. Sometimes, you wander just to stay ahead of trouble.");
			}
			else if (speech.Contains("favourite") || speech.Contains("favorite"))
			{
				Say("Favourite? I reckon there’s nothing better than a cool creek after a hot day on the run.");
			}		
            else if (speech.Contains("hero"))
            {
                Say("Not all heroes wear badges. Sometimes, they wear iron and ride through the night.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice isn’t always found in the courts. Sometimes, you must make your own stand.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Ride safe, mate. And remember, sometimes the wild ones are the ones who change the world.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me about armor, the Kelly Gang, Glenrowan, or the Jerilderie Letter.");
                }
            }

            base.OnSpeech(e);
        }

        public NedKelly(Serial serial) : base(serial) { }

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
