using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class Goal
    {
        public string GoalID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public decimal TargetCalories { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; } 
    }
}
