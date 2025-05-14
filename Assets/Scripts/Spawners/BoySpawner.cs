using BoyCharacter;
using ScoreTimer;
using UnityEngine;
using Zenject;

namespace Spawners
{
    public class BoySpawner : MonoBehaviour
    {
        [Inject] private ScoreTimerLogic _scoreTimerLogic;

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private BoyAnimatorController _boy;

        private void OnEnable()
        {
            _scoreTimerLogic.ScoreAdded += OnScoreAdded;
        }

        private void OnDisable()
        {
            _scoreTimerLogic.ScoreAdded -= OnScoreAdded;
        }

        private void OnScoreAdded()
        {
            BoyAnimatorController boy = Instantiate(_boy,
                _startPoint.position,
                transform.rotation);
            boy.Init(_targetPoint.transform);
        }
    }
}