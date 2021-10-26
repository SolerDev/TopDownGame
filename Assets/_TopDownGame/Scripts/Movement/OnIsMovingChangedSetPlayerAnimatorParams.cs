using UnityEngine;

namespace TopDownGame
{
    public class OnIsMovingChangedSetPlayerAnimatorParams : OnIsMovingChangedEvent
    {
        private BoolParam _isMoving;

        protected override void Awake()
        {
            base.Awake();

            _isMoving = new BoolParam("IsMoving", GetComponentInParent<Animator>());
        }

        protected override void OnIsMovingChanged(bool isMoving)
        {
            _isMoving.Set(isMoving);
        }
    }
}
