using TopDownGame;
using UnityEditor;

namespace ObjectReferences
{
    public abstract class ObservableReference<T> : ObjectReference<Observable<T>>
    {
        protected virtual void OnEnable()
        {
            _value ??= new Observable<T>();
        }
    }
}