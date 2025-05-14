using System;
using System.Collections;
using System.Collections.Generic;
using InteractiveObjects;
using UnityEngine;

namespace PlayerCharacter
{
    public class PlayerInteractableDetector : MonoBehaviour
    {
        private float _range = 0.7f;
        private float _iterationTime = 0.3f;
        private Coroutine _searchInteractable;
        private bool _isScanning = false;
        private bool _isFound = false;
        private List<IInteractable> _interactableObjects = new();

        public event Action<IInteractable> Found;
        public event Action Lost;

        private void Start()
        {
            StopSearch();
            _isScanning = true;
            _searchInteractable = StartCoroutine(TrySearch());
        }

        private void OnDestroy()
        {
            StopSearch();
        }

        private void StopSearch()
        {
            if (_searchInteractable != null)
            {
                _isScanning = false;
                StopCoroutine(_searchInteractable);
            }
        }

        private IEnumerator TrySearch()
        {
            var waitForSeconds = new WaitForSeconds(_iterationTime);

            while (_isScanning)
            {
                _interactableObjects.Clear();
                Collider[] hitObjects = Physics.OverlapSphere(
                transform.position,
                _range);

                foreach (var hitObject in hitObjects)
                {
                    if (hitObject.TryGetComponent(out IInteractable interactable))
                        _interactableObjects.Add(interactable);
                }

                if (_interactableObjects.Count > 0)
                {
                    if (!_isFound)
                    {
                        _isFound = true;
                        Found?.Invoke(_interactableObjects[0]);
                    }
                }
                else
                {
                    if (_isFound)
                    {
                        _isFound = false;
                        Lost?.Invoke();
                    }
                }

                yield return waitForSeconds;
            }
        }
    }
}