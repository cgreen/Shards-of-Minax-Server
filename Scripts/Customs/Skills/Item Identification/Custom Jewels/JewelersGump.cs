using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;

namespace Server.CustomJewels
{
    public class JewelersGump : Gump
    {
        private readonly Mobile _user;
        private readonly JewelersChisel _kit;
        private readonly Item[] _ingredients;            // up to 4 slots

        private const int SlotCount      = 4;
        private const int BottleLabel    = 400;          // “Craft jewel” button ID
        private const int ExamineButton  = 998;          // “Examine” button ID

        // ItemID‐skill requirements for the four ingredient boxes (UNCHANGED)
        private static readonly double[] SlotSkillReq = { 25.0, 25.0, 120.0, 200.0 };

        // ── NEW: Define “Ingredient Tiers” ─────────────────────────────────
        // Each list holds all the item‐Types that require exactly that tier.
        // Tier25  = can be used by anyone with ≥ 25% ItemID
        // Tier50  = … ≥ 50% ItemID (plus Tier25 items)
        // Tier75  = … ≥ 75% ItemID (plus Tier25+Tier50)
        // Tier100 = … ≥ 100% ItemID (plus all below)
        // Tier125, Tier150, Tier175 similarly. Anything not in these lists → “Tier200.”
        private static readonly List<Type> Tier25 = new List<Type>
        {
            // e.g. typeof(SpiderFang), typeof(SerpentScale), ...
            typeof(RefreshPotion),
            typeof(AgilityPotion),
            typeof(NightSightPotion),
            typeof(LesserHealPotion),
            typeof(StrengthPotion),
            typeof(LesserCurePotion),
            typeof(LesserExplosionPotion),
            typeof(BlackPearl),
            typeof(Bloodmoss),
            typeof(Garlic),	
            typeof(Ginseng),	
            typeof(MandrakeRoot),
            typeof(Nightshade),
            typeof(SpidersSilk),
            typeof(SulfurousAsh),
            typeof(SpringWater),
            typeof(DestroyingAngel),
            typeof(PetrafiedWood),
            // …etc…
        };

        private static readonly List<Type> Tier50 = new List<Type>
        {
            // e.g. typeof(NightshadeBerries), typeof(ScorpionSting), ...
            typeof(SkinTingeingTincture),
            typeof(StarSapphire),
            typeof(Emerald),
            typeof(Sapphire),	
            typeof(Ruby),	
            typeof(Citrine),
            typeof(Amethyst),
            typeof(Tourmaline),
            typeof(Amber),
            typeof(Diamond),
            typeof(BatWing),
            typeof(DaemonBlood),	
            typeof(PigIron),	
            typeof(NoxCrystal),
            typeof(GraveDust),
            // …etc…
        };

        private static readonly List<Type> Tier75 = new List<Type>
        {
            // e.g. typeof(BasiliskBlood), ...
            typeof(BoltOfCloth),
            typeof(Cloth),
            typeof(UncutCloth),
            typeof(Cotton),
            typeof(Wool),	
            typeof(Flax),
            typeof(SpoolOfThread),
            typeof(OakLog),
            typeof(AshLog),	
            typeof(YewLog),	
            typeof(BloodwoodLog),
            typeof(IronIngot),
            typeof(DullCopperIngot),
            typeof(ShadowIronIngot),
            typeof(CopperIngot),
            typeof(BronzeIngot),
            typeof(GoldIngot),	
            typeof(AgapiteIngot),	
            typeof(VeriteIngot),
            typeof(ValoriteIngot),
            // …etc…
        };

