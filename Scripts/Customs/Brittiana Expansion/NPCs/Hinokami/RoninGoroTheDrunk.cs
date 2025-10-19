/*
 * Scripts/Custom/DialogueSystem/RoninGoroTheDrunk.cs
 * Data-driven dialogue, unique Tokuno exile outfit, Hinokami lore.
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
    [CorpseName("the corpse of Ronin Goro")]
    public class RoninGoroTheDrunk : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static RoninGoroTheDrunk()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "RoninGoroTheDrunk.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public RoninGoroTheDrunk()
            : base(AIType.AI_Berserk, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ronin Goro";
            Title = "the Drunk";
            Body = 0x190; // Human male
            Hue = 0x83E;  // Light skin

            // Loreful, ragged Tokuno exile outfit
            AddItem(new MaleKimono() { Name = "Tattered Kimono of Exile", Hue = 0x455 });
            AddItem(new Obi() { Name = "Wine-stained Sash", Hue = 0x31 });
            AddItem(new ClothNinjaHood() { Name = "Lopsided Ronin Hood", Hue = 0x497 });
            AddItem(new Waraji() { Name = "Muddy Waraji", Hue = 0x453 });
            AddItem(new Bottle() { Name = "Cheap Sake Jug", Hue = 0x481 });
            AddItem(new Wakizashi() { Name = "Nicked Wakizashi", Hue = 0x3E2 }); // Sheathed

            HairItemID = 0x2047; // messy short
            HairHue = 0x46E; // Black
            FacialHairItemID = 0x203C; // scraggly beard
            FacialHairHue = 0x46E; 

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public RoninGoroTheDrunk(Serial serial) : base(serial) { }

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
