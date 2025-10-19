/*
 * Scripts/Custom/DialogueSystem/TavrosKren.cs
 * Data-driven dialogue, custom outfit, Lost Shards lore.
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
    [CorpseName("the crumpled remains of Tavros Kren")]
    public class TavrosKren : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TavrosKren()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TavrosKren.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TavrosKren()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tavros Kren";
            Title = "Historian of Lost Shards";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Unique, lore-rich explorer-scholar outfit
            AddItem(new WizardsHat() { Name = "Hat of Cartographer's Dread", Hue = 0x481 });
            AddItem(new FancyShirt() { Name = "Shirt of Thousand Scripts", Hue = 0x1A5 });
            AddItem(new BodySash() { Name = "Sash of Anxious Maps", Hue = 0xB79 });
            AddItem(new Cloak() { Name = "Cloak of Lost Destinies", Hue = 0x59B });
            AddItem(new LeatherGloves() { Name = "Scrollbinder's Grips", Hue = 0x977 });
            AddItem(new LongPants() { Name = "Dust-Stained Scholar’s Trousers", Hue = 0x857 });
            AddItem(new Boots() { Name = "Wayfarer’s Mud-Caked Boots", Hue = 0x840 });
            AddItem(new GnarledStaff() { Name = "Scepter of Shard-Seeking", Hue = 0x48D });

            HairItemID = 0x2044; // wild hair
            HairHue = 0x47D; // copper
            FacialHairItemID = 0x203F; // bushy beard
            FacialHairHue = 0x47D;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public TavrosKren(Serial serial) : base(serial) { }

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
