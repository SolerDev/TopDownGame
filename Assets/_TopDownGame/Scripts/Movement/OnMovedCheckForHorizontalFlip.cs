using UnityEngine;

namespace TopDownGame
{
    public class OnMovedCheckForHorizontalFlip : OnMovedEvent
    {
        private bool _wasFacingRight = true;

        private Transform _transform;

        protected override void Awake()
        {
            base.Awake();

            _transform = transform;
        }

        protected override void OnMoved(Vector2 movement)
        {
            bool isFacingRight = movement.x.CompareTo(0) <= 0;

            if (!_wasFacingRight.Equals(isFacingRight))
            {
                _wasFacingRight = isFacingRight;
                _transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
            }
        }
    }
}
