/*
 * Scripts/Custom/DialogueSystem/EmberTheFragment.cs
 * NPC: Ember (the “Child”)
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
    [CorpseName("the still form of Ember")]
    public class EmberTheFragment : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EmberTheFragment()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EmberTheFragment.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EmberTheFragment()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ember";
            Title = "the Quiet Child";
            Body = 0x191; // Human female child
            Hue = 0x47E; // Ethereal pale

            AddItem(new FancyShirt() { Hue = 0x483, Name = "Shroud of Dreaming Shadows" });
            AddItem(new Skirt() { Hue = 0x497, Name = "Nightsoil Hem Skirt" });
            AddItem(new Cloak() { Hue = 0x4C2, Name = "Unraveling Twilight Cloak" });
            AddItem(new Sandals() { Hue = 0x47E, Name = "Soft-Footed Remnants" });
            AddItem(new FlowerGarland() { Hue = 0x482, Name = "Withered Memory Garland" });

            HairItemID = 0x203C; // Child’s hair
            HairHue = 0x453;     // Ashen black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public EmberTheFragment(Serial serial) : base(serial) { }

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
