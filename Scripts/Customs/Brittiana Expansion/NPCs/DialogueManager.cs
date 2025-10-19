// Scripts/Custom/DialogueSystem/DialogueManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;                   // for CastSpell
using Server.Engines.XmlSpawner2;      // for XmlAttachment & XmlAttach

namespace Server.Custom.Dialogue
{
    #region Runtime data holders
    public class DialogueModule
    {
        public string Id;
        public string NpcText;
        public List<DialogueOption> Options = new List<DialogueOption>();
    }

    public class DialogueOption
    {
        public string Text;
        public Func<PlayerMobile, bool> Condition;
        public Action<PlayerMobile> Action;
        public string NextModuleId;
    }
    #endregion

    public class DialogueManager
    {
        private readonly Dictionary<string, DialogueModule> _modules 
            = new Dictionary<string, DialogueModule>();
        private readonly string _npcName;

        private DialogueManager(string npcName)
        {
            _npcName = npcName;
        }

        public static DialogueManager LoadFromXml(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Dialogue XML not found: " + filePath);

            var doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode root = doc.DocumentElement;
            if (root == null || root.Name != "DialogueFile")
                throw new Exception("Invalid dialogue XML. Root <DialogueFile> missing.");

            string npcName = "UNKNOWN";
            if (root.Attributes["npc"] != null)
                npcName = root.Attributes["npc"].Value;

            var mgr = new DialogueManager(npcName);

            // Pass 1: create modules
            XmlNodeList dialogueNodes = root.SelectNodes("Dialogue");
            foreach (XmlNode dlg in dialogueNodes)
            {
                var idAttr = dlg.Attributes["id"];
                if (idAttr == null)
                    throw new Exception("Dialogue node missing id attribute.");
                string id = idAttr.Value;

				XmlNode txtNode = dlg.SelectSingleNode("NPCText");
				string txt = txtNode != null
					? txtNode.InnerText.Trim()
					: String.Empty;

                mgr._modules.Add(id, new DialogueModule { Id = id, NpcText = txt });
            }

            // Pass 2: attach options
            foreach (XmlNode dlg in dialogueNodes)
            {
                string id = dlg.Attributes["id"].Value;
                var module = mgr._modules[id];

                XmlNodeList optionNodes = dlg.SelectNodes("Option");
                foreach (XmlNode opt in optionNodes)
                {
                    string text = opt.Attributes["text"]?.Value ?? String.Empty;
                    string next = opt.Attributes["next"]?.Value; // may be null

                    var cond = BuildCondition(opt);
                    var act  = BuildAction(opt);

                    module.Options.Add(new DialogueOption
                    {
                        Text         = text,
                        NextModuleId = next,
                        Condition    = cond,
                        Action       = act
                    });
                }
            }

            return mgr;
        }

