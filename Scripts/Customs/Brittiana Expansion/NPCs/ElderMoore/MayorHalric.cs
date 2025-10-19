/*
 * Scripts/Custom/DialogueSystem/MayorHalric.cs
 * Minimal example – now 100 % data‑driven dialogue.
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
    [CorpseName("the corpse of Mayor Halric")]
    public class MayorHalric : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MayorHalric()
        {
            /* one‑time file load when the class is first referenced */
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MayorHalric.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MayorHalric()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mayor Halric of the Old Ways";
            Title = "of Eldermoor";
            Body = 0x190; // Human male
            Hue = 0x835;

            AddItem(new FancyShirt() { Hue = 0x497 });
            AddItem(new LongPants() { Hue = 0x59B });
            AddItem(new HalfApron() { Hue = 0x4B5 });
            AddItem(new Cloak() { Hue = 0x96D });
            AddItem(new Boots() { Hue = 0x455 });
            AddItem(new WideBrimHat() { Hue = 0x966 });

            HairItemID = 0x203B;
            HairHue = 0x453;
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x453;
			
			XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
			SpecialLootHelper.AddLoot(this);	//add traits, vendor system, and random loot	
        }

        public MayorHalric(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile pm)
            {
                var root = _dialogue.GetModule("greeting");   // entry node id
                pm.SendGump(new XMLDialogueGump(pm, root, _dialogue));
            }
        }

        public override void Serialize(GenericWriter w) { base.Serialize(w); w.Write(0); }
        public override void Deserialize(GenericReader r) { base.Deserialize(r); r.ReadInt(); }
    }
}
