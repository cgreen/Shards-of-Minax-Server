using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Te Rauparaha")]
    public class TeRauparaha : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TeRauparaha() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Te Rauparaha";
            Body = 0x190; // Human male

            // Unique Appearance: Māori Chief
            AddItem(new ElvenShirt() { Name = "Korowai of Leadership", Hue = 2009 }); // dark flaxen
            AddItem(new FancyKilt() { Name = "Woven Piupiu Kilt", Hue = 2956 }); // flax-green
            AddItem(new Cloak() { Name = "Feathered Cloak of Mana", Hue = 1195 }); // deep blue
            AddItem(new TribalMask() { Name = "Ta Moko Mask of Ngāti Toa", Hue = 2428 }); // obsidian black
            AddItem(new FurBoots() { Name = "Boots of Aotearoa", Hue = 2502 }); // earthy brown
            AddItem(new BodySash() { Name = "Sash of the Haka", Hue = 1405 }); // bone white

            // Weapon: Taiaha (using QuarterStaff as base)
            AddItem(new QuarterStaff() { Name = "Taiaha of Chiefs", Hue = 1365 }); // rich red-brown

            SpeechHue = 1161; // green-blue, for the sea

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
                Say("I am Te Rauparaha, chief of Ngāti Toa, and my name is both feared and sung across Aotearoa.");
            }
            else if (speech.Contains("job"))
            {
                Say("Some call me a war chief, some a poet. I am a survivor, a voyager, and a keeper of my people’s mana.");
            }
            else if (speech.Contains("health"))
            {
                Say("Though storms and battles have left their scars, my spirit is unbroken, like the land itself.");
            }
            else if (speech.Contains("ngati toa") || speech.Contains("ngāti toa") || speech.Contains("toa"))
            {
                Say("Ngāti Toa are my iwi, my kin, who journeyed with me from Kawhia to Kapiti. Our story is carved on the land.");
            }
            else if (speech.Contains("haka"))
            {
                Say("Ka Mate! Ka Mate! I composed that haka when danger shadowed me. It is a song of life over death—would you hear its story?");
            }
            else if (speech.Contains("ka mate"))
            {
                Say("Hiding in the darkness, I spoke: 'Ka Mate! Ka Mate! Ka Ora! Ka Ora!' It is our haka, our heartbeat, known even across the seas.");
            }
            else if (speech.Contains("mana"))
            {
                Say("Mana is the breath of dignity. It cannot be taken—only earned, upheld, and remembered.");
            }
            else if (speech.Contains("aotearoa") || speech.Contains("new zealand"))
            {
                Say("Aotearoa—the land of the long white cloud. From snow-capped mountains to restless sea, she remembers all stories.");
            }
            else if (speech.Contains("voyager") || speech.Contains("voyage") || speech.Contains("canoe"))
            {
                Say("Our ancestors crossed the great ocean in waka, guided by stars and courage. The sea is in our blood.");
            }
            else if (speech.Contains("battle") || speech.Contains("war"))
            {
                Say("I have seen many battles—against rival iwi, and against muskets and ships of the newcomers. Each left its mark.");
            }
            else if (speech.Contains("poet") || speech.Contains("song"))
            {
                Say("The greatest weapon is not always the taiaha, but a song that endures. My haka travels farther than any spear.");
            }
            else if (speech.Contains("chief"))
            {
                Say("To be a chief is to carry both burden and honor. The wellbeing of my people is always first.");
            }
            else if (speech.Contains("kapiti"))
            {
                Say("Kapiti Island became our fortress—a place of strength, and a home for my people after our long migrations.");
            }
            else if (speech.Contains("migration") || speech.Contains("kawhia"))
            {
                Say("Driven from Kawhia, we journeyed south. Hardship became legend; our footsteps, the road for generations.");
            }
            else if (speech.Contains("musket"))
            {
                Say("The musket changed everything. Friendships and feuds, old and new, were reshaped in smoke and fire.");
            }
            else if (speech.Contains("pakeha") || speech.Contains("european"))
            {
                Say("The Pākehā arrived with new ways, new weapons, and new bargains. Some were friends; others, storms.");
            }
            else if (speech.Contains("peace"))
            {
                Say("After blood comes the longing for peace. I have parleyed with governors and rivals alike, for a future yet unwritten.");
            }
            else if (speech.Contains("legend"))
            {
                Say("Every legend begins in hardship and ends in memory. Some say I am both, still walking these lands in spirit.");
            }
            else if (speech.Contains("spirit") || speech.Contains("spirits") || speech.Contains("ancestors"))
            {
                Say("My ancestors watch from the mist. Their courage gives strength, and their voices warn or guide.");
            }
            else if (speech.Contains("mist"))
            {
                Say("Mist cloaked me when I hid from danger, as it cloaks all things before a new dawn. Listen, and the mist will speak.");
            }
            else if (speech.Contains("cloak") || speech.Contains("korowai"))
            {
                Say("A chief’s korowai carries stories in every feather—each a reminder of those who came before.");
            }
            else if (speech.Contains("star") || speech.Contains("stars"))
            {
                Say("We navigate by stars—over sea, over years, even in darkness. There is always a path, if your heart is patient.");
            }
            else if (speech.Contains("island"))
            {
                Say("Island to island, shore to shore—Aotearoa is woven from journeys and arrivals.");
            }
            else if (speech.Contains("taiaha"))
            {
                Say("My taiaha is a dancer in battle, a pointer in peace. Its voice is swift, but its lesson is patience.");
            }
            else if (speech.Contains("lesson"))
            {
                Say("Lessons are found in hardship. Only the wise keep listening, even when the teaching is painful.");
            }
            else if (speech.Contains("future"))
            {
                Say("The future? It belongs to those who honor both land and ancestor. What will you carry forward?");
            }
			else if (speech.Contains("friend") || speech.Contains("friends") || speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("A friend today may be an enemy tomorrow, and vice versa. In times of change, even rivers shift their course.");
			}
			else if (speech.Contains("river") || speech.Contains("rivers"))
			{
				Say("The rivers of Aotearoa flow with memory. In their waters, I have seen reflections of both peace and war.");
			}
			else if (speech.Contains("tattoo") || speech.Contains("moko"))
			{
				Say("My moko is my identity, carved in pain and pride. It tells my story to all who care to look.");
			}
			else if (speech.Contains("ancestor") || speech.Contains("genealogy") || speech.Contains("whakapapa"))
			{
				Say("Whakapapa is our family line, the thread connecting us to those long past. I walk with my ancestors beside me.");
			}
			else if (speech.Contains("feather") || speech.Contains("feathers"))
			{
				Say("Each feather in my cloak was gifted in trust. They are more than decoration—they are promises kept.");
			}
			else if (speech.Contains("promise") || speech.Contains("promises"))
			{
				Say("A chief’s word is binding as the flax rope. Broken promises can tear a people apart.");
			}
			else if (speech.Contains("governor") || speech.Contains("governors"))
			{
				Say("Governors came bearing gifts and treaties, but always there was a price hidden in their words.");
			}
			else if (speech.Contains("treaty") || speech.Contains("treaties") || speech.Contains("waitangi"))
			{
				Say("The Treaty of Waitangi was signed with hope and suspicion. Its meaning is still argued on every marae.");
			}
			else if (speech.Contains("marae"))
			{
				Say("A marae is the heart of a people—a meeting place, a school, a shelter in storms both real and remembered.");
			}
			else if (speech.Contains("fire") || speech.Contains("flame"))
			{
				Say("Fire brings warmth, but it can also destroy. In my youth, I learned to respect both its faces.");
			}
			else if (speech.Contains("respect"))
			{
				Say("Without respect, there can be no peace. Every person, every mountain, every stream deserves it.");
			}
			else if (speech.Contains("greenstone") || speech.Contains("pounamu"))
			{
				Say("Pounamu is our treasure, formed by the land and shaped by the patient hand. To possess it is to bear responsibility.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom comes not with age, but with listening. Even the youngest child may teach the oldest chief.");
			}
			else if (speech.Contains("child") || speech.Contains("children"))
			{
				Say("Children are tomorrow’s leaders. In their laughter, I hear the hopes of generations yet unborn.");
			}
			else if (speech.Contains("storm") || speech.Contains("storms"))
			{
				Say("Storms come and go. True strength is not in avoiding the rain, but in learning to dance with it.");
			}
			else if (speech.Contains("dance") || speech.Contains("dancing"))
			{
				Say("Our haka is a dance of strength, our poi a dance of beauty. Each movement tells a story.");
			}
			else if (speech.Contains("beauty"))
			{
				Say("Beauty in Aotearoa is everywhere—from snow on the mountains to patterns on the shell of a small snail.");
			}
			else if (speech.Contains("shell"))
			{
				Say("A tiny shell, polished by the sea, is as precious as gold if you know its story.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Our stories are maps for the soul. Listen to them, and you will never be lost, no matter how far you travel.");
			}			
            else if (speech.Contains("carry"))
            {
                Say("Carry courage. Carry memory. Carry respect for all who walk these lands, seen and unseen.");
            }
            else if (speech.Contains("hidden"))
            {
                Say("Many things are hidden in the heart of Aotearoa—greenstone, stories, and sometimes, treasures.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Not all treasures glitter. Some are history, waiting for the curious to uncover their meaning.");
            }
            // SECRET REWARD KEYWORD
            else if (speech.Contains("curious"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the keenest eyes must sometimes wait. The land does not yield her gifts too quickly.");
                }
                else
                {
                    Say("Aroha to the curious! Accept this Treasure Chest of New Zealand History, and may its secrets inspire your own journey.");
                    from.AddToBackpack(new TreasureChestOfNewZealandHistory());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell") || speech.Contains("haere ra"))
            {
                Say("Haere rā! May the winds guide your waka safely on, wherever you roam.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of haka, Kapiti, voyages, or the stories hidden in Aotearoa’s mist.");
                }
            }

            base.OnSpeech(e);
        }

        public TeRauparaha(Serial serial) : base(serial) { }

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
