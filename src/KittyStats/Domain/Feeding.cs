using System;

namespace KittyStats.Domain
{
    public class Feeding
    {
        public Feeding()
        {
            Time = DateTime.Now;
            FoodType = "2:1";
        }

        public DateTime Time { get; set; }
        public double WeightBefore { get; set; }
        public double WeightAfter { get; set; }
        public string FoodType { get; set; }
        public string Notes { get; set; }
    }
}