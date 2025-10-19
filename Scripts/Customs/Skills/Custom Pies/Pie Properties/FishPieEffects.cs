// Scripts/Custom/Custom Pies/Attributes/FishPieAttributes.cs
using System;
using Server;
using Server.Mobiles;
using Server.Items;      // for BaseFishPie and FishPieEffect


namespace Server.CustomPies.Attributes
{
    /// <summary>
    /// Common helper that all Fish-Pie attributes inherit.
    /// It handles registering itself, adding / removing BuffInfo, and firing a timer.
    /// Child classes only need to supply the FishPieEffect it represents and (optionally)
    /// inject any extra SkillMod or ResistanceMod logic.
    /// </summary>
    public abstract class FishPieAttributeBase : IPieAttribute
    {
        public abstract FishPieEffect EffectType { get; }

        public virtual string Id    => EffectType.ToString();       // e.g. "MedBoost"
        public virtual string Label => Id.Replace("Boost", " Boost")
                                         .Replace("Soak",  " Soak")
                                         .Replace("Dam",   " Damage")
                                         .Replace("Chance"," Chance");

        public virtual TimeSpan Duration => TimeSpan.FromMinutes(5);

        /// <summary>Most of the fish pies just play the generic “munch” sound.</summary>
        public virtual int SoundId => 0x1E7;

        public virtual void Visual(Mobile m)
        {
            // Generic pie-eating effect; override if you want something fancier.
            m.FixedEffect(0x375A, 10, 15);
        }

        // The static ctor registers ONE instance of every derived class at shard start-up.
        static FishPieAttributeBase()
        {
            // use reflection so we don’t have to remember to call Register() manually
            foreach (Type t in typeof(FishPieAttributeBase).Assembly.GetTypes())
            {
                if (t.IsSubclassOf(typeof(FishPieAttributeBase)) && !t.IsAbstract)
                {
                    IPieAttribute instance = (IPieAttribute)Activator.CreateInstance(t);
                    PieAttributeRegistry.Register(instance);
                }
            }
        }

        public void Apply(Mobile eater)
        {
            // If the player already has that fish-pie effect, abort (just like real pies)
            if (!BaseFishPie.TryAddBuff(eater, EffectType))
            {
                eater.SendLocalizedMessage(502173); // “You are already under a similar effect.”
                return;
            }

            // Let child classes add SkillMod / ResistanceMod, etc.
            OnApplyExtra(eater);

            // Add the standard Fish-Pie buff icon
            BuffInfo.AddBuff(eater,
                new BuffInfo(BuffIcon.FishPie, 1116340, Label)); // 1116340 = “Fish Pie”

            // Start a timer to remove the buff after Duration
            Timer.DelayCall(Duration, () =>
            {
                BaseFishPie.RemoveBuff(eater, EffectType);
                OnExpire(eater);
            });

            if (SoundId >= 0) eater.PlaySound(SoundId);
            Visual(eater);
        }

        /// <summary>Override to add SkillMod, ResistanceMod, etc.</summary>
        protected virtual void OnApplyExtra(Mobile eater) { }

        /// <summary>Override to clean up extra mods if needed.</summary>
        protected virtual void OnExpire(Mobile eater) { }
    }

    // ─────────────────────────  Skill-boost pies  ──────────────────────────

    public sealed class MedBoostAttribute : FishPieAttributeBase
    {
        public override FishPieEffect EffectType => FishPieEffect.MedBoost;

        protected override void OnApplyExtra(Mobile eater)
        {
            TimedSkillMod mod = new TimedSkillMod(SkillName.Meditation, true, 10.0, Duration)
            {
                ObeyCap = true
            };
            eater.AddSkillMod(mod);
        }
    }

    public sealed class FocusBoostAttribute : FishPieAttributeBase
    {
        public override FishPieEffect EffectType => FishPieEffect.FocusBoost;

        protected override void OnApplyExtra(Mobile eater)
        {
            TimedSkillMod mod = new TimedSkillMod(SkillName.Focus, true, 10.0, Duration)
            {
                ObeyCap = true
            };
            eater.AddSkillMod(mod);
        }
    }

    // ─────────────────────────  Soak-type pies  ────────────────────────────
    // These rely on BaseFishPie.ScaleDamage, so no extra mods are necessary.

    public sealed class ColdSoakAttribute      : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.ColdSoak;      }
    public sealed class EnergySoakAttribute    : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.EnergySoak;    }
    public sealed class FireSoakAttribute      : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.FireSoak;      }
    public sealed class PoisonSoakAttribute    : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.PoisonSoak;    }
    public sealed class PhysicalSoakAttribute  : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.PhysicalSoak;  }

    // ─────────────────────────  Combat-stat pies  ─────────────────────────
    // WeaponDamage / HitChance / DefChance / SpellDamage are implemented elsewhere
    // (e.g., the damage routine checks BaseFishPie.IsUnderEffects).  We only need
    // to register the buff and duration here.

    public sealed class WeaponDamAttribute  : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.WeaponDam;  }
    public sealed class HitChanceAttribute  : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.HitChance;  }
    public sealed class DefChanceAttribute  : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.DefChance;  }
    public sealed class SpellDamageAttribute: FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.SpellDamage;}

    // ─────────────────────────  Regen / utility pies  ─────────────────────
    // The actual regeneration & soul-charge math is already done by whatever
    // code checks BaseFishPie.IsUnderEffects.  So again, no extra mods needed.

    public sealed class ManaRegenAttribute : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.ManaRegen; }
    public sealed class HitsRegenAttribute : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.HitsRegen; }
    public sealed class StamRegenAttribute : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.StamRegen; }
    public sealed class SoulChargeAttribute: FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.SoulCharge;}
    public sealed class CastFocusAttribute : FishPieAttributeBase { public override FishPieEffect EffectType => FishPieEffect.CastFocus; }
}
