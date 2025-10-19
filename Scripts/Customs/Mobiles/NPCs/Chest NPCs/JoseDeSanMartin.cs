using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of General José de San Martín")]
    public class JoseDeSanMartin : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public JoseDeSanMartin() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "General José de San Martín";
            Body = 0x190; // Human male body

            // Stats
            Str = 95;
            Dex = 70;
            Int = 90;
            Hits = 80;

            // Unique Appearance: Liberator of Argentina
            AddItem(new FormalShirt() { Name = "Azure Military Tunic of the Andes", Hue = 1254 });
            AddItem(new FancyKilt() { Name = "Liberator's Sash of Liberty", Hue = 2212 });
            AddItem(new Cloak() { Name = "Patriot's Cloak of Mendoza", Hue = 2062 });
            AddItem(new FeatheredHat() { Name = "San Martín's Plumed Hat", Hue = 1175 });
            AddItem(new Boots() { Name = "Marching Boots of the Granaderos", Hue = 1109 });
            AddItem(new BodySash() { Name = "Order of the Sun Sash", Hue = 2118 });

            // Weapon: Sabre
            AddItem(new Katana() { Name = "Freedom Sabre of the Andes", Hue = 1158 });

            // Speech Hue
            SpeechHue = 2122;

            // Initialize reward cooldown
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
                Say("I am General José de San Martín, liberator of Argentina, Chile, and Peru.");
            }
            else if (speech.Contains("job"))
            {
                Say("I am a soldier of freedom, who led the Army of the Andes across the mountains to free South America.");
            }
            else if (speech.Contains("health"))
            {
                Say("I am well, though the years and battles have left their mark upon me.");
            }
            else if (speech.Contains("liberator"))
            {
                Say("They call me the Liberator for my role in freeing Argentina, Chile, and Peru from colonial rule.");
            }
            else if (speech.Contains("argentina"))
            {
                Say("Argentina is a land of courage, from the windswept pampas to the snow-capped Andes.");
            }
            else if (speech.Contains("andes"))
            {
                Say("Crossing the Andes was my greatest feat. The icy mountains were both ally and enemy.");
            }
            else if (speech.Contains("army"))
            {
                Say("The Army of the Andes was forged in Mendoza—brave souls seeking liberty for all.");
            }
            else if (speech.Contains("liberty") || speech.Contains("freedom"))
            {
                Say("Liberty is the most precious treasure. It must be won, defended, and cherished.");
            }
            else if (speech.Contains("mendoza"))
            {
                Say("Mendoza was the birthplace of our dream for independence—a city of wine, hope, and planning.");
            }
            else if (speech.Contains("wine"))
            {
                Say("Ah, the Malbec wines of Mendoza are as bold as the patriots who drank them.");
            }
            else if (speech.Contains("patriot") || speech.Contains("patriots"))
            {
                Say("Patriots are those who serve their homeland before themselves.");
            }
            else if (speech.Contains("chile"))
            {
                Say("From Mendoza, we marched across the Andes to free Chile at the Battle of Chacabuco.");
            }
            else if (speech.Contains("peru"))
            {
                Say("Peru was the last bastion of colonial power. Our victory in Lima meant liberty for all.");
            }
            else if (speech.Contains("battle"))
            {
                Say("We fought many battles—San Lorenzo, Chacabuco, Maipú—all for the cause of freedom.");
            }
            else if (speech.Contains("san lorenzo"))
            {
                Say("San Lorenzo was my first victory, where my Granaderos proved their valor.");
            }
            else if (speech.Contains("granaderos"))
            {
                Say("The Granaderos a Caballo are Argentina's finest cavalry—brave, loyal, unstoppable.");
            }
            else if (speech.Contains("horse") || speech.Contains("horses"))
            {
                Say("A good horse is a soldier’s most loyal friend. Mine carried me across the Andes.");
            }
            else if (speech.Contains("sabre"))
            {
                Say("My sabre has tasted both frost and fire in the struggle for independence.");
            }
            else if (speech.Contains("dream"))
            {
                Say("My dream was a united, free South America, where justice and equality would flourish.");
            }
            else if (speech.Contains("independence"))
            {
                Say("Independence is earned by sacrifice and unity. The sun of May shines because of it.");
            }
            else if (speech.Contains("sun") || speech.Contains("may"))
            {
                Say("The Sun of May is the symbol of freedom—a golden emblem on Argentina's flag.");
            }
            else if (speech.Contains("flag"))
            {
                Say("Argentina's flag of blue and white was raised for the first time in Rosario, a city of hope.");
            }
			else if (speech.Contains("family"))
			{
				Say("My wife, Remedios, was my heart’s companion. Our daughter, Mercedes, carried my hopes for a peaceful future.");
			}
			else if (speech.Contains("remedios"))
			{
				Say("Remedios de Escalada, my beloved wife, was a symbol of strength and kindness during troubled times.");
			}
			else if (speech.Contains("mercedes"))
			{
				Say("Mercedes, my daughter, was born amidst the fires of revolution. Her innocence reminded me why we fought.");
			}
			else if (speech.Contains("spain"))
			{
				Say("I was born in Yapeyú, but trained as a soldier in Spain before returning to free my homeland.");
			}
			else if (speech.Contains("yapeyu"))
			{
				Say("Yapeyú, on the banks of the Uruguay River, was my birthplace—a small corner of a vast dream.");
			}
			else if (speech.Contains("friends"))
			{
				Say("True friends are rare in war and peace. I trusted men like Belgrano, O'Higgins, and Güemes.");
			}
			else if (speech.Contains("belgrano"))
			{
				Say("Manuel Belgrano designed our flag and fought bravely for independence. A true patriot.");
			}
			else if (speech.Contains("o'higgins"))
			{
				Say("Bernardo O'Higgins of Chile stood by my side as we freed his country from tyranny.");
			}
			else if (speech.Contains("guemes"))
			{
				Say("Martín Miguel de Güemes defended the northern frontiers, harrying royalists with courage and cunning.");
			}
			else if (speech.Contains("enemy") || speech.Contains("enemies"))
			{
				Say("Our enemies were not just soldiers of Spain, but also fear, division, and doubt.");
			}
			else if (speech.Contains("philosophy"))
			{
				Say("I believe that only those who serve others truly become great. Power must be wielded with humility.");
			}
			else if (speech.Contains("humility"))
			{
				Say("After victory, I retired quietly in France. Glory belongs to the people, not to one man alone.");
			}
			else if (speech.Contains("france"))
			{
				Say("In my final years, I lived in Boulogne-sur-Mer, France, far from my beloved Argentina but close in spirit.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("I wish to be remembered not as a conqueror, but as a servant of liberty and justice.");
			}
			else if (speech.Contains("justice"))
			{
				Say("Justice is the foundation of freedom. Without it, even the greatest nation will crumble.");
			}
			else if (speech.Contains("river"))
			{
				Say("The Paraná and Uruguay rivers were lifelines for our armies—carrying hope and hardship alike.");
			}
			else if (speech.Contains("mate"))
			{
				Say("Ah, mate—the drink of the pampas! It brings warmth to cold mornings and unity to friends.");
			}
			else if (speech.Contains("tradition"))
			{
				Say("Traditions are the soul of a people. In song, in dress, in the sharing of mate—we find our spirit.");
			}
			else if (speech.Contains("song"))
			{
				Say("The zamba, the chacarera—our folk songs keep alive the dreams and struggles of our land.");
			}
			else if (speech.Contains("advice"))
			{
				Say("My advice? Persevere in the face of hardship. The mountains are climbed step by step.");
			}			
            else if (speech.Contains("rosario"))
            {
                Say("Rosario gave us our flag and many brave sons for our cause.");
            }
            else if (speech.Contains("tango"))
            {
                Say("Tango? That dance was born after my time—but it stirs the soul of Argentina.");
            }
            else if (speech.Contains("pampas"))
            {
                Say("The pampas are Argentina's endless grasslands, home to gauchos and wild freedom.");
            }
            else if (speech.Contains("gaucho") || speech.Contains("gauchos"))
            {
                Say("Gauchos are the free spirits of the pampas—masters of horse and blade, loyal to liberty.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("My true legacy is freedom for future generations, not glory for myself.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Patience, amigo! True treasures must wait for their time. Return to me later.");
                }
                else
                {
                    Say("Your curiosity and valor are worthy! Take this Treasure Chest of Argentina—may it bring you courage and fortune.");
                    from.AddToBackpack(new TreasureChestOfArgentina());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("goodbye") || speech.Contains("farewell"))
            {
                Say("Farewell, traveler! May the winds of the Andes guide you ever toward liberty.");
            }
            else
            {
                // Optional: Encourage exploration
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of the Andes, Granaderos, Mendoza, or the dream of independence.");
                }
            }

            base.OnSpeech(e);
        }

        public JoseDeSanMartin(Serial serial) : base(serial) { }

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
