/*
 * Scripts/Custom/DialogueSystem/VokarBonecrafter.cs
 * Verdant Tribes bone artisan with secret trade ties to Hinokami.
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
    [CorpseName("the corpse of Vokar the Bonecrafter")]
    public class VokarBonecrafter : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VokarBonecrafter()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VokarBonecrafter.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VokarBonecrafter()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Vokar";
            Title = "the Bonecrafter";
            Body = 0x190; // Human male
            Hue = 0x83E; // Tanned, earthy

            // Tribal, primal, artisan outfit (fitting bone worker)
            AddItem(new TribalMask() { Name = "Mask of the Horned Hunter", Hue = 0x457 });
            AddItem(new BoneChest() { Name = "Boneworker's Hauberk", Hue = 0x47C });
            AddItem(new BoneGloves() { Name = "Carver's Gauntlets", Hue = 0x47E });
            AddItem(new FurSarong() { Name = "Pelt-Wrapped Kilt", Hue = 0x453 });
            AddItem(new LeatherSuneate() { Name = "Hunter's Leggings", Hue = 0x3D2 });
            AddItem(new Sandals() { Name = "Barefoot Sandals", Hue = 0x430 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // Dark brown
            FacialHairItemID = 0x204B; // beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            // (Optional) Add bonecraft wares if using custom vendor
        }

        public VokarBonecrafter(Serial serial) : base(serial) { }

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
