/*
 * Scripts/Custom/DialogueSystem/BozuFisherPoet.cs
 * Data-driven dialogue, custom outfit, poetic flavor, quest clues.
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
    [CorpseName("the corpse of Bozu")]
    public class BozuFisherPoet : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BozuFisherPoet()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BozuFisherPoet.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BozuFisherPoet()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bozu";
            Title = "the Fisher-Poet";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Lore-rich fisherman’s outfit (Japanese aesthetic)
            AddItem(new StrawHat() { Name = "Fisherman's Kasa", Hue = 0x4E2 });
            AddItem(new MaleKimono() { Name = "Kimono of Still Waters", Hue = 0x8B4 });
            AddItem(new Hakama() { Name = "Hakama of Quiet Reeds", Hue = 0x8A8 });
            AddItem(new Obi() { Name = "Obi of River's Breath", Hue = 0x47E });
            AddItem(new Sandals() { Name = "Reed Woven Sandals", Hue = 0x847 });
            AddItem(new HalfApron() { Name = "Fishing Apron", Hue = 0x58B });

            // Fishing pole for flavor, poetic prop
            AddItem(new ShepherdsCrook() { Name = "Aged Fishing Rod", Hue = 0x840 });

            HairItemID = 0x203C; // Topknot
            HairHue = 0x453; // Black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public BozuFisherPoet(Serial serial) : base(serial) { }

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
