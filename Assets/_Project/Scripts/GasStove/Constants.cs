using System.Collections.Generic;

namespace GasStove
{
    public static class Constants
    {
        public static readonly Dictionary<float, KnobRotatePosition> KnobValueToKnobState = new()
        {
            { 0f, KnobRotatePosition.Low },
            { 0.5f, KnobRotatePosition.High },
            { 1f, KnobRotatePosition.Disabled }
        };
        
        public const float GAS_STRENGTH_DISABLE = 0f;
        public const float GAS_STRENGTH_LOW = 0.5f;
        public const float GAS_STRENGTH_HIGH = 1f;
        
        public static readonly Dictionary<KnobRotatePosition, float> KnobStateToGasStrength = new()
        {
            { KnobRotatePosition.Disabled, GAS_STRENGTH_DISABLE },
            { KnobRotatePosition.Low, GAS_STRENGTH_LOW },
            { KnobRotatePosition.High, GAS_STRENGTH_HIGH }
        };
    }
}