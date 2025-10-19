using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{

	[CorpseName("the remains of Queen Zenobia")]
	public class ZenobiaOfPalmyra : BaseCreature
	{
		private DateTime lastRewardTime;

		[Constructable]
		public ZenobiaOfPalmyra() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
		{
			Name = "Queen Zenobia";
			Body = 0x191; // Female human body

			// Outfit (see above for detailed names & hues)
			AddItem(new FancyDress() { Name = "Imperial Robes of Palmyra", Hue = 2654 });
			AddItem(new Cloak() { Name = "Mantle of the Desert Empress", Hue = 2935 });
			AddItem(new BodySash() { Name = "Silken Sash of the Levant", Hue = 2301 });
			AddItem(new Sandals() { Name = "Pearled Sandals of the Queen", Hue = 2124 });
			AddItem(new Circlet() { Name = "Diadem of Zenobia", Hue = 1153 });
			AddItem(new Leafblade() { Name = "Blade of Palmyrene Resolve", Hue = 2847 });

			SpeechHue = 2075;
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
				Say("I am Zenobia, Queen of Palmyra, the desert jewel and sovereign of Syria.");
			}
			else if (speech.Contains("job"))
			{
				Say("I ruled over a vast realm in defiance of Rome, protector of Syria and its ancient heart.");
			}
			else if (speech.Contains("health"))
			{
				Say("My spirit is eternal, tempered by war and wisdom. I endure.");
			}
			else if (speech.Contains("palmyra"))
			{
				Say("Palmyra—city of columns and caravans—was my capital, the pearl of the desert.");
			}
			else if (speech.Contains("empire"))
			{
				Say("My empire stretched from Egypt to Anatolia. I challenged emperors and defied fate.");
			}
			else if (speech.Contains("rome"))
			{
				Say("Rome feared my ambition. Their legions came, but I did not kneel.");
			}
			else if (speech.Contains("rebellion"))
			{
				Say("It was not rebellion, but justice. A queen must rise when her people are chained.");
			}
			else if (speech.Contains("wisdom"))
			{
				Say("Wisdom is the compass of queens. I studied Greek, Aramaic, Latin, and strategy.");
			}
			else if (speech.Contains("desert"))
			{
				Say("The desert is my cradle and shield—harsh, beautiful, and free.");
			}
			else if (speech.Contains("caravan"))
			{
				Say("Caravans brought silks, spices, and tales from far lands to Palmyra’s gates.");
			}
			else if (speech.Contains("crown"))
			{
				Say("A crown is not gold—it is duty, sacrifice, and the will to protect one’s people.");
			}
			else if (speech.Contains("history"))
			{
				Say("History remembers the bold. Let it remember Palmyra, not in ruin, but in glory.");
			}
			else if (speech.Contains("legacy"))
			{
				Say("My legacy lies not in conquest, but in defiance—and in the freedom of my people.");
			}
			else if (speech.Contains("queen"))
			{
				Say("I was not born to rule, but I rose to protect my people when none else would. That is the heart of a queen.");
			}
			else if (speech.Contains("alexandria"))
			{
				Say("Alexandria fell to me without bloodshed. Its scholars and scrolls became a gift to Palmyra.");
			}
			else if (speech.Contains("philosophy"))
			{
				Say("I studied the Stoics and the Neoplatonists. A queen must sharpen both blade and mind.");
			}
			else if (speech.Contains("greek") || speech.Contains("latin") || speech.Contains("aramaic"))
			{
				Say("Yes, I spoke the tongues of trade and diplomacy. Words can conquer more than swords.");
			}
			else if (speech.Contains("aurelian"))
			{
				Say("Aurelian—the Roman Emperor who broke my armies but never my spirit. He respected me, even in chains.");
			}
			else if (speech.Contains("chains") || speech.Contains("captivity"))
			{
				Say("Though taken to Rome in golden chains, I walked with dignity. Defeat does not end a legacy.");
			}
			else if (speech.Contains("victory"))
			{
				Say("Victory is fleeting. But honor? That endures in every stone, every tale, every breath of desert wind.");
			}
			else if (speech.Contains("trade"))
			{
				Say("Trade was the lifeblood of Palmyra. Incense, silk, and glass passed through our gates to the world.");
			}
			else if (speech.Contains("glass"))
			{
				Say("Palmyrene glass sparkled like stars. Our artisans shaped light and sand into treasures.");
			}
			else if (speech.Contains("art"))
			{
				Say("Art reveals the soul of a nation. Palmyra's temples, mosaics, and statues speak across centuries.");
			}
			else if (speech.Contains("temple") || speech.Contains("temples"))
			{
				Say("The Temple of Bel stood at Palmyra’s heart—sacred and radiant. Even Rome envied its majesty.");
			}
			else if (speech.Contains("oracle"))
			{
				Say("The oracles warned me of Roman vengeance. I listened, but I chose defiance over fear.");
			}
			else if (speech.Contains("despair"))
			{
				Say("Despair is the weapon of tyrants. I offered my people pride, even in ruin.");
			}
			else if (speech.Contains("hope"))
			{
				Say("Hope is not weakness. It is rebellion against inevitability.");
			}
			else if (speech.Contains("freedom"))
			{
				Say("Freedom is carved by sacrifice. I offered mine so that others might live proud and unbound.");
			}			
			else if (speech.Contains("treasure") || speech.Contains("chest"))
			{
				TimeSpan cooldown = TimeSpan.FromMinutes(20);
				if (DateTime.UtcNow - lastRewardTime < cooldown)
				{
					Say("Even ancient treasures must rest between hands. Return later, noble soul.");
				}
				else
				{
					Say("Take this Treasure Chest of Ancient Syria. May its contents whisper of Palmyra’s past.");
					from.AddToBackpack(new TreasureChestOfAncientSyria());
					lastRewardTime = DateTime.UtcNow;
				}
			}
			else if (speech.Contains("farewell") || speech.Contains("goodbye"))
			{
				Say("Walk in wisdom, as the desert winds once carried my voice across empires.");
			}
			else
			{
				if (Utility.RandomDouble() < 0.10)
				{
					Say("Ask me of Palmyra, Rome, or the treasures of the Syrian sands.");
				}
			}

			base.OnSpeech(e);
		}

		public ZenobiaOfPalmyra(Serial serial) : base(serial) { }

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
