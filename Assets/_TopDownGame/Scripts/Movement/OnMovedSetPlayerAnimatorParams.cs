using UnityEngine;
using Zenject;

namespace TopDownGame
{
    public class OnMovedSetPlayerAnimatorParams : OnMovedEvent
    {
        private AnimatorParam<float> _velX;
        private AnimatorParam<float> _velY;


        [Inject]
        private void Construct(AnimatorParametersController animatorParametersController)
        {
            _velX = animatorParametersController.GetParameter<float>("VelX");
            _velY = animatorParametersController.GetParameter<float>("VelY");
        }

        protected override void OnMoved(Vector2 movement)
        {
            _velX.Set(movement.x);
            _velY.Set(movement.y);
        }
    }
}
