using BoyCharacter;
using Particles;
using ScoreTimer;
using UnityEngine;

namespace Spawners
{
    public class BoySpawner : MonoBehaviour
    {
        [SerializeField] private ScoreTimerLogic _scoreTimerLogic;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private BoyAnimatorController _boy;
        [SerializeField] private ParticlesEffect _boyEffect;

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
            boy.Init(_targetPoint.transform, _boyEffect);
            _boyEffect.Play(boy.transform.position);
        }
    }
}