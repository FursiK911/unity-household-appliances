using System.Collections.Generic;
using GasStove;
using Instruments;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class GameplayProcessChecker : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Burner[] _burners;
        [SerializeField] private GasAnalyzer _gasAnalyzer;
        [SerializeField] private FinishedView _finishedView;

        private Dictionary<GameplayProcessStep, bool> _processSteps;

        public void Initialize()
        {
            UnsubscribeBurners();
            UnsubscribeGasAnalyzer();
            
            _finishedView.gameObject.SetActive(false);
            _processSteps = new Dictionary<GameplayProcessStep, bool>(Constants.ProcessSteps);
            
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
            if (strength <= 0)
            {
                return;
            }
            
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
            
            if (_processSteps.ContainsKey(GameplayProcessStep.GasScan))
            {
                _processSteps[GameplayProcessStep.GasScan] = true;
            }
            
            UnsubscribeGasAnalyzer();
            CheckFinished();
        }

        private void CheckFinished()
        {
            Debug.Log("[GameplayProcessChecker] Checking finished view");
            if (_processSteps.Values.Count == 0)
            {
                Debug.LogError("[GameplayProcessChecker] Steps is empty");
                return;
            }
            
            foreach (var value in _processSteps.Values)
            {
                Debug.Log($"[GameplayProcessChecker] {value}");
                if (!value)
                {
                    return;
                }
            }
            
            _finishedView.gameObject.SetActive(true);
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