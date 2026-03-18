using System;
using GasStove;
using UnityEngine;

namespace Instruments
{
    public class GasAnalyzerSensor : MonoBehaviour
    {
        public event Action OnGasDetected;
        public event Action OnGasLost;

        private int _gasContacts;

        private void OnTriggerEnter(Collider other)
        {
            var zone = other.GetComponent<BurnerLightZone>();
            if (zone == null || !zone.IsGasOn)
                return;

            _gasContacts++;

            if (_gasContacts > 0)
            {
                OnGasDetected?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var zone = other.GetComponent<BurnerLightZone>();
            if (zone == null)
                return;

            _gasContacts = Mathf.Max(0, _gasContacts - 1);

            if (_gasContacts == 0)
            {
                OnGasLost?.Invoke();
            }
        }
    }
}