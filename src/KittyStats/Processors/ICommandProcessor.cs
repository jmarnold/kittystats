namespace KittyStats.Processors
{
    public interface ICommandProcessor<T>
        where T : class
    {
        void Process(T command);
    }
}