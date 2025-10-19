using System;
using System.Collections.Generic;
using Server.Items;  // for Item

namespace Server.Regions.Sosaria.Traits
{
    public class DataDrivenSpeechTrait : SosariaSpeechTraitWithItem
    {
        public DataDrivenSpeechTrait(string name, int prio)
            : base(name, prio)
        {
        }

		public void AddEntry(string keyword, List<string> lines,
							 string itemType, string[] ctorArgs)
		{
			if (itemType == null)
			{
				Add(keyword, lines);
				return;
			}

			// Try to resolve the type by name
			var t = ScriptCompiler.FindTypeByName(itemType);
			if (t == null)
			{
				Console.WriteLine(
				  $"[Traits] ERROR: Unknown itemType '{itemType}' in trait '{Name}', keyword '{keyword}'. Entry will be skipped."
				);
				return; // skip this entry rather than blow up
			}

			Add(keyword, lines, () =>
			{
				return (Item)Activator.CreateInstance(t, ParseArgs(ctorArgs));
			});
		}


        // simplified: just parse primitives & booleans
        private static object[] ParseArgs(string[] parts)
        {
            if (parts == null || parts.Length == 0)
                return Array.Empty<object>();

            var objs = new object[parts.Length];
            for (int i = 0; i < parts.Length; i++)
                objs[i] = ToType(parts[i].Trim());

            return objs;
        }

        private static object ToType(string text)
        {
            if (int.TryParse(text, out var i))       return i;
            if (double.TryParse(text, out var d))    return d;
            if (bool.TryParse(text, out var b))      return b;
            // fall back to string (or expand for enums as needed)
            return text;
        }
    }
}
