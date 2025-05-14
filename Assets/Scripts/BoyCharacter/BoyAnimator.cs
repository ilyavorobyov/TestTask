using UnityEngine;

namespace BoyCharacter
{
    [RequireComponent(typeof(Animator))]
    public class BoyAnimator : MonoBehaviour
    {
        private const string Idle = nameof(Idle);
        private const string Run = nameof(Run);
        private const string Dance = nameof(Dance);

        private readonly int _idleAnimationHash = Animator.StringToHash(nameof(Idle));
        private readonly int _runAnimationHash = Animator.StringToHash(nameof(Run));
        private readonly int _danceAnimationHash = Animator.StringToHash(nameof(Dance));

        private Animator _animator;
        private bool _isIdle = false;
        private bool _isRunning = false;
        private bool _isDancing = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayIdleAnimation()
        {
            if (!_isIdle)
            {
                _animator.SetTrigger(_idleAnimationHash);
                _isIdle = true;
                _isRunning = false;
                _isDancing = false;
            }
        }

        public void PlayRunAnimation()
        {
            if (_isIdle || _isDancing)
            {
                _animator.SetTrigger(_runAnimationHash);
                _isIdle = false;
                _isRunning = true;
                _isDancing = false;
            }
        }

        public void PlayDanceAnimation()
        {
            if (_isRunning || _isIdle)
            {
                _animator.SetTrigger(_danceAnimationHash);
                _isIdle = false;
                _isRunning = false;
                _isDancing = true;
            }
        }
    }
}