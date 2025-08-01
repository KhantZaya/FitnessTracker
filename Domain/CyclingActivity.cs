using System.Collections.Generic;

namespace FitnessTracker.Domain
{
    public class CyclingActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            decimal totalCalories = 0;

            if (metrics.TryGetValue("M10", out decimal distance))
                totalCalories += distance * 40;

            if (metrics.TryGetValue("M11", out decimal duration))
                totalCalories += duration * 6;

            if (metrics.TryGetValue("M12", out decimal elevation))
                totalCalories += (elevation / 10m) * 5;

            return totalCalories;
        }
    }

}
