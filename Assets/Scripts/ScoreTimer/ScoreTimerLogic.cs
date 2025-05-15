using System;
using System.Collections;
using InteractiveObjects;
using Particles;
using PlayerCharacter;
using UniRx;
using UnityEngine;

namespace ScoreTimer
{
    public class ScoreTimerLogic : MonoBehaviour
    {
        [SerializeField] private PlayerInteractableDetector _playerInteractableDetector;
        [SerializeField] private ParticlesEffect _hideObjectEffect;
        [SerializeField] private ScoreTimerView _scoreTimerView;

        private int _rewardDelay = 3;
        private int _iterationTime = 1;
        private int _startTime = 0;
        private bool _isCounting = false;
        private IInteractable _currentObject;
        private Coroutine _countTimer;

        private ReactiveProperty<int> _timer = new ReactiveProperty<int>();

        public IReadOnlyReactiveProperty<int> Timer => _timer;

        public event Action ScoreAdded;
        public event Action<Vector3, int> CountStarted;
        public event Action CountEnded;

        private void OnEnable()
        {
            _playerInteractableDetector.Found += OnFound;
            _playerInteractableDetector.Lost += OnLost;
        }

        private void OnDisable()
        {
            _playerInteractableDetector.Found -= OnFound;
            _playerInteractableDetector.Lost -= OnLost;
            StopCount();
        }

        private void StopCount()
        {
            if (_countTimer != null)
            {
                _isCounting = false;
                StopCoroutine(_countTimer);
                CountEnded?.Invoke();
            }
        }

        private void AddScore()
        {
            _hideObjectEffect.Play(_currentObject.GetPosition());
            _currentObject.Hide();
            ScoreAdded?.Invoke();
        }

        private IEnumerator TrySearch()
        {
            var waitForSeconds = new WaitForSeconds(_iterationTime);
            _timer.Value = _startTime;

            while (_isCounting)
            {
                if (_timer.Value > _rewardDelay)
                    break;

                yield return waitForSeconds;
                _timer.Value++;
            }

            AddScore();
            StopCount();
        }

        private void OnFound(IInteractable interactable)
        {
            _currentObject = interactable;
            StopCount();
            _isCounting = true;
            _countTimer = StartCoroutine(TrySearch());
            CountStarted?.Invoke(_currentObject.GetPosition(), _rewardDelay);
        }

        private void OnLost()
        {
            StopCount();
        }
    }
}