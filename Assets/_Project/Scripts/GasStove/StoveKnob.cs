using System;
using UnityEngine;
using XR;

namespace GasStove
{
    public class StoveKnob: MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private XRKnob _xrKnob;
        
        private KnobRotatePosition _knobRotatePosition = KnobRotatePosition.Disabled;
        
        public event Action<StoveKnob, KnobRotatePosition> OnStoveHandleChange;

        public void Initialize()
        {
            _xrKnob.onValueChange.RemoveListener(HandleValueChange);
            
            _xrKnob.maxAngle = 0f;
            _xrKnob.minAngle = -180f;
            _xrKnob.AngleIncrement = 90f;
            _xrKnob.value = 1f;
            
            _xrKnob.onValueChange.AddListener(HandleValueChange);
        }

        private void OnDestroy()
        {
            _xrKnob.onValueChange.RemoveListener(HandleValueChange);
        }

        private void HandleValueChange(float value)
        {
            //Debug.Log($"[StoveKnob] HandleValueChange: {value}", this);
            if (Constants.KnobValueToKnobState.TryGetValue(value, out var state))
            {
                ChangeHandleState(state);
            }
            else
            {
                Debug.LogError($"[StoveKnob] Unexpected handle value {value}",this);
            }
        }

        private void ChangeHandleState(KnobRotatePosition rotatePosition)
        {
            if (rotatePosition == _knobRotatePosition)
            {
                return;
            }
            
            _knobRotatePosition = rotatePosition;
            Debug.Log($"[StoveKnob] new rotatePosition {rotatePosition}");
            OnStoveHandleChange?.Invoke(this, _knobRotatePosition);
        }

        // private void OnValidate()
        // {
        //     if (_xrKnob == null)
        //     {
        //         _xrKnob = GetComponent<XRKnob>();
        //     }
        // }
    }
}