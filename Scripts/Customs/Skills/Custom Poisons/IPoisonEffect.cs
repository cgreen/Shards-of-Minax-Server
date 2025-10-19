using System;

namespace Server.CustomPoisons
{
    public interface IPoisonEffect
    {
        string Id { get; }
        string Label { get; }
        void Apply(Mobile attacker, Mobile defender);

        int SoundId { get; }
        void Visual(Mobile defender);
    }
}

