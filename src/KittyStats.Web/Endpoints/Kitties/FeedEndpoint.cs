using System;
using FubuCore;
using FubuMVC.Core.Continuations;
using KittyStats.Commands;
using KittyStats.Domain;
using KittyStats.Web.Models;

namespace KittyStats.Web.Endpoints.Kitties
{
    public class FeedEndpoint
    {
        private readonly IRepository _repository;
        private readonly ICommandDispatcher _commandDispatcher;

        public FeedEndpoint(IRepository repository, ICommandDispatcher commandDispatcher)
        {
            _repository = repository;
            _commandDispatcher = commandDispatcher;
        }

        public LogFeedViewModel Get(LogFeedingRequest request)
        {
            var kittyId = "kitties/{0}".ToFormat(request.Id);
            var kitty = _repository.Find<Kitty>(kittyId);

            var lastFeeding = kitty.LastFeeding() ?? new Feeding();
            var feeding = new Feeding
                              {
                                  Time = DateTime.Now,
                                  FoodType = lastFeeding.FoodType,
                                  WeightBefore = lastFeeding.WeightBefore,
                                  WeightAfter = lastFeeding.WeightAfter
                              };

            return new LogFeedViewModel
                       {
                           Kitty = kitty,
                           LastFeeding = kitty.LastFeeding(),
                           KittyId = kittyId,
                           Feeding = feeding
                       };
        }

        public FubuContinuation Post(LogFeed feed)
        {
            _commandDispatcher.Dispatch(feed);
            var kitty = _repository.Find<Kitty>(feed.KittyId);
            return FubuContinuation.RedirectTo(new ViewKittyRequest {Id = kitty.Identifier()});
        }
    }
}