/*
 * Scripts/Custom/DialogueSystem/TolanDrift.cs
 * Fully data-driven dialogue, unique outfit, Airfleet captain of Aerilon
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
    [CorpseName("the corpse of Tolan Drift")]
    public class TolanDrift : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TolanDrift()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TolanDrift.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TolanDrift()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tolan Drift";
            Title = "Skyship Captain of Aerilon";
            Body = 0x190; // Human male
            Hue = 0x47E;  // Light blue skin tint, matching the city's theme

            // Unique Airfleet Outfit
            AddItem(new FancyShirt() { Name = "Skyfarer's Azure Doublet", Hue = 0x8B3 });         // Bright blue, silk-trimmed
            AddItem(new LongPants() { Name = "Aether-Woven Sashpants", Hue = 0x481 });           // Pale silver-blue
            AddItem(new Boots() { Name = "Stormrider’s Winged Boots", Hue = 0x497 });            // Deep indigo, silver buckles
            AddItem(new Cloak() { Name = "Cloudweave Cloak of the Airfleet", Hue = 0xB94 });     // Azure-fade, lined with white
            AddItem(new WizardsHat() { Name = "Captain's Zephyr Hat", Hue = 0x1B6 });            // Sky blue, white feather
            AddItem(new BodySash() { Name = "Skyship Command Sash", Hue = 0x9C2 });              // Cerulean, gold clasp

            // Accessories & Style
            HairItemID = 0x203C;
            HairHue = 0x47E;
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x47E;

            // Signature weapon: Ornate Skyship Compass (as MagicWand)
            AddItem(new MagicWand() { Name = "Ornate Skyship Compass", Hue = 0x48F });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public TolanDrift(Serial serial) : base(serial) { }

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
