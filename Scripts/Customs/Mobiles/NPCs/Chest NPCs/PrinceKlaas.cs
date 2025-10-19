using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Prince Klaas")]
    public class PrinceKlaas : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public PrinceKlaas() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Prince Klaas";
            Body = 0x190; // Human male body

            // Stats
            Str = 90;
            Dex = 80;
            Int = 105;
            Hits = 80;

            // Unique Appearance
            AddItem(new ElvenShirt() { Name = "Regal Tunic of Kwaku", Hue = 2949 });
            AddItem(new GuildedKilt() { Name = "Freedom Sash of the Windward Isles", Hue = 2410 });
            AddItem(new BodySash() { Name = "Indigo Band of the Uprising", Hue = 1109 });
            AddItem(new Cloak() { Name = "Shadow Cloak of the Night Meeting", Hue = 2425 });
            AddItem(new FeatheredHat() { Name = "Prince Klaas’ Rebel Plume", Hue = 1321 });
            AddItem(new Sandals() { Name = "Island Striders", Hue = 2105 });
            AddItem(new RingmailArms() { Name = "Armlets of Resistance", Hue = 2207 });

            // Weapon
            AddItem(new Scepter() { Name = "Staff of Hope", Hue = 1175 });

            SpeechHue = 2219;

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
                Say("I am Prince Klaas, born Kwaku Takyi—a son of Africa, spirit of Antigua’s struggle.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I was bound in chains. But my true calling was to free my people.");
            }
            else if (speech.Contains("health"))
            {
                Say("My body was beaten, but my spirit never broke.");
            }
            else if (speech.Contains("slave"))
            {
                Say("Enslaved, yes, but never defeated. My dreams reached beyond the sugar fields.");
            }
            else if (speech.Contains("rebellion"))
            {
                Say("In 1736, we dreamed of freedom. Our rebellion was sparked in secret, by moonlight and hope.");
            }
            else if (speech.Contains("freedom"))
            {
                Say("Freedom is a fire: it burns quietly, then brightens the whole land.");
            }
            else if (speech.Contains("africa"))
            {
                Say("Africa gave me roots and courage. Antigua gave me purpose.");
            }
            else if (speech.Contains("antigua"))
            {
                Say("Antigua’s sugar fields saw much pain, but also the courage of many.");
            }
            else if (speech.Contains("secret"))
            {
                Say("Our plans were hidden in song and dance, safe from the master's ear.");
            }
            else if (speech.Contains("drum"))
            {
                Say("The drumbeat was our code, the sound of uprising.");
            }
            else if (speech.Contains("dance"))
            {
                Say("Even in chains, our dance carried the message of freedom.");
            }
            else if (speech.Contains("betrayal"))
            {
                Say("Betrayal shattered our dream—but not our spirit.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not gold, but memory—our story lives on, carried by the wind.");
            }
            else if (speech.Contains("hope"))
            {
                Say("Hope is a seed. Even crushed, it grows in the hearts of the brave.");
            }
			else if (speech.Contains("island"))
			{
				Say("Antigua is an island shaped by sun and sea. Every wave remembers those who longed for freedom.");
			}
			else if (speech.Contains("barbuda"))
			{
				Say("Barbuda—sister isle, refuge of the wild, where stories travel on the wind.");
			}
			else if (speech.Contains("ocean") || speech.Contains("sea"))
			{
				Say("The ocean was both barrier and hope. Some gazed across the water and dreamed of home.");
			}
			else if (speech.Contains("family"))
			{
				Say("Family was all we had. We clung to each other, sharing strength beneath the watchful eye.");
			}
			else if (speech.Contains("market"))
			{
				Say("In the market, whispers traveled faster than coin. There, news of hope could spread in secret.");
			}
			else if (speech.Contains("festival") || speech.Contains("celebration"))
			{
				Say("Our festivals—though watched and wary—were times when joy and sorrow mingled in song.");
			}
			else if (speech.Contains("story") || speech.Contains("stories"))
			{
				Say("Every night, we shared stories. Some spoke of old Africa; some dared to dream of tomorrow.");
			}
			else if (speech.Contains("justice"))
			{
				Say("True justice is freedom. I lived and died for that dream.");
			}
			else if (speech.Contains("chain") || speech.Contains("chains"))
			{
				Say("Chains can bind the body, but never the mind. Our thoughts were always our own.");
			}
			else if (speech.Contains("moon"))
			{
				Say("By the light of the moon, we gathered in secret—brothers and sisters in hope.");
			}
			else if (speech.Contains("friend") || speech.Contains("friends"))
			{
				Say("A true friend risks much for another. I found many such souls in our struggle.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Enemies watched us from shadows and porches. Some hid fear behind cruelty.");
			}
			else if (speech.Contains("master"))
			{
				Say("The master held the whip, but never our hearts.");
			}
			else if (speech.Contains("pain"))
			{
				Say("Pain taught us to endure. Hope taught us to rise again.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams are powerful. They cross oceans, survive fire, and outlive kings.");
			}
			else if (speech.Contains("fire"))
			{
				Say("We hid signals in firelight—one spark could change everything.");
			}
			else if (speech.Contains("death"))
			{
				Say("Death came for many. But as long as our story is told, we do not truly die.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to the bold. Plant seeds of freedom wherever you walk.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is a dangerous friend. Speak it softly, carry it always.");
			}
			else if (speech.Contains("herb") || speech.Contains("herbs"))
			{
				Say("Old mothers knew the secret of herbs—healing for the sick, wisdom for the young.");
			}
			else if (speech.Contains("night"))
			{
				Say("Night is when the island truly breathes—quiet, watchful, alive with whispers.");
			}
			else if (speech.Contains("spirit") || speech.Contains("spirits"))
			{
				Say("The spirits of our ancestors watched over us. Some say they walk the sugar fields at dusk.");
			}
			else if (speech.Contains("dusk"))
			{
				Say("At dusk, shadows grow long—and so does our courage.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun’s heat could scorch, but it also brought life to the cane and hope to the heart.");
			}			
            else if (speech.Contains("song"))
            {
                Say("Our songs kept the secret alive. Listen close, and you might hear it still.");
            }
            else if (speech.Contains("sugar"))
            {
                Say("The cane fields were harsh, but the taste of freedom was sweeter.");
            }
            else if (speech.Contains("windward"))
            {
                Say("The Windward Isles—where whispers of revolt sailed with the sea breeze.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("All treasures must wait. Return to me after some time, friend.");
                }
                else
                {
                    Say("For your curiosity and respect, accept this Treasure Chest of Antigua and Barbuda—may it remind you of our courage.");
                    from.AddToBackpack(new TreasureChestOfAntiguaBarbuda());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Carry our story with you. The dream of freedom lives on.");
            }
            else
            {
                // Encourage discovery if no keywords match
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of rebellion, freedom, drums, or Africa’s legacy.");
                }
            }

            base.OnSpeech(e);
        }

        public PrinceKlaas(Serial serial) : base(serial) { }

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
