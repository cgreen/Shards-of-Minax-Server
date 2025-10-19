using System;
using System.Collections.Generic;
using System.Linq;


public interface ISpeechTrait
{
    string Name   { get; }
    int    Priority { get; }       // higher = wins collisions
    bool   TryGetResponse(string speech, out string response);
}
