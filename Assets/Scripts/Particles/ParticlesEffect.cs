using UnityEngine;

namespace Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticlesEffect : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        Vector3 _addingPosition = new Vector3(0f, 1.4f, 0f);

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Play(Vector3 targetPosition)
        {
            _particleSystem.Play();
            transform.position = targetPosition + _addingPosition;
        }
    }
}