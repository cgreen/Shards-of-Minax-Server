using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; // for Activator & Type
using Server;            // for ScriptCompiler.Assemblies
using Server.Mobiles;    // if you’re reflecting on Mobile types, etc.
using System.IO;
using Server.Regions.Sosaria;    // wherever TraitXmlLoader lives
	
public static class SosariaTraitRegistry
{
    private static readonly List<SosariaISpeechTrait> _compiled = new List<SosariaISpeechTrait>();

    static SosariaTraitRegistry()
    {
        // only load the types from assemblies
        foreach (Type t in ScriptCompiler.Assemblies
             .SelectMany(a => a.GetTypes())
             .Where(t => typeof(SosariaISpeechTrait).IsAssignableFrom(t)
                         && t.GetConstructor(Type.EmptyTypes) != null
                         && !t.IsAbstract))
        {
            _compiled.Add((SosariaISpeechTrait)Activator.CreateInstance(t));
        }
    }

    /// <summary>All of your “hard‐coded” (compiled) traits.</summary>
    public static IEnumerable<SosariaISpeechTrait> Compiled => _compiled;

    /// <summary>Load just the XML traits from *one* file.</summary>
    public static IEnumerable<SosariaISpeechTrait> LoadFromXml(string filePath)
    {
        if (!File.Exists(filePath))
            yield break;
        foreach (var t in TraitXmlLoader.Load(filePath))
            yield return t;
    }
}

