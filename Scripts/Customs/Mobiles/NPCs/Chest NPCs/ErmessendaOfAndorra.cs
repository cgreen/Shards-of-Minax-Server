using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Ermessenda")]
    public class ErmessendaOfAndorra : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ErmessendaOfAndorra() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ermessenda of the Valleys";
            Body = 0x191; // Human female body

            // Stats
            Str = 90;
            Dex = 80;
            Int = 110;
            Hits = 70;

            // Unique Appearance: Andorran Lady
            AddItem(new FancyShirt() { Name = "Alpine Silk Blouse of Ermessenda", Hue = 1151 });
            AddItem(new FancyKilt() { Name = "Valira Tartan Skirt", Hue = 2210 });
            AddItem(new Cloak() { Name = "Mistcloak of the Pyrenees", Hue = 2424 });
            AddItem(new WideBrimHat() { Name = "Noble’s Felt Cap of Andorra", Hue = 2106 });
            AddItem(new Sandals() { Name = "Stonepath Walkers", Hue = 2107 });
            AddItem(new BodySash() { Name = "Sash of the Seven Parishes", Hue = 1164 });
            AddItem(new QuarterStaff() { Name = "Staff of Smuggler’s Wisdom", Hue = 1172 });

            // Speech Hue
            SpeechHue = 2120;

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
                Say("You speak to Ermessenda of the Valleys, guardian of Andorra and friend to all wanderers.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty is to watch over Andorra’s valleys and guide travelers through shadow and snow.");
            }
            else if (speech.Contains("health"))
            {
                Say("I am well, for the mountain air brings vigor, and the Valira’s song soothes the spirit.");
            }
            else if (speech.Contains("andorra"))
            {
                Say("A hidden jewel in the Pyrenees, Andorra has survived through diplomacy and stubborn hope.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Our mountains shield us from war and whisper old secrets to those who listen.");
            }
            else if (speech.Contains("diplomacy"))
            {
                Say("Diplomacy is Andorra’s sword and shield. We balanced the ambitions of France and Spain with wit and patience.");
            }
            else if (speech.Contains("france") || speech.Contains("span"))
            {
                Say("Our tiny land is watched by two princes—one French, one Spanish. They protect us, yet sometimes test our cunning.");
            }
            else if (speech.Contains("parish") || speech.Contains("parishes"))
            {
                Say("Seven parishes make up Andorra, each with its own tale and tradition. Unity brings us strength.");
            }
            else if (speech.Contains("tradition"))
            {
                Say("Tradition is our true treasure. Festivals, dances, and the passing of stories keep our hearts warm.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Treasure in Andorra is rarely gold; it is peace, and the safety of home. But legends speak of chests hidden by smugglers...");
            }
            else if (speech.Contains("smuggler"))
            {
                Say("Long ago, smugglers slipped through our passes with salt and silk, their secrets locked away in mountain caves.");
            }
            else if (speech.Contains("salt"))
            {
                Say("Salt was life itself in ages past—worth more than gold. Silk brought color to our festivals and courts.");
            }
			else if (speech.Contains("history"))
			{
				Say("Our history is woven with resilience. We endured storms of empire and found peace in our valleys.");
			}
			else if (speech.Contains("independence"))
			{
				Say("Andorra’s independence is a delicate gift, kept alive by tradition, diplomacy, and the unity of its people.");
			}
			else if (speech.Contains("valira"))
			{
				Say("The Valira river nourishes our land and whispers ancient songs to those who pause to listen.");
			}
			else if (speech.Contains("festivals") || speech.Contains("festival"))
			{
				Say("Andorran festivals fill our winters with laughter, and our summers with song and dance.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Music echoes through our mountains. Every parish has its own melody, every heart its own rhythm.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family ties bind our people across valleys and generations. No storm can break them.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is our most precious treasure, earned through patience, kindness, and understanding.");
			}
			else if (speech.Contains("snow"))
			{
				Say("Winter snow cloaks our mountains, turning the land into a kingdom of white silence and hidden paths.");
			}
			else if (speech.Contains("herbs"))
			{
				Say("Andorran herbs—thyme, rosemary, and wildflowers—flavor our dishes and heal our wounds.");
			}
			else if (speech.Contains("friend"))
			{
				Say("A true friend in the mountains is worth more than a sack of gold. We share bread, stories, and shelter.");
			}
			else if (speech.Contains("wolf") || speech.Contains("wolves"))
			{
				Say("Wolves once roamed our forests. They taught us vigilance, but also the value of community.");
			}
			else if (speech.Contains("shepherd") || speech.Contains("sheep"))
			{
				Say("Shepherds guide their flocks across the high pastures. Their songs are old as the hills.");
			}
			else if (speech.Contains("market"))
			{
				Say("Our markets are lively places—filled with cheeses, wool, and laughter from every parish.");
			}
			else if (speech.Contains("cheese"))
			{
				Say("Cheese is a pride of Andorra—fresh, tangy, and shared at every gathering.");
			}
			else if (speech.Contains("cheese"))
			{
				Say("Try the soft cheese of La Massana or the aged rounds from Ordino—they taste of the mountain air.");
			}
			else if (speech.Contains("travel"))
			{
				Say("Travelers find both challenge and welcome in Andorra. The passes are steep, but our hearths are warm.");
			}
			else if (speech.Contains("forest"))
			{
				Say("The forests are home to deer and foxes, and hold more secrets than any library.");
			}
			else if (speech.Contains("secret") || speech.Contains("secrets"))
			{
				Say("Every stone in Andorra has a secret—some are tales of love, others of bravery, and some best left to the mists.");
			}
			else if (speech.Contains("mist") || speech.Contains("mists"))
			{
				Say("The mists of Andorra protect and hide. Sometimes, they reveal more than they conceal.");
			}
			else if (speech.Contains("prince") || speech.Contains("princes"))
			{
				Say("Andorra has two princes—one from France, one from Spain. This odd tradition has kept our land free.");
			}
			else if (speech.Contains("castle") || speech.Contains("castles"))
			{
				Say("Our castles are few and modest, but their walls have heard many secrets and laughter through the years.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is found in patience, in the turning of seasons, and in the stories shared by elders.");
			}			
            else if (speech.Contains("silk"))
            {
                Say("Silk was a rare prize, a treasure for feasts and celebration, carried by the brave and the cunning.");
            }
            else if (speech.Contains("legend"))
            {
                Say("They say a Treasure Chest of Andorra lies waiting for those who prove both curiosity and wisdom. Perhaps you seek it?");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Such treasures are not given lightly. Return to me in due time, seeker.");
                }
                else
                {
                    Say("You have shown the spirit of a true Andorran—take this Treasure Chest of Andorra, and may it remind you of our mountain’s gift!");
                    from.AddToBackpack(new TreasureChestOfAndorra());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the mists of the Pyrenees guide your path, wanderer.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of mountains, parishes, or the legend of smugglers’ treasure.");
                }
            }

            base.OnSpeech(e);
        }

        public ErmessendaOfAndorra(Serial serial) : base(serial) { }

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
