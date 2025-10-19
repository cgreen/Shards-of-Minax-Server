/*
 * Scripts/Custom/DialogueSystem/ZaraGhostBlade.cs
 * Legendary mercenary NPC, unique outfit, Qasaria lore, dynamic quest hooks.
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
    [CorpseName("the fallen Ghost Blade")]
    public class ZaraGhostBlade : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ZaraGhostBlade()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ZaraGhostBlade.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ZaraGhostBlade()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zara";
            Title = "the Ghost Blade";
            Body = 0x191; // Human female
            Hue = 0x482; // pale, almost spectral

            // Unique, lore-heavy outfit
            AddItem(new StuddedBustierArms() { Name = "Spiritbound Vest of the Nameless", Hue = 0x47E });
            AddItem(new LeatherNinjaPants() { Name = "Whisperstep Shin-guards", Hue = 0x455 });
            AddItem(new BodySash() { Name = "Sash of Silent Oaths", Hue = 0x1F7 });
            AddItem(new HoodedShroudOfShadows() { Name = "Ghostwalker’s Shroud", Hue = 0x481 });
            AddItem(new NinjaTabi() { Name = "Shadefoot Boots", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Phantom’s Grasp", Hue = 0x481 });
            AddItem(new AssassinSpike() { Name = "Wraithsteel Dagger", Hue = 0x4A7 });
            AddItem(new Cloak() { Name = "Veil of Forgotten Blood", Hue = 0x55D });

            HairItemID = 0x203C; // long flowing hair
            HairHue = 0x47E; // ghostly white/silver

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ZaraGhostBlade(Serial serial) : base(serial) { }

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
