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


        [Inject]
        private void Construct(PlayerInputActions inputActions)
        {
            Move = inputActions.Player.Move;
        }

        private void OnEnable()
        {
            Move.Enable();
        }

        private void OnDisable()
        {
            Move.Disable();
        }
    }
}
