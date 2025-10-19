/*
 * Scripts/Custom/DialogueSystem/EjanStonehowl.cs
 * Verdant Tribes, shamanic lore, ritual quest
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
    [CorpseName("the corpse of Ejan Stonehowl")]
    public class EjanStonehowl : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EjanStonehowl()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EjanStonehowl.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EjanStonehowl()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ejan Stonehowl";
            Title = "the Beast-Caller";
            Body = 0x190; // Human male
            Hue = 0x839;  // earthy brown skin

            // Distinct, shamanic Verdant tribal outfit
            AddItem(new TribalMask() { Name = "Mask of the Moonlit Hunt", Hue = 0x835 });
            AddItem(new FurSarong() { Name = "Fur Sarong of the Spirit Grove", Hue = 0x96F });
            AddItem(new WoodlandChest() { Name = "Carved Bark Chestguard", Hue = 0x853 });
            AddItem(new LeatherArms() { Name = "Trophied Beast Leather Arms", Hue = 0x966 });
            AddItem(new WoodlandGloves() { Name = "Gloves of Root and Vine", Hue = 0x96C });
            AddItem(new Sandals() { Name = "Forest Treader Sandals", Hue = 0x6A4 });
            AddItem(new BodySash() { Name = "Howler’s Sash", Hue = 0x964 });
            AddItem(new WildStaff() { Name = "Totemic Howler Staff", Hue = 0x967 });

            HairItemID = 0x203C; // ponytail
            HairHue = 0x455;     // dark brown hair
            FacialHairItemID = 0x2041; // medium beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public EjanStonehowl(Serial serial) : base(serial) { }

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
