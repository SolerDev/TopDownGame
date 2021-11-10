using UnityEngine;

namespace TopDownGame
{
    public interface IVelocityCalculator
    {
        Vector2 Calculate(Vector2 currentVelocity,
                          Vector2 targetVelocity,
                          float acceleration,
                          ref Vector2 smoothVelocity);
    }
}
