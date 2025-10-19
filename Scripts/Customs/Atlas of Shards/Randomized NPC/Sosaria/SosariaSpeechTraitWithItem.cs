using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;

public class SosariaSpeechTraitWithItem : SosariaSpeechTrait, SosariaIItemSpeechTrait
{
    private class Entry
    {
        public List<string> Lines;
        public Func<Item> Factory;

        public Entry(IEnumerable<string> lines, Func<Item> factory = null)
        {
            Lines = lines.ToList();
            Factory = factory;
        }
    }

    private readonly Dictionary<string, Entry> _bank2 = new Dictionary<string, Entry>(StringComparer.OrdinalIgnoreCase);

    protected SosariaSpeechTraitWithItem(string name, int priority = 0) : base(name, priority) { }

    protected void Add(string keyword, IEnumerable<string> lines)
    {
        _bank2[keyword] = new Entry(lines);
    }

    protected void Add(string keyword, IEnumerable<string> lines, Func<Item> itemFactory)
    {
        _bank2[keyword] = new Entry(lines, itemFactory);
    }

    protected new void Add(string keyword, params string[] lines)
    {
        Add(keyword, lines.ToList());
    }

    public bool TryGetResponse(string speech, out string response, out Item item)
    {
        foreach (var kv in _bank2)
        {
            if (speech.IndexOf(kv.Key, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var e = kv.Value;
                response = e.Lines[Utility.Random(e.Lines.Count)];
                item = e.Factory != null ? e.Factory() : null;
                return true;
            }
        }

        response = null;
        item = null;
        return false;
    }
}
