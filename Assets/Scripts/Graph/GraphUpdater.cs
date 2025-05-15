using ScoreTimer;
using UnityEngine;

namespace Graph
{
    public class GraphUpdater : MonoBehaviour
    {
        [SerializeField] private ScoreTimerLogic _scoreTimerLogic;

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