using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Julien Fedon")]
    public class JulienFedon : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public JulienFedon() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Julien Fédon";
            Body = 0x190; // Human male

            // Unique Appearance: Rebel of the Spice Isle
            AddItem(new FancyShirt() { Name = "Crimson Rebel's Shirt", Hue = 2117 });
            AddItem(new GuildedKilt() { Name = "Kilt of the Grand Étang Uprising", Hue = 2472 });
            AddItem(new ElvenBoots() { Name = "Boots of the Mountain Hideout", Hue = 2405 });
            AddItem(new Cloak() { Name = "Cloak of Revolution", Hue = 1157 });
            AddItem(new Bandana() { Name = "Bandana of Liberty", Hue = 1372 });
            AddItem(new BodySash() { Name = "Sash of Grenadian Resistance", Hue = 1437 });

            // Weapon: Cutlass (iconic Caribbean blade)
            AddItem(new Cutlass() { Name = "Fedon's Cutlass", Hue = 1109 });

            // Speech color: deep green
            SpeechHue = 1421;

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
                Say("I am Julien Fédon, son of Grenada and leader of those who dared to dream of freedom.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a planter, always a rebel. I fought to break the chains binding my people.");
            }
            else if (speech.Contains("health"))
            {
                Say("Storms of war left their scars, but hope kept my spirit strong.");
            }
            else if (speech.Contains("grenada"))
            {
                Say("Grenada, the Isle of Spice, where the mountains hide secrets and the nutmeg trees whisper of old rebellions.");
            }
            else if (speech.Contains("rebel") || speech.Contains("rebellion"))
            {
                Say("The Fédon Rebellion was a cry for liberty, echoing through the hills of Grand Étang.");
            }
            else if (speech.Contains("british"))
            {
                Say("The British clung to power, but we showed them the courage of the Grenadian people.");
            }
            else if (speech.Contains("french"))
            {
                Say("I am of French and African blood. The world calls me a rebel; my people call me hope.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the torch that lights the darkest night. Even defeat cannot extinguish it.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is as precious as the first rains after drought—hard-won, and never forgotten.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains shielded us, their trails known only to the brave and the desperate.");
            }
            else if (speech.Contains("grand etang"))
            {
                Say("Grand Étang was our fortress, our sanctuary. Its mists hid us from our foes.");
            }
            else if (speech.Contains("isle") || speech.Contains("island"))
            {
                Say("This island is both paradise and battlefield—a land of spices and struggle.");
            }
            else if (speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Grenada’s riches lie in her spices: nutmeg, cinnamon, and clove. Their scent is carried on every wind.");
            }
            else if (speech.Contains("chains"))
            {
                Say("To shatter chains, one needs more than strength—one needs unity, courage, and purpose.");
            }
            else if (speech.Contains("unity"))
            {
                Say("Unity turned fear into defiance. My brothers and sisters stood as one beneath the banner of freedom.");
            }
            else if (speech.Contains("banner"))
            {
                Say("Our banner was not of cloth, but of hope and shared resolve.");
            }
            else if (speech.Contains("plantation"))
            {
                Say("From plantation fields to mountain camps, all yearned for liberty.");
            }
            else if (speech.Contains("camp") || speech.Contains("camps"))
            {
                Say("We made our camps in the wild, where the trees listened and the streams remembered.");
            }
            else if (speech.Contains("fire") || speech.Contains("fires"))
            {
                Say("Each night, we gathered by firelight, sharing tales of lost homes and new dreams.");
            }
            else if (speech.Contains("dream") || speech.Contains("dreams"))
            {
                Say("A dream, once spoken aloud, can spark a revolution.");
            }
            else if (speech.Contains("defeat"))
            {
                Say("Defeat cannot erase the memory of resistance. Every generation writes its own story.");
            }
            else if (speech.Contains("father"))
            {
                Say("My father was a free man from France. My mother, a woman of African descent. In me, two worlds met and rebelled.");
            }
            else if (speech.Contains("mother"))
            {
                Say("My mother taught me that strength is found not only in arms, but in kindness and memory.");
            }
            else if (speech.Contains("loss") || speech.Contains("lost"))
            {
                Say("So much was lost in the struggle—friends, family, even hope itself. Yet the will to rise remains.");
            }
            else if (speech.Contains("faith"))
            {
                Say("In the darkest nights, faith was our only companion. Some found it in prayers, others in one another.");
            }
            else if (speech.Contains("river"))
            {
                Say("The rivers of Grenada run red in memory and bright in sunlight. They carried news, hope, and sometimes sorrow.");
            }
            else if (speech.Contains("slavery") || speech.Contains("slave"))
            {
                Say("Slavery chained bodies, but never souls. Our uprising was a cry for dignity no man could deny.");
            }
            else if (speech.Contains("freed"))
            {
                Say("Many dreamed of freedom. Some lived to see it, some died with hope in their hearts.");
            }
            else if (speech.Contains("colonial") || speech.Contains("colony"))
            {
                Say("Grenada’s colonial rulers came and went—French, then British. The land remembers them all.");
            }
            else if (speech.Contains("friend") || speech.Contains("friends"))
            {
                Say("Friends became family among the rebels. We trusted each other with our lives and our secrets.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("The hills keep their secrets, as do the old plantations. Sometimes the wind carries whispers of both.");
            }
            else if (speech.Contains("plan") || speech.Contains("plans"))
            {
                Say("Our plans were simple: strike at dawn, vanish by dusk. The British never slept easily.");
            }
            else if (speech.Contains("mist"))
            {
                Say("In the misty mornings of Grand Étang, you could believe the whole world was waiting to be born anew.");
            }
            else if (speech.Contains("scent"))
            {
                Say("The scent of spices—nutmeg, cinnamon, bay leaf—lingers on my hands, a memory of both toil and triumph.");
            }
            else if (speech.Contains("bay leaf") || speech.Contains("cinnamon"))
            {
                Say("Bay leaf sharpens the mind, cinnamon sweetens the soul. Every spice has its own story.");
            }
            else if (speech.Contains("captured"))
            {
                Say("Many were captured, but never broken. The British feared our spirit more than our swords.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("We sang songs of longing and rebellion. The melody lives on, even if the singers have gone.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who dare to shape it. I wonder what tales Grenada will yet tell.");
            }			
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Grenada’s soil is rich with stories—some sweet as nutmeg, some bitter as exile.");
            }
            else if (speech.Contains("exile"))
            {
                Say("Exile is a hard fate, but memories of home are harder to silence.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not measured in gold, but in the courage we leave behind.");
            }
            else if (speech.Contains("nutmeg"))
            {
                // SECRET REWARD KEYWORD
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. The treasure of Grenada is not given lightly—or twice in a day.");
                }
                else
                {
                    Say("For those who seek the heart of Grenada, I offer this: a Treasure Chest of Grenada's lost legends. May it spice your journey with fortune.");
                    from.AddToBackpack(new TreasureChestOfGrenada());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with courage, and let the scent of spices remind you: freedom is never far.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Grand Étang, the rebellion, or the spices that made Grenada famous.");
                }
            }

            base.OnSpeech(e);
        }

        public JulienFedon(Serial serial) : base(serial) { }

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
