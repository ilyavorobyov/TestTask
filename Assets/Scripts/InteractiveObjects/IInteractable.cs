using UnityEngine;

namespace InteractiveObjects
{
    public interface IInteractable
    {
        public Vector3 GetPosition();

        public void Hide();
    }
}