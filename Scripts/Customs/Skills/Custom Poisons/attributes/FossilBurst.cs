using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class FossilBurst : IPoisonEffect
    {
        public string Id    => "FossilBurst";
        public string Label => "Fossil Burst";
        public int SoundId  => 0x665;

        private static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        private static readonly int MinDamage = 200;
        private static readonly int MaxDamage = 300;

        static FossilBurst()
        {
            PoisonEffectRegistry.Register(new FossilBurst());
        }

        public void Visual(Mobile owner)
        {
            if (owner == null)
                return;

            owner.PublicOverheadMessage(MessageType.Emote, 0x3B2, true, "* Unleashes ancient energy *");
            owner.PlaySound(SoundId);
            owner.FixedEffect(0x36BD, 20, 10);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || attacker.Map == null || DateTime.UtcNow < _nextAllowed)
                return;

            Visual(attacker);

            List<Mobile> targets = new List<Mobile>();
            IPooledEnumerable eable = attacker.GetMobilesInRange(5);

            foreach (Mobile m in eable)
            {
                if (m != attacker && attacker.CanBeHarmful(m))
                    targets.Add(m);
            }

            eable.Free();

            foreach (Mobile m in targets)
            {
                int damage = Utility.RandomMinMax(MinDamage, MaxDamage);
                AOS.Damage(m, attacker, damage, 100, 0, 0, 0, 0);

                m.SendLocalizedMessage(1070844); // Aura effect message

                ResistanceMod mod = new ResistanceMod(ResistanceType.Physical, -20);
                m.AddResistanceMod(mod);

                Timer.DelayCall(TimeSpan.FromSeconds(10), () =>
                {
                    m.RemoveResistanceMod(mod);
                    m.SendLocalizedMessage(1070845); // Resistance returned
                });
            }

            _nextAllowed = DateTime.UtcNow + Cooldown;
        }
    }
}
