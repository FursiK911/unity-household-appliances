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

        public float CurrentGasStrength => _currentGasStrength;
        public bool IsBurning => _isBurning;
        public bool IsGasOn => _currentGasStrength > 0;
        
        public event Action<float> CurrentGasStrengthChanged;
        public event Action<bool> BurningChanged;
        
        public void Initialize(IGasStoveBehavior behavior)
        {
            _gasEffect.SetActive(false);
            _burnerEffect.SetActive(false);
            _cracklingEffect.SetActive(false);
            _poppingEffect.SetActive(false);
            
            _behavior = behavior;
        }

        public void ChangeCurrentGasStrength(KnobRotatePosition rotatePosition)
        {
            if (!Constants.KnobStateToGasStrength.TryGetValue(rotatePosition, out var strength))
                throw new ArgumentOutOfRangeException(nameof(rotatePosition), rotatePosition, null);
            
            _currentGasStrength = strength;
            CurrentGasStrengthChanged?.Invoke(strength);

            if (rotatePosition == KnobRotatePosition.Disabled)
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

        public void ChangeGasEffect(float gasStrength)
        {
            switch (gasStrength)
            {
                case Constants.GAS_STRENGTH_DISABLE:
                    DisableGasEffect();
                    break;
                case Constants.GAS_STRENGTH_LOW:
                    _gasEffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _gasEffect.SetActive(true);
                    break;
                case Constants.GAS_STRENGTH_HIGH:
                    _gasEffect.transform.localScale = new Vector3(1f, 1f, 1f);
                    _gasEffect.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gasStrength), gasStrength, null);
            }
        }

        public void DisableGasEffect()
        {
            _gasEffect.SetActive(false);
            _isBurning = false;
        }

        public void ChangeBurnerEffect(float gasStrength)
        {
            switch (gasStrength)
            {
                case Constants.GAS_STRENGTH_DISABLE:
                    DisableBurnerEffect();
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
                    throw new ArgumentOutOfRangeException(nameof(gasStrength), gasStrength, null);
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