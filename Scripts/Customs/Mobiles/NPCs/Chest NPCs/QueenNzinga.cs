using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Queen Nzinga")]
    public class QueenNzinga : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public QueenNzinga() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Queen Nzinga Mbande";
            Body = 0x191; // Human female body

            // Stats
            Str = 90;
            Dex = 75;
            Int = 100;
            Hits = 80;

            // Unique Angolan Royalty Outfit
            AddItem(new FormalShirt() { Name = "Royal Tunic of Ndongo", Hue = 2110 });
            AddItem(new FancyKilt() { Name = "Matamba Warrior’s Skirt", Hue = 2118 });
            AddItem(new Cloak() { Name = "Nzinga's Mantle of Defiance", Hue = 1150 });
            AddItem(new BodySash() { Name = "Sash of Kimbundu Nobility", Hue = 1402 });
            AddItem(new Sandals() { Name = "Sandalwood Queen’s Footwear", Hue = 2107 });
            AddItem(new FeatheredHat() { Name = "Crown of Nzinga", Hue = 2075 });
            AddItem(new Scepter() { Name = "Scepter of Queen Nzinga", Hue = 1175 });

            SpeechHue = 2212;
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
                Say("I am Queen Nzinga Mbande, ruler of Ndongo and Matamba, a daughter of Angola’s soil.");
            }
            else if (speech.Contains("job"))
            {
                Say("I lead my people, defend my land, and outwit all who would subjugate us.");
            }
            else if (speech.Contains("health"))
            {
                Say("Strength flows through me like the Kwanza River, though every battle leaves its mark.");
            }
            else if (speech.Contains("queen"))
            {
                Say("A queen must be fierce and wise. I took the throne to save my people from bondage.");
            }
            else if (speech.Contains("ndongo"))
            {
                Say("Ndongo is the land of my birth—a kingdom proud and bold, but threatened by outsiders.");
            }
            else if (speech.Contains("matamba"))
            {
                Say("After many trials, I claimed Matamba, uniting kingdoms against our enemies.");
            }
            else if (speech.Contains("portuguese"))
            {
                Say("The Portuguese seek gold and slaves, but I have denied them victory at every turn.");
            }
            else if (speech.Contains("war"))
            {
                Say("War is a storm—devastating, but sometimes the only path to freedom.");
            }
            else if (speech.Contains("peace"))
            {
                Say("I brokered peace when I could, and turned to war when I must. Balance is the queen’s gift.");
            }
            else if (speech.Contains("sister"))
            {
                Say("My sister, Kifunji, was both rival and ally. Family bonds are as complex as kingdoms.");
            }
            else if (speech.Contains("king"))
            {
                Say("Before me ruled King Ngola. When his reign faltered, I rose to shield my people.");
            }
            else if (speech.Contains("slavery") || speech.Contains("slave"))
            {
                Say("Slavery is a shadow over Angola. I fought with every breath to protect my people from chains.");
            }
			else if (speech.Contains("legacy"))
			{
				Say("My legacy is one of resilience and defiance. May future generations rise unbroken, as I did.");
			}
			else if (speech.Contains("tactic") || speech.Contains("tactics") || speech.Contains("strategy"))
			{
				Say("A queen’s weapons are not only blade and spear, but cunning, disguise, and the turning of rivals into allies.");
			}
			else if (speech.Contains("faith") || speech.Contains("spirit"))
			{
				Say("I drew strength from the spirits of the land and the traditions of my ancestors. Their wisdom guided my path.");
			}
			else if (speech.Contains("culture"))
			{
				Say("Our dances, songs, and tales keep the flame of Angola alive, even in times of sorrow.");
			}
			else if (speech.Contains("people"))
			{
				Say("My people are strong, proud, and resourceful. They endured much, but never forgot their worth.");
			}
			else if (speech.Contains("betrayal") || speech.Contains("betray"))
			{
				Say("Trust, once broken, is not easily mended. Even among kin, betrayal leaves scars that last beyond lifetimes.");
			}
			else if (speech.Contains("resist") || speech.Contains("resistance"))
			{
				Say("Resistance is more than battle; it is refusing to forget who you are, even when all is threatened.");
			}
			else if (speech.Contains("ambassador") || speech.Contains("envoy"))
			{
				Say("I have faced envoys from Portugal, the Netherlands, and neighboring lands—sometimes as enemy, sometimes as guest.");
			}
			else if (speech.Contains("chair") || speech.Contains("throne"))
			{
				Say("Once, the Portuguese denied me a chair, hoping to insult me. I sat upon the back of a loyal attendant, and lost no dignity.");
			}
			else if (speech.Contains("netherlands") || speech.Contains("dutch"))
			{
				Say("For a time, I allied with the Dutch against the Portuguese. In war, an unlikely friend is still a friend.");
			}
			else if (speech.Contains("loss") || speech.Contains("sacrifice"))
			{
				Say("Every victory demands a sacrifice. I mourn those lost, but honor their memory by fighting on.");
			}
			else if (speech.Contains("advisor") || speech.Contains("counselor"))
			{
				Say("A wise ruler listens to many voices, but trusts only a few. My advisors often saved both my life and my soul.");
			}
			else if (speech.Contains("matamba"))
			{
				Say("Matamba’s forests hid many secrets and gave shelter to those fleeing chains. There I built new hope.");
			}
			else if (speech.Contains("kwanza") || speech.Contains("river"))
			{
				Say("The Kwanza River nourishes the land as a mother nourishes her child. Many stories begin on its banks.");
			}
			else if (speech.Contains("ancestors"))
			{
				Say("I honor my ancestors, whose spirits dwell in the earth, the trees, and the very wind that breathes over Angola.");
			}
			else if (speech.Contains("future"))
			{
				Say("The future belongs to the bold, and to those who refuse to bow their heads in defeat.");
			}			
            else if (speech.Contains("alliance"))
            {
                Say("To save Ndongo and Matamba, I forged alliances—even with unlikely friends, from Dutch to neighboring tribes.");
            }
            else if (speech.Contains("trickery") || speech.Contains("trick"))
            {
                Say("Sometimes a throne is won not by force, but by wit. I once outwitted the Portuguese at a royal audience.");
            }
            else if (speech.Contains("royal"))
            {
                Say("Royalty is a burden and a blessing. One must serve with courage and rule with justice.");
            }
            else if (speech.Contains("treasure") || speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience is a virtue, traveler. Return to me later if you seek a reward from Angola.");
                }
                else
                {
                    Say("Your curiosity honors me. Accept this Treasure Chest of Angola—may it remind you of freedom’s value.");
                    from.AddToBackpack(new TreasureChestOfAngola());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("May Angola’s courage guide your journey. Go in strength and wisdom.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of Ndongo, Matamba, the Portuguese, or the secret of my reign.");
                }
            }

            base.OnSpeech(e);
        }

        public QueenNzinga(Serial serial) : base(serial) { }

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
