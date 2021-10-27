namespace TopDownGame
{
    public interface IObservableProvider<T>
    {
        Observable<T> Observed { get; }
    }
}
