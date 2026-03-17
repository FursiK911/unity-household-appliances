using System;
using GasStove.Behaviors;
using GasStove.Interfaces;

namespace GasStove
{
    public static class RandomStoveBehaviorGenerator
    {
        private static readonly IGasStoveBehavior[] _behaviors = new IGasStoveBehavior[]
        {
            new DefaultGasStoveBehavior(),
            new CracklingGasStoveBehavior(),
            new PoppingGasStoveBehavior(),
        };

        private static readonly Random _random = new Random();

        public static IGasStoveBehavior GenerateBehavior()
        {
            var index = _random.Next(_behaviors.Length);
            return _behaviors[index];
        }
    }
}