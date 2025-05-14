using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ScoreTimer
{
    public class ScoreTimerView : MonoBehaviour
    {
        [Inject] private ScoreTimerViewObject _scoreTimerViewObject;
        [Inject] private ScoreTimerLogic _scoreTimerLogic;

        [SerializeField] private TMP_Text _rewardDelayText;
        [SerializeField] private TMP_Text _currentTimeText;
        [SerializeField] private Image _scoreTimerFilling;
        [SerializeField] private Transform _player;

        private Vector3 _offset = new Vector3(0, 3f, 0);
        private Vector3 _worldPos;
        private Vector3 _screenPos;
        private float _rewardDelay;
        private float _timer;

        private void Start()
        {
            _scoreTimerLogic.Timer
            .Subscribe(OnTimerChanged)
            .AddTo(this);
        }

        private void OnEnable()
        {
            _scoreTimerLogic.CountStarted += OnCountStarted;
            _scoreTimerLogic.CountEnded += OnCountEnded;
        }

        private void OnDisable()
        {
            _scoreTimerLogic.CountStarted -= OnCountStarted;
            _scoreTimerLogic.CountEnded -= OnCountEnded;
        }

        private void OnTimerChanged(int timer)
        {
            _timer = timer;
            _currentTimeText.text = _timer.ToString();

            if (_rewardDelay > 0)
            {
                _scoreTimerFilling.fillAmount = Mathf.Clamp01(_timer / _rewardDelay);
            }
        }

        private void OnCountStarted(Vector3 vector, int rewardDelay)
        {
            _rewardDelay = rewardDelay;
            _scoreTimerFilling.fillAmount = 0;
            _scoreTimerViewObject.gameObject.SetActive(true);
            _rewardDelayText.text = _rewardDelay.ToString();
        }

        private void OnCountEnded()
        {
            if (_scoreTimerViewObject != null)
                _scoreTimerViewObject.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_scoreTimerViewObject.gameObject.activeSelf)
            {
                _worldPos = _player.position + _offset;
                _screenPos = Camera.main.WorldToScreenPoint(_worldPos);
                _scoreTimerViewObject.transform.position = _screenPos;
            }
        }
    }
}