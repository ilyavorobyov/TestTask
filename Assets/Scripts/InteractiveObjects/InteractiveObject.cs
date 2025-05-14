using UnityEngine;

namespace InteractiveObjects
{
    public class InteractiveObject : MonoBehaviour, IInteractable
    {
        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}