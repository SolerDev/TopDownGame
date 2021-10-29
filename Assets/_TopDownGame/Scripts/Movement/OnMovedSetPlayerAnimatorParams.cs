using UnityEngine;

namespace TopDownGame
{
    public class OnMovedSetPlayerAnimatorParams : OnMovedEvent
    {
        private AnimatorParam<float> _velX;
        private AnimatorParam<float> _velY;

        protected override void Awake()
        {
            base.Awake();

            var animatorParametersController = transform.parent.GetComponentInChildren<AnimatorParametersController>();
            _velX = (AnimatorParam<float>)animatorParametersController.ParamsByName["VelX"];
            _velY = (AnimatorParam<float>)animatorParametersController.ParamsByName["VelY"];

            //var animator = transform.parent.GetComponentInChildren<Animator>();
            //_velX = new FloatParam("VelX", animator);
            //_velY = new FloatParam("VelY", animator);
        }

        protected override void OnMoved(Vector2 movement)
        {
            _velX.Set(movement.x);
            _velY.Set(movement.y);
        }
    }
}
