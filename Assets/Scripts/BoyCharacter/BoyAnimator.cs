using UnityEngine;

namespace BoyCharacter
{
    [RequireComponent(typeof(Animator))]
    public class BoyAnimator : MonoBehaviour
    {
        private enum AnimationState { Idle, Run, Dance }

        private const string Idle = nameof(Idle);
        private const string Run = nameof(Run);
        private const string Dance = nameof(Dance);

        private readonly int _idleAnimationHash = Animator.StringToHash(nameof(Idle));
        private readonly int _runAnimationHash = Animator.StringToHash(nameof(Run));
        private readonly int _danceAnimationHash = Animator.StringToHash(nameof(Dance));

        private Animator _animator;
        private AnimationState _currentState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _currentState = AnimationState.Idle;
        }

        public void PlayIdleAnimation()
        {
            if (_currentState == AnimationState.Idle)
                return;

            _animator.SetTrigger(_idleAnimationHash);
            _currentState = AnimationState.Idle;
        }

        public void PlayRunAnimation()
        {
            if (_currentState == AnimationState.Run)
                return;

            _animator.SetTrigger(_runAnimationHash);
            _currentState = AnimationState.Run;
        }

        public void PlayDanceAnimation()
        {
            if (_currentState == AnimationState.Dance)
                return;

            _animator.SetTrigger(_danceAnimationHash);
            _currentState = AnimationState.Dance;
        }
    }
}