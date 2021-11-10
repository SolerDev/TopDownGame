using ObjectReferences;
using TopDownGame.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownGame
{
    public class OnMoveInputSetMoveDirection : MonoBehaviour
    {
        private IMove _mover;
        private Vector2 _moveDirection;


        [Inject]
        private void Construct(InputActionsProvider inputActions, IMove mover)
        {
            _mover = mover;

            inputActions.Move.performed += OnPerformed;
            inputActions.Move.canceled += OnCanceled;
        }

        private void OnCanceled(InputAction.CallbackContext obj)
        {
            _moveDirection = Vector2.zero;
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            _moveDirection = obj.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _mover.Move(_moveDirection);
        }
    }
}
