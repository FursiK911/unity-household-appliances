using System.Collections.Generic;

namespace GasStove
{
    public static class Constants
    {
        public static readonly Dictionary<float, KnobState> KnobStates = new()
        {
            { 0f, KnobState.Low },
            { 0.5f, KnobState.High },
            { 1f, KnobState.Disabled }
        };
    }
}