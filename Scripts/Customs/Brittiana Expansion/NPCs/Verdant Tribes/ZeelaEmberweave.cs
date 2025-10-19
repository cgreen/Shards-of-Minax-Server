/*
 * Scripts/Custom/DialogueSystem/ZeelaEmberweave.cs
 * Data-driven dialogue, custom outfit, Verdant Tribes lore.
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
    [CorpseName("the body of Zeela Emberweave")]
    public class ZeelaEmberweave : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ZeelaEmberweave()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ZeelaEmberweave.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ZeelaEmberweave()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zeela Emberweave";
            Title = "the Fire Keeper";
            Body = 0x191; // Human female
            Hue = 0x840;  // Earthy skin

            // Custom outfit: tribal, mystical, fire motif
            AddItem(new FancyDress() { Name = "Emberwoven Gown", Hue = 0x486 });
            AddItem(new Cloak() { Name = "Ashen Shawl", Hue = 0x968 });
            AddItem(new Sandals() { Name = "Spiritwalker's Sandals", Hue = 0x475 });
            AddItem(new TribalMask() { Name = "Mask of Ember Spirits", Hue = 0x66D });
            AddItem(new BodySash() { Name = "Sash of the Everflame", Hue = 0x51E });

            HairItemID = 0x203C; // long wavy hair
            HairHue = 0x47E; // white/silver

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ZeelaEmberweave(Serial serial) : base(serial) { }

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
