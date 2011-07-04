using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;

namespace KittyStats.Configuration
{
    public class RavenRegistry : Registry
    {
        public RavenRegistry()
        {
            For<IDocumentStore>()
                .Use(() =>
                         {
                             var store = new DocumentStore
                                             {
                                                 ConnectionStringName = "KittyStats"
                                             };
                             store.Initialize();

                             return store;
                         });

            For<IDocumentSession>()
                .Use(ctx => ctx.GetInstance<IDocumentStore>().OpenSession());
        }
    }
}