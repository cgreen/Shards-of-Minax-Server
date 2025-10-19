/*
 * Scripts/Custom/DialogueSystem/CorrenTheShardTouched.cs
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
    [CorpseName("the corpse of Corren the Shard-Touched")]
    public class CorrenTheShardTouched : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CorrenTheShardTouched()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CorrenTheShardTouched.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CorrenTheShardTouched()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Corren the Shard-Touched";
            Title = "of Eldermoor";
            Body = 0x190; // Human male
            Hue = 0x847; // Slightly otherworldly skin tone

            AddItem(new Robe() { Name = "Tattered Starweave Robe", Hue = 0x488 });
            AddItem(new BodySash() { Name = "Gem-Touched Sash", Hue = 0x48F });
            AddItem(new ClothNinjaHood() { Name = "Worn Traveler’s Hood", Hue = 0x46D });
            AddItem(new Circlet() { Name = "Shard-Fractured Circlet", Hue = 0x845 });
            AddItem(new Obi() { Name = "Runic Amulet", Hue = 0xB4F });

            HairItemID = 0x203B;
            HairHue = 0x47E;
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public CorrenTheShardTouched(Serial serial) : base(serial) { }

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
