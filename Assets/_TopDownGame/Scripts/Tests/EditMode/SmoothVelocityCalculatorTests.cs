using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TopDownGame.Tests.PlayMode
{
    public class SmoothVelocityCalculatorTests
    {
        private Vector2 _smoothVelocity;

        private static readonly Vector2[] s_currentVelocities = new Vector2[]
        {
            Vector2.zero,
            Vector2.one,
            new Vector2(-1f,-1f),
        };

        private static readonly Vector2[] s_targetVelocities = new Vector2[]
        {
            Vector2.zero,
            Vector2.one,
            new Vector2(-1f,-1f),
        };

        private static readonly float[] s_accelerations = new float[]
        {
            0f,
            -1f,
            10f,
        };


        [Test]
        public void Calculate([ValueSource(nameof(s_currentVelocities))] Vector2 currentVelocity,
                              [ValueSource(nameof(s_targetVelocities))] Vector2 targetVelocity,
                              [ValueSource(nameof(s_accelerations))] float acceleration)
        {
            //arrange
            var calculator = new SmoothVelocityCalculator();

            //act
            var actual = calculator.Calculate(currentVelocity,
                                              targetVelocity,
                                              acceleration,
                                              ref _smoothVelocity);

            //assert
            var expected = Vector2.SmoothDamp(currentVelocity,
                                              targetVelocity,
                                              ref _smoothVelocity,
                                              acceleration);

            Assert.AreEqual(expected, actual);
        }
    }
}