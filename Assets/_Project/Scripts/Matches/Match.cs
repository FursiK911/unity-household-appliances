using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Matches
{
    public class Match : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _burnEffect;
        [SerializeField] private XRGrabInteractable _xrGrabInteractable;

        public bool IsBurning => _burnEffect.activeInHierarchy;
        
        public event Action<SelectEnterEventArgs> OnSelectEnter;

        public void Initialize()
        {
            _xrGrabInteractable.selectEntered.RemoveListener(HandleSelectEntered);
            _xrGrabInteractable.selectExited.RemoveListener(HandleSelectExited);
            
            _burnEffect.SetActive(false);
            
            _xrGrabInteractable.selectEntered.AddListener(HandleSelectEntered);
            _xrGrabInteractable.selectExited.AddListener(HandleSelectExited);
        }

        private void OnDestroy()
        {
            _xrGrabInteractable.selectEntered.RemoveListener(HandleSelectEntered);
            _xrGrabInteractable.selectExited.RemoveListener(HandleSelectExited);
        }

        private void HandleSelectEntered(SelectEnterEventArgs args)
        {
            OnSelectEnter?.Invoke(args);
        }
        
        private void HandleSelectExited(SelectExitEventArgs args)
        {
            _rigidbody.isKinematic = false;
        }

        public void DisableRigidbody()
        {
            _rigidbody.isKinematic = true;
        }

        public void EnableRigidbody()
        {
            _rigidbody.isKinematic = false;
        }

        public void Light()
        {
            _burnEffect.SetActive(true);
        }

        public void Extinguish()
        {
            _burnEffect.SetActive(false);
        }
    }
}