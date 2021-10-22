using System;
using UnityEngine;

namespace TopDownGame
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour, IMover
    {
        public event Action<Vector2> OnMoved;

        private Rigidbody2D _rb;
        private Vector2 _previousPosition;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Moves the object via it's Rigidbody2D. Should be used inside FixedUpdate.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public void Move(Vector2 direction, float speed)
        {
            var targetTranslation = direction * speed;
            _rb.position += targetTranslation;
        }

        private void FixedUpdate()
        {
            if (HasMoved(out var movement))
                OnMoved?.Invoke(movement);
        }

        private bool HasMoved(out Vector2 movement)
        {
            var currentPosition = _rb.position;
            movement = currentPosition - _previousPosition;
            _previousPosition = currentPosition;

            return !movement.Equals(Vector2.zero);
        }
    }

    public interface IMover
    {
        event Action<Vector2> OnMoved;

        void Move(Vector2 direction, float speed);
    }
}
