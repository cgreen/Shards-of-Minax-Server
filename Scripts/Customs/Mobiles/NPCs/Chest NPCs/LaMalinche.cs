using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of La Malinche")]
    public class LaMalinche : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public LaMalinche() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "La Malinche";
            Body = 0x191; // Human female body

            // Unique Appearance: The Bridge Between Worlds
            AddItem(new FloweredDress() { Name = "Dress of Xochitl's Grace", Hue = 2125 });
            AddItem(new BodySash() { Name = "Sash of Dual Worlds", Hue = 1270 });
            AddItem(new FeatheredHat() { Name = "Huipil of Feathers and Shells", Hue = 2427 });
            AddItem(new Sandals() { Name = "Sandals of the Pilgrim", Hue = 2405 });
            AddItem(new Cloak() { Name = "Cloak of Whispers", Hue = 1109 });
            AddItem(new FlowerGarland() { Name = "Crown of the New Sun", Hue = 34 });
            AddItem(new Kama() { Name = "Sickle of Harvest and Change", Hue = 1182 });

            SpeechHue = 2124;
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
                Say("I was called Malinalli, then Marina, but the world knows me as La Malinche.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some say I was a slave, some a princess, but I became the bridge between two worlds.");
            }
            else if (speech.Contains("health"))
            {
                Say("My heart is heavy with memories, yet my voice endures, whispering in forgotten tongues.");
            }
            else if (speech.Contains("bridge"))
            {
                Say("I was the bridge—between peoples, between gods and men. A path few choose, and none travel unchanged.");
            }
            else if (speech.Contains("tongue"))
            {
                Say("With my tongue, I carried the words of empires. Words can build or break worlds.");
            }
            else if (speech.Contains("cortes"))
            {
                Say("Hernán Cortés saw me as a key, not a person. But every key can lock or unlock a thousand fates.");
            }
            else if (speech.Contains("empire"))
            {
                Say("The Aztec Empire stood proud and vast, but empires rise and fall like the sun.");
            }
            else if (speech.Contains("betrayal"))
            {
                Say("Some call me traitor, some call me survivor. Truth is a river with many currents.");
            }
            else if (speech.Contains("gods"))
            {
                Say("The old gods watched as new faces arrived. Sometimes, gods speak in silence and in stone.");
            }
            else if (speech.Contains("languages") || speech.Contains("language"))
            {
                Say("I spoke Nahuatl, Maya, and the language of dreams. Each tongue a mask, each word a knife or balm.");
            }
            else if (speech.Contains("memory"))
            {
                Say("Memory is a garden of both flowers and thorns. To remember is to honor, and sometimes to hurt.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My legacy is written in shadows and whispers, but some stories are carved deeper than others—some in the very stones. Seek the glyphs if you wish to understand.");
            }
            else if (speech.Contains("glyph") || speech.Contains("glyphs"))
            {
                // SECRET REWARD LOGIC
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("The stones remember, but they do not repeat their secrets so soon. Return when the sun is higher.");
                }
                else
                {
                    Say("You have seen beyond words, to the silent truth. Accept this Treasure Chest of Mexico's Legacy—may it guide your journey.");
                    from.AddToBackpack(new TreasureChestOfMexicosLegacy());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("aztec"))
            {
                Say("The Aztecs called themselves Mexica. Their temples touched the sky and their hearts beat with both pride and dread.");
            }
            else if (speech.Contains("princess"))
            {
                Say("Once, I was daughter to a noble house. Fate scattered my roots far from home, but I grew new branches.");
            }
			else if (speech.Contains("child"))
			{
				Say("My son bore the blood of both conqueror and conquered. They called him Martín—the first of a new people, caught between worlds.");
			}
			else if (speech.Contains("mother"))
			{
				Say("A mother holds many secrets—sorrow, hope, and the wish that her children find a gentler world than hers.");
			}
			else if (speech.Contains("nahuatl"))
			{
				Say("Nahuatl, the language of my ancestors, still lives on the wind. In its syllables are echoes of ancient songs.");
			}
			else if (speech.Contains("maya"))
			{
				Say("Maya words shaped my childhood. Every language I learned was a gift and a burden.");
			}
			else if (speech.Contains("teotl") || speech.Contains("spirit"))
			{
				Say("Teotl is the breath within all things—mountain, river, flame, and heart. Even the stones listen.");
			}
			else if (speech.Contains("tlatoani") || speech.Contains("emperor"))
			{
				Say("The tlatoani stood atop great pyramids, speaking for gods and people alike. But no voice is truly alone.");
			}
			else if (speech.Contains("pyramid") || speech.Contains("temple"))
			{
				Say("The pyramids rise from the earth, their shadows stretching across time. They remember what we forget.");
			}
			else if (speech.Contains("storm"))
			{
				Say("Storms swept through Tenochtitlán the year the strangers came—some saw it as an omen, others as a warning unheeded.");
			}
			else if (speech.Contains("tears"))
			{
				Say("The conquest brought rivers of tears. Yet, as with rain, new life sometimes grows in the mud of sorrow.");
			}
			else if (speech.Contains("gold"))
			{
				Say("Gold dazzled the newcomers, but they did not understand its true worth. To us, it was the sweat of the sun, not a measure of power.");
			}
			else if (speech.Contains("tenochtitlan"))
			{
				Say("Tenochtitlán was a city of water and stone, a mirror of the heavens. Its ruins whisper at night, if you care to listen.");
			}
			else if (speech.Contains("song") || speech.Contains("music"))
			{
				Say("Our music wove together joy and longing. Even now, if you listen, the wind carries those old melodies.");
			}
			else if (speech.Contains("mask"))
			{
				Say("We all wear masks—some woven of cloth, others of duty. Sometimes it is hard to remember which face is truly yours.");
			}
			else if (speech.Contains("shadow") || speech.Contains("shadows"))
			{
				Say("The past is a long shadow. Some run from it; I choose to walk beside mine, and learn its lessons.");
			}
			else if (speech.Contains("choice") || speech.Contains("choices"))
			{
				Say("Every choice is a seed. Some grow into trees, others into thorns. We rarely see what our seeds will become.");
			}
			else if (speech.Contains("river"))
			{
				Say("Rivers remember every footstep along their banks. They carry stories as surely as they carry water.");
			}
			else if (speech.Contains("trade") || speech.Contains("trader"))
			{
				Say("Traders once brought cacao, feathers, and obsidian across these lands—more precious than gold, for they wove us together.");
			}
			else if (speech.Contains("forbidden"))
			{
				Say("Much was forbidden to me—yet, like the serpent in the garden, I found ways to move unseen and unheard.");
			}			
            else if (speech.Contains("slave"))
            {
                Say("Chains can be of iron, but also of fear. I broke one, but not always the other.");
            }
            else if (speech.Contains("fate"))
            {
                Say("Fate weaves its threads through all stories. Some knots can be untied, others become destiny.");
            }
            else if (speech.Contains("destiny"))
            {
                Say("To choose is to shape destiny. Even the smallest voice can echo through centuries.");
            }
            else if (speech.Contains("flower") || speech.Contains("flowers"))
            {
                Say("Flowers wither, but their seeds return. So it is with memory and forgiveness.");
            }
            else if (speech.Contains("forgive") || speech.Contains("forgiveness"))
            {
                Say("Forgiveness is a river—difficult to cross, yet it nourishes both shores.");
            }
            else if (speech.Contains("history"))
            {
                Say("History is a mask. Those who write it decide who is monster and who is martyr.");
            }
            else if (speech.Contains("calendar"))
            {
                Say("The great stone calendar remembers more than days—it remembers hopes, omens, and the paths not taken.");
            }
            else if (speech.Contains("omen") || speech.Contains("omens"))
            {
                Say("Some say omens foretold the end of an age. I say each day carries its own sign.");
            }
            else if (speech.Contains("sun"))
            {
                Say("The sun rises on new worlds. What will you do beneath its gaze?");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Travel well, and may the rivers of time be kind to your memory.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of empire, Cortés, betrayal, or the silent language of the glyphs.");
                }
            }

            base.OnSpeech(e);
        }

        public LaMalinche(Serial serial) : base(serial) { }

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
