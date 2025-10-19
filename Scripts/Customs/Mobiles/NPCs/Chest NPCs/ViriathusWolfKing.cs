using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Viriathus")]
    public class ViriathusWolfKing : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ViriathusWolfKing() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Viriathus, Wolf King of Lusitania";
            Body = 0x190; // Human male

            // Unique Appearance: Lusitanian Warrior King
            AddItem(new FurSarong() { Name = "Wolf Pelt of the Shepherd King", Hue = 1150 });
            AddItem(new WoodlandBelt() { Name = "Belt of Forest Spirits", Hue = 1765 });
            AddItem(new ElvenShirt() { Name = "Tunic of the Iberian Dawn", Hue = 1869 });
            AddItem(new GuildedKilt() { Name = "War-Kilt of Lusitania", Hue = 2525 });
            AddItem(new LeatherGloves() { Name = "Gloves of the Rebel Hunt", Hue = 2101 });
            AddItem(new FurBoots() { Name = "Boots of Mountain Shadows", Hue = 2002 });
            AddItem(new TribalMask() { Name = "Mask of the Ancient Wolf", Hue = 2400 });

            // Weapon: Spear
            AddItem(new Spear() { Name = "Spear of Viriathus", Hue = 2408 });

            // Speech Hue
            SpeechHue = 2118;

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
                Say("I am Viriathus, called the Wolf King, last free voice of Lusitania.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once a shepherd, I became the leader of free warriors, defying the Roman eagle.");
            }
            else if (speech.Contains("health"))
            {
                Say("Many wounds mark my body, but my spirit still runs wild as the wolves of the mountains.");
            }
            else if (speech.Contains("lusitania"))
            {
                Say("Lusitania is the wild land between rivers and stones, where freedom was once our birthright.");
            }
            else if (speech.Contains("rome") || speech.Contains("roman"))
            {
                Say("Rome sent many legions, but the forests and mountains favored my people. We fought as shadows.");
            }
            else if (speech.Contains("wolf"))
            {
                Say("They named me 'the Wolf' for my cunning and my howl in battle. Wolves honor loyalty, cunning, and freedom.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains are ancient allies. They hide rebels and whisper secrets to those who listen.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits"))
            {
                Say("The spirits of Lusitania are fierce and proud. They linger in the wind and in old stones.");
            }
            else if (speech.Contains("shepherd"))
            {
                Say("I herded sheep as a boy. The wolf and the shepherd share the land, sometimes as foes, sometimes as kin.");
            }
            else if (speech.Contains("resistance") || speech.Contains("rebellion"))
            {
                Say("Rebellion is the breath of the wild. Our hearts beat with the rhythm of drum and storm.");
            }
            else if (speech.Contains("betrayal") || speech.Contains("traitor"))
            {
                Say("It was betrayal, not battle, that ended my days. Yet a wolf’s memory lingers long in the pack.");
            }
            else if (speech.Contains("forest") || speech.Contains("woods"))
            {
                Say("The forest hides many things: warriors, secrets, and old gods alike.");
            }
            else if (speech.Contains("eagle"))
            {
                Say("The Roman eagle soars, but even the greatest bird fears the night and the cunning wolf.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is not a gift; it is a struggle. Each sunrise, we claimed it anew.");
            }
            else if (speech.Contains("dawn"))
            {
                Say("Dawn breaks red on Lusitania’s hills—red as the fires we lit in defiance.");
            }
            else if (speech.Contains("legend") || speech.Contains("legends"))
            {
                Say("Legends are born from truth and myth. Ask of my spear, the wolf, or the mountains to learn more.");
            }
            else if (speech.Contains("spear"))
            {
                Say("This spear tasted the blood of conquerors. Its iron remembers every battle.");
            }
            else if (speech.Contains("pack"))
            {
                Say("A lone wolf can survive, but a pack can drive off even eagles. My warriors were my pack.");
            }
            else if (speech.Contains("cunning"))
            {
                Say("Victory favors the cunning. In war, the silent foot and sudden leap win the day.");
            }
            else if (speech.Contains("gods"))
            {
                Say("Our gods walk the wilds still. Some say they guide lost souls back to freedom.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is the blood in my veins. Even in death, I guard it for my people.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is not stone or gold—it is the stubborn hope that refuses to kneel.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is the last arrow in the quiver. Guard it well.");
            }
            else if (speech.Contains("ancient"))
            {
                Say("We are ancient, as the mountains. Many tried to erase us, but the wild remembers.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is a river; sometimes gentle, sometimes wild. Drink from it, and learn.");
            }
			else if (speech.Contains("river") || speech.Contains("tagus"))
			{
				Say("The Tagus flows golden through Lusitania, carrying secrets from the mountains to the sea. Many have tried to claim it, but its song is forever wild.");
			}
			else if (speech.Contains("sea"))
			{
				Say("The sea is the end and the beginning. My people once looked west and saw the land of dreams, beyond the reach of Rome.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("Dreams are where warriors meet old gods. Some say I walk there still, guiding those who refuse to bow.");
			}
			else if (speech.Contains("iron"))
			{
				Say("Iron is cold, but the heart behind it must burn hot. Our spears were iron, yet it was courage that broke legions.");
			}
			else if (speech.Contains("songs") || speech.Contains("song"))
			{
				Say("Our bards remember what stone forgets. Ask them of eagles, of wolves, or of the flames of freedom.");
			}
			else if (speech.Contains("bard") || speech.Contains("bards"))
			{
				Say("A bard's word is a blade of memory. To be sung about is to never truly die.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun kissed our land each morning. It gives life, but also reveals the shadows of those who hunt us.");
			}
			else if (speech.Contains("hunt") || speech.Contains("hunter"))
			{
				Say("The Romans called us hunters. But we were hunted, too, by traitors and by fate.");
			}
			else if (speech.Contains("fate"))
			{
				Say("Fate winds like a forest path: tangled, shadowed, and unknown. Some make their own trail, wolf-like.");
			}
			else if (speech.Contains("ally") || speech.Contains("allies"))
			{
				Say("We found allies among other tribes—some faithful, some as wild and unpredictable as the hills.");
			}
			else if (speech.Contains("tribe") || speech.Contains("tribes"))
			{
				Say("Many tribes shared Lusitania: Vettones, Turduli, and others. Together we stood, or fell, as the mountains demanded.");
			}
			else if (speech.Contains("blood"))
			{
				Say("Blood spilled for freedom blesses the land. Mine stains these hills still, beneath stone and heather.");
			}
			else if (speech.Contains("heather"))
			{
				Say("Heather cloaks our graves in purple and gold. In spring, even the Romans paused to marvel at its beauty.");
			}
			else if (speech.Contains("cloak"))
			{
				Say("This cloak was once a gift from my mother. It held warmth against the night, and courage against fear.");
			}
			else if (speech.Contains("mother"))
			{
				Say("My mother taught me to run with the wind, and to listen for danger in the silence.");
			}
			else if (speech.Contains("silence"))
			{
				Say("In silence, the forest speaks. In silence, the wolf plans. Never fear silence—it is full of meaning.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is a rare guest. When she visits, cherish her. But never forget the path to war.");
			}
			else if (speech.Contains("death"))
			{
				Say("Death stalks every path. To meet it with open eyes is to be truly free.");
			}
			else if (speech.Contains("friend"))
			{
				Say("Friendship is forged in hardship, not in comfort. Are you a friend of the wild, or just a passing shadow?");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("Shadows hide both danger and hope. My warriors moved like shadows—seen only when we chose to be.");
			}			
            else if (speech.Contains("fire"))
            {
                Say("Our fires burned bright at night—signals to friend and warning to foe.");
            }
            else if (speech.Contains("enemy"))
            {
                Say("An enemy is not always a stranger. Sometimes, the foe sits beside the fire.");
            }
            // *** SECRET REWARD KEYWORD BELOW ***
            else if (speech.Contains("howl"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the wolves must rest between hunts. Return after the moon rises again.");
                }
                else
                {
                    Say("Your spirit honors the wild. Take this Treasure Chest of Lusitanian Legends—may your story echo like a wolf’s howl across the ages.");
                    from.AddToBackpack(new TreasureChestOfLusitanianLegends());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with the wild winds of Lusitania, friend.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of wolves, Rome, the spear, or the howl that echoes at dusk.");
                }
            }

            base.OnSpeech(e);
        }

        public ViriathusWolfKing(Serial serial) : base(serial) { }

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
