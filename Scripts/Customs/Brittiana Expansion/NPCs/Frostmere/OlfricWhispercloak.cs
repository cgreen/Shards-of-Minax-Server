/*
 * Scripts/Custom/DialogueSystem/OlfricWhispercloak.cs
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
    [CorpseName("the corpse of Olfric Whispercloak")]
    public class OlfricWhispercloak : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OlfricWhispercloak()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OlfricWhispercloak.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OlfricWhispercloak()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Olfric \"Whispercloak\" Dane";
            Title = "the Voice-Stealer";
            Body = 0x190;
            Hue = 0x495;

            // Unique, named outfit
            AddItem(new HoodedShroudOfShadows() { Name = "Cowl of Vanished Voices", Hue = 0x455 });       // Soft black, dully iridescent
            AddItem(new LeatherNinjaJacket() { Name = "Muffling Jacket", Hue = 0x497 });                  // Charcoal gray, absorbs sound
            AddItem(new Hakama() { Name = "Sable Hakama", Hue = 0x400 });                                 // Faint blue-black, almost frostbitten
            AddItem(new LeatherNinjaMitts() { Name = "Whisperthief’s Gloves", Hue = 0x59B });             // Deep midnight blue, tips etched silver
            AddItem(new NinjaTabi() { Name = "Silent Step Tabi", Hue = 0x6D6 });                          // Ashen gray, wrapped for stealth
            AddItem(new Cloak() { Name = "Echo-Drinker Cloak", Hue = 0x497 });                            // Shadow-absorbing, flickers in torchlight
            AddItem(new AssassinSpike() { Name = "Murderer’s Soliloquy", Hue = 0x4F1 });                  // Ornate, etched with bardic runes

            HairItemID = 0x2048;
            HairHue = 0x46E;
            FacialHairItemID = 0;
            
            // Secret traits
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());

            SpecialLootHelper.AddLoot(this);
        }

        public OlfricWhispercloak(Serial serial) : base(serial) { }

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
