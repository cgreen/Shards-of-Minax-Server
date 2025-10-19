using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Harald Hardrada")]
    public class HaraldHardrada : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public HaraldHardrada() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Harald Hardrada";
            Title = "the Last Viking King";
            Body = 0x190; // Human male

            // Stats
            Str = 100;
            Dex = 85;
            Int = 90;
            Hits = 100;

            // Unique Legendary Viking King Outfit
            AddItem(new ElvenShirt() { Name = "Royal Tunic of the North", Hue = 1157 });
            AddItem(new GuildedKilt() { Name = "King's Battle Kilt", Hue = 1175 });
            AddItem(new Cloak() { Name = "Wolfskin Cloak of Stamford", Hue = 1109 });
            AddItem(new WingedHelm() { Name = "Helm of Ravens", Hue = 2407 });
            AddItem(new FurBoots() { Name = "Boots of the Fjord", Hue = 2413 });
            AddItem(new BodySash() { Name = "Oathkeeper's Sash", Hue = 1167 });

            // Weapon: DoubleAxe (legendary Norse weapon)
            AddItem(new DoubleAxe() { Name = "Viking King's War Axe", Hue = 2101 });

            // Armor: PlateArms, symbolic of royal armor
            AddItem(new PlateArms() { Name = "Royal Steel Bracers", Hue = 1150 });

            SpeechHue = 2117;
            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            // Starter keywords
            if (speech.Contains("name"))
            {
                Say("I am Harald Sigurdsson, called Hardrada—the stern, the unyielding. I was King of Norway and wanderer of many realms.");
            }
            else if (speech.Contains("job"))
            {
                Say("I was king, warlord, poet, and traveler. The last to hold the Viking spirit in my hand, before the old ways faded.");
            }
            else if (speech.Contains("health"))
            {
                Say("The sword marked my flesh, but the saga endures. A king's life is seldom long—and never dull.");
            }
            // Major lore
            else if (speech.Contains("norway"))
            {
                Say("Norway is a land of fjords, storms, and proud hearts. My kingdom, carved by axe and ambition.");
            }
            else if (speech.Contains("king"))
            {
                Say("I ruled Norway with fire and iron. Yet a true king also travels—have you heard of Miklagard?");
            }
            else if (speech.Contains("miklagard") || speech.Contains("constantinople"))
            {
                Say("Miklagard—Constantinople—was the greatest city of the east. I served there as a Varangian guard, wielding axe and oath alike.");
            }
            else if (speech.Contains("varangian"))
            {
                Say("The Varangian Guard were Norse warriors sworn to the Byzantine Emperor. We were called 'axe-bearers from the north'.");
            }
            else if (speech.Contains("viking"))
            {
                Say("To be a Viking is to live boldly—sailing where the sea dares and writing one’s own saga.");
            }
            else if (speech.Contains("saga"))
            {
                Say("A saga is more than a story. It is a chain of memory, linking the living to the dead.");
            }
            else if (speech.Contains("youth") || speech.Contains("young"))
            {
                Say("In my youth, I fought at Stiklestad. I was exiled, wandering the world in search of glory.");
            }
            else if (speech.Contains("stamford") || speech.Contains("bridge"))
            {
                Say("The Battle of Stamford Bridge was my final stand—a Viking king's end, far from home. Yet honor travels beyond death.");
            }
            else if (speech.Contains("battle"))
            {
                Say("I have seen battles in many lands. Each one is remembered by blood and by those who survive to sing.");
            }
            else if (speech.Contains("poet") || speech.Contains("poetry"))
            {
                Say("Kings must have more than strength. I wove words as keen as swords—would you hear a verse?");
            }
            else if (speech.Contains("verse") || speech.Contains("song"))
            {
                Say("Steel is strong, but song endures. 'Better to stand and fight. If you run, you'll only die tired.'");
            }
            else if (speech.Contains("axe"))
            {
                Say("My axe carved new destinies. In Miklagard, they called me 'The Thunder of the North'.");
            }
            else if (speech.Contains("raven"))
            {
                Say("The raven is Odin's bird—winged omen on the battlefield. Ravens feasted at Stamford, as in old sagas.");
            }
            else if (speech.Contains("odin"))
            {
                Say("Odin, the Allfather, watches over warriors and poets alike. Some say he chooses who survives the fray.");
            }
            else if (speech.Contains("valhalla"))
            {
                Say("Valhalla is the hall of the fallen. There, warriors feast and fight anew, beneath Odin’s gaze.");
            }
            else if (speech.Contains("feast"))
            {
                Say("A true Viking feast is roast boar, sweet mead, and stories echoing through firelit halls.");
            }
            else if (speech.Contains("mead"))
            {
                Say("Mead sweetens both victory and defeat. In Valhalla, the cups never empty.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not gold nor land, but the tales told when you are gone. Seek to earn a place in memory.");
            }
            else if (speech.Contains("fjord"))
            {
                Say("The fjords of Norway are deep and mysterious. Some say treasures are hidden where the mist meets the water.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Not all treasure is silver. Some lies buried in legend, or in the courage to seek what others fear.");
            }
            else if (speech.Contains("wanderer") || speech.Contains("traveler"))
            {
                Say("I wandered from the cold north to the golden halls of Byzantium. Adventure is a king’s true inheritance.");
            }
            else if (speech.Contains("byzantine"))
            {
                Say("The Byzantines valued loyalty and steel. Their walls have seen more wars than any northern fortress.");
            }
            else if (speech.Contains("shield"))
            {
                Say("A shield is a friend that never betrays. Mine bore the wolf’s head—symbol of unbroken spirit.");
            }
            else if (speech.Contains("wolf"))
            {
                Say("The wolf runs alone, yet never forgets its pack. So, too, does a king rely on loyal friends.");
            }
            else if (speech.Contains("storm"))
            {
                Say("Norway’s storms forge strong hearts. Only fools curse the wind—instead, I learned to sail with it.");
            }
            else if (speech.Contains("north"))
            {
                Say("The North shapes all who call it home. Cold steel, colder seas, but the warmest of welcomes by the fire.");
            }
            else if (speech.Contains("fire"))
            {
                Say("Fires warm and fires burn. In every saga, the fire is both beginning and end.");
            }
            else if (speech.Contains("sword"))
            {
                Say("A king’s sword is never idle, nor his word lightly given.");
            }
			else if (speech.Contains("family"))
			{
				Say("My father was Sigurd Syr, a wise king in the east, and my half-brother was Saint Olaf. Our blood runs with old Norway's legacy.");
			}
			else if (speech.Contains("saint olaf") || speech.Contains("olaf"))
			{
				Say("Saint Olaf fell at Stiklestad, fighting for the Christian faith. His death changed Norway forever—and sent me into exile.");
			}
			else if (speech.Contains("exile"))
			{
				Say("Exile taught me cunning and patience. I served foreign kings, waiting for the day to reclaim my birthright.");
			}
			else if (speech.Contains("byzantium"))
			{
				Say("Byzantium was a world of gold and secrets. The Emperor trusted the Varangians to guard his throne—sometimes from his own kin.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold flows in rivers in the south, but it cannot buy honor—or silence the old songs in your heart.");
			}
			else if (speech.Contains("honor"))
			{
				Say("Honor is not just for kings. It’s how you treat friend and foe, in the mead hall or on the field of war.");
			}
			else if (speech.Contains("enemy") || speech.Contains("foe"))
			{
				Say("A wise king studies his enemy, but never lets hatred cloud his mind. Sometimes, today's foe becomes tomorrow's ally.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A friend by your side is better than ten swords. I would trust a Varangian comrade with my life—and often did.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("What we leave behind is not silver or land, but the memories people tell and retell long after we are gone.");
			}
			else if (speech.Contains("north star"))
			{
				Say("The North Star never falters. On sea or land, follow its light, and you'll find your way home.");
			}
			else if (speech.Contains("longship"))
			{
				Say("Longships are the wings of the sea. They brought Norsemen to England, Byzantium, even distant Vinland.");
			}
			else if (speech.Contains("vinland"))
			{
				Say("Vinland lies far to the west, across a wild sea. Some say Leif Erikson walked its shores before any king of Norway.");
			}
			else if (speech.Contains("storm"))
			{
				Say("I have sailed through storms fierce enough to frighten even the bravest heart. Storms pass, but courage endures.");
			}
			else if (speech.Contains("courage"))
			{
				Say("Courage is facing what must be done, even when fear howls louder than any wind.");
			}
			else if (speech.Contains("feud"))
			{
				Say("Feuds run deep in Norway. Better to end them with wise words or a firm hand—else the land remembers every wrong.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Even a king seeks peace, if only by winning respect. The best peace is one carved with wisdom, not just steel.");
			}
			else if (speech.Contains("queen"))
			{
				Say("My queen, Elisiv of Kiev, stood by me in storm and calm. Through her, my line reached both east and north.");
			}
			else if (speech.Contains("kiev"))
			{
				Say("Kiev is a city of splendor on the river Dnieper. I saw its towers rise on my journeys, and its people were fierce and free.");
			}
			else if (speech.Contains("runestone") || speech.Contains("runes"))
			{
				Say("Runestones tell our deeds in words that last longer than flesh. Carve your name in courage, not just stone.");
			}
			else if (speech.Contains("ghost") || speech.Contains("ghosts"))
			{
				Say("Ghosts haunt the old places—battlefields, lonely fjords, and sometimes, a king’s own dreams.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("A true Viking dreams with eyes wide open, always searching for the next shore, the next saga.");
			}
			else if (speech.Contains("shield wall") || speech.Contains("shieldwall"))
			{
				Say("The shield wall is strength in unity—each warrior guarding the next. Alone, a shield is small; together, unbreakable.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Every man must face his destiny. Some run; some fight; a few, like me, carve it into legend.");
			}
			else if (speech.Contains("legend"))
			{
				Say("They say a man becomes a legend only after he is gone. Until then, he is but a seeker and a storyteller.");
			}			
            else if (speech.Contains("end") || speech.Contains("death"))
            {
                Say("Death comes for kings and peasants alike. What matters is the story you leave behind.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("mist"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the keenest seeker must wait for the mist to rise again. Patience is a virtue in the north.");
                }
                else
                {
                    Say("You have seen through the mists—take this Treasure Chest of Norway, and let its contents stir your own saga.");
                    from.AddToBackpack(new TreasureChestOfNorway());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            // Farewell
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May Odin’s ravens watch your path, and the northern lights guide you home.");
            }
            // Random nudge for lost players
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Miklagard, the Varangians, the fjords, or the wolf’s head upon my shield.");
                }
            }

            base.OnSpeech(e);
        }

        public HaraldHardrada(Serial serial) : base(serial) { }

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
