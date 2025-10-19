using System.Collections.Generic;
using TraitSystem; // for ITrait

namespace CustomNPC
{
    public interface ITraitHolder
    {
        List<ITrait> Traits { get; }
    }
}
