/*
 * Scripts/Custom/DialogueSystem/MarjanStormEye.cs
 * Data-driven dialogue, custom outfit, Sunreach lore.
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
    [CorpseName("the corpse of Marjan Storm-Eye")]
    public class MarjanStormEye : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MarjanStormEye()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MarjanStormEye.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MarjanStormEye()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Marjan Storm-Eye";
            Title = "the retired corsair";
            Body = 0x190; // Human male
            Hue = 0x835;  // Weathered, tanned

            // Outfit - retired, but hints of pirate past and current barkeep
            AddItem(new Shirt() { Name = "Salt-stained Tunic", Hue = 0x967 });
            AddItem(new HalfApron() { Name = "Tavern Apron", Hue = 0x8A5 });
            AddItem(new LeatherGloves() { Name = "Weathered Leather Gloves", Hue = 0x96D });
            AddItem(new Boots() { Name = "Sturdy Boots", Hue = 0x712 });
            AddItem(new TricorneHat() { Name = "Storm-Eye's Tricorne", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Corsair’s Red Sash", Hue = 0x21 });
            AddItem(new Cutlass() { Name = "Old Corsair's Cutlass", Movable = false, Hue = 0x835 });
            // Optional: Eye patch? If supported in your server.

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // dark brown
            FacialHairItemID = 0x203F; // short beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MarjanStormEye(Serial serial) : base(serial) { }

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