        #region Condition DSL
		/* ======================================================================
		 *  BuildCondition  – supports 18 verbs (all case‑insensitive)
		 * ====================================================================*/
		private static Func<PlayerMobile,bool> BuildCondition(XmlNode opt)
		{
			var attr = opt.Attributes["condition"];
			if (attr == null || String.IsNullOrEmpty(attr.Value))
				return pm => true;                       // default: always show

			string expr = attr.Value.Trim();

			/* ------------------------------------------------------------------
			 *  ❶  Item / Scroll ownership
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("!HasScroll:", StringComparison.OrdinalIgnoreCase) ||
				expr.StartsWith("HasScroll:",  StringComparison.OrdinalIgnoreCase))
			{
				bool inverted = expr[0] == '!';
				string keyword = expr.Substring(inverted ? 11 : 10);   // length of prefixes
				return pm => inverted 
					  ? !HasScroll<KillQuestScroll>(pm, keyword) 
					  :  HasScroll<KillQuestScroll>(pm, keyword);
			}

			if (expr.StartsWith("!HasItem:", StringComparison.OrdinalIgnoreCase) ||
				expr.StartsWith("HasItem:",  StringComparison.OrdinalIgnoreCase))
			{
				bool inverted = expr[0] == '!';
				string typeName = expr.Substring(inverted ? 9 : 8);
				Type type = ScriptCompiler.FindTypeByName(typeName);
				if (type == null) return pm => !inverted;              // safe default
				return pm =>
				{
					bool has = pm.Backpack != null && pm.Backpack.FindItemByType(type, true) != null;
					return inverted ? !has : has;
				};
			}

			/* ------------------------------------------------------------------
			 *  ❷  Gold
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("GoldAtLeast:", StringComparison.OrdinalIgnoreCase))
			{
				int amt;
				if (Int32.TryParse(expr.Substring(12), out amt))
					return pm => CountGold(pm) >= amt;
			}

			/* ------------------------------------------------------------------
			 *  ❸  Skill levels   (SkillAtLeast:Mining,80)
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("SkillAtLeast:", StringComparison.OrdinalIgnoreCase) ||
				expr.StartsWith("SkillBelow:",   StringComparison.OrdinalIgnoreCase))
			{
				bool below = expr.StartsWith("SkillBelow:", StringComparison.OrdinalIgnoreCase);
				string[] tok = expr.Substring(below ? 11 : 13).Split(',');
				if (tok.Length == 2)
				{
					string skillName = tok[0].Trim();
					double value;
					if (Double.TryParse(tok[1], out value))
					{
						SkillName sn;
						if (Enum.TryParse(skillName, true, out sn))
							return pm =>
							{
								double cur = pm.Skills[sn].Base;
								return below ? cur < value : cur >= value;
							};
					}
				}
			}

			/* ------------------------------------------------------------------
			 *  ❹  Stat values     (StatAtLeast:Str,100)
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("StatAtLeast:", StringComparison.OrdinalIgnoreCase) ||
				expr.StartsWith("StatBelow:",   StringComparison.OrdinalIgnoreCase))
			{
				bool below = expr.StartsWith("StatBelow:", StringComparison.OrdinalIgnoreCase);
				string[] tok = expr.Substring(below ? 10 : 12).Split(',');
				if (tok.Length == 2)
				{
					StatType st;
					int val;
					if (Enum.TryParse(tok[0], true, out st) &&
						Int32.TryParse(tok[1], out val))
					{
						return pm =>
						{
							int cur = st == StatType.Str ? pm.RawStr
								   : st == StatType.Dex ? pm.RawDex
								   : pm.RawInt;
							return below ? cur < val : cur >= val;
						};
					}
				}
			}

			/* ------------------------------------------------------------------
			 *  ❺  Fame / Karma
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("FameAtLeast:", StringComparison.OrdinalIgnoreCase))
			{
				int v; if (Int32.TryParse(expr.Substring(12), out v))
					return pm => pm.Fame >= v;
			}
			if (expr.StartsWith("KarmaAtLeast:", StringComparison.OrdinalIgnoreCase))
			{
				int v; if (Int32.TryParse(expr.Substring(13), out v))
					return pm => pm.Karma >= v;
			}
			if (expr.StartsWith("FameBelow:", StringComparison.OrdinalIgnoreCase))
			{
				int v; if (Int32.TryParse(expr.Substring(10), out v))
					return pm => pm.Fame < v;
			}
			if (expr.StartsWith("KarmaBelow:", StringComparison.OrdinalIgnoreCase))
			{
				int v; if (Int32.TryParse(expr.Substring(11), out v))
					return pm => pm.Karma < v;
			}

			/* ------------------------------------------------------------------
			 *  ❻  Gender
			 * ----------------------------------------------------------------*/
			if (expr.Equals("IsFemale", StringComparison.OrdinalIgnoreCase))
				return pm => pm.Female;
			if (expr.Equals("IsMale", StringComparison.OrdinalIgnoreCase))
				return pm => !pm.Female;

			/* ------------------------------------------------------------------
			 *  ❼  Map / Region
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("InMap:", StringComparison.OrdinalIgnoreCase))
			{
				string mapName = expr.Substring(6);
				return pm => pm.Map != null && pm.Map.Name.Equals(mapName, StringComparison.OrdinalIgnoreCase);
			}

			if (expr.StartsWith("InRegion:", StringComparison.OrdinalIgnoreCase))
			{
				string regionName = expr.Substring(9);
				return pm => pm.Region != null && pm.Region.Name.Equals(regionName, StringComparison.OrdinalIgnoreCase);
			}

			/* ------------------------------------------------------------------
			 *  ❽  Attachment presence
			 *      HasAttachment:XmlQuestTracker
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("HasAttachment:", StringComparison.OrdinalIgnoreCase) ||
				expr.StartsWith("!HasAttachment:", StringComparison.OrdinalIgnoreCase))
			{
				bool invert = expr[0] == '!';
				string attName = expr.Substring(invert ? 15 : 14);
				Type at = ScriptCompiler.FindTypeByName(attName);
				if (at == null) return pm => !invert;

				return pm =>
				{
					bool has = XmlAttach.FindAttachment(pm, at) != null;
					return invert ? !has : has;
				};
			}

			/* ------------------------------------------------------------------
			 *  ❾  RandomChance:50   (passes ~50 % of the time)
			 * ----------------------------------------------------------------*/
			if (expr.StartsWith("RandomChance:", StringComparison.OrdinalIgnoreCase))
			{
				int pct;
				if (Int32.TryParse(expr.Substring(13), out pct))
					return pm => Utility.Random(100) < pct;
			}

			/* ------------------------------------------------------------------
			 *  ❿  Default – unknown verb
			 * ----------------------------------------------------------------*/
			return pm =>
			{
				pm.SendMessage("Unknown condition verb: " + expr);
				return true;
			};
		}

