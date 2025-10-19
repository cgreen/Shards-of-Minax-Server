using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Engines.XmlSpawner2;
using Server.Customs.Invasion_System;

namespace Server.Customs.Invasion_System
{
    public class FactionHonorCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("FactionHonor", AccessLevel.GameMaster, e =>
            {
                e.Mobile.SendGump(new FactionHonorListGump(e.Mobile));
            });
        }
    }

    /* -------------------- Main List Gump -------------------- */
    public class FactionHonorListGump : Gump
    {
        private Mobile _from;

        public FactionHonorListGump(Mobile from) : base(50, 50)
        {
            _from = from;

            AddPage(0);
            AddBackground(0, 0, 350, 40 + (Enum.GetValues(typeof(XmlMobFactions.GroupTypes)).Length * 25), 9270);
            AddLabel(110, 10, 53, "Faction Honor Levels"); // Yellow title

            int y = 40;
            foreach (XmlMobFactions.GroupTypes g in Enum.GetValues(typeof(XmlMobFactions.GroupTypes)))
            {
                if (g == XmlMobFactions.GroupTypes.End_Unused) continue;

                int honor = FactionHonorSystem.Get(g);

                AddLabel(20, y, 53, $"{g}");        // Yellow faction name
                AddLabel(180, y, 53, $"{honor}");   // Yellow honor value

                AddButton(280, y, 4005, 4007, (int)g + 1, GumpButtonType.Reply, 0);

                y += 25;
            }
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID <= 0) return;

            var g = (XmlMobFactions.GroupTypes)(info.ButtonID - 1);
            _from.SendGump(new FactionHonorEditGump(_from, g));
        }
    }

    /* -------------------- Edit Gump -------------------- */
    public class FactionHonorEditGump : Gump
    {
        private Mobile _from;
        private XmlMobFactions.GroupTypes _group;

        public FactionHonorEditGump(Mobile from, XmlMobFactions.GroupTypes group) : base(100, 100)
        {
            _from = from;
            _group = group;

            int current = FactionHonorSystem.Get(group);

            AddPage(0);
            AddBackground(0, 0, 300, 150, 9270);
            AddLabel(90, 20, 53, $"{group} Honor");      // Yellow header
            AddLabel(30, 60, 53, "Current:");
            AddLabel(120, 60, 53, current.ToString());

            AddLabel(30, 90, 53, "New Value:");
            AddTextEntry(120, 90, 120, 20, 0, 1, current.ToString());

            AddButton(60, 120, 4005, 4007, 1, GumpButtonType.Reply, 0); // OK
            AddButton(180, 120, 4005, 4007, 2, GumpButtonType.Reply, 0); // Cancel
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1)
            {
                string text = info.GetTextEntry(1)?.Text?.Trim();
                if (int.TryParse(text, out int newValue))
                {
                    FactionHonorSystem.Set(_group, newValue);
                    _from.SendMessage(68, $"{_group} honor set to {newValue}");
                }
                else
                {
                    _from.SendMessage(33, "Invalid number entered.");
                }

                _from.SendGump(new FactionHonorListGump(_from));
            }
            else
            {
                _from.SendGump(new FactionHonorListGump(_from));
            }
        }
    }
}
