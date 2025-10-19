// Scripts/CustomPoisons/Effects/Helpers/LingeringDamageTimer.cs
using System;
using Server;
using Server.Mobiles;

namespace Server.CustomPoisons.Effects.Helpers
{
    public class LingeringDamageTimer : Timer
    {
        private Mobile m_Defender;
        private Mobile m_Attacker;
        private int m_DamagePerTick;
        private int m_DamageTypePhys, m_DamageTypeFire, m_DamageTypeCold, m_DamageTypePois, m_DamageTypeNrgy;

        public LingeringDamageTimer(Mobile defender, Mobile attacker, int totalTicks, TimeSpan interval, int damagePerTick, 
                                    int phys, int fire, int cold, int pois, int nrgy) 
            : base(interval, interval, totalTicks)
        {
            m_Defender = defender;
            m_Attacker = attacker;
            m_DamagePerTick = damagePerTick;
            m_DamageTypePhys = phys;
            m_DamageTypeFire = fire;
            m_DamageTypeCold = cold;
            m_DamageTypePois = pois;
            m_DamageTypeNrgy = nrgy;

            Priority = TimerPriority.FiftyMS;
        }

        protected override void OnTick()
        {
            if (m_Defender != null && m_Defender.Alive && !m_Defender.Deleted)
            {
                AOS.Damage(m_Defender, m_Attacker, m_DamagePerTick, m_DamageTypePhys, m_DamageTypeFire, m_DamageTypeCold, m_DamageTypePois, m_DamageTypeNrgy);
                m_Defender.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist); // Example: Blood particles or generic hit
            }
            else
            {
                Stop();
            }
        }
    }
}