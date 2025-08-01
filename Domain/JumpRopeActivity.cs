using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    using System.Collections.Generic;

    namespace FitnessTracker.Domain
    {
        public class JumpRopeActivity : ActivityBase
        {
            public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
            {
                decimal totalCalories = 0;

                if (metrics.TryGetValue("M13", out decimal jumps))
                    totalCalories += (jumps / 100m) * 12;

                if (metrics.TryGetValue("M14", out decimal duration))
                    totalCalories += duration * 10;

                if (metrics.TryGetValue("M15", out decimal intensity))
                    totalCalories += intensity * 5;

                return totalCalories;
            }
        }

    }

}
