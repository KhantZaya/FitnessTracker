using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class HikingActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            decimal totalCalories = 0;

            if (metrics.TryGetValue("M1", out decimal distance))
                totalCalories += distance * 45; // ~45 cal/km

            if (metrics.TryGetValue("M12", out decimal elevation))
                totalCalories += (elevation / 10m) * 6; // ~6 cal per 10m gain

            if (metrics.TryGetValue("M14", out decimal duration))
                totalCalories += duration * 5; // ~5 cal/min

            return totalCalories;
        }
    }

}
