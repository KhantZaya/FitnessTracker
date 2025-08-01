using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public abstract class ActivityBase
    {
        public abstract decimal CalculateCalories(Dictionary<string, decimal> metricValues);
    }
}
