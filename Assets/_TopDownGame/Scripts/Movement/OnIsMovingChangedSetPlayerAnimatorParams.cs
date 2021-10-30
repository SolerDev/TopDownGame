using UnityEngine;
using Zenject;

namespace TopDownGame
{
    public class OnIsMovingChangedSetPlayerAnimatorParams : OnIsMovingChangedEvent
    {
        private AnimatorParam<bool> _isMoving;


        [Inject]
        private void Construct(AnimatorParametersController animatorParametersController)
        {
            _isMoving = animatorParametersController.GetParameter<bool>("IsMoving");
        }

        protected override void OnIsMovingChanged(bool isMoving)
        {
            _isMoving.Set(isMoving);
        }
    }
}
