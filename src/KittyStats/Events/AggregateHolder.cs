using Raven.Json.Linq;

namespace KittyStats.Events
{
    public class AggregateHolder
    {
        public string KittyId { get; set; }
        public RavenJObject Aggregate { get; set; }
    }
}