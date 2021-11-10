using UnityEngine;

namespace TopDownGame
{
    public class SmoothVelocityCalculator : IVelocityCalculator
    {
        public Vector2 Calculate(Vector2 currentVelocity,
                                 Vector2 targetVelocity,
                                 float acceleration,
                                 ref Vector2 smoothVelocity)
        {
            var speed = Vector2.SmoothDamp(currentVelocity,
                                           targetVelocity,
                                           ref smoothVelocity,
                                           acceleration);

            return speed;
        }
    }
}
