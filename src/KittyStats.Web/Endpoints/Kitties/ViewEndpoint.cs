using FubuCore;
using KittyStats.Domain;
using KittyStats.Web.Models;

namespace KittyStats.Web.Endpoints.Kitties
{
    public class ViewEndpoint
    {
        private readonly IRepository _repository;

        public ViewEndpoint(IRepository repository)
        {
            _repository = repository;
        }

        public KittyViewModel Get(ViewKittyRequest request)
        {
            var kitty = _repository.Find<Kitty>("kitties/{0}".ToFormat(request.Id));
            return new KittyViewModel
                       {
                           LastMeds = kitty.LastMeds(),
                           LastStimulated = kitty.LastStimulation(),
                           Kitty = kitty,
                           LastFeeding = kitty.LastFeeding()
                       };
        }
    }
}