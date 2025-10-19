using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Gumps;
using Server.Mobiles;
using TraitSystem;
using CustomNPC;  // for ITraitHolder
using Server.ContextMenus;

namespace CustomNPC
{
    public class EvaluateTraitsGump : Gump
    {
        private struct BreakPoint
        {
            public int Threshold;
            public int Lines;
            public BreakPoint(int th, int ln) { Threshold = th; Lines = ln; }
        }

        // as in the original RandomNpcBase gump…
        private static readonly BreakPoint[] _breaks = new[]
        {
            new BreakPoint( 50, 1),
            new BreakPoint( 75, 2),
            new BreakPoint(100, 3),
            new BreakPoint(150, 4),
            new BreakPoint(175, 5),
            new BreakPoint(200, int.MaxValue)
        };

        private readonly Mobile _viewer;
        private readonly ITraitHolder _holder;
        private readonly List<ITrait> _traits;

        /// <summary>
        /// New constructor: accept any ITraitHolder (your RandomNpcBase *or* RandomTraitDynamicVendorBase).
        /// </summary>
        public EvaluateTraitsGump(Mobile viewer, ITraitHolder holder)
            : base(50, 50)
        {
            _viewer = viewer;
            _holder = holder;
            _traits = holder.Traits;

            int skill = (int)viewer.Skills[SkillName.EvalInt].Value;
            int linesToShow = _breaks.Where(bp => skill >= bp.Threshold)
                                     .Max(bp => bp.Lines);

            var list = _traits.Select(t => t.Name)
                              .Take(linesToShow)
                              .ToList();

            AddPage(0);
            AddBackground(0, 0, 250, 30 + list.Count * 20, 5054);
            AddLabel(10, 10, 0, $"Evaluation ({skill:0})");

            if (list.Count == 0)
            {
                AddLabel(10, 30, 38, "Nothing revealed.");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                    AddLabel(10, 30 + i * 20, 0, "- " + list[i]);
            }

            AddButton(180, 5, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);
        }
    }

    public class EvaluateTraitsEntry : ContextMenuEntry
    {
        private readonly Mobile _from;
        private readonly ITraitHolder _holder;

        public EvaluateTraitsEntry(Mobile from, ITraitHolder holder)
            : base(6125, 3) // “Talk” icon
        {
            _from   = from;
            _holder = holder;
        }

        public override void OnClick()
        {
            if (_from.CheckTargetSkill(SkillName.EvalInt, _holder as Mobile, 0, 200))
                _from.SendGump(new EvaluateTraitsGump(_from, _holder));
            else
                _from.SendMessage("You cannot discern anything.");
        }
    }
}
