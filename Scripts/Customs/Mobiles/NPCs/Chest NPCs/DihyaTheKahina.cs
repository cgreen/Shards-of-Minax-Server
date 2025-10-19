using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Dihya")]
    public class DihyaTheKahina : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public DihyaTheKahina() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Dihya, the Kahina";
            Body = 0x191; // Human female body

            // Unique Appearance
            AddItem(new Tunic() { Name = "Desert Queen's Silken Tunic", Hue = 2428 });
            AddItem(new FancyKilt() { Name = "Sandswept War-Kilt of the Kahina", Hue = 2213 });
            AddItem(new Cloak() { Name = "Veil of the Infinite Horizon", Hue = 1153 });
            AddItem(new Bandana() { Name = "Crown of the Aures", Hue = 1178 });
            AddItem(new Sandals() { Name = "Wayfarer's Dawn Sandals", Hue = 2401 });
            AddItem(new BodySash() { Name = "Sash of Berber Defiance", Hue = 2105 });

            AddItem(new Scimitar() { Name = "Blade of the Dihyan Oracle", Hue = 1176 });

            SpeechHue = 2119;

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
                Say("I am Dihya, last queen of the Dihyans. Some called me the Kahina—seer, leader, mother of the sands.");
            }
            else if (speech.Contains("job"))
            {
                Say("I defended the Berber tribes against invaders, weaving the fates of desert and mountain together.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit outlives every wound. The desert does not yield, nor do I.");
            }
            else if (speech.Contains("queen"))
            {
                Say("Queen not only by blood, but by battle. My crown was forged in struggle and shadow.");
            }
            else if (speech.Contains("berber"))
            {
                Say("We are the Imazighen—free people—whose stories ride the winds from Atlas to Sahara.");
            }
            else if (speech.Contains("desert"))
            {
                Say("The desert is both sword and shield—cruel to the careless, but gentle to those who remember its secrets.");
            }
            else if (speech.Contains("history"))
            {
                Say("The tales of my people are written in wind and sand. Ask of ancestors, prophecy, or freedom.");
            }
            else if (speech.Contains("prophecy"))
            {
                Say("Prophecy is a mirror. It shows us what we fear, and sometimes what we must become.");
            }
            else if (speech.Contains("ancestors"))
            {
                Say("The voices of the ancestors whisper in every storm. Listen close, and you may learn survival.");
            }
            else if (speech.Contains("sand"))
            {
                Say("Sand preserves, sand buries. What you lose in the desert, the wind remembers.");
            }
            else if (speech.Contains("aures"))
            {
                Say("The Aurès mountains cradle my homeland—a fortress of stone and wild olive trees.");
            }
            else if (speech.Contains("enemy"))
            {
                Say("Enemies come like locusts, but are driven off by flame and unity.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future is a journey across shifting dunes. Every footstep matters.");
            }
            else if (speech.Contains("oracle"))
            {
                Say("Some called me an oracle, but I only speak what the land has taught me.");
            }
            else if (speech.Contains("river"))
            {
                Say("Rivers in the desert are rare and precious, just as hope is.");
            }
            else if (speech.Contains("secret"))
            {
                Say("Secrets keep us safe, but shared with honor, they become legacy.");
            }
            else if (speech.Contains("battle"))
            {
                Say("Battle teaches more than victory; defeat carves the truest lessons.");
            }
            else if (speech.Contains("flame"))
            {
                Say("Flame in the desert is both a danger and a beacon. It draws both friend and foe.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a promise, made in every sunrise and kept by those who refuse to kneel.");
            }
            else if (speech.Contains("shadow"))
            {
                Say("Every queen has walked with shadows. Mine shaped me as much as sunlight.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is the true map of the desert. Without it, all wanderers are lost.");
            }
            else if (speech.Contains("horizon"))
            {
                Say("The horizon is both end and beginning. Follow it long enough, and you may find an oasis.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Wisdom is water: seek it, share it, guard it against those who would waste it.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not gold or land, but the courage to endure and the hope you leave behind.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Mountains teach patience and pride. They outlast even the greatest armies.");
            }
			else if (speech.Contains("kahina"))
			{
				Say("They called me Kahina, meaning 'seer' or 'priestess.' My visions came not from magic, but from seeing my people’s suffering.");
			}
			else if (speech.Contains("invader") || speech.Contains("invaders"))
			{
				Say("Invaders see the desert as empty. Only those who love it truly understand its strength.");
			}
			else if (speech.Contains("sahara"))
			{
				Say("The Sahara is endless, both a cradle and a grave. Every grain of sand holds an untold story.");
			}
			else if (speech.Contains("mirage"))
			{
				Say("A mirage is hope and warning. Not everything beautiful is real—yet sometimes, dreams guide us to truth.");
			}
			else if (speech.Contains("song") || speech.Contains("songs"))
			{
				Say("We sing to remember. Our songs carry the scent of cedar, the taste of salt, and the laughter of ancestors.");
			}
			else if (speech.Contains("olive"))
			{
				Say("The wild olive tree endures drought and storm. Its roots run as deep as the memory of my people.");
			}
			else if (speech.Contains("storm"))
			{
				Say("A desert storm can erase footprints and kingdoms alike. Only what is cherished survives.");
			}
			else if (speech.Contains("market"))
			{
				Say("The market is the heart of every city. Spices, colors, laughter, and secrets pass from hand to hand.");
			}
			else if (speech.Contains("veil"))
			{
				Say("A veil hides and reveals. Sometimes, mystery is its own form of strength.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("An oracle listens as much as she speaks. Even silence holds prophecy.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is a blade: it can free or wound. Best to wield it with wisdom.");
			}
			else if (speech.Contains("camel"))
			{
				Say("A camel is the ship of the desert. Loyal and tireless, it teaches patience and endurance.");
			}
			else if (speech.Contains("date"))
			{
				Say("Dates are sweet gifts from the palm. In lean years, their memory is enough to keep hope alive.");
			}
			else if (speech.Contains("night"))
			{
				Say("The desert night is full of stories. Stars guide the lost home, and shadows whisper secrets.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("Stars are the ancestors' eyes, watching over travelers who cross the dunes.");
			}
			else if (speech.Contains("sister") || speech.Contains("brother"))
			{
				Say("Sisters and brothers—by blood or by oath—are the pillars of our house. Protect them well.");
			}
			else if (speech.Contains("olive"))
			{
				Say("The wild olive tree endures drought and storm. Its roots run as deep as the memory of my people.");
			}
			else if (speech.Contains("atlas"))
			{
				Say("The Atlas mountains are both shield and boundary. Their snow feeds distant rivers and distant dreams.");
			}
			else if (speech.Contains("lion"))
			{
				Say("Once, the Barbary lion walked these lands—fierce and noble, like our greatest chiefs.");
			}
			else if (speech.Contains("dune") || speech.Contains("dunes"))
			{
				Say("Dunes shift with the wind, but the spirit of the desert endures. Change is not always loss.");
			}
			else if (speech.Contains("journey"))
			{
				Say("Every journey begins with uncertainty and ends with wisdom, if one survives the distance.");
			}
			else if (speech.Contains("blessing"))
			{
				Say("A true blessing is shade at noon, water at dusk, and friendship that endures the storm.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is as rare as water in the desert, but more precious than gold.");
			}			
            else if (speech.Contains("family"))
            {
                Say("Family is shelter against the storm. Even when scattered, our roots reach deep.");
            }
            else if (speech.Contains("victory"))
            {
                Say("Victory is sweet, but survival is sacred.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the oasis at the edge of exhaustion. Hold it tight, and you will endure.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fire can destroy, but it also lights the night and keeps fear at bay.");
            }
            // SECRET REWARD KEYWORD
            else if (speech.Contains("oasis"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience. Even the deepest oasis cannot be visited too often.");
                }
                else
                {
                    Say("You have found the heart of the desert. Take this Treasure Chest of Dihya—may its mysteries sustain your journey.");
                    from.AddToBackpack(new TreasureChestOfDihya());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Walk with the wind and remember: even a single flame can hold back the night.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of prophecy, the Aurès, memory, or the hidden oases of my homeland.");
                }
            }

            base.OnSpeech(e);
        }

        public DihyaTheKahina(Serial serial) : base(serial) { }

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
