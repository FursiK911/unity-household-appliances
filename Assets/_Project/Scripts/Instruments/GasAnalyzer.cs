using System;
using UnityEngine;

namespace Instruments
{
    public class GasAnalyzer : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField]
        private GasAnalyzerDisplay _display;
        [SerializeField] 
        private GasAnalyzerSensor _sensor;
        [SerializeField]
        private AudioSource _warningAudioSource;
        
        public event Action<bool> SensorStateChanged;

        public void Initialize()
        {
            _sensor.OnGasDetected -= HandleGasDetected;
            _sensor.OnGasLost -= HandleGasLost;
            
            _display.Initialize();
            
            _sensor.OnGasDetected += HandleGasDetected;
            _sensor.OnGasLost += HandleGasLost;
            
            _warningAudioSource.playOnAwake = false;
            _warningAudioSource.Stop();
            _warningAudioSource.loop = true;
        }

        public void OnDestroy()
        {
            _sensor.OnGasDetected -= HandleGasDetected;
            _sensor.OnGasLost -= HandleGasLost;
        }

        private void HandleGasLost()
        {
            _display.ShowEmptyGasScreen();
            _warningAudioSource.Stop();
            SensorStateChanged?.Invoke(false);
        }

        private void HandleGasDetected()
        {
            _display.ShowGasScreen();
            _warningAudioSource.Play();
            SensorStateChanged?.Invoke(true);
        }
    }
}