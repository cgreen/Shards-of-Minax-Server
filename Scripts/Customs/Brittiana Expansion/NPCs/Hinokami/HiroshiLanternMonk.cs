/*
 * Scripts/Custom/DialogueSystem/HiroshiLanternMonk.cs
 * Data-driven dialogue, ritual event hook, and anti-Minax lore.
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
    [CorpseName("the corpse of Hiroshi")]
    public class HiroshiLanternMonk : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HiroshiLanternMonk()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HiroshiLanternMonk.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HiroshiLanternMonk()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hiroshi";
            Title = "the Lantern Monk";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Custom monk outfit (Japanese/ritual flavor)
            AddItem(new MonkRobe() { Name = "Sunset Monk’s Robe", Hue = 0x43E });
            AddItem(new Obi() { Name = "Lantern Sash", Hue = 0x47F });
            AddItem(new Waraji() { Name = "Straw Waraji", Hue = 0x422 });
            AddItem(new FlowerGarland() { Name = "Garland of Dawn", Hue = 0x481 });
            AddItem(new CampingLanturn() { Name = "Sacred Lantern", Hue = 0x482 });

            HairItemID = 0x203C; // topknot
            HairHue = 0x47F;     // dark brown
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public HiroshiLanternMonk(Serial serial) : base(serial) { }

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
