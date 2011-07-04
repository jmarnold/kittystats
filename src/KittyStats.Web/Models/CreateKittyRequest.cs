using System.Linq;
using FubuMVC.Core;
using KittyStats.Commands;
using KittyStats.Domain;

namespace KittyStats.Web.Models
{
    public class CreateKittyRequest
    { 
    }

    public class CreateKittyInput : Kitty
    {
    }

    public class LogFeedingRequest
    {
        [RouteInput]
        public string Id { get; set; }
    }

    public class LogFeedViewModel : LogFeed
    {
        public Feeding LastFeeding { get; set; }
        public Kitty Kitty { get; set; }
    }

    public class ViewKittyRequest
    {
        [RouteInput]
        public string Id { get; set; }
    }

    public class KittyViewModel
    {
        public Kitty Kitty { get; set; }
        public double CurrentWeight
        {
            get
            {
                var lastFeeding = Kitty
                    .Feedings
                    .OrderByDescending(f => f.Time)
                    .FirstOrDefault();

                if (lastFeeding == null) return 0;

                return lastFeeding.WeightAfter;
            }
        }
        
        public object[] ChartData()
        {
            return Kitty
                .Feedings
                .Select(f => new object[2] { f.Time.ToString("MM/dd/yyyy HH:mm"), f.WeightAfter })
                .ToArray();
        }
    }
}