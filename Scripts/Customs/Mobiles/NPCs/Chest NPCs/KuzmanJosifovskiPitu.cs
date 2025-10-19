using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Kuzman Josifovski Pitu")]
    public class KuzmanJosifovskiPitu : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public KuzmanJosifovskiPitu() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kuzman Josifovski Pitu";
            Body = 0x190; // Human male

            // Unique Appearance: Macedonian Partisan
            AddItem(new FormalShirt() { Name = "White Shirt of the Partisan", Hue = 1153 });
            AddItem(new GuildedKilt() { Name = "Ohrid's Sash of Honor", Hue = 1171 });
            AddItem(new Cloak() { Name = "Cloak of the Macedonian Dawn", Hue = 1281 });
            AddItem(new FeatheredHat() { Name = "Beret of the Shadow Brigade", Hue = 1175 });
            AddItem(new FurBoots() { Name = "Boots of Mountain Trails", Hue = 2101 });
            AddItem(new BodySash() { Name = "Sash of Brotherhood", Hue = 1317 });
            AddItem(new ShortPants() { Name = "Encrypted Red Band", Hue = 2113 });
            AddItem(new Dagger() { Name = "Knife of the Coded Oath", Hue = 1170 });

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
                Say("They call me Kuzman Josifovski Pitu, a son of Macedonia, forever loyal to my people.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty was to unite our brothers and sisters, to carry the flame of resistance through mountain and shadow.");
            }
            else if (speech.Contains("health"))
            {
                Say("Scars and hunger, yes—but my spirit stands unbroken, as do the stones of Ohrid.");
            }
            else if (speech.Contains("ohrid"))
            {
                Say("Ohrid is the jewel of Macedonia, its lake a mirror of the sky, its streets echoing with old songs.");
            }
            else if (speech.Contains("macedonia"))
            {
                Say("Macedonia is a land of rivers and mountains, forged in struggle and hope.");
            }
            else if (speech.Contains("partisan") || speech.Contains("resistance"))
            {
                Say("We were called partisans—brothers and sisters bound by courage and a secret code.");
            }
            else if (speech.Contains("shadow"))
            {
                Say("We moved in shadow, for the enemy watched every path. The night became our shield.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("The mountains gave us shelter and wisdom. Many messages passed from peak to peak.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom was our password, whispered between the old stones and the young hearts.");
            }
            else if (speech.Contains("enemy"))
            {
                Say("Enemies lurked in every alley, but so did friends with hidden gifts.");
            }
            else if (speech.Contains("code"))
            {
                Say("Our code was simple: trust the message, not the messenger.");
            }
            else if (speech.Contains("brotherhood"))
            {
                Say("Brotherhood is more than blood—it is a promise sealed under the Macedonian sky.");
            }
            else if (speech.Contains("lake"))
            {
                Say("Lake Ohrid is older than memory, keeper of secrets, and friend to many partisans.");
            }
            else if (speech.Contains("secret") || speech.Contains("secrets"))
            {
                Say("A secret can save a life, or end one. Only the worthy are entrusted with the most precious message.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("A legacy is not gold, but the will to rise, to resist, and to dream for a free tomorrow.");
            }
            else if (speech.Contains("war"))
            {
                Say("War taught us the value of every quiet moment, every shared loaf of bread.");
            }
            else if (speech.Contains("bread"))
            {
                Say("Bread is life. I have shared my last crust with a stranger and gained a friend for life.");
            }
            else if (speech.Contains("friend"))
            {
                Say("In the darkest times, friendship was the only light we had.");
            }
            else if (speech.Contains("torch"))
            {
                Say("A single torch in the forest can lead many home. So too with hope.");
            }
			else if (speech.Contains("history"))
			{
				Say("History is a chain—each link forged in hope and struggle. Macedonia’s is written in both tears and triumph.");
			}
			else if (speech.Contains("night"))
			{
				Say("The night brought danger, but also cover for our missions. Many a plan was whispered under the cloak of darkness.");
			}
			else if (speech.Contains("flag"))
			{
				Say("The flag is not just cloth, but a symbol of every heart that dares to dream of freedom.");
			}
			else if (speech.Contains("river"))
			{
				Say("The rivers of Macedonia have seen many secrets float by—some carried in the current, some buried in its banks.");
			}
			else if (speech.Contains("poem") || speech.Contains("poetry"))
			{
				Say("Poetry is resistance. When bullets failed, our words still soared over the mountains and into memory.");
			}
			else if (speech.Contains("future"))
			{
				Say("We did not fight for ourselves alone. Every step was for a Macedonia our children might inherit.");
			}
			else if (speech.Contains("enemy"))
			{
				Say("Every enemy taught us vigilance. Even in defeat, we learned, we adapted, we endured.");
			}
			else if (speech.Contains("password"))
			{
				Say("The right password, spoken in the right place, could open doors—or save lives.");
			}
			else if (speech.Contains("youth"))
			{
				Say("The youth carried our dreams. Many became legends far too soon.");
			}
			else if (speech.Contains("martyr") || speech.Contains("martyrs"))
			{
				Say("Martyrs are the seeds from which tomorrow’s courage grows. Their names are never forgotten here.");
			}
			else if (speech.Contains("promise"))
			{
				Say("I promised my mother I would not let fear keep me from standing tall. It is a promise I keep for all Macedonia.");
			}
			else if (speech.Contains("betrayal"))
			{
				Say("Betrayal cuts deeper than any blade. Yet, it taught us to cherish those who proved loyal.");
			}
			else if (speech.Contains("spy"))
			{
				Say("Spies wore many faces, but truth has its own light, and the shadows could not hide it forever.");
			}
			else if (speech.Contains("father"))
			{
				Say("My father’s stories shaped my heart—stories of sun, stone, and a freedom worth any cost.");
			}
			else if (speech.Contains("sunrise"))
			{
				Say("Each sunrise was a victory; proof that hope outlived the darkness once again.");
			}
			else if (speech.Contains("compass"))
			{
				Say("A true compass points not just to north, but to the heart’s resolve.");
			}
			else if (speech.Contains("harvest"))
			{
				Say("The harvest is more than wheat. We reap courage, memory, and the will to go on.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is like water: sometimes clouded, but always finding its way to the light.");
			}
			else if (speech.Contains("prison"))
			{
				Say("Prison walls held many of us, but could not silence the songs or messages smuggled in hope.");
			}
			else if (speech.Contains("star") || speech.Contains("stars"))
			{
				Say("On cold nights, we read the stars as our ancestors did—each one a guide, a wish, a watcher.");
			}			
            else if (speech.Contains("hope"))
            {
                Say("Hope was our greatest weapon, outlasting bullets and betrayal.");
            }
            else if (speech.Contains("message"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("A message, once given, cannot be repeated so soon. Return when the shadows have shifted.");
                }
                else
                {
                    Say("You have found the true message. Take this Treasure Chest of North Macedonia—may it guide your own journey.");
                    from.AddToBackpack(new TreasureChestOfNorthMacedonia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("family"))
            {
                Say("Family gave me strength when the world seemed lost.");
            }
            else if (speech.Contains("song") || speech.Contains("songs"))
            {
                Say("Our songs kept our courage alive. Even now, the wind carries them over Lake Ohrid.");
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Go with courage. Macedonia remembers those who listen.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Ohrid, the mountains, resistance, or the old message that changed our fate.");
                }
            }

            base.OnSpeech(e);
        }

        public KuzmanJosifovskiPitu(Serial serial) : base(serial) { }

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
