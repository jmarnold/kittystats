using System;
using System.Linq;
using KittyStats.Domain;
using KittyStats.Web.Models;

namespace KittyStats.Web.Endpoints
{
    public class DashboardEndpoint
    {
        private readonly IRepository _repository;

        public DashboardEndpoint(IRepository repository)
        {
            _repository = repository;
        }

        public DashboardModel Get(DashboardRequestModel request)
        {
            var kitties = _repository.FindAll<Kitty>().ToList();
            DateTime lastFeed = DateTime.Now;
            foreach(var kitty in kitties)
            {
                var feed = kitty.LastFeeding();
                if(feed == null)
                {
                    continue;
                }

                if(feed.Time < lastFeed)
                {
                    lastFeed = feed.Time;
                }
            }

            var nextFeedingTime = lastFeed.AddHours(2);
            return new DashboardModel
                       {
                           NextFeedingTime = nextFeedingTime,
                           Time = (nextFeedingTime - DateTime.Now).Minutes.ToString(),
                           Kitties = kitties
                       };
        }
    }
}