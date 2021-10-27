using UnityEngine;

namespace TopDownGame
{
    public class SpeedProvider : MonoBehaviour, IObservableProvider<float>
    {
        [SerializeField] private float _speed;
        private readonly Observable<float> _observedSpeed = new Observable<float>(5);
        public Observable<float> Observed => _observedSpeed;


#if UNITY_EDITOR

        private float _oldSpeed;

        private void LateUpdate()
        {
            if (_oldSpeed != _speed)
            {
                _oldSpeed = _speed;
                _observedSpeed.Set(_speed);
            }
        }

#endif
    }
}
