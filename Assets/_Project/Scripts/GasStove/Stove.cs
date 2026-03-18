using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace GasStove
{
    public class Stove : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        [SerializedDictionary("Stove Handles", "Burners")]
        private SerializedDictionary<StoveKnob, Burner> _knobs;
        
        public void Initialize()
        {
            foreach (var burner in _knobs.Values)
            {
                burner.Initialize(RandomStoveBehaviorGenerator.GenerateBehavior());
            }
            
            foreach (var knob in _knobs.Keys)
            {
                knob.Initialize();
                knob.OnStoveHandleChange += HandleStoveHandleChange;
            }
        }

        private void OnDestroy()
        {
            foreach (var knob in _knobs.Keys)
            {
                knob.OnStoveHandleChange -= HandleStoveHandleChange;
            }
        }

        private void HandleStoveHandleChange(StoveKnob sender, KnobRotatePosition rotatePosition)
        {
            if (_knobs.TryGetValue(sender, out var burner))
            {
                burner.ChangeCurrentGasStrength(rotatePosition);
            }
        }
    }
}
