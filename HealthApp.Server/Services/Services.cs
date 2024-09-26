using HealthApp.Server.Models;
using System.Globalization;

namespace HealthApp.Server.Services
{
    public class Services
    {
        /// <summary>
        /// Calculates the Resting Metabolic Rate (RMR) using the Mifflin-St Jeor equation.
        /// If gender is not set it will default to the male calculation.
        /// </summary>
        /// <returns>int</returns>
        public decimal RMR(User user, DailyMeasurement dm)
        {
            decimal res;
            if (user.Gender == null || user.Gender == "male")
            {
                res = 10 * dm.WeightKg + (decimal)6.25 * user.HeightCm - 5 * user.Age + 5;
            }
            else
            {
                res = 10 * dm.WeightKg + (decimal)6.25 * user.HeightCm - 5 * user.Age - 161;
            }
            return res;
        }
        /// <summary>
        /// Calculates the Basal metabolic rate based on the Harris-Benedict equation. It uses the RMR and multiplies this value by and number that corresponds to activity level.
        /// The resulting number is the daily Kilocalorie intake required to maintain current body rate.
        /// </summary>
        /// <returns>decimal</returns>
        public decimal BMR(User user, DailyMeasurement dm)
        {
            if (dm.ActivityLevel == null)
            {
                return -1;
            }
            decimal multiplier = ActivityLevelMethods.GetActivityValue(dm.ActivityLevel);
            decimal RMR = this.RMR(user, dm);
            return RMR * multiplier;
        }
    }
    enum ActivityLevels
    {
        sedentary,
        light,
        moderate,
        active,
        very
    };
    public static class ActivityLevelMethods
    {
        public static decimal GetActivityValue(this string activityValue)
        {

            switch (activityValue)
            {
                case nameof(ActivityLevels.sedentary):
                    return (decimal)1.2;
                case nameof(ActivityLevels.light):
                    return (decimal)1.375;
                case nameof(ActivityLevels.moderate):
                    return (decimal)1.55;
                case nameof(ActivityLevels.active):
                    return (decimal)1.725;
                case nameof(ActivityLevels.very):
                    return (decimal)1.9;
                default:
                    return -1;
            }
        }
    }
}
