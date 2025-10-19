using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;                    // ← for BindingFlags
using System.Xml;
using Server;                               // ← for Mobile, Item, etc.
using Server.Items;
using Server.Engines.XmlSpawner2;           // ← for XmlAttachment, XmlAttach

namespace TraitSystem
{
    /// <summary>
    /// Marker interface for traits that can spawn XmlSpawner2 attachments.
    /// </summary>
    public interface IAttachmentTrait : ITrait
    {
        void AttachTo(Mobile target);
    }

    public static class TraitXml
    {
        public static IEnumerable<ITrait> Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"[Traits] WARNING: {path} not found.");
                yield break;
            }

            var doc = new XmlDocument();
            doc.Load(path);

            foreach (XmlNode node in doc.SelectNodes("/traits/trait"))
            {
                var trait = ParseTrait(node);
                if (trait != null)
                    yield return trait;
            }
        }

        private static ITrait ParseTrait(XmlNode node)
        {
            string name = node.Attributes["name"]?.Value;
            if (String.IsNullOrEmpty(name))
                return null;

            int prio = 0;
            int.TryParse(node.Attributes["priority"]?.Value, out prio);

            var dt = new DataTrait(name, prio);

            // --- existing dialogue / item entries ---
            foreach (XmlNode entry in node.SelectNodes("entry"))
            {
                string key      = entry.Attributes["keyword"]?.Value;
                string itemType = entry.Attributes["itemType"]?.Value;
                string ctorCsv  = entry.Attributes["ctorArgs"]?.Value;

                var lines = entry.SelectNodes("line")
                                 .OfType<XmlNode>()
                                 .Select(l => l.InnerText.Trim())
                                 .Where(s => s.Length > 0)
                                 .ToList();

                if (String.IsNullOrEmpty(key) || lines.Count == 0)
                    continue;

                dt.AddEntry(key, lines, itemType, ctorCsv);
            }

            // --- NEW: parse <attachment> tags ---
            foreach (XmlNode aNode in node.SelectNodes("attachment"))
            {
                // must specify type="XmlPrismaticSpray" (or any XmlAttachment subclass)
                string typeName = aNode.Attributes["type"]?.Value;
                if (String.IsNullOrEmpty(typeName))
                    continue;

                Type t = ScriptCompiler.FindTypeByName(typeName);
                if (t == null)
                {
                    Console.WriteLine($"[Traits] Unknown attachment type '{typeName}' in '{name}'.");
                    continue;
                }

                // optional ctorArgs="1,30,10"
                var ctorCsv = aNode.Attributes["ctorArgs"]?.Value;
                var ctorArgs = DataTrait.ParseArgs(ctorCsv);

                // collect any other attributes as property overrides
                var props = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);
                foreach (XmlAttribute at in aNode.Attributes)
                {
                    if (at.Name.Equals("type", StringComparison.OrdinalIgnoreCase) ||
                        at.Name.Equals("ctorArgs", StringComparison.OrdinalIgnoreCase))
                        continue;

                    props[at.Name] = at.Value;
                }

                dt.AddAttachment(t, ctorArgs, props);
            }

            return dt;
        }
    }

    public interface ITrait
    {
        string Name    { get; }
        int    Priority { get; }
        bool   TryGetResponse(string speech, out string response);
    }

	public interface IItemTrait : ITrait
	{
		bool TryGetResponse(string speech, out string response, out Item item, out string keyword);
	}


    /// <summary>
    /// Core implementation: holds dialogue/item entries _and_ XML attachments.
    /// </summary>
    internal sealed class DataTrait : IItemTrait, IAttachmentTrait
    {
        // existing dialogue/item bank
        private class Entry
        {
            public string[] Lines;
            public Func<Item> Factory;
        }
		private readonly Dictionary<string, Entry> _bank =
			new Dictionary<string, Entry>(StringComparer.OrdinalIgnoreCase);

		private readonly List<AttachmentInfo> _attachments = new List<AttachmentInfo>();


        private sealed class AttachmentInfo
        {
            public Type Type;
            public object[] CtorArgs;
            public Dictionary<string,string> Props;
        }

        public string Name     { get; private set; }
        public int    Priority { get; private set; }

        public DataTrait(string name, int priority)
        {
            Name     = name;
            Priority = priority;
        }

        public void AddEntry(string keyword, List<string> lines, string itemType, string ctorCsv)
        {
            Func<Item> factory = null;
            if (!String.IsNullOrEmpty(itemType))
            {
                var t = ScriptCompiler.FindTypeByName(itemType);
                if (t == null)
                    Console.WriteLine($"[Traits] Unknown item type '{itemType}' in '{Name}'.");
                else
                {
                    var args = ParseArgs(ctorCsv);
                    factory = () => (Item)Activator.CreateInstance(t, args);
                }
            }
            _bank[keyword] = new Entry { Lines = lines.ToArray(), Factory = factory };
        }

		public bool TryGetResponse(string speech, out string response)
		{
			Item dummy;
			string dummyKeyword;
			return TryGetResponse(speech, out response, out dummy, out dummyKeyword);
		}


		public bool TryGetResponse(string speech, out string response, out Item item, out string keyword)
		{
			foreach (var kvp in _bank)
			{
				if (speech.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					var e = kvp.Value;
					response = e.Lines[Utility.Random(e.Lines.Length)];
					item = e.Factory != null ? e.Factory() : null;
					keyword = kvp.Key;
					return true;
				}
			}
			response = null;
			item = null;
			keyword = null;
			return false;
		}


        // ----- NEW: attachment support -----

        public void AddAttachment(Type t, object[] args, Dictionary<string,string> props)
        {
            _attachments.Add(new AttachmentInfo {
                Type     = t,
                CtorArgs = args,
                Props     = props
            });
        }

        public void AttachTo(Mobile target)
        {
            foreach (var info in _attachments)
            {
                // create the XmlAttachment subclass
                var att = (XmlAttachment)Activator.CreateInstance(info.Type, info.CtorArgs);

                // apply any property overrides
                foreach (var kv in info.Props)
                {
                    var pi = info.Type.GetProperty(
                        kv.Key,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
                    );
                    if (pi != null && pi.CanWrite)
                        pi.SetValue(att, Convert.ChangeType(kv.Value, pi.PropertyType));
                }

                // attach into XmlSpawner2
                XmlAttach.AttachTo(target, att);
            }
        }

        // helper: parse comma-separated ctor args into ints, doubles, bools or strings
        internal static object[] ParseArgs(string csv)
        {
            if (String.IsNullOrEmpty(csv))
                return Array.Empty<object>();

            var parts = csv.Split(',');
            var args  = new List<object>();
            foreach (var p in parts)
            {
                var s = p.Trim();
                if (Int32.TryParse(s,   out var i))
                    args.Add(i);
                else if (Double.TryParse(s, out var d))
                    args.Add(d);
                else if (Boolean.TryParse(s, out var b))
                    args.Add(b);
                else
                    args.Add(s);
            }
            return args.ToArray();
        }
    }
}
