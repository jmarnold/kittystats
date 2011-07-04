using System;
using System.Collections.Generic;
using System.Linq;

namespace KittyStats.Domain
{
    public class Kitty
    {
        public Kitty()
        {
            Feedings = new List<Feeding>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<Feeding> Feedings { get; set; }

        public Feeding LastFeeding()
        {
            return Feedings
                .OrderByDescending(f => f.Time)
                .FirstOrDefault();
        }

        public Feeding LastMeds()
        {
            return Feedings
                .Where(f => f.MedsGiven)
                .OrderByDescending(f => f.Time)
                .FirstOrDefault();
        }

        public Feeding LastStimulation()
        {
            return Feedings
                .Where(f => f.Stimulated)
                .OrderByDescending(f => f.Time)
                .FirstOrDefault();
        }

        public string Identifier()
        {
            return Id.Replace("kitties/", "");
        }
    }
}