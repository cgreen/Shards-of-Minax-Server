/*
 * Scripts/Custom/DialogueSystem/MasterKenjiHayabusa.cs
 * Data-driven dialogue, custom outfit, Hinokami dojo lore.
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
    [CorpseName("the corpse of Master Kenji Hayabusa")]
    public class MasterKenjiHayabusa : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MasterKenjiHayabusa()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MasterKenjiHayabusa.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MasterKenjiHayabusa()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.3, 0.5)
        {
            Name = "Master Kenji Hayabusa";
            Title = "the Swordmaster";
            Body = 0x190; // Human male
            Hue = 0x83F; // Light tan

            // Iconic Ronin/Samurai outfit
            AddItem(new ClothNinjaHood() { Name = "Warrior's Hachimaki", Hue = 0x497 });
            AddItem(new MaleKimono() { Name = "Kimono of the Falling Blade", Hue = 0x47E });
            AddItem(new Obi() { Name = "Obi of Iron Resolve", Hue = 0x51C });
            AddItem(new Hakama() { Name = "Battle Hakama", Hue = 0x2C1 });
            AddItem(new SamuraiTabi() { Name = "Tabi of Discipline", Hue = 0x455 });
            AddItem(new LeatherDo() { Name = "Reinforced Do", Hue = 0x497 });
            AddItem(new Katana() { Name = "Master’s Katana", Hue = 0x47E });

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // dark brown
            FacialHairItemID = 0x2040; // goatee
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MasterKenjiHayabusa(Serial serial) : base(serial) { }

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
