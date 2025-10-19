using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Bayano")]
    public class Bayano : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public Bayano() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bayano";
            Body = 0x190; // Human male body

            // Unique Appearance: Jungle Rebel Leader
            AddItem(new ElvenShirt() { Name = "Bayano's Indigo Jungle Tunic", Hue = 1319 });
            AddItem(new GuildedKilt() { Name = "Skirt of the Darién Night", Hue = 2119 });
            AddItem(new Cloak() { Name = "Cloak of the Midnight Rainforest", Hue = 2209 });
            AddItem(new TribalMask() { Name = "Mask of the Cimarrón Chief", Hue = 2430 });
            AddItem(new FurBoots() { Name = "Boots of the Silent Uprising", Hue = 1835 });
            AddItem(new BodySash() { Name = "Sash of Forgotten Kings", Hue = 1175 });

            // Weapon: Unique
            AddItem(new Scimitar() { Name = "Machete of Freedom", Hue = 1367 });

            // Speech Hue
            SpeechHue = 2150;

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
                Say("I am Bayano, once a slave, now a legend beneath Panama's endless sky.");
            }
            else if (speech.Contains("job"))
            {
                Say("My job was survival, rebellion, and freedom—leader of those called Cimarrónes in the Darién wilds.");
            }
            else if (speech.Contains("health"))
            {
                Say("My scars run deep, but the strength of my people endures like the roots of the rainforest.");
            }
            else if (speech.Contains("panama"))
            {
                Say("Panama is a land of rivers and secrets—where empires crossed, and rebels found home.");
            }
            else if (speech.Contains("cimarron") || speech.Contains("cimarrones"))
            {
                Say("Cimarrónes are escaped slaves who forged free lives in the jungles, beyond the reach of chains.");
            }
            else if (speech.Contains("rebellion") || speech.Contains("rebel"))
            {
                Say("Our rebellion was born of pain and hope. We struck at night, and vanished with the dawn.");
            }
            else if (speech.Contains("darién") || speech.Contains("darien"))
            {
                Say("The Darién is dense and wild—there, the earth itself shields those who run from oppression.");
            }
            else if (speech.Contains("slave") || speech.Contains("slavery"))
            {
                Say("Chains may break flesh, but never the spirit. All who yearn for freedom are kin to me.");
            }
            else if (speech.Contains("mask"))
            {
                Say("This mask is not to hide, but to remember: each face behind it is a story of defiance.");
            }
            else if (speech.Contains("machete"))
            {
                Say("My machete cleared more than jungle—it parted the path to liberty for many.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a seed. With courage, it grows in even the darkest soil.");
            }
            else if (speech.Contains("spanish") || speech.Contains("conquistador"))
            {
                Say("The Spanish hunted us, but the forest was our shield, and our silence was sharper than steel.");
            }
            else if (speech.Contains("forest") || speech.Contains("jungle"))
            {
                Say("The jungle remembers all: footsteps, oaths, and betrayals. Listen close, and you might hear its warnings.");
            }
            else if (speech.Contains("legend"))
            {
                Say("They say I could not be caught, that the rivers would hide me and the earth would swallow my enemies.");
            }
            else if (speech.Contains("river") || speech.Contains("rivers"))
            {
                Say("Panama's rivers carried news and hope, and sometimes, our warriors beneath their currents.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is rebellion’s true weapon. As long as one heart resists, defeat is never final.");
            }
            else if (speech.Contains("community"))
            {
                Say("In the jungle, our communities—palenques—were hidden, but our spirit was fierce and bright.");
            }
            else if (speech.Contains("palenque"))
            {
                Say("A palenque is a secret village of the free. There, we lived as kin, safe from the world’s chains.");
            }
            else if (speech.Contains("chain") || speech.Contains("chains"))
            {
                Say("A broken chain can become a weapon, or a story. Which will you carry?");
            }
            else if (speech.Contains("story") || speech.Contains("stories"))
            {
                Say("Every scar is a story; every story a lesson. Ask, and perhaps I will share one.");
            }
			else if (speech.Contains("panther"))
			{
				Say("The panther moves unseen—silent, swift, patient. In the jungle, sometimes survival means learning from the shadows.");
			}
			else if (speech.Contains("fear"))
			{
				Say("Fear is the first chain every captive must break. Only then can you begin to shape your own destiny.");
			}
			else if (speech.Contains("destiny"))
			{
				Say("Destiny is a winding river; no one truly knows where it leads until they set foot in the current.");
			}
			else if (speech.Contains("moon"))
			{
				Say("We marched by moonlight, its silver path our only guide. The night was our cloak, our ally.");
			}
			else if (speech.Contains("allies"))
			{
				Say("Allies come in many forms—a kind stranger, a clever bird, even the wind that hides your footsteps.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("I learned to know my enemies by the weight of their silence. A wise rebel listens more than he speaks.");
			}
			else if (speech.Contains("escape"))
			{
				Say("Escape is not a single moment—it is a journey. Each day you breathe free, you are escaping anew.");
			}
			else if (speech.Contains("fire"))
			{
				Say("Fire warms the heart and wards off fear, but in the wrong hands it can summon ruin. Every campfire is a risk.");
			}
			else if (speech.Contains("drum") || speech.Contains("drums"))
			{
				Say("Drums speak the language of courage. Their beat can rally warriors, or warn of danger from afar.");
			}
			else if (speech.Contains("song") || speech.Contains("sing"))
			{
				Say("Songs kept our spirits alive when food was scarce and hope seemed distant. Even the forest listens when we sing.");
			}
			else if (speech.Contains("leader"))
			{
				Say("A leader is not chosen by birth, but by the trust of those who follow—and the burdens he is willing to bear.");
			}
			else if (speech.Contains("trust"))
			{
				Say("Trust is as rare as gold, and twice as valuable. Lose it, and even your own shadow may turn against you.");
			}
			else if (speech.Contains("map"))
			{
				Say("Maps drawn by outsiders tell you where to go. The ones we made told us where not to be found.");
			}
			else if (speech.Contains("trade"))
			{
				Say("We traded with the forest and with friends who wished us well. Even a single coin could mean the difference between hunger and hope.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family is more than blood; it is every soul who stands beside you when the world turns dark.");
			}
			else if (speech.Contains("roots"))
			{
				Say("Roots hold trees to the earth, and people to their promise. Forget your roots, and the first storm may take you.");
			}
			else if (speech.Contains("storm"))
			{
				Say("Storms come quickly in Panama. To survive them, you must bend, not break.");
			}
			else if (speech.Contains("children"))
			{
				Say("Children carried our future in their laughter, even when our present seemed filled with sorrow.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is learned from mistakes and passed along in whispers. Listen, and you may gain it without the pain.");
			}
			else if (speech.Contains("spirit"))
			{
				Say("The spirit is what cannot be chained. Even when our bodies faltered, our spirits soared above the trees.");
			}
			else if (speech.Contains("victory"))
			{
				Say("Victory can be as simple as a meal, or as grand as a free village. Every small triumph lights the way to the next.");
			}
			else if (speech.Contains("forgive") || speech.Contains("forgiveness"))
			{
				Say("Forgiveness is a harder battle than any fought with blade or fire. Yet sometimes, it is the only path forward.");
			}
			else if (speech.Contains("peace"))
			{
				Say("Peace is a rare treasure, hard-won and easily lost. Guard it, for its absence is a heavy burden.");
			}			
            else if (speech.Contains("lesson"))
            {
                Say("The lesson of the jungle: trust your kin, never your captor. And never show your refuge to strangers.");
            }
            else if (speech.Contains("refuge"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even the safest refuge cannot welcome you twice in a day. Return later, seeker.");
                }
                else
                {
                    Say("You have found the word hidden in the leaves. Accept this Treasure Chest of Panama—may it help you carve your own legend.");
                    from.AddToBackpack(new TreasureChestOfPanama());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("king"))
            {
                Say("They called me a king, but I was only a man, searching for a place where none ruled but hope.");
            }
            else if (speech.Contains("jungle") || speech.Contains("rainforest"))
            {
                Say("Beneath the emerald canopy, the free found their home—and their courage.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Travel with the river’s patience, and the panther’s watchful eyes.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of rebellion, Panama, the Cimarrónes, or the palenques hidden in the Darién.");
                }
            }

            base.OnSpeech(e);
        }

        public Bayano(Serial serial) : base(serial) { }

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
