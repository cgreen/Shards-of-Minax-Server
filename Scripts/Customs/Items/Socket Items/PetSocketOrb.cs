using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class PetSocketOrb : Item
    {
        [Constructable]
        public PetSocketOrb() : base(0x1AE2) // Orb-like item graphic
        {
            Weight = 1.0;
            Name = "a pet socket orb";
            LootType = LootType.Blessed;
        }

        public PetSocketOrb(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            from.SendMessage("Which pet would you like to socket?");
            from.Target = new InternalTarget(this);
        }

        private class InternalTarget : Target
        {
            private PetSocketOrb m_Orb;

            public InternalTarget(PetSocketOrb orb) : base(10, false, TargetFlags.None)
            {
                m_Orb = orb;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Orb.Deleted || !m_Orb.IsChildOf(from.Backpack))
                {
                    from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                    return;
                }

                if (targeted is BaseCreature pet && pet.Controlled && pet.ControlMaster == from)
                {
                    if (XmlAttach.FindAttachment(pet, typeof(XmlSocketable)) != null)
                    {
                        from.SendMessage("That pet is already socketable.");
                    }
                    else
                    {
                        XmlAttach.AttachTo(pet, new XmlSocketable(6));
                        XmlAttach.AttachTo(pet, new XmlSockets(6));

                        from.SendMessage("Your pet is now socketable with 6 sockets.");
                        m_Orb.Delete();
                    }
                }
                else
                {
                    from.SendMessage("That is not your pet.");
                }
            }
        }
    }
}
