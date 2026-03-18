using System.Collections.Generic;

namespace Gameplay
{
    public class Constants
    {
        public static readonly Dictionary<GameplayProcessStep, bool> ProcessSteps = new()
        {
            { GameplayProcessStep.GasOn, false },
            { GameplayProcessStep.GasScan, false },
        };
    }
}