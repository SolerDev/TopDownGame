using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TopDownGame.Tests.PlayMode
{
    public class MoverTests
    {
        private static Vector2[] s_directions = new Vector2[]
        {
            Vector2.zero,
            Vector2.left,
            Vector2.right,
            Vector2.up,
            Vector2.down,
        };

        private static float[] s_speeds = new float[]
        {
            0f,
            1f,
            -1f,
            10f,
            -10f,
        };

        [UnityTest]
        public IEnumerator Move([ValueSource(nameof(s_directions))] Vector2 direction,
                                [ValueSource(nameof(s_speeds))] float speed)
        {
            GameObject gameObject = new GameObject();
            var rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
            var mover = gameObject.AddComponent<Mover>();

            var preMovePosition = rb.position;
            mover.Move(direction, speed);

            yield return new WaitForFixedUpdate();

            var postMovePosition = rb.position;
            var movement = postMovePosition - preMovePosition;

            var expectedMovement = direction * speed;
            Assert.AreEqual(expectedMovement, movement);
        }
    }
}