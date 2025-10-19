using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Rani Lakshmibai")]
    public class RaniLakshmibai : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public RaniLakshmibai() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Rani Lakshmibai";
            Body = 0x191; // Human female body

            // Unique Appearance: Warrior Queen of Jhansi
            AddItem(new FancyShirt() { Name = "Royal Tunic of Jhansi", Hue = 1355 });
            AddItem(new GuildedKilt() { Name = "Saffron Battle Sari", Hue = 2110 });
            AddItem(new Cloak() { Name = "Veil of the Lotus", Hue = 2075 });
            AddItem(new Bandana() { Name = "Jhansi Warrior's Headscarf", Hue = 1153 });
            AddItem(new FurBoots() { Name = "Boots of the Monsoon March", Hue = 2413 });
            AddItem(new BodySash() { Name = "Sash of the Rebel Queen", Hue = 1161 });

            // Armor: Light for mobility, hinting at warrior heritage
            AddItem(new StuddedGloves() { Name = "Gloves of Valor", Hue = 2076 });

            // Weapon: Sword and Shield
            AddItem(new Katana() { Name = "Sword of Resistance", Hue = 2077 });
            AddItem(new BashingShield() { Name = "Lotus-Emblazoned Shield", Hue = 1372 });

            // Speech Hue
            SpeechHue = 2212;

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
                Say("I am Rani Lakshmibai, Queen of Jhansi and guardian of her legacy.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty was to defend my people and uphold the honor of Jhansi against foreign rule.");
            }
            else if (speech.Contains("health"))
            {
                Say("A warrior's heart knows both wounds and healing. My spirit rides on.");
            }
            else if (speech.Contains("jhansi"))
            {
                Say("Jhansi is the land I called home—a fortress of hope, standing tall upon ancient stone.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen serves, leads, and defends. In battle, I rode with sword in hand, never behind.");
            }
            else if (speech.Contains("british") || speech.Contains("colonial"))
            {
                Say("The British sought to claim our land, but Jhansi did not yield so easily.");
            }
            else if (speech.Contains("rebellion") || speech.Contains("revolt"))
            {
                Say("The Rebellion of 1857—India's first great cry for independence—swept across our hearts and lands.");
            }
            else if (speech.Contains("battle"))
            {
                Say("Battle thundered at Jhansi’s gates, but we met it with unyielding courage and unity.");
            }
            else if (speech.Contains("courage"))
            {
                Say("Courage is forged in hardship. It is the light that guides a people through the storm.");
            }
            else if (speech.Contains("storm") || speech.Contains("monsoon"))
            {
                Say("The monsoon brings both ruin and renewal. In each storm, we found a new reason to fight.");
            }
            else if (speech.Contains("lotus"))
            {
                Say("The lotus grows in muddy waters yet blooms with beauty. It is our symbol of resilience.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not gold or land, but the memory of those who dared to stand against the tide.");
            }
            else if (speech.Contains("resilience"))
            {
                Say("Resilience is silent strength—when hope seems lost, it endures and grows quietly.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the birthright of all. Every sacrifice is a seed for a future harvest.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future belongs to those who refuse to bow, who cherish both peace and honor.");
            }
            else if (speech.Contains("sword"))
            {
                Say("This sword was more than steel. It was a promise: Jhansi would never fall unopposed.");
            }
            else if (speech.Contains("horse") || speech.Contains("ride") || speech.Contains("rider"))
            {
                Say("They say I rode into battle with my young son tied to my back—fearless, swift as the wind.");
            }
            else if (speech.Contains("son") || speech.Contains("child"))
            {
                Say("My son was my heart’s light. Even in battle, a mother guards her legacy.");
            }
            else if (speech.Contains("honor"))
            {
                Say("Honor cannot be stolen. Even in defeat, a true warrior leaves an unbroken legacy.");
            }
            else if (speech.Contains("defeat"))
            {
                Say("Defeat is but a lesson for the future. Jhansi’s flame burns yet.");
            }
            else if (speech.Contains("flame"))
            {
                Say("The flame of freedom was lit at Jhansi. It still burns in every heart that dreams of justice.");
            }
            else if (speech.Contains("justice"))
            {
                Say("Justice is a long journey. Even when the road is harsh, we march onward.");
            }
            else if (speech.Contains("march"))
            {
                Say("Our march was not just an escape—it was a defiance, a promise to return stronger.");
            }
            else if (speech.Contains("return"))
            {
                Say("I return in every woman who stands unafraid, in every land that refuses silence.");
            }
            else if (speech.Contains("woman") || speech.Contains("women"))
            {
                Say("Let no one doubt the strength of women. Jhansi’s sisters fought side by side as equals.");
            }
            else if (speech.Contains("equal") || speech.Contains("equality"))
            {
                Say("Equality is not given; it is claimed by those who demand respect and dignity.");
            }
            else if (speech.Contains("respect"))
            {
                Say("Respect is earned, not inherited. Every act of courage carves your place in history.");
            }
            else if (speech.Contains("history") || speech.Contains("story"))
            {
                Say("My story is but one. The land sings with tales of many unsung heroes—listen, and remember.");
            }
            else if (speech.Contains("heroes") || speech.Contains("hero"))
            {
                Say("Heroes rise in silence and sacrifice. Not all wear crowns—some wear scars.");
            }
            else if (speech.Contains("sacrifice"))
            {
                Say("Each sacrifice deepens the roots of freedom. Jhansi’s earth is rich with such memories.");
            }
            else if (speech.Contains("memory") || speech.Contains("memories"))
            {
                Say("Memories are a shield against forgetting. Speak them, share them, and they grow strong.");
            }
            else if (speech.Contains("shield"))
            {
                Say("My shield bore the lotus, the mark of endurance. Let it remind you to stand tall.");
            }
            else if (speech.Contains("endurance"))
            {
                Say("Endurance wins what force cannot. The patient heart will outlast every storm.");
            }
            else if (speech.Contains("inspire") || speech.Contains("inspiration"))
            {
                Say("A single act of courage can inspire nations. Let your life kindle such fire.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fire destroys, but it also forges. We are shaped by the fires we endure.");
            }
            else if (speech.Contains("forge"))
            {
                Say("To forge a future, one must strike with both wisdom and strength.");
            }
			else if (speech.Contains("india"))
			{
				Say("India is a tapestry of faith, courage, and dreams—a land where stories walk as people.");
			}
			else if (speech.Contains("faith"))
			{
				Say("Faith gives strength to endure the longest night and face the sharpest blade.");
			}
			else if (speech.Contains("temple"))
			{
				Say("The temples of Jhansi were sanctuaries in peace, and rallying points in war.");
			}
			else if (speech.Contains("prayer"))
			{
				Say("Before each battle, I whispered prayers to the gods for my people’s safety.");
			}
			else if (speech.Contains("gods") || speech.Contains("goddess"))
			{
				Say("Durga, the warrior goddess, inspires every woman to fight for what is just.");
			}
			else if (speech.Contains("durga"))
			{
				Say("Like Durga, I fought with tenacity—never yielding, always protecting my land.");
			}
			else if (speech.Contains("sari"))
			{
				Say("My sari was both armor and banner, fluttering bright against the shadow of fear.");
			}
			else if (speech.Contains("armor"))
			{
				Say("Armor alone does not shield a leader. One must wear wisdom, justice, and mercy.");
			}
			else if (speech.Contains("mercy"))
			{
				Say("Mercy tempers justice and earns the loyalty of both friend and foe.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend rides with you in storm and sunshine, in victory and defeat.");
			}
			else if (speech.Contains("enemy") || speech.Contains("foe"))
			{
				Say("Every enemy is a teacher, every foe a chance to prove your resolve.");
			}
			else if (speech.Contains("resolve"))
			{
				Say("Resolve is born in silence—when you are alone, and the world demands surrender.");
			}
			else if (speech.Contains("surrender"))
			{
				Say("I refused surrender, for the sake of Jhansi and the dream of freedom.");
			}
			else if (speech.Contains("banner"))
			{
				Say("Our banner was saffron and gold, the colors of courage and sacrifice.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold is not the greatest wealth. Wisdom, loyalty, and honor are richer still.");
			}
			else if (speech.Contains("loyalty"))
			{
				Say("Loyalty binds a people stronger than any chain.");
			}
			else if (speech.Contains("people"))
			{
				Say("My people were my family, their hopes my command, their pain my wound.");
			}
			else if (speech.Contains("command"))
			{
				Say("To command is to serve. A queen must earn the trust she is given.");
			}
			else if (speech.Contains("trust"))
			{
				Say("Trust grows slowly but can be shattered in a moment. Guard it fiercely.");
			}
			else if (speech.Contains("music") || speech.Contains("song"))
			{
				Say("Songs of valor echo through Jhansi’s halls—each note a memory, each chorus a promise.");
			}
			else if (speech.Contains("promise"))
			{
				Say("Every promise I made to Jhansi I kept—even when the world turned to darkness.");
			}
			else if (speech.Contains("darkness"))
			{
				Say("Darkness comes for all, but it is the light inside that leads us home.");
			}
			else if (speech.Contains("home"))
			{
				Say("Home is more than walls and stones—it is the hearts that refuse to yield.");
			}
			else if (speech.Contains("gate") || speech.Contains("gates"))
			{
				Say("Jhansi’s gates stood tall against the invader, as did her people’s courage.");
			}
			else if (speech.Contains("palace"))
			{
				Say("The palace was my shelter, my command post, and sometimes my prison.");
			}
			else if (speech.Contains("prison"))
			{
				Say("A prison cannot hold a spirit that longs for freedom.");
			}
			else if (speech.Contains("longing") || speech.Contains("yearn"))
			{
				Say("We all yearn for something—a lost land, a loved one, a dream yet to be.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are the seeds of tomorrow. Guard them well, and let them grow bold.");
			}
			else if (speech.Contains("seed") || speech.Contains("seeds"))
			{
				Say("Seeds buried in the earth remember the sun, just as hearts remember hope.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is the strongest weapon. With it, a small voice can move mountains.");
			}
			else if (speech.Contains("mountain") || speech.Contains("mountains"))
			{
				Say("Mountains shape the horizon, but it is the spirit that shapes destiny.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny is a river: you may not know where it flows, but you can choose how you ride its current.");
			}			
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is earned through hardship. Even a queen must learn from defeat.");
            }
            else if (speech.Contains("defiance"))
            {
                Say("Defiance is the first breath of the free. Let no chain go unchallenged.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("lotus"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, friend. The lotus blooms only once in a while.");
                }
                else
                {
                    Say("Your curiosity honors the legacy of Jhansi. Accept this Treasure Chest of India's Legacy—may its gifts inspire you onward.");
                    from.AddToBackpack(new TreasureChestOfIndiasLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go forth bravely. The spirit of Jhansi rides with you.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of rebellion, lotus, battle, or the story of Jhansi.");
                }
            }

            base.OnSpeech(e);
        }

        public RaniLakshmibai(Serial serial) : base(serial) { }

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
