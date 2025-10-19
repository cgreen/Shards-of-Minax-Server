/*
 * Scripts/Custom/DialogueSystem/TahliaGreenFlame.cs
 * Interactive dialogue, custom tribal outfit, Verdant warband quests.
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
    [CorpseName("the corpse of Tahlia the Green Flame")]
    public class TahliaGreenFlame : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TahliaGreenFlame()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TahliaGreenFlame.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TahliaGreenFlame()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tahlia";
            Title = "of the Green Flame";
            Body = 0x191; // Human female
            Hue = 0x840; // Tanned

            // Distinctive tribal outfit
            AddItem(new TribalMask() { Name = "Mask of the Green Flame", Hue = 0x7A3 });
            AddItem(new FurSarong() { Name = "Hunter's Fur Sarong", Hue = 0x845 });
            AddItem(new LeatherBustierArms() { Name = "Verdant Armguard", Hue = 0x59D });
            AddItem(new LeatherSuneate() { Name = "Hunter's Greaves", Hue = 0x7C6 });
            AddItem(new Sandals() { Name = "Ash-Runner Sandals", Hue = 0x59D });
            AddItem(new Cloak() { Name = "Emberleaf Cloak", Hue = 0x56B });

            HairItemID = 0x203C; // Braided
            HairHue = 0x453; // Dark green
            FacialHairItemID = 0; // none

            // Wields a unique spear
            AddItem(new ShortSpear() { Name = "Flame-Tipped Spear", Hue = 0x54C });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public TahliaGreenFlame(Serial serial) : base(serial) { }

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
