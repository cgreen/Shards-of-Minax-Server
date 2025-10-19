using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.CustomJewels.Properties
{
    // ---------------------------------------------------
    // Tyr Rune (+Special attack/defense: Stamina Drain)
    // ---------------------------------------------------
    public sealed class TyrRuneProperty : IJewelProperty
    {
        public string Id    => "TyrRune";
        public string Label => "Special: Stamina Drain";
        public int    Icon  => 0x1F14; // same icon as rune

        static TyrRuneProperty() => JewelPropertyRegistry.Get(""); // register

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.StamDrain);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.StamDrain);
        }
    }

    // ---------------------------------------------------
    // Ahm Rune (+Special attack/defense: Puff Of Smoke)
    // ---------------------------------------------------
    public sealed class AhmRuneProperty : IJewelProperty
    {
        public string Id    => "AhmRune";
        public string Label => "Special: Puff Of Smoke";
        public int    Icon  => 0x1F14;

        static AhmRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.PuffOfSmoke);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.PuffOfSmoke);
        }
    }

    // ---------------------------------------------------
    // Mor Rune (+Special attack/defense: Mind Drain)
    // ---------------------------------------------------
    public sealed class MorRuneProperty : IJewelProperty
    {
        public string Id    => "MorRune";
        public string Label => "Special: Mind Drain";
        public int    Icon  => 0x1F14;

        static MorRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.MindDrain);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.MindDrain);
        }
    }

    // ---------------------------------------------------
    // Mef Rune (+Special attack/defense: Gift of Health)
    // ---------------------------------------------------
    public sealed class MefRuneProperty : IJewelProperty
    {
        public string Id    => "MefRune";
        public string Label => "Special: Gift of Health";
        public int    Icon  => 0x1F14;

        static MefRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.GiftOfHealth);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.GiftOfHealth);
        }
    }

    // ---------------------------------------------------
    // Ylm Rune (Weapon: Vortex Strike, Shield: Spike Shield)
    // ---------------------------------------------------
    public sealed class YlmRuneProperty : IJewelProperty
    {
        public string Id    => "YlmRune";
        public string Label => "Special: Vortex Strike / Spike Shield";
        public int    Icon  => 0x1F14;

        static YlmRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.VortexStrike);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.SpikeShield);
        }
    }

    // ---------------------------------------------------
    // Kot Rune (+Special attack/defense: Paralyzing Fear)
    // ---------------------------------------------------
    public sealed class KotRuneProperty : IJewelProperty
    {
        public string Id    => "KotRune";
        public string Label => "Special: Paralyzing Fear";
        public int    Icon  => 0x1F14;

        static KotRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.ParalyzingFear);
            else if (target is BaseShield)
                XmlCustomDefenses.AddDefense(target, XmlCustomDefenses.SpecialDefenses.ParalyzingFear);
        }
    }

    // ---------------------------------------------------
    // Jor Rune (Weapon: Triple Slash)
    // ---------------------------------------------------
    public sealed class JorRuneProperty : IJewelProperty
    {
        public string Id    => "JorRune";
        public string Label => "Special: Triple Slash";
        public int    Icon  => 0x1F14;

        static JorRuneProperty() => JewelPropertyRegistry.Get("");

        public void Apply(Mobile crafter, object target)
        {
            if (target is BaseWeapon)
                XmlCustomAttacks.AddAttack(target, XmlCustomAttacks.SpecialAttacks.TripleSlash);
        }
    }
}
