using System;
using ObjectReferences;
using UnityEngine;
using Zenject;

namespace TopDownGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour, IMove
    {
        [SerializeField] private ObservableFloatReference _speedReference;
        [SerializeField] private float _accelerationTime = 0.35f;
        [SerializeField] private float _decelerationTime = 0.2f;

        public event Action<Vector2> OnMoved;
        public Observable<bool> IsMoving { get; private set; } = new Observable<bool>();

        private Rigidbody2D _rb;
        private IVelocityCalculator _velocityCalculator;
        private Vector2 _previousPosition;
        private Vector2 _smoothVelocity;
        private bool _wasMoving = false;



        [Inject]
        private void Construct(Rigidbody2D rb, IVelocityCalculator velocityCalculator)
        {
            _rb = rb;
            _velocityCalculator = velocityCalculator;
        }




        /// <summary>
        /// Moves the object via it's Rigidbody2D. Should be used inside FixedUpdate.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="targetSpeed"></param>
        public void Move(Vector2 direction)
        {
            bool isStopping = direction.Equals(Vector2.zero);

            var currentVelocity = _rb.velocity;
            var targetVelocity = direction * _speedReference.Get();
            float acceleration = isStopping ? _decelerationTime : _accelerationTime;

            var velocity = _velocityCalculator.Calculate(currentVelocity,
                                                         targetVelocity,
                                                         acceleration,
                                                         ref _smoothVelocity);

            _rb.velocity = velocity;
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
        void Move(Vector2 direction);
    }
}
