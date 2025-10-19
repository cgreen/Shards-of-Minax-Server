using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.CustomPoisons.Effects
{
    public sealed class ChillTouch : IPoisonEffect
    {
        public string Id    => "ChillTouch";
        public string Label => "Chill Touch";
        public int SoundId  => 0x1FB;

        private const double TriggerChance = 0.15;
        private const int Damage = 40;
        private const double AttackSpeedReduction = 0.15;
        private static readonly TimeSpan EffectDuration = TimeSpan.FromSeconds(15);

        static ChillTouch() => PoisonEffectRegistry.Register(new ChillTouch());

        public void Visual(Mobile defender)
        {
			Server.Effects.SendLocationParticles(
				EffectItem.Create(defender.Location, defender.Map, EffectItem.DefaultDuration),
				0x374A, 10, 30, 1154, 0, 0, 0);

            defender.PlaySound(SoundId);
            defender.SendMessage("You feel a chilling force slow your movements!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            if (Utility.RandomDouble() > TriggerChance)
                return;

            defender.Damage(Damage, attacker);
            Visual(defender);
            attacker.Say("Chilled!");

            if (defender is BaseCreature bc)
            {
                // Apply slow effect
                double slowFactor = 1 + AttackSpeedReduction;
                bc.CurrentSpeed *= slowFactor;

                Timer.DelayCall(EffectDuration, () =>
                {
                    if (!bc.Deleted)
                        bc.CurrentSpeed /= slowFactor;
                });
            }

            // Optional: Handle slowing for players if needed
        }
    }
}
