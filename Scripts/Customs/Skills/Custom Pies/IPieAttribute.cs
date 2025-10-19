using Server.Mobiles;

/// <summary>One discrete pie “property”, discovered automatically.</summary>
namespace Server.CustomPies
{
    public interface IPieAttribute
    {
        string Id        { get; }   // unique key (“RestoreHits”)
        string Label     { get; }   // human name (“Restore Health”)

        /// <summary>Runs when the pie is eaten.</summary>
        void Apply( Mobile eater );

        int  SoundId  { get; }      // -1 ⇒ none
        void Visual( Mobile eater );// optional particles
    }
}
