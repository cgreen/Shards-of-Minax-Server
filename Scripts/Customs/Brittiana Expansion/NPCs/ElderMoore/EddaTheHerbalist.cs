/*
 * Scripts/Custom/DialogueSystem/EddaTheHerbalist.cs
 * Richly detailed, quest-giving dialogue NPC.
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
    [CorpseName("the corpse of Edda the Herbalist")]
    public class EddaTheHerbalist : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EddaTheHerbalist()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EddaTheHerbalist.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EddaTheHerbalist()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Edda the Herbalist";
            Title = "of Eldermoor";
            Body = 0x191; // Human female
            Hue = 0x841;

            // Unique Outfit
            AddItem(new FancyShirt() { Name = "Sageleaf Chemise", Hue = 0x59C }); // Moss green
            AddItem(new Skirt() { Name = "Marshmist Skirt", Hue = 0x47E });       // Soft teal-blue
            AddItem(new HoodedShroudOfShadows() { Name = "Druid’s Whisper Hood", Hue = 0x485 }); // Faded pine
            AddItem(new HalfApron() { Name = "Patchwork Herb Apron", Hue = 0x972 }); // Earthy brown
            AddItem(new Sandals() { Name = "Bogwalker Sandals", Hue = 0x453 }); // Muddy gray-green
            AddItem(new BodySash() { Name = "Willow Talisman Sash", Hue = 0x481 }); // Pale willow
            AddItem(new Bag() { Name = "Edda’s Herb Satchel", Hue = 0x59C }); // For flavor

            HairItemID = 0x203C;
            HairHue = 0x455; // White-gray
            // No facial hair for female by default

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public EddaTheHerbalist(Serial serial) : base(serial) { }

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
