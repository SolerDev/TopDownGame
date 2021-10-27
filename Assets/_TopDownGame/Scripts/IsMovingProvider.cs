using UnityEngine;

namespace TopDownGame
{
    public class IsMovingProvider : MonoBehaviour, IObservableProvider<bool>
    {
        private readonly Observable<bool> _isMoving = new Observable<bool>();
        public Observable<bool> Observed => _isMoving;
    }
}
