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

        private InputAction.CallbackContext _moveDirectionContext;
        private bool _isMoving = false;



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
            if (_isMoving)
                _mover.Move(_moveDirectionContext.ReadValue<Vector2>(), _speeder.Speed);
        }

        private void OnEnable()
        {
            _move = _inputActions.Player.Move;
            _move.performed += OnBeginMove;
            _move.canceled += OnEndMove;
            _move.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
        }



        private void OnBeginMove(InputAction.CallbackContext obj)
        {
            _isMoving = true;
            _moveDirectionContext = obj;
        }

        private void OnEndMove(InputAction.CallbackContext _)
        {
            _isMoving = false;
        }
    }
}
