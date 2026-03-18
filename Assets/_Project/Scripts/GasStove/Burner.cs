using System;
using GasStove.Interfaces;
using UnityEngine;

namespace GasStove
{
    public class Burner: MonoBehaviour
    {
        [Header("Effects")]
        [SerializeField] private GameObject _gasEffect;
        [SerializeField] private GameObject _burnerEffect;
        [SerializeField] private GameObject _cracklingEffect;
        [SerializeField] private GameObject _poppingEffect;
        
        private IGasStoveBehavior _behavior;
        private float _currentGasStrength;
        private bool _isBurning;

        public bool IsBurning => _isBurning;
        
        public void Initialize(IGasStoveBehavior behavior)
        {
            _gasEffect.SetActive(false);
            _burnerEffect.SetActive(false);
            _cracklingEffect.SetActive(false);
            _poppingEffect.SetActive(false);
            
            _behavior = behavior;
        }

        public void ChangeCurrentGasStrength(KnobState state)
        {
            if (!Constants.KnobStateToGasStrength.TryGetValue(state, out var strength))
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
            
            _currentGasStrength = strength;

            if (state == KnobState.Disabled)
            {
                _behavior.TurnOffGas(this);
            }
            else
            {
                _behavior.TurnOnGas(this);
            }
        }

        public void LightBurner()
        {
            _isBurning = true;
            _behavior.Light(this);
        }

        public void EnableGasEffect()
        {
            switch (_currentGasStrength)
            {
                case Constants.GAS_STRENGTH_DISABLE:
                    _gasEffect.SetActive(false);
                    _isBurning = false;
                    break;
                case Constants.GAS_STRENGTH_LOW:
                    _gasEffect.transform.localScale = new Vector3(1f, 1f, 1f);
                    _gasEffect.SetActive(true);
                    break;
                case Constants.GAS_STRENGTH_HIGH:
                    _gasEffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _gasEffect.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_currentGasStrength), _currentGasStrength, null);
            }
        }

        public void DisableGasEffect()
        {
            _gasEffect.SetActive(false);
        }

        public void EnableBurnerEffect()
        {
            switch (_currentGasStrength)
            {
                case Constants.GAS_STRENGTH_DISABLE:
                    _burnerEffect.SetActive(false);
                    break;
                case Constants.GAS_STRENGTH_LOW:
                    _burnerEffect.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    _burnerEffect.SetActive(true);
                    break;
                case Constants.GAS_STRENGTH_HIGH:
                    _burnerEffect.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    _burnerEffect.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_currentGasStrength), _currentGasStrength, null);
            }
        }

        public void DisableBurnerEffect()
        {
            _burnerEffect.SetActive(false);
        }

        public void EnableCracklingEffect()
        {
            _cracklingEffect.SetActive(true);
        }

        public void DisableCracklingEffect()
        {
            _cracklingEffect.SetActive(false);
        }

        public void EnablePoppingEffect()
        {
            _poppingEffect.SetActive(true);
        }

        public void DisablePoppingEffect()
        {
            _poppingEffect.SetActive(false);
        }
    }
}