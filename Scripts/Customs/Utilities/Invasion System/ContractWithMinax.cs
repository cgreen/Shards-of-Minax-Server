using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Commands;
using Server.Customs.Invasion_System;

namespace Server.Customs.Invasion_System
{
    [Flipable(0x14F0, 0x14EF)] // Parchment scroll graphics
    public class ContractWithMinax : Item
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public InvasionTowns Town { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public TownMonsterType Monster { get; private set; }

        [Constructable]
        public ContractWithMinax() : base(0x14F0)
        {
            Name = "Contract With Minax";
            Weight = 1.0;

            // Randomize town and monster on creation
            Town = (InvasionTowns)Utility.Random(Enum.GetValues(typeof(InvasionTowns)).Length);
            Monster = (TownMonsterType)Utility.Random(Enum.GetValues(typeof(TownMonsterType)).Length);
        }

        public ContractWithMinax(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version

            writer.Write((int)Town);
            writer.Write((int)Monster);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            Town = (InvasionTowns)reader.ReadInt();
            Monster = (TownMonsterType)reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("That must be in your backpack.");
                return;
            }

            from.CloseGump(typeof(ContractWithMinaxGump));
            from.SendGump(new ContractWithMinaxGump(from, this));
        }

        public void Activate(Mobile from)
        {
            var champ = (TownChampionType)Utility.Random(Enum.GetValues(typeof(TownChampionType)).Length);

            TownInvasion invasion = new TownInvasion(Town, Monster, champ, DateTime.UtcNow);
            invasion.OnStart(); // Start immediately

            Delete(); // Consume the contract
            from.SendMessage(38, $"Minax’s forces march on {Town}!");
        }
    }

	public class ContractWithMinaxGump : Gump
	{
		private readonly Mobile _from;
		private readonly ContractWithMinax _scroll;

		public ContractWithMinaxGump(Mobile from, ContractWithMinax scroll)
			: base(200, 150)
		{
			_from = from;
			_scroll = scroll;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddBackground(0, 0, 300, 180, 9270); // wider for spacing
			AddLabel(90, 15, 1153, "Contract With Minax");

			AddLabel(30, 60, 54, $"Invasion Type: {_scroll.Monster}");
			AddLabel(30, 85, 54, $"Target Town: {_scroll.Town}");

			// OK / Start button
			AddButton(40, 130, 247, 248, 1, GumpButtonType.Reply, 0);

			// Cancel button
			AddButton(180, 130, 241, 242, 0, GumpButtonType.Reply, 0);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				_scroll.Activate(_from);
			}
		}
	}

}
