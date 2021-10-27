using System;
using TopDownGame.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownGame
{
    public class MoveTowardsInputDirection : MonoBehaviour
    {
        private IMove _mover;
        private IObservableProvider<float> _speedProvider;
        private Vector2 _inputDirection;

        private void Awake()
        {
            var moveInput = GetComponentInParent<InputActionsProvider>().Move;
            moveInput.performed += OnPerformed;

            _mover = GetComponentInParent<IMove>();
            _speedProvider = GetComponentInParent<SpeedProvider>();
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            _inputDirection = obj.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _mover.Move(_inputDirection, _speedProvider.Observed);
        }
    }
}
