using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;

namespace Server.CustomPies
{
    public class MagicalOvenGump : Gump
    {
        private readonly Mobile      _user;
        private readonly MagicalOven _oven;
        private readonly Item[]      _ings;    // holds up to 4 ingredients

        private const int SlotCount   = 4;
        private const int BakeBtn     = 400;
        private const int ClearBtn    = 401;
        private const int ExamineBtn  = 402;

        // Cooking‐skill thresholds for unlocking each slot (UNCHANGED)
        private static readonly double[] SlotSkillReq = new double[] { 25.0, 25.0, 120.0, 200.0 };

        //
        // ─── NEW: Define “Ingredient Tiers” ──────────────────────────────────────
        //
        // Each list represents all the item‐Types that a player of that tier may use.
        // At 25 skill you may only use the types in Tier25.
        // At 50 skill you get Tier25 + Tier50, etc.  Any type not in any list requires ≥ 200.
        //
        private static readonly List<Type> Tier25 = new List<Type>
        {
            // e.g. typeof(Apple), typeof(Banana), typeof(Berries), etc.
            // Fill in your “25‐skill” items here:
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
		
            // … etc …
        };

        private static readonly List<Type> Tier50 = new List<Type>
        {
            // e.g. typeof(Meat), typeof(Vegetable), etc.
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
		
            // … etc …
        };

        private static readonly List<Type> Tier75 = new List<Type>
        {
            // e.g. typeof(Spice), typeof(FruitSalad), etc.
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
            // … etc …
        };

        private static readonly List<Type> Tier100 = new List<Type>
        {
            // e.g. typeof(StuffedEgg), typeof(Cheese), etc.
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
			
            // … etc …
        };

        private static readonly List<Type> Tier125 = new List<Type>
        {
            // … your 125‐skill items …
            typeof(RefreshPotion),
            typeof(AgilityPotion),
            typeof(NightSightPotion),
            typeof(LesserHealPotion),
            typeof(StrengthPotion),
            typeof(LesserPoisonPotion),
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
				
        };

        private static readonly List<Type> Tier150 = new List<Type>
        {
            // … your 150‐skill items …
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
	
        };

        private static readonly List<Type> Tier175 = new List<Type>
        {
            // … your 175‐skill items …
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
        };

        // (By design, anything not in ANY of the above lists is effectively “Tier200”)

        /// <summary>
        /// Given an Item, return the minimum cooking‐skill required in order to use it as an ingredient.
        /// </summary>
        public static double GetIngredientSkillReq(Item ing)
        {
            Type t = ing.GetType();

            // Note: check from lowest tier upward, since they accumulate.
            if (Tier25.Contains(t))
                return 25.0;

            if (Tier50.Contains(t))
                return 50.0;

            if (Tier75.Contains(t))
                return 75.0;

            if (Tier100.Contains(t))
                return 100.0;

            if (Tier125.Contains(t))
                return 125.0;

            if (Tier150.Contains(t))
                return 150.0;

            if (Tier175.Contains(t))
                return 175.0;

            // Anything not in any list → requires 200% Cooking to use
            return 200.0;
        }
        // ──────────────────────────────────────────────────────────────────────────

        public MagicalOvenGump(Mobile user, MagicalOven oven, Item[] prefill = null)
            : base(50, 50)
        {
            _user = user;
            _oven = oven;

            if (prefill != null && prefill.Length == SlotCount)
                _ings = prefill;
            else
                _ings = new Item[SlotCount];

            Build();
        }

        private void Build()
        {
            Closable   = true;
            Disposable = true;

            AddPage(0);
            AddBackground(0, 0, 540, 560, 9270);
            AddLabel(200, 15, 0x44F, "Magical Oven");

            // ── Draw the four “ingredient slot” boxes ─────────────────────
            for (int i = 0; i < SlotCount; i++)
            {
                int x = 70 + (i % 2) * 200;
                int y = 50 + (i / 2) * 140;

                // background frame
                AddBackground(x, y, 60, 60, 9270);

                // if an item is already selected in that slot, draw it
                if (_ings[i] != null && !_ings[i].Deleted)
                {
                    AddItem(x + 6, y + 22, _ings[i].ItemID, _ings[i].Hue);
                }

                // “click here” button to select an ingredient
                AddButton(x, y, 0x837, 0x838, 10 + i, GumpButtonType.Reply, 0);

                // show the cooking skill needed for that slot
                AddLabel(x, y + 62, 0x44F, $"{SlotSkillReq[i]:0}% Cooking");
            }

            // ── Bake, Clear, Examine buttons at bottom ─────────────────
            AddButton(130, 500, 0xFA5, 0xFA6, BakeBtn,    GumpButtonType.Reply, 0);
            AddLabel (170, 504, 0x44F, "Bake Pie");

            AddButton(260, 500, 0xFA5, 0xFA6, ClearBtn,   GumpButtonType.Reply, 0);
            AddLabel (300, 504, 0x44F, "Clear");

            AddButton(390, 500, 0xFA5, 0xFA6, ExamineBtn, GumpButtonType.Reply, 0);
            AddLabel (430, 504, 0x44F, "Inspect");

            // ── Preview area at the bottom ─────────────────────────────
            AddBackground(40, 280, 460, 190, 9270);
            AddHtml(55, 295, 440, 175, BuildPreviewHtml(), false, true);
        }

