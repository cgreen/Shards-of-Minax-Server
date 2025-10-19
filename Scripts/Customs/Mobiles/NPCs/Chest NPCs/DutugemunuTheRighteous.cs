using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of King Dutugemunu")]
    public class DutugemunuTheRighteous : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public DutugemunuTheRighteous() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "King Dutugemunu the Righteous";
            Body = 0x190; // Human male body

            // Stats
            Str = 100;
            Dex = 60;
            Int = 100;
            Hits = 90;

            // Appearance
            AddItem(new Robe() { Name = "Robe of the Ruwanwelisaya", Hue = 1153 });
            AddItem(new BodySash() { Name = "Sash of the Sacred Bo Tree", Hue = 2122 });
            AddItem(new FancyShirt() { Name = "Silk Tunic of Rajarata", Hue = 2418 });
            AddItem(new Cloak() { Name = "Cloak of the Eternal Flame", Hue = 2117 });
            AddItem(new Sandals() { Name = "Sandals of Anuradhapura", Hue = 2055 });
            AddItem(new FeatheredHat() { Name = "Crown of the Dharmic Monarch", Hue = 1413 });

            AddItem(new GnarledStaff() { Name = "Staff of Enlightened Kings", Hue = 1175 });

            SpeechHue = 2123;
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
                Say("I am Dutugemunu, ruler of Rajarata, defender of the Dhamma, and uniter of Lanka.");
            }
            else if (speech.Contains("job"))
            {
                Say("My duty was to restore righteousness to the island and uphold the sacred path.");
            }
            else if (speech.Contains("health"))
            {
                Say("The spirit remains strong, though centuries have passed.");
            }
            else if (speech.Contains("lanka"))
            {
                Say("Lanka is a pearl of the Indian Ocean—rich in beauty, sorrow, and wisdom.");
            }
            else if (speech.Contains("dhamma"))
            {
                Say("Dhamma is the law of righteousness. I fought not for power, but to protect its light.");
            }
            else if (speech.Contains("elara"))
            {
                Say("King Elara was a noble foe, just and brave. I built a monument to honor him after the battle.");
            }
            else if (speech.Contains("ruwanwelisaya"))
            {
                Say("That great stupa is my heart's offering—white as moonlight, tall as hope.");
            }
            else if (speech.Contains("bo tree") || speech.Contains("bo"))
            {
                Say("From the sacred Bodhi tree, enlightenment blossoms. It is our root and crown.");
            }
            else if (speech.Contains("temple"))
            {
                Say("Temples are sanctuaries for the soul, where even kings kneel before truth.");
            }
            else if (speech.Contains("battle"))
            {
                Say("The battle for Anuradhapura was fierce, but unity prevailed over division.");
            }
            else if (speech.Contains("peace"))
            {
                Say("True peace is harder won than any kingdom. It lives in compassion.");
            }
            else if (speech.Contains("treasure"))
            {
                Say("Sri Lanka’s true treasures are not gold—but wisdom, harmony, and sacred relics.");
            }
            else if (speech.Contains("relic"))
            {
                Say("The Tooth Relic of the Buddha was carried through storms and fire to reach this land.");
            }
			else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
			{
				Say("My ancestors lit the path I walked. A king does not walk alone—he walks upon the legacy of thousands.");
			}
			else if (speech.Contains("truth"))
			{
				Say("Truth is like the sacred flame—it may flicker in the storm, but it is never extinguished.");
			}
			else if (speech.Contains("sorrow"))
			{
				Say("Even kings know sorrow. The tears of my people carved deeper wounds than the blade ever could.");
			}
			else if (speech.Contains("buddha"))
			{
				Say("I held the teachings of the Buddha as my guide—compassion in war, peace in victory.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is earned not only by age, but by the willingness to listen to silence.");
			}
			else if (speech.Contains("anuradhapura"))
			{
				Say("Anuradhapura was my jewel, my city of light. Its walls held the dreams of a united Lanka.");
			}
			else if (speech.Contains("dream") || speech.Contains("dreams"))
			{
				Say("I dreamed of a land without hatred, where temples outnumbered swords.");
			}
			else if (speech.Contains("monk") || speech.Contains("monks"))
			{
				Say("I often sought counsel from monks, for in their silence I found clarity.");
			}
			else if (speech.Contains("stupa"))
			{
				Say("The stupa is not just stone—it is a prayer in form, a beacon of the sacred in a world of impermanence.");
			}
			else if (speech.Contains("impermanence"))
			{
				Say("All things fade—kingdoms, crowns, and even kings. But virtue endures.");
			}
			else if (speech.Contains("virtue"))
			{
				Say("Virtue is not in conquest, but in restraint. In giving when it is easier to take.");
			}
			else if (speech.Contains("conquest"))
			{
				Say("My conquest was not of land alone, but of ego, hatred, and doubt.");
			}
			else if (speech.Contains("truth") || speech.Contains("honor"))
			{
				Say("Honor is not worn—it is lived. A king without honor is no more than a tyrant with a throne.");
			}
			else if (speech.Contains("pilgrim") || speech.Contains("pilgrimage"))
			{
				Say("Many journeyed to Anuradhapura in search of peace. Some found it. Others brought it with them.");
			}			
            else if (speech.Contains("unite") || speech.Contains("unity"))
            {
                Say("Only by unity can a land rise. I sought to bind the island not with chains, but with purpose.");
            }
            else if (speech.Contains("compassion"))
            {
                Say("Even to my enemies I showed mercy. A king must conquer hate before land.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Even sacred treasures must wait their time. Return once your path has ripened.");
                }
                else
                {
                    Say("May this Treasure Chest of Ancient Sri Lanka bring you closer to understanding and balance.");
                    from.AddToBackpack(new TreasureChestOfAncientSriLanka());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May the teachings of the Buddha light your path, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Elara, Ruwanwelisaya, or the sacred Bo tree to uncover deeper truths.");
                }
            }

            base.OnSpeech(e);
        }

        public DutugemunuTheRighteous(Serial serial) : base(serial) { }

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
