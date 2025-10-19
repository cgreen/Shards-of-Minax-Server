/*
 * Scripts/Custom/DialogueSystem/ZahiraTheVeiledAlchemist.cs
 * Data-driven dialogue, custom outfit, Qasaria lore.
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
    [CorpseName("the corpse of Zahira the Veiled Alchemist")]
    public class ZahiraTheVeiledAlchemist : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ZahiraTheVeiledAlchemist()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ZahiraTheVeiledAlchemist.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ZahiraTheVeiledAlchemist()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zahira";
            Title = "the Veiled Alchemist";
            Body = 0x191; // Human female
            Hue = 0x847; // Subtle desert tan

            // Unique, lore-rich outfit pieces
            AddItem(new HoodedShroudOfShadows() { Name = "Dunesveil of the Exile", Hue = 0x8B5 });
            AddItem(new FancyDress() { Name = "Britannian Court Robes (Tarnished)", Hue = 0x482 });
            AddItem(new Cloak() { Name = "Desertmist Alchemist's Wrap", Hue = 0x8AC });
            AddItem(new BodySash() { Name = "Band of the Scorpion’s Sting", Hue = 0xA66 });
            AddItem(new Sandals() { Name = "Soft-Soled Sandwalkers", Hue = 0xB2B });
            AddItem(new LeatherGloves() { Name = "Stained Gauntlets of Vials", Hue = 0x96A });
            AddItem(new WoodlandBelt() { Name = "Apothecary’s Pouchbelt", Hue = 0x940 });

            HairItemID = 0x203C; // long hair w/ tail
            HairHue = 0x455; // jet black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            // Optionally add alchemy wares for sale here
        }

        public ZahiraTheVeiledAlchemist(Serial serial) : base(serial) { }

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