        #endregion

        #region Action DSL
        private static Action<PlayerMobile> BuildAction(XmlNode opt)
        {
            var attr = opt.Attributes["action"];
            if (attr == null || String.IsNullOrEmpty(attr.Value))
                return pm => { };

            string expr = attr.Value.Trim();

            // Close
            if (expr.Equals("Close", StringComparison.OrdinalIgnoreCase))
                return pm => { };

            // GiveScroll
            if (expr.StartsWith("GiveScroll:", StringComparison.OrdinalIgnoreCase))
            {
                string key = expr.Substring("GiveScroll:".Length);
                return pm => GiveScroll(pm, new KillQuestScroll(key, 1, 0));
            }

            // GiveItem
            if (expr.StartsWith("GiveItem:", StringComparison.OrdinalIgnoreCase))
                return BuildGiveItem(expr.Substring("GiveItem:".Length));

            // PlaySound:0x123
            if (expr.StartsWith("PlaySound:", StringComparison.OrdinalIgnoreCase))
            {
                int sound;
                if (Int32.TryParse(
                        expr.Substring("PlaySound:".Length),
                        System.Globalization.NumberStyles.HexNumber,
                        null,
                        out sound))
                {
                    return pm => pm.PlaySound(sound);
                }
            }

            // GiveGold:500
            if (expr.StartsWith("GiveGold:", StringComparison.OrdinalIgnoreCase))
            {
                int amt;
                if (Int32.TryParse(expr.Substring("GiveGold:".Length), out amt) && amt > 0)
                    return pm => pm.AddToBackpack(new Gold(amt));
            }

            // Teleport:x,y,z,map
            if (expr.StartsWith("Teleport:", StringComparison.OrdinalIgnoreCase))
            {
                ParsedPoint3D p;
                if (ParsedPoint3D.TryParse(expr.Substring("Teleport:".Length), out p))
                    return pm => pm.MoveToWorld(
                        new Point3D(p.X, p.Y, p.Z),
                        p.Map
                    );
            }

            // SendMessage:Hello
            if (expr.StartsWith("SendMessage:", StringComparison.OrdinalIgnoreCase))
            {
                string msg = expr.Substring("SendMessage:".Length);
                return pm => pm.SendMessage(msg);
            }

            // Broadcast:Global text
            if (expr.StartsWith("Broadcast:", StringComparison.OrdinalIgnoreCase))
            {
                string msg = expr.Substring("Broadcast:".Length);
                return pm => World.Broadcast(0x35, true, msg);
            }

            // AddStat:Str,10,60
            if (expr.StartsWith("AddStat:", StringComparison.OrdinalIgnoreCase))
            {
                ParsedStatMod s;
                if (ParsedStatMod.TryParse(expr.Substring("AddStat:".Length), out s))
                    return pm =>
                    {
                        pm.AddStatMod(new StatMod(
                            s.Stat,
                            "dlg_" + s.Stat,
                            s.Amount,
                            TimeSpan.FromSeconds(s.Duration)
                        ));
                    };
            }

            // AddSkill:Mining,20,60
            if (expr.StartsWith("AddSkill:", StringComparison.OrdinalIgnoreCase))
            {
                ParsedSkillMod sm;
                if (ParsedSkillMod.TryParse(expr.Substring("AddSkill:".Length), out sm))
                    return pm =>
                    {
                        SkillName skill;
                        try
                        {
                            skill = (SkillName)Enum.Parse(
                                typeof(SkillName),
                                sm.SkillName,
                                true
                            );
                        }
                        catch
                        {
                            pm.SendMessage("Invalid skill: " + sm.SkillName);
                            return;
                        }

                        var mod = new DefaultSkillMod(skill, true, sm.Amount);
                        mod.ObeyCap = true;
                        pm.AddSkillMod(mod);

                        Timer.DelayCall(
                            TimeSpan.FromSeconds(sm.Duration),
                            () => pm.RemoveSkillMod(mod)
                        );
                    };
            }

            // Karma:+100 or Fame:-50
            if (expr.StartsWith("Karma:", StringComparison.OrdinalIgnoreCase))
            {
                int d;
                if (Int32.TryParse(expr.Substring("Karma:".Length), out d))
                    return pm => pm.Karma += d;
            }
            if (expr.StartsWith("Fame:", StringComparison.OrdinalIgnoreCase))
            {
                int d;
                if (Int32.TryParse(expr.Substring("Fame:".Length), out d))
                    return pm => pm.Fame += d;
            }

            // CastSpell:FireballSpell
            if (expr.StartsWith("CastSpell:", StringComparison.OrdinalIgnoreCase))
            {
                string spellName = expr.Substring("CastSpell:".Length).Trim();
                return pm =>
                {
                    Type t = ScriptCompiler.FindTypeByName(spellName);
                    if (t != null && typeof(Spell).IsAssignableFrom(t))
                    {
                        var sp = Activator.CreateInstance(t, pm, null) as Spell;
                        sp?.Cast();
                    }
                };
            }

            // Effect:36BD,0,10
            if (expr.StartsWith("Effect:", StringComparison.OrdinalIgnoreCase))
            {
                var tok = expr.Substring("Effect:".Length)
                              .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tok.Length >= 1)
                {
                    int id = 0;
                    try { id = Convert.ToInt32(tok[0], 16); } catch { }
                    int hue  = tok.Length >= 2 && Int32.TryParse(tok[1], out hue) ? hue : 0;
                    int rend = tok.Length >= 3 && Int32.TryParse(tok[2], out rend) ? rend : 0;

                    return pm =>
                        Effects.SendLocationEffect(pm.Location, pm.Map, id, 30, hue, rend);
                }
            }

