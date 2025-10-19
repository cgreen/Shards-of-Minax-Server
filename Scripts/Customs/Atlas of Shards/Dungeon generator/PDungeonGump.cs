using System.Linq;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;         // MagicMapBase
using Server.Engines.ProceduralDungeon;
using Server.Network;


namespace Server.Engines.ProceduralDungeon
{
    public class PDungeonGump : Gump
    {
        private readonly PlayerMobile    _user;
        private readonly IMapBlueprint[] _choices;

        public PDungeonGump(PlayerMobile user) : base(100, 100)
        {
            _user = user;

            // 1) Wrap every MagicMapBase in the backpack:
            var dynamic = user.Backpack.Items
                .OfType<MagicMapBase>()
                .Select(mm => (IMapBlueprint)new MagicMapItemBlueprint(mm));

            // 2) All your code-only blueprints:
            var statics = MapBlueprintRegistry.All;

            _choices = dynamic.Concat(statics).ToArray();

            // layout
            int width  = 260, height = 30 + _choices.Length * 40;
            AddBackground(0, 0, width, height, 9250);
            AddLabel(70, 10, 0x34, "Select Map");

            int y = 40;
            for (int i = 0; i < _choices.Length; i++)
            {
                var bp = _choices[i];
                AddLabel (30, y, 1152, bp.DisplayName);
                AddButton(200, y, 0x819, 0x81A, i + 1, GumpButtonType.Reply, 0);
                y += 40;
            }
        }

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			int idx = info.ButtonID - 1;
			if (idx < 0 || idx >= _choices.Length) 
				return;

			var bp = _choices[idx];

			// ——— Classic MagicMapBase scroll? ———
			if (bp is MagicMapItemBlueprint mbp
			 && !(mbp.MapItem is IProvidesTiles))  // classic has no terrain hook
			{
				var scroll = mbp.MapItem;
				scroll.Internalize();  // take it out of the pack

				new ClassicMagicMapBlueprint(scroll, _user)
					.Activate(PDungeonController.Instance);

				return;
			}

			// ——— Procedural maps (terrain + content) ———
			MagicMapBase usedScroll = null;
			if (bp is MagicMapItemBlueprint p)
			{
				usedScroll = p.MapItem;
				usedScroll.Internalize();
			}

			foreach (var pad in PDungeonController.Instance.Instances)
			{
				if (pad.TryStart(_user, bp))
					return;  // launched successfully
			}

			// No free pads: give back scroll if we took one
			if (usedScroll != null)
				usedScroll.MoveToWorld(_user.Location, _user.Map);

			_user.SendMessage("All map devices are busy – please wait.");
		}


    }
}
