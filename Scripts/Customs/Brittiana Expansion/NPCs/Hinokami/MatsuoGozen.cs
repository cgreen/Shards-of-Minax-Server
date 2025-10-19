/*
 * Scripts/Custom/DialogueSystem/MatsuoGozen.cs
 * Data-driven dialogue, custom outfit, Hinokami lore.
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
    [CorpseName("the corpse of Matsuo Gozen")]
    public class MatsuoGozen : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MatsuoGozen()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MatsuoGozen.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MatsuoGozen()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Matsuo Gozen";
            Title = "retired onna-bugeisha";
            Body = 0x191; // Human female
            Hue = 0x455; // Subtle, tanned

            // Custom, iconic Hinokami attire (samurai & feminine grace)
            AddItem(new FemaleKimono() { Name = "Silken Kimono of the Crimson Bloom", Hue = 0x485 });
            AddItem(new Obi() { Name = "Obi of Hidden Blades", Hue = 0x53D });
            AddItem(new Waraji() { Name = "Woven Waraji", Hue = 0x497 });
            AddItem(new Tessen() { Name = "Fan of Silent Steel", Hue = 0x47E }); // Concealed dagger fan
            AddItem(new LeatherDo() { Name = "Embroidered Leather Do", Hue = 0x5E2 }); // Traditional armor touch

            HairItemID = 0x203B; // long hair
            HairHue = 0x466; // dark, elegant
            // Optionally add FlowerGarland or JinBaori for local color

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public MatsuoGozen(Serial serial) : base(serial) { }

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
