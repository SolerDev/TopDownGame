//using System.Collections;
//using Extensions;
//using NUnit.Framework;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.TestTools;

//namespace TopDownGame.Tests.EditMode
//{
//    public class MoverTests
//    {
//        private static readonly Vector2[] s_directions = new Vector2[]
//        {
//            Vector2.zero,
//            Vector2.left,
//            Vector2.down,
//            Vector2.one,
//        };

//        private static readonly float[] s_speeds = new float[]
//        {
//            -2f,
//            0f,
//            2f
//        };

//        private static readonly float[] s_decelerationTimes = new float[]
//        {
//            0f,
//            .25f,
//            .5f,
//        };

//        private static readonly float[] s_accelerationTimes = new float[]
//        {
//            0f,
//            .25f,
//            .5f,
//        };

//        private static readonly Vector2[] s_initialVelocity = new Vector2[]
//        {
//            Vector2.zero,
//            Vector2.one,
//            Vector2.one*20f
//        };


//        [Test]
//        public void GetTargetPositionTest([ValueSource(nameof(s_directions))] Vector2 direction,
//                                          [ValueSource(nameof(s_speeds))] float speed,
//                                          [ValueSource(nameof(s_accelerationTimes))] float accelerationTime,
//                                          [ValueSource(nameof(s_decelerationTimes))] float decelerationTime,
//                                          [ValueSource(nameof(s_initialVelocity))] Vector2 initialVelocity)
//        {
//            //arrange
//            var go = new GameObject();
//            var actualRb = go.AddComponent<Rigidbody2D>();
//            actualRb.gravityScale = 0f;
//            actualRb.velocity = initialVelocity;

//            var targetTranslation = direction * speed;
//            bool isStopping = direction.magnitude < 0.2f;
//            var startPosition = actualRb.position;

//            var mover = go.AddComponent<Mover>();
//            var so = new SerializedObject(mover);
//            so.FindProperty("_accelerationTime").floatValue = accelerationTime;
//            so.FindProperty("_decelerationTime").floatValue = decelerationTime;
//            so.ApplyModifiedProperties();


//            //act
//            mover.gettargetposition(direction, speed);
//            Class target = new Class();
//            PrivateObject obj = new PrivateObject(mover);
//            var actual = obj.Invoke("PrivateMethod");


//            //assert
//            Assert.AreEqual(actualRb.position, expectedRb.position);




//            void ExpectedMove()
//            {
//                var smoothVelocity = Vector2.zero;
//                var targetPosition = startPosition + targetTranslation;
//                var expectedPosition = Vector2.SmoothDamp(startPosition,
//                                                          targetPosition,
//                                                          ref smoothVelocity,
//                                                          isStopping ? decelerationTime : accelerationTime);
//                expectedRb.MovePosition(expectedPosition);
//            }
//        }



//        [UnityTest]
//        public IEnumerator Move([ValueSource(nameof(s_directions))] Vector2 direction,
//                                [ValueSource(nameof(s_speeds))] float speed,
//                                [ValueSource(nameof(s_accelerationTimes))] float accelerationTime,
//                                [ValueSource(nameof(s_decelerationTimes))] float decelerationTime,
//                                [ValueSource(nameof(s_initialVelocity))] Vector2 initialVelocity)
//        {
//            //arrange
//            var actualGo = new GameObject();
//            var expectedGo = new GameObject();
//            var actualRb = actualGo.AddComponent<Rigidbody2D>();
//            actualRb.gravityScale = 0f;
//            actualRb.velocity = initialVelocity;
//            var expectedRb = expectedGo.AddComponent<Rigidbody2D>(actualRb);

//            var targetTranslation = direction * speed;
//            bool isStopping = direction.magnitude < 0.2f;
//            var startPosition = actualRb.position;

//            var mover = actualGo.AddComponent<Mover>();
//            var so = new SerializedObject(mover);
//            so.FindProperty("_accelerationTime").floatValue = accelerationTime;
//            so.FindProperty("_decelerationTime").floatValue = decelerationTime;
//            so.ApplyModifiedProperties();


//            //act
//            mover.Move(direction, speed);
//            ExpectedMove();
//            yield return new WaitForFixedUpdate();


//            //assert
//            Assert.AreEqual(actualRb.position, expectedRb.position);




//            void ExpectedMove()
//            {
//                var smoothVelocity = Vector2.zero;
//                var targetPosition = startPosition + targetTranslation;
//                var expectedPosition = Vector2.SmoothDamp(startPosition,
//                                                          targetPosition,
//                                                          ref smoothVelocity,
//                                                          isStopping ? decelerationTime : accelerationTime);
//                expectedRb.MovePosition(expectedPosition);
//            }
//        }
//    }
//}