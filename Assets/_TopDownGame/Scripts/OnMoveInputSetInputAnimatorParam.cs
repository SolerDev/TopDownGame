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
        private void Construct(InputActionsProvider inputActions/*, AnimatorParametersController animParamCtrl*/)
        {
            var animParamCtrl = transform.parent.GetComponentInChildren<AnimatorParametersController>();

            inputActions.Move.performed += OnPerformed;

            _inputX = (AnimatorParam<float>)animParamCtrl.ParamsByName["InputX"];
            _inputY = (AnimatorParam<float>)animParamCtrl.ParamsByName["InputY"];
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            var inputDirection = obj.ReadValue<Vector2>();
            _inputX.Set(inputDirection.x);
            _inputY.Set(inputDirection.y);
        }
    }
}
