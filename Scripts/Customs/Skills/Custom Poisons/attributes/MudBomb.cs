using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Engines.XmlSpawner2;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class MudBomb : IPoisonEffect
    {
        public string Id    => "MudBomb";
        public string Label => "Mud Bomb";
        public int SoundId  => 0x145;
		public void Visual(Mobile defender) { }		

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(20);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static MudBomb() => PoisonEffectRegistry.Register(new MudBomb());

        public void Visual(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null)
                return;

            attacker.PublicOverheadMessage(MessageType.Emote, 0x3B2, true, "* Throws a glob of mud *");
            attacker.PlaySound(SoundId);
            attacker.Direction = attacker.GetDirectionTo(defender);
            attacker.MovingEffect(defender, 0xF0D, 7, 1, false, false);
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (DateTime.UtcNow < _nextAllowed)
                return;

            if (attacker == null || defender == null || !defender.Alive)
                return;

            Visual(attacker, defender);

            Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
            {
                if (defender != null && defender.Alive)
                {
                    defender.Freeze(TimeSpan.FromSeconds(3));
                    defender.FixedEffect(0x376A, 9, 32);
                    defender.PlaySound(0x201);
                    AOS.Damage(defender, attacker, Utility.RandomMinMax(15, 125), 100, 0, 0, 0, 0);
                }
            });

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