        private static readonly List<Type> Tier100 = new List<Type>
        {
            // e.g. typeof(DragonVenom), typeof(MandrakeRoot), ...
            typeof(AbyssChivesFruit),
            typeof(aggearangFruit),
            typeof(agleatainFruit),
            typeof(ameoyoteFruit),
            typeof(AngelRootFruit),
            typeof(AngelTurnipFruit),	
            typeof(ArcticParsnipFruit),	
            typeof(AshLycheeFruit),
            typeof(AshRootFruit),
            typeof(AutumnCherryFruit),
            typeof(AutumnPomegranateFruit),
            typeof(BitterDurianFruit),
            typeof(BittersweetChivesFruit),
            typeof(BlackChoyFruit),	
            typeof(blattiovesFruit),	
            typeof(blearelFruit),
            typeof(BlumbFruit),
            typeof(bosheaShootFruit),
            typeof(brafulalFruit),
            typeof(brongerFruit),
            typeof(BushCerimanFruit),
            typeof(BushSpinachFruit),	
            typeof(CandyMorindaFruit),	
            typeof(CaveAsparagusFruit),
            typeof(CavePersimmonFruit),
            typeof(CavernMangosteenFruit),
            typeof(chigionutFruit),
            typeof(chummionachFruit),
            typeof(ciarryFruit),
            typeof(CinderGingerFruit),	
            typeof(CliffNectarineFruit),	
            typeof(crennealeryFruit),
            typeof(criarianFruit),
            typeof(darantFruit),
            typeof(DaydreamPommeracFruit),
            typeof(DesertPlumFruit),
            typeof(DesertRowanFruit),
            typeof(DessertBroccoliFruit),	
            typeof(DessertTomatoFruit),	
            typeof(DewKiwiFruit),
            typeof(DewPawpawFruit),
            typeof(dimquatFruit),
            typeof(diowanFruit),
            typeof(DragoLimeFruit),
            typeof(DrakeLentilFruit),
            typeof(DrakeMangoFruit),
            typeof(eacketFruit),
            typeof(eacotFruit),	
            typeof(earolaFruit),	
            typeof(EasternBacuriFruit),
            typeof(eawanFruit),
            typeof(echocadoFruit),
            typeof(ElephantBreadnutFruit),
            typeof(EmberLaurelFruit),
            typeof(EmberLettuceFruit),
            typeof(FalseAlmondFruit),	
            typeof(fliavesFruit),	
            typeof(FluxxFruit),
            typeof(fucrucotFruit),
            typeof(fudishFruit),
            typeof(fushewFruit),
            typeof(geweodineFruit),
            typeof(gigliachokeFruit),
            typeof(girinFruit),	
            typeof(glissidillaFruit),	
            typeof(GoldenRocketFruit),
            typeof(grandaFruit),
            typeof(gropioveFruit),
            typeof(GroundPearFruit),
            typeof(grutatoFruit),
            typeof(HairyTomatoFruit),
            typeof(HateCalamansiFruit),	
            typeof(HazelLimeFruit),	
            typeof(hialoupeFruit),
            typeof(hiorolaFruit),
            typeof(iaconaFruit),
            typeof(IceRocketFruit),
            typeof(iddiochokeFruit),
            typeof(imberFruit),
            typeof(ingeFruit),	
            typeof(intineFruit),	
            typeof(ippiocressFruit),
            typeof(ittianaFruit),
            typeof(jeorraFruit),
            typeof(jigreapawFruit),
            typeof(jochiniFruit),
            typeof(kledamiaFruit),
            typeof(kleopeFruit),
            typeof(kraccaleryFruit),
            typeof(krevaFruit),	
            typeof(LillypillyFruit),	
            typeof(LoveKumquatFruit),
            typeof(LoveZucchiniFruit),
            typeof(MageCherryFruit),
            typeof(MageDateFruit),
            typeof(MellowGourdFruit),
            typeof(MoonPumpkinFruit),
            typeof(moyiarlanFruit),	
            typeof(MutantLemonFruit),	
            typeof(MysteryFruit),
            typeof(MysteryGuavaFruit),
            typeof(MysteryOrangeFruit),
            typeof(NativeRambutanFruit),
            typeof(NightCabbageFruit),
            typeof(NightmareSaguaroFruit),
            typeof(ocanateFruit),	
            typeof(OceanMuscadineFruit),	
            typeof(omondFruit),
            typeof(otilFruit),
            typeof(PeaceAmaranthFruit),
            typeof(PeaceDateFruit),
            typeof(PeaceNectarineFruit),
            typeof(phecceayoteFruit),
            typeof(piokinFruit),	
            typeof(probbacheeFruit),	
            typeof(puchiniFruit),
            typeof(PygmyOrangeFruit),
            typeof(qekliatilloFruit),
            typeof(RainLaurelFruit),
            typeof(RainPommeracFruit),
            typeof(rephoneFruit),
            typeof(satilFruit),	
            typeof(siheonachFruit),	
            typeof(SilverFruit),
            typeof(slirindFruit),
            typeof(slomeloFruit),
            typeof(SmellyCarrotFruit),
            typeof(SourAmaranthFruit),
            typeof(StormBrambleFruit),
            typeof(striachiniFruit),	
            typeof(strondaFruit),
            typeof(SwampNectarineFruit),
            typeof(SweetBoquilaFruit),
            typeof(TigerBeanFruit),	
            typeof(TropicalCherryFruit),	
            typeof(unaFruit),
            typeof(uyerdFruit),
            typeof(veapeFruit),
            typeof(VoidBrambleFruit),
            typeof(VoidOkraFruit),
            typeof(VoidPulasanFruit),
            typeof(VoidSproutFruit),	
            typeof(vrecequilaFruit),	
            typeof(vropperrotFruit),
            typeof(vuveFruit),
            typeof(WinterCoconutFruit),
            typeof(WonderRambutanFruit),
            typeof(wriggumondFruit),
            typeof(XeenBerryFruit),
            typeof(xekraFruit),	
            typeof(xemeloFruit),
            typeof(zanioperFruit),
            typeof(ziongerFruit),
            typeof(Hides),	
            typeof(HairDye),
            // …etc…
        };

