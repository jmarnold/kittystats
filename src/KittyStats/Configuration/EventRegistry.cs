using KittyStats.Events;
using StructureMap.Configuration.DSL;

namespace KittyStats.Configuration
{
    public class EventRegistry : Registry
    {
        public EventRegistry()
        {
            For(typeof (IEventHandler<>)).Use(typeof (LoggingEventHandler<>));
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.ConnectImplementationsToTypesClosing(typeof (IEventHandler<>));
                         x.AddAllTypesOf(typeof (IEventHandler<>));
                     });
        }
    }
}