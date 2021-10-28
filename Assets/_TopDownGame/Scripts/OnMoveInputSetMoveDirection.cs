﻿using System;
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
        [SerializeField] private ObservableFloatReference _speedReference;
        private Vector2 _moveDirection;


        [Inject]
        private void Construct(InputActionsProvider inputActions)
        {
            inputActions.Move.performed += OnPerformed;
        }

        private void Awake()
        {
            _mover = GetComponentInParent<IMove>();
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            _moveDirection = obj.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            var observableSpeed = _speedReference.Get();
            float speed = observableSpeed.Read();
            _mover.Move(_moveDirection, speed);
        }
    }
}