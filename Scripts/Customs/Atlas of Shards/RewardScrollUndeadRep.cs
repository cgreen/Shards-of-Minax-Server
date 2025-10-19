using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.CustomItems
{
    public class RewardScrollUndeadRep : Item
    {
        [Constructable]
        public RewardScrollUndeadRep() : base(0x14F0) // Looks like a scroll
        {
            Name = "Scroll of Undead Allegiance";
            Hue = 1150; // Darkish hue, thematically undead
            LootType = LootType.Blessed;
            Weight = 1.0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("The scroll must be in your backpack to use it.");
                return;
            }

            // Get or create the XmlMobFactions attachment
            var factionAttachment = XmlAttach.FindAttachment(from, typeof(XmlMobFactions)) as XmlMobFactions;

            if (factionAttachment == null)
            {
                factionAttachment = new XmlMobFactions();
                XmlAttach.AttachTo(from, factionAttachment);
            }

            // Increase Undead reputation
            int amount = 5000;
            factionAttachment.Undead += amount;

            from.SendMessage(61, $"You feel a dark power acknowledge you. (+{amount} Undead reputation)");

            Delete(); // Consume the scroll
        }

        // Serialization
        public RewardScrollUndeadRep(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
