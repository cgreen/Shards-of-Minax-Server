/*
 * Scripts/Custom/DialogueSystem/CaptainRhogarBlackwake.cs
 * Dialogue-driven pirate harbormaster. Sunreach Harbor questline.
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
    [CorpseName("the corpse of Captain Rhogar Blackwake")]
    public class CaptainRhogarBlackwake : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CaptainRhogarBlackwake()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CaptainRhogarBlackwake.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CaptainRhogarBlackwake()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.3, 0.4)
        {
            Name = "Captain Rhogar Blackwake";
            Title = "the Harbor Warlord";
            Body = 0x190; // Human male
            Hue = 0x83F;  // Tanned skin

            // Pirate/Harbor Master outfit (unique)
            AddItem(new TricorneHat() { Name = "Blackwake's Tricorne", Hue = 0x455 });
            AddItem(new Shirt() { Name = "Salt-Stained Shirt", Hue = 0x47E });
            AddItem(new BodySash() { Name = "Sash of Dock Authority", Hue = 0x59D });
            AddItem(new LeatherGloves() { Name = "Dockmaster's Grips", Hue = 0x497 });
            AddItem(new LongPants() { Name = "Harbor Slops", Hue = 0x967 });
            AddItem(new Boots() { Name = "Pirate's Sea Boots", Hue = 0x1BB });
            AddItem(new Cutlass() { Name = "Rhogar's Cutlass", Hue = 0x484 });
            AddItem(new HalfApron() { Name = "Smuggler's Apron", Hue = 0x4B0 });

            HairItemID = 0x203C; // Short hair
            HairHue = 0x466;     // Dark brown/black
            FacialHairItemID = 0x204B; // Full beard
            FacialHairHue = 0x466;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public CaptainRhogarBlackwake(Serial serial) : base(serial) { }

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
