namespace KittyStats.Events
{
    public interface IEventHandler<T>
        where T : class
    {
        void Handle(T @event);
    }
}