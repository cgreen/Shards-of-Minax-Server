// EvaluateSosariaEntry.cs
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Regions.Sosaria;

public class EvaluateSosariaEntry : ContextMenuEntry
{
    private readonly Mobile m_From;
    private readonly SosariaRandomNPC m_NPC;

    public EvaluateSosariaEntry(Mobile from, SosariaRandomNPC npc)
        : base(6125, 3) // 6125 = “Evaluate”, 3 = menu order :contentReference[oaicite:0]{index=0}
    {
        m_From = from;
        m_NPC  = npc;
    }

    public override void OnClick()
    {
        if (m_From.CheckTargetSkill(SkillName.EvalInt, m_NPC, 0, 200))
        {
            m_From.SendGump(new EvaluateSosariaGump(m_From, m_NPC));
        }
        else
        {
            m_From.SendMessage("You cannot make sense of their nature.");
        }
    }
}
