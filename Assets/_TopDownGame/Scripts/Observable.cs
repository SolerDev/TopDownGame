using System;

namespace TopDownGame
{
    public class Observable<T>
    {
        public event Action<T> OnValueChanged;

        private T _value;

        public Observable(T value = default)
        {
            _value = value;
        }

        public T Read()
        {
            return _value;
        }

        public void Write(T value)
        {
            if (value.Equals(_value))
                return;

            _value = value;
            OnValueChanged?.Invoke(_value);
        }

        public static implicit operator T(Observable<T> obs)
        {
            return obs.Read();
        }
    }
}
