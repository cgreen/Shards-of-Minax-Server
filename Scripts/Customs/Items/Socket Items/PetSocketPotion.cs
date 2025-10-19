using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class PetSocketPotion : Item
    {
        [Constructable]
        public PetSocketPotion() : base(0x0F06) // 0x0F06 = standard potion graphic
        {
            Weight = 1.0;
            Name = "Pet Socket Potion";
            LootType = LootType.Blessed;
        }

        public PetSocketPotion(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // Must be in your pack
                return;
            }

            from.SendMessage("Target the pet you wish to socket...");
            from.Target = new PetTarget(this);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt(); // version
        }

        private class PetTarget : Target
        {
            private readonly PetSocketPotion _potion;

            public PetTarget(PetSocketPotion potion) : base(12, false, TargetFlags.None)
            {
                _potion = potion;
            }

            protected override void OnTarget(Mobile from, object target)
            {
                if (!(target is BaseCreature pet) || pet.ControlMaster != from)
                {
                    from.SendMessage("That is not your pet."); // ownership check
                    return;
                }

                // Attach or find existing XmlSocketable
                var sock = XmlAttach.FindAttachment(pet, typeof(XmlSocketable)) as XmlSocketable;
                if (sock == null)
                {
                    XmlAttach.AttachTo(pet, new XmlSocketable());
                    sock = XmlAttach.FindAttachment(pet, typeof(XmlSocketable)) as XmlSocketable;
                }

                // Configure the sockets
                sock.MaxSockets       = 3;   // allow up to 3 sockets
                sock.ResourceQuantity = 50;  // cost per socket in resources
                // sock.ResourceType = typeof(Emerald); // optional: set specific resource type

                from.SendMessage("The potion glows as sockets form on your pet!");
                _potion.Delete();  // consume the potion
            }
        }
    }
}
