using System;
using UnityEngine;

namespace TopDownGame
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour, IMove
    {
        [SerializeField] private float _accelerationTime = 0.35f;
        [SerializeField] private float _decelerationTime = 0.2f;

        public event Action<Vector2> OnMoved;
        public Observable<bool> IsMoving { get; private set; } = new Observable<bool>();

        private Rigidbody2D _rb;
        private Vector2 _previousPosition;
        private Vector2 _smoothVelocity;


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
            bool isStopping = direction.magnitude < 0.2f;
            var targetTranslation = direction * speed;
            var currentPosition = _rb.position;
            var targetPosition = currentPosition + targetTranslation;

            var smoothPosition = Vector2.SmoothDamp(currentPosition,
                                                    targetPosition,
                                                    ref _smoothVelocity,
                                                    isStopping ? _decelerationTime : _accelerationTime);

            _rb.MovePosition(smoothPosition);
        }


        private void FixedUpdate()
        {
            bool isMoving = HasMoved(out var movement);

            if (isMoving)
                OnMoved?.Invoke(movement);
        }

        private bool HasMoved(out Vector2 movement)
        {
            var currentPosition = _rb.position;
            movement = currentPosition - _previousPosition;
            _previousPosition = currentPosition;

            return movement.Equals(Vector2.zero);
        }
    }

    public interface IMove
    {
        event Action<Vector2> OnMoved;
        Observable<bool> IsMoving { get; }
        void Move(Vector2 direction, float speed);
    }
}
