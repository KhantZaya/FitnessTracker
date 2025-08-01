using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class SwimmingActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            decimal totalCalories = 0;

            if (metrics.TryGetValue("M4", out decimal laps))
                totalCalories += laps * 15;

            if (metrics.TryGetValue("M5", out decimal duration))
                totalCalories += duration * 8;

            if (metrics.TryGetValue("M6", out decimal strokeRate))
                totalCalories += strokeRate * 2;

            return totalCalories;
        }
    }

}