        private static readonly List<Type> Tier125 = new List<Type>
        {
            // e.g. typeof(NightmareAsh), ...
            typeof(Cabbage),
            typeof(Cantaloupe),
            typeof(Carrot),
            typeof(HoneydewMelon),
            typeof(Squash),	
            typeof(Lettuce),
            typeof(Onion),
            typeof(Pumpkin),
            typeof(GreenGourd),
            typeof(YellowGourd),
            typeof(Watermelon),
            typeof(Peach),	
            typeof(Pear),	
            typeof(Lemon),
            typeof(Lime),
            typeof(Grapes),
            typeof(Apple),
            typeof(SheafOfHay),
            typeof(RawFishSteak),
            typeof(Fish),	
            // …etc…
        };

        private static readonly List<Type> Tier150 = new List<Type>
        {
            // e.g. typeof(GriffonFeather), ...
            typeof(Carrot),
            typeof(HoneydewMelon),
            typeof(Squash),
            typeof(Lettuce),
            typeof(WoodenBowlOfCarrots),
            typeof(WoodenBowlOfCorn),
            typeof(WoodenBowlOfLettuce),
            typeof(WoodenBowlOfPeas),
            typeof(PewterBowlOfCorn),
            typeof(PewterBowlOfLettuce),
            typeof(PewterBowlOfPeas),
            typeof(PewterBowlOfPotatos),
            typeof(WoodenBowlOfStew),
            typeof(WoodenBowlOfTomatoSoup),
            typeof(BeverageBottle),
            typeof(Jug),
            typeof(Pitcher),
            typeof(Wasabi),
            typeof(BentoBox),
            typeof(GreenTeaBasket),
            // …etc…
        };

        private static readonly List<Type> Tier175 = new List<Type>
        {
            // e.g. typeof(AncientBoneDust), ...
            typeof(Apple),
            typeof(Banana),
            typeof(Cabbage),
            typeof(CookedBird),	
            typeof(LambLeg),
            typeof(ChickenLeg),
            typeof(RoastPig),
            typeof(SackFlour),
            typeof(JarHoney),
            typeof(BreadLoaf),
            typeof(ApplePie),
            typeof(Cake),
            typeof(Muffins),
            typeof(FrenchBread),
            typeof(Cookies),
            typeof(CheesePizza),
            typeof(BowlFlour),
            typeof(PeachCobbler),
            typeof(Quiche),
            typeof(Dough),
            typeof(Eggs),
            typeof(Bacon),
            typeof(Ham),
            typeof(Sausage),
            typeof(RawChickenLeg),
            typeof(RawBird),	
            typeof(RawLambLeg),
            typeof(RawRibs),
            // …etc…
        };