            // Damage:50
            if (expr.StartsWith("Damage:", StringComparison.OrdinalIgnoreCase))
            {
                int dmg;
                if (Int32.TryParse(expr.Substring("Damage:".Length), out dmg) && dmg > 0)
                    return pm => pm.Damage(dmg);
            }

            // Heal:30
            if (expr.StartsWith("Heal:", StringComparison.OrdinalIgnoreCase))
            {
                int heal;
                if (Int32.TryParse(expr.Substring("Heal:".Length), out heal) && heal > 0)
                    return pm => pm.Hits = Math.Min(pm.Hits + heal, pm.HitsMax);
            }

            // AttachXml:AttachmentName,arg1,arg2
            if (expr.StartsWith("AttachXml:", StringComparison.OrdinalIgnoreCase))
            {
                var tok = expr.Substring("AttachXml:".Length)
                              .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tok.Length >= 1)
                    return pm =>
                    {
                        Type at = ScriptCompiler.FindTypeByName(tok[0]);
                        if (at != null)
                        {
                            object[] ctorArgs = tok.Skip(1).Cast<object>().ToArray();
                            var att = Activator.CreateInstance(at, ctorArgs) 
                                       as XmlAttachment;
                            if (att != null)
                                XmlAttach.AttachTo(pm, pm, att);
                        }
                    };
            }

