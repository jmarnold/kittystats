using KittyStats.Domain;

namespace KittyStats.Commands
{
    public class LogFeed
    {
        public string KittyId { get; set; }
        public Feeding Feeding { get; set; }
    }
}