using UnityEngine;

namespace Matches
{
    public class Grater : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var match = other.GetComponent<Match>();
            if (match == null || match.IsBurning)
                return;

            match.Light();
        }
    }
}