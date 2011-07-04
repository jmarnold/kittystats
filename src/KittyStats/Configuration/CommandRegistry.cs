using KittyStats.Processors;
using StructureMap.Configuration.DSL;

namespace KittyStats.Configuration
{
    public class CommandRegistry : Registry
    {
        public CommandRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.ConnectImplementationsToTypesClosing(typeof (ICommandProcessor<>));
                         x.AddAllTypesOf(typeof (ICommandProcessor<>));
                     });
        }    
    }
}