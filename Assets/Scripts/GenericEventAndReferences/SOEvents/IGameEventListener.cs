namespace GenericEventAndReferences.SOEvents
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}