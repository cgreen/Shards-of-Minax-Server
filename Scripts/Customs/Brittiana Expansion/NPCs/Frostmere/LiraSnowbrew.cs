/*
 * Scripts/Custom/DialogueSystem/LiraSnowbrew.cs
 * Fully data-driven dialogue. See Data/Dialogues/LiraSnowbrew.xml.
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
    [CorpseName("the corpse of Lira Snowbrew")]
    public class LiraSnowbrew : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LiraSnowbrew()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LiraSnowbrew.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LiraSnowbrew()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Lira Snowbrew";
            Title = "the Alchemical Innkeeper";
            Body = 0x191; // Human female
            Hue = 0x47E;

            // Unique outfit, all with custom names and hues:
            AddItem(new FancyShirt()    { Name = "Brewmist Bodice",         Hue = 0x47F });
            AddItem(new Skirt()         { Name = "Frosted Barmaid Skirt",   Hue = 0x47B });
            AddItem(new HalfApron()     { Name = "Alchemist's Iceveil",     Hue = 0x482 });
            AddItem(new Cloak()         { Name = "Snowmelt Cloak",          Hue = 0x48A });
            AddItem(new Boots()         { Name = "Stormleather Boots",      Hue = 0x495 });
            AddItem(new FlowerGarland() { Name = "Winterspring Garland",    Hue = 0x482 });
            AddItem(new BodySash()      { Name = "Crystalbrew Sash",        Hue = 0x47F });

            HairItemID = 0x203C;
            HairHue = 0x481;

            // Attach features and vendor ability
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LiraSnowbrew(Serial serial) : base(serial) { }

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
