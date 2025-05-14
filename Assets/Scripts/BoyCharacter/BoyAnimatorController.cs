using System.Collections;
using Pathfinding;
using UnityEngine;

namespace BoyCharacter
{
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(BoyAnimator))]
    public class BoyAnimatorController : MonoBehaviour
    {
        private Vector3 _target;
        private int _idleDuration = 3;
        private int _danceDuration = 6;
        private AIPath _path;
        private Coroutine _controlAnimator;
        private BoyAnimator _animator;

        private void Awake()
        {
            _path = GetComponent<AIPath>();
            _animator = GetComponent<BoyAnimator>();
        }

        private void OnDisable()
        {
            StopControl();
        }

        public void Init(Transform target)
        {
            if (_path != null)
            {
                _target = target.transform.position;
                StopControl();
                _controlAnimator = StartCoroutine(ControlAnimator());
            }
        }

        private void StopControl()
        {
            if (_controlAnimator != null)
            {
                StopCoroutine(_controlAnimator);
            }
        }

        private IEnumerator ControlAnimator()
        {
            var waitForSecondsIdle = new WaitForSeconds(_idleDuration);
            var waitForSecondsDance = new WaitForSeconds(_danceDuration);
            _animator.PlayIdleAnimation();
            yield return waitForSecondsIdle;
            _path.destination = _target;
            _animator.PlayRunAnimation();
            yield return new WaitUntil(() => _path.reachedEndOfPath);
            _animator.PlayDanceAnimation();
            yield return waitForSecondsDance;
            StopControl();
            Destroy(gameObject);
        }
    }
}