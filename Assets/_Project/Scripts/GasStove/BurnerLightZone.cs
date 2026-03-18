using Matches;
using UnityEngine;

namespace GasStove
{
    public class BurnerLightZone : MonoBehaviour
    {
        [SerializeField] private Burner _burner;
        
        private void OnTriggerEnter(Collider other)
        {
            var match = other.GetComponent<Match>();
            if (match == null || !match.IsBurning)
                return;

            _burner.LightBurner();
        }
    }
}
