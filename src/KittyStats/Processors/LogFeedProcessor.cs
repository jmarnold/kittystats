using KittyStats.Commands;
using KittyStats.Domain;
using KittyStats.Events;

namespace KittyStats.Processors
{
    public class LogFeedProcessor : ICommandProcessor<LogFeed>
    {
        private readonly IRepository _repository;
        private readonly IEventPublisher _eventPublisher;

        public LogFeedProcessor(IEventPublisher eventPublisher, IRepository repository)
        {
            _eventPublisher = eventPublisher;
            _repository = repository;
        }

        public void Process(LogFeed command)
        {
            var kitty = _repository.Find<Kitty>(command.KittyId);
            kitty
                .Feedings
                .Add(command.Feeding);

            _repository.Save();

            _eventPublisher
                .Publish(new FeedLoggedEvent
                             {
                                 KittyId = command.KittyId,
                                 Feeding = command.Feeding
                             });
        }
    }
}