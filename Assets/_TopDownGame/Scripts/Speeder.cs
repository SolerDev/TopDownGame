using UnityEngine;

namespace TopDownGame
{
    public class Speeder : MonoBehaviour, ISpeeder
    {
        [SerializeField] private float _speed;
        public Observable<float> Speed { get; } = new Observable<float>(5);

#if UNITY_EDITOR

        private float _oldSpeed;

        private void LateUpdate()
        {
            if (_oldSpeed != _speed)
            {
                _oldSpeed = _speed;
                Speed.Set(_speed);
            }
        }

#endif
    }

    public interface ISpeeder
    {
        Observable<float> Speed { get; }
    }
}
