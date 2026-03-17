using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Matches
{
    public class Matchbox : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable _xrGrabInteractable;
        [SerializeField] private Match _matchPrefab;
        [SerializeField] private Transform _matchSpawnTransform;
        
        private Match _holdedMatch;
        
        public void Initialize()
        {
            _xrGrabInteractable.activated.AddListener(HandleActivate);
            _xrGrabInteractable.deactivated.AddListener(HandleDeactivate);
        }

        public void OnDestroy()
        {
            _xrGrabInteractable.activated.RemoveListener(HandleActivate);
            _xrGrabInteractable.deactivated.RemoveListener(HandleDeactivate);
        }

        private void HandleActivate(ActivateEventArgs args)
        {
            GetMatch();
        }
        
        private void HandleDeactivate(DeactivateEventArgs args)
        {
            if (_holdedMatch != null)
            {
                ReleaseMatch();
            }
        }

        public void GetMatch()
        {
            var match = Instantiate(_matchPrefab);
            HoldMatch(match);
        }

        public void HoldMatch(Match match)
        {
            if (_holdedMatch != null)
            {
                ReleaseMatch();
            }

            _holdedMatch = match;
            _holdedMatch.transform.SetParent(_matchSpawnTransform);
            _holdedMatch.transform.localPosition = Vector3.zero;
            _holdedMatch.transform.localRotation = Quaternion.identity;
        }

        public void ReleaseMatch()
        {
            _holdedMatch.transform.SetParent(null);
            _holdedMatch.EnableRigidbody();
        }
    }
}