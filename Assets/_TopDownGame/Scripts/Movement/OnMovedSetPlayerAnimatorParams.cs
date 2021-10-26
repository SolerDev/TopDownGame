using UnityEngine;

namespace TopDownGame
{
    public class OnMovedSetPlayerAnimatorParams : OnMovedEvent
    {
        private FloatParam _velX;
        private FloatParam _velY;

        protected override void Awake()
        {
            base.Awake();

            var animator = GetComponentInParent<Animator>();
            _velX = new FloatParam("VelX", animator);
            _velY = new FloatParam("VelY", animator);
        }

        protected override void OnMoved(Vector2 movement)
        {
            _velX.Set(movement.x);
            _velY.Set(movement.y);
        }
    }
}
