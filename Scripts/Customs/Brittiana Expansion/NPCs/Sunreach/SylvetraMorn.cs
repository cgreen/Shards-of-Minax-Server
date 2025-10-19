/*
 * Scripts/Custom/DialogueSystem/SylvetraMorn.cs
 * Mystic apothecary, shadowed past, Sunreach lore and quest.
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
    [CorpseName("the corpse of Sylvetra Morn")]
    public class SylvetraMorn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SylvetraMorn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SylvetraMorn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SylvetraMorn()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sylvetra Morn";
            Title = "the Mystic Apothecary";
            Body = 0x191; // Human female
            Hue = 0x46E;

            // Unique, loreful outfit
            AddItem(new HoodedShroudOfShadows() { Name = "Midnight Apothecary's Shroud", Hue = 0x497 });
            AddItem(new PlainDress() { Name = "Twilight Herbalist's Dress", Hue = 0x482 });
            AddItem(new BodySash() { Name = "Sash of Forgotten Oaths", Hue = 0x845 });
            AddItem(new Sandals() { Name = "Desert-Worn Sandals", Hue = 0x59C });
            AddItem(new LeatherGloves() { Name = "Healer's Touch", Hue = 0x48C });
            AddItem(new WoodlandBelt() { Name = "Satchel of Uncommon Remedies", Hue = 0x497 });

            HairItemID = 0x2048; // Long, wavy hair
            HairHue = 0x480; // Deep black
            FacialHairItemID = 0x0000; // none
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SylvetraMorn(Serial serial) : base(serial) { }

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
