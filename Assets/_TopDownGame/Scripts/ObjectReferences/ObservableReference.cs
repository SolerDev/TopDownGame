using TopDownGame;

namespace ObjectReferences
{
    public abstract class ObservableReference<T> : ObjectReference<Observable<T>>
    {
        private void OnEnable()
        {
            Initialize();
        }

        protected abstract void Initialize();
    }
}