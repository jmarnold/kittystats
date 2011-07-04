using StructureMap.Configuration.DSL;

namespace KittyStats.Configuration
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                         x.LookForRegistries();
                     });
        }
    }
}