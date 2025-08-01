using System.Collections.Generic;

namespace FitnessTracker.Domain
{
    public class DefaultActivity : ActivityBase
    {
        public override decimal CalculateCalories(Dictionary<string, decimal> metrics)
        {
            if (metrics == null || metrics.Count == 0)
                return 0;

            decimal calories = 0;

            // 1. Base calories based on Duration (avg ~5-10 cal/min)
            if (metrics.TryGetValue("Duration", out decimal duration))
                calories += duration * 7.5m; // Moderate estimate: 7.5 cal/min

            // 2. Distance-based calories (~60-100 cal/km depending on speed)
            if (metrics.TryGetValue("Distance", out decimal distanceKm))
                calories += distanceKm * 80m; // Avg 80 cal/km

            // 3. Steps-based calories (~0.04 cal/step)
            if (metrics.TryGetValue("Steps", out decimal steps))
                calories += steps * 0.04m;

            // 4. Intensity multiplier (scale 1-10, increases burn by up to 50%)
            if (metrics.TryGetValue("Intensity Level", out decimal intensity) && intensity > 1)
                calories *= (1 + (intensity / 20m)); // 5% extra per intensity level

            // 5. Speed adjustment (faster = more calories)
            if (metrics.TryGetValue("Speed", out decimal speedKmPerH) && speedKmPerH > 0)
                calories *= (1 + (speedKmPerH / 50m)); // +2% per km/h over baseline

            // 6. Elevation gain bonus (~5 cal per meter climbed)
            if (metrics.TryGetValue("Elevation Gain", out decimal elevationMeters))
                calories += elevationMeters * 5m;

            // Ensure non-negative
            return calories > 0 ? calories : 0;
        }
    }
}