using UnityEngine;

namespace ObjectReferences
{
    public abstract class ObservableRawDataReference<T> : ObservableReference<T>
    {
        [SerializeField] private T _dataValue;

        protected override void OnEnable()
        {
            base.OnEnable();
            _dataValue = Get().Read();
        }

        private void OnValidate()
        {
            var observable = Get();
            if (!observable.Read().Equals(_dataValue))
                observable.Write(_dataValue);
        }
    }
}