using ScoreTimer;
using UnityEngine;
using Zenject;

namespace Graph
{
    public class GraphUpdater : MonoBehaviour
    {
        [Inject] private ScoreTimerLogic _scoreTimerLogic;

        private void OnEnable()
        {
            _scoreTimerLogic.ScoreAdded += OnUpdated;
        }

        private void OnDisable()
        {
            _scoreTimerLogic.ScoreAdded -= OnUpdated;
        }

        private void OnUpdated()
        {
            AstarPath.active.Scan();
        }
    }
}