            // fallback
            return pm => pm.SendMessage("Unknown dialogue action: " + expr);
        }
        #endregion

		// counts gold in backpack + bankbox
		private static int CountGold(PlayerMobile pm)
		{
			int total = 0;
			if (pm.Backpack != null)
				total += pm.Backpack.GetAmount(typeof(Gold));
			if (pm.BankBox  != null)
				total += pm.BankBox.GetAmount(typeof(Gold));
			return total;
		}


        #region GiveItem helper
        private static Action<PlayerMobile> BuildGiveItem(string spec)
        {
            string typePart;
            string argsPart = String.Empty;
            int p = spec.IndexOf('(');
            if (p >= 0 && spec.EndsWith(")"))
            {
                typePart = spec.Substring(0, p).Trim();
                argsPart = spec.Substring(p + 1, spec.Length - p - 2);
            }
            else
            {
                typePart = spec.Trim();
            }

            var itemType = ScriptCompiler.FindTypeByName(typePart);
            if (itemType == null)
                return pm => pm.SendMessage("Dialog error: item type '" + typePart + "' not found.");

            string[] tokens = String.IsNullOrEmpty(argsPart)
                              ? new string[0]
                              : argsPart.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => s.Trim()).ToArray();

            return pm =>
            {
                var item = CreateItemInstance(itemType, tokens);
                if (item == null)
                    pm.SendMessage("Could not create item '" + typePart + "'.");
                else
                {
                    pm.AddToBackpack(item);
                    pm.PlaySound(0x3D);
                }
            };
        }
        #endregion

        #region Item Factory Helpers
        private static Item CreateItemInstance(Type type, string[] rawArgs)
        {
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                var attrs = ctor.GetCustomAttributes(typeof(ConstructableAttribute), false);
                if (attrs.Length == 0) continue;

                var pars = ctor.GetParameters();
                if (pars.Length != rawArgs.Length) continue;

                var conv = TryConvertArguments(pars, rawArgs);
                if (conv != null)
                    return ctor.Invoke(conv) as Item;
            }

            return Activator.CreateInstance(type) as Item;
        }

        private static object[] TryConvertArguments(ParameterInfo[] pars, string[] rawArgs)
        {
            var result = new object[rawArgs.Length];
            for (int i = 0; i < rawArgs.Length; i++)
            {
                string tok = rawArgs[i];
                var targ = pars[i].ParameterType;

                try
                {
                    if (targ == typeof(string))
                        result[i] = tok;
                    else if (targ == typeof(int))
                        result[i] = Int32.Parse(tok);
                    else if (targ == typeof(double))
                        result[i] = Double.Parse(tok);
                    else if (targ == typeof(bool))
                        result[i] = Boolean.Parse(tok);
                    else if (targ.IsEnum)
                        result[i] = Enum.Parse(targ, tok, true);
                    else if (targ == typeof(Type))
                        result[i] = ScriptCompiler.FindTypeByName(tok);
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            }
            return result;
        }
        #endregion

        #region Parsed helpers
        private struct ParsedPoint3D
        {
            public int X, Y, Z; public Map Map;
            public static bool TryParse(string s, out ParsedPoint3D p)
            {
                p = default(ParsedPoint3D);
                var t = s.Split(',');
                if (t.Length < 4) return false;

                int x, y, z;
                if (!Int32.TryParse(t[0], out x) ||
                    !Int32.TryParse(t[1], out y) ||
                    !Int32.TryParse(t[2], out z))
                    return false;

                Map map;
                try { map = Map.Parse(t[3]); }
                catch { map = Map.Felucca; }

                p = new ParsedPoint3D { X = x, Y = y, Z = z, Map = map };
                return true;
            }
        }

        private struct ParsedStatMod
        {
            public StatType Stat; public int Amount; public int Duration;
            public static bool TryParse(string s, out ParsedStatMod m)
            {
                m = default(ParsedStatMod);
                var t = s.Split(',');
                if (t.Length < 3) return false;

                try
                {
                    m.Stat = (StatType)Enum.Parse(typeof(StatType), t[0], true);
                }
                catch
                {
                    return false;
                }

                if (!Int32.TryParse(t[1], out m.Amount))   return false;
                if (!Int32.TryParse(t[2], out m.Duration)) return false;

                return true;
            }
        }

        private struct ParsedSkillMod
        {
            public string SkillName; public double Amount; public int Duration;
            public static bool TryParse(string s, out ParsedSkillMod m)
            {
                m = default(ParsedSkillMod);
                var t = s.Split(',');
                if (t.Length < 3) return false;
                m.SkillName = t[0];
                if (!Double.TryParse(t[1], out m.Amount))   return false;
                if (!Int32.TryParse(t[2], out m.Duration))  return false;
                return true;
            }
        }
        #endregion

        #region Public API
		public DialogueModule GetModule(string id)
		{
			DialogueModule mod;
			if (_modules.TryGetValue(id, out mod))
				return mod;

			// Log a warning so you can track missing IDs without crashing
			// new:
			Console.WriteLine($"[WARNING][Dialogue] NPC '{_npcName}' tried to load missing module '{id}'");
			return null;
		}
        #endregion

        #region Legacy Helpers
        private static bool HasScroll<T>(PlayerMobile pm, string keyword) where T : Item
        {
            return pm.Backpack != null
                && pm.Backpack.FindItemsByType(typeof(T), true)
                     .OfType<Item>()
                     .Any(i => i.Name != null
                            && i.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static void GiveScroll(PlayerMobile pm, Item scroll)
        {
            pm.AddToBackpack(scroll);
            pm.PlaySound(0x3D);
        }
        #endregion
    }
}
