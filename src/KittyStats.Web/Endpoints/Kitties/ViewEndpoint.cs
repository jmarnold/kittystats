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
            return new KittyViewModel
                       {
                           Kitty = _repository.Find<Kitty>("kitties/{0}".ToFormat(request.Id))
                       };
        }
    }
}