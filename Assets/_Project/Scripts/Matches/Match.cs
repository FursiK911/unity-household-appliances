using UnityEngine;

namespace Matches
{
    public class Match : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public void DisableRigidbody()
        {
            _rigidbody.isKinematic = false;
        }

        public void EnableRigidbody()
        {
            _rigidbody.isKinematic = true;
        }
    }
}