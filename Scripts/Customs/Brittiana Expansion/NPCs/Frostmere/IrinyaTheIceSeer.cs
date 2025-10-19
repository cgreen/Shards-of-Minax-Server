/*
 * Scripts/Custom/DialogueSystem/IrinyaTheIceSeer.cs
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
    [CorpseName("the corpse of Irinya the Ice Seer")]
    public class IrinyaTheIceSeer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static IrinyaTheIceSeer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "IrinyaTheIceSeer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public IrinyaTheIceSeer()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Irinya the Ice Seer";
            Title = "Whisperer of the Obelisk";
            Body = 0x191; // Human female
            Hue = 0x47E; // Pale blue skin
            
            // Custom Outfit
            AddItem(new MonkRobe() { Name = "Veil of Winter’s Silence", Hue = 0x480 });
            AddItem(new FlowerGarland() { Name = "Frozen Blossom Circlet", Hue = 0x47B });
            AddItem(new BodySash() { Name = "Aurora Sash", Hue = 0x482 });
            AddItem(new FurBoots() { Name = "Snowdrift Boots", Hue = 0x495 });
            AddItem(new LeatherGloves() { Name = "Seer’s Touch", Hue = 0x47D });
            AddItem(new Cloak() { Name = "Mantle of Icy Dreams", Hue = 0x47C });
            AddItem(new MysticStaff() { Name = "Staff of Whispering Frost", Hue = 0x47A });

            HairItemID = 0x203C; // Long hair
            HairHue = 0x481; // Frosty silver

            // Attach random traits, vendor system, and loot
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public IrinyaTheIceSeer(Serial serial) : base(serial) { }

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
