using UnityEngine;

namespace TopDownGame
{
    public abstract class OnIsMovingChangedEvent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponentInParent<IMove>().IsMoving.OnValueChanged += OnIsMovingChanged;
        }

        protected abstract void OnIsMovingChanged(bool isMoving);
    }
}
