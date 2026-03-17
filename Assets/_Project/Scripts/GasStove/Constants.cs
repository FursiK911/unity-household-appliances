using System.Collections.Generic;

namespace GasStove
{
    public static class Constants
    {
        public static readonly Dictionary<float, KnobState> KnobValueToKnobState = new()
        {
            { 0f, KnobState.Low },
            { 0.5f, KnobState.High },
            { 1f, KnobState.Disabled }
        };
        
        public const float GAS_STRENGTH_DISABLE = 0f;
        public const float GAS_STRENGTH_LOW = 0.5f;
        public const float GAS_STRENGTH_HIGH = 1f;
        
        public static readonly Dictionary<KnobState, float> KnobStateToGasStrength = new()
        {
            { KnobState.Low, GAS_STRENGTH_DISABLE },
            { KnobState.High, GAS_STRENGTH_LOW },
            { KnobState.Disabled, GAS_STRENGTH_HIGH }
        };
    }
}