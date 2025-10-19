/*
 * Scripts/Custom/DialogueSystem/XMLDialogueGump.cs
 */
using Server.Gumps;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Dialogue;
using System;

namespace Server.Custom.Dialogue
{
    public class XMLDialogueGump : Gump
    {
        private readonly DialogueModule _module;
        private readonly DialogueManager _mgr;
        private readonly PlayerMobile _player;

        public XMLDialogueGump(PlayerMobile player, DialogueModule module, DialogueManager mgr) 
            : base(100, 100)
        {
            _player = player;
            _module = module;
            _mgr    = mgr;

            Closable  = true;
            Disposable= true;
            Dragable  = true;

            AddPage(0);
			// Outer gump background
			AddBackground(0, 0, 800, 700, 9270);

			// New background box for NPC dialogue
			AddBackground(30, 30, 740, 220, 9400); // Changed background ID and padding

			// NPC text inside the new background
			AddHtml(40, 40, 720, 200, 
				$"<BODY><BASEFONT COLOR=\"#ADD8E6\">{_module.NpcText}</BASEFONT></BODY>", 
				false, true);

            int y = 260;
            for (int i = 0; i < _module.Options.Count; i++)
            {
                var opt = _module.Options[i];
                if (!opt.Condition(_player))
                    continue;

                AddButton(40, y, 4005, 4007, i + 1, GumpButtonType.Reply, 0);
                AddHtml(110, y, 650, 80,
                    $"<BODY><BASEFONT COLOR=\"#32CD32\">{opt.Text}</BASEFONT></BODY>", false, false);
                y += 30;
            }
        }

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID <= 0)
				return;

			int idx = info.ButtonID - 1;
			if (idx < 0 || idx >= _module.Options.Count)
				return;

			var opt = _module.Options[idx];

			// run the action
			try
			{
				opt.Action?.Invoke(_player);
			}
			catch (Exception ex)
			{
				_player.SendMessage("An error occurred running that dialogue action.");
				Console.WriteLine($"[ERROR][Dialogue] {ex}: Error running dialogue action for NPC");
			}

			// chain to next dialogue (if any)
			if (!string.IsNullOrWhiteSpace(opt.NextModuleId))
			{
				var next = _mgr.GetModule(opt.NextModuleId);
				if (next != null)
				{
					_player.SendGump(new XMLDialogueGump(_player, next, _mgr));
				}
				else
				{
					_player.SendMessage("…Hmm, something went wrong with that conversation path. Please let an admin know.");
					// optionally close the gump or reopen the root module instead:
					// var root = _mgr.GetModule("questIntro"); 
					// if (root != null) _player.SendGump(new XMLDialogueGump(_player, root, _mgr));
				}
			}
		}

    }
}
