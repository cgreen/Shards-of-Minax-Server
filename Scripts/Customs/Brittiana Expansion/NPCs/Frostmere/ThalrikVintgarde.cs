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
    [CorpseName("the corpse of Thalrik Vintgarde")]
    public class ThalrikVintgarde : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ThalrikVintgarde()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ThalrikVintgarde.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ThalrikVintgarde()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Thalrik Vintgarde";
            Title = "the Polite Hermit";
            Body = 0x190; // Human male
            Hue = 0x47E; // Frostbitten pallor

            // Unique Outfit
            AddItem(new FurSarong() { Name = "Chillbone Sarong", Hue = 0x482 });
            AddItem(new HoodedShroudOfShadows() { Name = "Hermit’s Shadow Hood", Hue = 0x497 });
            AddItem(new BearMask() { Name = "Frostbear Mask", Hue = 0x47F });
            AddItem(new Cloak() { Name = "Winter’s Embrace Cloak", Hue = 0x481 });
            AddItem(new FurBoots() { Name = "Caribou-hide Boots", Hue = 0x430 });
            AddItem(new VivisectionKnife() { Name = "Iceforged Vivisection Knife", Hue = 0x48B });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x430; // Frosty grey
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x430;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this); // random loot, traits, etc.
        }

        public ThalrikVintgarde(Serial serial) : base(serial) { }

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
