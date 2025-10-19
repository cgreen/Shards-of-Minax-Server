// Scripts/CustomPoisons/Effects/Helpers/StatDrainTimer.cs
using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPoisons.Effects.Helpers
{
    public enum StatToDrain { Mana, Stam }

    public class StatDrainTimer : Timer
    {
        private Mobile m_Defender;
        private int m_DrainPerTick;
        private StatToDrain m_StatType;

        public StatDrainTimer(Mobile defender, int totalTicks, TimeSpan interval, int drainPerTick, StatToDrain statType) 
            : base(interval, interval, totalTicks)
        {
            m_Defender = defender;
            m_DrainPerTick = drainPerTick;
            m_StatType = statType;
            Priority = TimerPriority.FiftyMS;
        }

        protected override void OnTick()
        {
            if (m_Defender != null && m_Defender.Alive && !m_Defender.Deleted)
            {
                switch(m_StatType)
                {
                    case StatToDrain.Mana:
                        if (m_Defender.Mana > 0) 
                        {
                            m_Defender.Mana -= Math.Min(m_DrainPerTick, m_Defender.Mana);
                            m_Defender.FixedParticles(0x374A, 1, 15, 5022, 0x05, 0, EffectLayer.Head); // Blue sparkles
                        }
                        break;
                    case StatToDrain.Stam:
                        if (m_Defender.Stam > 0)
                        {
                            m_Defender.Stam -= Math.Min(m_DrainPerTick, m_Defender.Stam);
                            m_Defender.FixedParticles(0x374A, 1, 15, 5006, 0x34, 0, EffectLayer.Waist); // Yellow sparkles
                        }
                        break;
                }
            }
            else
            {
                Stop();
            }
        }
    }
}