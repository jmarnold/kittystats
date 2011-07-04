using System;
using Raven.Client;
using Raven.Json.Linq;

namespace KittyStats.Events
{
    public class LoggingEventHandler<T> : IEventHandler<T> where T : class
    {
        private readonly IDocumentStore _documentStore;

        public LoggingEventHandler(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Handle(T @event)
        {
            _documentStore
                .DatabaseCommands
                .Put(string.Format("events/{0}", Guid.NewGuid()), null, RavenJObject.FromObject(@event), new RavenJObject());
        }
    }
}