        /// <summary>
        /// Returns the minimum ItemID‐skill required to use this ingredient.
        /// </summary>
        public static double GetIngredientSkillReq(Item ing)
        {
            Type t = ing.GetType();

            if (Tier25.Contains(t))   return 25.0;
            if (Tier50.Contains(t))   return 50.0;
            if (Tier75.Contains(t))   return 75.0;
            if (Tier100.Contains(t))  return 100.0;
            if (Tier125.Contains(t))  return 125.0;
            if (Tier150.Contains(t))  return 150.0;
            if (Tier175.Contains(t))  return 175.0;

            // Anything not in the above lists → requires 200% ItemID
            return 200.0;
        }
        // ────────────────────────────────────────────────────────────────────

        public JewelersGump(Mobile user, JewelersChisel kit, Item[] prefill = null)
            : base(50, 50)
        {
            _user        = user;
            _kit         = kit;
            _ingredients = prefill ?? new Item[SlotCount];
            Build();
        }

        // ---------------------------------------------------------------- Build UI
        private void Build()
        {
            Closable   = true;
            Disposable = true;

            AddPage(0);
            AddBackground(0, 0, 500, 520, 9270);
            AddLabel(180, 15, 0x44F, "jeweler's Kit");

            /* ingredient boxes + skill labels */
            for (int i = 0; i < SlotCount; i++)
            {
                int x = 70 + (i % 2) * 180;
                int y = 50 + (i / 2) * 140;

                AddBackground(x, y, 60, 60, 9270);

                if (_ingredients[i] != null && !_ingredients[i].Deleted)
                    AddItem(x + 6, y + 22, _ingredients[i].ItemID, _ingredients[i].Hue);

                AddButton(x, y, 0x837, 0x838, 10 + i, GumpButtonType.Reply, 0);

                // Shows the slot‐unlock threshold (UNCHANGED)
                AddLabel(x, y + 62, 0x44F, $"{SlotSkillReq[i]:0}% Skill");
            }

            AddButton(150, 470, 0xFA5, 0xFA6, BottleLabel,     GumpButtonType.Reply, 0);
            AddLabel (190, 474, 0x44F, "Craft jewel");

            AddButton(270, 470, 0xFA5, 0xFA6, 999,             GumpButtonType.Reply, 0);
            AddLabel (310, 474, 0x44F, "Clear");
			
            AddButton(390, 470, 0xFA5, 0xFA6, ExamineButton,   GumpButtonType.Reply, 0);
            AddLabel (430, 474, 0x44F, "Examine");

            /* effects preview */
            AddBackground(40, 280, 420, 170, 9270);
            AddHtml(55, 295, 410, 160, BuildEffectHtml(), false, true);
        }

        // ---------------------------------------------------------------- Preview HTML
        private string BuildEffectHtml()
        {
            var chosen   = _ingredients.Where(i => i != null && !i.Deleted).ToArray();
            var overlaps = GetOverlappingEffects(chosen, out var freq);

            var allowed  = SelectEffects(_user.Skills[SkillName.ItemID].Value, overlaps, freq);

            if (allowed.Count == 0)
                return "<BASEFONT COLOR=#FF0000>No eligible effects with your current skill.";

            return string.Join("<BR>",
                               allowed.Select(id =>
                               {
                                   var eff = JewelPropertyRegistry.Get(id);
                                   return $"<BASEFONT COLOR=#00FF00>{(eff != null ? eff.Label : id)}</BASEFONT>";
                               }));
        }

        // ---------------------------------------------------------------- Button handling
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (_kit.Deleted) return;
            int bid = info.ButtonID;

