using System;
using UnityEngine;
using Zenject;

namespace TopDownGame
{
    public interface IMoveCalculationProvider
    {
        Vector2 Calculate(Vector2 currentPosition, Vector2 targetPosition, float acceleration, ref Vector2 smoothVelocity);
    }

    public class SmoothMovementCalculationProvider : IMoveCalculationProvider
    {
        public Vector2 Calculate(Vector2 currentPosition, Vector2 targetPosition, float acceleration, ref Vector2 smoothVelocity)
        {
            var smoothPosition = Vector2.SmoothDamp(currentPosition,
                                                    targetPosition,
                                                    ref smoothVelocity,
                                                    acceleration);
            return smoothPosition;
        }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour, IMove
    {
        [SerializeField] private float _accelerationTime = 0.35f;
        [SerializeField] private float _decelerationTime = 0.2f;

        public event Action<Vector2> OnMoved;
        public Observable<bool> IsMoving { get; private set; } = new Observable<bool>();

        private Rigidbody2D _rb;
        private IMoveCalculationProvider _moveCalculation;
        private Vector2 _previousPosition;
        private Vector2 _smoothVelocity;
        private bool _wasMoving = false;



        [Inject]
        private void Construct(Rigidbody2D rb, IMoveCalculationProvider moveCalculation)
        {
            _rb = rb;
            _moveCalculation = moveCalculation;
        }




        /// <summary>
        /// Moves the object via it's Rigidbody2D. Should be used inside FixedUpdate.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public void Move(Vector2 direction, float speed)
        {
            bool isStopping = speed == 0f || direction.Equals(Vector2.zero);
            var currentPosition = _rb.position;
            var targetPosition = currentPosition + direction * speed;


            var finalTargetPosition = _moveCalculation.Calculate(currentPosition,
                                                                 targetPosition,
                                                                 isStopping ? _accelerationTime : _decelerationTime,
                                                                 ref _smoothVelocity);

            _rb.MovePosition(finalTargetPosition);
        }

        private Vector2 GetTargetPosition(Vector2 direction, float speed)
        {
            bool isStopping = direction.magnitude < 0.2f;
            var targetTranslation = direction * speed;
            var currentPosition = _rb.position;
            var targetPosition = currentPosition + targetTranslation;

            var smoothPosition = Vector2.SmoothDamp(currentPosition,
                                                    targetPosition,
                                                    ref _smoothVelocity,
                                                    isStopping ? _decelerationTime : _accelerationTime);
            return smoothPosition;
        }

        private void FixedUpdate()
        {
            bool isMoving = HasMoved(out var movement);

            if (isMoving)
                OnMoved?.Invoke(movement);
            if (_wasMoving != isMoving)
            {
                _wasMoving = isMoving;
                IsMoving.Write(isMoving);
            }
        }

        private bool HasMoved(out Vector2 movement)
        {
            var currentPosition = _rb.position;
            movement = currentPosition - _previousPosition;
            _previousPosition = currentPosition;

            return !movement.Equals(Vector2.zero);
        }
    }

    public interface IMove
    {
        event Action<Vector2> OnMoved;
        Observable<bool> IsMoving { get; }
        void Move(Vector2 direction, float speed);
    }
}
