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
            return new DashboardModel
                       {
                           Kitties = _repository.FindAll<Kitty>().ToList()
                       };
        }
    }
}