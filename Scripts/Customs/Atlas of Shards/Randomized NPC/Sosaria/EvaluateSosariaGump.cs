// EvaluateSosariaGump.cs
using System;
using System.Linq;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Regions.Sosaria;

public class EvaluateSosariaGump : Gump
{
    // same breakpoints as the generic version :contentReference[oaicite:1]{index=1}
    private static readonly (int threshold, int count)[] _levels = new (int, int)[]
    {
        (50,  1),
        (75,  2),
        (100, 3),
        (150, 4),
        (175, 5),
        (200, int.MaxValue)
    };

    public EvaluateSosariaGump(Mobile viewer, SosariaRandomNPC npc)
        : base(50, 50)
    {
        int skill    = (int)viewer.Skills[SkillName.EvalInt].Value;
        int maxTraits = _levels.Where(l => skill >= l.threshold)
                                .Select(l => l.count)
                                .DefaultIfEmpty(0)
                                .Max();

        var traitNames = npc.Traits.Select(t => t.Name).ToList();
        int toShow     = Math.Min(maxTraits, traitNames.Count);

        AddPage(0);
        AddBackground(0, 0, 250, 30 + (toShow * 20), 5054);
        AddLabel(10, 10, 0, $"Sosarian Evaluation ({skill:0} EvalInt)");

        if (toShow == 0)
        {
            AddLabel(10, 30, 38, "You glean no clear Sosarian traits.");
        }
        else
        {
            for (int i = 0; i < toShow; i++)
                AddLabel(10, 30 + i * 20, 0, $"- {traitNames[i]}");
        }

        AddButton(180, 5, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);
    }
}
