/*
 * Scripts/Custom/DialogueSystem/ShogunRyujiTakamura.cs
 * Data-driven dialogue, custom samurai outfit, Hinokami lore.
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
    [CorpseName("the body of Shogun Ryuji Takamura")]
    public class ShogunRyujiTakamura : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ShogunRyujiTakamura()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ShogunRyujiTakamura.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ShogunRyujiTakamura()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Shogun Ryuji Takamura";
            Title = "of Hinokami";
            Body = 0x190; // Human male
            Hue = 0x83EA;

            // Samurai-inspired, formal Hinokami warlord outfit
            AddItem(new Kamishimo() { Name = "Shogun's Kamishimo of Authority", Hue = 0x497 });
            AddItem(new TattsukeHakama() { Name = "Ironwoven Tattsuke Hakama", Hue = 0x96C });
            AddItem(new Obi() { Name = "Obi of the Three Pillars", Hue = 0x4F2 });
            AddItem(new SamuraiTabi() { Name = "Shogun's Tabi", Hue = 0x47E });
            AddItem(new LightPlateJingasa() { Name = "Shogunal Jingasa", Hue = 0x516 });
            AddItem(new LeatherDo() { Name = "Do-maru of Vigilance", Hue = 0x6D6 });
            AddItem(new Katana() { Name = "Takamura's Katana", Hue = 0x484, Movable = false });

            HairItemID = 0x203B; // long hair (chonmage-style)
            HairHue = 0x455; // dark black
            FacialHairItemID = 0x203F; // thin beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ShogunRyujiTakamura(Serial serial) : base(serial) { }

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
