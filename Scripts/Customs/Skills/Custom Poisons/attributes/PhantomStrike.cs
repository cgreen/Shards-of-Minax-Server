// Scripts/CustomPoisons/Effects/PhantomStrike.cs
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.CustomPoisons.Effects
{
    public sealed class PhantomStrike : IPoisonEffect
    {
        public string Id    => "PhantomStrike";
        public string Label => "Phantom Strike";
        public int SoundId  => 0x229; // Optional: Use a ghostly or blade-type sound, or change it

        private static readonly TimeSpan Refractory = TimeSpan.FromSeconds(30);
        private static DateTime _nextAllowed = DateTime.UtcNow;

        static PhantomStrike() => PoisonEffectRegistry.Register(new PhantomStrike());

        public void Visual(Mobile defender)
        {
            if (defender == null) return;

            defender.FixedParticles(0x37C4, 10, 15, 5044, 0x481, 0, EffectLayer.CenterFeet);
            defender.PlaySound(SoundId);
            defender.SendMessage("You feel a sudden chill as something strikes from behind!");
        }

        public void Apply(Mobile attacker, Mobile defender)
        {
            if (attacker == null || defender == null || DateTime.UtcNow < _nextAllowed)
                return;

            // Try to teleport attacker behind the defender (1 tile away in a random direction)
            Point3D behind = new Point3D(
                defender.X + Utility.RandomMinMax(-1, 1),
                defender.Y + Utility.RandomMinMax(-1, 1),
                defender.Z
            );

            if (defender.Map != null && defender.Map.CanSpawnMobile(behind))
            {
                attacker.Location = behind;
            }

            int damage = Utility.RandomMinMax(20, 75); // Match XML behavior

            defender.Damage(damage, attacker);
            Visual(defender);

            _nextAllowed = DateTime.UtcNow + Refractory;
        }
    }
}
