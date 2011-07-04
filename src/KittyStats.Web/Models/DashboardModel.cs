using System.Collections.Generic;
using KittyStats.Domain;

namespace KittyStats.Web.Models
{
    public class DashboardModel
    {
        public DashboardModel()
        {
            Kitties = new List<Kitty>();
        }

        public IEnumerable<Kitty> Kitties { get; set; }
    }
}