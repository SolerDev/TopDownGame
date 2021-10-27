using System;
using System.Collections;
using System.Collections.Generic;
using TopDownGame.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownGame.Inputs
{
    public class OnFixedUpdateMove : MonoBehaviour
    {
        private IInputValueProvider<Vector2> _movementInputProvider;
        private IMove _mover;
        private ISpeeder _speeder;

        private void FixedUpdate()
        {
            _mover.Move(_movementInputProvider.InputDirection, _speeder.Speed);
        }
    }

    public class InputToValueBinder : MonoBehaviour, IInputValueProvider
    {
        private readonly PlayerInputActions _inputActions = new PlayerInputActions();
        private InputAction _move;

        private IMove _mover;
        private ISpeeder _speeder;


        public Vector2 InputDirection { get; private set; }



        [Inject]
        private void Construct([Inject(Id = "Player")] GameObject player)
        {
            _mover = player.GetComponent<IMove>();
            _speeder = player.GetComponent<ISpeeder>();
        }

        private void FixedUpdate()
        {
            _mover.Move(InputDirection, _speeder.Speed);
        }

        private void OnEnable()
        {
            _move = _inputActions.Player.Move;

            _move.performed += OnMovePerformed;
            _move.canceled += OnMoveCanceled;

            _move.Enable();
        }
        private void OnDisable()
        {
            _move.Disable();
        }




        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _mover.IsMoving.Set(false);
            OnMoveChanged(obj);
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            _mover.IsMoving.Set(true);
            OnMoveChanged(obj);
        }

        private void OnMoveChanged(InputAction.CallbackContext obj)
        {
            InputDirection = obj.ReadValue<Vector2>();
        }
    }
}
