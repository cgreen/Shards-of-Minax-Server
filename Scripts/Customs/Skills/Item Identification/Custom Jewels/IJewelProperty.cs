using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.CustomJewels
{
    public interface IJewelProperty
    {
        string Id    { get; }
        string Label { get; }
        int    Icon  { get; }
        void   Apply(Mobile crafter, object target);
    }

    public static class JewelPropertyRegistry
    {
        private static readonly Dictionary<string, IJewelProperty> _byId =
            new Dictionary<string, IJewelProperty>();

        static JewelPropertyRegistry()
        {
            // Auto-discover and register every IJewelProperty implementation
            var asm = typeof(IJewelProperty).Assembly;
            foreach (var t in asm.GetTypes().Where(t =>
                !t.IsAbstract && typeof(IJewelProperty).IsAssignableFrom(t)))
            {
                // CreateInstance will call the parameterless ctor of each IJewelProperty
                object instance = Activator.CreateInstance(t);
                if (instance is IJewelProperty prop)
                {
                    _byId[prop.Id] = prop;
                }
            }

            Console.WriteLine($"[Jewels] Loaded {_byId.Count} jewel properties.");
        }

        /// <summary>
        /// Returns the IJewelProperty with the given ID, or null if not found.
        /// </summary>
        public static IJewelProperty Get(string id)
        {
            if (id == null) return null;
            IJewelProperty result;
            if (_byId.TryGetValue(id, out result))
                return result;
            return null;
        }

        /// <summary>
        /// All registered properties.
        /// </summary>
        public static IEnumerable<IJewelProperty> All
        {
            get { return _byId.Values; }
        }
    }
}
