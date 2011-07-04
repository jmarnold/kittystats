using System.Linq;
using KittyStats.Processors;
using StructureMap;

namespace KittyStats
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            _container = container;
        }

        public void Dispatch<T>(T command) 
            where T : class
        {
            _container
                .GetAllInstances<ICommandProcessor<T>>()
                .ToList()
                .ForEach(p => p.Process(command));
        }
    }
}