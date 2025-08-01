using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class RunningActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            decimal totalCalories = 0;

            if (metrics.TryGetValue("M1", out decimal distance))
                totalCalories += distance * 60;  // Distance-based

            if (metrics.TryGetValue("M2", out decimal duration))
                totalCalories += duration * 10;  // Duration-based

            if (metrics.TryGetValue("M3", out decimal speed))
                totalCalories += speed * 5;      // Speed-based

            return totalCalories;
        }

    }
}
