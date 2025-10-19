/*
 * Scripts/Custom/DialogueSystem/JessaThornveil.cs
 * Data-driven dialogue, custom outfit, identity-shifting, Aerilon lore.
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
    [CorpseName("the corpse of Jessa Thornveil")]
    public class JessaThornveil : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static JessaThornveil()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "JessaThornveil.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public JessaThornveil()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Jessa Thornveil";
            Title = "the Maskwright & Illusionist";
            Body = 0x191; // Human female (will swap gender with masks!)
            Hue = 0x840; // Iridescent pale

            // Signature shifting mask — always present
            AddItem(new TribalMask() { Name = "The Veil of Thousand Faces", Hue = 0x482 });

            // Flamboyant, unique outfit
            AddItem(new FancyShirt() { Name = "Sable-Satin Chemise of Mutable Moods", Hue = 0x7AF });
            AddItem(new BodySash() { Name = "Opaline Sash of Persona-Shifting", Hue = 0xB65 });
            AddItem(new Kilt() { Name = "Vesper Silk Kilt of Dramatic Flair", Hue = 0x530 });
            AddItem(new Cloak() { Name = "Shifting Cloak of Gossamer Whispers", Hue = 0x47E });
            AddItem(new JesterShoes() { Name = "Harlequin Boots of Many Steps", Hue = 0x485 });
            AddItem(new LeatherGloves() { Name = "Illusionist’s Hands of Silk & Shade", Hue = 0x495 });

            // Hair: shifting color
            HairItemID = 0x203B; // Long hair
            HairHue = 0x47F; // Pale blue

            // Genderfluid detail: wears both male and female pieces, refers to self in mixed pronouns.

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public JessaThornveil(Serial serial) : base(serial) { }

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
