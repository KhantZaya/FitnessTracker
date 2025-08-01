using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain.FitnessTracker.Domain;

namespace FitnessTracker.Domain
{
    public class ActivityFactory {
        public static ActivityBase Create(string activityId)
        {
            switch (activityId)
            {
                case "A1":
                    return new RunningActivity();
                case "A2":
                    return new SwimmingActivity();
                case "A3":
                    return new WalkingActivity();
                case "A4":
                    return new CyclingActivity();
                case "A5":
                    return new JumpRopeActivity();
                case "A6":
                    return new HikingActivity();
                default:
                    return new DefaultActivity();
            }
        }
    }
}