            /* ingredient slots (10–13) */
            if (bid >= 10 && bid < 10 + SlotCount)
            {
                int slot  = bid - 10;
                double sk = _user.Skills[SkillName.ItemID].Value;

                // 1) Check slot‐unlock threshold (UNCHANGED)
                if (sk < SlotSkillReq[slot])
                {
                    _user.SendMessage($"You need at least {SlotSkillReq[slot]:0.0}% ItemID to use this slot.");
                    return;
                }

                // 2) Prompt target; in OnTarget we’ll enforce the ingredient‐tier requirement
                _user.Target = new IngredientTarget(_kit, slot, _ingredients);
                return;
            }

            if (bid == BottleLabel)
                Craftjewel();
            else if (bid == 999)      // clear
                _user.SendGump(new JewelersGump(_user, _kit, new Item[SlotCount]));
            else if (bid == ExamineButton)
            {
                _user.Target = new ExamineTarget(_user, _kit);
            }
        }

        private class ExamineTarget : Target
        {
            private readonly Mobile       _from;
            private readonly JewelersChisel _kit;

            public ExamineTarget(Mobile from, JewelersChisel kit)
                : base(2, false, TargetFlags.None)
            {
                _from = from;
                _kit  = kit;
                from.SendMessage("Select an ingredient to analyse.");
            }

            protected override void OnTarget(Mobile from, object obj)
            {
                if (obj is Item item)
                {
                    if (!item.IsChildOf(from.Backpack))
                    {
                        from.SendMessage("That must be in your backpack.");
                        return;
                    }

                    from.SendGump(new JewelPropertyListGump(from, item));
                }
            }
        }

        // ---------------------------------------------------------------- Crafting
        private void Craftjewel()
        {
            var chosen       = _ingredients.Where(i => i != null && !i.Deleted).ToArray();
            if (chosen.Length == 0)
            {
                _user.SendMessage("You must select at least one ingredient.");
                return;
            }

            var overlaps     = GetOverlappingEffects(chosen, out var freq);
            if (overlaps.Count == 0)
            {
                _user.SendMessage("None of the selected ingredients share a property – no jewel can be made.");
                return;
            }

            int max = GetMaxEffects(_user.Skills[SkillName.ItemID].Value);
            if (max == 0)
            {
                _user.SendMessage("You lack the skill to create any jewel.");
                return;
            }

            var finalEffects = SelectEffects(_user.Skills[SkillName.ItemID].Value, overlaps, freq);
            if (finalEffects.Count == 0)
            {
                _user.SendMessage("Your skill allows no effects from these ingredients.");
                return;
            }

            /* need a bottle */
            var bottle = _user.Backpack.FindItemByType(typeof(Diamond));
            if (bottle == null)
            {
                _user.SendMessage("You need a diamond.");
                return;
            }

            /* consume exactly ONE bottle */
            if (bottle.Amount > 1)
                bottle.Amount--;
            else
                bottle.Delete();

            /* consume one of each ingredient */
            foreach (var ing in chosen)
                if (ing.Amount > 1) ing.Amount--;
                else ing.Delete();

            /* create the jewel */
			var jewel = new CustomJewel();
			jewel.PropertyIds.Clear();
			jewel.PropertyIds.AddRange(finalEffects);
			jewel.GenerateNameAndHue();
			_user.AddToBackpack(jewel);
			_user.SendMessage("You have created a custom jewel!");

            _user.CloseGump(typeof(JewelersGump));
        }

        // ---------------------------------------------------------------- Helpers
        private static int GetMaxEffects(double skill)
        {
            if (skill >= 100.0) return 4;
            if (skill >= 75.0)  return 3;
            if (skill >= 50.0)  return 2;
            if (skill >= 25.0)  return 1;
            return 0;
        }

        /// <summary>
        /// Exactly matches GetMaxEffects in JewelersGump, so that PropertyListGump can call it.
        /// </summary>
        public static int GetMaxEffectsPublic(double skill) => GetMaxEffects(skill);

