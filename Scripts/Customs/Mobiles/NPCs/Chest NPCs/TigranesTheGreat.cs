using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("the remains of Tigranes the Great")]
    public class TigranesTheGreat : BaseCreature
    {
        private DateTime lastRewardTime;

        [Constructable]
        public TigranesTheGreat() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tigranes the Great";
            Body = 0x190; // Human male body

            // Stats
            Str = 105;
            Dex = 75;
            Int = 100;
            Hits = 80;

            // Unique Appearance
            AddItem(new FancyShirt() { Name = "Imperial Tunic of Tigranes", Hue = 1281 });
            AddItem(new FancyKilt() { Name = "Golden Kilt of Greater Armenia", Hue = 2207 });
            AddItem(new Cloak() { Name = "Cloak of Kingship", Hue = 1357 });
            AddItem(new WideBrimHat() { Name = "Tigranes’ Royal Diadem", Hue = 1172 });
            AddItem(new Sandals() { Name = "March of Tigranocerta", Hue = 2115 });
            AddItem(new BodySash() { Name = "Sash of the Euphrates", Hue = 1476 });
            AddItem(new Scimitar() { Name = "Sword of Armenian Triumph", Hue = 1149 });

            // Speech Hue
            SpeechHue = 2122;

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
                Say("I am Tigranes the Great, King of Kings and Lord of Armenia’s golden age.");
            }
            else if (speech.Contains("job"))
            {
                Say("I forged an empire from the rivers of Armenia to the heart of Syria. Some called me conqueror, others builder.");
            }
            else if (speech.Contains("health"))
            {
                Say("A king’s burdens are heavy, yet the flame of my people sustains me.");
            }
            else if (speech.Contains("empire"))
            {
                Say("My empire stretched from the Caspian to the Mediterranean. Power must be tempered with wisdom.");
            }
            else if (speech.Contains("king"))
            {
                Say("King of Kings, they named me. But my greatest joy was bringing unity and hope to Armenia.");
            }
            else if (speech.Contains("armen"))
            {
                Say("Armenia, land of mountains and song, where courage and sorrow are entwined.");
            }
            else if (speech.Contains("tigranocerta"))
            {
                Say("Tigranocerta, my shining city, built to be the jewel of Armenia and a crossroads of cultures.");
            }
            else if (speech.Contains("legacy"))
            {
                Say("Legacy is not in stone alone, but in the stories and spirit of a people. Seek the ancient treasures of Armenia, if you dare.");
            }
            else if (speech.Contains("rome"))
            {
                Say("Rome and Armenia—rivals and uneasy friends. I clashed with Lucullus, yet the future is written by those who dream beyond war.");
            }
            else if (speech.Contains("river"))
            {
                Say("The Euphrates and Araxes nourished my lands, as hope nourishes the hearts of my people.");
            }
            else if (speech.Contains("wisdom"))
            {
                Say("Seek wisdom not only in victory, but in the wounds of defeat. Even kings must learn humility.");
            }
            else if (speech.Contains("dream"))
            {
                Say("Dreams shape empires. My dream was a land where Armenians and all peoples prospered in peace.");
            }
            else if (speech.Contains("city"))
            {
                Say("A city is more than walls; it is the laughter, the struggles, and the songs of its people.");
            }
            else if (speech.Contains("mountain") || speech.Contains("mountains"))
            {
                Say("Armenia is a land of mountains—Ararat rises above all, a silent witness to our hopes and trials.");
            }
            else if (speech.Contains("ararat"))
            {
                Say("Mount Ararat, sacred and eternal, holds the legends of our ancestors and the promise of rebirth.");
            }
            else if (speech.Contains("ancestor") || speech.Contains("ancestors"))
            {
                Say("Our ancestors weathered storm and strife; their courage flows in the blood of every Armenian.");
            }
            else if (speech.Contains("strife") || speech.Contains("war"))
            {
                Say("War is the anvil upon which nations are forged—and sometimes shattered. My reign saw both triumph and loss.");
            }
            else if (speech.Contains("triumph") || speech.Contains("victory"))
            {
                Say("Victory is fleeting; true triumph lies in what we build that endures.");
            }
            else if (speech.Contains("loss"))
            {
                Say("Loss teaches humility. Even a King must bow before fate’s storms.");
            }
            else if (speech.Contains("fate"))
            {
                Say("Fate is a river we cannot turn. But we may choose how we sail its currents.");
            }
            else if (speech.Contains("caravan") || speech.Contains("trade"))
            {
                Say("Caravans crossed my empire, bearing silks, spices, and stories. Armenia has ever been a bridge between worlds.");
            }
            else if (speech.Contains("silk") || speech.Contains("spice") || speech.Contains("spices"))
            {
                Say("Silks shimmered in my court; spices from distant lands filled the air with promise.");
            }
            else if (speech.Contains("bridge"))
            {
                Say("Between east and west, Armenia endures—a bridge of commerce, culture, and kinship.");
            }
            else if (speech.Contains("culture"))
            {
                Say("Culture is the soul of a people. We sang, carved stone, and recorded wisdom so none would forget.");
            }
            else if (speech.Contains("stone"))
            {
                Say("Our stones speak: khachkars, fortresses, and churches—silent, steadfast, sacred.");
            }
            else if (speech.Contains("khachkar") || speech.Contains("khachkars"))
            {
                Say("A khachkar is a cross-stone, carved with faith and hope. They guard our roads and mark our memories.");
            }
            else if (speech.Contains("faith"))
            {
                Say("Faith endures in darkness and light. In my time, gods old and new walked side by side.");
            }
            else if (speech.Contains("god") || speech.Contains("gods"))
            {
                Say("From Aramazd to Christ, our land has known many gods. Yet hope and kindness unite us all.");
            }
            else if (speech.Contains("kindness"))
            {
                Say("A king’s true test is kindness to the lowly and the stranger. Even the mighty are judged by mercy.");
            }
            else if (speech.Contains("stranger"))
            {
                Say("Many strangers passed through my gates—some as friends, some as foes. All left stories behind.");
            }			
            else if (speech.Contains("queen"))
            {
                Say("My queen, Cleopatra of Pontus, was as fierce as any general. Our bond was forged in both love and ambition.");
            }
            else if (speech.Contains("crown"))
            {
                Say("The crown is heavy, a symbol of both glory and sacrifice.");
            }
            else if (speech.Contains("reward") || speech.Contains("chest"))
            {
                TimeSpan cooldown = TimeSpan.FromMinutes(20);
                if (DateTime.UtcNow - lastRewardTime < cooldown)
                {
                    Say("Treasures must be earned and patience is a kingly virtue. Return when the sun has moved on.");
                }
                else
                {
                    Say("For your curiosity and valor, I present the Treasure Chest of Armenia. May it remind you of ancient glory and enduring spirit.");
                    from.AddToBackpack(new TreasureChestOfArmenia());
                    lastRewardTime = DateTime.UtcNow;
                }
            }
            else if (speech.Contains("farewell") || speech.Contains("goodbye"))
            {
                Say("May Armenia’s ancient mountains watch over you, traveler.");
            }
            else
            {
                if (Utility.RandomDouble() < 0.10)
                {
                    Say("Ask me of empire, Tigranocerta, Rome, or the treasures of Armenia.");
                }
            }

            base.OnSpeech(e);
        }

        public TigranesTheGreat(Serial serial) : base(serial) { }

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
