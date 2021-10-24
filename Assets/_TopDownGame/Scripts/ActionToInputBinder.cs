using System;
using System.Collections;
using System.Collections.Generic;
using TopDownGame.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownGame.Inputs
{
    public class ActionToInputBinder : MonoBehaviour
    {
        private IMover _mover;
        private ISpeeder _speeder;

        private PlayerInputActions _inputActions;
        private InputAction _move;
        private Vector2 _inputDirection;



        [Inject]
        private void Construct([Inject(Id = "Player")] GameObject player)
        {
            _mover = player.GetComponent<IMover>();
            _speeder = player.GetComponent<ISpeeder>();
        }

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
        }

        private void FixedUpdate()
        {
            _mover.SetMovement(_inputDirection, _speeder.Speed);
        }

        private void OnEnable()
        {
            _move = _inputActions.Player.Move;
            _move.performed += OnMoveChanged;
            _move.canceled += OnMoveChanged;
            _move.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
        }



        private void OnMoveChanged(InputAction.CallbackContext obj)
        {
            _inputDirection = obj.ReadValue<Vector2>();
        }
    }
}
