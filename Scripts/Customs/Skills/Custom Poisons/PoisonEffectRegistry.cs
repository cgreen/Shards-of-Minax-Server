using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Server.CustomPoisons
{
    public static class PoisonEffectRegistry
    {
        private static readonly Dictionary<string, IPoisonEffect> _byId = new Dictionary<string, IPoisonEffect>();

        // ---------- NEW: automatic discovery ----------
        static PoisonEffectRegistry()
        {
            RegisterAllEffects();
        }

        private static void RegisterAllEffects()
        {
            Assembly asm = typeof(IPoisonEffect).Assembly;   // Scripts.dll
            foreach (Type t in asm.GetTypes()
                                  .Where(t => !t.IsAbstract &&
                                              typeof(IPoisonEffect).IsAssignableFrom(t)))
            {
                if (Activator.CreateInstance(t) is IPoisonEffect eff)
                    Register(eff);                           // duplicates overwrite – fine
            }

            Console.WriteLine($"[Poison] Loaded {_byId.Count} poison effects.");
        }
        // ------------------------------------------------

        public static void Register(IPoisonEffect effect)  => _byId[effect.Id] = effect;
        public static IPoisonEffect Get(string id)         => _byId.TryGetValue(id, out var e) ? e : null;
        public static IEnumerable<IPoisonEffect> All       => _byId.Values;
    }
}
