using System.Collections.Generic;

namespace FitnessTracker.Domain
{
    public class WalkingActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            decimal totalCalories = 0;

            if (metrics.TryGetValue("M7", out decimal steps))
                totalCalories += (steps / 1000m) * 40;

            if (metrics.TryGetValue("M8", out decimal duration))
                totalCalories += duration * 4;

            if (metrics.TryGetValue("M9", out decimal pace))
                totalCalories += (1 / pace) * 30; // faster pace = more cal

            return totalCalories;
        }
    }

}
