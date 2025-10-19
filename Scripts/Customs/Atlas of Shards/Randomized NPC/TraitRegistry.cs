using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; // for Activator & Type
using Server;            // for ScriptCompiler.Assemblies
using Server.Mobiles;    // if you’re reflecting on Mobile types, etc.


public static class TraitRegistry
{
    private static readonly List<ISpeechTrait> _all = new List<ISpeechTrait>();

    static TraitRegistry()
    {
        foreach (Type t in ScriptCompiler.Assemblies
                                         .SelectMany(a => a.GetTypes())
                                         .Where(t => typeof(ISpeechTrait).IsAssignableFrom(t)
                                                     && t.GetConstructor(Type.EmptyTypes)!=null
                                                     && !t.IsAbstract))
        {
            _all.Add((ISpeechTrait)Activator.CreateInstance(t));
        }
    }

    public static IEnumerable<ISpeechTrait> All  => _all;

    public static ISpeechTrait Random() => _all[Utility.Random(_all.Count)];
    public static IEnumerable<ISpeechTrait> Random(int count)
        => _all.OrderBy(_ => Utility.RandomDouble()).Take(count);
    public static IEnumerable<ISpeechTrait> ByNames(IEnumerable<string> names)
        => _all.Where(t => names.Contains(t.Name, StringComparer.OrdinalIgnoreCase));
}
