using System;
using UnityEngine;

namespace ObjectReferences
{
    public class ObjectReference : ScriptableObject
    {
        protected object _value;

        public object Get()
        {
            return _value;
        }

        public void Set(object value)
        {
            _value = value;
        }
    }

    public class ObjectReference<T> : ObjectReference
    {
        public new T Get()
        {
            return (T)_value;
        }

        public static implicit operator T(ObjectReference<T> obj)
        {
            return obj.Get();
        }
    }
}