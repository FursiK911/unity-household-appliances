using System;
using System.Collections.Generic;
using GasStove;
using Instruments;
using UnityEngine;

namespace Gameplay
{
    public class GameplayProcessChecker : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Burner[] _burners;
        [SerializeField] private GasAnalyzer _gasAnalyzer;

        private Dictionary<GameplayProcessStep, bool> _processSteps;

        public event Action GameplayProcessFinished;

        public void Initialize()
        {
            _processSteps =  new Dictionary<GameplayProcessStep, bool>(Constants.ProcessSteps);
            
            SubscribeBurners();
            SubscribeGasAnalyzer();
        }

        private void OnDestroy()
        {
            UnsubscribeBurners();
            UnsubscribeGasAnalyzer();
        }

        private void CurrentGasStrengthChanged(float strength)
        {
            if (_processSteps.ContainsKey(GameplayProcessStep.GasOn))
            {
                _processSteps[GameplayProcessStep.GasOn] = true;
            }
            
            UnsubscribeBurners();
            
            CheckFinished();
        }
        
        private void HandleSensorStateChanged(bool gasDetected)
        {
            if (!gasDetected)
            {
                return;
            }
            
            UnsubscribeGasAnalyzer();
            CheckFinished();
        }

        private void CheckFinished()
        {
            foreach (var value in _processSteps.Values)
            {
                if (!value)
                {
                    return;
                }
            }
            
            GameplayProcessFinished?.Invoke();
        }

        private void SubscribeBurners()
        {
            foreach (var burner in _burners)
            {
                burner.CurrentGasStrengthChanged += CurrentGasStrengthChanged;
            }
        }
        
        private void UnsubscribeBurners()
        {
            foreach (var burner in _burners)
            {
                burner.CurrentGasStrengthChanged -= CurrentGasStrengthChanged;
            }
        }

        private void SubscribeGasAnalyzer()
        {
            _gasAnalyzer.SensorStateChanged += HandleSensorStateChanged;
        }
        
        private void UnsubscribeGasAnalyzer()
        {
            _gasAnalyzer.SensorStateChanged -= HandleSensorStateChanged;
        }
    }
}