        // Build the HTML that shows “which attributes you’ll get” based on chosen ingredients and TasteID
        private string BuildPreviewHtml()
        {
            // Collect all non-null, non-deleted ingredients
            List<Item> chosenList = new List<Item>();
            for (int i = 0; i < SlotCount; i++)
            {
                if (_ings[i] != null && !_ings[i].Deleted)
                    chosenList.Add(_ings[i]);
            }

            Item[] chosen = chosenList.ToArray();
            Dictionary<string, int> freq;
            List<string> overlaps = GetOverlappingAttributes(chosen, out freq);

            double tasteSkill = _user.Skills[SkillName.TasteID].Value;
            List<string> allowed = SelectAttributesByTaste(tasteSkill, overlaps, freq);

            if (allowed == null || allowed.Count == 0)
            {
                return "<BASEFONT COLOR=#FF0000>No matching properties.";
            }

            // Build a green‐text list of allowed attribute labels
            List<string> lines = new List<string>();
            foreach (string id in allowed)
            {
                IPieAttribute pa = PieAttributeRegistry.Get(id);
                if (pa != null)
                    lines.Add($"<BASEFONT COLOR=#00FF00>{pa.Label}</BASEFONT>");
                else
                    lines.Add($"<BASEFONT COLOR=#00FF00>{id}</BASEFONT>");
            }

            return String.Join("<BR>", lines);
        }

        // Handle all button clicks
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int bid = info.ButtonID;

            // If they clicked one of the ingredient slots (IDs 10..13)
            if (bid >= 10 && bid < 10 + SlotCount)
            {
                int slotIndex = bid - 10;
                double cookingSkill = _user.Skills[SkillName.Cooking].Value;

                // First, the existing “slot unlock” check (UNCHANGED)
                if (cookingSkill < SlotSkillReq[slotIndex])
                {
                    _user.SendMessage(
                        $"You need {SlotSkillReq[slotIndex]:0}% Cooking to use this slot."
                    );
                    return;
                }

                // ── NEW: Prompt them to target an item in their backpack.  We'll check
                // the item’s own “ingredient requirement” in the Target handler.
                _user.Target = new IngredientTarget(_oven, slotIndex, _ings);
                return;
            }

            // Bake button
            if (bid == BakeBtn)
            {
                BakePie();
            }
            // Clear button
            else if (bid == ClearBtn)
            {
                _user.SendGump(new MagicalOvenGump(_user, _oven, new Item[SlotCount]));
            }
            // Examine button
            else if (bid == ExamineBtn)
            {
                _user.Target = new ExamineTarget(_user);
            }
        }

        // Actually “bake” a pie by consuming ingredients and creating CustomPie
        private void BakePie()
        {
            // (UNCHANGED from your code…)
            List<Item> chosenList = new List<Item>();
            for (int i = 0; i < SlotCount; i++)
            {
                if (_ings[i] != null && !_ings[i].Deleted)
                    chosenList.Add(_ings[i]);
            }

            if (chosenList.Count == 0)
            {
                _user.SendMessage("Add ingredients first.");
                return;
            }

            Item[] chosen = chosenList.ToArray();
            Dictionary<string,int> freq;
            List<string> overlaps = GetOverlappingAttributes(chosen, out freq);

            if (overlaps.Count == 0)
            {
                _user.SendMessage("No shared properties among those ingredients.");
                return;
            }

            double tasteSkill = _user.Skills[SkillName.TasteID].Value;
            List<string> finalAttributes = SelectAttributesByTaste(tasteSkill, overlaps, freq);

            if (finalAttributes.Count == 0)
            {
                _user.SendMessage("Your TasteID skill is too low to get any properties.");
                return;
            }

            // Consume each ingredient
            foreach (Item ing in chosen)
            {
                if (ing.Amount > 1)
                    ing.Amount--;
                else
                    ing.Delete();
            }

            // ── HERE’S THE KEY CHANGE: Create a new pie, assign its attributes, then call GenerateNameAndHue()
            CustomPie pie = new CustomPie();
            pie.Servings = 1;

            // Overwrite whatever the constructor put in AttributeIds
            pie.AttributeIds.Clear();
            foreach (string id in finalAttributes)
                pie.AttributeIds.Add(id);

            // Now regenerate Name & Hue based on the newly assigned attributes
            pie.GenerateNameAndHue();

            // Finally, add it to the player’s backpack
            _user.AddToBackpack(pie);
            _user.PlaySound(0x247);
            _user.SendMessage("You bake a unique pie: " + pie.Name);
            _user.CloseGump(typeof(MagicalOvenGump));
        }

