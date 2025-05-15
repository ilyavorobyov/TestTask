using ScoreTimer;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreTimerLogic _scoreTimerLogic;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private AudioSource _addScoreSound;

        private int _currentScore;
        private ScoreData _scoreData;

        private void Start()
        {
            _scoreData = ScoreData.Load();
            _currentScore = _scoreData.Score;
            Show();
        }

        private void OnEnable()
        {
            _scoreTimerLogic.ScoreAdded += OnScoreAdded;
        }

        private void OnDisable()
        {
            _scoreTimerLogic.ScoreAdded -= OnScoreAdded;
        }

        private void Show()
        {
            _scoreText.text = _currentScore.ToString();
        }

        private void OnScoreAdded()
        {
            _addScoreSound.PlayDelayed(0);
            _currentScore++;
            _scoreData.Score = _currentScore;
            Show();
            _scoreData.Save();
        }
    }
}