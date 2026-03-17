using System;
using UnityEngine;

namespace GasStove
{
    public class Burner: MonoBehaviour
    {
        [SerializeField] private GameObject _gasEffect;
        public void Initialize()
        {
            _gasEffect.SetActive(false);
        }

        public void ChangeState(KnobState state)
        {
            switch (state)
            {
                case KnobState.Disabled:
                    EnableGasEffect(0f);
                    break;
                case KnobState.Low:
                    EnableGasEffect(0.5f);
                    break;
                case KnobState.High:
                    EnableGasEffect(1f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void EnableGasEffect(float strength)
        {
            var normalizedStrength = Mathf.Clamp(strength, 0f, 1f);

            switch (normalizedStrength)
            {
                case 0f:
                    _gasEffect.SetActive(false);
                    break;
                case 1f:
                    _gasEffect.transform.localScale = new Vector3(1f, 1f, 1f);
                    _gasEffect.SetActive(true);
                    break;
                default:
                    _gasEffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _gasEffect.SetActive(true);
                    break;
            }
        }
    }
}