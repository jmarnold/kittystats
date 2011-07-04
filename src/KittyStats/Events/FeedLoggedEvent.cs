using KittyStats.Domain;

namespace KittyStats.Events
{
    public class FeedLoggedEvent
    {
        public string KittyId { get; set; }
        public Feeding Feeding { get; set; }
    }
}