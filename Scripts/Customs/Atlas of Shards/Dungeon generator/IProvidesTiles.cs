// File: IProvidesTiles.cs
using System.Collections.Generic;
using Server;

namespace Server.Engines.ProceduralDungeon
{
    /// <summary>
    /// Allows a MagicMapBase to define its own layout.
    /// </summary>
    public interface IProvidesTiles
    {
        IEnumerable<TileDef> GenerateTiles(Point3D centre);
    }
}
