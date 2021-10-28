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
        public InputAction Move { get; private set; }

        private void OnEnable()
        {
            var inputActions = new PlayerInputActions();
            Move = inputActions.Player.Move;
            Move.Enable();
        }

        private void OnDisable()
        {
            Move.Disable();
        }
    }
}
