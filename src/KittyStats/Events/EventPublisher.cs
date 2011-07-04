using System.Linq;
using StructureMap;

namespace KittyStats.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IContainer _container;

        public EventPublisher(IContainer container)
        {
            _container = container;
        }

        public void Publish<T>(T @event)
            where T : class
        {
            _container
                .GetAllInstances<IEventHandler<T>>()
                .ToList()
                .ForEach(handler => handler.Handle(@event));
        }
    }
}