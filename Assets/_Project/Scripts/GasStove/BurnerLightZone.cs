using Matches;
using UnityEngine;

namespace GasStove
{
    public class BurnerLightZone : MonoBehaviour
    {
        [SerializeField] private Burner _burner;
        
        public bool IsGasOn => _burner.IsGasOn;
        
        private void OnTriggerEnter(Collider other)
        {
            var match = other.GetComponent<Match>();
            if (match == null || !match.IsBurning)
                return;

            _burner.LightBurner();
        }
    }
}
