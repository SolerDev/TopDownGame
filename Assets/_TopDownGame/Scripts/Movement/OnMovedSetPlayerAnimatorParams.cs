using UnityEngine;

namespace TopDownGame
{
    public class OnMovedSetPlayerAnimatorParams : OnMovedEvent
    {
        private FloatParam _inputX;
        private FloatParam _inputY;

        protected override void Awake()
        {
            base.Awake();

            var animator = GetComponentInParent<Animator>();
            _inputX = new FloatParam("InputX", animator);
            _inputY = new FloatParam("InputY", animator);
        }

        protected override void OnMoved(Vector2 movement)
        {
            _inputX.Set(movement.x);
            _inputY.Set(movement.y);
        }
    }
}
