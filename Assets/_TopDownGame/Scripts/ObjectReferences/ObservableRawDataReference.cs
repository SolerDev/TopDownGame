using System;
using TopDownGame;
using UnityEngine;

namespace ObjectReferences
{
    public abstract class ObservableRawDataReference<T> : ObservableReference<T>
    {
        [SerializeField] private T _dataValue;


        protected override void Initialize()
        {
            _value = new Observable<T>(_dataValue);
        }

        private void OnValidate()
        {
            if (!_dataValue.Equals(Get().Read()))
                Get().Write(_dataValue);
        }
    }
}