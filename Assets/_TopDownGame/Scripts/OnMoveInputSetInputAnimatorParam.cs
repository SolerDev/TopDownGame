using System;
using TopDownGame.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownGame
{
    public class OnMoveInputSetInputAnimatorParam : MonoBehaviour, IPerformedInputEvent
    {
        private AnimatorParam<float> _inputX;
        private AnimatorParam<float> _inputY;

        [Inject]
        private void Construct(InputActionsProvider inputActions, AnimatorParametersController animatorParametersController)
        {
            inputActions.Move.performed += OnPerformed;

            _inputX = animatorParametersController.GetParameter<float>("InputX");
            _inputY = animatorParametersController.GetParameter<float>("InputY");
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            var inputDirection = obj.ReadValue<Vector2>();
            _inputX.Set(inputDirection.x);
            _inputY.Set(inputDirection.y);
        }
    }
}
