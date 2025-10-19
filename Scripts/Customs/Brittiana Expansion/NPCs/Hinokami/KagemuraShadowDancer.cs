/*
 * Scripts/Custom/DialogueSystem/KagemuraShadowDancer.cs
 * Fox-masked kabuki actor, illusionist, and quest-giver for Hinokami.
 */

using System.IO;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Custom.Dialogue;
using Server.Engines.XmlSpawner2;
using Server.Custom;

namespace Server.Mobiles
{
    [CorpseName("the body of Kagemura")]
    public class KagemuraShadowDancer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KagemuraShadowDancer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KagemuraShadowDancer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KagemuraShadowDancer()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kagemura the Shadow Dancer";
            Title = "Kabuki Fox Spirit";
            Body = 0x190; // Male human
            Hue = 0x47E; // Pale/ghostly

            // Unique, theatrical and mystical Japanese-style outfit
            AddItem(new TribalMask() { Name = "Fox Spirit Mask", Hue = 0x47F });
            AddItem(new MaleKimono() { Name = "Kabuki Kimono of Illusions", Hue = 0x482 });
            AddItem(new Obi() { Name = "Silken Obi of Shifting Colors", Hue = 0xB88 });
            AddItem(new Cloak() { Name = "Cloak of Dancing Shadows", Hue = 0x455 });
            AddItem(new Waraji() { Name = "Braided Sandals", Hue = 0x5E2 });
            AddItem(new Hakama() { Name = "Wide Hakama Trousers", Hue = 0x845 });
            AddItem(new MeditationFans() { Name = "Twin Fans of Mist", Hue = 0x481 });

            HairItemID = 0x2049; // Topknot
            HairHue = 0x455; // Black
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public KagemuraShadowDancer(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile pm)
            {
                var root = _dialogue.GetModule("greeting");
                pm.SendGump(new XMLDialogueGump(pm, root, _dialogue));
            }
        }

        public override void Serialize(GenericWriter w) { base.Serialize(w); w.Write(0); }
        public override void Deserialize(GenericReader r) { base.Deserialize(r); r.ReadInt(); }
    }
}
