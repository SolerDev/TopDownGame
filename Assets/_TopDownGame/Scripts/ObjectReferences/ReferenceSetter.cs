using UnityEngine;

namespace ObjectReferences
{
    public abstract class ReferenceSetter<T> : MonoBehaviour
    {
        [SerializeField] private ObjectReference<T> _objectReference;

        private void Awake()
        {
            _objectReference.Set(GetReference());
        }

        protected abstract T GetReference();
    }
}