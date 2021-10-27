using System;
using System.Collections;
using System.Collections.Generic;
using TopDownGame.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownGame.Inputs
{
    public class InputActionsProvider : MonoBehaviour
    {
        private readonly PlayerInputActions _inputActions = new PlayerInputActions();
        public InputAction Move { get; private set; }

        private void OnEnable()
        {
            Move = _inputActions.Player.Move;
            Move.Enable();
        }

        private void OnDisable()
        {
            Move.Disable();
        }
    }
}
