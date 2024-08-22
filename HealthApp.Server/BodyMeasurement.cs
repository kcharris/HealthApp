namespace HealthApp.Server
{
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
                    return  (decimal)1.2;
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
    public class BodyMeasurement
    {
        public DateOnly Date { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public decimal HeightCm { get; set; }
        public decimal WeightKg { get; set; }
        public string? ActivityLevel { get; set; }
        
        /// <summary>
        /// Calculates the Resting Metabolic Rate (RMR) using the Mifflin-St Jeor equation.
        /// If gender is not set it will default to the male calculation.
        /// </summary>
        /// <returns>int</returns>
        public decimal RMR()
        {
            decimal res;
            if (this.Gender == null || this.Gender == "male"){
                res = 10 * this.WeightKg + (decimal)6.25 * this.HeightCm - 5 * this.Age + 5;
            }
            else
            {
                res = 10 * this.WeightKg + (decimal)6.25 * this.HeightCm - 5 * this.Age - 161;
            }
            return res;
        }
        /// <summary>
        /// Calculates the Basal metabolic rate based on the Harris-Benedict equation. It uses the RMR and multiplies this value by and number that corresponds to activity level.
        /// The resulting number is the daily Kilocalorie intake required to maintain current body rate.
        /// </summary>
        /// <returns>decimal</returns>
        public decimal BMR(string activityLevel)
        {
            decimal multiplier = ActivityLevelMethods.GetActivityValue(activityLevel);
            decimal RMR = this.RMR();
            return RMR * multiplier;
        }
    }
}
