using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Server.CustomPies
{
    public static class PieAttributeRegistry
    {
        // Explicitly type the Dictionary (no target-typed new)
        private static readonly Dictionary<string, IPieAttribute> _byId = new Dictionary<string, IPieAttribute>();

        // Static constructor: discover and register every IPieAttribute in the loaded assembly
        static PieAttributeRegistry()
        {
            Assembly asm = typeof(IPieAttribute).Assembly;
            foreach (Type t in asm.GetTypes())
            {
                if (!t.IsAbstract && typeof(IPieAttribute).IsAssignableFrom(t))
                {
                    // Use Activator to create an instance
                    object instance = Activator.CreateInstance(t);
                    if (instance is IPieAttribute pieAttr)
                    {
                        _byId[pieAttr.Id] = pieAttr;
                    }
                }
            }

            Console.WriteLine($"[Pie] Loaded {_byId.Count} pie attributes.");
        }

        public static void Register(IPieAttribute attribute)
        {
            if (attribute == null || string.IsNullOrEmpty(attribute.Id))
                return;

            _byId[attribute.Id] = attribute;
        }

        public static IPieAttribute Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            IPieAttribute result;
            if (_byId.TryGetValue(id, out result))
                return result;

            return null;
        }

        public static IEnumerable<IPieAttribute> All
        {
            get { return _byId.Values; }
        }
    }
}
