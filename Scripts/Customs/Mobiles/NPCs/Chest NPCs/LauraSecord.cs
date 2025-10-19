using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Laura Secord")]
    public class LauraSecord : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public LauraSecord() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Laura Secord";
            Body = 0x191; // Human female body

            // Stats
            Str = 65;
            Dex = 80;
            Int = 100;
            Hits = 60;

            // Unique Appearance: Canadian Heroine
            AddItem(new FancyShirt() { Name = "Patriot's Linen Blouse", Hue = 1150 });
            AddItem(new PlainDress() { Name = "Loyalist's Woolen Dress", Hue = 2312 });
            AddItem(new Cloak() { Name = "Redcloak of the Niagara March", Hue = 38 });
            AddItem(new Bonnet() { Name = "Secord's Sturdy Bonnet", Hue = 2036 });
            AddItem(new Shoes() { Name = "Trailworn Walking Shoes", Hue = 1109 });
            AddItem(new BodySash() { Name = "Heroine's Sash of the North", Hue = 2057 });

            // No weapon; Laura’s weapon was her courage!

            // Speech Hue
            SpeechHue = 2212;

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
                Say("I am Laura Secord, once a quiet settler, now remembered for a long and perilous journey.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was a wife and mother—until the War of 1812 called me to a greater duty.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body is weary, but my spirit is ever resolute.");
            }
            else if (speech.Contains("journey"))
            {
                Say("One fateful day, I traveled through woods and swamps to warn British forces of an impending attack.");
            }
            else if (speech.Contains("war") || speech.Contains("1812"))
            {
                Say("The War of 1812 raged across our land. I could not stand by while danger threatened my home.");
            }
            else if (speech.Contains("danger"))
            {
                Say("Enemy soldiers surrounded our farm. Still, I slipped away to carry my warning.");
            }
            else if (speech.Contains("warning"))
            {
                Say("I overheard plans for an American attack at Beaver Dams. Only speed and secrecy could save us.");
            }
            else if (speech.Contains("beaver") || speech.Contains("beaver dams"))
            {
                Say("Beaver Dams was where Lieutenant FitzGibbon held his post—if I could reach him, we might avert disaster.");
            }
            else if (speech.Contains("fitzgibbon"))
            {
                Say("Lieutenant FitzGibbon listened to my warning and prepared the British troops.");
            }
            else if (speech.Contains("troops"))
            {
                Say("With the help of Mohawk allies, the British ambushed the enemy and won a vital victory.");
            }
            else if (speech.Contains("mohawk"))
            {
                Say("The Mohawk warriors were swift and cunning; their help was crucial to our cause.");
            }
            else if (speech.Contains("allies"))
            {
                Say("Alone, I would have failed. It was the unity of British, Canadian, and Indigenous allies that saved us.");
            }
            else if (speech.Contains("victory"))
            {
                Say("The victory at Beaver Dams turned the tide, preserving Upper Canada.");
            }
            else if (speech.Contains("canada"))
            {
                Say("Canada was but a collection of provinces then—held together by hope and courage.");
            }
            else if (speech.Contains("province") || speech.Contains("provinces"))
            {
                Say("Each province adds its own story and strength to the country we now call Canada.");
            }
            else if (speech.Contains("family"))
            {
                Say("My family endured much during the war. Yet love and loyalty kept us strong.");
            }
            else if (speech.Contains("loyalty"))
            {
                Say("Loyalty to home and country is the greatest armor a soul can wear.");
            }
            else if (speech.Contains("armor"))
            {
                Say("I wore no armor—just determination and the memory of those I loved.");
            }
			else if (speech.Contains("farm") || speech.Contains("farmhouse"))
			{
				Say("My family’s farm was our livelihood, and my refuge—until war made even the fields feel uncertain.");
			}
			else if (speech.Contains("milk") || speech.Contains("cow"))
			{
				Say("I left under pretense of milking our cow, hoping the soldiers would not suspect my true purpose.");
			}
			else if (speech.Contains("soldier") || speech.Contains("soldiers"))
			{
				Say("The soldiers quartered in our house were weary, but war makes even neighbors into strangers.");
			}
			else if (speech.Contains("river") || speech.Contains("creek"))
			{
				Say("Creeks and rivers crisscrossed my path—each crossing tested my resolve as much as my strength.");
			}
			else if (speech.Contains("weather"))
			{
				Say("The summer woods were thick and humid, the air buzzing with insects. My dress was soon soaked with sweat and fear.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Every step, I feared I would be caught. Still, duty pressed me forward.");
			}
			else if (speech.Contains("bravery") || speech.Contains("brave"))
			{
				Say("Bravery is not the absence of fear, but the will to act despite it.");
			}
			else if (speech.Contains("rumor") || speech.Contains("rumors"))
			{
				Say("Rumors swirled like autumn leaves—each carried a kernel of truth and a harvest of worry.");
			}
			else if (speech.Contains("family") || speech.Contains("children"))
			{
				Say("My thoughts were always with my children. Their laughter was my greatest comfort and my strongest resolve.");
			}
			else if (speech.Contains("maple") || speech.Contains("leaf"))
			{
				Say("The maple leaf is more than a symbol—it stands for endurance, change, and quiet strength.");
			}
			else if (speech.Contains("queen"))
			{
				Say("We lived under the distant rule of the British crown, but the heart of Canada has always belonged to its people.");
			}
			else if (speech.Contains("loyalist") || speech.Contains("loyalists"))
			{
				Say("Many neighbors were Loyalists, fleeing the American Revolution. Their stories, too, shaped this land.");
			}
			else if (speech.Contains("gratitude") || speech.Contains("thanks"))
			{
				Say("I am grateful to be remembered. Every kind word keeps my memory—and the spirit of Canada—alive.");
			}
			else if (speech.Contains("history"))
			{
				Say("History is the lantern that lights our path. Learn its lessons well, and you shall not lose your way.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("It is easy to call someone ‘enemy’ in war, but in peace, we are all neighbors, hoping for a better life.");
			}
			else if (speech.Contains("niagara"))
			{
				Say("The Niagara region is both beautiful and strategic. Its forests and fields have seen both peace and peril.");
			}
			else if (speech.Contains("forest") || speech.Contains("woods"))
			{
				Say("The woods sheltered me from watchful eyes, but every snapping twig was a threat.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is what carried me through—hope for peace, for my family, for the future.");
			}			
            else if (speech.Contains("memory"))
            {
                Say("They say memory is fragile, but stories endure. Will you help keep mine alive?");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("My story is but one thread in the great tapestry of Canadian heritage.");
            }
            else if (speech.Contains("heritage"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Some treasures must wait to be discovered again. Return when the tale is ready to be retold.");
                }
                else
                {
                    Say("You have honored the heritage of Canada and the courage of its people. Please accept this Treasure Chest of Canadian Heritage as a token of our shared past.");
                    from.AddToBackpack(new TreasureChestOfCanadianHeritage());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May courage guide your steps, as it once guided mine. Farewell, friend.");
            }
            else
            {
                // Encourage the player to ask about something else, sometimes
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of my journey, of warning, or of the heritage we share.");
                }
            }

            base.OnSpeech(e);
        }

        public LauraSecord(Serial serial) : base(serial) { }

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
