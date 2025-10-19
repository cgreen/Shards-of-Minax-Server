using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

#region RANDOM‑MAGIC‑SHIELD

public class RandomMagicShield : BaseShield
{
    private int _tier;

    // ───────────────── Tier configuration ────────────────────────────
    private class TierConfig
    {
        public int MinEffects, MaxEffects;    // # of random attribute/resist effects
        public int MinSkillBns, MaxSkillBns;  // # of random skill bonuses
        public int ResMin, ResMax;            // resistances roll range
    }

    // index 0 ⇒ T1 … index 6 ⇒ T7
    private static readonly TierConfig[] _tiers = new[]
    {
        new TierConfig{ MinEffects=2, MaxEffects=4, MinSkillBns=0, MaxSkillBns=1, ResMin=1,  ResMax=5  }, // T1
        new TierConfig{ MinEffects=3, MaxEffects=5, MinSkillBns=1, MaxSkillBns=2, ResMin=2,  ResMax=7  }, // T2
        new TierConfig{ MinEffects=4, MaxEffects=6, MinSkillBns=1, MaxSkillBns=2, ResMin=3,  ResMax=9  }, // T3
        new TierConfig{ MinEffects=5, MaxEffects=7, MinSkillBns=2, MaxSkillBns=3, ResMin=4,  ResMax=12 }, // T4
        new TierConfig{ MinEffects=6, MaxEffects=8, MinSkillBns=2, MaxSkillBns=4, ResMin=5,  ResMax=14 }, // T5
        new TierConfig{ MinEffects=7, MaxEffects=9, MinSkillBns=3, MaxSkillBns=5, ResMin=6,  ResMax=16 }, // T6
        new TierConfig{ MinEffects=8, MaxEffects=10,MinSkillBns=4, MaxSkillBns=6, ResMin=7,  ResMax=18 }, // T7
    };

    // weighted tiers (sum=100)
    private static readonly Tuple<int,int>[] _tierWeights = new[]
    {
        Tuple.Create(1,40), Tuple.Create(2,25), Tuple.Create(3,15),
        Tuple.Create(4,10), Tuple.Create(5, 6), Tuple.Create(6, 3),
        Tuple.Create(7, 1)
    };

    private static readonly Type[] _shieldTypes = new[]
    {
        typeof(BronzeShield), typeof(Buckler), typeof(HeaterShield), typeof(MetalShield),
        typeof(WoodenShield), typeof(ChaosShield), typeof(OrderShield), typeof(MetalKiteShield)
    };

    private static readonly string[] _prefixes = { "Mighty", "Stalwart", "Mystic", "Enchanted", "Arcane", "Aegis", "Bulwark", "Sentinel" };
    private static readonly string[] _suffixes = { "Ward", "Guard", "Barrier", "Bulwark", "Sentinel", "Protector", "Bastion", "Shield" };

    private static readonly Action<BaseShield>[] _baseAttributes = new Action<BaseShield>[]
    {
        s => s.Attributes.ReflectPhysical   = _rand.Next(1, 31),
        s => s.Attributes.DefendChance      = _rand.Next(1, 31),
        s => s.Attributes.CastSpeed         = _rand.Next(0, 2),
        s => s.Attributes.CastRecovery      = _rand.Next(0, 3),
        s => s.Attributes.RegenHits         = _rand.Next(1, 51),
        s => s.Attributes.RegenMana         = _rand.Next(1, 51),
        s => s.Attributes.RegenStam         = _rand.Next(1, 51),
        s => s.Attributes.SpellDamage       = _rand.Next(1, 51),
        s => s.Attributes.LowerManaCost     = _rand.Next(1, 41),
        s => s.Attributes.LowerRegCost      = _rand.Next(1, 41),
        s => s.Attributes.BonusStr          = _rand.Next(1, 31),
        s => s.Attributes.BonusDex          = _rand.Next(1, 31),
        s => s.Attributes.BonusInt          = _rand.Next(1, 31),
        s => s.Attributes.BonusHits         = _rand.Next(1, 51),
        s => s.Attributes.BonusStam         = _rand.Next(1, 51),
        s => s.Attributes.BonusMana         = _rand.Next(1, 51),
        s => s.ArmorAttributes.LowerStatReq = _rand.Next(1, 51),
        s => s.ArmorAttributes.MageArmor    = _rand.Next(0, 2),
        s => s.ArmorAttributes.DurabilityBonus = _rand.Next(1, 51)
    };

    private static readonly Random _rand = new Random();

    // ──────── Constructors ────────────────────────────────────────────

    [Constructable]
    public RandomMagicShield() : this(GetWeightedRandomTier()) { }

    [Constructable]
    public RandomMagicShield(int tier) : base(GetRandomItemID())
    {
        _tier = Math.Max(1, Math.Min(7, tier));
        Name  = $"{_prefixes[_rand.Next(_prefixes.Length)]} {_suffixes[_rand.Next(_suffixes.Length)]}";
        Hue   = _rand.Next(1, 3001);

        ApplyTierBonuses(_tiers[_tier - 1]);
    }

    public RandomMagicShield(Serial serial) : base(serial) { }

    // ──────── Tiered logic ────────────────────────────────────────────

    private void ApplyTierBonuses(TierConfig cfg)
    {
        // 1) random pool of attributes + resist bonuses
        int cnt = _rand.Next(cfg.MinEffects, cfg.MaxEffects + 1);
        AddRandomEffects(cnt, cfg);

        // 2) random skill bonuses
        int sk  = _rand.Next(cfg.MinSkillBns, cfg.MaxSkillBns + 1);
        AddRandomSkills(sk);

        // 3) sockets loosely by tier
        int socks = _rand.Next(_tier); 
        XmlAttach.AttachTo(this, new XmlSockets(socks));
    }

    private void AddRandomEffects(int count, TierConfig cfg)
    {
        // combine base attributes + armor‐bonus (resist) entries
        var pool = new List<Action<BaseShield>>(_baseAttributes)
        {
            s => s.PhysicalBonus += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            s => s.FireBonus     += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            s => s.ColdBonus     += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            s => s.PoisonBonus   += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            s => s.EnergyBonus   += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
        };

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int idx = _rand.Next(pool.Count);
            pool[idx](this);
            pool.RemoveAt(idx);
        }
    }

    private void AddRandomSkills(int count)
    {
        var all = new List<SkillName>((SkillName[])Enum.GetValues(typeof(SkillName)));
        for (int i = 0; i < count && all.Count > 0; i++)
        {
            int idx = _rand.Next(all.Count);
            var sk = all[idx];
            all.RemoveAt(idx);

            int bonus = _rand.Next(1, 5 * _tier);
            SkillBonuses.SetValues(i, sk, bonus);
        }
    }

    // ──────── Helpers ─────────────────────────────────────────────────

    private static int GetWeightedRandomTier()
    {
        int roll = _rand.Next(100), cum = 0;
        foreach (var t in _tierWeights)
        {
            cum += t.Item2;
            if (roll < cum) return t.Item1;
        }
        return 1;
    }

    private static int GetRandomItemID()
    {
        Type t = _shieldTypes[_rand.Next(_shieldTypes.Length)];
        var tmp = (BaseShield)Activator.CreateInstance(t);
        int id = tmp.ItemID;
        tmp.Delete();
        return id;
    }

    // ──────── Persistence ──────────────────────────────────────────────

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);  // version
        writer.Write(_tier);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        _tier = reader.ReadInt();
    }
}

#endregion
