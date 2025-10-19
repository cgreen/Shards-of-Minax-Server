using System;
using System.Collections.Generic;
using System.Linq;
using Server;            // for Utility, etc.

public class SpeechTrait : ISpeechTrait
{
    public string Name  { get; }
    public int    Priority { get; }
    private readonly Dictionary<string, List<string>> _bank;

    public SpeechTrait(string name, int priority = 0)
    {
        Name = name; Priority = priority;
        _bank = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
    }

    protected void Add(string keyword, params string[] responses)
        => _bank[keyword] = responses.ToList();

    public bool TryGetResponse(string speech, out string response)
    {
        foreach (var kv in _bank)
            if (speech.IndexOf(kv.Key, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var list = kv.Value;
                response = list[Utility.Random(list.Count)];
                return true;
            }
        response = null; return false;
    }
}
