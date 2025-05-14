using UnityEngine;

namespace Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class HideObjectEffect : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Play(Vector3 targetPosition)
        {
            _particleSystem.Play();
            transform.position = targetPosition;
        }
    }
}