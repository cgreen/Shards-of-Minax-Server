using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Fa Ngum")]
    public class FaNgum : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public FaNgum() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Fa Ngum";
            Title = "Founder of Lan Xang";
            Body = 0x190; // Human male body

            // Unique Appearance: Lao Royal Attire
            AddItem(new ElvenShirt() { Name = "Royal Shirt of Lan Xang", Hue = 1166 });
            AddItem(new FancyKilt() { Name = "Silk Kilt of the Mekong", Hue = 1366 });
            AddItem(new Cloak() { Name = "Peacock Feathered Cloak", Hue = 1359 });
            AddItem(new Circlet() { Name = "Golden Crown of Unity", Hue = 2213 });
            AddItem(new FurBoots() { Name = "Jungle-Walker Boots", Hue = 2055 });
            AddItem(new BodySash() { Name = "Sash of Three Rivers", Hue = 1250 });

            // Weapon: Scepter
            AddItem(new Scepter() { Name = "Scepter of Muang Sua", Hue = 1196 });

            // Speech Hue
            SpeechHue = 2121;

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
                Say("I am Fa Ngum, first King of Lan Xang, where the three rivers meet.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I was an exile. Now, I unite the lands of the Lao under the banner of Lan Xang.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body is old, but my spirit flows strong like the Mekong.");
            }
            else if (speech.Contains("lan xang"))
            {
                Say("Lan Xang means 'Land of a Million Elephants.' It is a kingdom of jungles, rivers, and legends.");
            }
            else if (speech.Contains("exile"))
            {
                Say("I was exiled as a child, sent to Angkor, where I learned the ways of kings and monks.");
            }
            else if (speech.Contains("angkor"))
            {
                Say("Angkor was a city of wonders. There I married a Khmer princess and returned with the Emerald Buddha.");
            }
            else if (speech.Contains("emerald buddha") || speech.Contains("buddha"))
            {
                Say("The Emerald Buddha came with me to Lan Xang, blessing our land with wisdom and peace.");
            }
            else if (speech.Contains("mekong") || speech.Contains("river"))
            {
                Say("The Mekong is the lifeblood of our land, winding from the mountains to the southern sea.");
            }
            else if (speech.Contains("elephant") || speech.Contains("elephants"))
            {
                Say("Elephants are the guardians of our forests and the symbol of our kingdom's strength.");
            }
            else if (speech.Contains("khmer"))
            {
                Say("The Khmer kings taught me many things—how to rule, how to dream, and how to endure.");
            }
            else if (speech.Contains("princess"))
            {
                Say("My queen, Kaeo Ket Keo, is wise as the naga and beautiful as a lotus in morning light.");
            }
            else if (speech.Contains("naga"))
            {
                Say("The naga are river spirits. In Lan Xang, they bring rain, protect temples, and watch over the Emerald Buddha.");
            }
            else if (speech.Contains("king"))
            {
                Say("A king is but a servant to the land and its people. Wisdom and mercy are my greatest swords.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity gave Lan Xang its strength. Three rivers, many peoples, but one heart.");
            }
            else if (speech.Contains("legend") || speech.Contains("story"))
            {
                Say("Lan Xang is full of legends—of naga, elephants, and a green jewel that changed our fate.");
            }
            else if (speech.Contains("fate"))
            {
                Say("Fate flows like the Mekong—sometimes calm, sometimes wild. Even kings must bow to its current.");
            }
            else if (speech.Contains("lao"))
            {
                Say("The Lao are strong and gentle, farmers and poets, loyal to land and family.");
            }
            else if (speech.Contains("jungle") || speech.Contains("forest"))
            {
                Say("Our jungles are home to spirits and tigers. Walk with respect, and you may find rare treasures.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("True treasure is not gold or jewels, but wisdom passed from elder to child.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("A wise ruler listens twice before speaking. What wisdom do you seek, traveler?");
            }
			else if (speech.Contains("music"))
			{
				Say("The khene’s song rises at dusk, echoing across the rice fields. In Lan Xang, music is the breath of the people.");
			}
			else if (speech.Contains("dance"))
			{
				Say("The Lao dance tells stories without words—each step a memory, each gesture a wish for rain or love.");
			}
			else if (speech.Contains("rice"))
			{
				Say("Sticky rice is our daily bread. A meal without rice is a day without sunlight.");
			}
			else if (speech.Contains("monk") || speech.Contains("monks"))
			{
				Say("Our monks walk in saffron robes, carrying blessings and stories from village to village.");
			}
			else if (speech.Contains("temple") || speech.Contains("temples"))
			{
				Say("Temples shine like jewels along the river. Offer a lotus, and you may find peace.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Merchants come from far lands, bringing silk, stories, and sometimes, trouble.");
			}
			else if (speech.Contains("silk"))
			{
				Say("Lao silk is woven with patience. Each thread holds a wish, a prayer, or a secret.");
			}
			else if (speech.Contains("tiger") || speech.Contains("tigers"))
			{
				Say("Tigers are the hidden kings of the forest. To see one and live is to be blessed by the spirits.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("In Lan Xang, the spirits of land and water walk beside us. Honor them, and fortune may smile upon you.");
			}
			else if (speech.Contains("fortune"))
			{
				Say("Fortune is like the river—sometimes full, sometimes dry, always changing.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("The royal drums called warriors to battle, and now they call children to play.");
			}
			else if (speech.Contains("friendship") || speech.Contains("friends"))
			{
				Say("A kingdom is built by many hands and many hearts. Treasure your friends, for they are your true wealth.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("Mountains guard our borders, their peaks hidden in mist. Climb one, and you may glimpse tomorrow.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon above Lan Xang is the same moon that watched over my childhood exile. It remembers all.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Lanterns on the river, laughter in the air—our festivals celebrate life’s turning seasons.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are our hope, our laughter, and the promise that Lan Xang’s story will never end.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("We light candles for our ancestors, so their wisdom may guide us and their courage may dwell in our hearts.");
			}
			else if (speech.Contains("boat") || speech.Contains("boats"))
			{
				Say("The boats of Lan Xang glide like spirits across the water, carrying rice, dreams, and sometimes, secrets.");
			}
			else if (speech.Contains("secret") || speech.Contains("secrets"))
			{
				Say("Every kingdom has secrets, traveler. Some are hidden in old temples, others in the heart of a king.");
			}			
            else if (speech.Contains("blessing") || speech.Contains("bless"))
            {
                Say("I bless you in the name of Lan Xang and the three rivers. May fortune flow with you.");
            }
            else if (speech.Contains("lotus"))
            {
                Say("The lotus blooms even in muddy water. So too can greatness arise from humble origins.");
            }
            else if (speech.Contains("peace"))
            {
                Say("Peace is a fragile flower, easily crushed by greed or pride. Cherish it.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("emerald"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, seeker. Even the Emerald Buddha reveals itself but once in a while.");
                }
                else
                {
                    Say("You have spoken the hidden word of Lan Xang. Accept this Treasure Chest of Lan Xang—may its blessings guide your path.");
                    from.AddToBackpack(new TreasureChestOfLanXang());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the naga of the river guard your steps, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Lan Xang, elephants, naga, or the legends of the Emerald Buddha.");
                }
            }

            base.OnSpeech(e);
        }

        public FaNgum(Serial serial) : base(serial) { }

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