        /// <summary>
        /// The four effect‐IDs that this item would contribute, using
        /// the exact same deterministic algorithm the kit already uses.
        /// </summary>
        public static List<string> GetEffectsFor(Item ing)
        {
            var pool = JewelPropertyRegistry.All.ToList();

            /* --- identical seed logic --- */
            string seedStr = String.IsNullOrWhiteSpace(ing.Name)
                               ? ing.GetType().Name
                               : ing.Name;

            int     seed = seedStr.ToLowerInvariant().GetHashCode();
            Random  rng  = new Random(seed);

            var ids = new List<string>();
            for (int i = 0; i < 4 && i < pool.Count; i++)
            {
                int idx = rng.Next(pool.Count - i);
                ids.Add(pool[idx].Id);

                // remove chosen (swap with the end)
                var tmp     = pool[idx];
                pool[idx]   = pool[pool.Count - 1 - i];
                pool[pool.Count - 1 - i] = tmp;
            }

            return ids;           // always ≤ 4 items
        }

        private static List<string> GetOverlappingEffects(Item[] chosen, out Dictionary<string, int> freq)
        {
            freq = new Dictionary<string, int>();
            foreach (var ing in chosen)
            {
                // Determine the effects for each ingredient by using its name/type as a seed,
                // just like your previous system.
                string seedStr = String.IsNullOrWhiteSpace(ing.Name)
                                    ? ing.GetType().Name
                                    : ing.Name;

                int seed = seedStr.ToLowerInvariant().GetHashCode();
                Random rng = new Random(seed);

                // Get a deterministic subset of all effect IDs
                var pool = JewelPropertyRegistry.All.ToList();
                var ids  = new List<string>();
                for (int i = 0; i < 4 && i < pool.Count; i++)
                {
                    int idx = rng.Next(pool.Count - i);
                    ids.Add(pool[idx].Id);
                    // Remove chosen (swap with the end)
                    var tmp = pool[idx];
                    pool[idx] = pool[pool.Count - 1 - i];
                    pool[pool.Count - 1 - i] = tmp;
                }

                foreach (var id in ids)
                    freq[id] = freq.ContainsKey(id) ? freq[id] + 1 : 1;
            }
            // Only return those effects that appear on 2 or more ingredients
            return freq.Where(kvp => kvp.Value > 1)
                       .Select(kvp => kvp.Key)
                       .ToList();
        }

        private static List<string> SelectEffects(double skill, List<string> overlaps, Dictionary<string, int> freq)
        {
            int max = GetMaxEffects(skill);
            return overlaps
                   .OrderByDescending(id => freq[id])      // most common first
                   .ThenBy(id => id)                       // alphabetical tie-break
                   .Take(max)
                   .ToList();
        }

        // ---------------------------------------------------------------- Targeting
        private class IngredientTarget : Target
        {
            private readonly JewelersChisel _kit;
            private readonly int          _slot;
            private readonly Item[]       _ings;

            public IngredientTarget(JewelersChisel kit, int slot, Item[] ings)
                : base(2, false, TargetFlags.None)
            {
                _kit  = kit;
                _slot = slot;
                _ings = ings;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (!(targeted is Item item) || !item.IsChildOf(from.Backpack))
                {
                    from.SendMessage("That must be in your backpack.");
                    return;
                }

                // Prevent choosing the same ingredient twice across slots
                for (int i = 0; i < _ings.Length; i++)
                {
                    if (i != _slot && _ings[i] == item)
                    {
                        from.SendMessage("That ingredient is already assigned to another slot.");
                        return;
                    }
                }

                // ── NEW: Check this item’s “tiered” ItemID requirement ────────────
                double userjewelSkill = from.Skills[SkillName.ItemID].Value;
                double req             = JewelersGump.GetIngredientSkillReq(item);

                if (userjewelSkill < req)
                {
                    from.SendMessage($"You need {req:0}% ItemID to use that ingredient.");
                    return;
                }
                // ────────────────────────────────────────────────────────────────────

                _ings[_slot] = item;
                from.SendGump(new JewelersGump(from, _kit, _ings));
            }
        }
    }
}
