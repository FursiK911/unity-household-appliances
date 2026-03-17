using System;
using UnityEngine;
using XR;

namespace GasStove
{
    public class StoveKnob: MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private XRKnob _xrKnob;
        
        private KnobState _handleState = KnobState.Disabled;
        
        public event Action<StoveKnob, KnobState> OnStoveHandleChange;

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
            Debug.Log($"[StoveKnob] HandleValueChange: {value}", this);
            if (Constants.KnobValueToKnobState.TryGetValue(value, out var state))
            {
                ChangeHandleState(state);
            }
            else
            {
                Debug.LogError($"[StoveKnob] Unexpected handle value {value}",this);
            }
        }

        private void ChangeHandleState(KnobState state)
        {
            if (state == _handleState)
            {
                return;
            }
            
            _handleState = state;
            Debug.Log($"[StoveKnob] new state {state}");
            OnStoveHandleChange?.Invoke(this, _handleState);
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