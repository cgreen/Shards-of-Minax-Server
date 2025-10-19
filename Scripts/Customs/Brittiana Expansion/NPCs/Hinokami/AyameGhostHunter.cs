/*
 * Scripts/Custom/DialogueSystem/AyameGhostHunter.cs
 * Data-driven dialogue, custom outfit, supernatural investigations in Hinokami.
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
    [CorpseName("the corpse of Ayame the Ghost-Hunter")]
    public class AyameGhostHunter : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AyameGhostHunter()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AyameGhostHunter.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AyameGhostHunter()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ayame";
            Title = "the Ghost-Hunter";
            Body = 0x191; // Human female
            Hue = 0x47E; // Pale skin

            // Outfit: Traditional, practical, ghost-hunting vibe
            AddItem(new FemaleKimono() { Name = "Ghost-Hunter's Kimono", Hue = 0x497 }); // Icy blue-grey
            AddItem(new Obi() { Name = "Embroidered Spirit Sash", Hue = 0x7B2 }); // Deep purple
            AddItem(new SamuraiTabi() { Name = "Tracker's Tabi", Hue = 0x1BB });
            AddItem(new ClothNinjaHood() { Name = "Yokai Stalker Hood", Hue = 0x9C4 });
            AddItem(new LeatherGloves() { Name = "Blessed Prayer Gloves", Hue = 0x5BE });
            AddItem(new ShortSpear() { Name = "Jitte of Spirit-Binding", Hue = 0x482 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x455; // Black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public AyameGhostHunter(Serial serial) : base(serial) { }

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
