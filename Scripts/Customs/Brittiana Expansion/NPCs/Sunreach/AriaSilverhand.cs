/*
 * Scripts/Custom/DialogueSystem/AriaSilverhand.cs
 * Data-driven dialogue, custom archaeologist outfit, spy/quest dialogue tree.
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
    [CorpseName("the corpse of Aria Silverhand")]
    public class AriaSilverhand : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AriaSilverhand()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AriaSilverhand.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AriaSilverhand()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Aria Silverhand";
            Title = "the Archaeologist-Spy";
            Body = 0x191; // Human female
            Hue = 0x47E;

            // Unique explorer/spy outfit, practical yet stylish
            AddItem(new FancyShirt() { Name = "Dust-Stained Explorer's Shirt", Hue = 0x945 });
            AddItem(new LeatherNinjaPants() { Name = "Shadow-Tailored Leggings", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sash of Shifting Allegiance", Hue = 0xB21 });
            AddItem(new Cloak() { Name = "Desert-Wind Cloak", Hue = 0x1F2 });
            AddItem(new Boots() { Name = "Sandwalker's Boots", Hue = 0x715 });
            AddItem(new LeatherGloves() { Name = "Silver-Tipped Gloves", Hue = 0x47E });
            AddItem(new Bandana() { Name = "Scout’s Bandana", Hue = 0x47E });

            // Her tool: GnarledStaff as an explorer's walking stick
            AddItem(new GnarledStaff() { Name = "Runic Surveyor’s Staff", Hue = 0x483 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47E; // silver/white
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public AriaSilverhand(Serial serial) : base(serial) { }

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
