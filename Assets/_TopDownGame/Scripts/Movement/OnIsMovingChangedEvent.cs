using UnityEngine;

namespace TopDownGame
{
    public abstract class OnIsMovingChangedEvent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponentInParent<IMove>().OnIsMovingChanged += OnIsMovingChanged;
        }

        protected abstract void OnIsMovingChanged(bool isMoving);
    }
}