        // (UNCHANGED from your code)
        private static int GetMaxByTaste(double tasteSkill)
        {
            if (tasteSkill >= 100.0) return 4;
            if (tasteSkill >=  75.0) return 3;
            if (tasteSkill >=  50.0) return 2;
            if (tasteSkill >=  25.0) return 1;
            return 0;
        }

        private static List<string> SelectAttributesByTaste(
            double tasteSkill,
            List<string> overlaps,
            Dictionary<string,int> freq
        )
        {
            int max = GetMaxByTaste(tasteSkill);
            List<string> ordered = overlaps
                .OrderByDescending(id => freq[id])
                .ThenBy(id => id)
                .ToList();

            List<string> result = new List<string>();
            for (int i = 0; i < ordered.Count && i < max; i++)
            {
                result.Add(ordered[i]);
            }
            return result;
        }

        private static List<string> GetOverlappingAttributes(Item[] chosen, out Dictionary<string,int> freq)
        {
            freq = new Dictionary<string,int>();

            foreach (Item ing in chosen)
            {
                List<string> ingAttrs = EffectsFor(ing);
                foreach (string id in ingAttrs)
                {
                    if (freq.ContainsKey(id))
                        freq[id]++;
                    else
                        freq[id] = 1;
                }
            }

            List<string> overlapList = new List<string>();
            foreach (KeyValuePair<string,int> kvp in freq)
            {
                if (kvp.Value > 1)
                    overlapList.Add(kvp.Key);
            }

            return overlapList;
        }

        internal static List<string> EffectsFor(Item ing)
        {
            List<IPieAttribute> pool = PieAttributeRegistry.All.ToList();
            string seedStr = String.IsNullOrWhiteSpace(ing.Name) ? ing.GetType().Name : ing.Name;
            int seed = seedStr.ToLowerInvariant().GetHashCode();
            Random rng = new Random(seed);

            List<string> ids = new List<string>();
            for (int i = 0; i < 4 && i < pool.Count; i++)
            {
                int idx = rng.Next(pool.Count - i);
                ids.Add(pool[idx].Id);

                IPieAttribute tmp = pool[idx];
                pool[idx] = pool[pool.Count - 1 - i];
                pool[pool.Count - 1 - i] = tmp;
            }

            return ids;
        }

        // ── Target classes ───────────────────────────────────────────

        private class IngredientTarget : Target
        {
            private readonly MagicalOven _ovenRef;
            private readonly int         _slotIndex;
            private readonly Item[]      _slots;

            public IngredientTarget(MagicalOven oven, int slotIndex, Item[] slots)
                : base(2, false, TargetFlags.None)
            {
                _ovenRef   = oven;
                _slotIndex = slotIndex;
                _slots     = slots;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (!(targeted is Item item) || !item.IsChildOf(from.Backpack))
                {
                    from.SendMessage("That must be in your backpack.");
                    return;
                }

                // Prevent choosing the same ingredient twice across slots
                for (int i = 0; i < _slots.Length; i++)
                {
                    if (i != _slotIndex && _slots[i] == item)
                    {
                        from.SendMessage("That ingredient is already assigned to another slot.");
                        return;
                    }
                }

                // ── NEW: Check the item’s own cooking‐skill requirement ─────────────────
                double userCookSkill = from.Skills[SkillName.Cooking].Value;
                double req = MagicalOvenGump.GetIngredientSkillReq(item);

                if (userCookSkill < req)
                {
                    from.SendMessage($"You need {req:0}% Cooking to use that ingredient.");
                    return;
                }
                // ──────────────────────────────────────────────────────────────────────

                // Everything’s okay; assign it
                _slots[_slotIndex] = item;
                from.SendGump(new MagicalOvenGump(from, _ovenRef, _slots));
            }
        }

        private class ExamineTarget : Target
        {
            private readonly Mobile _from;

            public ExamineTarget(Mobile from)
                : base(2, false, TargetFlags.None)
            {
                _from = from;
                from.SendMessage("Select an ingredient to inspect.");
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (!(targeted is Item item) || !item.IsChildOf(from.Backpack))
                {
                    from.SendMessage("That must be in your backpack.");
                    return;
                }

                from.SendGump(new IngredientPropertiesGump(from, item));
            }
        }
    }
}
