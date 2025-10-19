using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Imhotep the Sage")]
    public class ImhotepSageOfTheNile : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public ImhotepSageOfTheNile() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Imhotep, Sage of the Nile";
            Body = 0x190; // Human male body

            // Stats
            Str = 80;
            Dex = 60;
            Int = 100;
            Hits = 70;

            // Unique Egyptian Outfit
            Item pharaohCrown = new Bonnet() { Hue = 2125, Name = "Crown of the Sun Pharaoh" };
            AddItem(pharaohCrown);

            Item sageRobe = new Robe() { Hue = 2401, Name = "Robe of Sacred Scrolls" };
            AddItem(sageRobe);

            Item priestSandals = new Sandals() { Hue = 2212, Name = "Sandals of the Nile Priest" };
            AddItem(priestSandals);

            Item goldenSash = new BodySash() { Hue = 2412, Name = "Golden Sash of Ma'at" };
            AddItem(goldenSash);

            Item ankhStaff = new GnarledStaff() { Hue = 1161, Name = "Ankh of Knowledge" };
            AddItem(ankhStaff);

            Hue = Utility.RandomSkinHue();
            HairItemID = Utility.RandomList(0x2047, 0x203C); // Short or shaved
            HairHue = 0x455; // Black

            SpeechHue = 2213; // Gold-tan

            lastRewardTime = DateTime.MinValue;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!from.InRange(this, 3))
                return;

            string speech = e.Speech.ToLower();

            // --- Base keywords ---
            if (speech.Contains("name"))
            {
                Say("I am Imhotep, Sage of the Nile—architect, healer, and seeker of hidden truths.");
            }
            else if (speech.Contains("job"))
            {
                Say("Once, I served Pharaoh as vizier and master builder. Now, I guide those who seek wisdom and secrets of ancient Egypt.");
            }
            else if (speech.Contains("health"))
            {
                Say("My spirit is strong, though these sands have seen many ages pass.");
            }
            // --- Branch 1: Sphinx and riddles ---
            else if (speech.Contains("wisdom"))
            {
                Say("True wisdom lies in understanding the mysteries of life, death, and the river Nile.");
            }
            else if (speech.Contains("pharaoh"))
            {
                Say("The Pharaoh is the living god, the bridge between mortals and the divine. I served Djoser, whose step pyramid touches the sky.");
            }
            else if (speech.Contains("pyramid"))
            {
                Say("The pyramid is more than a tomb—it is a ladder to the stars. Each stone holds a secret, each chamber a riddle.");
            }
            else if (speech.Contains("riddle"))
            {
                Say("To solve a riddle is to see beyond the obvious. Have you faced the riddle of the Sphinx?");
            }
            else if (speech.Contains("sphinx"))
            {
                Say("The Sphinx guards the sands of Giza. She asks: 'What walks on four legs in the morning, two at noon, and three in the evening?' The answer reveals much about the journey of life.");
            }
            else if (speech.Contains("life"))
            {
                Say("Life flows like the Nile—sometimes calm, sometimes wild. Cherish every sunrise.");
            }
            else if (speech.Contains("death"))
            {
                Say("Death is not the end, but a passage to the afterlife. The heart must be lighter than the feather of Ma'at.");
            }
            else if (speech.Contains("afterlife"))
            {
                Say("In the afterlife, one's deeds are weighed. Prepare yourself with truth and purity.");
            }
            // --- Branch 2: Knowledge, scrolls, medicine ---
            else if (speech.Contains("knowledge"))
            {
                Say("I have written scrolls on medicine, architecture, and the stars. Ask me of scrolls, healing, or the stars.");
            }
            else if (speech.Contains("scroll"))
            {
                Say("My scrolls contain cures for many ills and blueprints for great monuments. Knowledge is the greatest treasure.");
            }
            else if (speech.Contains("healing"))
            {
                Say("I was called the greatest healer. Many illnesses yield to the wisdom of herbs and the blessings of the gods.");
            }
            else if (speech.Contains("herb"))
            {
                Say("The blue lotus, the mandrake, the papyrus reed—each has its place in the healer’s kit.");
            }
            else if (speech.Contains("star"))
            {
                Say("We chart the stars to understand fate. Sirius, the Dog Star, marks the flooding of the Nile.");
            }
            else if (speech.Contains("nile"))
            {
                Say("The Nile brings life to Egypt. Its floods nourish the land and its secrets are deep.");
            }
            // --- Branch 3: Ancient secrets, treasures, reward ---
            else if (speech.Contains("secret"))
            {
                Say("There are many secrets buried beneath these sands. Some are guarded by curses, others by riddles.");
            }
            else if (speech.Contains("curse"))
            {
                Say("A curse is a warning to the greedy. Only those pure of heart can claim true treasures.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Treasure is not always gold. Sometimes it is knowledge, sometimes it is the respect of the gods.");
            }
			else if (speech.Contains("hieroglyph"))
			{
				Say("Hieroglyphs are the language of the gods, written in stone and papyrus. Every symbol tells a story.");
			}
			else if (speech.Contains("papyrus"))
			{
				Say("Papyrus was our gift to the world—used for writing scrolls, recording wisdom, and spreading knowledge.");
			}
			else if (speech.Contains("architecture"))
			{
				Say("Architecture is frozen music—each temple and tomb crafted to honor gods and kings.");
			}
			else if (speech.Contains("obelisk"))
			{
				Say("The obelisk reaches for the sky, a prayer in stone. Its shadow marks the passage of time and the favor of Ra.");
			}
			else if (speech.Contains("underworld"))
			{
				Say("The underworld, Duat, is a realm of trials. Only the worthy cross the river and face the scales of Anubis.");
			}
			else if (speech.Contains("anubis"))
			{
				Say("Anubis, guardian of the dead, weighs every heart against the feather of truth. Beware the devourer if you are found wanting.");
			}
			else if (speech.Contains("mummification"))
			{
				Say("Mummification preserves the body for eternity. Every organ has its guardian, every ritual its purpose.");
			}
			else if (speech.Contains("scarab"))
			{
				Say("The scarab beetle is a symbol of rebirth. We wear it as a charm against evil and as a guide in the afterlife.");
			}
			else if (speech.Contains("cat"))
			{
				Say("Cats are sacred to Bastet. Their grace keeps our homes safe from misfortune and wandering spirits.");
			}
			else if (speech.Contains("bastet"))
			{
				Say("Bastet, goddess of home and joy, protects the living with her gentle paws and fierce claws.");
			}
			else if (speech.Contains("sun"))
			{
				Say("The sun is Ra's chariot, crossing the sky by day and journeying through the underworld by night.");
			}
			else if (speech.Contains("moon"))
			{
				Say("The moon is Thoth’s lamp, guiding scribes and magicians in their nightly work.");
			}
			else if (speech.Contains("thoth"))
			{
				Say("Thoth, wise scribe, taught us writing, magic, and calculation. Offer him respect if you seek knowledge.");
			}
			else if (speech.Contains("magician"))
			{
				Say("A true magician seeks harmony, not just power. Magic is the weaving of the seen and unseen.");
			}
			else if (speech.Contains("river"))
			{
				Say("The river Nile is Egypt’s lifeblood. It carries stories, dreams, and sometimes, omens.");
			}
			else if (speech.Contains("omen"))
			{
				Say("Omens guide our actions—birds in the sky, shapes in the sand, dreams at dawn. Heed them well.");
			}
			else if (speech.Contains("dream"))
			{
				Say("Dreams are whispers from the gods. Record yours and look for signs—truth is often hidden within.");
			}
			else if (speech.Contains("sand"))
			{
				Say("Sand buries secrets, but also preserves them. Time itself is measured in grains.");
			}
			else if (speech.Contains("festival"))
			{
				Say("Festivals honor the gods and renew our spirits. Dancing, feasting, and offerings keep the world in balance.");
			}
			else if (speech.Contains("music"))
			{
				Say("Music is a bridge to the divine. The sistrum and harp bring joy to mortals and gods alike.");
			}			
            else if (speech.Contains("gods"))
            {
                Say("Ra, Isis, Osiris, and Anubis watch over us. Pay them respect and fortune may favor you.");
            }
            else if (speech.Contains("fortune"))
            {
                Say("Fortune favors the wise and the patient. Seek your path with open eyes.");
            }
            else if (speech.Contains("path"))
            {
                Say("The path to wisdom and reward is for those who dare to seek, to ask, and to learn. Will you seek fulfillment?");
            }
            // --- Reward trigger ---
            else if (speech.Contains("fulfillment"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(10);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("You have already received my gift. Return when the sun is higher in the sky.");
                }
                else
                {
                    Say("You have proven your curiosity and wisdom. Accept this Treasure Chest of Ancient Egypt—may its secrets enrich your journey!");
                    from.AddToBackpack(new TreasureChestOfAncientEgypt());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            base.OnSpeech(e);
        }

        public ImhotepSageOfTheNile(Serial serial) : base(serial) { }

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
