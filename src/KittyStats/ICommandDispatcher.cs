namespace KittyStats
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : class;
    }
}