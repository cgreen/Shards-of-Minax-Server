/*
 * Scripts/Custom/DialogueSystem/NimaThornweaver.cs
 * Data-driven dialogue, custom outfit, Verdant lore.
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
    [CorpseName("the corpse of Nima the Thornweaver")]
    public class NimaThornweaver : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NimaThornweaver()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NimaThornweaver.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NimaThornweaver()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nima the Thornweaver";
            Title = "Forest Guardian";
            Body = 0x191; // Human female
            Hue = 0x83F;  // earthy brown-green

            // Distinct Verdant tribal outfit:
            AddItem(new WoodlandChest() { Name = "Thornwoven Vest", Hue = 0x59B });
            AddItem(new WoodlandArms() { Name = "Vinewrapped Bracers", Hue = 0x59B });
            AddItem(new WoodlandLegs() { Name = "Rootbound Leggings", Hue = 0x59B });
            AddItem(new WoodlandGloves() { Name = "Gloves of the Thicket", Hue = 0x59B });
            AddItem(new TribalMask() { Name = "Thornmask of the Verdant", Hue = 0x54F });
            AddItem(new BodySash() { Name = "Belt of Collected Thorns", Hue = 0x46A });
            AddItem(new Boots() { Name = "Mossy Boots", Hue = 0x7B0 });
            AddItem(new Scythe() { Name = "Thorncutter", Hue = 0x48B });

            HairItemID = 0x203B; // long hair
            HairHue = 0x7B0; // green
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public NimaThornweaver(Serial serial) : base(serial) { }

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
